using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TheBees.Records;

namespace TheBees.GameRom
{
    public class SuppleValueRange
    {
        protected SuppleValue[] values;
        protected int[] valueSizes;
        protected int[] valueOffsets;
        private int count;
        protected uint address;
        protected bool buffered;

        public bool Buffered { get { return buffered; } }
        public bool bufferLocked = false;
        public SuppleValue[] Values { get { return values; } }

        public Func<int, uint> GetValue;
        public Action<int, uint> SetValue;

        public SuppleValueRange(uint srcAddress)
        {
            address = srcAddress;
            buffered = false;
        }

        public SuppleValueRange(uint srcAddress, int srcCount, int srcValueSize)
            : this(srcAddress)
        {
            // set variables
            count = srcCount;
            valueSizes = new int[count];
            valueOffsets = new int[count];
            int sum = 0;

            for (int i = 0; i < count; i++)
            {
                valueSizes[i] = srcValueSize;
                valueOffsets[i] = sum;
                sum += srcValueSize;
            }

            BufferValues();
        }

        public SuppleValueRange(uint srcAddress, int[] srcValueSizes)
            : this(srcAddress)
        {

            count = valueSizes.Length;
            valueSizes = srcValueSizes;
            valueOffsets = new int[count];
            int sum = 0;

            for (int i = 0; i < count; i++)
            {
                valueOffsets[i] = sum;
                sum += valueSizes[i];
            }

            BufferValues();
        }

        protected virtual void SetAccessFunc()
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

        protected virtual void MakeSuppleValues()
        {
            List<SuppleValue> allValues = new List<SuppleValue>();
            uint currentAddress = address;
            int index = 0;

            foreach (int valueSize in valueSizes)
            {
                SuppleValue newSuppleValue = new SuppleValue(currentAddress, valueSize, this);
                newSuppleValue.Value = GetValueUnbuffered(index);
                allValues.Add(newSuppleValue);
                currentAddress += (uint)valueSize;
                index += 1;
            }

            values = allValues.ToArray();
            buffered = true;

        }

        public virtual void CallOnSetValue()
        {
        }

        private uint GetValueBuffered(int index)
        {
            return Values[index].Value;
        }

        private void SetValueBuffered(int index, uint value)
        {
            values[index].Value = value;
        }

        private uint GetValueUnbuffered(int index)
        {
            return RomData.GetData(address + (uint)valueOffsets[index], valueSizes[index]);
        }

        private void SetValueUnbuffered(int index, uint value)
        {

            RomData.SetData(address + (uint)valueOffsets[index], values[index].Value, valueSizes[index]);
        }

        protected void CheckBuffered()
        {
            if (!buffered)
            {
                throw new Exception("ValueRange must be buffered before retrieving supple value");
            }
        }
        public SuppleValue GetSuppleValue(int index)
        {
            CheckBuffered();
            return values[index];
        }

        public void ApplyBuffer()
        {
            CheckBuffered();
            values.ToList().ForEach((x) => x.ApplyValue());
        }

        public void BufferValues()
        {
            //values.ToList().ForEach((x) => x.BufferValue());
            if (!buffered)
            {
                MakeSuppleValues();
                SetAccessFunc();
            }
        }

        public void ClearBuffer()
        {
            CheckBuffered();

            if (!bufferLocked)
            {
                values = null;
                buffered = false;
                SetAccessFunc();
            }
        }

        public void ZeroBuffer()
        {
            CheckBuffered();
            values.ToList().ForEach(
                (x) => {
                    x.Value = 0;
                });
        }

        public void ZeroData()
        {
            values.ToList().ForEach(
                   (x) =>
                   {
                       x.Value = 0;
                       x.ApplyValue();
                   });
        }

        public void MakeEmptyBuffer()
        {
            BufferValues();
            ZeroBuffer();
        }

        public void SetBuffer(SuppleValueRange srcRange)
        {
            if (!srcRange.buffered)
                throw new ArgumentException("Source node must be buffered before setting to destination");
            if (values.Length != srcRange.values.Length)
                throw new ArgumentException("Value ranges do not match counts");
            if (!buffered)
                MakeEmptyBuffer();

            for (int i = 0; i < values.Length; i++)
            {
                values[i].Value = srcRange.values[i].Value;
            }
        }

        public void SetAddress(uint newAddress)
        {
            address = newAddress;
            if (buffered)
            {
                uint currentAddress = newAddress;
                for (int i = 0; i < values.Length; i++)
                {
                    values[i].Address = currentAddress;
                    currentAddress += (uint)valueSizes[i];
                }
            }
        }


        public void AdjustAddress(int adjustment)
        {
            SetAddress((uint)((int)address + adjustment));
        }

        public void LockBuffer()
        {
            bufferLocked = true;
        }

        public void UnlockBuffer()
        {
            bufferLocked = false;
        }
        public uint Address { get { return address; } }

        //protected override void OnUpdateAddress(uint oldAddress, uint newAddress)
        //{
        //    RomData.Set32(pointer, newAddress);
        //}

        //protected override int IndexSize { get { return valueSize; } }
        //public override int SizeInBytes { get { return count * valueSize; } }

    }
}
