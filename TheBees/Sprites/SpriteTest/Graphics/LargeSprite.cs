using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SpriteTest.Graphics
{
    struct TileRef
    {
        ushort tileIndex;
        ushort palIndex;
 
        public TileRef(ushort newTileIndex, ushort newPalIndex)
        {
            tileIndex = newTileIndex;
            palIndex = newPalIndex;
        }
        
        public ushort TileIndex{ get{ return tileIndex;}}
        public ushort PalIndex{ get{ return palIndex;}}
    }

    struct BGSurface
    {
        byte xPos;
        byte yPos;
        byte surfaceIndex;

        public BGSurface(byte newYPos, byte newXPos, byte newSurfaceIndex)
        {
            xPos = newXPos;
            yPos = newYPos;
            surfaceIndex = newSurfaceIndex;
        }

        public byte XPos { get { return xPos; } }
        public byte YPos { get { return yPos; } }
        public byte SurfaceIndex { get { return surfaceIndex; } }
    }

    class LargeSprite:Sprite
    {
        private const int maxTileW = MaxSpriteW / tileSize;
        private const int maxTileH = MaxSpriteH / tileSize;

        private uint address;
        private uint length;
        
        private int tileW = 32;
        private int tileH = maxTileH;
        
        private int refAmt = 0x1100;

        private int surfaceSize = 16;

        List<TileRef> tileRefList;
        List<BGSurface> bgSurfaceList;

        public LargeSprite(byte[] newSpriteData, byte[] newRomData, List<Color[]> newPalletSet, int newXAxis = 0, int newYAxis = 0, int newStartOffset = 0) 
        : base(newSpriteData, newRomData, newPalletSet, newXAxis, newYAxis, newStartOffset)
        {
        }

        protected override void Init()
        {
            tileRefList = new List<TileRef>();
            bgSurfaceList = new List<BGSurface>();

            lookupAddr = Helper.Rotate32(BitConverter.ToUInt32(spriteData, 0));
            length = Helper.Rotate32(BitConverter.ToUInt32(spriteData, 4));
            address = Helper.Rotate32(BitConverter.ToUInt32(spriteData, 8));

            lookupAddr = (lookupAddr << 1) - 0x400000;
            address = (address << 1) - 0x400000;
            length = ((length << 1) + 2) << 3;

            

            for (int i = 0; i < refAmt; i++)
            {
                tileRefList.Add(
                    new TileRef(
                        (ushort)((int)Helper.Rotate16(BitConverter.ToUInt16(spriteData, i * 4 + 16))/2),
                        Helper.Rotate16(BitConverter.ToUInt16(spriteData, i * 4 + 16 + 2))
                        )
                    );
            }

            // initialize surfaces here

            bgSurfaceList.Add(new BGSurface(0x20, 0x00, 0x09));
            bgSurfaceList.Add(new BGSurface(0x20, 0x40, 0x0A));
            bgSurfaceList.Add(new BGSurface(0x20, 0x80, 0x0B));
            bgSurfaceList.Add(new BGSurface(0x20, 0xC0, 0x0C));
            bgSurfaceList.Add(new BGSurface(0x30, 0x00, 0x0D));
            bgSurfaceList.Add(new BGSurface(0x30, 0x40, 0x0E));
            bgSurfaceList.Add(new BGSurface(0x30, 0x80, 0x0F));
            bgSurfaceList.Add(new BGSurface(0x30, 0xC0, 0x10));

            Process();

        }

        protected override void SetSpriteSize()
        {
            spriteWidth = 1024;
            spriteHeight = 1024;
        }

        protected override void InitRawData()
        {
            
            //rawDataSize = (uint)(spriteWidth * spriteHeight);
            rawDataSize = length;
            rawData = new byte[length];
        }

        protected override void Process()
        {

            InitRawData();
            SetSpriteSize();

            DoCharDMA(address, 0, length);

        }

        private void DrawAllSurfaces()
        {
            
            for (int i = 0; i < bgSurfaceList.Count; i++)
            {
                DrawSurface(bgSurfaceList[i].SurfaceIndex, bgSurfaceList[i].XPos/4, bgSurfaceList[i].YPos -0x20);
            }
        }

        private void DrawSurface(int index, int xTilePos, int yTilePos)
        {
            int start = index * (surfaceSize * surfaceSize);
            int amount = (surfaceSize * surfaceSize);
            int x = 0, y = 0;

            for (int i = 0; i < amount; i++)
            {
                TileRef t = tileRefList[start + i];
                int palIndex = t.PalIndex + palletOffset;

                // remove later. used for researching purposes
                if(palIndex < palletSet.Count)
                    DrawTile(t.TileIndex, (x * surfaceSize) + (xTilePos * surfaceSize), (y * surfaceSize) + (yTilePos * surfaceSize), palIndex);

                x++;
                if (x == surfaceSize)
                {
                    x = 0;
                    y++;

                    if (y == surfaceSize)
                    {
                        return;
                    }
                }
            }
            
        }

        public override void DrawSprite(Bitmap newBitmap, int xPos, int yPos, bool bClearBG = true)
        {
            b = newBitmap;
            destBitmapW = b.Width;
            destBitmapH = b.Height;

            StartDrawSprite(bClearBG);
            DrawAllSurfaces();
            //DrawAllTiles(1, 1);

            EndDrawSprite();
        }

        public void SetWidthInTiles(int newW)
        {
            /*
            tileW = newW;
            if (tileW > maxTileW)
                tileW = maxTileW;
            DrawSprite(b, destBitmapW, destBitmapH);
            */
        }

        private void DrawTiles(int startX, int startY)
        {
            int max = (int)length / (16 * 16);
            int x = 0, y = 0;

            for (int i = (startY * tileH + startX); i < max; i++)
            {
                DrawTile(i, x * tileSize, y * tileSize, 0, 0, 0);

                x += 1;

                if (x == tileW)
                {
                    x = 0;
                    y += 1;
                }

                if (y == tileH)
                {
                    break;
                }
            }
        }
        private void DrawAllTiles(int startX, int startY)
        {

            int x = 0, y = 0;

            for (int t = 0; t < tileRefList.Count; t++)
            {
                TileRef tile = tileRefList[t];

                if (tile.PalIndex != 0 || tile.TileIndex != 0)
                {
                    DrawTile(tile.TileIndex / 2, x * tileSize, y * tileSize, 0, 0, 0);

                    x += 1;

                    if (x == tileW)
                    {
                        x = 0;
                        y += 1;
                    }

                    if (y == tileH)
                    {
                        break;
                    }
                }
            }
        }
    }
}
