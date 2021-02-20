using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpriteTest
{
    static class Helper
    {
        public static ushort Rotate16(ushort source)
        {
            return (ushort)((int)(source >> 8) | (int)(source << 8));
        }

        public static uint Rotate32(uint source)
        {
            return (uint)((int)(source << 24) + ((int)(source & 0x0000FF00) << 8) + ((int)(source & 0x00FF0000) >> 8) + (int)(source >> 24));
        }
    }
}
