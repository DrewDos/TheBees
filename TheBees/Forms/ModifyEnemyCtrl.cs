using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TheBees.UnitData;
using TheBees.Description;
using TheBees.GameRom;
using TheBees.Forms.Support.DataControl;

namespace TheBees.Forms
{
    public partial class ModifyEnemyCtrl : Form
    {
        private int unitIndex;
        private ActiveDataElement activeData = ActiveData.GetDataElement(FormIndex.ModifySAEffect);

        static public General.BasicDelegate OnUpdateNode = null;
        private RadioButton[] rbSuperArtGroup = new RadioButton[3];

        public ModifyEnemyCtrl()
        {
            InitializeComponent();

            Initialize();
        }
        private void Initialize()
        {
            cbUnitSel.Items.AddRange(DescSpec.UnitNamesFromRomIndex);
            cbUnitSel.SelectedIndex = 0;
            unitIndex = 0;
            activeData.SetUnit(UnitHandler.GetUnit(unitIndex));
            UpdateUnitSelect();
        }

        private void UpdateUnitSelect()
        {
            unitIndex = cbUnitSel.SelectedIndex;
            activeData.SetUnit(UnitHandler.GetUnit(unitIndex));
            tabEnemyCtrl1.LoadNode(0);
        }

        private void CallOnUpdateAll()
        {
            if (OnUpdateNode != null)
                OnUpdateNode();
        }

        private void OnUnitSelect(object sender, EventArgs e)
        {
            if (tabEnemyCtrl1.Verification.Confirm("Update Changes", "Update Changes?"))
            {
                UpdateUnitSelect();
            }
            else
            {
                cbUnitSel.SelectedIndex = unitIndex;
            }
        }

        private void OnTabEditChanged(DataControlEventParams p)
        {
            if (Settings.AutoUpdate)
            {
                //tabSAEffect.UpdateNode();
                CallOnUpdateAll();
            }
        }


    }
}
