using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using TheBees.Sprites;

namespace TheBees.User
{
    public class SpriteSessionGuide : IUserMap
    {
        static public List<SpriteSessionRef> CreationReferences = new List<SpriteSessionRef>();
        public int GuideIndex { get { return 0x03; } }

        static public bool CheckCreationRefExists(string name)
        {
            return CreationReferences.Find((x) => x.Name == name) != null;
        }

        public void Clear()
        {
            CreationReferences.Clear();
        }

        static public string[] GetSessionNames()
        {
            List<string> output = new List<string>();

            foreach (SpriteSessionRef session in CreationReferences)
            {
                output.Add(session.Name);
            }

            return output.ToArray();
        }
        static public void RemoveSessionRef(int index)
        {
            CreationReferences.RemoveAt(index);

        }
        static public SpriteSessionRef MakeCreationReference(string name)
        {
            SpriteSessionRef reference = new SpriteSessionRef(name);
            CreationReferences.Add(reference);
            return reference;
        }

        public void LoadBaseData()
        {
            CreationReferences = new List<SpriteSessionRef>();
        }

        public void LoadData(BinaryReader r)
        {
            uint count = r.ReadUInt32();
            CreationReferences = new List<SpriteSessionRef>();

            for (int i = 0; i < count; i++)
            {
                SpriteSessionRef newRef = new SpriteSessionRef(r.ReadString());
                uint indexCount = r.ReadUInt32();
                for (int j = 0; j < indexCount; j++)
                {
                    newRef.AddIndex(r.ReadInt32());
                }

                CreationReferences.Add(newRef);
            }
        }

        public void SaveData(BinaryWriter w)
        {
            w.Write((uint)CreationReferences.Count);

            for (int i = 0; i < CreationReferences.Count; i++)
            {
                SpriteSessionRef reference = CreationReferences[i];

                w.Write(CreationReferences[i].Name);
                w.Write((uint)reference.Indexes.Length);

                for (int j = 0; j < reference.Indexes.Length; j++)
                {
                    w.Write((int)reference.Indexes[j]);
                }

            }
        }
    }
}
