using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;


namespace SpriteTest.Graphics
{

    struct TileDef
    {
        uint realLength;
        uint realDestination;
        uint realSource;

        public TileDef(uint inLength, uint inOffset, uint inAddress)
        {
            realSource = ((inAddress << 1) - 0x400000);
            realDestination = (inOffset << 4);
            realLength = (((inLength << 1) + 2) << 3);
        }

        public uint RealSource { get { return realSource; } }
        public uint RealDestination { get { return realDestination; } }
        public uint RealLength { get { return realLength; } }
    }

    class TileGroupDef
    {
        byte byte0;
        byte tileStartOffset;
        byte byte3;
        byte flipHorizontal;
        byte flipVertical;
        short _xOffset;
        byte width;
        byte height;
        short _yOffset;

        public TileGroupDef(byte[] buf)
        {
            byte0 = buf[0];
            tileStartOffset = buf[1];

            flipVertical = (byte)((buf[2] & 0x08) >> 3);
            flipHorizontal = (byte)((buf[2] & 0x10) >> 4);


            byte3 = buf[3];
            width = (byte)((buf[6] >> 4) & 0x03);
            height = (byte)((buf[6] >> 6) & 0x03);

            width = width == (byte)3 ? (byte)4 : width;
            height = height == (byte)3 ? (byte)4 : height;

            xOffset = (short)(Helper.Rotate16((ushort)BitConverter.ToInt16(buf, 4)) & 0x0FFF);
            yOffset = (short)(Helper.Rotate16((ushort)BitConverter.ToInt16(buf, 6)) & 0x0FFF);
        }

        public byte TileStartOffset { get { return tileStartOffset; } }
        public short XOffset { get { return _xOffset; } }
        private short xOffset { set { _xOffset = FromSigned12(value); } }
        public byte Width { get { return width; } }
        public byte Height { get { return height; } }
        public short YOffset { get { return _yOffset; } }
        private short yOffset { set { _yOffset = FromSigned12(value); } }
        public byte FlipHorizontal { get { return flipHorizontal; } }
        public byte FlipVertical { get { return flipVertical; } }
        private short FromSigned12(short val)
        {
            ushort output = (ushort)val;

            if ((val & 0x0800) > 0)
            {
                output |= 0xF000;
            }

            return (short)output;

        }
    }

    unsafe class NormalSprite : Sprite
    {
        // sprite header
        ushort start;
        ushort tileCt;
        ushort tileGroupCt;
        ushort unknown;

        // sprite information
        private int baseXOffset;
        private int baseYOffset;

        private List<TileDef> tileList;
        private List<TileGroupDef> tileGroupList;

        Color[] pallet;

        public NormalSprite(byte[] newSpriteData, byte[] newRomData, List<Color[]> newPalletSet, int newXAxis = 0, int newYAxis = 0, int newStartOffset = 0) 
        : base(newSpriteData, newRomData, newPalletSet, newXAxis, newYAxis, newStartOffset)
        {
        }

        protected override void Init()
        {
            pallet = palletSet[0];
            tileList = new List<TileDef>();
            tileGroupList = new List<TileGroupDef>();

            start = Helper.Rotate16(BitConverter.ToUInt16(spriteData, 0));
            tileCt = Helper.Rotate16(BitConverter.ToUInt16(spriteData, 4));
            tileGroupCt = Helper.Rotate16(BitConverter.ToUInt16(spriteData, 6));
            lookupAddr = Helper.Rotate32(BitConverter.ToUInt32(spriteData, 8));
            unknown = Helper.Rotate16(BitConverter.ToUInt16(spriteData, 2));

            lookupAddr = (lookupAddr << 1) - 0x400000;

            int tileListBlock = 8, tileGroupListBlock = 8;
            int tileListStart = 0x0C;
            int tileGroupListStart = 0x0C + (tileCt * tileListBlock);

            for (int i = 0; i < tileCt; i++)
            {
                int dataOffset = tileListStart + (tileListBlock * i);

                tileList.Add(
                    new TileDef(
                            Helper.Rotate16(BitConverter.ToUInt16(spriteData, dataOffset + 4)),
                            Helper.Rotate16(BitConverter.ToUInt16(spriteData, dataOffset + 6)),
                            Helper.Rotate32(BitConverter.ToUInt32(spriteData, dataOffset))
                    )
                );
            }

            for (int i = 0; i < tileGroupCt; i++)
            {
                int dataOffset = tileGroupListStart + (tileGroupListBlock * i);
                byte[] tileGroupListBuf = new byte[8];

                for (int j = 0; j < 8; j++)
                {
                    tileGroupListBuf[j] = spriteData[dataOffset + j];
                }

                tileGroupList.Add(new TileGroupDef(tileGroupListBuf));

            }
        }

        /*
        private void LoadCustomData()
        {
            BinaryReader b = new BinaryReader(File.Open("C:\\SpriteTest.dat", FileMode.Open));
            testData = new byte[(int)b.BaseStream.Length];

            b.Read(testData, 0, (int)b.BaseStream.Length);
            b.Close();
        }
        */
        protected override void SetSpriteSize()
        {

            int len = tileGroupList.Count;
            int minX = 0xFFFF, minY = 0xFFFF,
                maxX = -0xFFFF, maxY = -0xFFFF;


            for (int i = 0; i < len; i++)
            {

                int halfW = ((tileGroupList[i].Width * 16) / 2);
                int currMinX = -halfW + tileGroupList[i].XOffset;
                int currMaxX = halfW + tileGroupList[i].XOffset;

                int halfH = ((tileGroupList[i].Height * 16) / 2);
                int currMinY = -halfH + tileGroupList[i].YOffset;
                int currMaxY = halfH + tileGroupList[i].YOffset;

                minX = currMinX < minX ? currMinX : minX;
                minY = currMinY < minY ? currMinY : minY;
                maxX = currMaxX > maxX ? currMaxX : maxX;
                maxY = currMaxY > maxX ? currMaxY : maxX;
            }

            spriteWidth = maxX - minX;
            spriteHeight = maxY - minY;
            baseXOffset = -minX;
            baseYOffset = -minY;
        }

        // drawing functions


        // tile drawing functions
        public override void DrawSprite(Bitmap newBitmap, int xPos, int yPos, bool bClearBG = true)
        {
            b = newBitmap;
            destBitmapW = b.Width;
            destBitmapH = b.Height;

            StartDrawSprite(bClearBG);

            foreach (TileGroupDef tg in tileGroupList)
            {
                DrawTileGroup(tg, xPos + xAxis, yPos + yAxis); // xAxis and yAxis have been removed from here
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

            for (int tileX = 0; tileX < xTileAmt; tileX++)
            {
                for (int tileY = 0; tileY < yTileAmt; tileY++)
                {


                    targetX = (tg.FlipHorizontal > 0) ? (xTileAmt - 1) - tileX : tileX;
                    targetY = (tg.FlipVertical > 0) ? (yTileAmt - 1) - tileY : tileY;

                    DrawTile(
                        tileOffset + (tileX * yTileAmt) + tileY, // tile index
                        (targetX * tileSize) + destX + xPos - xAxis, // x position in bitmap to draw
                        (targetY * tileSize) + destY + yPos - yAxis, // y position in bitmap to draw
                        0, // sprite index will always be 0 for normal sprites
                        tg.FlipHorizontal,
                        tg.FlipVertical
                        );
                }
            }
        }
        // processing chain

        protected override void InitRawData()
        {
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

            int len = tileList.Count;

            InitRawData();
            SetSpriteSize();

            for (int i = 0; i < len; i++)
            {

                DoCharDMA(tileList[i].RealSource, tileList[i].RealDestination, tileList[i].RealLength);
            }


        }


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

        public List<TileDef> TileSet
        {
            get { return tileList; }
        }
        public List<TileGroupDef> TileGroupSet
        {
            get { return tileGroupList; }
        }
    }




}
