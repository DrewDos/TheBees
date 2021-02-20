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
using TheBees.UnitData.Node;
using TheBees.General;
using TheBees.Forms.Verification;
using TheBees.Forms.Support.DataControl;

namespace TheBees.Forms
{
    public partial class TabCommandHeader : NodeLayout
    {
        CommandHeader nodeHeader;

        private int primaryIndex;
        private int changedIndex;
        private int startIndex = -1;

        public event Action<int> PrimaryIndexChanged;

        public TabCommandHeader(ActiveDataElement source)
            : base(source)
        {
        }

        public TabCommandHeader()
            : base()
        {
        }

        // fill in values for nodes
        protected override void RegisterControls()
        {
            tbOBL.MaxValue = 0xFFFF;
            tbOBM.MaxValue = 0xFFFF;
            tbOBH.MaxValue = 0xFFFF;
            tbOBEX.MaxValue = 0xFFFF;
            tbFlags.MaxValue = 0xFFFF;
            tbUndef1.MaxValue = 0xFFFF;
            tbUndef2.MaxValue = 0xFFFFFFFF;
            tbBtnConfig1.MaxValue = 0xFFFF;
            tbBtnConfig2.MaxValue = 0xFFFF;
            tbBtnConfig3.MaxValue = 0xFFFF;
            tbBtnConfig4.MaxValue = 0xFFFF;

            ControlSet.RegisterControl(tbFlags, "usableCndts");
            ControlSet.RegisterControl(tbUndef1, "undef1");
            ControlSet.RegisterControl(tbUndef2, "undef2");
            ControlSet.RegisterControl(tbBtnConfig1, "btnCfg1");
            ControlSet.RegisterControl(tbBtnConfig2, "btnCfg2");
            ControlSet.RegisterControl(tbBtnConfig3, "btnCfg3");
            ControlSet.RegisterControl(tbBtnConfig4, "btnCfg4");
            ControlSet.RegisterControl(tbOBL, new Ref<uint>(() => (uint)nodeHeader.OrbitalBasisL, (x) => nodeHeader.OrbitalBasisL = (int)x));
            ControlSet.RegisterControl(tbOBM, new Ref<uint>(() => (uint)nodeHeader.OrbitalBasisM, (x) => nodeHeader.OrbitalBasisM = (int)x));
            ControlSet.RegisterControl(tbOBH, new Ref<uint>(() => (uint)nodeHeader.OrbitalBasisH, (x) => nodeHeader.OrbitalBasisH = (int)x));
            ControlSet.RegisterControl(tbOBEX, new Ref<uint>(() => (uint)nodeHeader.OrbitalBasisEX, (x) => nodeHeader.OrbitalBasisEX = (int)x));
            ControlSet.RegisterControl(cbCommandSel, new Ref<uint>(() => (uint)primaryIndex, (x) => changedIndex = (int)x), OnChangeCommand);
        }

        protected override void OnPrimaryProceed()
        {
            UpdateCommandSelect();
            if (PrimaryIndexChanged != null)
                PrimaryIndexChanged(primaryIndex);

            base.OnPrimaryProceed();
        }

        protected override void OnPrimaryCancel()
        {
            cbCommandSel.SelectedIndex = primaryIndex;

            //base.OnPrimaryCancel();
        }
        protected override void OnLoadNode()
        {
            if (startIndex != -1)
            {
                cbCommandSel.SelectedIndex = startIndex;
                startIndex = -1;
            }
            base.OnLoadNode();

        }

        protected override void LoadLayout()
        {
            base.LoadLayout();
            
            cbCommandSel.Items.Clear();
            cbCommandSel.Items.AddRange(UserCommandMap.GetCommandNames());

            cbCommandSel.SelectedIndex = 0;
        }

        private void LoadNodeFromGroup(int index)
        {
            LoadNode(UnitCommand.AllCommands[index].GetHeader());
        }

        public void LoadNodeExternal(int index)
        {
            primaryIndex = index;
            startIndex = index;
            LoadNodeFromGroup(index);
        }

        public override void LoadNode(DataNode newNode)
        {
            nodeHeader = (CommandHeader)newNode;
            base.LoadNode(newNode);
        }


        private void UpdateCommandSelect()
        {
            LoadNodeFromGroup(primaryIndex);
        }

        private void OnChangeCommand(DataControlEventParams p)
        {
            primaryIndex = changedIndex;
            Verification.Confirm("Update changes to header?", "Update Changes?");

            OnChangeValue(p);
        }
        private void OnCommandChangeCommitted(object sender, EventArgs e)
        {

        }


    }
}