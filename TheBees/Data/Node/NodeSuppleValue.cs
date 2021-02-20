using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheBees.GameRom
{
    public class NodeSuppleValue : SuppleValue
    {
        private string key;
        public string Key { get { return key; } }

        public NodeSuppleValue(uint newAddress, int newValueSize, string newKey, NodeValueRange parent)
            :base(newAddress, newValueSize, parent)
        {
            key = newKey;
        }
    }
}
