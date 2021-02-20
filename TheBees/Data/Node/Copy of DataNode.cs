//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace TheBees.GameRom
//{
//    public delegate void OnSetDataValueDelegate(DataNode node);

//    public class DataNode
//    {

//        protected uint[] data = null;
//        protected NodeType type;
//        protected uint address;
//        public uint Address { get { return address; } }

//        static public OnSetDataValueDelegate OnSetDataValue = null;

//        protected bool buffered = false;
//        public bool Buffered { get { return buffered; } }

//        public virtual string Description { get { return "DataNode"; } }

//        public DataNode(NodeType newType)
//        {
            
//            type = newType;
//            /*
//            int count = NodeSpec.SpecList[newType].Count;

//            //data = new uint[count];
//            Array.Clear(data, 0, count);
//            */
//        }

//        public DataNode(uint offset, NodeType newType)
//        {
//            address = offset;
//            type = newType;
//        }
//        public void SetAddress(uint newAddress)
//        {
//            address = newAddress;
//        }
//        public void AdjustAddress(int adjustment)
//        {
//            address = (uint)((int)address + adjustment);
//        }

//        public virtual DataNode GetCopy()
//        {
//            return new DataNode(this.address, this.type);
//        }

//        public uint GetValue(string key)
//        {
//            return RomData.GetData(address + (uint)NodeSpec.GetValueOffset(type, key), NodeSpec.GetNodeSize(type, key));
//        }


//        public void SetValue(string key, uint value)
//        {
//            RomData.SetData(address + NodeSpec.GetValueOffset(type, key), value, NodeSpec.GetNodeSize(type, key));

//            CallOnSetValue();
//        }

//        public int SizeInBytes
//        {
//            return NodeSpec.GetSpecSize(type);
//        }

//        public NodeType GetNodeType()
//        {
//            return type;
//        }

//        public void FillBuffer()
//        {
            
//            int valueCount = NodeSpec.SpecList[type].Count;
//            int valueOffset = 0;
//            int currSize = 0;

//            data = new uint[valueCount];

//            for(int i = 0; i < valueCount; i++)
//            {
//                currSize = NodeSpec.SpecList[type][i].Size;
//                data[i] = RomData.GetData(address + (uint)valueOffset, currSize);

//                valueOffset += currSize;
//            }

//            buffered = true;
//        }

//        public void ClearBuffer()
//        {
//            data = null;
//            buffered = false;
//        }

//        public void ApplyData()
//        {
//            /*
//            int valueCount = NodeSpec.SpecList[type].Count;
//            uint valueOffset = 0;
//            uint currSize = 0;

//            for (int i = 0; i < valueCount; i++)
//            {
//                currSize = NodeSpec.SpecList[type][i].Size;
//                RomData.SetData(address + valueOffset, data[i], currSize);

//                valueOffset += currSize;
//            }
//            */
//        }

//        public void ApplyBuffer()
//        {
            
//            int valueCount = NodeSpec.SpecList[type].Count;
//            int valueOffset = 0;
//            int currSize = 0;

//            for (int i = 0; i < valueCount; i++)
//            {
//                currSize = NodeSpec.SpecList[type][i].Size;
//                RomData.SetData(address + (uint)valueOffset, data[i], currSize);

//                valueOffset += currSize;
//            }
            
//        }

//        public void SetBufferEmpty()
//        {
//            int valueCount = NodeSpec.SpecList[type].Count;
//            int valueOffset = 0;
//            int currSize = 0;

//            data = new uint[valueCount];

//            for (int i = 0; i < valueCount; i++)
//            {
//                currSize = NodeSpec.SpecList[type][i].Size;
//                data[i] = 0;

//                valueOffset += currSize;
//            }

//            buffered = true;
//        }

//        private void CallOnSetValue()
//        {
//            if (OnSetDataValue != null)
//            {
//                OnSetValue(this);
//            }
//        }
//        public uint [] Buffer { get { return data; } }
//    }
//}
