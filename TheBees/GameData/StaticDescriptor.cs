using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using TheBees.Description;

namespace TheBees.GameData
{
    static class StaticDescriptor
    {
        static private Dictionary<uint, DescriptorRef> descriptors = new Dictionary<uint, DescriptorRef>();

        static public bool LoadDescriptors(string source)
        {
            if (!File.Exists(source))
                return false;

            descriptors.Clear();
            BinaryReader r = new BinaryReader(File.Open(source, FileMode.Open));

            while (r.BaseStream.Position != r.BaseStream.Length)
            {
                uint address = r.ReadUInt32();
                string tag = r.ReadString();
                string description = r.ReadString();

                SetDescriptor(address, tag, description);
            }

            r.Close();
            return true;
        
        }

        static public bool SaveDescriptors(string target)
        {
            if (descriptors.Count == 0)
                throw new Exception("No descriptors to save");

            BinaryWriter w = new BinaryWriter(File.Open(target, FileMode.Create));

            foreach(KeyValuePair<uint, DescriptorRef> descRef in descriptors)
            {
                w.Write(descRef.Key);
                w.Write(descRef.Value.Tag);
                w.Write(descRef.Value.Description);

            }

            w.Close();

            return true;

        }

        static public void SetDescriptor(uint address, string tag, string description)
        {
            if (!descriptors.ContainsKey(address))
            {
                descriptors[address] = new DescriptorRef(tag, description);
            }
            else
            {
                // do nothing for now

                // throw new ArgumentException("Key already exists");
            }
        }

        static public void ClearDescriptorByTag(string tag)
        {
            descriptors = descriptors.Where(x => x.Value.Tag != tag).ToDictionary(pair => pair.Key, pair => pair.Value);
        }

        static public Dictionary<uint, DescriptorRef> GetDescriptorsByTag(string tag)
        {
            return descriptors.Where(kvp => kvp.Value.Tag == tag).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        }
    }
}
