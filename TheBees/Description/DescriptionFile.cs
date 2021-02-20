using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TheBees.Description
{
    // unit
    // action type
    // action
    
    // unit
    // property type
    // property index
    

    static class DescriptionFile
    {
        static public bool Load(string source)
        {
            if (!File.Exists(source))
                return false;

            BinaryReader r = new BinaryReader(File.Open(source, FileMode.Open));

            while (r.BaseStream.Position != r.BaseStream.Length)
            {
                int region = r.ReadInt32();
                int subRegion = r.ReadInt32();
                int stringIndex = r.ReadInt32();
                string description = r.ReadString();

                DescriptionBody.AddDescription(region, subRegion, stringIndex, description);
            }

            r.Close();
            return true;
        }

        static public bool Save(string destination)
        {
            BinaryWriter w = new BinaryWriter(File.Open(destination, FileMode.Create));

            DescriptionBody.InitPackGet();

            DescriptionPack currPack = DescriptionBody.GetNextPack();

            while(currPack != null)
            {
                w.Write(currPack.Region);
                w.Write(currPack.SubRegion);
                w.Write(currPack.StringIndex);
                w.Write(currPack.Description);

                currPack = DescriptionBody.GetNextPack();
            }

            w.Close();

            return true;
        }
    }
}
