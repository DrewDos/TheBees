using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using TheBees.General;

namespace TheBees.Forms
{
    public class ColorSelection
    {
        public delegate void UpdateCompleteDelegate(ColorSelection selection);

        private List<ColorIndex> colorIndexes = new List<ColorIndex>();
        public List<ColorIndex> ColorIndexes { get { return colorIndexes; } }

        private UpdateCompleteDelegate updateComplete = null;
        public UpdateCompleteDelegate UpdateComplete { set { updateComplete = value; } }

        private Color[] basePallet;

        public ColorSelection()
        {
        }

        public void UpdateSelection(int newR, int newG, int newB)
        {
            foreach (ColorIndex index in colorIndexes)
            {
                index.SetColor(newR, newG, newB);
            }

            OnUpdateComplete(this);
        }
        public void SetBase(Color[] newBase)
        {
            basePallet = newBase;
        }

        public void AdjustSelection(int adjR, int adjG, int adjB)
        {
            foreach (ColorIndex index in colorIndexes)
            {
                int newR, newG, newB;
                newR = MaintainBounds(basePallet[index.Index].R + adjR);
                newG = MaintainBounds(basePallet[index.Index].G + adjG);
                newB = MaintainBounds(basePallet[index.Index].B + adjB);

                index.SetColor(newR, newG, newB);
            }

            OnUpdateComplete(this);
        }

        private void OnUpdateComplete(ColorSelection selection)
        {
            if (updateComplete != null)
            {
                updateComplete(selection);
            }
        }
        private int MaintainBounds(int value)
        {
            if (value > 255)
            {
                value = 255;
            }

            if (value < 0)
            {
                value = 0;
            }

            return value;
        }

        public void Clear()
        {
            colorIndexes.Clear();
        }
    }
}
