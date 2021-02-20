using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheBees.Forms
{
    public class ColorIndex
    {
        public int R;
        public int G;
        public int B;
        private int index;
        public int Index { get { return index; } }

        public ColorIndex(int srcR, int srcG, int srcB, int srcIndex)
        {
            R = srcR;
            G = srcG;
            B = srcB;
            index = srcIndex;
        }

        public void SetColor(int newR, int newG, int newB)
        {
            R = newR;
            G = newG;
            B = newB;
        }

    }
}
