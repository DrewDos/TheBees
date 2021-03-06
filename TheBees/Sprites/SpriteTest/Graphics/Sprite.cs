﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;


namespace SpriteTest.Graphics
{
    interface ISprite
    {
    }

    unsafe abstract class Sprite
    {
        public const int MaxSpriteW = 2048;
        public const int MaxSpriteH = 2048 * 3;

        protected const int tileSize = 16;

        // sprite header
        protected uint lookupAddr;

        // sprite information0
        protected int xAxis;
        protected int yAxis;
        protected int spriteWidth;
        protected int spriteHeight;

        // data information
        protected byte[] spriteData;
        protected byte[] romData;
        protected byte[] rawData;

        protected byte lastNormalByte = 0;
        protected uint rawDataSize;
        protected int startOffset;

        // used for bitmap drawing
        protected Bitmap b;
        protected int destBitmapW, destBitmapH;
        protected List<Color[]> palletSet;
        protected int palletOffset = 0;
        protected int bpp;
        protected byte* scan0;
        protected BitmapData bData;

        public Sprite(byte[] newSpriteData, byte[] newRomData, List<Color[]> newPalletSet, int newXAxis = 0, int newYAxis = 0, int newStartOffset = 0)
        {
            spriteData = newSpriteData;
            romData = newRomData;
            palletSet = newPalletSet;
            xAxis = newXAxis;
            yAxis = newYAxis;
            startOffset = newStartOffset;

            Init();
            Process();
        }

        // drawing functions
        unsafe protected void StartDrawSprite(bool bClear = true)
        {
            bData = b.LockBits(Rectangle.FromLTRB(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, b.PixelFormat);
            bpp = Image.GetPixelFormatSize(b.PixelFormat);
            scan0 = (byte*)bData.Scan0.ToPointer();
            if(bClear)
                ClearBitmap();
        }

        unsafe protected void SetPixel(int x, int y, byte r, byte g, byte b)
        {
            byte* data = scan0 + bData.Stride * y + x * bpp / 8;
            data[0] = r;
            data[1] = g;
            data[2] = b;
        }

        unsafe protected void SetPixel(int x, int y, Color col)
        {
            byte* data = scan0 + bData.Stride * y + x * bpp / 8;
            data[0] = col.B;
            data[1] = col.G;
            data[2] = col.R;
            data[3] = 0xFF;
        }

        unsafe protected void ClearBitmap()
        {
            int len = b.Width * b.Height * bpp / 8;

            for (int i = 0; i < len; i++)
            {
                scan0[i] = 0;
            }
        }

        unsafe protected void EndDrawSprite()
        {
            b.UnlockBits(bData);
        }

        

        protected void DrawTile(int tileIndex, int x, int y, int palletIndex = 0, byte flipX = 0, byte flipY = 0)
        {
            int ptX = 0,
                ptY = 0,
                xAdd = 1, yAdd = 1,
                xSet = 0, ySet = 0,
                xSrc = 0, ySrc = 0,
                xFinal, yFinal;

            if (flipX > 0)
            {
                xAdd = -1;
                xSet = (tileSize - 1);
                xSrc = xSet;
            } 
            
            if (flipY > 0)
            {
                yAdd = -1;
                ySet = (tileSize - 1);
                ySrc = ySet;
            }

            if ((ySrc * tileSize) + xSrc + (tileIndex * 0x100) > rawDataSize)
                return;

            for (int i = 0; i < 0x100; i++)
            {
                byte pixel = rawData[(ySrc * tileSize) + xSrc + (tileIndex * 0x100)];

                xFinal = x + ptX;
                yFinal = y + ptY;
                if(xFinal >= 0 && yFinal >= 0 && xFinal < destBitmapW && yFinal < destBitmapH)
                {
                    SetPixel(xFinal, yFinal, palletSet[palletIndex][pixel]);
                }
                

                ptX += 1;
                xSrc += xAdd;

                if (ptX == tileSize)
                {
                    ptX = 0;
                    ptY += 1;

                    xSrc = xSet;
                    ySrc += yAdd;

                    if (ptY == tileSize)
                        break;
                }
            }
        }

        // taken from fba cps3run.cpp
        // cps3_do_char_dma
        protected void DoCharDMA(uint realSource, uint realDestination, uint realLength)
        {
            int lengthRemaining = (int)realLength;
            lastNormalByte = 0;

            while (lengthRemaining > 0)
            {
                byte currentByte = romData[realSource];
                realSource++;

                if ((currentByte & 0x80) > 0)
                {
                    byte realByte;
                    uint lengthProcessed;
                    currentByte &= 0x7f;

                    realByte = romData[(lookupAddr + currentByte * 2 + 0)];

                    lengthProcessed = (uint)ProcessByte(realByte, realDestination, lengthRemaining);
                    lengthRemaining -= (int)lengthProcessed; // subtract the number of bytes the operation has taken
                    realDestination += lengthProcessed; // add it onto the destination
                    if (realDestination > rawDataSize) return;
                    if (lengthRemaining <= 0) return; // if we've expired, exit

                    realByte = romData[(lookupAddr + currentByte * 2 + 1)];

                    lengthProcessed = (uint)ProcessByte(realByte, realDestination, lengthRemaining);
                    lengthRemaining -= (int)lengthProcessed; // subtract the number of bytes the operation has taken
                    realDestination += lengthProcessed; // add it onto the destination
                    //if (realDestination > rawDataSize) return;
                    if (lengthRemaining <= 0) return;  // if we've expired, exit
                }
                else
                {
                    uint lengthProcessed;
                    lengthProcessed = (uint)ProcessByte(currentByte, realDestination, lengthRemaining);
                    lengthRemaining -= (int)lengthProcessed; // subtract the number of bytes the operation has taken
                    realDestination += lengthProcessed; // add it onto the destination
                    //if (realDestination > rawDataSize) return;
                    if (lengthRemaining <= 0) return;  // if we've expired, exit
                }
            }
        }

        protected int ProcessByte(byte realByte, uint destination, int maxLength)
        {

            if ((realByte & 0x40) > 0)
            {
                int tranfercount = 0;
                int rleLength = (int)(realByte & (uint)0x3f) + 1;

                while (rleLength > 0)
                {
                    int index = (int)(destination + tranfercount);
                    if (index >= 0)
                        rawData[index] = (byte)(lastNormalByte & 0x3f);
                    

                    tranfercount++;
                    rleLength--;
                    maxLength--;
                    if ((destination + tranfercount) > rawDataSize) return maxLength;
                }

                return tranfercount;
            }
            else
            {
                uint index = (destination);
                if((int)index >= 0)
                    rawData[index] = realByte;
                lastNormalByte = realByte;
                return 1;
            }
        }

        public abstract void DrawSprite(Bitmap newBitmap, int xPos, int yPos, bool bClearBG = true);
        protected abstract void SetSpriteSize();
        protected abstract void InitRawData();
        protected abstract void Process();
        protected abstract void Init();
        /*
        public Bitmap AsBitmap
        {
            get 
            {
                if (bUpdateBitmap)
                {
                    DrawSprite();
                    bUpdateBitmap = false;
                }
                return b; 
            }
        }
        */

        // remove later
        // used for debugging purposes

        public int GetPalCount()
        {
            return palletSet.Count;
        }

        public void SetPalletOffset(int newOffset)
        {
            palletOffset = newOffset;
        }

        public int Width
        {
            get { return spriteWidth; }
        }

        public int Height
        {
            get { return spriteHeight; }
        }
    }

    


}
