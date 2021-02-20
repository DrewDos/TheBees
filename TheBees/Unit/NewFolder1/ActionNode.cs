using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TheBees.GameRom;


namespace TheBees.UnitData
{
    // not yet implemented completely
    // this class will allow full descriptions
    
    public abstract class ActionNode : DataNode
    {
        public virtual RawNodeType RawType { get { return RawNodeType.None; } }
        protected int dataLengthInBytes;

        public ActionNode(uint address, NodeType type)
            : base(address, type)
        {
            dataLengthInBytes = NodeUtil.GetByteCountFromNode(type);
        }

        public int LengthOfDataInBytes { get { return dataLengthInBytes; } }
    }
}
