using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using TheBees.Records;

namespace TheBees.GameRom
{


    public class NodeGroup
    {
        protected List<DataNode> dataNodes = new List<DataNode>();
        public List<DataNode> DataNodes { get { return dataNodes; }}
        private int size = 0;

        public NodeGroup()
        {
        }

        public NodeGroup(uint sourceAddress, int count, NodeType type)
        {

            int nodeSize = (int)NodeSpec.SpecSizes[type];
            uint currentAddress = sourceAddress;
            for (int i = 0; i < count; i++)
            {
                dataNodes.Add(NodeUtil.GetProperNode(type, currentAddress));
                size += nodeSize;
                currentAddress = sourceAddress + (uint)size;
            }
        }
        
        public DataNode AddNodeByType(uint address, NodeType type)
        {
            DataNode newNode = new DataNode(address, type);
            return AddNode(newNode);
        }

        public DataNode AddNode(DataNode newNode)
        {
            dataNodes.Add(newNode);
            return newNode;
        }

        public DataNode GetNode(int index)
        {
            return DataNodes[index];
        }

        public void SetNode(DataNode newNode, int index)
        {
            dataNodes[index] = null;
            dataNodes[index] = newNode;
        }
        public int SizeInBytes { get { return size; } }
        public int Count { get { return dataNodes.Count; } }
    }
}
