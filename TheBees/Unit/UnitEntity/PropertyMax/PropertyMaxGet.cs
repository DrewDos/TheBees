using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TheBees.UnitData;
using TheBees.GameData;
using TheBees.GameRom;
using System.IO;

namespace TheBees
{
    public class PropertyMaxIndex
    {
        public PropertyType Base;
        public object Next;
        public NodeType BaseNodeType;
        public bool NextCharReqd;
        private Func<Unit, uint> GetNextAddress;

        public PropertyMaxIndex(PropertyType newBase, object newNext, NodeType newBaseNodeType, bool nextCharReqd = false)
        {
            Base = newBase;
            Next = newNext;
            BaseNodeType = newBaseNodeType;
            NextCharReqd = nextCharReqd;

            SetupGetNextAddressMethod();
        }


        private void SetupGetNextAddressMethod()
        {
            if (Next is PropertyType)
            {
                GetNextAddress = (x) => x.GetPropertyGroup((PropertyType)Next).DataAddress;
            }
            else if (Next is ActionType)
            {
                GetNextAddress = (x) => x.GetActionGroup((ActionType)Next).Address;
            }
        }

        public int GetCount(Unit baseChar, Unit nextChar)
        {
            Unit nextCharFinal = baseChar;

            if (NextCharReqd)
                nextCharFinal = nextChar;

            if (nextCharFinal != null)
            {
                try
                {
                    uint a = nextCharFinal.GetPropertyGroup(Base).DataAddress;
                    uint b = GetNextAddress(nextCharFinal);
                    return (int)((GetNextAddress(nextCharFinal) -
                         baseChar.GetPropertyGroup(Base).DataAddress) /
                        (uint)NodeSpec.SpecSizes[BaseNodeType]);
                }
                catch
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }
    }

    public static class PropertyMaxGet
    {
        public static List<PropertyMaxIndex> maxIndexes = GetMaxIndexes();

        public static void GetSummary()
        {
            List<string> lines = new List<string>();
            List<string> names = new List<string>();
            names.AddRange(Description.DescSpec.UnitNamesFromRomIndex);
            names.Add("Misisle");
  
            //public List<Dictionary<PropertyType, int>> MaxValues = new List<Dictionary<PropertyType, int>>()
            //{
            //    {
            //        new Dictionary<PropertyType, int>()
            //        {
            //            {PropertyType.Collision1, 12}
            //        }
            //    }
            //};
            lines.Add("public List<Dictionary<PropertyType, int>> MaxValues = new List<Dictionary<PropertyType, int>>()");
            lines.Add("{");
            for(int i = 0; i < UnitHandler.UnitSet.Count; i++)
            {
                Unit character = UnitHandler.UnitSet[i];
                Unit nextChar = UnitHandler.UnitSet.Count - 1 == i ? character : UnitHandler.UnitSet[i + 1];

                //if (!(character is UnitCharacter))
                //{
                //    continue;
                //}
                lines.Add("    // " + names[i]);
                lines.Add("    {");
                lines.Add("        new Dictionary<PropertyType, int>()");
                lines.Add("        {");


                for(int j = 0; j < maxIndexes.Count; j++)
                {
                    PropertyMaxIndex currIndex = maxIndexes[j];
                    string toAdd = "            { PropertyType." + currIndex.Base.ToString();
                    toAdd += ", 0x" + currIndex.GetCount(character, nextChar).ToString("X4");
                    toAdd += "}" + (maxIndexes.Count - 1 != j ? "," : "");
                    toAdd += " // " + character.PropertyLoader.GetMax(currIndex.Base).ToString("X4");
                    lines.Add(toAdd);
                }
                lines.Add("        }");
                lines.Add("    },");
                lines.Add("");
            }

            lines.Add("}");
            TextWriter w = File.CreateText(@"C:\maxgettest.txt");
            foreach (string line in lines)
            {
                w.WriteLine(line);
            }
            w.Close();
            

        }

        static public List<PropertyMaxIndex> GetMaxIndexes()
        {
            List<PropertyMaxIndex> output = new List<PropertyMaxIndex>();

            output.Add(new PropertyMaxIndex(PropertyType.TweakMotion, PropertyType.Acceleration, NodeType.TweakMotion));
            output.Add(new PropertyMaxIndex(PropertyType.Acceleration, PropertyType.EnemyCtrl, NodeType.Acceleration));
            output.Add(new PropertyMaxIndex(PropertyType.SupportGraphicsExt, PropertyType.SupportGraphics, NodeType.SupportGfxSpecExt));
            output.Add(new PropertyMaxIndex(PropertyType.SupportGraphics, PropertyType.ThrownOpponentSpec, NodeType.SupportGfxSpec));
            output.Add(new PropertyMaxIndex(PropertyType.ThrownOpponentSpec, ActionType.LandingBehavior, NodeType.ThrownOpponentSpec));
            output.Add(new PropertyMaxIndex(PropertyType.AllCollision, PropertyType.Collision1, NodeType.AllCollision));
            output.Add(new PropertyMaxIndex(PropertyType.Collision1, PropertyType.Collision2, NodeType.Collision16));
            output.Add(new PropertyMaxIndex(PropertyType.Collision2, PropertyType.Collision3, NodeType.Collision16));
            output.Add(new PropertyMaxIndex(PropertyType.Collision3, PropertyType.AllCollision, NodeType.Collision4, true));
            output.Add(new PropertyMaxIndex(PropertyType.ThrowCollision, PropertyType.CollisionThrown, NodeType.Collision4));
            output.Add(new PropertyMaxIndex(PropertyType.CollisionThrown, PropertyType.AttackCollision, NodeType.Collision4, true));
            output.Add(new PropertyMaxIndex(PropertyType.AttackCollision, PropertyType.CollisionThrown, NodeType.Collision16));
            output.Add(new PropertyMaxIndex(PropertyType.AttackDetails, PropertyType.SettingsFooterDamage, NodeType.AttackDetails));
            output.Add(new PropertyMaxIndex(PropertyType.EnemyCtrl, PropertyType.TweakMotion, NodeType.EnemyCtrl, true));

            return output;
        }
    }
}
