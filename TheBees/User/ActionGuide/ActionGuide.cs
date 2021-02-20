using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using TheBees.UnitData;

namespace TheBees.User
{
    public class ActionGuide : IUserMap
    {
        public int GuideIndex { get { return 0x06; } }

        static public Dictionary<uint, int> ActionLengths = new Dictionary<uint, int>();
        static public Dictionary<uint, List<int>> ForceMotionIndexes = new Dictionary<uint, List<int>>();
        static public Dictionary<uint, bool> StaticFunctionSizes = new Dictionary<uint, bool>();

        static private ActionIndexRef[] BaseForceMotionIndexes = new ActionIndexRef[]
        {
            new ActionIndexRef(0x062F2018, 2),
            new ActionIndexRef(0x063161C4, 2),
            new ActionIndexRef(0x063A8A04, 1),
            new ActionIndexRef(0x063A4954, 2)
        };

        static public int GetActionLength(uint address)
        {
            if (ActionLengths.ContainsKey(address))
                return ActionLengths[address];

            return -1;
        }

        static public void SetActionLength(uint address, int length)
        {
            ActionLengths[address] = length;
        }

        static public void ClearActionLength(uint address)
        {
            if (ActionLengths.ContainsKey(address)) ActionLengths.Remove(address);
        }

        static public void SetForceMotion(uint address, int index)
        {
            if (!ForceMotionIndexes.ContainsKey(address))
                ForceMotionIndexes[address] = new List<int>();

            ForceMotionIndexes[address].Add(index);
        }

        static public void SetForceMotionRange(uint address, List<int> indexes)
        {
            if (!ForceMotionIndexes.ContainsKey(address))
            {
                ForceMotionIndexes[address] = indexes;
            }
            else
            {
                ForceMotionIndexes[address].Clear();
                ForceMotionIndexes[address].AddRange(indexes);

            }
        }

        static public void ClearForceMotion(uint address)
        {
            if (ForceMotionIndexes.ContainsKey(address)) ForceMotionIndexes.Remove(address);
        }

        static public List<int> GetTreatAsMotionIndex(uint address)
        {
            if (ForceMotionIndexes.ContainsKey(address))
                return ForceMotionIndexes[address];

            return null;
        }

        ////////////////////////////////////////
        // main methods
        ////////////////////////////////////////

        public void LoadBaseTreatAsMotions()
        {
            ForceMotionIndexes.Clear();
            Array.ForEach(BaseForceMotionIndexes, (x) => { ForceMotionIndexes[x.ActionAddress] = new List<int>(); ForceMotionIndexes[x.ActionAddress].Add(x.DataIndex); });

        }

        private void LoadBaseActionLengths()
        {
            ActionLengths.Clear();
            Array.ForEach(BaseActionLengths.ActionLengths, (x) => ActionLengths[x.ActionAddress] = x.Length);
        }

        public void Clear()
        {
            ActionLengths.Clear();
            ForceMotionIndexes.Clear();
        }

        public void LoadBaseData()
        {
            LoadBaseTreatAsMotions();
            LoadBaseActionLengths();
        }

        public void SaveData(BinaryWriter w)
        {
            w.Write((uint)ActionLengths.Count);

            foreach (KeyValuePair<uint, int> actionLength in ActionLengths)
            {
                w.Write(actionLength.Key);
                w.Write(actionLength.Value);
            }

            w.Write((uint)ForceMotionIndexes.Count);


            foreach (KeyValuePair<uint, List<int>> forceMotionIndex in ForceMotionIndexes)
            {
                w.Write(forceMotionIndex.Key);
                w.Write((uint)forceMotionIndex.Value.Count);

                for (int i = 0; i < forceMotionIndex.Value.Count; i++)
                {
                    w.Write(forceMotionIndex.Value[i]);
                }
            }
        }

        public void LoadData(BinaryReader r)
        {
            // load lookup tags
            ActionLengths.Clear();
            ForceMotionIndexes.Clear();

            uint lengthCount = r.ReadUInt32();

            for (int i = 0; i < lengthCount; i++)
            {
                uint key = r.ReadUInt32();
                int value = r.ReadInt32();
                ActionLengths[key] = value;
            }

            uint forceMotionCount = r.ReadUInt32();

            for (int i = 0; i < forceMotionCount; i++)
            {
                uint key = r.ReadUInt32();
                uint indexCount = r.ReadUInt32();

                ForceMotionIndexes[key] = new List<int>();
                for (int indexCtr = 0; indexCtr < indexCount; indexCtr++)
                {
                    int value = r.ReadInt32();
                    ForceMotionIndexes[key].Add(value);
                }
            }
        }
    }
}
