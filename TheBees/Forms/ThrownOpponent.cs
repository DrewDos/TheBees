using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TheBees.GameRom;
using TheBees.Forms.Verification;
using TheBees.Forms.Support.DataControl;

namespace TheBees.Forms
{
    public partial class ThrownOpponent : Form
    {
        private UnitSelector sourceSelector = null;
        private UnitSelector targetSelector = null;

        SpriteViewer viewer;
        ActiveDataElement refActiveData;
        ActiveDataElement targetActiveData;

        private GameRom.NodeSequence group;
        private int prevUnitNum = -1;
        private int specNum;
        private int realSpecNum;
        private int unitCount = 24;

        private UnitData.Node.ThrownOpponent specNode;
        private int startAction = 0;
        private int[] groupStartIndexes = null;
        private bool showTargetImage = false;

        private VerifyManual vh;

        public ThrownOpponent()
        {
            viewer = new SpriteViewer();
            //viewer.Panel.SetModifyMode(ModifyMode.Sprite);
            //viewer.Panel.SpriteOffsetChanged = OnSpriteOffsetChanged;

            InitializeComponent();


            vh = new VerifyManual("dataIndex");
            vh.AddChild(tabThrownOpponent.Verification);
            vh.MakeChangesEvent += () => specNode.ApplyBuffer();

            sourceSelector = new UnitSelector(cbSourceUnit, cbCategoryRef, cbActionRef, cbDataRef);
            targetSelector = new UnitSelector(cbThrownUnit, cbTargetCategory, cbTargetAction, cbDataTarget);

            refActiveData = sourceSelector.ActiveData;
            targetActiveData = targetSelector.ActiveData;

            sourceSelector.SelectComplete = OnRefSelectComplete;
            sourceSelector.SelectUnit = OnRefSelectUnit;
            sourceSelector.SelectAction = OnRefSelectAction;

            sourceSelector.EnableAllGroups(false);
            sourceSelector.EnableGroup(UnitData.ActionType.Throws);
            sourceSelector.MotionIndexesOnly = true;

            sourceSelector.Verification = vh;

            targetSelector.EnableAllGroups(false);
            targetSelector.EnableGroup(UnitData.ActionType.ClientBehavior3);
            targetSelector.ListMode = GroupListMode.ByAction;
            targetSelector.Lock(UnitCombo.Category);
            targetSelector.Lock(UnitCombo.Action);

            sourceSelector.CompleteSettings();
            sourceSelector.LoadFromUnit();

            targetSelector.CompleteSettings();
            targetSelector.LoadFromUnit();

            targetSelector.SelectComplete = OnTargetSelectComplete;
            targetSelector.SelectGroup = OnTargetSelectGroup;
            targetSelector.SelectUnit = OnTargetSelectUnit;

            tabThrownOpponent.ActiveData = refActiveData;
            tabThrownOpponent.ValueChangedEvent += OnEditChanged;
            tabThrownOpponent.FlipFlagChangedEvent += OnFlipFlagChanged;

            //OnRefSelectUnit();
        }

        private void OnFlipFlagChanged()
        {
            UpdateSpriteView();
        }

        private void OnEditChanged(DataControlEventParams p)
        {
            UpdateSpriteView();
        }

        private void UpdateSpecList()
        {
            cbSpecIndex.Items.Clear();
            cbSpecIndex.Items.Add("None");
            cbSpecIndex.Items.AddRange(Description.DescSpec.GetIndexedList(group.Count));

        }

        private void OnRefSelectUnit()
        {
            int currUnitNum = refActiveData.Unit.Index;

            if (prevUnitNum != currUnitNum)
            {
                group = refActiveData.Unit.GetPropertyGroup(UnitData.PropertyType.ThrownOpponentSpec);

                if (group != null)
                {
                    UpdateSpecList();
                    specNum = 0;
//                  cbSpecIndex.SelectedIndex = 0;
                }
            }
        }

        private void OnRefSelectAction()
        {
            UpdateStartAction();
        }

        private void UpdateStartAction()
        {
            startAction = 0;

            if (refActiveData.Action != null)
            {
                for (int i = 0; i < refActiveData.Action.Count; i++)
                {
                    GameRom.DataNode node = refActiveData.Action.GetNode(i);


                    if (GameRom.NodeUtil.GetRawFromNodeType(node.GetNodeType()) == GameRom.RawNodeType.FunctionCall)
                    {
                        if (((UnitData.FunctionCall)node).FunctionCode == 0x69)
                        {
                            //startAction = groupStartIndexes[(int)((UnitData.Node.FunctionCall)node).Value2];// +(int)((UnitData.Node.FunctionCall)node).Value3;
                            startAction = (int)((UnitData.FunctionCall)node).Value2;
                            break;
                        }
                    }
                }
            }
        }

        private void OnRefSelectComplete()
        {
            if (group != null)
            {
                int tiNum = (int)((UnitData.Motion)refActiveData.Data).ThrownOpponentIndex;
                specNum = 0;
                if (tiNum != 0)
                {
                    tiNum -= 1;

                    // Fix later
                    // We must fix this later
                    // we're using this since the range of thrown opponent indexes are currently incorrect

                    if (tiNum <= refActiveData.Unit.GetPropertyGroup(UnitData.PropertyType.ThrownOpponentSpec).Count)
                    {
                        specNum = (tiNum * unitCount + targetSelector.UnitNum) + 1;
                    }

                    if (specNum > cbSpecIndex.Items.Count)
                    {
                        specNum = 0;
                    }
                    cbSpecIndex.SelectedIndex = specNum;
                    UpdateSpecSelect();
                    UpdateRefSelect();
                }
                else
                {
                    cbSpecIndex.SelectedIndex = 0;
                    UpdateSpecSelect();
                }
            }

        }

        private void OnTargetSelectUnit()
        {
            if (specNum > 0)
            {
                specNum = specNum / unitCount * unitCount + targetActiveData.Unit.Index + 1;
                cbSpecIndex.SelectedIndex = specNum;
            }
            UpdateSpecSelect();

            targetSelector.MakeSelection(-1, -1, startAction, specNode.DataIndex);
        }

        private void OnTargetSelectGroup()
        {
            //GetGroupStartIndexes();
            UpdateStartAction();
        }
        private void GetGroupStartIndexes()
        {
            int currGroupIndex = -1;
            List<int> groupIndexes = new List<int>();

            for (int i = 0; i < targetSelector.NodeIndexes.Length; i++)
            {
                if (targetSelector.NodeIndexes[i].ActionNum != currGroupIndex)
                {
                    currGroupIndex = targetSelector.NodeIndexes[i].ActionNum;
                    groupIndexes.Add(i);
                }
            }

            groupStartIndexes = groupIndexes.ToArray();
        }
        private void OnTargetSelectComplete()
        {
            if (targetSelector.FromSelect == UnitCombo.Data)
            {
                specNode.DataIndex = targetSelector.DataNum;
                vh.SetKey("dataIndex", true);
            }
            UpdateSpriteView();
        }
        
        private void UpdateSpecSelect()
        {
            if (specNum > 0)
            {
                showTargetImage = true;

                if (!targetSelector.Enabled)
                {
                    targetSelector.Enable();
                }

                realSpecNum = specNum - 1;
                specNode = (UnitData.Node.ThrownOpponent)group.GetNode(realSpecNum);

                tabThrownOpponent.LoadNode(specNode);
            }
            else
            {
                targetSelector.Disable();
                showTargetImage = false;
                UpdateSpriteView();
            }
        }

        private void UpdateRefSelect()
        {            
            int targetUnit = realSpecNum % unitCount;

            if (targetUnit >= UnitData.UnitSpec.CharacterUnitCount)
            {
                targetUnit = targetSelector.UnitNum;
                showTargetImage = false;
            }
            targetSelector.MakeSelection(
                targetUnit,
                -1,//(int)specNode.GetValue("value1"),
                startAction,
                specNode.DataIndex
                );


            UpdateSpriteView();
        }
        private void UpdateSpriteView()
        {
            if (viewer.Visible)
            {
                List<SpriteRequest> requests = new List<SpriteRequest>();
                int primaryIndex = 0;
                int secondaryIndex = 0;
                
                UnitData.Motion sourceMotion = null;
                UnitData.Motion targetMotion = null;
                
                if (GameRom.NodeUtil.GetRawFromNodeType(refActiveData.Data.GetNodeType()) == GameRom.RawNodeType.Motion)
                {
                    sourceMotion = (UnitData.Motion)refActiveData.Data;
                    primaryIndex = sourceMotion.SpriteIndex;
                }

                if (showTargetImage)
                {
                    if (GameRom.NodeUtil.GetRawFromNodeType(targetActiveData.Data.GetNodeType()) == GameRom.RawNodeType.Motion)
                    {
                        targetMotion = (UnitData.Motion)targetActiveData.Data;
                        secondaryIndex = targetMotion.SpriteIndex;
                    }
                }

                SpriteRequest reqPrimary = null;
                SpriteRequest reqSecondary = null;

                if (primaryIndex > 0)
                {
                    reqPrimary = new SpriteRequest(
                        primaryIndex, 
                        UnitData.UnitHandler.GetCharacterUnitPallet(refActiveData.Unit.Index),
                        0,
                        0,
                        false,
                        false,
                        true
                        );
                }

                if (secondaryIndex != 0)
                {

                    reqSecondary =
                        new SpriteRequest(
                            secondaryIndex,
                            UnitData.UnitHandler.GetCharacterUnitPallet(targetActiveData.Unit.Index),
                            specNode.xOffset,
                            specNode.yOffset * -1,
                            specNode.FlipX != targetMotion.FlipX,
                            specNode.FlipY != targetMotion.FlipY
                        );
                }
                

                switch (specNode.LayerValue)
                {
                    
                    case 2:
                        if (reqPrimary != null) 
                            requests.Add(reqPrimary);
                        if(reqSecondary != null)
                            requests.Add(reqSecondary);
                        break;
                    default:
                        if (reqSecondary != null)
                            requests.Add(reqSecondary);
                        if (reqPrimary != null)
                            requests.Add(reqPrimary);
                        break;

                }

            
                if (requests.Count > 0)
                {
                    viewer.ShowNormalSprite(requests);
                }
            }
        }

        private void OnClickShowSpriteViewer(object sender, EventArgs e)
        {
            viewer.Show(this);
        }

        private void OnSelectSpectIndex(object sender, EventArgs e)
        {
            if (vh.Confirm("Update Changes?", "Update Changes?"))
            {
                // we dont have to handle the update from here, since the verify handler has the callback within it
                specNum = cbSpecIndex.SelectedIndex;
                UpdateSpecSelect();
                UpdateRefSelect();
            }
            else
            {
               cbSpecIndex.SelectedIndex = specNum;
            }
        }

        private void OnShown(object sender, EventArgs e)
        {
            viewer.Show(this);
            UpdateSpriteView();
            
        }

        private void On(object sender, EventArgs e)
        {

        }

        private void OnDataIndexChanged(object sender, EventArgs e)
        {
            if (((BitEdit)sender).ChangeType == BitEditChange.Input)
            {
                specNode.DataIndex = (int)((BitEdit)sender).Value;
            }
        }

        private void OnSpriteOffsetChanged(int index, int xPos, int yPos)
        {
            yPos *= -1;
            //specNode.xOffset = (short)xPos;
            //specNode.yOffset = (short)yPos;
            tabThrownOpponent.ControlSet.GetControlByKey("xPos").SetValue((uint)xPos & 0x0000FFFF);// = "xPos", (ushort)xPos);
            tabThrownOpponent.ControlSet.GetControlByKey("yPos").SetValue((uint)yPos & 0x0000FFFF);//
        }
    }
}
