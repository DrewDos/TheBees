using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Data;
using System.IO;

namespace TheBees.Sprites
{
    static class Pallet
    {
        public const int sizeInBytes = 0x80;
        public const int palletSize = 0x40;

        private static double FactorFromColor = 0.12156862745098039215686274509804;
        private static double FactorToColor = 8.2258064516129032258064516129032;

        public static Color[] GetPallet(uint address)
        {
            Color[] pallet = new Color[palletSize];

            for (int i = 0; i < palletSize; i++)
            {
                pallet[i] = GetColorFromData(RomData.GetRaw16(address, i * 2));
            }

            return pallet;

        }

        public static void SetPallet(uint address, Color [] pallet)
        {
            if (pallet.Length != palletSize)
            {
                throw new ArgumentOutOfRangeException();
            }

            for (int i = 0; i < palletSize; i++)
            {
                RomData.Set16(address + (uint)i*2, GetDataFromColor(pallet[i]));
            }
        }

        private static Color GetColorFromData(ushort source)
        {
            byte r = 0, g = 0, b = 0;
            //uint swapped = source;
            ushort swapped = (ushort)((source >> 8) | (source << 8));

            b = (byte)((swapped & 0x7C00) >> 10);
            g = (byte)((swapped & 0x3E0) >> 5);
            r = (byte)(swapped & 0x1F);

            r = (byte)(r << (3));
            g = (byte)(g << (3));
            b = (byte)(b << (3));

            r += (byte)(r / 32);
            g += (byte)(g / 32);
            b += (byte)(b / 32);

            //auxr = auxr;
            //g = g << 8;
            //b = b << 16;

            return Color.FromArgb(255, r, g, b);
        }

        private static ushort GetDataFromColor(Color color)
        {
            uint newValue = 0;
            int rValue, gValue, bValue;
            rValue = (int)Math.Round((double)color.R * FactorFromColor);
            gValue = (int)Math.Round((double)color.G * FactorFromColor);
            bValue = (int)Math.Round((double)color.B * FactorFromColor);

            newValue |= ((uint)rValue);
            newValue |= ((uint)gValue << 5);
            newValue |= ((uint)bValue << 10);

            ushort rotated = (ushort)((newValue >> 8) | (newValue << 8));
            return (ushort)newValue;
        }
    }
}
