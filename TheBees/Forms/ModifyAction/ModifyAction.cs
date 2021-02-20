using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TheBees.GameRom;
using TheBees.UnitData;
using TheBees.Forms.Support.DataControl;
using TheBees.Forms.Verification;
using TheBees.Sprites;
using TheBees.Controls;

namespace TheBees.Forms
{


    public partial class ModifyAction : Form
    {
        static protected SpriteViewer spriteViewer;
        protected UnitSelector selector;
        protected DataPanel dataPanel;
        protected DataNode attackNode = null;
        protected DataNode collisionNode = null;
        protected ActiveDataElement activeData;
        private DirectionalKeyAction keyAction;
        private FunctionView functionView;
        private ReferenceQueue refQueue;
        private bool loadFunctionView = false;

        private SpriteSelector spriteSelector;

        public UnitSelector UnitSelector { get { return selector; } }

        static public SpriteViewer SpriteViewer { get { return spriteViewer; } }

        public General.BasicDelegate UpdateAll {set { dataPanel.UpdateAll = value; } }

        public ModifyAction(ActionReference srcReference)
        {
            InitializeInstance();
            selector.LoadWithSelection(srcReference);
        }

        public ModifyAction()
        {
            InitializeInstance();
            selector.LoadFromUnit();

            //loadFunctionView = true;
        }

        private void InitializeInstance()
        {
            InitializeComponent();

            refQueue = new ReferenceQueue();

            keyAction = new DirectionalKeyAction();
            keyAction.UpEvent += () => selector.PreviousData();
            keyAction.DownEvent += () => selector.NextData();
            keyAction.LeftEvent += () => selector.PreviousAction();
            keyAction.RightEvent += () => selector.NextAction();

            SaveHandler.BeforeSaveEvent += OnSave;
            actionEditTextbox1.TextSendEvent += UpdateActionTag;

            if (!Settings.ShowModifyActionDataCount)
            {
                lblDataCount.Visible = false;
            }

            spriteViewer = new SpriteViewer();
            spriteViewer.Panel.SetModifyMode(ModifyMode.Collision);
            CollisionRelay.SetSpriteViewer(spriteViewer);


            selector = new UnitSelector(cbUnit, cbCategory, cbProperty, lbDataIndex);
            activeData = selector.ActiveData;

            dataPanel = new DataPanel(selector, rbBase, rbAttackProperties, rbCollisionProperties, panelNoData);
            dataPanel.UpdateAll = NodeDataStream.SaveData;
            dataPanel.TabSelectComplete = OnTabSelectComplete;
            dataPanel.ValueChangedEvent += OnValueChanged;
            dataPanel.LoadTabCallback = OnLoadTab;
            selector.Verification = dataPanel.Verification;
            dataPanel.TabActivateEvent += OnActivateTab;
            dataPanel.TabDeactivateEvent += OnDeactivateTab;

            //dataPanel.UpdateAll = OnUpdateAll;

            selector.SelectComplete += OnSelectData;
            selector.SelectAction += OnSelectAction;

            dataPanel.Load();

            dataPanel.TabMotion.OnGraphicValueChanged += OnGraphicValueChanged;
            dataPanel.TabCollision.PrimaryIndexChanged += UpdateCollisionIndex;
            dataPanel.TabAttackDetails.PrimaryIndexChanged += UpdateAttackIndex;
            dataPanel.TabFunctionCall.JumpToAction = JumpTo;

            actionToolset1.SetControls(selector, cbProperty);
            actionDataToolset1.SetControls(selector, lbDataIndex);

            selector.CompleteSettings();

            btnGoBack.Enabled = refQueue.HasPrevious();
        }
        private void OnActivateTab(ActionDataTabs tab)
        {
            if (tab == ActionDataTabs.Motion && spriteSelector != null && spriteSelector.Visible)
                spriteSelector.ActivateSelector();
        }

        private void OnDeactivateTab(ActionDataTabs tab)
        {
            if (spriteSelector != null && spriteSelector.Visible)
                spriteSelector.DeactivateSelector();
        }

        private void UpdateSpriteIndex(int newIndex)
        {
            dataPanel.TabMotion.ControlSet.GetControlByKey("gfx2").SetValue((uint)newIndex).UpdateControl();
        }

        private void OnSelectAction()
        {
            lblActionIndex.Text = "Action Index: " + selector.ActionNum.ToString("X2");
        }

        private void OnSelectData()
        {
            // on select complete alias
            if (selector.GroupNum != -1)
            {
                dataPanel.UpdateDataSelect();
                actionEditTextbox1.SetTextFromSelect(activeData.Action.Tag);
            }
        }

        private void OnLoadTab(NodeLayout tab)
        {
            groupBox.Controls.Add(tab);
        }

        private void OnTabSelectComplete(RawNodeType rawType)
        {

            if (rawType == RawNodeType.Motion)
            {
                ShowMotionSprite();
            }
            else
            {
                if(spriteViewer.Visible)
                    spriteViewer.Clear();
            }

            string addressString = "";
            
            switch (dataPanel.ActiveTab)
            {
                case ActionDataTabs.Attack:
                    if(dataPanel.AttackNode != null)
                        addressString = dataPanel.AttackNode.Address.ToString("X8");
                    break;
                case ActionDataTabs.Collision:
                    if(dataPanel.CollisionNode != null)
                        addressString = dataPanel.CollisionNode.Address.ToString("X8");
                    break;
                case ActionDataTabs.Motion:
                case ActionDataTabs.Header:
                case ActionDataTabs.FunctionCall:
                    if(activeData.Data != null)
                        addressString = activeData.Data.Address.ToString("X8");
                    break;
                default:
                    addressString = "";
                    break;
            }

            lblDataAddress.Text = String.Format("Data Address: {0}", addressString);
        }
       
        public void ShowMotionSprite(int tempIndex = 0)
        {

            if (spriteViewer.Visible && activeData.Data.GetType() == typeof(Motion))
            {
                spriteViewer.ShowNormalSprite(DisplayHelper.GetRequestsFromMotion(activeData.Unit, (Motion)activeData.Data).Requests);
            }
        }
        private void UpdateCollisionIndex(int newIndex)
        {
            ((Motion)activeData.Data).AllCollisionIndex = (uint)newIndex;
        }

        private void UpdateAttackIndex(int newIndex)
        {
            ((Motion)activeData.Data).AttackIndex = (uint)newIndex;
        }

        private void OnValueChanged(DataControlEventParams p)
        {
        }

        // all control event handlers
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveHandler.SaveRom(Settings.RomTarget, Globals.LoadedType);
        }

        private void OnClose(object sender, FormClosingEventArgs e)
        {
            if (spriteViewer.Visible)
            {
                spriteViewer.Hide();
            }
        }
        public void OnSave()
        {
            //if (panel != null)
            //{
            //    panel.UpdateAllChanges();
            //}
        }

        public void OnGraphicValueChanged(DataControlEventParams p)
        {
            ShowMotionSprite();
        }


        ////////////////////////////////////////
        // to rename later
        ////////////////////////////////////////
        private void UpdateActionTag(string newText)
        {
            activeData.Action.SetTag(newText);
            selector.UpdateActionListText(activeData.Group.RecordableList.GetIndexes(activeData.Action), newText);

        }

        ////////////////////////////////////////
        // shortcuts
        ////////////////////////////////////////
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyAction.Process(ModifierKeys, keyData))
                return true;

            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if ((ModifierKeys & Keys.Control) > 0 && (keyData & Keys.Up) > 0)
            {
                return true;
            }

            return base.ProcessDialogKey(keyData);
        }


        private void OnShown(object sender, EventArgs e)
        {
            if (loadFunctionView)
            {
                functionView = new FunctionView(selector);
                functionView.Show(this);
            }

            spriteViewer.Show(this);
        }

        private void ViewDropDownOpening(object sender, EventArgs e)
        {
            menuOpenSpriteViewer.Enabled = !spriteViewer.Visible;
        }

        private void OnOpenSpriteViewer(object sender, EventArgs e)
        {
            spriteViewer.Show(this); 
        }

        private void OnChangeLength(object sender, EventArgs e)
        {
            activeData.Action.ChangeLengthOfData(6);
        }

        private void OnShowAddresses(object sender, EventArgs e)
        {
            int min = 0;
            int max = (int)Enum.GetValues(typeof(PropertyType)).Cast<PropertyType>().Max();
            string output = "";

            for (int i = min; i < max; i++)
            {
                PropertyType type = (PropertyType)i;
                PropertyGroup group = activeData.Unit.GetPropertyGroup(type);

                if (group != null)
                {
                    output += String.Format("{0}: {1}\n", type.ToString(), ((int)group.DataAddress).ToString("X8"));
                }

            }

            min = 0;
            max = (int)Enum.GetValues(typeof(ActionType)).Cast<ActionType>().Max();

            for (int i = min; i < max; i++)
            {
                ActionType type = (ActionType)i;
                ActionGroup group = activeData.Unit.GetActionGroup(type);

                if (group != null)
                {
                    output += String.Format("{0}: {1}\n", type.ToString(), ((int)group.Address).ToString("X8"));
                }

            }

            MessageBox.Show(output);

        }


        private void cbDataIndex_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void ModifyAction_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void JumpTo(int groupNum, int actionNum, int dataNum)
        {
            refQueue.Push(GetCurrentReference());
            int targetDataIndex = dataNum;
            selector.MakeSelection(-1, groupNum, actionNum, targetDataIndex);
            btnGoBack.Enabled = refQueue.HasPrevious();
        }

        private ActionReference GetCurrentReference()
        {
            return new ActionReference(selector.UnitNum, selector.GroupNum, selector.ActionNum, selector.DataNum);
        }

        private void OnClickGoBack(object sender, EventArgs e)
        {
            ActionReference reference = refQueue.GetPrevous();
            selector.MakeSelection(reference.UnitNum, reference.GroupNum, reference.ActionNum, reference.DataNum);
            btnGoBack.Enabled = refQueue.HasPrevious();

        }

        private void OnClickGetDoubleFunctions(object sender, EventArgs e)
        {
            Debugging.GetDoubleFunctions();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ActionReference reference = Debugging.DoubleFunctionNext();
            selector.MakeSelection(reference.UnitNum, reference.GroupNum, reference.ActionNum, reference.DataNum);
        }

        private void OnClickMenuSpriteSelector(object sender, EventArgs e)
        {
            spriteSelector = new SpriteSelector();
            spriteSelector.SpriteIndexChangedEvent += UpdateSpriteIndex;
            
            spriteSelector.Show(this);
            if (dataPanel.ActiveTab == ActionDataTabs.Motion)
                spriteSelector.ActivateSelector();
            else
                spriteSelector.DeactivateSelector();
        }

        private void OnFindActions(object sender, EventArgs e)
        {
            ActionReference reference = Debugging.DoubleFunctionNext();
            selector.MakeSelection(reference.UnitNum, reference.GroupNum, reference.ActionNum, reference.DataNum);

        }

        private void OnToolsDropDownOpening(object sender, EventArgs e)
        {
            menuSpriteSelector.Enabled = spriteSelector == null || !spriteSelector.Visible;
        }

    }
}
