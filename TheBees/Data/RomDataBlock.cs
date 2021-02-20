using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TheBees.Records;
using TheBees.General;
using TheBees.GameRom;

namespace TheBees.Data
{
    public abstract class RomDataBlock : Recordable
    {

        static private bool maintainData = false;
        public override bool MaintainData { get { return maintainData; } }

        public int BlockSize;

        protected byte[] buffer;

        public RomDataBlock(uint start, bool finalize = true)
            :base(start, finalize)
        {
            if (HasRecord)
            {
                BlockSize = record.Size;
            }
        }

        protected override void BeforeDataMove()
        {
            base.BeforeDataMove();

            buffer = RomData.GetBlock(address, BlockSize);
        }

        protected override void AfterSetAddress()
        {
            base.AfterSetAddress();

            RomData.SetBlock(address, buffer);
            buffer = null;
        }
        public override int SizeInBytes
        {
            get { return BlockSize; }
        }
    }
}
