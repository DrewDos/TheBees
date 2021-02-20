using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TheBees.GameRom;
using TheBees.UnitData;
using TheBees.Forms.Verification;
using TheBees.Forms.Support.DataControl;

using System.Windows.Forms;

namespace TheBees.Forms
{
    public enum ActionDataOption
    {
        Base,
        Collision,
        Attack,
        None
    }

    public enum ActionDataTabs
    {

        Motion,
        FunctionCall,
        Attack,
        Collision,
        Header,
        NoData,
        None
    }

    public class DataPanel
    {
        public delegate void OnTabSelectCompleteDelegate(RawNodeType rawType);
        public delegate void OnLoadTabDelegate(NodeLayout tab);

        public event Action<ActionDataTabs> TabActivateEvent;
        public event Action<ActionDataTabs> TabDeactivateEvent;

        protected ActiveDataElement activeData;
        protected ActionDataOption activeOption = ActionDataOption.None;
        protected Dictionary<ActionDataTabs, NodeLayout> tabs;
        protected ActionDataTabs activeTab = ActionDataTabs.None;
        private List<ActionDataTabs> allActiveTabs = new List<ActionDataTabs>();

        protected RawNodeType activeRawNodeType;
        protected bool loadPropertyIndexes = true;
        protected int lastUnitOnMotionUpdate = -1;
        protected NodeType activeNodeType;
        private bool stopDataOptionUpdate = false;

        public FunctionCallPanel TabFunctionCall { get { return tabFunctionCall; } }
        public TabAttackDetails TabAttackDetails { get { return tabAttackDetails; } }
        public TabActionHeader TabHeader { get { return tabHeader; } }
        public TabMotion TabMotion { get { return tabMotion; } }
        public TabCollision TabCollision { get { return tabCollision; } }

        private FunctionCallPanel tabFunctionCall;
        private TabAttackDetails tabAttackDetails;
        private TabActionHeader tabHeader;
        private TabMotion tabMotion;
        private TabCollision tabCollision;

        private DataNode attackNode;
        private DataNode collisionNode;

        private RadioButton rbBase;
        private RadioButton rbAttackProperties;
        private RadioButton rbCollisionProperties;
        private Panel panelNoData;

        private UnitSelector selector;

        public OnTabSelectCompleteDelegate TabSelectComplete = null;
        public General.BasicDelegate UpdateAll = null;
        public OnLoadTabDelegate LoadTabCallback = null;

        public Dictionary<ActionDataTabs, NodeLayout> Tabs { get { return tabs; } }
        public ActionDataTabs ActiveTab { get { return activeTab; } }
        public DataNode AttackNode { get { return attackNode; } }
        public DataNode CollisionNode { get { return collisionNode; } }

        public event DataControlObserver ValueChangedEvent;

        private VerifyHandler verifyHandler;
        public VerifyHandler Verification
        {
            get
            {
                return verifyHandler;
            }
            set
            {
                verifyHandler = value;
            }
        }

        public DataPanel(UnitSelector selectorSource, RadioButton rbBaseSource, RadioButton rbAttackSource, RadioButton rbCollisionSource, Panel sourcePanelNoData)
        {
            activeData = selectorSource.ActiveData;
            this.panelNoData = sourcePanelNoData;
            rbBase = rbBaseSource;
            rbAttackProperties = rbAttackSource;
            rbCollisionProperties = rbCollisionSource;

            rbBase.CheckedChanged += OnCheckBase;
            rbAttackProperties.CheckedChanged += OnCheckAttackProperties;
            rbCollisionProperties.CheckedChanged += OnCheckCollisionProperties;

            selector = selectorSource;

            tabs = new Dictionary<ActionDataTabs, NodeLayout>();
            verifyHandler = new VerifyHandler();
            verifyHandler.MakeChangesEvent += () => UpdateAllChanges();
        }

        public void Load()
        {
            LoadTab(ActionDataTabs.Header);
            LoadTab(ActionDataTabs.Motion);
            LoadTab(ActionDataTabs.Attack);
            LoadTab(ActionDataTabs.Collision);
            LoadTab(ActionDataTabs.FunctionCall);
        }
        public void UpdateDataSelect()
        {
            allActiveTabs.Clear();

            DataNode selectedData = selector.ActiveData.Data;
            activeData.SetDataNode(selectedData);

            NodeType nodeType = selectedData.GetNodeType();
            RawNodeType rawType = NodeUtil.GetRawFromNodeType(nodeType);

            attackNode = null;
            collisionNode = null;

            bool setBase = false;

            switch (rawType)
            {
                case RawNodeType.Motion:
                    rbBase.Enabled = true;
                    tabs[ActionDataTabs.Motion].LoadNode(selectedData);

                    if (nodeType == NodeType.Motion8)
                    {
                        rbAttackProperties.Enabled = false;
                        rbCollisionProperties.Enabled = false;
                    }
                    else
                    {
                        attackNode = activeData.Unit.GetPropertyNode(PropertyType.AttackDetails, ((int)((Motion)selectedData).AttackIndex));
                        collisionNode = activeData.Unit.GetPropertyNode(PropertyType.AllCollision, ((int)((Motion)selectedData).AllCollisionIndex));

                        /*
                        if (lastUnitOnMotionUpdate != selector.UnitNum)
                        {
                            tabs[ActionDataTabs.Attack].LoadNodeIndexes = true;
                            tabs[ActionDataTabs.Collision].LoadNodeIndexes = true;
                        }
                        else
                        {
                            ((TabCollision)tabs[ActionDataTabs.Collision]).PreventCollisionIndexLoad = true;
                        }
                        */
                        tabAttackDetails.LoadNodeExternal((int)((Motion)selectedData).AttackIndex);
                        //tabs[ActionDataTabs.Attack].LoadNode(attackNode);
                        tabs[ActionDataTabs.Collision].LoadNode(collisionNode);

                        rbAttackProperties.Enabled = true;
                        rbCollisionProperties.Enabled = true;

                        allActiveTabs.Add(ActionDataTabs.Motion);
                        allActiveTabs.Add(ActionDataTabs.Collision);
                        allActiveTabs.Add(ActionDataTabs.Attack);

                        lastUnitOnMotionUpdate = selector.UnitNum;
                    }
                    break;
                case RawNodeType.FunctionCall:
                    tabs[ActionDataTabs.FunctionCall].LoadNode(selectedData);
                    rbBase.Enabled = true;
                    rbAttackProperties.Enabled = false;
                    rbCollisionProperties.Enabled = false;
                    attackNode = null;
                    collisionNode = null;
                    allActiveTabs.Add(ActionDataTabs.FunctionCall);
                    setBase = true;
                    break;
                default:
                    switch (nodeType)
                    {
                        case NodeType.ActionHeader:
                            tabs[ActionDataTabs.Header].LoadNode(selectedData);
                            rbBase.Enabled = true;
                            allActiveTabs.Add(ActionDataTabs.Header);
                            activeOption = ActionDataOption.None;
                            setBase = true;
                            break;
                        default:
                            rbBase.Enabled = false;
                            break;
                    }
                    //rbBase.Enabled = false;
                    rbAttackProperties.Enabled = false;
                    rbCollisionProperties.Enabled = false;
                    attackNode = null;
                    collisionNode = null;
                    break;
            }

            if (setBase)
            {
                activeOption = ActionDataOption.Base;
                stopDataOptionUpdate = true;
                rbBase.Checked = true;
                stopDataOptionUpdate = false;
            }

            activeRawNodeType = rawType;
            activeNodeType = nodeType;

            UpdateDataOptionSelect(activeOption, true);
            OnTabSelectComplete(rawType);


        }
        private void OnTabSelectComplete(RawNodeType rawType)
        {
            if (TabSelectComplete != null)
                TabSelectComplete(rawType);
        }

        private void OnUpdateAll()
        {
            if (UpdateAll != null)
                UpdateAll();
        }

        private void OnLoadTab(NodeLayout tab)
        {
            if (LoadTabCallback != null)
                LoadTabCallback(tab);
        }
        private void UpdateDataOptionSelect(ActionDataOption newOption, bool forceOptionSelect = false)
        {

            ActionDataTabs selectedTab = ActionDataTabs.None;

            if (newOption != ActionDataOption.None)
            {
                if (newOption == ActionDataOption.Base)
                {
                    switch (activeRawNodeType)
                    {
                        case RawNodeType.FunctionCall:
                            selectedTab = ActionDataTabs.FunctionCall;
                            break;
                        case RawNodeType.Motion:
                            selectedTab = ActionDataTabs.Motion;
                            break;
                        case RawNodeType.None:
                            switch (activeNodeType)
                            {
                                case NodeType.ActionHeader:
                                    selectedTab = ActionDataTabs.Header;
                                    break;
                            }
                            break;
                    }

                }
                else
                {
                    selectedTab = (ActionDataTabs)Enum.Parse(typeof(ActionDataTabs), newOption.ToString("G"));
                }

                if (activeTab == selectedTab && !forceOptionSelect)
                {
                    return;
                }

                if (activeTab != ActionDataTabs.None)
                {
                    ShowTab(activeTab, false);
                }

                if (selectedTab != ActionDataTabs.None)
                {
                    ShowTab(selectedTab);
                }

                activeTab = selectedTab;
                activeOption = newOption;
            }
            else
            {
                activeOption = ActionDataOption.None;
                //activeTab = ActionDataTabs.None;
            }

            //lblDataAddress.Text = "Data Address: " + labelAddress;


        }



        private void LoadTab(ActionDataTabs tabKey)
        {
            NodeLayout tab = null;

            if (tabs.ContainsKey(tabKey))
            {
                throw new ArgumentException("tab already exists");
            }

            switch (tabKey)
            {
                case ActionDataTabs.Motion:
                    tab = new TabMotion(activeData);
                    tabMotion = (TabMotion)tab;
                    break;
                case ActionDataTabs.Collision:
                    tab = new TabCollision(activeData);
                    ((TabCollision)tab).PrimaryIndexChanged += OnAllCollisionIndexChanged;
                    tabCollision = (TabCollision)tab;
                    break;
                case ActionDataTabs.Attack:
                    tab = new TabAttackDetails(activeData);
                    tabAttackDetails = (TabAttackDetails)tab;
                    tabAttackDetails.PrimaryIndexChanged += OnAttackIndexChanged;
                    break;
                case ActionDataTabs.FunctionCall:
                    tab = new FunctionCallPanel(activeData);
                    tabFunctionCall = (FunctionCallPanel)tab;
                    break;
                case ActionDataTabs.Header:
                    tab = new TabActionHeader(activeData);
                    tabHeader = (TabActionHeader)tab;
                    tabHeader.DataLengthChangedEvent += OnDataLengthChanged;
                    break;
                case ActionDataTabs.None:
                    throw new ArgumentException("Invalid tabKey");

            }

            tab.ValueChangedEvent += OnValueChanged;

            tab.Location = new System.Drawing.Point(12, 12);
            tab.Hide();
            tabs[tabKey] = tab;
            verifyHandler.AddChild(tab.Verification);
            OnLoadTab(tab);
        }

        protected void ShowNoData(bool show = true)
        {
            activeTab = ActionDataTabs.NoData;
            panelNoData.Visible = show;
        }

        protected void HideData()
        {
            if (activeTab != ActionDataTabs.None)
            {
                ShowTab(activeTab, false);
            }

            stopDataOptionUpdate = true;
            rbBase.Checked = false;
            rbAttackProperties.Checked = false;
            rbCollisionProperties.Checked = false;
            stopDataOptionUpdate = false;

        }


        protected void ShowTab(ActionDataTabs tab, bool show = true)
        {
            switch (tab)
            {
                case ActionDataTabs.NoData:
                    panelNoData.Visible = show;
                    break;
                default:
                    if (show)
                    {
                        tabs[tab].Show();
                        if (TabActivateEvent != null)
                            TabActivateEvent(tab);
                    }
                    else
                    {
                        tabs[tab].Hide();
                        if (TabDeactivateEvent != null)
                            TabDeactivateEvent(tab);
                    }

                    break;
            }
        }

        private void OnValueChanged(DataControlEventParams p)
        {

            if (ValueChangedEvent != null)
                ValueChangedEvent(p);

            NodeDataStream.SaveData();
        }

        public void UpdateAllChanges()
        {
            for (int i = 0; i < allActiveTabs.Count; i++)
            {
                tabs[allActiveTabs[i]].UpdateNode();
                tabs[allActiveTabs[i]].Verification.Pending = false;
            }

            OnUpdateAll();
        }

        //public bool VerifyChanges()
        //{
        //    verifyHandler.Confirm("Confirm changes?", "Confirm?");
        //    return true;
        //}

        private void OnDataLengthChanged(int newLength)
        {
            activeData.Action.ChangeLengthOfData(newLength);
        }

        private void OnAttackIndexChanged(int index)
        {
            ((Motion)tabMotion.Node).AttackIndex = (uint)index;
            tabMotion.Verification.Pending = true;
        }

        private void OnAllCollisionIndexChanged(int index)
        {
            ((Motion)tabMotion.Node).AllCollisionIndex = (uint)index;
            tabMotion.Verification.Pending = true;
        }
        private void OnCheckBase(object sender, EventArgs e)
        {
            if (!stopDataOptionUpdate && rbBase.Checked)
            {
                UpdateDataOptionSelect(ActionDataOption.Base);
            }
        }

        private void OnCheckAttackProperties(object sender, EventArgs e)
        {
            if (!stopDataOptionUpdate && rbAttackProperties.Checked)
            {
                UpdateDataOptionSelect(ActionDataOption.Attack);
            }

        }

        private void OnCheckCollisionProperties(object sender, EventArgs e)
        {
            if (!stopDataOptionUpdate && rbCollisionProperties.Checked)
            {
                UpdateDataOptionSelect(ActionDataOption.Collision);
            }

        }

    }
}
