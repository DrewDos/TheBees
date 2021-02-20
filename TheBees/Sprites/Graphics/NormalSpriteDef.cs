using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TheBees.Records;
using TheBees.Data;
using TheBees.User;

namespace TheBees.Sprites
{
    public class NormalSpriteDef : Recordable
    {

        protected override RecordSpaceGroup spaceGroup { get { return RecordGuide.UserSpace; } }

        private List<TileDef> tileList;
        private List<TileGroupDef> tileGroupList;

        public List<TileDef> TileList { get { return tileList; } }
        public List<TileGroupDef> TileGroupList { get { return tileGroupList; } }

        private uint realLookupAddr;
        public uint RealLookupAddress { get { return realLookupAddr; } }
        public uint LookupAddressAsGame { get { return GetGameLookupFromReal(realLookupAddr); } }
        
        // some indexes have unknown data
        private byte[] unknownData;

        // help for initializing records
        private int rawDataSize = -1;

        // sprite header
        private ushort start;
        private ushort tileCt;
        private ushort tileGroupCt;
        private ushort unknown;

        public ushort StartValue { get { return start; } }

        //public List<int> PointerIndexes;
        private RecordableObserver lookupObserver;
        
        static public Dictionary<uint, List<int>> PointerIndexes = new Dictionary<uint, List<int>>();
        static private HashSet<NormalSpriteDef> pendingHash = new HashSet<NormalSpriteDef>();
        private List<int> tempPointerIndexes;

        static private bool preventPending = false;
        static public bool PreventPending { set { preventPending = value; } }

        static private bool maintainData = false;
        public override bool MaintainData { get { return maintainData; } }

        public NormalSpriteDef(uint address, bool newHasUnknown = false, bool loadBlock = false)
            : base(address, true)
        {
            tileList = new List<TileDef>();
            tileGroupList = new List<TileGroupDef>();

            LoadHeader();

            int tileListBlock = 8, tileGroupListBlock = 8;
            int tileListStart = 0x0C;
            int tileGroupListStart = 0x0C + (tileCt * tileListBlock);

            int unknownTest = 0;

            for (int i = 0; i < tileCt; i++)
            {
                int dataOffset = tileListStart + (tileListBlock * i);

                tileList.Add(
                    new TileDef(
                            this,
                            RomData.Get16(address, dataOffset + 4),
                            RomData.Get16(address, dataOffset + 6),
                            RomData.Get32(address, dataOffset)
                    )
                );

                TileDef def = tileList[tileList.Count - 1];

                unknownTest += (int)def.RealLength / (16 * 16);
            }

            // load tile  block after loading each tile def to get size required for loading tile blocks
            tileList.ForEach((x) => x.LoadTileDataBlock());

            for (int i = 0; i < tileGroupCt; i++)
            {
                int dataOffset = tileGroupListStart + (tileGroupListBlock * i);
                byte[] tileGroupListBuf = new byte[8];

                for (int j = 0; j < 8; j++)
                {
                    tileGroupListBuf[j] = RomData.Get8(address, dataOffset + j);
                }

                tileGroupList.Add(new TileGroupDef(tileGroupListBuf));
            }

            if (newHasUnknown)
            {
                int unknownStart = 0x0C + tileCt * 8 + tileGroupCt * 8;
                unknownData = new byte[8];
                for (int i = 0; i < 8; i++)
                {
                    unknownData[i] = RomData.Get8(address + (uint)(unknownStart + i));
                }
            }

            LoadLookupBlock();
        }

        private void LoadHeader()
        {
            start = RomData.Get16(address);
            tileCt = RomData.Get16(address, 4);
            tileGroupCt = RomData.Get16(address, 6);
            unknown = RomData.Get16(address, 2);
            realLookupAddr = ((uint)(RomData.Get32(address, 8) << 1) - 0x400000);
            if ((int)realLookupAddr < 0)
                realLookupAddr = 0;
        }

        public void SetLookupFromReal(uint srcAddress)
        {
            realLookupAddr = srcAddress;
        }

        public uint GetGameLookupFromReal(uint srcAddress)
        {
            return (srcAddress + 0x400000) >> 1;
        }


        public void WriteData()
        {
            uint offset = 0;

            // write header
            RomData.Set16(address + 0x00, start);
            RomData.Set16(address + 0x02, unknown);
            RomData.Set16(address + 0x04, (ushort)tileList.Count);
            RomData.Set16(address + 0x06, (ushort)tileGroupList.Count);
            RomData.Set32(address + 0x08, LookupAddressAsGame);

            offset = address + 0x0C;

            // write the tile data map
            for (int tileCtr = 0; tileCtr < tileList.Count; tileCtr++)
            {
                RomData.Set32(offset, tileList[tileCtr].GameSource);
                RomData.Set16(offset + 4, tileList[tileCtr].GameLength);
                RomData.Set16(offset + 6, tileList[tileCtr].GameOffset);
                offset += 0x08;
            }

            // write the tile group data

            for (int groupCtr = 0; groupCtr < tileGroupList.Count; groupCtr++)
            {
                TileGroupDef group = tileGroupList[groupCtr];

                //RomData.Set8(offset + 0x00, group.Byte0);
                RomData.Set16(offset + 0x00, group.TileStartOffset);
                
                byte flipByte = (byte)(group.FlipVertical << 3);
                flipByte |= (byte)(group.FlipHorizontal << 4);
                flipByte |= group.UnknownFlag;
                RomData.Set8(offset + 0x02, (byte)(flipByte));

                //RomData.Set8(offset + 0x02, 0x02);

                RomData.Set8(offset + 0x03, group.Byte3);
                RomData.Set16(offset + 0x04, (ushort)(group.XOffset & 0x0FFF));

                ushort sizeValue = (ushort)((group.Width == 4 ? 3 : group.Width) << 12);
                sizeValue |= (ushort)((group.Height == 4 ? 3 : group.Height) << 14);
                sizeValue |= (ushort)(group.YOffset & 0x0FFF);
                RomData.Set16(offset + 0x06, sizeValue);

                offset += 0x08;
            }

            // write unused bytes if exists
            if (unknownData != null)
            {
                for (int i = 0; i < unknownData.Length; i++)
                {
                    RomData.Set8(offset + (uint)i, unknownData[i]);
                }
            }



        }


        public void ClearData()
        {

            SpriteMap.UpdateSpriteDefPointer(this, 0);
            PointerIndexes.Remove(address);
            MasterList.Remove(address);

            foreach (TileDef def in tileList)
            {
                def.ClearData();
            }


            lookupObserver.DisassociateBlock();
            lookupObserver = null;

            record.ClearFromSpace(false);
            record = null;

            
        }

        ////////////////////////////////////////
        // lookup block methods
        ////////////////////////////////////////

        //public void OnUpdateLookupComplete()
        //{
        //        WriteData();
        //}

        private void OnDataBlockMove(RecordableMoveParams p)
        {
            SetLookupFromReal(p.ToAddress);
            PendUpdate();
        }

        public void LoadLookupBlock()
        {
            if (lookupObserver == null)
            {
                lookupObserver = new RecordableObserver(LookupBlock.GetRecordable(RealLookupAddress), OnDataBlockMove);
            }
        }

        ////////////////////////////////////////
        // record assist methods
        ////////////////////////////////////////

        public void PendUpdate()
        {
            if (preventPending)
                return;

            if(!pendingHash.Contains(this))
                pendingHash.Add(this);
        }

        static public void SpaceUpdateComplete()
        {
            WritePending();
        }

        static private void WritePending()
        {
            foreach (NormalSpriteDef def in pendingHash)
            {
                def.WriteData();
            }

            pendingHash.Clear();
        }

        ////////////////////////////////////////
        // overrides
        ////////////////////////////////////////

        protected override void BeforeDataMove()
        {
            base.BeforeDataMove();

            tempPointerIndexes = new List<int>();
            if (!PointerIndexes.ContainsKey(address) || PointerIndexes[address] == null)
            {
                throw new Exception("Should have pointer indexes....");
            }
            tempPointerIndexes.AddRange(PointerIndexes[address]);
            PointerIndexes.Remove(address);
        }

        protected override void AfterSetAddress()
        {
            base.AfterSetAddress();

            if (tempPointerIndexes == null)
                throw new Exception("Temporary pointer indexes should not be null");

            PointerIndexes[address] = tempPointerIndexes;
            tempPointerIndexes = null;

            SpriteMap.UpdateSpriteDefPointer(this, address);
        }

        ////////////////////////////////////////
        // static methods
        ////////////////////////////////////////

        //static public void ApplyAllDefs()
        //{
        //    foreach (NormalSpriteDef def in MasterList.Values)
        //    {
        //        def.WriteData();
        //    }
        //}

        public int GetRawDataSize()
        {
            if (rawDataSize < 0)
            {
                int len = tileList.Count;
                int result = 0;
                int currSz = 0;

                for (int i = 0; i < len; i++)
                {
                    currSz = (int)(tileList[i].RealDestination + tileList[i].RealLength);
                    if (result < currSz)
                        result = currSz;
                }

                rawDataSize = result;
            }

            return rawDataSize;
        }

        static public void AddPointerIndex(uint address, int index)
        {
            if (!PointerIndexes.ContainsKey(address))
            {
                PointerIndexes[address] = new List<int>();
            }

            PointerIndexes[address].Add(index);
        }

        static public NormalSpriteDef GetRecordable(uint address, bool newHasUnknown = false)
        {
            if (!MasterList.ContainsKey(address))
            {
                NormalSpriteDef def = new NormalSpriteDef(address, newHasUnknown);
                if (creatingBaseRecords) def.InitializeRecord();
            }

            return (NormalSpriteDef)MasterList[address];
        }

        static public bool DefExists(uint address)
        {
            return MasterList.ContainsKey(address);
        }

        ////////////////////////////////////////
        // properties
        ////////////////////////////////////////

        public override int SizeInBytes
        {
            get { return 0x0C + tileCt * 8 + tileGroupCt * 8 + (unknownData == null ? 0 : 8); }
        }

    }
}
