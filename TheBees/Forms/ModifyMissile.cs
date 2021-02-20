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
using TheBees.Forms.Verification;

namespace TheBees.Forms
{
    public partial class ModifyMissile : Form, IModifyForm
    {
        private int configIndex;
        private NodeSequence nodes;
        private NodePanel panel;
        protected ActiveDataElement activeData = ActiveData.GetDataElement(FormIndex.ModifyMissileDef);
        //private VerifyHandler vfh;

        public ModifyMissile()
        {
            InitializeComponent();


            activeData.SetUnit(UnitHandler.GetUnit(0x15));

            toolsMissile.SetControls(null, cbMissileSelect);
            toolsMissile.SetPropertyGroup(activeData.Unit.GetPropertyGroup(PropertyType.MissileConfig));
            toolsMissile.ComboChangedEvent += (x) => UpdateMissileSelect();
            

            cbMissileSelect.Items.AddRange(DescSpec.GetIndexedList(activeData.Unit.GetPropertyGroup(PropertyType.MissileConfig).Count));
            cbMissileSelect.SelectedIndex = 0;

            UpdateMissileSelect();
        }

        private void Init()
        {
        }

        private void UpdateMissileSelect()
        {
            configIndex = cbMissileSelect.SelectedIndex;
            tabMissileConfig1.LoadNode(configIndex);
            lblDataAddress.Text = tabMissileConfig1.Node.Address.ToString("X8");

        }

        private void OnMissileSelectCommitted(object sender, EventArgs e)
        {
            UpdateMissileSelect();
        }

        public void SetSaveDelegate()
        {
        }

        public void OnSave()
        {
        }

        private void OnCopyDef(object sender, EventArgs e)
        {
        }
    }
}
