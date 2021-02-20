using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheBees.Description
{
    class DescriptionPack
    {
        public int Region;
        public int SubRegion;
        public int StringIndex;
        public string Description;

        public DescriptionPack(int region, int subRegion, int stringIndex, string description)
        {
            this.Region = region;
            this.SubRegion = subRegion;
            this.StringIndex = stringIndex;
            this.Description = description;
        }
    }

    static class DescriptionBody
    {
        static private Dictionary<int, Dictionary<int, Dictionary<int, string>>> allStrings = new Dictionary<int, Dictionary<int, Dictionary<int, string>>>();
        static private List<int[]> packIndexes = new List<int[]>();
        static private int currPackIndex;
        static private int packGetSize = -1;

        static public void Clear()
        {
            allStrings.Clear();
            packIndexes = new List<int[]>();
            packGetSize = -1;
        }

        static public void AddDescription(int region, int subRegion, int stringIndex, string description)
        {
            if(!allStrings.ContainsKey(region))
            {
                allStrings[region] = new Dictionary<int,Dictionary<int, string>>();
            }

            if(!allStrings[region].ContainsKey(subRegion))
            {
                allStrings[region][subRegion] = new Dictionary<int,string>();
            }
            
            allStrings[region][subRegion][stringIndex] = description;

        }

        static public void InitPackGet()
        {
            currPackIndex = -1;
            packIndexes = new List<int[]>();

            foreach(KeyValuePair<int, Dictionary<int, Dictionary<int, string>>> currRegion in allStrings)
            {
                foreach(KeyValuePair<int, Dictionary<int, string>> currSubRegion in currRegion.Value)
                {
                    foreach(KeyValuePair<int, string> currString in currSubRegion.Value)
                    {
                        packIndexes.Add(new int[]{ currRegion.Key, currSubRegion.Key, currString.Key});
                    }
                }
            }

            packGetSize = packIndexes.Count;
        }

        static public DescriptionPack GetNextPack()
        {
            currPackIndex += 1;
            if(packGetSize == packIndexes.Count)
            {

                if(packIndexes.Count > currPackIndex)
                {
                    return GetPack(packIndexes[currPackIndex]);
                }
            }
            else
            {
                throw new Exception("Pack get must be initialized");
            }

            return null;
        }

        static public DescriptionPack GetPack(int[] packIndexes)
        {
            string description = allStrings[packIndexes[0]][packIndexes[1]][packIndexes[2]];

            return new DescriptionPack(packIndexes[0], packIndexes[1], packIndexes[2], description);
        }

        static public string GetIndex(int region, int subRegion, int index, string format = "X2")
        {
            if (allStrings.ContainsKey(region) &&
                allStrings[region].ContainsKey(subRegion) &&
                allStrings[region][subRegion].ContainsKey(index))
            {
                return allStrings[region][subRegion][index];
            }
            else
            {
                return index.ToString(format);
            }
        }


        static public string[] GetIndexedList(int region, int subRegion, int count, string format = "X2")
        {
            Dictionary<int,string> sourceSubRegion;
            List<string> output = new List<string>();

            if(allStrings.ContainsKey(region) && allStrings[region].ContainsKey(subRegion))
            {
                sourceSubRegion = allStrings[region][subRegion];
            }
            else
            {
                sourceSubRegion = new Dictionary<int,string>();
            }

            for (int i = 0; i < count; i++)
            {
                if(sourceSubRegion.ContainsKey(i))
                {
                    output.Add(sourceSubRegion[i]);
                }
                else
                {
                    output.Add(i.ToString(format));
                }
            }

            return output.ToArray();
        }


    }
}
