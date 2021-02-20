using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheBees.GameRom
{
    public class SuppleValue
    {
        private int valueSize;
        private uint value;
        private SuppleValueRange parent;

        public uint Address;

        public uint Value 
        {
            get { return value; }
            set 
            { 
                this.value = value; 
                parent.CallOnSetValue(); 
            }
        }
        public SuppleValue(uint newAddress, int newValueSize, SuppleValueRange newParent)
        {
            valueSize = newValueSize;
            Address = newAddress;
            parent = newParent;
        }

        //private uint GetValueFromRom()
        //{
        //    return RomData.GetData(address, valueSize);
        //}

        public void ApplyValue()
        {
            RomData.SetData(Address, value, valueSize);
        }
    }
}
