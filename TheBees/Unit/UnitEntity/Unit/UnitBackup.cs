
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Diagnostics;
//using System.IO;

//namespace TheBees.UnitData
//{
//    public abstract class Unit
//    {
//        private Dictionary<PropertyType, PropertyGroup> propertyGroups;
//        private Dictionary<ActionType, ActionGroup> actionGroups;

//        protected uint address;
//        protected List<uint> addresses;
//        protected uint index;

//        abstract protected void InitGroups();
//        abstract protected void GetMaxAccel();

//        protected uint maxAllClsn = 0;
//        protected uint maxAttackDef = 0;
//        protected int maxAccel = 0;

//        protected uint[] maxClsn;
//        private bool findMaxValues = false;

//        // collision value research
//        static Dictionary<PropertyType, List<int>> clsnAddresses = new Dictionary<PropertyType, List<int>>();

//        protected string[] usableIndexes = new string[] { "decision1", "decision2", "decision3", "throwJgmt", "jgmtThrown", "atkRoll" };

//        // for diagnostic purposes
//        static private bool timeFileStart = true;
//        static private Stopwatch sw = null;
//        static private StreamWriter timeFile = null;
//        private const string timeFileDest = @"timefile.txt";

//        // for diagnostic on max values
//        static private List<List<uint>> currMaxAddresses = new List<List<uint>>();
//        static private int currMaxAddCount = 0;

//        static private void SaveMaxText()
//        {
//            StreamWriter w = new StreamWriter(File.Open(@"c:\max.txt", FileMode.Create));

//            NodeType[] types = new NodeType[]
//            {
//                NodeType.AllCollision,
//                NodeType.Collision16,
//                NodeType.Collision16,
//                NodeType.Collision4,
//                NodeType.Collision4,
//                NodeType.Collision4, 
//                NodeType.Collision16
//            };

//            for (int i = 0; i < 21; i++)
//            {
//                List<uint> original = new List<uint>();
//                original.AddRange(currMaxAddresses[i].ToArray());

//                currMaxAddresses[i].Sort();

//                for (int j = 1; j < currMaxAddresses[i].Count; j++)
//                {
//                    int typeIndex = original.IndexOf(currMaxAddresses[i][j - 1]);
//                    w.WriteLine(((currMaxAddresses[i][j] - currMaxAddresses[i][j - 1]) / NodeSpec.GetSpecSize(types[typeIndex])).ToString("X8"));
//                }

//                w.WriteLine();
//            }

//            w.Close();
//        }

//        public Unit(uint address, uint index, uint[] maxClsn = null, uint maxAllClsn = 0, uint maxAttackDef = 0)
//        {
//            this.address = address;
//            this.index = index;
//            propertyGroups = new Dictionary<PropertyType, PropertyGroup>();
//            actionGroups = new Dictionary<ActionType, ActionGroup>();

//            if (maxClsn == null || maxAllClsn == 0 || maxAttackDef == 0)
//            {
//                findMaxValues = true;
//            }
//            else
//            {
//                this.maxClsn = maxClsn;
//                this.maxAllClsn = maxAllClsn;
//                this.maxAttackDef = maxAttackDef;
//            }

//            // get the addresses of each 
//            Init();

//            AddMaxAddress();
//        }

//        protected virtual void Init()
//        {
//            InitGroups();
//        }


//        protected virtual void LoadProperties()
//        {
//            /*

//            for (int i = 0; i < usableIndexes.Length; i++)
//            {
//                uint type1 = addresses[(int)PropertyType.Collision1 + (i + 1)];
//                uint type2 = addresses[(int)PropertyType.Collision1 + i];
//                uint nodesize = NodeSpec.GetSpecSize(types[i]);

//                uint maxClsn = (addresses[(int)PropertyType.Collision1 + (i + 1)] - addresses[(int)PropertyType.Collision1 + i]) / NodeSpec.GetSpecSize(types[i]);
//                AddProperty(PropertyType.Collision1 + i, types[i], (int)maxClsn);
//            }
//            */

//            // load each collision type based off of their max values
//            if (findMaxValues)
//            {
//                GetMaxAttackClsnDefValues();
//                LoadAttackClsn();
//                GetMaxClsnValues();
//            }
//            else
//            {
//                LoadAttackClsn();
//            }

//            LoadClsn();

//            UpdateGuideData();
//        }

//        public ActionGroup GetActionGroup(ActionType type)
//        {
//            return actionGroups[type];
//        }
//        public PropertyGroup GetPropertyGroup(PropertyType type)
//        {
//            return propertyGroups[type];
//        }

//        protected void AddAction(ActionType type)
//        {
//            actionGroups.Add(type, new ActionGroup(addresses[(int)type], type));
//        }

//        protected void AddProperty(PropertyType propertyType, NodeType nodeType, int count)
//        {
//            propertyGroups.Add(propertyType, new PropertyGroup(addresses[(int)propertyType], count, nodeType));
//        }

//        protected void GetMaxAttackClsnDefValues()
//        {
//            // get max attack and collision defs from each motion
//            List<uint> maxes = new List<uint>();

//            foreach (ActionGroup group in actionGroups.Values)
//            {
//                int actionIndex = 0;

//                foreach (UnitAction action in group.Actions)
//                {
//                    int count = action.MotionCount;


//                    for (int i = 0; i < count; i++)
//                    {
//                        Motion node = action.GetMotion(i);
//                        NodeType type = node.GetNodeType();

//                        if (type == NodeType.Motion16 || type == NodeType.Motion24)
//                        {

//                            if (node.AllCollisionIndex > maxAllClsn)
//                            {
//                                maxAllClsn = node.AllCollisionIndex;
//                            }

//                            if (node.AttackIndex > maxAttackDef)
//                            {
//                                maxAttackDef = node.AttackIndex;

//                            }
//                        }
//                    }

//                    actionIndex += 1;
//                }
//            }


//        }

//        protected void LoadAttackClsn()
//        {

//            // load the first two property sets so we can get the rest
//            //AddProperty(PropertyType.AllCollision, NodeType.AllCollision, (int)(addresses[(int)PropertyType.AllCollision + 1] - addresses[(int)PropertyType.AllCollision]));
//            AddProperty(PropertyType.AllCollision, NodeType.AllCollision, (int)maxAllClsn);
//            AddProperty(PropertyType.AttackDetails, NodeType.AttackDetails, (int)maxAttackDef);
//        }

//        protected void GetMaxClsnValues()
//        {

//            // get all collision properties
//            PropertyGroup pGroup = GetPropertyGroup(PropertyType.AllCollision);
//            maxClsn = new uint[usableIndexes.Length];
//            Array.Clear(maxClsn, 0, maxClsn.Length);

//            // now, get the max definitions for each collision type
//            for (int i = 0; i < maxAllClsn; i++)
//            {
//                DataNode node = pGroup.GetNode(i);

//                for (int j = 0; j < usableIndexes.Length; j++)
//                {
//                    uint value = node.GetValue(usableIndexes[j]);

//                    if (value > maxClsn[j])
//                    {
//                        // we're going to assume that anything over 0x1000 (which is forgiving in itself) has some kind of special indexing
//                        if (value < 0x1000)
//                        {
//                            maxClsn[j] = value;
//                        }
//                    }

//                }

//            }


//        }

//        protected virtual void LoadClsn()
//        {


//            AddProperty(PropertyType.Collision1, NodeType.Collision16, (int)maxClsn[0] + 1);
//            AddProperty(PropertyType.Collision2, NodeType.Collision16, (int)maxClsn[1] + 1);
//            AddProperty(PropertyType.Collision3, NodeType.Collision4, (int)maxClsn[2] + 1);
//            AddProperty(PropertyType.ThrowCollision, NodeType.Collision4, (int)maxClsn[3] + 1);
//            AddProperty(PropertyType.CollisionThrown, NodeType.Collision4, (int)maxClsn[4] + 1);
//            AddProperty(PropertyType.AttackCollision, NodeType.Collision16, (int)maxClsn[5] + 1);

//        }

//        private void UpdateGuideData()
//        {
//            if (Settings.GetGuideData)
//            {

//                RomGuide.SetValue(GuideKey.AllCollision, maxAllClsn);
//                RomGuide.SetValue(GuideKey.AttackDef, maxAttackDef);
//                RomGuide.SetValue(GuideKey.Collision1, maxClsn[0] + 1);
//                RomGuide.SetValue(GuideKey.Collision2, maxClsn[1] + 1);
//                RomGuide.SetValue(GuideKey.Collision3, maxClsn[2] + 1);
//                RomGuide.SetValue(GuideKey.ThrowCollision, maxClsn[3] + 1);
//                RomGuide.SetValue(GuideKey.CollisionThrown, maxClsn[4] + 1);
//                RomGuide.SetValue(GuideKey.AttackCollision, maxClsn[5] + 1);
//            }
//        }

//        // for diagnostic purposes
//        protected void StartTimer()
//        {
//            if (timeFileStart)
//            {
//                if (File.Exists(timeFileDest))
//                {
//                    File.Delete(timeFileDest);
//                }

//                sw = new Stopwatch();

//                timeFileStart = false;
//            }


//            sw.Start();
//        }

//        protected void EndTimer(string initialMsg)
//        {
//            sw.Stop();

//            timeFile = new StreamWriter(File.Open(timeFileDest, FileMode.Append));

//            timeFile.WriteLine(initialMsg + "{0}", sw.Elapsed);
//            timeFile.WriteLine();
//            sw.Reset();
//            timeFile.Close();

//        }

//        protected void AddMaxAddress()
//        {
//            currMaxAddresses.Add(new List<uint>());

//            currMaxAddresses[currMaxAddCount].Add(addresses[(int)PropertyType.AllCollision]);
//            currMaxAddresses[currMaxAddCount].Add(addresses[(int)PropertyType.Collision1]);
//            currMaxAddresses[currMaxAddCount].Add(addresses[(int)PropertyType.Collision2]);
//            currMaxAddresses[currMaxAddCount].Add(addresses[(int)PropertyType.ThrowCollision]);
//            currMaxAddresses[currMaxAddCount].Add(addresses[(int)PropertyType.CollisionThrown]);
//            currMaxAddresses[currMaxAddCount].Add(addresses[(int)PropertyType.AttackCollision]);
//            currMaxAddresses[currMaxAddCount].Add(addresses[(int)PropertyType.Collision3]);
//            currMaxAddresses[currMaxAddCount].Add(addresses[(int)PropertyType.AttackDetails]);

//            currMaxAddCount += 1;

//            if (currMaxAddCount == 21)
//            {
//                SaveMaxText();
//            }
//        }
//    }
//}

