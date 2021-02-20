using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;


namespace TheBees.Sprites
{

    
    unsafe public class NormalSprite : Sprite
    {
        // sprite information
        private int baseXOffset;
        private int baseYOffset;

        private bool masterFlipX = false;
        private bool masterFlipY = false;

        private NormalSpriteDef spriteDef; 

        public int BaseX { get { return baseXOffset; } }
        public int BaseY { get { return baseYOffset; } }
        //Color[] pallet;

        protected override uint RealLookupAddress { get { return spriteDef.RealLookupAddress; } }

        public NormalSprite(uint address, int newXAxis = 0, int newYAxis = 0, bool sourceFlipX = false, bool sourceFlipY = false) 
        : base(address, newXAxis, newYAxis)
        {
            masterFlipX = sourceFlipX;
            masterFlipY = sourceFlipY;

            spriteDef = NormalSpriteDef.GetRecordable(address);

            Process();
        }

        protected override void Init()
        {
        }

        protected override void SetSpriteSize()
        {
            List<TileGroupDef> tileGroupList = spriteDef.TileGroupList;

            int len = tileGroupList.Count;
            int minX = 0xFFFF, minY = 0xFFFF,
                maxX = -0xFFFF, maxY = -0xFFFF;


            for (int i = 0; i < len; i++)
            {

                int halfW = ((tileGroupList[i].Width * 16) / 2);
                int currMinX = -halfW + tileGroupList[i].XOffset * (masterFlipX?-1:1);
                int currMaxX = halfW + tileGroupList[i].XOffset * (masterFlipX ? -1 : 1);

                int halfH = ((tileGroupList[i].Height * 16) / 2);
                int currMinY = -halfH + tileGroupList[i].YOffset * (masterFlipY ? -1 : 1);
                int currMaxY = halfH + tileGroupList[i].YOffset * (masterFlipY ? -1 : 1);

                minX = currMinX < minX ? currMinX : minX;
                minY = currMinY < minY ? currMinY : minY;
                maxX = currMaxX > maxX ? currMaxX : maxX;
                maxY = currMaxY > maxY ? currMaxY : maxY;
            }

            spriteWidth = maxX - minX;
            spriteHeight = maxY - minY;
            baseXOffset =  -minX;
            baseYOffset = -minY;
        }

        // drawing functions


        // tile drawing functions
        public override void DrawSprite(Bitmap newBitmap, Color [] newPallet,  int xPos, int yPos, bool bClearBG = true)
        {
            b = newBitmap;
            destBitmapW = b.Width;
            destBitmapH = b.Height;
            palletSet.Clear();
            palletSet.Add(newPallet);

            StartDrawSprite(bClearBG);

            foreach (TileGroupDef tg in spriteDef.TileGroupList)
            {
                //DrawTileGroup(tg, xPos + xAxis, yPos + yAxis); // xAxis and yAxis have been removed from here
                DrawTileGroup(tg, xPos + baseXOffset, yPos + baseYOffset); // xAxis and yAxis have been removed from here
            }

            EndDrawSprite();
        }

        private void DrawTileGroup(TileGroupDef tg, int destX, int destY)
        {
            int xTileAmt = tg.Width,
                yTileAmt = tg.Height,
                xPos = tg.XOffset,
                yPos = tg.YOffset,
                tileOffset = (tg.TileStartOffset / 2),

                xAxis = ((xTileAmt * tileSize) / 2),
                yAxis = ((yTileAmt * tileSize) / 2),

                targetX, targetY;

            bool flipXFinal = tg.FlipHorizontal>0 != masterFlipX;
            bool flipYFinal = tg.FlipVertical > 0 != masterFlipY;

            //bool forceFlipX = true;
            //bool forceFlipY = false;
            xPos = xPos * (masterFlipX ? -1 : 1);
            yPos = yPos * (masterFlipY ? -1 : 1);
            //xAxis = -xAxis;
            //yPos = -yPos;

            for (int tileX = 0; tileX < xTileAmt; tileX++)
            {
                for (int tileY = 0; tileY < yTileAmt; tileY++)
                {

                    
                    //targetX = (tg.FlipHorizontal > 0) ? (xTileAmt - 1) - tileX : tileX;
                    //targetY = (tg.FlipVertical > 0) ? (yTileAmt - 1) - tileY : tileY;

                    targetX = (flipXFinal) ? (xTileAmt - 1) - tileX : tileX;
                    targetY = (flipYFinal) ? (yTileAmt - 1) - tileY : tileY;

                    DrawTile(
                        tileOffset + (tileX * yTileAmt) + tileY, // tile index
                        (targetX * tileSize) + destX + xPos - xAxis, // x position in bitmap to draw
                        (targetY * tileSize) + destY + yPos - yAxis, // y position in bitmap to draw
                        0, // sprite index will always be 0 for normal sprites
                        (byte)(flipXFinal ? 1 : 0),//tg.FlipHorizontal,
                        (byte)(flipYFinal ? 1 : 0)//tg.FlipVertical
                        );
                }
            }
        }
        // processing chain

        protected override void InitRawData()
        {
            List<TileDef> tileList = spriteDef.TileList;

            int len = tileList.Count;
            uint res = 0;
            uint currSz = 0;

            for (int i = 0; i < len; i++)
            {
                currSz = tileList[i].RealDestination + tileList[i].RealLength;
                if (res < currSz)
                    res = currSz;
            }
            rawDataSize = res;
            rawData = new byte[res];
        }

        protected override void Process()
        {

            List<TileDef> tileList = spriteDef.TileList;

            int len = tileList.Count;

            InitRawData();
            SetSpriteSize();

            for (int i = 0; i < len; i++)
            {

                DoCharDMA(tileList[i].RealSource, tileList[i].RealDestination, tileList[i].RealLength);
            }


        }

        public int RealAxisX { get { return xAxis; } }
        public int RealAxisY { get { return yAxis; } }
        public int AxisX { get { return masterFlipX ? -xAxis : xAxis; } }
        public int AxisY { get { return masterFlipY ? -yAxis : yAxis; } }
        public int Width { get { return spriteWidth; } }
        public int Height { get { return spriteHeight; } }
    }
}
