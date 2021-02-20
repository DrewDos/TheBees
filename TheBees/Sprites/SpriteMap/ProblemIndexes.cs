using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TheBees.Data;

namespace TheBees.Sprites
{
    static public class ProblemIndexes
    {
        static public int [] Indexes = new int[]
        {
            0x000009DD,
            0x000022C2,
            0x000027CC,
            0x00002FA0,
            0x00003ACF,
            0x0000410B,
            0x0000539B,
            0x00005883,
            0x000065FF,
            0x00006B10,
            0x0000714B,
            0x0000767F,
            0x00009513,
            0x000095DE,
            0x000096D7,
            0x0000974A,
            0x0000994E,
            0x00009A1B,
            0x00009B0E,
            0x00009B2B,
            0x00009B37,
            0x00009B63,
            0x00009B6B,
            0x00009B77,
            0x00009B8F,
            0x00009B9B,
            0x00009BA7,
            0x00009C87,
            0x00009D24,
            0x00009DA7,
            0x00009DBF,
            0x00009E67,
            0x00009FF6,
            0x0000A1DA,
            0x0000A9F7,
            0x0000B1E7,
            0x0000B2B2,
            0x0000B348,
            0x0000B40D,
            0x0000B4B7,
            0x0000B4ED,
            0x0000B521,
            0x0000B5A7,
            0x0000B627,
            0x0000B6A7,
            0x0000B727,
            0x0000B7A7,
            0x0000B827,
            0x0000B8A7,
            0x0000B927,
            0x0000B9A7,
            0x0000BA27,
            0x0000BAA7,
            0x0000BB27,
            0x0000BBA7,
            0x0000BC27,
            0x0000BCA2,
            0x0000BD1D,
            0x0000BD57,
            0x0000BDE7,
            0x0000D87F,
            0x0000D8CF,
            0x0000D96F,
            0x0000DA2F,
            0x0000DA6F,
            0x0000DABF,
            0x0000DAFF,
            0x0000DB3F,
            0x0000DBEF,
            0x0000DC3F,
            0x0000DC9F,
            0x0000DCDF,
            0x0000DD5F,
            0x0000DEDF,
            0x0000DF1F,
            0x0000DF88,
            0x0000E09F,
            0x0000E14F,
            0x0000E16F,
            0x0000E1EF,
            0x0000E21F,
            0x0000E272,
            0x0000E2CF,
            0x0000E31F,
            0x0000E35F,
            0x0000E3AF,
            0x0000E3CF,
            0x0000E3EF,
            0x0000E44F,
            0x0000E46F,
            0x0000E597,
            0x0000E5B7
        };

        static public bool IsProblemIndex(int index)
        {
            return Array.Find(Indexes, x => x == index) > 0;
        }
    }
}
