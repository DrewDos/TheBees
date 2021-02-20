using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TheBees.Data;
using TheBees.User;
using TheBees.Records;

namespace TheBees.Sprites
{
    public class LookupBlock : RomDataBlock
    {

        protected override RecordSpaceGroup spaceGroup { get { return RecordGuide.UserSpace; } }

        public LookupBlock(uint start)
            : base(start)
        {
        }

        static public LookupBlock GetRecordable(uint address)
        {
            if (!MasterList.ContainsKey(address))
            {
                int newBlockSize = 0x0100;

                LookupBlock newBlock = new LookupBlock(address);

                if (creatingBaseRecords)
                {
                    newBlock.BlockSize = newBlockSize;
                    newBlock.InitializeRecord();
                }
            }

            return (LookupBlock)MasterList[address];
        }

        static public LookupBlock CreateLookupTable()
        {
            if (!RecordGuide.UserSpace.FreeSizeAvailable(0x100))
                throw new Exception("Not enough free size available");

            Record record = RecordGuide.UserSpace.CreateRecordForNewData(0x100);
            LookupBlock table = new LookupBlock(record.Start);
            table.SetRecord(record);

            if (MasterList.ContainsKey(record.Start))
                throw new Exception("Block in this location already exists");

            MasterList[record.Start] = table;

            return table;
        }

    }
}
