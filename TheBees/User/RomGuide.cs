using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using TheBees.GameRom;
using TheBees.Records;

namespace TheBees.User
{
    static public class RomGuide
    {
        static private Dictionary<int, IUserMap> GuideMasterList;

        public static void Initialize()
        {
            // setup
            SaveHandler.OnSaveRom += () => { Save(Settings.GuideSource); };
            Recordable.OnInstantiateRecordable += (x) => x.SetTag(RecordTagGuide.GetRecordTag(x.Address));
            Recordable.SetTagEvent += (x) => RecordTagGuide.SetRecordTag(x.Address, x.Tag);

            // load all guides
            GuideMasterList = new Dictionary<int, IUserMap>();

            AddGuide(new PropertyGuide());
            AddGuide(new SpriteRegionGuide());
            AddGuide(new LookupTagGuide());
            AddGuide(new SpriteSessionGuide());
            AddGuide(new RecordGuide());
            AddGuide(new ActionGuide());
            AddGuide(new RecordTagGuide());

        }

        private static void AddGuide(IUserMap map)
        {
            if(GuideMasterList.ContainsKey(map.GuideIndex))
                throw new Exception("GuideIndex already set");

            GuideMasterList[map.GuideIndex] = map;
        }

        public static void Load(bool isBaseRom, string src)
        {
            if (isBaseRom)
            {
                foreach (KeyValuePair<int, IUserMap> guide in GuideMasterList)
                {
                    guide.Value.LoadBaseData();
                }
            }
            else
            {
                BinaryReader r = new BinaryReader(File.Open(src, FileMode.Open));
                byte[] checksum = r.ReadBytes(0x10);
                if (!checksum.SequenceEqual(RomData.Checksum))
                    throw new Exception("The file " + src + " does not match the checksum for this rom");

                uint count = r.ReadUInt32();

                for (int i = 0; i < count; i++)
                {
                    uint guideIndex = r.ReadUInt32();
                    GuideMasterList[(int)guideIndex].LoadData(r);
                }
            }
            
        }

        public static void Save(string dst)
        {
            BinaryWriter w = new BinaryWriter(File.Open(dst, FileMode.Create));

            w.Write(RomData.Checksum);
            w.Write((uint)GuideMasterList.Count);

            foreach (KeyValuePair<int, IUserMap> guide in GuideMasterList)
            {
                w.Write((uint)guide.Value.GuideIndex);
                guide.Value.SaveData(w);
            }

            w.Close();
        }

        public static void Clear()
        {
            foreach (KeyValuePair<int, IUserMap> guide in GuideMasterList)
            {
                guide.Value.Clear();
            }
        }
    }
}
