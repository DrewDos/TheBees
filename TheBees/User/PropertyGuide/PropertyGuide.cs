using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using TheBees.UnitData;

namespace TheBees.User
{
    public class PropertyGuide : IUserMap
    {
        static public Dictionary<int, Dictionary<PropertyType, int>> MasterList;
        public int GuideIndex { get { return 0x00; } }

        public void Clear()
        {
            MasterList.Clear();
        }

        static public int GetValue(int index, PropertyType type)
        {
            if (!MasterList[index].ContainsKey(type))
            {
                return 0x00;
            }

            return MasterList[index][type];
        }

        static public void SetValue(int index, PropertyType type, int value)
        {
            MasterList[index][type] = value;
        }

        public void LoadBaseData()
        {
            MasterList = new Dictionary<int, Dictionary<PropertyType, int>>();

            for (int i = 0; i < UnitPropertyMax.MaxValues.Count; i++)
            {
                MasterList[i] = new Dictionary<PropertyType, int>();

                foreach (KeyValuePair<PropertyType, int> unitMaxes in UnitPropertyMax.MaxValues[i])
                {
                    MasterList[i][unitMaxes.Key] = unitMaxes.Value;
                }

            }
        }

        public void LoadData(BinaryReader r)
        {
            MasterList = new Dictionary<int, Dictionary<PropertyType, int>>();

            uint unitCount = r.ReadUInt32();

            for (int indexCtr = 0; indexCtr < unitCount; indexCtr++)
            {
                uint unitIndex = r.ReadUInt32();

                MasterList[(int)unitIndex] = new Dictionary<PropertyType, int>();

                uint propertyCount = r.ReadUInt32();

                for (int propertyCtr = 0; propertyCtr < propertyCount; propertyCtr++)
                {
                    uint propertyType = r.ReadUInt32();

                    MasterList[(int)unitIndex][(PropertyType)propertyType] = (int)r.ReadUInt32();
                }
            }
        }

        public void SaveData(BinaryWriter w)
        {
            w.Write((uint)MasterList.Count);

            foreach(KeyValuePair<int, Dictionary<PropertyType, int>> currList in MasterList)
            {
                w.Write((uint)currList.Key);
                w.Write((uint)currList.Value.Count);

                foreach (KeyValuePair<PropertyType, int> currProperty in currList.Value)
                {
                    w.Write((uint)currProperty.Key);
                    w.Write((uint)currProperty.Value);
                }
            }
        }
    }
}
