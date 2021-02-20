using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheBees.Sound
{
    public static class SampleSpec
    {

        public const uint RawSampleHeaderPointers = 0x06788000;
        public const int RawSampleHeaderListAmount = 0x10;

        public const uint RawSampleDataPointers = 0x0678C000;
        public const int RawSampleCount = 0x300;

        public const int SoundEffectCount = 0x0CB3;
        public const uint SoundEffectRegion = 0x0678F000;
        public const int SoundEffectSampleMax = 0x10;

        static public uint[] SoundPointers = new uint[0x04]
        {
            0x06001010,
            0x06133E2C,
            0x06133EA4,
            0x0613413C

        };

        static public uint[] GetSampleDataGroupPointers()
        {
            return GetPointers(1);
        }

        static public uint[] GetSoundEffectPointers()
        {
            return GetPointers(2);
        }

        static public uint[] GetRawHeaderPointers()
        {
            return GetPointers(0);
        }

        static private uint[] GetPointers(int pointerIndex)
        {
            List<uint> output = new List<uint>();
            for (int i = 0; i < SoundPointers.Length; i++)
            {
                output.Add(SoundPointers[i] + (uint)pointerIndex * 4);
            }
            return output.ToArray();
        }

        static public HashSet<byte> KnownCodes = new HashSet<byte>() { 0xC1, 0xC2, 0xC2, 0xC4, 0xBF };
    }
}
