using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
using System.IO;

namespace SpriteCreator
{
    static class PalletFile
    {
        static public Color [] Get(string fileName)
        {
            BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open));

            Color[] colors = new Color[64];

            for (int i = 0; i < 64; i++)
            {
                byte r = reader.ReadByte();
                byte g = reader.ReadByte();
                byte b = reader.ReadByte();

                colors[i] = Color.FromArgb(255, r, g, b);
                uint rawColor = (uint)colors[i].ToArgb();
            }

            reader.Close();

            return colors;
        }
    }
}
