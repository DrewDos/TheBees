using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheBees.UnitData
{
    public class CancelSpec
    {
        public bool LP, MP, HP, LK, MK, HK;
        public CancelTarget Target;
        public CancelDirection Direction;
        public bool StrictDirections;

        public CancelSpec(ushort data)
        {
            Value = data;
        }

        public ushort Value
        {
            get
            {
                ushort output = 0;
                output |= (ushort)((ushort)Direction & 0x000F);
                output |= LP ? (ushort)0x0010 : (ushort)0;
                output |= MP ? (ushort)0x0020 : (ushort)0;
                output |= HP ? (ushort)0x0040 : (ushort)0;
                output |= LK ? (ushort)0x0100 : (ushort)0;
                output |= MK ? (ushort)0x0200 : (ushort)0;
                output |= HK ? (ushort)0x0400 : (ushort)0;
                output |= StrictDirections ? (ushort)0x0080 : (ushort)0;
                output |= Target == CancelTarget.Target ? (ushort)0x0800 : (ushort)0;

                return output;
            }

            set
            {

                Direction = (CancelDirection)(value & 0x000F);
                LP = (value & 0x0010) == 0x0010;
                MP = (value & 0x0020) == 0x0020;
                HP = (value & 0x0040) == 0x0040;
                LK = (value & 0x0100) == 0x0100;
                MK = (value & 0x0200) == 0x0200;
                HK = (value & 0x0400) == 0x0400;
                StrictDirections = (value & 0x0080) == 0x0080;
                if ((value & 0x0800) == 0x0800) Target = CancelTarget.Target; else Target = CancelTarget.Any;
            }
        }
    }
    public enum CancelTarget
    {
        Target,
        Any
    }
    public enum CancelDirection
    {
        None,
        DF,
        D,
        DB,
        F,
        N,
        B,
        UF,  
        U, 
        UB,
        NoDBDDF,
        NoUBUUF,
        ForN, 
        BorN, 
        BorF, 
        BForN
    }

}
