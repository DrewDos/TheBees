using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TheBees.GameRom;

namespace TheBees.Sprites
{

    public class SpriteRegion
    {
        private int start;
        private int end;
        private string tag;

        public int StartIndex { get { return start; } }
        public int LastIndex { get { return end; } }
        public string Tag { get { return tag; } }

        public SpriteRegion(int newStart, int newEnd, string newTag)
        {
            start = newStart;
            end = newEnd;
            tag = newTag;
        }

        public int[] GetIndexes()
        {
            List<int> indexes = new List<int>();

            for (int i = start; i <= end; i++)
            {
                indexes.Add(i);
            }

            return indexes.ToArray();
        }
        public int GetFirstUnusedIndex()
        {
            for (int i = start; i <= end; i++)
            {
                uint address = RomData.Get32((uint)(SpriteSpec.SpriteDefOffset + SpriteSpec.SpriteIndexSize * i + 4));

                if (address == 0x00000000)
                {
                    return i;
                }
            }

            return -1;
        }

        public int GetAvailIndexCount()
        {
            int count = 0;
            for (int i = start; i <= end; i++)
            {
                if (SpriteMap.GetSpriteAddress(i) == 0x00)
                    count += 1;
            }

            return count;
        }
    }
}
