using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TheBees.Records;
using TheBees.Data;
using TheBees.User;

namespace TheBees.Sound
{
    public class RawSampleDataGroup : Recordable
    {
        private MappedRecordableList sampleDataMap;
        public MappedRecordableList SampleMap { get { return sampleDataMap; } }

        private List<SampleDataDetails> sampleDetails;
        private int sampleCount;

        public RawSampleDataGroup(uint address)
            : base(address, true)
        {
            sampleCount = SampleSpec.RawSampleCount;
            LoadAllSampleData();
        }

        static public RawSampleDataGroup GetRecordable(uint address)
        {
            if (!MasterList.ContainsKey(address))
            {
                RawSampleDataGroup group = new RawSampleDataGroup(address);

                if (creatingBaseRecords) group.InitializeRecord();

                MasterList[address] = group;
            }

            return (RawSampleDataGroup)MasterList[address];
        }

        public void LoadAllSampleData()
        {
            sampleDataMap = new MappedRecordableList(UpdateAddressList);
            sampleDetails = new List<SampleDataDetails>();

            for (int i = 0; i < sampleCount; i++)
            {
                SampleDataDetails newDetails = SampleDataDetails.GetDetailsFromRom(i);

                sampleDetails.Add(newDetails);

                if (newDetails.End - newDetails.Start > 0)
                {
                    sampleDataMap.AddMap(SampleBlock.GetRecordable(i));
                }
                else
                {
                    sampleDataMap.AddMap(null);
                }
            }
        }

        public void ClearBlock(int index)
        {
            SampleBlock block = GetSampleBlock(index);
            if (block == null)
                throw new ArgumentException("Invalid index for map");

            SampleMap.ClearMap(index, true, true);
            sampleDetails[index].Clear();
            SetSampleData(index);
        }

        public SampleBlock GetSampleBlock(int index)
        {
            return (SampleBlock)sampleDataMap.GetMap(index);
        }

        public SampleDataDetails GetSampleDetails(int index)
        {
            return sampleDetails[index];
        }

        public void UpdateSampleData(int index, SampleDataDetails newSampleData)
        {
            sampleDetails[index].UpdateValues(newSampleData);
        }
        public void SetSampleData(int index)
        {
            SampleDataDetails selectedDetail = sampleDetails[index];

            RomData.Set32(SampleSpec.RawSampleDataPointers + (uint)index * 0x10 + 0x00, selectedDetail.Start); // start
            RomData.Set32(SampleSpec.RawSampleDataPointers + (uint)index * 0x10 + 0x04, selectedDetail.MidPointOffset + selectedDetail.Start); // midpoint
            RomData.Set32(SampleSpec.RawSampleDataPointers + (uint)index * 0x10 + 0x08, selectedDetail.End); // end
            RomData.Set32(SampleSpec.RawSampleDataPointers + (uint)index * 0x10 + 0x0C, selectedDetail.UnknownValue); // unknown
        }

        public void UpdateAddressList()
        {
            for (int i = 0; i < sampleDataMap.MapCount; i++)
            {
                SampleDataDetails currDetails = sampleDetails[i];
                SampleBlock block = (SampleBlock)sampleDataMap.GetMap(i);
                if (block != null)
                {
                    currDetails.Start = block.Address;
                    currDetails.End = block.Address + (uint)block.SizeInBytes-1;
                    SetSampleData(i);
                }
            }
        }

        protected override RecordSpaceGroup spaceGroup
        {
            get
            {
                return RecordGuide.ProgramSpace;
            }
        }

        public override int SizeInBytes
        {
            get { return sampleCount * 0x10; }
        }

        public override bool MaintainData
        {
            get { return true; }
        }
    }

    public class SampleDataDetails
    {
        public uint Start;
        public uint End;
        public uint MidPointOffset;
        public uint UnknownValue;

        public SampleDataDetails(uint newStart, uint newMidpoint, uint newEnd, uint newUnknown)
        {
            Start = newStart;
            End = newEnd;
    
            MidPointOffset = newMidpoint - newStart;
            UnknownValue = newUnknown;
        }

        static public SampleDataDetails GetDetailsFromRom(int index)
        {
            return new SampleDataDetails(
                   RomData.Get32(SampleSpec.RawSampleDataPointers + (uint)index * 0x10 + 0x00), // start
                   RomData.Get32(SampleSpec.RawSampleDataPointers + (uint)index * 0x10 + 0x04), // midpoint offset
                   RomData.Get32(SampleSpec.RawSampleDataPointers + (uint)index * 0x10 + 0x08), // end
                   RomData.Get32(SampleSpec.RawSampleDataPointers + (uint)index * 0x10 + 0x0C) // unknown
               );
        }

        public void UpdateValues(SampleDataDetails src)
        {
            Start = src.Start;
            End = src.End;
            MidPointOffset = src.MidPointOffset;
            UnknownValue = src.UnknownValue;
        }
        public void Clear()
        {
            Start = 0;
            End = 0;
            MidPointOffset = 0;
            UnknownValue = 0;
        }
    }
}
