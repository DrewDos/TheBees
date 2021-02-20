using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TheBees.GameData;
using TheBees.GameRom;

using TheBees.Records;
using TheBees.User;

namespace TheBees.Sound
{
    public class SoundEffect
    {
        private int soundEffectIndex;
        private int dataSize;

        private byte startValue;
        private int[] validNodeIndexes;
        public int[] ValidNodeIndexes { get { return validNodeIndexes; } }

        private uint address;
        public uint Address { get { return address; } }

        private ushort[] offsets = new ushort[SampleSpec.SoundEffectSampleMax];
        private List<SampleNode> sampleNodes = new List<SampleNode>();
        public List<SampleNode> SampleNodes { get { return sampleNodes; } }
        private Dictionary<uint, SampleNode> keyedSampleNodes = new Dictionary<uint, SampleNode>();

        public SoundEffect(uint srcAddress)
        {
            address = srcAddress;
            Load();
        }

        private void Load()
        {
            startValue = RomData.Get8(address);

            List<int> tempNodeIndexes = new List<int>();

            // load all sample offsets
            for (int i = 0; i < SampleSpec.SoundEffectSampleMax; i++)
            {
                ushort offset = RomData.Get16(address, i * 2 + 1);
                offsets[i] = offset;

                if (offset != 0x00)
                {
                    SampleNode newNode = new SampleNode(address, offset);
                    sampleNodes.Add(newNode);
                    keyedSampleNodes[offset] = newNode;
                    tempNodeIndexes.Add(i);
                    dataSize += newNode.SizeInBytes;
                }
                else
                {
                    sampleNodes.Add(null);
                }
            }

            CheckSizes();

            validNodeIndexes = tempNodeIndexes.ToArray();


        }

        private void CheckSizes()
        {
            for (int i = 0; i < sampleNodes.Count; i++)
            {
                if (sampleNodes[i] != null)
                {
                    if (i + 1 < offsets.Length && offsets[i+1] != 0 && offsets[i + 1] - offsets[i] != sampleNodes[i].SizeInBytes)
                    {
                        throw new Exception("Size incorrect");
                    }
                }
            }
        }

        public void WriteSoundEffect()
        {
            int byteOffset = 0;
            RomData.Set8(address, startValue);

            byteOffset += 1;

            for (int i = 0; i < offsets.Length; i++)
            {
                ushort offset = offsets[i];

                RomData.Set16(address + (uint)byteOffset, offset);
                byteOffset += 2;
                if (keyedSampleNodes.ContainsKey(offset))
                {
                    keyedSampleNodes[offset].WriteData();
                }
            }
        }

        public void UpdateAddress(uint newAddress)
        {
            address = newAddress;
        }

        public int SizeInBytes
        {
            get 
            {
                return SampleSpec.SoundEffectSampleMax * 2 + 0x01 + dataSize;
            }
        }

    }
}
