using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheBees.Sprites
{
    public class LookupTag
    {
        private uint address;
        private string tag;

        public uint Address { get { return address; } }
        public string Tag { get { return tag; } }

        public LookupTag(uint newAddress, string newTag)
        {
            address = newAddress;
            tag = newTag;
        }
    }
}
