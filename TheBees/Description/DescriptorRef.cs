using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheBees.Description
{
    struct DescriptorRef
    {
        private string tag;
        private string description;

        public string Tag { get { return tag; } }
        public string Description { get { return description; } }

        public DescriptorRef(string newTag, string newDescription)
        {
            tag = newTag;
            description = newDescription;
        }
    }
}
