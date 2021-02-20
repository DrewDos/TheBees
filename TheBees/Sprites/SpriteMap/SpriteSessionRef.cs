using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheBees.Sprites
{
    public class SpriteSessionRef
    {
        private string name;
        public string Name { get { return name; }}

        private List<int> indexes = new List<int>();
        public int[] Indexes { get { return indexes.ToArray(); } }
        public SpriteSessionRef(string newName)
        {
            name = newName;
        }

        public void AddIndex(int newIndex)
        {
            indexes.Add(newIndex);
        }

        public void AddRange(int[] range)
        {
            indexes.AddRange(range);
        }

        public void RemoveAtPosition(int pos)
        {
            indexes.RemoveAt(pos);
        }
    }
}
