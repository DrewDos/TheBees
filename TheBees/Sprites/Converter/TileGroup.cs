using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SpriteCreator
{
    public class TileGroup
    {
        static public int TileSize = 0;
        public Rectangle[] Rects;
        public int StartX;
        public int StartY;
        public int Width;
        public int Height;

        public TileDataBlock DataBlock;

        public TileGroup(Rectangle[] rects, int startX, int startY, int width, int height)
        {
            Rects = rects;
            StartX = startX;
            StartY = startY;
            Width = width;
            Height = height;
        }

        public int WidthInPixels { get { return TileSize * Width; } }
        public int HeightInPixels { get { return TileSize * Height; } }
    }
}
