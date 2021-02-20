using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheBees.UnitData
{
    public class InputConfig
    {
        public bool N, U, D, F, B;
        public bool WhileRising, WhileFalling, StrictDirectional, LenientDirectional;
        public byte Distance;

        public InputConfig(ushort data)
        {
            Value = data;
        }

        public ushort Value
        {
            get
            {
                if (Distance != 0)
                    return (ushort)Distance;

                ushort output = 0;
                output |= U ? (ushort)0x0001 : (ushort)0;
                output |= D ? (ushort)0x0002 : (ushort)0;
                output |= F ? (ushort)0x0004 : (ushort)0;
                output |= B ? (ushort)0x0008 : (ushort)0;

                output |= WhileFalling ? (ushort)0x1000 : (ushort)0;
                output |= WhileRising ? (ushort)0x2000 : (ushort)0;
                output |= LenientDirectional ? (ushort)0x4000 : (ushort)0;
                output |= StrictDirectional ? (ushort)0x8000 : (ushort)0;
                return output;
            }

            set
            {
                if ((value & (ushort)0xF000) == 0)
                {
                    Distance = (byte)value;
                    return;
                }
                N = (value & 0x0000) == 0x0000 && !StrictDirectional;
                U = (value & 0x0001) == 0x0001;
                D = (value & 0x0002) == 0x0002;
                F = (value & 0x0004) == 0x0004;
                B = (value & 0x0008) == 0x0008;

                WhileFalling = (value & 0x1000) == 0x1000;
                WhileRising = (value & 0x2000) == 0x2000;
                LenientDirectional = (value & 0x4000) == 0x4000;
                StrictDirectional = (value & 0x8000) == 0x8000;

            }
        }

    }
}
