using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheBees.GameRom
{
    class PalletIndexSet
    {
        Dictionary<int, int> redirectFromRaw = new Dictionary<int, int>();
        Dictionary<int, uint> offsetFromIndex = new Dictionary<int, uint>();
        public PalletIndexSet(DataNode[] palletNodes)
        {
            List<int> redirectList = new List<int>();

            // pass 1
            foreach (DataNode node in palletNodes)
            {
                int palletCount = (int)node.GetValue("size") / 0x80;
                int destination = (int)node.GetValue("destination") / 0x80;

                for (int i = 0; i < palletCount; i++)
                {
                    redirectList.Add(destination + i);
                }
            }

            redirectList.Sort();
            for (int i = 0; i < redirectList.Count; i++)
            {
                redirectFromRaw[redirectList[i]] = i;
            }

            // pass 2
            foreach (DataNode node in palletNodes)
            {
                uint address = node.GetValue("offset");
                int size = (int)node.GetValue("size");

                if (size > 0 && size % 0x80 != 0)
                {
                    throw new ArgumentException("size other than 0x80 not yet implemented");
                }

                int palletCount =  size / 0x80;
                int destination = (int)node.GetValue("destination") / 0x80;

                for (int i = 0; i < palletCount; i++)
                {
                    offsetFromIndex[redirectFromRaw[destination + i]] = address + (uint)(0x80 * i);  
                }
            }
        }

        public uint GetAddressFromIndex(int index)
        {
            if(offsetFromIndex.ContainsKey(index))
            {
                return offsetFromIndex[index];
            }

            return 0;
        }

        //public uint GetAddressFromRaw(int rawIndex)
        //{
        //    if (redirectFromRaw.ContainsKey(rawIndex))
        //    {
        //        return offsetFromIndex[redirectFromRaw[rawIndex]];
        //    }

        //    return 0;
        //}

        public int Count { get { return offsetFromIndex.Count; } }
        
    }
}
