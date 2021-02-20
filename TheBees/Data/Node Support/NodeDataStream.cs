using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace TheBees.GameRom
{
    public delegate void OnUpdateNodeDelegate(uint address, DataNode node);
    public delegate void OnUpdateNodeComplete();

    public static class NodeDataStream
    {
        static private Dictionary<uint, NodeValueRange> keyedNodes = new Dictionary<uint, NodeValueRange>();
        static public string DestinationDir = "";

        static public void OnNodeUpdate(NodeValueRange node)
        {
            if (!keyedNodes.ContainsKey(node.Address))
            {
                keyedNodes[node.Address] = node;
            }
        }

        static public void SaveData()
        {
            string addressFileDest = DestinationDir + "address.dat";
            string dataFileDest = DestinationDir + "datafile.dat";

            uint currDestination = 0;
            uint currDataDestination = 0;
            BinaryWriter addrFile = new BinaryWriter(File.Open(addressFileDest, FileMode.Create));
            BinaryWriter dataFile = new BinaryWriter(File.Open(dataFileDest, FileMode.Create));
            // save the address file

            foreach (KeyValuePair<uint, NodeValueRange> node in keyedNodes)
            {
                int size = node.Value.SizeInBytes;
                addrFile.Write(currDataDestination);
                addrFile.Write(node.Value.Address);
                addrFile.Write((uint)size);


                for (int i = 0; i < size; i++)
                {
                    dataFile.Write(RomData.Get8(node.Value.Address, i));
                }

                currDataDestination += (uint)size;

                currDestination += sizeof(uint)*3;
            }


            // save the data
            addrFile.Close();
            dataFile.Close();

        }

    }
}
