using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheBees.UnitData
{
    class UnitSpec
    {
        public const uint UnitOffset = 0x0618B148;//0x0618B1B4;
        public const uint UnitOffsetSize = 0x6C;

        public const int CharacterUnitCount = 21;//21;

        public const uint MissileUnitOffset = 0x0618B5EC;
        public const uint MissileConfigOffset = 0x061BB058;
        public const uint AddressOfMissleConfigOffset = 0x060E39FC;
        public const int MissileConfigCount = 0xF3;
        public const int MissileUnitIndex = 21;

        public const uint CommandListOffset = 0x0661381C;
        public const int CommandListOffsetSize = 0x38;

        public const int ActiveSpecialAccelDefCount = 0x12 * 4;
        public const uint SpecialCommandDefAddress = 0x65EFAD0;

        public const uint UnitPalletAddressOffset = 0x61A7DE8;
        public const uint UnitPalletIndexSize = 0x930;
        public const uint UnitPalletSideSize = 0x930 / 2;
        public const uint UnitPalletNumGroups = 0x07;
        public const uint PalletIndexSize = 0x0C;

        public const uint SAEffectOffset = 0x65EA670;
        public const uint SAEffectIndexSize = 0x40;

        public const uint EnemyCtrlPointerOffset = 0x065FBF40;
        public const int OrbitalBasisAddressCount = 0x12;

        static public uint GetCharacterUnitPalletOffset(uint unitID, uint palletIndex = 0)
        {
            return unitID * UnitPalletIndexSize + UnitPalletAddressOffset;
        }

        public static int[] UnitIndexRedirect = new int[] 
        { 
            3,
            4, 
            1, 
            7, 
            2, 
            0, 
            6, 
            9, 
            5, 
            8, 
            10,
            11,
            12,
            13,
            14,
            15,
            16,
            17,
            18,
            19,
            20,
        };

        public static int[] CharacterAddressRedirect = new int[] 
        { 
            0x06, // all character units
            0x03, 
            0x05, 
            0x01, 
            0x02, 
            0x09, 
            0x07, 
            0x04, 
            0x0A, 
            0x08,
            0x0C, 
            0x0D, 
            0x0E, 
            0x0F, 
            0x10, 
            0x11, 
            0x12, 
            0x13, 
            0x14, 
            0x15, 
            0x16,
            0x0B, // Missile
        };

        public static int[] PalletAddressRedirect = new int[]
        { 
            0x06, 
            0x03, 
            0x05, 
            0x01, 
            0x02, 
            0x09, 
            0x07, 
            0x04, 
            0x0A, 
            0x08, 
            0x0B,
            0x0C, 
            0x0D, 
            0x0E, 
            0x0F, 
            0x10, 
            0x11, 
            0x12, 
            0x13, 
            0x14, 
            0x15
        };

        static public uint[] OrbitalBasisOffsets = new uint[]
        {   
            0x65ECD1C,
            0x65ECDC4,
            0x65ECE1C,
            0x65ECE64,
            0x65ECEAC,
            0x65ECEF4,
            0x65ECF3C,
            0x65ECF84,
            0x65ECFD4,
            0x65ED208,
            0x65ED250,
            0x65ED298,
            0x65ED2E0,
            0x65ED388,
            0x65ED400,
            0x65ED400,
            0x65ED448,
            0x65ED490,
            0x65ED4D8,
            0x65ED580,
            0x65ED5C8
        };

        static public int[] GroupIndexesFromGameRef = new int[]
        {
            0,
            1,
            3,
            4,
            5,
            6,
            2,
            7,
            8,
            9

        };
        static public uint GetCharacterUnitOffset(int index)
        {
            return (uint)UnitSpec.CharacterAddressRedirect[index] * UnitOffsetSize + UnitOffset;
        }

        static public uint GetMissileUnitOffset()
        {
            return MissileUnitOffset;
        }

    }
}
