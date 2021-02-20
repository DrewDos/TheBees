using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheBees.GameRom
{

    public class DataNode : NodeValueRange
    {

        public virtual string Description { get { return "DataNode"; } }

        public DataNode(NodeType newType)
            :base(0, newType)
        {
            type = newType;
        }

        public DataNode(uint offset, NodeType newType)
            : base(offset, newType)
        {
        }

        public virtual DataNode GetCopy(bool ensureBuffer)
        {
            DataNode copiedNode = new DataNode(this.address, this.type);
            if (ensureBuffer)
            {
                // gets values from the current address
                // should probably resolve this in the future
                copiedNode.MakeEmptyBuffer();
                copiedNode.SetBuffer(this);
            }

            return copiedNode;
        }


        public NodeType GetNodeType()
        {
            return type;

        }

        public void SetNodeType(NodeType newType)
        {
            type = newType;
        }
    }
}
