using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TheBees.Data;
using TheBees.Records;

namespace TheBees.Sprites
{
    public class TileDef
    {
        private uint realLength;
        private uint realDestination;
        private uint realSource;

        public uint RealSource { get { return realSource; } }
        public uint RealDestination { get { return realDestination; } }
        public uint RealLength { get { return realLength; } }

        public uint GameSource { get { return (realSource + 0x400000) >> 1; } }
        public ushort GameLength { get { return (ushort)((((RealLength >> 3) - 2) >> 1)); }}
        public ushort GameOffset { get { return (ushort)(realDestination >> 4); } }

        private NormalSpriteDef parent;
        public NormalSpriteDef Parent { get { return parent; } }

        private RecordableObserver blockObserver;
        public RecordableObserver BlockObserver { get { return blockObserver; } }

        public TileDef(NormalSpriteDef newParent, uint inLength, uint inOffset, uint inAddress)
        {
            parent = newParent;

            SetSourceFromGame(inAddress);
            realDestination = (inOffset << 4);
            realLength = (((inLength << 1) + 2) << 3);

        }

        public void LoadTileDataBlock()
        {
            if (blockObserver == null)
            {
                blockObserver = new RecordableObserver(TileDataBlock.GetRecordable(this), OnDataBlockMove);
            }            
            
        }

        public void SetSourceFromGame(uint address)
        {
            realSource = (address << 1) - 0x400000;
        }

        public void SetRealSource(uint address)
        {
            realSource = address;
            parent.PendUpdate();
        }

        public void ClearData()
        {
            blockObserver.DisassociateBlock();
            blockObserver = null;

        }

        private void OnDataBlockMove(RecordableMoveParams p)
        {
            SetRealSource(p.ToAddress);
            parent.PendUpdate();
        }
    }
}
