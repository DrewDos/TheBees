using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TheBees.GameData;
using TheBees.GameRom;
using TheBees.Records;
using TheBees.User;

namespace TheBees.Sound
{
    public class RawSampleGroup : Recordable
    {
        private List<ushort> offsets;
        private List<DataNode> sampleHeaders;

        private int size;

        public RawSampleGroup(uint address)
            : base(address, true)
        {
            LoadSampleHeaders();
        }

        static public RawSampleGroup GetRecordable(uint address)
        {
            if (!MasterList.ContainsKey(address))
            {
                RawSampleGroup newGroup = new RawSampleGroup(address);
                if (creatingBaseRecords) newGroup.InitializeRecord();

                MasterList[address] = newGroup;
            }

            return (RawSampleGroup) MasterList[address];
        }

        private void LoadSampleHeaders()
        {
            sampleHeaders = new List<DataNode>();
            offsets = new List<ushort>();
            int count = 0x100/2;

            size = count * 2;

            for (int i = 0; i < count; i++)
            {
                ushort offset = RomData.Get16(address + (uint)i*2);
                DataNode newNode = null;

                if (offset != 0x00)
                {
                    newNode = new DataNode(address + (uint)offset, NodeType.RawSampleHeader);
                    size += newNode.SizeInBytes;
                }
                sampleHeaders.Add(newNode);
                offsets.Add(offset);
            }
        }

        public DataNode GetSampleHeader(int index)
        {
            if (index < 0 || index > offsets.Count)
                throw new ArgumentException("index out of range");

            return sampleHeaders[index];
        }

        protected override void BufferData()
        {
            sampleHeaders.ForEach((x) => x.BufferValues());
        }
        protected override void ApplyBuffer()
        {
            sampleHeaders.ForEach((x) => x.ApplyBuffer());
        }

        public override int SizeInBytes
        {
            get { return size;  }
        }

        public override bool MaintainData
        {
            get { return false; }
        }
        protected override RecordSpaceGroup spaceGroup
        {
            get
            {
                return RecordGuide.ProgramSpace;
            }
        }

    }
}
