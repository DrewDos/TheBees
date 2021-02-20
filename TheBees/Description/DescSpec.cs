using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TheBees.GameRom;
using TheBees.UnitData;

namespace TheBees.Description
{
    public struct CategoryIndex
    {
        public ActionType type;
        public int index;

        public CategoryIndex(ActionType newType, int newIndex)
        {
            type = newType;
            index = newIndex;
        }

        public ActionType Type
        {
            get { return type; }
        }
        public int Index
        {
            get { return index; }
        }

    }
    class DescSpec
    {
        /*
        public static string[] UnitNamesFromAddresses = new string[]
        {
            "Yun", 
            "Dudley", 
            "Alex", 
            "Ibuki", 
            "Ryu", 
            "Gill", 
            "Hugo",
            "Oro", 
            "Necro", 
            "Elena", 
            "Yang", 
            "Ken",
            "Sean",     
            "Julian?",  
            "Gouki",    
            "Shin Gouki",
            "Chun-Li",  
            "Makoto",   
            "Q",        
            "Twelve",
            "Remy" 
        };
        */
        
        public static string[] UnitNamesFromRomIndex = new string[]
        {
            "Gill",
            "Alex",
            "Ryu",
            "Yun",
            "Dudley",
            "Necro",
            "Hugo",
            "Ibuki",
            "Elena",
            "Oro",
            "Yang",
            "Ken",
            "Sean",
            "Urien",
            "Akuma",
            "Shin Akuma",
            "Chun-Li",
            "Makoto",
            "Q",
            "Twelve",
            "Remy"
        };

        public static string MissileName = "Missiles";
        public static string BonusStageUnitName = "Car";

        public static string[] CategoryNames = new string[]
        {
            "Basic Operations",
            "Reactions 1",
            "Reactions 2",
            "Throws",
            "Reactions 3",
            "Attacks",
            "Specials",
            "Landing Behavior",
            "Subroutines",
            "Win/Loss/Judgment"
        };

        public static ActionType[] IndexedCategories = new ActionType[]
        {
            ActionType.NormalOperation,
            ActionType.ClientBehavior1,
            ActionType.ClientBehavior2,
            ActionType.Throws,
            ActionType.ClientBehavior3,
            ActionType.Tricks,
            ActionType.Mortals,
            ActionType.LandingBehavior,
            ActionType.SubroutineMortal,
            ActionType.VictoryPose,
        };

        
        public static string[] GetPropertyNames(int unitSel, ActionType type)
        {
            int count = UnitHandler.GetUnit(unitSel).GetActionGroup(type).Count;
            string [] output = new string[count];

            for(int i = 0; i < count; i++)
            {
                output[i] = i.ToString("X4");
            }

            return output;
        }

        //public static string[] GetMotionNames(int unitSel, int categorySel, int propertySel)
        //{
        //    int count = ((UnitAction)UnitHandler.GetCharacterUnit(unitSel).GetActionGroup(IndexedCategories[categorySel]).GetNodeGroup(propertySel)).MotionCount;
        //    string [] output = new string[count];

        //    for(int i = 0; i < count; i++)
        //    {
        //        output[i] = i.ToString();
        //    }

        //    return output;
        //}

        //public static string[] GetMissileNames()
        //{
        //    int count = UnitHandler.MissileUnit.GetActionGroup(ActionType.NormalOperation).Count;

        //    string[] output = new string[count];

        //    for (int i = 0; i < count; i++)
        //    {
        //        output[i] = i.ToString("X2");
        //    }

        //    return output;
        //}

        //public static string[] GetMissileConfigNames()
        //{
        //    int count = UnitSpec.MissileConfigCount;

        //    string[] output = new string[count];

        //    for (int i = 0; i < count; i++)
        //    {
        //        output[i] = i.ToString("X2");
        //    }

        //    return output;
        //}
        public static string[] GetNumberedList(int[] list)
        {
            string[] output = new string[list.Length];
            for (int i = 0; i < list.Length; i++)
            {
                output[i] = list[i].ToString("X2");
            }

            return output;
        }
        public static string[] GetIndexedList(NodeSequence nodeGroup)
        {
            string[] output = new string[nodeGroup.Count];

            for (int i = 0; i < nodeGroup.Count; i++)
            {
                output[i] = i.ToString("X4");
            }

            return output;
        }
        public static string[] GetIndexedList(int count, int startIndex = 0)
        {
            string[] output = new string[count-startIndex];

            for (int i = startIndex; i < count; i++)
            {
                output[i-startIndex] = i.ToString("X4");
            }

            return output;
        }

        public static string[] GetNodeGroupDescriptions(DataNode [] nodes, int [] indexes = null)
        {
            List<string> output = new List<string>();
            if (indexes == null)
            {
                for (int i = 0; i < nodes.Length; i++)
                {
                    output.Add(GetDataNodeName(nodes[i], i));
                }
            }
            else
            {
                for (int i = 0; i < nodes.Length; i++)
                {
                    output.Add(GetDataNodeName(nodes[i], indexes[i]));
                }
            }

            return output.ToArray();
        }

        public static string GetDataNodeName(DataNode node, int index)
        {
            return index.ToString("X2") + ": " + node.Description;
        }

        public static string[] GetButtonNames()
        {
            return Enum.GetNames(typeof(CharacterButton));
        }
       
    }
}
