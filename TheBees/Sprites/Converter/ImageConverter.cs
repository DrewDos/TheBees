using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace SpriteCreator
{
    static class ImageConverter
    {

        private const int tileSize = 16;
        unsafe private delegate Color GetColorDelegate(byte* data);

        static public SpriteRomInfo GetSpriteData(string imageSource, Color[] pallet)
        {
            Color backgroundColor = pallet[0];
            Dictionary<uint, byte> colorIndexes = GetIndexedColors(pallet);

            Bitmap sourceBitmap = new Bitmap(imageSource);
            Rectangle rect = GetSourceCoords(sourceBitmap, backgroundColor);

            bool [] tilesActive;
            Rectangle [] tileRects;
            TileGroup [] tileGroups;

            int currWidth = rect.Width;
            int currHeight = rect.Height;

            if (currWidth % tileSize > 0)
            {
                currWidth += (tileSize - (currWidth % tileSize));
            }

            if (currHeight % tileSize > 0)
            {
                currHeight += (tileSize - (currHeight % tileSize));
            }

            if (currWidth != rect.Width || currHeight != rect.Height)
            {
                SetProperSize(ref sourceBitmap, backgroundColor, rect.X, rect.Y, currWidth, currHeight);
            }

            tilesActive = GetTilesActive(sourceBitmap, backgroundColor);
            tileRects = GetTileRects(tilesActive, currWidth/16, currHeight/16);
            tileGroups = GetTileGroups(currWidth, currHeight, tilesActive, tileRects);

            return ConvertTileGroups(sourceBitmap, colorIndexes, tileGroups);

        }

        static private Dictionary<uint, byte> GetIndexedColors(Color[] pallet)
        {
            Dictionary<uint, byte> indexedColors = new Dictionary<uint, byte>();
            for (int i = 0; i < 64; i++)
            {
                uint colorKey = (uint)pallet[i].ToArgb();
                if (!indexedColors.ContainsKey(colorKey))
                {
                    indexedColors[colorKey] = (byte)i;
                }
            }

            return indexedColors;
        }

        static private void SetProperSize(ref Bitmap sourceBitmap, Color backgroundColor, int startX, int startY, int newWidth, int newHeight)
        {
            Bitmap bitmap = new Bitmap(newWidth, newHeight);

            Graphics g = Graphics.FromImage(bitmap);
            g.FillRectangle(new SolidBrush(backgroundColor), new Rectangle(0, 0, newWidth, newHeight));

            g.DrawImage(sourceBitmap, new Rectangle(0, 0, newWidth, newHeight), new Rectangle(startX, startY, newWidth, newHeight), GraphicsUnit.Pixel);

            sourceBitmap = bitmap;
        }

        static private TileGroup [] GetTileGroups(int width, int height, bool [] tilesActive, Rectangle [] tileRects)
        {

            int tileCountX = width / tileSize;
            int tileCountY = height / tileSize;
            int tileCount = tileCountX * tileCountY;

            bool[] isGrouped = new bool[tileCount];
            Array.Clear(isGrouped, 0, tileCount);

            List<TileGroup> tileGroups = new List<TileGroup>();

            for (int y = 0; y < tileCountY; y++)
            {
                for (int x = 0; x < tileCountX; x++)
                {
                    if (tilesActive[y * tileCountX + x] && !isGrouped[y * tileCountX + x])
                    {
                        int groupX = x;
                        int groupXMax = (tileCountX - groupX > 4 ? groupX + 4 : tileCountX - groupX + groupX);

                        int groupY = y;
                        int groupYMax = (tileCountY - groupY > 4 ? groupY + 4 : tileCountY - groupY + groupY);

                        int groupWidth = 4;
                        int groupHeight = 4;

                        int currWidth = 0;
                        int currHeight = 0;

                        for (; groupY < groupYMax; groupY++)
                        {
                            currWidth = 0;
                            for (groupX = x; groupX < groupXMax; groupX++)
                            {
                                if (tilesActive[groupY * tileCountX + groupX] && !isGrouped[groupY * tileCountX + groupX])
                                {
                                    currWidth += 1;
                                }

                                else
                                {
                                    break;
                                }
                            }

                            if (groupX != x)
                            {
                                if (currWidth < groupWidth)
                                {
                                    groupWidth = currWidth;
                                }

                                currHeight++;
                            }
                            else
                            {
                                break;
                            }

                        }

                        groupHeight = currHeight;

                        if (groupWidth == 3)
                            groupWidth = 2;
                        if (groupHeight == 3)
                            groupHeight = 2;

                        groupXMax = x + groupWidth;
                        groupYMax = y + groupHeight;

                        List<Rectangle> groupRects = new List<Rectangle>();

                        for (groupX = x; groupX < groupXMax; groupX++)
                        {
                            for (groupY = y; groupY < groupYMax; groupY++)
                            {
                                isGrouped[groupY * tileCountX + groupX] = true;
                                groupRects.Add(tileRects[groupY * tileCountX + groupX]);
                            }
                        }

                        if (groupRects.Count > 0)
                        {
                            tileGroups.Add(new TileGroup(groupRects.ToArray(), x, y, groupWidth, groupHeight));
                        }
                    }
                }
            }

            return tileGroups.ToArray();
        }



        static private Rectangle [] GetTileRects(bool [] sourceTilesActive, int numTilesX, int numTilesY)
        {
            int tileCount = numTilesX * numTilesY;
            Rectangle [] tileRects = new Rectangle[tileCount];
            Array.Clear(tileRects, 0, tileCount);

            for (int y = 0; y < numTilesY; y++)
            {
                for (int x = 0; x < numTilesX; x++)
                {
                    if (sourceTilesActive[numTilesX * y + x])
                    {
                        int startX = x * tileSize;
                        int startY = y * tileSize;

                        tileRects[y * numTilesX + x] = new Rectangle(startX, startY, tileSize, tileSize);
                    }
                }
            }

            return tileRects;
        }

        unsafe static private bool [] GetTilesActive(Bitmap sourceBitmap, Color backgroundColor)
        {
            byte bpp = GetBPP(sourceBitmap.PixelFormat);
            BitmapData bData = sourceBitmap.LockBits(new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height), ImageLockMode.ReadWrite, sourceBitmap.PixelFormat);
            byte* scan0 = (byte*)bData.Scan0.ToPointer();

            int width = sourceBitmap.Width;
            int height = sourceBitmap.Height;
            int numTilesX = width / tileSize;
            int numTilesY = height / tileSize;

            int tileCount = width / tileSize * height / tileSize;
            bool [] tilesActive = new bool[tileCount];

            for (int tileY = 0; tileY < numTilesY; tileY++)
            {
                for (int tileX = 0; tileX < numTilesX; tileX++)
                {
                    bool colorSet = false;

                    for (int y = 0; y < tileSize; y++)
                    {
                        for (int x = 0; x < tileSize; x++)
                        {
                            byte* data = scan0 + (((tileY * tileSize * width) + (y * width) + (tileX * tileSize) + x) * ((int)bpp / 8));
                            //BGRA
                            Color color = Color.FromArgb((int)data[3], (int)data[2], (int)data[1], (int)data[0]);

                            if (!color.Equals(backgroundColor))
                            {
                                colorSet = true;
                                break;
                            }
                        }

                        if (colorSet)
                            break;
                    }

                    if (colorSet)
                    {
                        tilesActive[tileY * numTilesX + tileX] = true;
                    }
                }
            }

            sourceBitmap.UnlockBits(bData);

            return tilesActive;


        }


        unsafe static private Rectangle GetSourceCoords(Bitmap sourceBitmap, Color backgroundColor)
        {
            int endX = 0;
            int endY = 0;

            int startX = sourceBitmap.Width;
            int startY = sourceBitmap.Height;

            byte bpp = GetBPP(sourceBitmap.PixelFormat);
            BitmapData bData = sourceBitmap.LockBits(new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height), ImageLockMode.ReadWrite, sourceBitmap.PixelFormat);
            byte* scan0 = (byte*)bData.Scan0.ToPointer();

            GetColorDelegate getColor = null;

            switch (bpp)
            {
                case 8:
                    getColor = (x) => { return sourceBitmap.Palette.Entries[x[0]]; };
                    break;
                case 24:
                    getColor = (x) => { return Color.FromArgb(255, x[2], x[1], x[0]); };
                    break;
                case 32:
                    getColor = (x) => { return Color.FromArgb(0xFF, x[2], x[1], x[0]); };
                    break;
            }

            for (int y = 0; y < bData.Height; y++)
            {
                for (int x = 0; x < bData.Width; x++)
                {
                    byte* data = scan0 + y * bData.Stride + x * bpp / 8;

                    Color color = getColor(data);

                    if (!color.Equals(backgroundColor))
                    {
                        if (startX > x)
                        {
                            startX = x;
                        }

                        if (startY > y)
                        {
                            startY = y;
                        }

                        if (endX < x)
                        {
                            endX = x;
                        }

                        if (endY < y)
                        {
                            endY = y;
                        }
                    }
                }
            }

            sourceBitmap.UnlockBits(bData);

            int newWidth = endX - startX;
            int newHeight = endY - startY;

            if (endX != startX)
                newWidth += 1;

            if (endY != startY)
                newHeight += 1;

            return new Rectangle(startX, startY, newWidth, newHeight);
        }

        static private byte GetBPP(PixelFormat format)
        {
            byte bpp = 0;

            switch (format)
            {
                case PixelFormat.Format8bppIndexed:
                    bpp = 8;
                    break;
                case PixelFormat.Format24bppRgb:
                    bpp = 24;
                    break;
                case PixelFormat.Format32bppArgb:
                case PixelFormat.Format32bppRgb:
                case PixelFormat.Format32bppPArgb:
                    bpp = 32;
                    break;
                default:
                    bpp = 0;
                    break;
            }

            return bpp;
        }

        static unsafe private SpriteRomInfo ConvertTileGroups(Bitmap sourceBitmap, Dictionary<uint, byte> colorIndexes, TileGroup [] tileGroups)
        {
            byte bpp = GetBPP(sourceBitmap.PixelFormat);
            BitmapData bData = sourceBitmap.LockBits(new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height), ImageLockMode.ReadWrite, sourceBitmap.PixelFormat);
            byte* scan0 = (byte*)bData.Scan0.ToPointer();

            int destination = 0;
            byte index = 0;

            int width = sourceBitmap.Width;
            int height = sourceBitmap.Height;

            foreach (TileGroup group in tileGroups)
            {
                List<byte> rawData = new List<byte>();

                int count = group.Width * group.Height;

                int length = count * tileSize * tileSize;

                //bool start = true;
                byte rleIndex = 0;
                byte rleCount = 0;

                int pX = 0;
                int pY = 0;

                for (int i = 0; i < count; i++)
                {
                    Rectangle rect = group.Rects[i];

                    int tileX = rect.X;
                    int tileY = rect.Y;


                    for (pY = 0; pY < tileSize; pY++)
                    {
                        for (pX = 0; pX < tileSize; pX++)
                        {
                            byte* data = scan0 + (tileY * width + pY * width + tileX + pX) * (bpp / 8);

                            uint key = (uint)Color.FromArgb(data[3], data[2], data[1], data[0]).ToArgb();

                            index = 0;

                            if (colorIndexes.ContainsKey(key))
                            {
                                index = colorIndexes[key];
                            }
                            //rawData.Add(index);
                            ProcessByte(rawData, index, ref rleIndex, ref rleCount);
                        }
                    }


                }

                CompleteProcessGroup(rawData, rleCount);

                // raw data must be a multiple of 2
                if (rawData.Count % 2 > 0)
                {
                    rawData.Add(0);
                }

                group.DataBlock = new TileDataBlock(rawData.ToArray(), length, destination);

                destination += length;
            }

            return new SpriteRomInfo(tileGroups, sourceBitmap.Width, sourceBitmap.Height);
            
        }

        static private void ProcessByte(List<byte> buffer, byte index, ref byte rleIndex, ref byte rleCount)
        {
            if (buffer.Count == 0)
            {
                buffer.Add(index);
                rleIndex = index;
                return;
            }

            if (index == rleIndex)
            {
                rleCount += 1;

                if (rleCount == 0x40)
                {
                    buffer.Add((byte)((rleCount + 0x3F)));
                    rleCount = 0;
                }

            }
            else
            {
                if (rleCount > 0)
                {
                    buffer.Add((byte)((rleCount + 0x3F)));
                }

                buffer.Add(index);
                rleCount = 0;
                rleIndex = index;
            }
            
        }

        static private void CompleteProcessGroup(List<byte> buffer, byte rleCount)
        {
            if (rleCount > 0)
            {
                buffer.Add((byte)((rleCount + 0x3F)));
            }

        }



    }
}
