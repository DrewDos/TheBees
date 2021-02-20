using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TheBees.User
{
    public class RecordTagGuide : IUserMap
    {
        static public bool AutoSave = true;
        static public RecordTagGuide mainGuide;

        public int GuideIndex { get { return 0x07; } }
        static public Dictionary<uint, string> RecordTags;
        static private string FileName = @"recordtag.dat";

        static public void SetRecordTag(uint address, string newTag)
        {
            RecordTags[address] = newTag;

            // for debugging purposes
            mainGuide.SaveData(null);
        }
        static public string GetRecordTag(uint address)
        {
            if (RecordTags.ContainsKey(address))
                return RecordTags[address];
            
            return "";
        }

        static public void ClearTag(uint address)
        {
            RecordTags.Remove(address);
        }

        public void LoadBaseData()
        {
            try
            {
                LoadData(null);

            }
            catch
            {
            }

            // for debugging purposes
            mainGuide = this;
        }

        public void SaveData(BinaryWriter unused)
        {
            BinaryWriter w = new BinaryWriter(File.Open(FileName, FileMode.Create));

            w.Write((uint)RecordTags.Count);

            foreach (KeyValuePair<uint, string> tag in RecordTags)
            {
                w.Write(tag.Key);
                w.Write(tag.Value);
            }

            w.Close();
        }

        public void LoadData(BinaryReader unused)
        {

            // for debugging purposes
            mainGuide = this;

            RecordTags = new Dictionary<uint, string>();

            BinaryReader r = new BinaryReader(File.Open(FileName, FileMode.Open));


            uint count = r.ReadUInt32();

            for (int i = 0; i < count; i++)
            {
                uint address = r.ReadUInt32();
                string tag = r.ReadString();
                RecordTags[address] = tag;
            }

            r.Close();
        }

        public void Clear()
        {
            RecordTags.Clear();
        }
    }
}
