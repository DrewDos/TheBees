using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheBees.Records
{
    public class SpaceGroupSummary
    {
        public string GroupName;
        public int FreeSpace;
        public int LargestBlockAvailable;

        public SpaceGroupSummary(string srcName, RecordSpaceGroup group)
        {
            GroupName = srcName;
            FreeSpace = group.FreeSpace;
            LargestBlockAvailable = group.LargestBlockAvail;
        }
    }
}
