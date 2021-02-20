using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;

namespace SpriteTest.Graphics
{
    static class SpriteHandler
    {
        static private byte[] spriteRomData;
        static private byte[] tileData;
        static private bool bLoaded = false;

        static public void LoadRomData()
        {
            if (!bLoaded)
            {
                BinaryReader sd1 = new BinaryReader(File.Open("c:\\10d", FileMode.Open));
                BinaryReader sd2 = new BinaryReader(File.Open("c:\\20d", FileMode.Open));

                BinaryReader f30 = new BinaryReader(File.Open("C:\\30", FileMode.Open));
                BinaryReader f31 = new BinaryReader(File.Open("C:\\31", FileMode.Open));
                BinaryReader f40 = new BinaryReader(File.Open("C:\\40", FileMode.Open));
                BinaryReader f41 = new BinaryReader(File.Open("C:\\41", FileMode.Open));
                BinaryReader f50 = new BinaryReader(File.Open("C:\\50", FileMode.Open));
                BinaryReader f51 = new BinaryReader(File.Open("C:\\51", FileMode.Open));
                BinaryReader f60 = new BinaryReader(File.Open("C:\\60", FileMode.Open));
                BinaryReader f61 = new BinaryReader(File.Open("C:\\61", FileMode.Open));

                spriteRomData = new byte[0x1000000];
                tileData = new byte[0x800000 * 8];

                sd1.Read(spriteRomData, 0, 0x800000);
                sd2.Read(spriteRomData, 0x800000, 0x800000);

                f30.Read(tileData, 0x800000 * 0, 0x800000);
                f31.Read(tileData, 0x800000 * 1, 0x800000);
                f40.Read(tileData, 0x800000 * 2, 0x800000);
                f41.Read(tileData, 0x800000 * 3, 0x800000);
                f50.Read(tileData, 0x800000 * 4, 0x800000);
                f51.Read(tileData, 0x800000 * 5, 0x800000);
                f60.Read(tileData, 0x800000 * 6, 0x800000);
                f61.Read(tileData, 0x800000 * 7, 0x800000);

                sd1.Close();
                sd2.Close();

                f30.Close();
                f31.Close();
                f40.Close();
                f41.Close();
                f50.Close();
                f51.Close();
                f60.Close();
                f61.Close();
                bLoaded = true;
            }
        }
        /*
        static public Sprite FromFile(String spriteSource, string romSource, Color[] pallet, Bitmap b)
        {
            BinaryReader f = new BinaryReader(File.Open(spriteSource, FileMode.Open));
            BinaryReader d = new BinaryReader(File.Open(romSource, FileMode.Open));

            byte[] spriteDest = new byte[(int)f.BaseStream.Length];
            byte[] romDest = new byte[(int)d.BaseStream.Length];
            f.Read(spriteDest, 0, (int)f.BaseStream.Length);
            d.Read(romDest, 0, (int)d.BaseStream.Length);
            return new Sprite(spriteDest, romDest, pallet, b, 0, 0, 0);
        }
        */
        static public void DrawMultipleSprites(Bitmap b, List<Sprite> sprites, int xPos, int yPos)
        {
            int count = sprites.Count;

            for (int i = 0; i < count; i++)
            {
                sprites[i].DrawSprite(b, xPos, yPos, false);
            }
        }

        static public Sprite GetLargeSprite(int index)
        {
            
            int stageDefOffet = 0x19D038;
            int tileDefOffset = 0x19CBB4;
            int palletDefOffset = 0x1B4754;
            //int palletRedirectOffsetDark = 0x19DDD4;
            int palletRedirectOffset = 0x19DE02;
            ushort palletRedirect = Helper.Rotate16(BitConverter.ToUInt16(spriteRomData, (index * 2) + palletRedirectOffset));

            palletRedirect = (ushort)((((int)palletRedirect << 1) + palletRedirect) << 2);

            uint stageDefIndex = Helper.Rotate32(BitConverter.ToUInt32(spriteRomData, (index * 4) + stageDefOffet)) - 0x6000000;
            uint tileDefIndex = (uint)((index * 16) + tileDefOffset);
            uint palletDefIndex = Helper.Rotate32(BitConverter.ToUInt32(spriteRomData, palletDefOffset + palletRedirect)) - 0x400000;

            int length = 0x4400;
            byte[] buf = new byte[length + 16];
            Array.Copy(spriteRomData, tileDefIndex, buf, 0, 16);
            Array.Copy(spriteRomData, stageDefIndex, buf, 16, length);

            List<Color[]> col = Pallet.GetRangeFromBuffer(tileData, (int)palletDefIndex, (int)(palletDefIndex + (0x80 * 100)));
            return new LargeSprite(buf, tileData, col, 0, 0);
        }

        static public List<Sprite> GetSpritesFromRange(int start, int length)
        {
            int max = start + length;
            List<Sprite> spriteList = new List<Sprite>();

            for (int i = start; i < max; i++)
            {
                spriteList.Add(GetNormalSprite(i));
            }

            return spriteList;
        }

        static public List<Sprite> GetLargeFromRange(int start, int length)
        {
            int max = start + length;
            List<Sprite> spriteList = new List<Sprite>();

            for (int i = start; i < max; i++)
            {
                spriteList.Add(GetLargeSprite(i));
            }

            return spriteList;
        }

        static public List<Sprite> GetSpritesFromIndexes(int[] indexes)
        {

            int count = indexes.Length;
            List<Sprite> spriteList = new List<Sprite>();

            for (int i = 0; i < count; i++)
            {
                spriteList.Add(GetNormalSprite(indexes[i]));
            }

            return spriteList;


        }

        static public Sprite GetNormalSprite(int index)
        {
            int spriteDefOffset = index * 0x08 + 0x800000;
            uint realAddress = Helper.Rotate32(BitConverter.ToUInt32(spriteRomData, spriteDefOffset + 4)) - 0x06000000;

            short xAxis = (short)Helper.Rotate16((ushort)BitConverter.ToInt16(spriteRomData, spriteDefOffset));
            short yAxis = (short)Helper.Rotate16((ushort)BitConverter.ToInt16(spriteRomData, spriteDefOffset + 2));

            int size = Helper.Rotate16(BitConverter.ToUInt16(spriteRomData, (int)realAddress + 4)) * 8 +
                    Helper.Rotate16(BitConverter.ToUInt16(spriteRomData, (int)realAddress + 6)) * 8 + 0x0C;
            byte[] buf = new byte[size];
            Array.Copy(spriteRomData, realAddress, buf, 0, size);

            List<Color[]> col = new List<Color[]>();
            col.Add(Pallet.FromBuffer(tileData, 0x700300 + 0x2800000));

            return new NormalSprite(buf, tileData, col, xAxis, yAxis);
        }

    }
}
