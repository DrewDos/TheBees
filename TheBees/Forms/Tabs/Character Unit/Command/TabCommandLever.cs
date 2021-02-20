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
using TheBees.General;
using TheBees.Forms.Verification;
using TheBees.Forms.Support.DataControl;

namespace TheBees.Forms
{
    public partial class TabCommandLever : NodeLayout
    {
        private int primaryIndex;
        private int changedIndex;

        private int commandIndex = -1;
        private UnitCommand command;

        public event Action<int> PrimaryIndexChanged;

        public TabCommandLever(ActiveDataElement source = null)
            : base(source)
        {
        }

        public TabCommandLever()
            : base()
        {
        }

        protected override void OnPrimaryCancel()
        {
            cbLeverSel.SelectedIndex = primaryIndex;
            base.OnPrimaryCancel();
        }

        protected override void OnPrimaryProceed()
        {
            UpdatePrimaryIndexSelect();

            if (PrimaryIndexChanged != null)
                PrimaryIndexChanged(primaryIndex);

            base.OnPrimaryProceed();
        }
        // fill in values for nodes
        protected override void RegisterControls()
        {

            tbValue1.MaxValue = 0xFFFF;
            tbValue2.MaxValue = 0xFFFF;
            tbValue3.MaxValue = 0xFFFF;
            tbValue4.MaxValue = 0xFFFF;
            ControlSet.RegisterControl(tbValue1, "undef1");
            ControlSet.RegisterControl(tbValue2, "undef2");
            ControlSet.RegisterControl(tbValue3, "undef3");
            ControlSet.RegisterControl(tbValue4, "trans1");
            ControlSet.RegisterControl(cbLeverSel, new Ref<uint>(() => (uint)primaryIndex, (x) => changedIndex = (int)x), OnLeverSelect, "primarySelector");
        }

        public void SetCommand(int index)
        {
            if (commandIndex != index)
            {
                commandIndex = index;
                command = UserCommandMap.GetCommand(index);

                // fill up the combo box
                cbLeverSel.Items.Clear();
                cbLeverSel.Items.AddRange(DescSpec.GetIndexedList(command.GetLeverCount()));

                primaryIndex = 0;
                cbLeverSel.SelectedIndex = 0;
                UpdatePrimaryIndexSelect();
            }
        }

        private void UpdatePrimaryIndexSelect()
        {
            LoadNodeFromGroup(primaryIndex);
        }
        private void LoadNodeFromGroup(int index)
        {
            LoadNode(command.GetLever(index));
        }

        public override void LoadNode(DataNode newNode)
        {
            if (command == null)
            {
                throw new Exception("Command must be set before loading node");
            }

            base.LoadNode(newNode);
        }
        public void OnLeverSelect(DataControlEventParams p)
        {
            primaryIndex = changedIndex;
            Verification.Confirm("Update changes to lever?", "Update Changes?");

            OnChangeValue(p);
        }
    }
}