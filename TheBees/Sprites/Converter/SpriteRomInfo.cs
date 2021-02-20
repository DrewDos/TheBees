using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpriteCreator
{
    class SpriteRomInfo
    {
        private int groupCount = 0;

        private TileGroup[] groups;
        public TileGroup[] Groups { get { return groups; } }

        private int width;
        private int height;

        public int Width { get { return width; } }
        public int Height { get { return height; } }

        public SpriteRomInfo(TileGroup[] sourceGroups, int spriteWidth, int spriteHeight)
        {
            groupCount = sourceGroups.Length;
            groups = sourceGroups;

            width = spriteWidth;
            height = spriteHeight;
        }

        public byte[] GetLookupTable()
        {
            return null;
        }

        public int GetTileDataSize()
        {
            int size = 0;
            Array.ForEach(groups, (x) => size += x.DataBlock.RawData.Length);
            return size;
        }

        public int GetSpriteDataSize()
        {
            return 0x0C + groupCount * 2 * 8;
        }

        public byte[][] GetTileDataBlocks()
        {
            byte[][] dataGroups = new byte[groupCount][];

            for (int i = 0; i < groupCount; i++)
            {
                dataGroups[i] = new byte[groups[i].DataBlock.RawData.Length];
                Buffer.BlockCopy(groups[i].DataBlock.RawData, 0, dataGroups[i], 0, groups[i].DataBlock.RawData.Length);
            }

            return dataGroups;
        }

        public byte[] GetTileData()
        {
            List<byte> tileData = new List<byte>();

            for (int i = 0; i < groupCount; i++)
            {
                
                tileData.AddRange(groups[i].DataBlock.RawData);
            }

            return tileData.ToArray();

        }
        unsafe public byte[] GetSpriteData(uint lookupOffset, uint [] tileDataOffsets)
        {

            byte[] spriteData = new byte[groupCount * 8 * 2 + 0x0C];

            fixed (byte* bytes = spriteData)
            {
                ushort* ushortPtr = (ushort*)bytes;
                uint* uintPtr = (uint*)bytes;

                ushortPtr[0] = Helper.Rotate16(0x8000); // start
                ushortPtr[1] = Helper.Rotate16(0x0056); // unknown
                ushortPtr[2] = Helper.Rotate16((ushort)groupCount);
                ushortPtr[3] = Helper.Rotate16((ushort)groupCount);
                uintPtr = (uint*)&ushortPtr[4];
                uintPtr[0] = Helper.Rotate32((lookupOffset + 0x400000) >> 1);

                int destination = 0;
                int tileInBytes = 16 * 16;

                for (int i = 0; i < groupCount; i++)
                {
                    TileGroup group = groups[i];

                    // write the tile set def
                    int tileSetIndex = 0x0C + (i * 8);
                    uintPtr = (uint*)&bytes[tileSetIndex];

                    uintPtr[0] = Helper.Rotate32((tileDataOffsets[i] + 0x400000) >> 1);//dataAddresses[i];
                    ushortPtr = (ushort*)&bytes[tileSetIndex + 0x04];

                    int size = (group.Width * group.Height * tileInBytes);

                    ushortPtr[0] = Helper.Rotate16((ushort)(((size >> 3) - 2) >> 1));
                    ushortPtr[1] = Helper.Rotate16((ushort)(destination >> 4));


                    // write the tile group def
                    int tileGroupIndex = 0x0C + (8 * groupCount + i * 8);

                    int xOffset = group.Rects[0].X + (16 * group.Width / 2);
                    int yOffset = group.Rects[0].Y + (16 * group.Height / 2);
                    int targetWidth = group.Width == 4 ? 3 : group.Width;
                    int targetHeight = group.Height == 4 ? 3 : group.Height;

                    bytes[tileGroupIndex] = 0;
                    bytes[tileGroupIndex + 1] = (byte)(destination / tileInBytes * 2);
                    bytes[tileGroupIndex + 2] = 2; // flip horizontal / flip vertical // its always set to 2? 
                    bytes[tileGroupIndex + 3] = 0; // ?
                    ushortPtr = (ushort*)&bytes[tileGroupIndex + 4];
                    ushortPtr[0] = Helper.Rotate16((ushort)xOffset);
                    //bytes[tileGroupIndex + 5] = 0; // ?
                    bytes[tileGroupIndex + 6] = (byte)((targetHeight << 6) | (targetWidth << 4));
                    ushortPtr = (ushort*)&bytes[tileGroupIndex + 6];
                    ushortPtr[0] = (ushort)(ushortPtr[0] | Helper.Rotate16((ushort)yOffset));
                    //bytes[tileGroupIndex + 7] = 0; // ?

                    destination += size;
                    //tileDataOffset += (uint)group.DataBlock.RawData.Length;
                }

            }

            return spriteData;
        }
    }
}
