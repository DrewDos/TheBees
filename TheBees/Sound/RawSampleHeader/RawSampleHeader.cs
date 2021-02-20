using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TheBees.GameData;
using TheBees.GameRom;

namespace TheBees.Sound
{
    class RawSampleHeader : DataNode
    {
        public RawSampleHeader(uint address)
            : base(address, NodeType.RawSampleHeader)
        {
        }

        public int RawSampleDataRefNum
        {
            get { return (int)GetValue("undef4"); }
        }
    }
}
