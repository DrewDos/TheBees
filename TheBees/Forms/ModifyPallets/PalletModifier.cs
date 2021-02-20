using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TheBees.Forms
{
    class PalletModifier
    {
        public delegate void UpdatePalletDelegate(Color[] newPallet);

        private ColorAdjuster adjuster;
        private PalletControl palletControl;
        private Color [] basePallet;

        public ColorAdjuster Adjuster { get { return adjuster; } }
        public PalletControl Control { get { return palletControl; } }

        private UpdatePalletDelegate updatePallet = null;
        public UpdatePalletDelegate UpdatePallet { set { updatePallet = value; } }

        public double FactorFromColor = 0.12156862745098039215686274509804;
        public double FactorToColor = 8.2258064516129032258064516129032;

        int prevAdjR = 0;
        int prevAdjG = 0;
        int prevAdjB = 0;

        public PalletModifier(ColorAdjuster srcAdjuster, PalletControl srcControl)
        {
            adjuster = srcAdjuster;
            palletControl = srcControl;

            adjuster.SetMode(TrackMode.Set);
            adjuster.AdjustColor = OnAdjustColor;
            adjuster.SetColor = OnSetColor;
            palletControl.SelectionChange = OnSelectionChange;
        }

        public void SetBasePallet(Color[] newBase)
        {
            basePallet = newBase;
        }

        private void OnUpdatePallet(Color[] newPallet)
        {
            if(updatePallet != null)
                updatePallet(newPallet);
        }

        public void OnAdjustColor(int r, int g, int b)
        {
            int newR = (int)Math.Round((double)r * FactorToColor);
            int newG = (int)Math.Round((double)g * FactorToColor);
            int newB = (int)Math.Round((double)b * FactorToColor);


            palletControl.GetColorSelection().AdjustSelection(newR - prevAdjR, newG - prevAdjG, newB - prevAdjB);
            OnUpdatePallet(palletControl.Pallet);
        }

        public void OnSetColor(int r, int g, int b)
        {
            int newR = (int)Math.Round((double)r * FactorToColor);
            int newG = (int)Math.Round((double)g * FactorToColor);
            int newB = (int)Math.Round((double)b * FactorToColor);

            palletControl.GetColorSelection().UpdateSelection(newR, newG, newB);
            OnUpdatePallet(palletControl.Pallet);
        }

        public void OnSelectionChange(int count)
        {
            if (count > 0)
            {
                adjuster.Enable();

                if (count == 1)
                {
                    ColorIndex index = palletControl.GetColorSelection().ColorIndexes[0];

                    int srcR = (int)Math.Round(index.R * FactorFromColor);
                    int srcG = (int)Math.Round(index.G * FactorFromColor);
                    int srcB = (int)Math.Round(index.B * FactorFromColor);

                    adjuster.SetValues(srcR, srcG, srcB);
                }
                else
                {
                    prevAdjR = 0;
                    prevAdjG = 0;
                    prevAdjB = 0;
                    palletControl.GetColorSelection().SetBase(basePallet);
                    adjuster.SetValues(0, 0, 0);
                }
            }
            else
            {
                adjuster.Enable(false);
            }
        }

        public int[,] GetFactoredPallet()
        {
            Color[] srcPallet = palletControl.Pallet;
            int[,] factoredPallet = new int[srcPallet.Length,3];

            for (int i = 0; i < srcPallet.Length; i++)
            {
                factoredPallet[i,0] = (int)Math.Round((double)srcPallet[i].R * FactorFromColor);
                factoredPallet[i,1] = (int)Math.Round((double)srcPallet[i].G * FactorFromColor);
                factoredPallet[i,2] = (int)Math.Round((double)srcPallet[i].B * FactorFromColor);
            }

            return factoredPallet;
        }

        public void SetPallet(Color[] newPallet)
        {
            if (newPallet.Length < 0x40)
                throw new Exception("Pallet is too small");

            palletControl.ClearSelection();
            palletControl.LoadPallet(newPallet);
            OnUpdatePallet(palletControl.Pallet);

            
        }
    }
}
