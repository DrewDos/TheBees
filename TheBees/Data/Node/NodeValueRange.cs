using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheBees.GameRom
{
    public class NodeValueRange : SuppleValueRange
    {
        static public Action<NodeValueRange> OnSetDataValue = null;

        public delegate void OnSetDataValueDelegate(DataNode node);

        private Dictionary<string, int> keyIndexes;
        protected NodeType type;
        
        new public Func<string, uint> GetValue;
        new public Action<string, uint> SetValue;

        public NodeValueRange(uint address, NodeType newType)
            :base(address)
        {
            valueSizes = NodeSpec.ValueSizes[newType];
            valueOffsets = null;
            keyIndexes = NodeSpec.KeyedIndexes[newType];
            type = newType;

            SetAccessFunc();
        }

        public override void CallOnSetValue()
        {
            if (OnSetDataValue != null)
            {
                OnSetDataValue(this);
            }
        }

        protected override void SetAccessFunc()
        {
            if (!buffered)
            {
                GetValue = GetValueUnbuffered;
                SetValue = SetValueUnbuffered;
            }
            else
            {
                GetValue = GetValueBuffered;
                SetValue = SetValueBuffered;
            }
        }

        private uint GetValueBuffered(string key)
        {
            return Values[keyIndexes[key]].Value;
        }

        private void SetValueBuffered(string key, uint value)
        {
            Values[keyIndexes[key]].Value = value;

            CallOnSetValue();
        }

        private uint GetValueUnbuffered(string key)
        {
            uint somevalu = RomData.GetData(address + NodeSpec.GetValueOffset(type, key), valueSizes[keyIndexes[key]]);
            return somevalu;
        }

        private void SetValueUnbuffered(string key, uint value)
        {
            RomData.SetData(address + NodeSpec.GetValueOffset(type, key), value, valueSizes[keyIndexes[key]]);

            CallOnSetValue();

        }

        public NodeSuppleValue GetSuppleValue(string key)
        {
            return (NodeSuppleValue)Values[keyIndexes[key]];
        }

        protected override void MakeSuppleValues()
        {
            List<SuppleValue> allValues = new List<SuppleValue>();
            uint currentAddress = address;

            for(int i = 0; i < valueSizes.Length; i++)
            {
                string currKey = NodeSpec.NodeSpecList[type][i].Name;
                NodeSuppleValue newValue = new NodeSuppleValue(currentAddress, valueSizes[i], currKey, this);
                newValue.Value = GetValueUnbuffered(currKey);
                currentAddress += (uint)valueSizes[i];
                allValues.Add(newValue);
            }

            values = allValues.ToArray();
            buffered = true;

        }


        public bool ContainsKey(string key)
        {
            return keyIndexes.ContainsKey(key);
        }

        public int SizeInBytes { get { return NodeSpec.SpecSizes[type]; }}
    }
}
