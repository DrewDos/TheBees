using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TheBees.Records;
using TheBees.Data;
using TheBees.User;

namespace TheBees.Sound
{
    public class SampleBlock : RomDataBlock
    {
        public SampleBlock(uint address, int size)
            : base(address)
        {
            BlockSize = size;
        }

        static public SampleBlock GetRecordable(int index)
        {
            uint start = RomData.Get32(SampleSpec.RawSampleDataPointers + (uint)index*0x10);

            if (!MasterList.ContainsKey(start))
            {
                uint end = RomData.Get32(SampleSpec.RawSampleDataPointers + (uint)index * 0x10 + 0x08);

                SampleBlock newSample = new SampleBlock(start, (int)(end - start + 1));
                if (creatingBaseRecords) newSample.InitializeRecord();

                MasterList[start] = newSample;
            }

            return (SampleBlock)MasterList[start];
        }

        protected override RecordSpaceGroup spaceGroup
        {
            get
            {
                return RecordGuide.UserSpace;
            }
        }

    }
}
