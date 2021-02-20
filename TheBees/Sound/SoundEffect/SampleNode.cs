using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TheBees.Records;

namespace TheBees.Sound
{
    public class SampleNode
    {
        private uint address;
        private int size;

        private List<SampleNodeValue> values;
        public List<SampleNodeValue> Values { get { return values; } }

        private List<uint> offsets;

        private Dictionary<byte, int> takeAmt = new Dictionary<byte, int>()
        {
            {0xC1, 2},
            {0xC2, 1},
            {0xC4, 1},
            {0xC6, 1},
            {0xBF, 3}
        };

        public int SizeInBytes { get { return size; } }

        public SampleNode(uint effectAddress, uint offset)
        {
            address = effectAddress + offset;
            Load();
        }

        private void Load()
        {
            offsets = new List<uint>();
            values = new List<SampleNodeValue>();
            int byteOffset = 0;
            byte currByte = RomData.Get8(address, byteOffset);
            int amtToGet = 0;
            while (currByte != 0xFF)
            {
                switch (currByte)
                {
                    case 0xC1: // length
                    case 0xC2: // bank select
                    case 0xC4: // sound number
                    case 0xC6: // volume
                    case 0xBF: //???
                        amtToGet = takeAmt[currByte];
                        break;

                }

                offsets.Add((uint)byteOffset);
                List<byte> foundBytes = new List<byte>();
                byte code = currByte;

                if (takeAmt.ContainsKey(currByte))
                {

                    for (int i = 0; i < amtToGet; i++)
                    {
                        foundBytes.Add(RomData.Get8(address, ++byteOffset));
                    }
                }
                else
                {
                    code = 0x00;
                    foundBytes.Add(code);
                }


                values.Add(new SampleNodeValue(code, foundBytes.ToArray()));

                currByte = RomData.Get8(address, ++byteOffset);
            }

            if (currByte == 0xFF)
            {
                size = byteOffset += 1;
            }
            else
            {
                throw new Exception("expecting end");
            }
        }

        public void WriteData()
        {
            Dictionary<byte, int> positions = new Dictionary<byte, int>();
            foreach (byte key in takeAmt.Keys)
                positions[key] = 0;

            int byteOffset = 0;

            for (int i = 0; i < values.Count; i++)
            {
                SampleNodeValue currValue = values[i];
                if (currValue.IsKnownCode)
                    RomData.Set8(address + (uint)byteOffset++, currValue.Code);


                for (int j = 0; j < currValue.Values.Length; j++)
                {
                    RomData.Set8(address + (uint)byteOffset++, currValue.Values[j]);
                }
            }

            RomData.Set8(address + (uint)byteOffset, 0xFF);
        }

        public void UpdateData(int index, uint newData)
        {
            if (index < 0 || index >= values.Count)
                throw new Exception("index out of range");

            SampleNodeValue value = values[index];

            for (int i = 0; i < value.Values.Length; i++)
            {
                value.Values[i] = (byte)(newData >> (i * 8));
            }

            WriteValue(index);
        }

        public void WriteValue(int index)
        {

            if (index < 0 || index >= values.Count)
                throw new Exception("index out of range");

            SampleNodeValue value = values[index];
            uint currOffset = address + offsets[index];
            if (value.Code != 0x00)
            {
                RomData.Set8(currOffset++, value.Code);
            }
            for (int i = 0; i < value.Values.Length; i++)
            {
                RomData.Set8(currOffset++, value.Values[i]);
            }
        }
    }

    public class SampleNodeValue
    {
        private byte code;
        private byte[] values;

        public byte Code { get { return code; } }
        public byte[] Values { get { return values;  } }

        public SampleNodeValue(byte srcCode, byte[] srcValues)
        {
            code = srcCode;
            values = srcValues;
        }

        public bool IsKnownCode { get { return SampleSpec.KnownCodes.Contains(code); } }
    }
}
