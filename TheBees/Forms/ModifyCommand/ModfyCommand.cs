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
using TheBees.Description;
using TheBees.User;

namespace TheBees.Forms
{

    public delegate void UpdateNodeDelegate(int index = -1);

    public partial class ModifyCommand : Form, IModifyForm
    {
        private ActiveDataElement activeData = ActiveData.GetDataElement(FormIndex.ModifyCommand);
        private PropertyGroup accelGroup;
        private CommandSet commandSet;
        private ModifyAction modifyActionForm;
        private int unitIndex;
        private int accelIndex;
        private int accel2Index;
        private int orbitalBasisIndex;
        private int actionIndex;
        private int bankIndex;
        private int targetNodeIndex;
        private int globalCommandIndex;
        private int unitCommandIndex;
        private int inputIndex;
        private TrickAccelType activeType;
        private DataNode accelNode;
        private DataNode accelNode2;
        private bool accel1Enabled = true;
        private bool accel2Enabled = true;

        private string[] verifyKeys = new string[] { "accel1", "accel2", "main", "command", "inputSpec", "all" };
        private Dictionary<string, UpdateNodeDelegate> updateDelegates = new Dictionary<string, UpdateNodeDelegate>();
        private Dictionary<string, bool> verifyFlags = new Dictionary<string, bool>();

        private BitEdit[] editsAccel1;
        private BitEdit[] editsAccel2;
        private BitEdit[] specEdits;
        private string[] keys;
        private string[] specKeys;
        private const int accelKeyCount = 6;

        private bool allowChangeType = true;
        private bool hasInputSpec = false;

        private bool usingAccel = true;

        private DirectionalKeyAction keyAction;

        public event Action<UnitCommand> SpecialBankSelectEvent;

        static public General.BasicDelegate OnUpdateComplete = null;

        public ModifyCommand()
        {
            InitializeComponent();

            

            accelTools1.SetControls(() => UpdateAccelNode(1), cbAcceleration, cbAcceleration2);
            accelTools2.SetControls(() => UpdateAccelNode(2), cbAcceleration2, cbAcceleration);

            accelTools1.ComboChangedEvent += (x) => OnSelectAcceleration(cbAcceleration, EventArgs.Empty);
            accelTools2.ComboChangedEvent += (x) => OnSelectAcceleration2(cbAcceleration2, EventArgs.Empty);

            InitData();
            SetSaveDelegate();
            ResetVerifyFlags();
            LoadCharacterNames();
            cbCharacterSel.SelectedIndex = 0;
            activeType = TrickAccelType.StandingNormals;
            
            allowChangeType = false;
            rbStanding.Checked = true;
            allowChangeType = true;

            keyAction = new DirectionalKeyAction();
            keyAction.LeftEvent += PreviousBank;
            keyAction.RightEvent += NextBank;
            UpdateCharacterSelect();
        }

        private void InitData()
        {
            InitUpdateDelegates();

            editsAccel1 = new BitEdit[]
            {
                tbXMuzzle,
                tbXAccel,
                tbUndef1,
                tbYMuzzle,
                tbYAccel,
                tbUndef2
            };
            editsAccel2 = new BitEdit[]
            {
                tbXMuzzle2,
                tbXAccel2,
                tbUndef21,
                tbYMuzzle2,
                tbYAccel2,
                tbUndef22
            };

            keys = new string[]
            {
                "xMuzzleVel",
                "xAccel",
                "undef1",
                "yMuzzleVel",
                "yAccel",
                "undef2"
            };

            
            for (int i = 0; i < accelKeyCount; i++ )
            {
                // this is fine, since they're all words
                editsAccel1[i].MaxValue = 0xFFFF;
                editsAccel2[i].MaxValue = 0xFFFF;
            }

            // initialize spec offsets
            specKeys = NodeSpec.GetKeys(NodeType.InputSpec);
            int specKeyCount = specKeys.Length;
            specEdits = new BitEdit[specKeyCount];
 
            for (int i = 0; i < specKeyCount; i++)
            {
                specEdits[i] = new BitEdit();
                specEdits[i].MaxValue = 0xFFFF;
                specEdits[i].TextChanged += OnInputSpecTextChanged;
                specOpponentTable.Controls.Add(specEdits[i], 0, i);
            }
        }

        private void InitUpdateDelegates()
        {

            updateDelegates["accel1"] = UpdateAccelNode;
            updateDelegates["accel2"] = UpdateAccelNode;
            updateDelegates["main"] = UpdateNode;
            updateDelegates["command"] = UpdateCommandAddress;
            updateDelegates["inputSpec"] = UpdateInputSpecNode;
            updateDelegates["all"] = UpdateAll;
        }

        private DialogResult ShowVerification()
        {
            return MessageBox.Show("Update changes?", "Update", MessageBoxButtons.YesNoCancel);
        }

        private void ResetVerifyFlags()
        {
            for (int i = 0; i < verifyKeys.Length; i++)
            {
                verifyFlags[verifyKeys[i]] = false;
            }
        }

        private void RequestVerification(string key)
        {
            verifyFlags[key] = true;
        }

        private void UpdateNode(string key, int index = -1)
        {
            updateDelegates[key](index);
        }

        private void UpdateAll(int index)
        {
            UpdateNode();

            UpdateAccelNode(1);
            UpdateAccelNode(2);

            UpdateInputSpecNode(-1);
            UpdateCommandAddress(-1);

            verifyFlags["all"] = false;

            CallOnUpdateComplete();
        }
        private bool VerifyChanges(string key, int index = -1)
        {
            if (verifyFlags[key])
            {
                DialogResult res = ShowVerification();

                switch (res)
                {
                    case DialogResult.Yes:
                        UpdateNode(key, index);
                        verifyFlags[key] = false;
                        return true;
                    case DialogResult.No:
                        verifyFlags[key] = false;
                        return true;
                    case DialogResult.Cancel:
                        return false;

                }

            }

            return true;
        }

        private void LoadCharacterNames()
        {
            cbCharacterSel.Items.Clear();
            cbCharacterSel.Items.AddRange(DescSpec.UnitNamesFromRomIndex);
        }

        private void LoadBankNames()
        {
            cbBankSel.Items.Clear();

            if (CommandSet.IsNormal(activeType))
            {
                cbBankSel.Items.AddRange(new string[] { "LP", "MP", "HP", "LK", "MK", "HK" });
            }
            else if(activeType == TrickAccelType.Specials)
            {
                int count = UnitSpec.ActiveSpecialAccelDefCount/4;
                for (int i = 0; i < count ; i++)
                {
                    cbBankSel.Items.Add((0x14 + i).ToString("X"));
                }

            }
        }

        private void LoadAccelNames()
        {
            cbAcceleration.Items.Clear();
            cbAcceleration.Items.AddRange(UnitDescription.GetPropertyGroupIndexes(activeData.Unit, PropertyType.Acceleration));
            cbOrbitalBasisIndex.Items.Clear();
            cbOrbitalBasisIndex.Items.AddRange(DescSpec.GetIndexedList((0x12 + 0x10)));
            cbAcceleration2.Items.Clear();
            cbAcceleration2.Items.AddRange(UnitDescription.GetPropertyGroupIndexes(activeData.Unit, PropertyType.Acceleration));
        }

        private void LoadCommandNames()
        {
            // load the default command
            cbCommand.Items.Clear();

            
            switch (activeType)
            {
                case TrickAccelType.StandingNormals:
                case TrickAccelType.CrouchingNormals:
                case TrickAccelType.JumpNeutral:
                case TrickAccelType.JumpBack:
                case TrickAccelType.JumpForward:
                    cbCommand.Items.Add("");
                    break;
                case TrickAccelType.Specials:
                    cbCommand.Items.AddRange(UserCommandMap.GetCommandNames());
                        break;
            }

            



            if (cbCommand.Items.Count == 1)
                cbCommand.Enabled = false;
            else
                cbCommand.Enabled = true;
        }

        private void LoadInputNames()
        {
            cbInputType.Items.Clear();

            if (CommandSet.IsNormal(activeType))
            {
                for(int i = 0; i < 3; i++)
                {
                    cbInputType.Items.Add((String.Format("{0} {1}", Enum.GetName(typeof(CharacterButton), bankIndex), i+1)));
                }
            }
            else if(activeType == TrickAccelType.Specials)
            {
                cbInputType.Items.AddRange(new string[]{ "L", "M", "H", "EX"});
            }
        }

        private void EnableTypeControls()
        {

            rbStanding.Enabled = commandSet.TypeAvailable(TrickAccelType.StandingNormals);
            rbCrouching.Enabled = commandSet.TypeAvailable(TrickAccelType.CrouchingNormals);
            rbNeutralJump.Enabled = commandSet.TypeAvailable(TrickAccelType.JumpForward);
            rbForwardJump.Enabled = commandSet.TypeAvailable(TrickAccelType.JumpForward);
            rbBackJump.Enabled = commandSet.TypeAvailable(TrickAccelType.JumpBack);
            rbSpecials.Enabled = commandSet.TypeAvailable(TrickAccelType.Specials);
        }

        private void LoadCharacter()
        {
            activeData.SetUnit(UnitHandler.GetUnit(unitIndex));
            commandSet = ((UnitCharacter)activeData.Unit).GetCommandSet();
            EnableTypeControls();

            TrickAccelType newType = activeType;

            if(!commandSet.TypeAvailable(activeType))
            {
                activeType = TrickAccelType.StandingNormals;
            }

            accelGroup = activeData.Unit.GetPropertyGroup(PropertyType.Acceleration);
            LoadAccelNames();

            UpdateTypeSelect(newType);

            accelTools1.SetPropertyGroup(accelGroup);
            accelTools2.SetPropertyGroup(accelGroup);

        }

        private int GetCommandIndex()
        {
            switch (activeType)
            {
                case TrickAccelType.StandingNormals:
                case TrickAccelType.CrouchingNormals:
                case TrickAccelType.JumpNeutral:
                case TrickAccelType.JumpForward:
                case TrickAccelType.JumpBack:
                    return 0;
                case TrickAccelType.Specials:
                    return 0x14 + bankIndex;
            }

            // we aren't going to implement special command indexes just yet...

            return 0;
        }

        private void UpdateBankSelect()
        {
            bankIndex = cbBankSel.SelectedIndex;

            //LoadCommandNames();
            LoadInputNames();
            if (activeType == TrickAccelType.Specials)
            {
                unitCommandIndex = GetCommandIndex();
                UnitCommand globalCmd = UserCommandMap.GetCommand(commandSet.CommandMap.GetMap(unitCommandIndex).Address);
                globalCommandIndex = UserCommandMap.GetCommandIndex(globalCmd.Address);
                cbCommand.SelectedIndex = globalCommandIndex;
                UpdateSelectedCommandText();

                if (SpecialBankSelectEvent != null)
                    SpecialBankSelectEvent(globalCmd);
            }
            else
            {
                if (SpecialBankSelectEvent != null)
                    SpecialBankSelectEvent(null);
            }

            UpdateCommandSelect();

            cbInputType.SelectedIndex = 0;
            UpdateInputSelect();


        }

        private void PreviousBank()
        {
            if (activeType == TrickAccelType.Specials)
            {
                if (bankIndex - 1 < 0)
                    return;

                bankIndex -= 1;
                cbBankSel.SelectedIndex = bankIndex;
                UpdateBankSelect();
            }
        }

        private void NextBank()
        {
            if (activeType == TrickAccelType.Specials)
            {
                if (bankIndex + 1 >= (UnitSpec.ActiveSpecialAccelDefCount / 4))
                    return;

                bankIndex += 1;
                cbBankSel.SelectedIndex = bankIndex;
                UpdateBankSelect();
            }

        }

        private void UpdateInputSelect()
        {
            inputIndex = cbInputType.SelectedIndex;

            btnBankConfig.Enabled = inputIndex > 0 && activeType != TrickAccelType.Specials;

            LoadDef();
        }

        private void LoadDef()
        {
            activeData.SetDataNode(commandSet.GetNode(activeType, bankIndex, inputIndex));
            targetNodeIndex = CommandSet.GetNodeIndex(activeType, bankIndex, inputIndex);
            //LoadCommandNames();
            // we will load the command index here

            // load the action data
            cbAction.SelectedIndex = (int)activeData.Data.GetValue("trick");
            UpdateActionSelect();

            // load the acceleration data
            if (usingAccel)
            {
                cbAcceleration.SelectedIndex = (int)activeData.Data.GetValue("accel1");
            }
            else
            {
                cbOrbitalBasisIndex.SelectedIndex = (int)activeData.Data.GetValue("accel1");
            }

            cbAcceleration2.SelectedIndex = (int)activeData.Data.GetValue("accel2");

            //cbAcceleration.SelectedIndex = accelIndex;
            //cbAcceleration2.SelectedIndex = accel2Index;

            //EnableAccel(1);
            UpdateAccelSelect(1);
            UpdateAccelSelect(2, true);
            // load the input spec values
            PopulateInputSpec();
        }

        private void PopulateInputSpec()
        {
            if (hasInputSpec)
            {
                DataNode node = commandSet.GetInputSpec(activeType);

                for (int i = 0; i < specKeys.Length; i++)
                {
                    specEdits[i].Value = node.GetValue(specKeys[i]);
                }
            }
        }
        private void UpdateCommandSelect()
        {
            globalCommandIndex = cbCommand.SelectedIndex;
        }

        private void PopulateAccelNode(int index)
        {
            
            BitEdit[] source = GetSourceEdit(index);
            DataNode accel = null;

            if (index == 1) accel = accelNode;
            if (index == 2) accel = accelNode2;

            for (int i = 0; i < accelKeyCount; i++)
            {
                source[i].Value = accel.GetValue(keys[i]);
            }
            
        }

        private void UpdateInputSpecNode(int index)
        {
            if (hasInputSpec)
            {
                DataNode node = commandSet.GetInputSpec(activeType);

                for (int i = 0; i < specKeys.Length; i++)
                {
                    node.SetValue(specKeys[i], specEdits[i].Value);
                }

                //node.ApplyData();
                verifyFlags["inputSpec"] = false;
            }
        }

        private void UpdateAccelNode(int index)
        {
            if (AccelEnabled(index))
            {
                BitEdit[] source = GetSourceEdit(index);
                DataNode accel = null;

                if (index == 1) accel = accelNode;
                if (index == 2) accel = accelNode2;

                for (int i = 0; i < accelKeyCount; i++)
                {
                    accel.SetValue(keys[i], source[i].Value);
                }

                //accel.ApplyData();

                if (index == 1)
                    verifyFlags["accel1"] = false;
                if (index == 2)
                    verifyFlags["accel2"] = false;
            }
        }

        private bool AccelEnabled(int index)
        {
            if (index == 1)
            {
                return accel1Enabled;
            }

            else if (index == 2)
            {
                return accel2Enabled;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Invalid Accel Index");
            }


        }

        private void EnableInputSpec(bool enable = true)
        {
            for (int i = 0; i < specKeys.Length; i++)
            {
                specEdits[i].Enabled = enable;
            }
        }
        private void EnableAccel(int index, bool enable = true)
        {
            if (AccelEnabled(index) != enable)
            {
                BitEdit[] edits = null;

                if (index == 1)
                {
                    edits = editsAccel1;
                    //box = cbAcceleration;
                    accel1Enabled = enable;
                }
                else if (index == 2)
                {
                    edits = editsAccel2;
                    //box = cbAcceleration2;
                    accel2Enabled = enable;
                }

                for (int i = 0; i < edits.Length; i++)
                {
                    edits[i].Enabled = enable;
                }

                //box.Enabled = enable;
            }
        }

        private BitEdit[] GetSourceEdit(int accelNum)
        {
            switch (accelNum)
            {
                case 1:
                    return editsAccel1;

                case 2:
                    return editsAccel2;

            }

            return null;
        }

        private void UpdateAccelSelect(int index, bool loadingBank = false)
        {
            if(index == 1)
            {
                if (usingAccel)
                {
                    accelIndex = cbAcceleration.SelectedIndex;

                    EnableAccel(index);
                    accelNode = accelGroup.GetNode(accelIndex);
                    PopulateAccelNode(1);


                    if (accelIndex == accel2Index && usingAccel)
                    {
                        EnableAccel(2, false);
                    }
                    else
                    {
                        EnableAccel(2);
                    }

                }
                else
                {
                    orbitalBasisIndex = cbOrbitalBasisIndex.SelectedIndex;
                }
            }

            if (index == 2)
            {
                accel2Index = cbAcceleration2.SelectedIndex;

                if (loadingBank && accelIndex == accel2Index && usingAccel)
                {
                    EnableAccel(index, false);
                }
                else
                {
                    EnableAccel(index);
                }

                accelNode2 = accelGroup.GetNode(accel2Index);
                PopulateAccelNode(2);

                if (!loadingBank && accel2Index == accelIndex)
                {
                    
                    EnableAccel(1, false);
                    
                }
                else
                {
                    EnableAccel(1);
                }
            }
        }

        private void UpdateActionSelect()
        {
            actionIndex = cbAction.SelectedIndex;

            if (modifyActionForm != null && modifyActionForm.Visible)
            {
                modifyActionForm.UnitSelector.MakeSelection(GetCurrentActionReference());
            }
        }

        private void UpdateCharacterSelect()
        {
            unitIndex = cbCharacterSel.SelectedIndex;
            LoadCharacter();
        }


        private void UpdateTypeSelect(TrickAccelType type)
        {
            activeType = type;

            ActionType actionType = ActionType.None;

            if(CommandSet.IsNormal(type))
            {
                LoadCommandNames();
                actionType = ActionType.Tricks;
                activeData.SetGroup(activeData.Unit.ActionGroups[ActionType.Tricks]);
                hasInputSpec = true;
                tbSelectedCommand.Text = "";
                tbSelectedCommand.Enabled = false;
                btnSetCommand.Enabled = false;
                EnableInputSpec();
                btnModifyCommand.Enabled = false;
                SetDetailsType(false);
            }
            else if (type == TrickAccelType.Specials)
            {
                LoadCommandNames();
                actionType = ActionType.Mortals;
                activeData.SetGroup(activeData.Unit.ActionGroups[ActionType.Mortals]);

                hasInputSpec = false;
                tbSelectedCommand.Enabled = true;
                btnSetCommand.Enabled = true;
                EnableInputSpec(false);
                btnModifyCommand.Enabled = true;
                SetDetailsType(true);
            }
            else
            {
                throw new ArgumentException("Invalid TrickAccelType Specified");
            }

            activeData.SetGroup(activeData.Unit.GetActionGroup(actionType));

            LoadBankNames();
            
            // load all of the actions
            cbAction.Items.Clear();
            cbAction.Items.AddRange(UnitDescription.GetActionGroupNames(activeData.Group));

            cbBankSel.SelectedIndex = 0;
            UpdateBankSelect();

        }

        private void SetDetailsType(bool newUsingAccel)
        {
            if(newUsingAccel != usingAccel)
            {
                if (usingAccel)
                {
                    usingAccel = false;
                    pnlOrbitalBasis.Visible = true;
                    lblAccel1.Text = "Orbital Basis Index";
                    lblAccel2.Text = "Acceleration";
                    pnlPrimaryAccel.Visible = false;
                }
                else
                {
                    usingAccel = true;
                    lblAccel1.Text = "Acceleration #1";
                    lblAccel2.Text = "Acceleration #2";
                    pnlOrbitalBasis.Visible = false;
                    pnlPrimaryAccel.Visible = true;
                }

                usingAccel = newUsingAccel;
            }
        }


        private void UpdateNode(int index = -1)
        {
            DataNode node = activeData.Data;

            node.SetValue("trick", (uint)actionIndex);
            if(usingAccel)
                node.SetValue("accel1", (uint)accelIndex);
            else
                node.SetValue("accel1", (uint)orbitalBasisIndex);

            commandSet.GetNodeGroup(activeType).SetNode(node, targetNodeIndex);
            //commandSet.GetNodeGroup(activeType).GetNode(targetNodeIndex).ApplyData();

            verifyFlags["main"] = false;

        }

        private void UpdateOrRequest(string key)
        {
            if (Settings.AutoUpdate)
            {
                int index = -1;
                if (key == "accel1") index = 1;
                if (key == "accel2") index = 2;
                UpdateNode(key, index);
                CallOnUpdateComplete();
            }
            else
            {
                RequestVerification(key);
                RequestVerification("all");
            }
        }

        private void UpdateCommandAddress(int index)
        {
            if (activeType != TrickAccelType.Specials)
                return;

            // we aren't going to allow updating addresses yet
        }

        private void OnCharacterSelect(object sender, EventArgs e)
        {
            // verify

            if (VerifyChanges("all"))
            {
                UpdateCharacterSelect();
            }
            else
            {
                cbCharacterSel.SelectedIndex = unitIndex;
            }

        }

        private void OnSelectBank(object sender, EventArgs e)
        {
            if (VerifyChanges("all"))
            {

                UpdateBankSelect();
            }
            else
            {
                cbBankSel.SelectedIndex = bankIndex;
            }

            /*
            UpdateNode();
            UpdateInputSpecNode();

            UpdateAccelNode(1);
            UpdateAccelNode(2);
            */

            
        }

        private void OnSelectCommand(object sender, EventArgs e)
        {
            // we arent allowing any changes to the command yet
            UpdateCommandSelect();
        }

        private void OnSetCommand(object sender, EventArgs e)
        {
            commandSet.CommandMap.ReplaceMap(unitCommandIndex, UserCommandMap.GetCommand(globalCommandIndex));
            UpdateSelectedCommandText();
        }

        private void UpdateSelectedCommandText()
        {
            string tag = UserCommandMap.GetCommand(globalCommandIndex).Tag;
            if (tag == "")
                tag = commandSet.CommandMap.GetMap(globalCommandIndex).Address.ToString("X8");

            tbSelectedCommand.Text = "Current: " + tag;
        }

        private void RevertTypeSelect()
        {
            allowChangeType = false;

            switch(activeType)
            {
                case TrickAccelType.StandingNormals:
                    rbStanding.Checked = true;
                    break;
                case TrickAccelType.CrouchingNormals:
                    rbCrouching.Checked = true;
                    break;
                case TrickAccelType.JumpNeutral:
                    rbNeutralJump.Checked = true;
                    break;
                case TrickAccelType.JumpBack:
                    rbBackJump.Checked = true;
                    break;
                case TrickAccelType.JumpForward:
                    rbForwardJump.Checked = true;
                    break;
                case TrickAccelType.Specials:
                    rbSpecials.Checked = true;
                    break;
                
            }

            allowChangeType = true;
        }

        private void OnSelectAcceleration(object sender, EventArgs e)
        {
            if (VerifyChanges("accel1", 1))
            {
                UpdateAccelSelect(1);

                UpdateOrRequest("main");

            }
            else
            {
                cbAcceleration.SelectedIndex = accelIndex;
            }

            
        }

        private void OnSelectAcceleration2(object sender, EventArgs e)
        {
            if (VerifyChanges("accel2", 2))
            {

                UpdateAccelSelect(2);

                UpdateOrRequest("main");
                
            }

            else
            {
                cbAcceleration2.SelectedIndex = accelIndex;
            }
        }

        private void OnSelectAction(object sender, EventArgs e)
        {
            UpdateActionSelect();

            UpdateOrRequest("main");
        }


        private void OnChangeInputType(object sender, EventArgs e)
        {

            if (VerifyChanges("all"))
            {
                UpdateInputSelect();
            }
            else
            {
                cbInputType.SelectedIndex = inputIndex;
            }
            
        }

        private void OnNormalsStandingChanged(object sender, EventArgs e)
        {
            if (rbStanding.Checked)
            {
                if (allowChangeType && allowChangeType)
                {

                    if (VerifyChanges("all"))
                    {
                        UpdateTypeSelect(TrickAccelType.StandingNormals);
                    }
                    else
                    {
                        RevertTypeSelect();
                    }
                }
            }
        }

        private void OnNormalsCrouchingChanged(object sender, EventArgs e)
        {
            if (rbCrouching.Checked && allowChangeType)
            {
                if (VerifyChanges("all"))
                {
                    UpdateTypeSelect(TrickAccelType.CrouchingNormals);
                }
                else
                {
                    RevertTypeSelect();
                }

            }
        }

        private void OnSpecialsChanged(object sender, EventArgs e)
        {
            if (rbSpecials.Checked && allowChangeType)
            {
                if (VerifyChanges("all"))
                {
                    UpdateTypeSelect(TrickAccelType.Specials);
                }
                else
                {
                    RevertTypeSelect();
                }
            }
        }



        private void OnNeutralJumpChanged(object sender, EventArgs e)
        {
            if (rbNeutralJump.Checked && allowChangeType)
            {
                if (VerifyChanges("all"))
                {
                    UpdateTypeSelect(TrickAccelType.JumpNeutral);
                }
                else
                {
                    RevertTypeSelect();
                }
            }
        }

        private void OnJumpForwardChanged(object sender, EventArgs e)
        {
            if (rbForwardJump.Checked && allowChangeType)
            {
                if (VerifyChanges("all"))
                {
                    UpdateTypeSelect(TrickAccelType.JumpForward);
                }
                else
                {
                    RevertTypeSelect();
                }
            }
        }

        private void OnJumpBackChanged(object sender, EventArgs e)
        {
            if (rbBackJump.Checked && allowChangeType)
            {
                if (VerifyChanges("all"))
                {
                    UpdateTypeSelect(TrickAccelType.JumpBack);
                }
                else
                {
                    RevertTypeSelect();
                }
            }
        }
        
        private void OnClickModifyCommand(object sender, EventArgs e)
        {
            ModifyUserCommand form = new ModifyUserCommand(activeData, globalCommandIndex);

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                cbCommand.SelectedIndex = form.CommandIndex;
                UpdateCommandSelect();

            }
        }

        private void OnAccel1TextChanged(object sender, EventArgs e)
        {
            if (((BitEdit)sender).ChangeType == BitEditChange.Input)
            {
                UpdateOrRequest("accel1");
            }
        }

        private void OnAccel2TextChanged(object sender, EventArgs e)
        {
            if (((BitEdit)sender).ChangeType == BitEditChange.Input)
            {

                UpdateOrRequest("accel2");
            }
        }

        private void OnInputSpecTextChanged(object sender, EventArgs e)
        {
            if (((BitEdit)sender).ChangeType == BitEditChange.Input)
            {

                UpdateOrRequest("inputSpec");
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyAction.Process(ModifierKeys, keyData))
                return true;

            return base.ProcessCmdKey(ref msg, keyData);
        }



        public void SetSaveDelegate()
        {
            SaveHandler.BeforeSaveEvent += OnSave;
        }

        public void OnSave()
        {
            UpdateAll(-1);
        }

        public void CallOnUpdateComplete()
        {
            if (OnUpdateComplete != null)
            {
                OnUpdateComplete();
            }
        }

        private void btnToStream_Click(object sender, EventArgs e)
        {
            NodeDataStream.SaveData();
        }

        private void OnShown(object sender, EventArgs e)
        {
            EditCommandName nameEditor = new EditCommandName(this, keyAction);
            nameEditor.Show(this);
        }

        public void UpdateUnitCommandText(int cmdIndexGlobal, string newText)
        {
            if (globalCommandIndex == cmdIndexGlobal)
            {
                cbCommand.Items[globalCommandIndex] = newText;
            }

            if (cmdIndexGlobal == UserCommandMap.GetCommandIndex(commandSet.CommandMap.GetMap(unitCommandIndex).Address))
            {
                UpdateSelectedCommandText();
            }
        }

        private void OnClickBankConfig(object sender, EventArgs e)
        {
            string specKey = NodeSpec.GetKeys(NodeType.InputSpec)[(inputIndex-1) + (bankIndex*2)];
            BankConfig config = new BankConfig((ushort)commandSet.GetInputSpec(activeType).GetValue(specKey));

            if (config.ShowDialog() == DialogResult.OK)
            {
                commandSet.GetInputSpec(activeType).SetValue(specKey, (ushort)config.Value);
            }

        }

        private ActionReference GetCurrentActionReference()
        {
            return new ActionReference(activeData.Unit.Index, (int)activeData.Group.ActionType, actionIndex, 0);
        }

        private void OnClickGoToAction(object sender, EventArgs e)
        {
            modifyActionForm = new ModifyAction();

            modifyActionForm.Show(this);
        }

    }
}
