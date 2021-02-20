using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Data;
using System.IO;

namespace SpriteTest
{
    static class Pallet
    {
        public const int sizeInBytes = 0x80;
        public const int palletSize = 0x40;

        public static List<Color[]> GetRangeFromBuffer(byte[] buf, int start, int max)
        {
            List<Color[]> pallets = new List<Color[]>();
            int amt = (max - start) / sizeInBytes;

            for (int i = 0; i < amt; i++)
            {
                pallets.Add(MakePallet(buf, i * sizeInBytes + start, palletSize));
            }

            return pallets;
        }

        public static Color[] FromBuffer(byte[] buf, int start)
        {
            return MakePallet(buf, start, palletSize);
        }

        public static Color[] FromFile(String source)
        {
            byte[] buf;
            BinaryReader b = new BinaryReader(File.Open(source, FileMode.Open));
            
            buf = new byte[b.BaseStream.Length];
            b.Read(buf, 0, (int)b.BaseStream.Length);
            b.Close();

            return MakePallet(buf, 0, 64);
        }

        private static Color[] MakePallet(byte[] buf, int start, int size)
        {
            Color [] pallet = new Color[size];

            for (int i = 0; i < size; i++)
            {
                ushort[] rawColor = getRGB(BitConverter.ToUInt16(buf, start + i * 2));

                pallet[i] = Color.FromArgb((int)rawColor[0], (int)rawColor[1], (int)rawColor[2]);
            }

            return pallet;

        }

        private static ushort[] getRGB(ushort source)
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

            return new ushort[3] { r, g, b };
        }
    }
}
