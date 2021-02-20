using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TheBees.GameRom;

namespace TheBees.UnitData
{
    class FunctionCall : ActionNode
    {

        public override RawNodeType RawType
        {
            get { return RawNodeType.FunctionCall; }
        }

        public override string Description
        {
            get
            {
                return "Function Call";
            }
        }

        public FunctionCall(uint address, NodeType type)
            : base(address, type)
        {
        }

        public int FunctionCode
        {
            get { return (int)GetValue("callNum"); }
            set { SetValue("callNum", (uint)value); }
        }

        public uint Value1
        {
            get { return GetValue("value1"); }
            set { SetValue("value1", value); }
        }

        public uint Value2
        {
            get { return GetValue("value2"); }
            set { SetValue("value2", value); }
        }

        public uint Value3
        {
            get { return GetValue("value3"); }
            set { SetValue("value3", value); }
        }


        public override DataNode GetCopy()
        {
            return new FunctionCall(this.address, this.type);
        }
    }
}
