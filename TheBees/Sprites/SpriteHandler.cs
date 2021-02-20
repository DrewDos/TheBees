using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;

using TheBees.UnitData;
using TheBees.Records;
using TheBees.User;

using SpriteCreator;
using TheBees.Data;

namespace TheBees.Sprites
{
    static class SpriteHandler
    {
        static public void LoadAllSpriteDefs()
        {
            int start = 0x00000 / 8;
            int max = 0x80000 / 8;
            int count = max - start;

            for (int i = 0; i < count; i++)
            {
                uint address = RomData.Get32(0x6800004, (i * 8));

                if (address != 0)
                {
                    NormalSpriteDef.GetRecordable(address, ProblemIndexes.IsProblemIndex(i));
                    NormalSpriteDef.AddPointerIndex(address, i);
                }
            }
        }

        static public void SetOperationCompleteCallback()
        {
            RecordSpaceGroup.OperationCompleteEvent += NormalSpriteDef.SpaceUpdateComplete;
        }

        static public void RemoveOperationCompleteCallback()
        {
            RecordSpaceGroup.OperationCompleteEvent -= NormalSpriteDef.SpaceUpdateComplete;
        }

        static public void BeforeRecordSaveBase()
        {
            //SpriteLoader.InitBaseData();
        }

        static public Sprite GetSprite(int index, bool flipX = false, bool flipY = false)
        {
            uint spriteDefAddress = (uint)index * SpriteSpec.SpriteIndexSize + SpriteSpec.SpriteDefOffset;
            uint dataAddress = RomData.Get32(spriteDefAddress, 4);

            if (dataAddress != 0x00)
            {
                short xAxis = (short)RomData.Get16(spriteDefAddress);
                short yAxis = (short)RomData.Get16(spriteDefAddress, 2);

                int size = RomData.Get16(dataAddress, 4) * 8 + RomData.Get16(dataAddress, 6) * 8 + 0x0C;


                return new NormalSprite(dataAddress, xAxis, yAxis, flipX, flipY);
            }

            return null;
        }
        
        static public int CreateSprite(string bmpSrc, Color[] pallet, SpriteRegion targetRegion, LookupTag lookupTag)
        {

            SpriteRomInfo romData = SpriteCreator.ImageConverter.GetSpriteData(bmpSrc, pallet);

            // ensure size is available

            if (!RecordGuide.UserSpace.FreeSizeAvailable(null, romData.GetTileDataSize()))
                throw new Exception("Not enough free space");

            if (!RecordGuide.ProgramSpace.FreeSizeAvailable(null, romData.GetSpriteDataSize()))
                throw new Exception("Not enough free program space");


            byte[][] dataBlocks = romData.GetTileDataBlocks();

            //
            // setup tile data
            //

            RecordSpace tileSpace = RecordGuide.UserSpace.GetSpaceFromFreeSize(romData.GetTileDataSize());

            uint startDataOffset = tileSpace.GetNewRecordStart();
            List<RomDataBlock> blocks = new List<RomDataBlock>();
            List<uint> blockLocations = new List<uint>();

            for (int i = 0; i < dataBlocks.Length; i++)
            {
                uint dataOffset = tileSpace.GetNewRecordStart();

                Record tileRecord = RecordGuide.CreateRecord(dataOffset, dataBlocks[i].Length);
                dataOffset = tileSpace.AddRecord(tileRecord);
                blockLocations.Add(dataOffset);
                RomData.SetBlock(dataOffset, dataBlocks[i]);
            }
            //
            // setup sprite data
            //

            RecordSpace dataSpace = RecordGuide.ProgramSpace.GetSpaceFromFreeSize(romData.GetSpriteDataSize());
            uint newAddress = dataSpace.GetNewRecordStart();

            Record spriteDefRecord = RecordGuide.CreateRecord(newAddress, romData.GetSpriteDataSize());
            dataSpace.AddRecord(spriteDefRecord);
            RomData.SetBlock(newAddress, romData.GetSpriteData(lookupTag.Address, blockLocations.ToArray()));

            if (NormalSpriteDef.DefExists(newAddress))
                throw new Exception("Def already exists in address 0x" + newAddress.ToString("X8"));

            // unlock lookup block
            RomDataBlock lookupBlock = LookupBlock.GetRecordable(lookupTag.Address);
            lookupBlock.Reset();
            // load sprites
            NormalSpriteDef newDef = NormalSpriteDef.GetRecordable(newAddress);
            blocks.ForEach((x) => x.LoadComplete());
            // lock the block back up
            lookupBlock.LoadComplete();

            // lock lookup block
            int newIndex = targetRegion.GetFirstUnusedIndex();
            NormalSpriteDef.AddPointerIndex(newAddress, newIndex);
            SpriteMap.UpdateSpriteDefPointer(newDef, newAddress);

            // setup axis
            SpriteMap.UpdateSpriteAxis(newIndex, (short)((romData.Width / 2) * -1), (short)((romData.Height / 2) * -1));
            return newIndex;
        }

        static public int GetNumImages(string dirSrc)
        {
            return Directory.GetFiles(dirSrc, "*.bmp").Length;
        }

        static public int[] ConvertImagesFromFiles(string[] files, Color[] pallet, SpriteRegion targetRegion, LookupTag lookupTag)
        {
            List<int> newIndexes = new List<int>();

            for (int i = 0; i < files.Length; i++)
            {
                newIndexes.Add(CreateSprite(files[i], pallet, targetRegion, lookupTag));
            }

            return newIndexes.ToArray();
        }

        static public int RemoveSprite(int index)
        {
            uint address = SpriteMap.GetSpriteAddress(index);

            if (address != 0x00)
            {
                ((NormalSpriteDef)Recordable.MasterList[address]).ClearData();

                RecordGuide.UserSpace.ConsolidateEachSpace();
                RecordGuide.ProgramSpace.ConsolidateEachSpace();

                RecordSpaceGroup.OperationComplete();

                return 1;
            }
            return 0;            
        }

        static public DataOpSummary RemoveSpriteWithSummary(params int [] indexes)
        {

            int numRemoved = 0;

            SpaceGroupSummary programBefore = new Records.SpaceGroupSummary("Program Space", RecordGuide.ProgramSpace);
            SpaceGroupSummary userBefore = new Records.SpaceGroupSummary("User Space", RecordGuide.UserSpace);

            foreach (int index in indexes)
            {
                uint address = SpriteMap.GetSpriteAddress(index);
                if (address != 0x00)
                {
                    ((NormalSpriteDef)Recordable.MasterList[address]).ClearData();
                    numRemoved += 1;
                }
            }

            RecordGuide.UserSpace.ConsolidateEachSpace();
            //RecordGuide.UserSpace.ConsolidateGroup();
            RecordGuide.ProgramSpace.ConsolidateEachSpace();

            RecordSpaceGroup.OperationComplete();

            SpaceGroupSummary programAfter = new Records.SpaceGroupSummary("Program Space", RecordGuide.ProgramSpace);
            SpaceGroupSummary userAfter = new Records.SpaceGroupSummary("User Space", RecordGuide.UserSpace);
            return new Records.DataOpSummary(numRemoved, programBefore, programAfter, userBefore, userAfter);


        }

    }
}
