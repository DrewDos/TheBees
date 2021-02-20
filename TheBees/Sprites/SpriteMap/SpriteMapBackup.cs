using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TheBees.Data;
using TheBees.Sprites;
using TheBees.Records;
using TheBees.User;

namespace TheBees.Sprites
{
    static public class SpriteMap
    {
        static private Dictionary<uint, NormalSpriteDef> spriteDataMasterList;
        static private Dictionary<uint, RomDataBlock> tileDataMasterList;
        static private Dictionary<uint, RomDataBlock> lookupTableMasterList;

        static public Dictionary<uint, NormalSpriteDef> SpriteDataMasterList { get { return spriteDataMasterList; } }
        static public Dictionary<uint, RomDataBlock> TileDataMasterList { get { return tileDataMasterList; } }
        static public Dictionary<uint, RomDataBlock> LookupTableMasterList { get { return lookupTableMasterList; } }


        //static private List<NormalSpriteDef> spriteList;

        static public void Initialize()
        {
            spriteDataMasterList = new Dictionary<uint,NormalSpriteDef>();
        }

        static public void Clear()
        {
            spriteDataMasterList = null;
            lookupTableMasterList = null;
            tileDataMasterList = null;
        }

        static public RomDataBlock CreateLookupTable()
        {
            if (!RecordGuide.UserSpace.FreeSizeAvailable(0x100))
                throw new Exception("Not enough free size available");

            Record record = RecordGuide.UserSpace.CreateRecordForNewData(0x100);
            RomDataBlock table = new RomDataBlock(record.Start);
            table.SetRecord(record);

            if (lookupTableMasterList.ContainsKey(record.Start))
                throw new Exception("Lookup table in this location already exists");

            lookupTableMasterList[record.Start] = table;

            return table;
            
        }

        static public RomDataBlock GetLookupBlock(uint address)
        {
            if (!lookupTableMasterList.ContainsKey(address))
            {
                RomDataBlock block = new RomDataBlock(address);
                lookupTableMasterList[address] = block;
            }

            return lookupTableMasterList[address];
        }

        static public RomDataBlock GetTileDataBlock(uint address)
        {
            if (!tileDataMasterList.ContainsKey(address))
            {
                RomDataBlock block = new RomDataBlock(address);
                tileDataMasterList[address] = block;
            }

            return tileDataMasterList[address];
        }

        static public void OnRomLoad(bool loadRecords = false)
        {

            spriteDataMasterList = new Dictionary<uint, NormalSpriteDef>();
            lookupTableMasterList = new Dictionary<uint, RomDataBlock>();
            tileDataMasterList = new Dictionary<uint,RomDataBlock>();

            SpriteGuide.OnRomLoad();            
            LoadAllSpriteDefs(loadRecords);
        }

        static public void InitBaseData()
        {
            if (spriteDataMasterList == null)
                LoadAllSpriteDefs(false);

            tileDataMasterList = new Dictionary<uint, RomDataBlock>();
            lookupTableMasterList = new Dictionary<uint, RomDataBlock>();

            // get tile data sizes for every single tile def

            foreach(KeyValuePair<uint, NormalSpriteDef> kvp in spriteDataMasterList)
            {
            
                NormalSpriteDef def = kvp.Value;

                if (def == null) continue;

                // get the block for each sprite
                int spriteDataSize = def.SizeInBytes;

                Record spriteDataRecord = new Record(def.Address, spriteDataSize);
                spriteDataMasterList[def.Address].RecordEntity = spriteDataRecord;


                // get the blocks for each lookup table
                if (!lookupTableMasterList.ContainsKey(def.RealLookupAddress))
                {
                    Record record = new Record(def.RealLookupAddress, 0x100);
                    RomDataBlock dataBlock = new RomDataBlock(def.RealLookupAddress);
                    dataBlock.SetRecord(record);
                    lookupTableMasterList[def.RealLookupAddress] = dataBlock;
                }

                def.LoadLookupBlock();

                // get sizes for each tile data 
                int[] dataSizes = GetTileDataSizes(def);
                
                for (int tileCtr = 0; tileCtr < def.TileList.Count; tileCtr++)
                {
                    TileDef currDef = def.TileList[tileCtr];

                    uint srcAddress = currDef.RealSource;

                    if (!tileDataMasterList.ContainsKey(srcAddress))
                    {
                        int size = dataSizes[tileCtr];

                        Record record = new Record(srcAddress, size);
                        RomDataBlock db = new RomDataBlock(srcAddress);
                        db.SetRecord(record);
                        tileDataMasterList[srcAddress] = db;
                    }

                    currDef.LoadTileDataBlock();
                    currDef.SetRealSource(srcAddress);


                }
            }

            LoadRecordsIntoSpaceGroup();

        }

        static private void LoadRecordsIntoSpaceGroup()
        {
            List<NormalSpriteDef> spriteList = spriteDataMasterList.Values.ToList().OrderBy(x => x.Address).ToList();

            // add all records to the program space and user space
            
            uint[] range = CheckSpriteDefSequence(spriteList);
            
            // all has passed, so creat the space group
            //RecordSpace spriteDataSpace = RecordHandler.ProgramSpace.CreateSpace(range[0], range[1]);
            
            // 2nd pass, add all records
            // all addresses should be the same as original
            for (int i = 0; i < spriteList.Count; i++)
            {
                RecordGuide.ProgramSpace.CreateSpaceFromRecord(spriteList[i].RecordEntity).AddRawRecord(spriteList[i].RecordEntity);
            }

            RecordGuide.ProgramSpace.Sort();
            RecordGuide.ProgramSpace.Consolidate();

            // load all lookup lists            
            List<RomDataBlock> lookupList = lookupTableMasterList.Values.ToList().OrderBy(x => x.Address).ToList();

            for (int i = 0; i < lookupList.Count; i++)
            {
                RecordGuide.UserSpace.CreateSpaceFromRecord(lookupList[i].RecordEntity).AddRawRecord(lookupList[i].RecordEntity);
            }

            // load all tile data now            
            List<RomDataBlock> tileDataList = tileDataMasterList.Values.ToList().OrderBy(x => x.Address).ToList();

            for (int i = 0; i < tileDataList.Count; i++)
            {
                RecordGuide.UserSpace.CreateSpaceFromRecord(tileDataList[i].RecordEntity).AddRawRecord(tileDataList[i].RecordEntity);
            }

            RecordGuide.UserSpace.Sort();
            RecordGuide.UserSpace.Consolidate();

        }

        static public void LoadAllSpriteDefs(bool loadBlocks)
        {
            int start = 0x00000 / 8;
            int max = 0x80000 / 8;
            int count = max - start;

            spriteDataMasterList = new Dictionary<uint, NormalSpriteDef>();
            Dictionary<uint, List<int>> spriteDataIndexes = new Dictionary<uint, List<int>>();
            for (int i = 0; i < count; i++)
            {
                uint address = RomData.Get32(0x6800004, (i * 8));

                if (address != 0)
                {
                    if (!spriteDataMasterList.ContainsKey(address))
                    {
                        spriteDataMasterList[address] = new NormalSpriteDef(address, ProblemIndexes.IsProblemIndex(i), loadBlocks);
                    }

                    if (!spriteDataIndexes.ContainsKey(address))
                    {
                        spriteDataIndexes[address] = new List<int>();
                    }

                    spriteDataIndexes[address].Add(i);
                }
            }

            foreach (NormalSpriteDef def in spriteDataMasterList.Values)
            {
                def.PointerIndexes = spriteDataIndexes[def.Address];
            }

            foreach (KeyValuePair<uint, RomDataBlock> block in tileDataMasterList)
            {
                block.Value.LoadComplete();
            }

            foreach (KeyValuePair<uint, RomDataBlock> block in lookupTableMasterList)
            {
                block.Value.LoadComplete();
            }
        }

        static private int [] GetTileDataSizes(NormalSpriteDef spriteDef)
        {                  
            List<TileDef> tileDefs = spriteDef.TileList;
            int [] tileDataSizes = new int[tileDefs.Count];
            int rawSize = GetRawDataSize(tileDefs);
            int dataSize = 0;
            for (int tileNum = 0; tileNum < tileDefs.Count; tileNum++)
            {

                uint currSource = tileDefs[tileNum].RealSource;

                if (!tileDataMasterList.ContainsKey(currSource))
                {
                    dataSize = CalcSpriteDataSize(
                        tileDefs[tileNum].RealSource,
                        tileDefs[tileNum].RealDestination,
                        tileDefs[tileNum].RealLength,
                        spriteDef.RealLookupAddress,
                        rawSize);

                }
                else
                {
                    dataSize = tileDataMasterList[currSource].SizeInBytes;
                }

                if (dataSize % 2 > 0)
                {
                    dataSize += 1;
                }
                tileDataSizes[tileNum] = dataSize;
            }

            return tileDataSizes;
        }

        static private int GetRawDataSize(List<TileDef> tileList)
        {
            int len = tileList.Count;
            uint result = 0;
            uint currSz = 0;

            for (int i = 0; i < len; i++)
            {
                currSz = tileList[i].RealDestination + tileList[i].RealLength;
                if (result < currSz)
                    result = currSz;
            }

            return (int)result;
        }

        static private int CalcSpriteDataSize(uint realSource, uint realDestination, uint realLength, uint lookupAddr, int rawDataSize)
        {
            uint startSource = realSource;
            int length = 0;

            uint lengthRemaining = realLength;
            byte lastNormalByte = 0;

            while (lengthRemaining > 0)
            {
                byte currentByte = RomData.Get8(realSource);
                realSource++;
                length = (int)(realSource - startSource);

                if ((currentByte & 0x80) > 0)
                {

                    byte realByte;
                    uint lengthProcessed;
                    currentByte &= 0x7f;

                    realByte = RomData.Get8(lookupAddr, currentByte * 2 + 0);

                    lengthProcessed = ProcessByte(realByte, realDestination, lengthRemaining, rawDataSize, ref lastNormalByte);
                    lengthRemaining -= lengthProcessed; // subtract the number of bytes the operation has taken
                    realDestination += lengthProcessed; // add it onto the destination
                    if (realDestination > rawDataSize) return length;
                    if (lengthRemaining <= 0) return length; // if we've expired, exit

                    realByte = RomData.Get8(lookupAddr, currentByte * 2 + 1);

                    lengthProcessed = ProcessByte(realByte, realDestination, lengthRemaining, rawDataSize, ref lastNormalByte);
                    lengthRemaining -= lengthProcessed; // subtract the number of bytes the operation has taken
                    realDestination += (uint)lengthProcessed; // add it onto the destination
                    //if (realDestination > rawDataSize) return;
                    if (lengthRemaining <= 0) return length;  // if we've expired, exit

                }
                else
                {

                    uint lengthProcessed;
                    lengthProcessed = (uint)ProcessByte(currentByte, realDestination, lengthRemaining, rawDataSize, ref lastNormalByte);
                    lengthRemaining -= lengthProcessed; // subtract the number of bytes the operation has taken
                    realDestination += lengthProcessed; // add it onto the destination
                    //if (realDestination > rawDataSize) return;
                    if (lengthRemaining <= 0) return length;  // if we've expired, exit

                }
            }

            return length;
        }

        static private uint ProcessByte(byte realByte, uint destination, uint maxLength, int rawDataSize, ref byte lastNormalByte)
        {

            if ((realByte & 0x40) > 0)
            {
                uint tranfercount = 0;
                int rleLength = (int)(realByte & (uint)0x3f) + 1;

                while (rleLength > 0)
                {
                    tranfercount++;
                    rleLength--;
                    maxLength--;
                    if ((destination + tranfercount) > rawDataSize) return maxLength;
                }

                return tranfercount;
            }
            else
            {
                lastNormalByte = realByte;
                return 1;
            }
        }

        // debugging purposes
        static public void ApplyAllDefs()
        {
            foreach (NormalSpriteDef def in spriteDataMasterList.Values)
            {
                def.WriteData();
            }
        }
        static private uint[] CheckSpriteDefSequence(List<NormalSpriteDef> spriteList)
        {
            uint start = 0;
            uint end = 0;

            if (spriteList.Count > 0)
            {
                start = spriteList[0].RecordEntity.Start;
                end = spriteList[0].RecordEntity.End;

                for (int i = 1; i < spriteList.Count; i++)
                {
                    if (end != spriteList[i].RecordEntity.Start)
                    {
                        throw new Exception("Not in sequence");
                    }

                    end = spriteList[i].RecordEntity.End;
                }
            }

            return new uint[] { start, end };
        }

    }
}
