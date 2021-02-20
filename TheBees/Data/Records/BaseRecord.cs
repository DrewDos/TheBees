using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheBees.Records
{    
    public delegate void OnUpdateAddressDelegate(uint oldAddress, uint newAddress);

    public abstract class BaseRecord
    {
        protected uint start;
        protected uint end;

        public int Index { get; set; }

        public bool IsChild;

        public BaseRecord(uint address, int length)
        {
            start = address;
            end = (uint)length + start;
        }
        public virtual void SetAddress(uint newAddress)
        {
            uint fromAddress = start;
            int length = (int)(end - start);
            start = newAddress;
            end = start + (uint)length;
        }

        public uint Start { get { return start; } }
        public uint End { get { return end; } }
        public int Size { get { return (int)(end - start); } }
    }
}
