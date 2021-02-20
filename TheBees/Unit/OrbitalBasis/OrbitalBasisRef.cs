using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheBees.UnitData
{
    class OrbitalBasisRef
    {
        private int index;
        private uint address;
        private string description;

        public int Index { get { return index; } }
        public uint Address { get { return address; } }
        public string Description { set { description = value; } get { return description; } }

        public OrbitalBasisRef(int newIndex, uint newAddress, string newDescription)
        {
            index = newIndex;
            address = newAddress;
            description = newDescription;
        }


    }
}
