using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using TheBees.Sprites;

namespace TheBees.User
{
    public class SpriteRegionGuide : IUserMap
    {
        public int GuideIndex { get { return 0x01; } }
        static public List<SpriteRegion> SpriteRegions = new List<SpriteRegion>();

        public void Clear()
        {
            SpriteRegions.Clear();
        }
        public void LoadBaseData()
        {
            SpriteRegions = GetBaseSpriteRegions();
        }

        public void LoadData(BinaryReader r)
        {
            SpriteRegions = new List<SpriteRegion>();

            uint count = r.ReadUInt32();

            for (int i = 0; i < count; i++)
            {
                SpriteRegions.Add(new SpriteRegion((int)r.ReadUInt32(), (int)r.ReadUInt32(), r.ReadString()));
            }
        }

        public void SaveData(BinaryWriter w)
        {
            w.Write((uint)SpriteRegions.Count);

            for (int i = 0; i < SpriteRegions.Count; i++)
            {
                w.Write((uint)SpriteRegions[i].StartIndex);
                w.Write((uint)SpriteRegions[i].LastIndex);
                w.Write(SpriteRegions[i].Tag);
            }
        }

        static public string[] GetRegionNames()
        {
            List<string> output = new List<string>();
            SpriteRegions.ForEach((x) => output.Add(x.Tag));
            return output.ToArray();
        }

        static public SpriteRegion CreateSpriteRegion(int startIndex, int lastIndex, string tag)
        {
            SpriteRegion region = new SpriteRegion(startIndex, lastIndex, tag);
            SpriteRegions.Add(region);
            return region;
        }

        static public bool RegionExistsByTag(string tag)
        {
            return SpriteRegions.ToList().Find((x) => x.Tag == tag) != null;
        }

        static public List<SpriteRegion> GetBaseSpriteRegions()
        {
            return new List<SpriteRegion>()
            {
                new SpriteRegion(0x00000001, 0x000005FF, "Gill"),
                new SpriteRegion(0x00000600, 0x00000BFF, "Alex"),
                new SpriteRegion(0x00000C00, 0x000011FF, "Ryu"),
                new SpriteRegion(0x00001200, 0x000017FF, "Yun"),
                new SpriteRegion(0x00001800, 0x00001DFF, "Dudley"),
                new SpriteRegion(0x00001E00, 0x000023FF, "Necro"),
                new SpriteRegion(0x00002400, 0x000029FF, "Hugo"),
                new SpriteRegion(0x00002A00, 0x00002FFF, "Ibuki"),
                new SpriteRegion(0x00003000, 0x000035FF, "Elena"),
                new SpriteRegion(0x00003600, 0x00003BFF, "Oro"),
                new SpriteRegion(0x00003C00, 0x000041FF, "Yang"),
                new SpriteRegion(0x00004200, 0x000047FF, "Ken"),
                new SpriteRegion(0x00004800, 0x00004DFF, "Sean"),
                new SpriteRegion(0x00004E00, 0x000053FF, "Urien"),
                new SpriteRegion(0x00005400, 0x000059FF, "Akuma"),
                new SpriteRegion(0x00005A00, 0x00005FFF, "Chun-Li"),
                new SpriteRegion(0x00006000, 0x000065FF, "Makoto"),
                new SpriteRegion(0x00006600, 0x00006BFF, "Q"),
                new SpriteRegion(0x00006C00, 0x000071FF, "Twelve"),
                new SpriteRegion(0x00007200, 0x000077FF, "Remy"),
            };
        }
    }
}
