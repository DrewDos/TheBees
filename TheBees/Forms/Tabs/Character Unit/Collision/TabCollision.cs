using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TheBees.GameRom;
using TheBees.UnitData;
using TheBees.Description;
using TheBees.Forms.Verification;
using TheBees.General;
using TheBees.Forms.Support.DataControl;

namespace TheBees.Forms
{
    public partial class TabCollision : NodeLayout
    {
        // property types for collision indexes only
        private Dictionary<string, PropertyType> types = new Dictionary<string, PropertyType>();
        private Dictionary<string, bool> availableTypes = new Dictionary<string, bool>();
        private Dictionary<string, RadioButton> radioMap = new Dictionary<string, RadioButton>();

        private string activeKey = null;

        static int clsnIndex;
        static int allClsnIndex;
        static int changedIndex = -1;

        private bool allowTypeChange = true;
        private int totalKeyCount = 6;
        private int activeKeyCount = 6;
        private string[] keys;

        public event Action<int> PrimaryIndexChanged;

        Dictionary<string, int> indexes = new Dictionary<string, int>();
        Dictionary<string, DataNode> allNodes = new Dictionary<string, DataNode>();
        VerifyManual vhs;

        static private CollisionLayout layout;

        private DataNode ActiveNode { get { return allNodes[activeKey]; } set { allNodes[activeKey] = value; } }

        public TabCollision(ActiveDataElement source)
            : base(source)
        {
            Init();

            toolsActiveCollision.SetControls(layout.Verification.ConfirmNoMessage, cbClsnIndex);
            toolsAllCollision.SetControls(Verification.ConfirmNoMessage, cbAllClsnIndex);

            
            toolsAllCollision.ComboChangedEvent += (x) => { OnAllCollisionIndexChange(cbAllClsnIndex, EventArgs.Empty); };
            toolsActiveCollision.ComboChangedEvent += (x) => { OnCollisionIndexChange(cbClsnIndex, EventArgs.Empty); };

        }

        private void Init()
        {
            keys = new string[]
            {
                "decision1",
                "decision2",
                "decision3",
                "atkRoll",
                "throwJgmt",
                "jgmtThrown"
            };

            PropertyType[] tempTypes = new PropertyType[] 
            { 
                PropertyType.Collision1, 
                PropertyType.Collision2, 
                PropertyType.Collision3, 
                PropertyType.AttackCollision, 
                PropertyType.ThrowCollision, 
                PropertyType.CollisionThrown 
            };

            RadioButton [] tempRadios = new RadioButton[]
            {
                rbCollision1,
                rbCollision2,
                rbCollision3,
                rbCollisionAttack,
                rbCollisionThrow,
                rbCollisionThrown,
            };


            for (int i = 0; i < totalKeyCount; i++)
            {
                string key = keys[i];
                // set property types
                types[key] = tempTypes[i];
                radioMap[key] = tempRadios[i];
                availableTypes[key] = false;
            }

            // setup layout
            layout = new CollisionLayout(activeData);
            this.Controls.Add(layout);
            layout.Location = new System.Drawing.Point(115, 30);
            layout.OnCollisionInputValueChanged = OnCollisionInputValueChanged;
            layout.OnUpdateCollisionNode = OnCollisionUpdate;
            ModifyAction.SpriteViewer.OnCollisionRectChangeDelegate = OnCollisionRectChange;


            vhs = new VerifyManual(keys);
            Verification.AddChild(vhs);

        }

        protected override void RegisterControls()
        {
            ControlSet.RegisterControl(cbAllClsnIndex, new Ref<uint>(() => { return (uint)changedIndex; }, (x) => changedIndex = (int)x), OnChangeAllCollision)
                .CaptureVerification = false;
        }

        protected override void OnPrimaryProceed()
        {
            allClsnIndex = changedIndex;

            UpdateAllCollisionSelect();
            if (PrimaryIndexChanged != null)
                PrimaryIndexChanged(allClsnIndex);

            base.OnPrimaryProceed();
        }

        protected override void OnPrimaryCancel()
        {
            cbAllClsnIndex.SelectedIndex = allClsnIndex;

            base.OnPrimaryCancel();
        }
        protected override void OnLoadNode()
        {
          
            cbAllClsnIndex.Enabled = true;
            LoadAllCollisionIndexes();

            if (unitChanged)
            {
                toolsAllCollision.SetPropertyGroup(activeData.Unit.GetPropertyGroup(PropertyType.AllCollision));
            }

            if (node != null)
            {
                cbAllClsnIndex.SelectedIndex = (int)((Motion)activeData.Data).AllCollisionIndex;
            }
            else
            {
                //cbAllClsnIndex.Text = "Invalid Value";
            }
            for (int i = 0; i < totalKeyCount; i++)
            {
                // set property types
                availableTypes[keys[i]] = false;
            }
            
            
            base.OnLoadNode();
        }

        //overridden populate controls
        // not actual controls, just values referencing a node
        public override void PopulateControls()
        {
            // get all indexes
            for (int i = 0; i < activeKeyCount; i++)
            {
                indexes[keys[i]] = (int)node.GetValue(keys[i]);
            }

            // then load all nodes
            LoadAllNodes();

            string startKey = "";

            for (int i = 0; i < activeKeyCount; i++)
            {
                string key = keys[i];
                if (availableTypes[key])
                {
                    radioMap[key].Enabled = true;

                    if (startKey == "")
                    {
                        startKey = key;
                    }
                }

                else
                {
                    radioMap[key].Checked = false;
                    radioMap[key].Enabled = false;
                }
            }


            radioMap[startKey].Checked = true;
            SelectCollisionType(startKey);
            activeKey = startKey;

            //layout.PopulateControls();

            DataNode[] nodes = new DataNode[totalKeyCount];
            for (int i = 0; i < totalKeyCount; i++)
            {
                nodes[i] = allNodes[keys[i]];
            }

            CollisionRelay.UpdateViewAll(nodes);
        }

        private void LoadCollisoinNode(string key)
        {
            if (activeData.Unit.GetPropertyGroup(types[key]).Count > 0)
            {
                DataNode nodeRetrieval = activeData.Unit.GetPropertyGroup(types[key]).GetNode(indexes[key]);

                //if (nodeRetrieval != null)
                //{
                //    allNodes[key] = nodeRetrieval.GetCopy();
                //}
                //else
                //{
                //    allNodes[key] = null;
                //}

                if (!allNodes.ContainsKey(key) || allNodes[key] != nodeRetrieval)
                {
                    if (allNodes.ContainsKey(key) && allNodes[key] != null)
                    {
                        allNodes[key].UnlockBuffer();
                        allNodes[key].ClearBuffer();
                    }

                    nodeRetrieval.BufferValues();
                    nodeRetrieval.LockBuffer();
                }

                allNodes[key] = nodeRetrieval;
                availableTypes[key] = true;
            }
            else
            {
                allNodes[key] = null;
                availableTypes[key] = false;
            }
        }

        private void LoadAllNodes()
        {
            for (int i = 0; i < totalKeyCount; i++)
            {
                LoadCollisoinNode(keys[i]);
            }
        }



        public override void UpdateNode()
        {
            for (int i = 0; i < activeKeyCount; i++)
            {
                node.SetValue(keys[i], (uint)indexes[keys[i]]);
                UpdateCollisionNode(keys[i]);
                node.ApplyBuffer();
            }

            vhs.Pending = false;

            //base.UpdateNode();
        }

        private void LoadCollisionIndexes()
        {
            if (!PreventCollisionIndexLoad)
            {
                cbClsnIndex.Items.Clear();
                cbClsnIndex.Items.AddRange(UnitDescription.GetPropertyGroupIndexes(activeData.Unit, types[activeKey]));
            }
            else
            {
                PreventCollisionIndexLoad = false;
            }
        }

        // load all of the all-collision indexes
        private void LoadAllCollisionIndexes()
        {
            if (unitChanged)
            {
                cbAllClsnIndex.Items.Clear();
                cbAllClsnIndex.Items.AddRange(UnitDescription.GetPropertyGroupIndexes(activeData.Unit, PropertyType.AllCollision));
            }
        }

        private void UpdateCollisionNode(string key)
        {
            allNodes[key].ApplyBuffer();

        }

        // when selecting the type from the radio button
        private void SelectCollisionType(string key)
        {
            if (allowTypeChange)
            {
                layout.PreventBufferRelease = true;
                activeKey = key;
                toolsActiveCollision.SetPropertyGroup(activeData.Unit.GetPropertyGroup(types[activeKey]));
                LoadCollisionIndexes();
                clsnIndex = indexes[activeKey];
                cbClsnIndex.SelectedIndex = clsnIndex;
                LoadActiveCollision();
                layout.PreventBufferRelease = false;
            }
        }

        private void UpdateChanges()
        {
            if (vhs.Pending)
            {
                UpdateNode();
                vhs.Pending = false;
            }
        }

        private void ResetCollisionVerifyFlags()
        {

            vhs.Pending = false;

        }

        private void LoadActiveCollision()
        {
            layout.LoadNode(ActiveNode);
        }

        private void OnCollisionIndexChange(object sender, EventArgs e)
        {
           
            bool res = layout.Verification.Confirm("Update changes?", "Update all changes?");

            if (res)
            {
                vhs.SetKey(activeKey, false);
                UpdateCollisionSelect();

                if (Settings.AutoUpdate)
                {
                    UpdateNode();
                }

            }
            else
            {
                cbClsnIndex.SelectedIndex = indexes[activeKey];
            }
        }

        protected override void OnChangeValue(DataControlEventParams p)
        {
            //vhs.SetKey(activeKey, true);
            base.OnChangeValue(p);
        }

        private void UpdateAll()
        {
            for (int i = 0; i < activeKeyCount; i++)
            {
                if (vhs.GetKey(keys[i]))
                {
                    UpdateCollisionNode(keys[i]);
                }
            }
        }

        private void OnAllCollisionIndexChange(object sender, EventArgs e)
        {
            Verification.Confirm("Update", "Update All Collision Index and nodes?");
        }


        private void OnChangeAllCollision(DataControlEventParams p)
        {
            Verification.Confirm("Update Attack", "Update attack index?");

        }

        // when the active collision type index changes
        private void UpdateCollisionSelect()
        {
            
            clsnIndex = cbClsnIndex.SelectedIndex;
            if (indexes[activeKey] != clsnIndex)
            {
                indexes[activeKey] = clsnIndex;
                Verification.Pending = true;
            }

            PropertyGroup group = activeData.Unit.GetPropertyGroup(types[activeKey]);
            DataNode nodeSelected = group.GetNode(clsnIndex);

            //if (nodeSelected != ActiveNode)
            //{
            //    if (ActiveNode != null)
            //    {
            //        ActiveNode.UnlockBuffer();
            //        ActiveNode.ClearBuffer();
            //    }

            ActiveNode = nodeSelected;
            //}

            //if (!ActiveNode.Buffered)
            //{
            //    ActiveNode.BufferValues();
            //    ActiveNode.LockBuffer();
            //}
            LoadActiveCollision();
            CollisionRelay.UpdateViewType(ActiveNode, activeKey);

        }

        private void UpdateAllCollisionSelect()
        {
            allClsnIndex = cbAllClsnIndex.SelectedIndex;
            PropertyGroup group = activeData.Unit.GetPropertyGroup(PropertyType.AllCollision);
            if (node != null && node.Buffered)
            {
                node.UnlockBuffer();
                node.ClearBuffer();
            }

            node = group.GetNode(allClsnIndex);

            node.BufferValues();
            node.LockBuffer();

            PopulateControls();
        }

        private void OnCollisionTypeChanged(object sender, EventArgs e)
        {
            if(((RadioButton)sender).Checked)
                SelectCollisionType((string)((RadioButton)sender).Tag);
        }

        private void OnCollisionInputValueChanged(int editIndex)
        {
            CollisionRelay.UpdateViewSingle(ActiveNode, activeKey, (editIndex / 4));

            vhs.SetKey(activeKey, true);
        }

        private void OnCollisionRawValueChange(int index)
        {
            vhs.SetKey(activeKey, true);
        }

        private void OnCollisionUpdate()
        {
            UpdateCollisionNode(activeKey);
        }

        private void OnCollisionRectChange(string type, int boxIndex)
        {

            short[] values = CollisionRelay.GetValuesFromViewerRect(type, boxIndex);

            string[] format = NodeSpec.GetCollisionKeysFromIndex(boxIndex);

            for (int i = 0; i < 4; i++)
            {
                allNodes[type].SetValue(format[i], (uint)(ushort)values[i]);
            }

            if (type == activeKey)
            {
                layout.PopulateBox(boxIndex);
            }

            vhs.SetKey(type, true);

        }

        public bool PreventCollisionIndexLoad { get; set; }
    }
}
