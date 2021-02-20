using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TheBees.GameRom;
using TheBees.User;

namespace TheBees.UnitData
{
    public abstract class PropertyLoader
    {
        public delegate void OnCallLoadGroupDelegate(PropertyType propertyType, GameRom.NodeType nodeType);
        protected Dictionary<PropertyType, int> maxValues;
        protected int index;
        protected Unit unit;

        public OnCallLoadGroupDelegate CallLoadGroup = null;
        private Action GetMaxFromMotion, GetMaxSupportGfx, GetMaxClsnValues, GetMaxEnemyCtrls;
        public Dictionary<PropertyType, int> MaxValues { get { return maxValues; } }
       // abstract protected void LoadPropertyGroups();

        public PropertyLoader(Unit sourceUnit)
        {
            maxValues = new Dictionary<PropertyType, int>();
            unit = sourceUnit;
            index = unit.Index;
        }


        public void LoadFromGuide()
        {
            GetMaxFromMotion = GetMaxFromGuide;

            GetMaxSupportGfx = () => { };
            GetMaxClsnValues = () => { };
            GetMaxEnemyCtrls = () => { };

            LoadPropertyGroups();
        }

        public void LoadFromData()
        {
            /*
            GetMaxFromMotion = OnGetMaxFromMotion;
            GetMaxSupportGfx = OnGetMaxGfx;
            GetMaxClsnValues = OnGetMaxClsnValues;
            GetMaxEnemyCtrls = OnGetMaxEnemyCtrls;
            */

            GetMaxFromMotion = GetMaxFromPropertyMax;
            GetMaxSupportGfx = () => { };
            GetMaxClsnValues = () => { };
            GetMaxEnemyCtrls = () => { };
            LoadPropertyGroups();
        }

        public void OnCallLoadGroup(PropertyType propertyType, GameRom.NodeType nodeType)
        {
            if (CallLoadGroup != null)
                CallLoadGroup(propertyType, nodeType);
        }

        public void GetMaxFromUnit()
        {
  
        }

        private void GetMaxFromGuide()
        {
            int start = Enum.GetValues(typeof(PropertyType)).Cast<int>().Min();
            int end = (int)PropertyType.None;

            for (int i = start; i <= end; i++)
            {
                SetMax((PropertyType)i, PropertyGuide.GetValue(index, (PropertyType)i));
            }

            //SetMax(PropertyType.AllCollision, RomGuide.GetValue(index, (int)PropertyType.AllCollision));
            //SetMax(PropertyType.AttackDetails, RomGuide.GetValue(index, (int)PropertyType.AttackDetails));
        }

        public virtual void LoadPropertyGroups()
        {
            GetMaxFromMotion();
            CallLoadGroup(PropertyType.AllCollision, GameRom.NodeType.AllCollision);
            CallLoadGroup(PropertyType.AttackDetails, GameRom.NodeType.AttackDetails);
            CallLoadGroup(PropertyType.TweakMotion, GameRom.NodeType.TweakMotion);
            CallLoadGroup(PropertyType.ThrownOpponentSpec, GameRom.NodeType.ThrownOpponentSpec);

            GetMaxSupportGfx();
            CallLoadGroup(PropertyType.SupportGraphics, GameRom.NodeType.SupportGfxSpec);
            CallLoadGroup(PropertyType.SupportGraphicsExt, GameRom.NodeType.SupportGfxSpecExt);

            GetMaxClsnValues();
            CallLoadGroup(PropertyType.Collision1, GameRom.NodeType.Collision16);
            CallLoadGroup(PropertyType.Collision2, GameRom.NodeType.Collision16);
            CallLoadGroup(PropertyType.Collision3, GameRom.NodeType.Collision4);
            CallLoadGroup(PropertyType.ThrowCollision, GameRom.NodeType.Collision4);
            CallLoadGroup(PropertyType.CollisionThrown, GameRom.NodeType.Collision4);
            CallLoadGroup(PropertyType.AttackCollision, GameRom.NodeType.Collision16);

            //GetMaxEnemyCtrls();
            //CallLoadGroup(PropertyType.SettingsFooterDamage, GameRom.NodeType.EnemyCtrl);
        }

        public void GetMaxFromPropertyMax()
        {
            int start = Enum.GetValues(typeof(PropertyType)).Cast<int>().Min();
            int end = (int)PropertyType.None;
            for (int i = start; i < end; i++)
            {
                PropertyType getType = (PropertyType)i;
                if (UnitPropertyMax.MaxValues[unit.Index].ContainsKey(getType))
                {
                    SetMax((PropertyType)i, UnitPropertyMax.MaxValues[index][getType]);
                }
            }
        }
        public void OnGetMaxEnemyCtrls()
        {
            int maxEnemyCtrls = 0;
            for(int i = 0; i < unit.PropertyGroups[PropertyType.AttackDetails].Count; i++)
            {
                DataNode node = unit.PropertyGroups[PropertyType.AttackDetails].GetNode(i);

                int currMax = (int)node.GetValue("andCtrlEnemy");

                if (currMax > maxEnemyCtrls)
                    maxEnemyCtrls = currMax;
            }

            SetMax(PropertyType.EnemyCtrl, maxEnemyCtrls);
        }

        public void OnGetMaxFromMotion()
        {// get max attack and collision defs from each motion

            //int maxAllClsn = 0;
            //int maxAttackDef = 0;
            //int maxTweakMotion = 0;
            //int maxOpSpec = 0;

            //int value = 0;

            //List<int> valueList = new List<int>();

            //foreach (ActionGroup group in unit.ActionGroups.Values)
            //{
            //    int actionIndex = 0;
                
            //    foreach (UnitAction action in group.Actions)
            //    {
            //        int count = action.MotionCount;


            //        for (int i = 0; i < count; i++)
            //        {
            //            Motion node = action.GetMotion(i);
            //            GameRom.NodeType type = node.GetNodeType();



            //            if (type == GameRom.NodeType.Motion16 || type == GameRom.NodeType.Motion24)
            //            {

            //                if (node.AttackIndex > maxAttackDef)
            //                {
            //                    maxAttackDef = (int)node.AttackIndex;

            //                }

            //                value = (int)((Motion)node).TweakMotion;

            //                if (value > maxTweakMotion)
            //                {
            //                    maxTweakMotion = value;

            //                }

            //                if (type == GameRom.NodeType.Motion24)
            //                {
            //                    value = (int)((Motion)node).ThrownOpponentIndex;

            //                    if (value > maxOpSpec)
            //                    {
            //                        if (value < 0xFF)
            //                            maxOpSpec = value;

            //                    }
            //                }
            //            }
            //        }

            //        actionIndex += 1;
            //    }
            //}


            //maxAllClsn = (int)(
            //    (
            //    unit.GetAddress(PropertyType.Collision1) - 
            //    unit.GetAddress(PropertyType.AllCollision)
            //    )/GameRom.NodeSpec.SpecSizes[GameRom.NodeType.AllCollision]
            //);

            //SetMax(PropertyType.AllCollision, maxAllClsn);
            //SetMax(PropertyType.AttackDetails, maxAttackDef);
            //SetMax(PropertyType.TweakMotion, maxTweakMotion);
            //SetMax(PropertyType.ThrownOpponentSpec, maxOpSpec*24);

        }

        protected void OnGetMaxGfx()
        {

            SetMax(PropertyType.SupportGraphicsExt, (int)(unit.GetAddress(PropertyType.SupportGraphics) - unit.GetAddress(PropertyType.SupportGraphicsExt)) / 8);
            SetMax(PropertyType.SupportGraphics, (int)(unit.GetAddress(PropertyType.ThrownOpponentSpec) - unit.GetAddress(PropertyType.SupportGraphics)) / 8);
        }
        protected void OnGetMaxClsnValues()
        {

            // get all collision properties
            string[] usableIndexes = new string[] { "decision1", "decision2", "throwJgmt", "jgmtThrown", "atkRoll" , "decision3" };
            PropertyGroup pGroup = unit.GetPropertyGroup(PropertyType.AllCollision);
            int[] maxClsn = new int[usableIndexes.Length];
            int maxAllClsn = (int)GetMax(PropertyType.AllCollision);
            Array.Clear(maxClsn, 0, maxClsn.Length);

            // now, get the max definitions for each collision type
            for (int i = 0; i < maxAllClsn; i++)
            {
                GameRom.DataNode node = pGroup.GetNode(i);

                for (int j = 0; j < usableIndexes.Length; j++)
                {
                    uint value = node.GetValue(usableIndexes[j]);

                    if (value > maxClsn[j])
                    {
                        // we're going to assume that anything over 0x1000 (which is forgiving in itself) has some kind of special indexing
                        if (value < 0x1000)
                        {
                            maxClsn[j] = (int)value;
                        }
                    }

                }

            }

            for (int i = 0; i < usableIndexes.Length; i++)
            {
                SetMax((PropertyType)i + (int)PropertyType.Collision1, maxClsn[i] + 1);
            }
        }

        public void UpdateGuideData()
        {
        }

        public int GetMax(PropertyType type)
        {
            return PropertyGuide.GetValue(index, type);
        }

        public void SetMax(PropertyType type, int amount)
        {
            PropertyGuide.SetValue(index, type, amount);
        }

        public void UpdateMax(PropertyType type)
        {
            PropertyGuide.SetValue(index, type, unit.GetPropertyGroup(type).Count);
        }
    }
}
