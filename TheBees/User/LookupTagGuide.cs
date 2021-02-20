using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using TheBees.Sprites;
using TheBees.Data;

namespace TheBees.User
{
    public class LookupTagGuide : IUserMap
    {
        public int GuideIndex { get { return 0x02; } }

        static public List<LookupTag> LookupTags = new List<LookupTag>();
        static private Dictionary<uint, LookupTag> KeyedLookupTags = new Dictionary<uint,LookupTag>();

        public void Clear()
        {
            LookupTags.Clear();
            KeyedLookupTags.Clear();
        }

        static public List<LookupTag> GetBaseLookupTags()
        {
            return new List<LookupTag>()
            {
                new LookupTag(0x01460000, "Gill"),
                new LookupTag(0x025A0000, "Alex"),
                new LookupTag(0x01000000, "Ryu"),
                new LookupTag(0x00AB8000, "Yun"),
                new LookupTag(0x01800000, "Dudley"),
                new LookupTag(0x01BB0000, "Necro"),
                new LookupTag(0x00800000, "Hugo"),
                new LookupTag(0x02800000, "Ibuki"),
                new LookupTag(0x029D0000, "Elena"),
                new LookupTag(0x02420000, "Oro"),
                new LookupTag(0x00AB8000, "Yang"),
                new LookupTag(0x01000000, "Ken"),
                new LookupTag(0x01000000, "Sean"),
                new LookupTag(0x01460000, "Urien"),
                new LookupTag(0x01000000, "Akuma"),
                new LookupTag(0x01E01000, "Chun-Li"),
                new LookupTag(0x019B0000, "Makoto"),
                new LookupTag(0x02000000, "Q"),
                new LookupTag(0x00D38000, "Twelve"),
                new LookupTag(0x022C0000, "Remy")
            };
        }

        static public LookupTag CreateLookupTag(uint address, string tag)
        {
            LookupTag newTag = new LookupTag(address, tag);

            if (KeyedLookupTags.ContainsKey(address))
                throw new Exception("Tag already occupied for this address");

            KeyedLookupTags[address] = newTag;

            return newTag;
        }

        static public void SetBaseLookupTags()
        {
            LookupTags = GetBaseLookupTags();
            KeyedLookupTags = new Dictionary<uint, LookupTag>();

            foreach (LookupTag tag in LookupTags)
            {
                KeyedLookupTags[tag.Address] = tag;
            }
        }

        static public List<LookupTag> GetAllLookupTags()
        {
            List<LookupTag> newList = new List<LookupTag>();

            foreach (RomDataBlock table in RomDataBlock.MasterList.Values)
            {
                LookupTag newTag;

                if (KeyedLookupTags.ContainsKey(table.Address))
                {
                    newTag = KeyedLookupTags[table.Address];
                }
                else
                {
                    newTag = new LookupTag(table.Address, table.Address.ToString("X8"));
                }
                newList.Add(newTag);
            }

            return newList;
        }

        public void LoadBaseData()
        {
            SetBaseLookupTags();
        }

        public void SaveData(BinaryWriter w)
        {
            w.Write((uint)LookupTags.Count);

            foreach (LookupTag tag in LookupTags)
            {
                w.Write(tag.Address);
                w.Write(tag.Tag);
            }
        }

        public void LoadData(BinaryReader r)
        {
            // load lookup tags
            uint count = r.ReadUInt32();

            List<LookupTag> tags = new List<LookupTag>();

            for (int i = 0; i < count; i++)
            {
                tags.Add(new LookupTag(r.ReadUInt32(), r.ReadString()));
            }

            LookupTags = tags;
        }
    }
}
