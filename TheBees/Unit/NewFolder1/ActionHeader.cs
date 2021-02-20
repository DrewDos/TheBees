using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TheBees.GameRom;

namespace TheBees.UnitData
{

    public class ActionHeader : DataNode
    {

        public override string Description
        {
            get
            {
                return "Action Header";
            }
        }
        public ActionHeader(uint offset)
            : base(offset, NodeType.ActionHeader)
        {

        }

        public int DataLengthInBytes
        {
            get
            {
                uint value = GetValue("lengthOfData");
                if (value == 1)
                    value = 2;
                return (int)value * 4;
            }
            set
            {
                if (value / 8 > 3 || value % 8 > 0)
                    throw new ArgumentException("New Data Length must be 8, 16, or 24");

                SetValue("lengthOfData", (uint)value / 4);

            }
        }

        public override DataNode GetCopy()
        {
            return new ActionHeader(this.address);
        }
        
    }
}
