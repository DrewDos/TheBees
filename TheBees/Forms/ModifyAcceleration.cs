using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TheBees.Description;
using TheBees.UnitData;

namespace TheBees.Forms
{
    public partial class ModifyAcceleration : Form
    {
        private int unitIndex = 0;
        public int accelIndex;
        private ActiveDataElement activeData = new ActiveDataElement();
        public TabAccel AccelTab { get { return tabAccel; } }
        private bool allowSelect = false;
        private int startUnitIndex = 0;
        private int selectedIndex = -1;

        public ModifyAcceleration(int srcUnitIndex = 0, int srcAccelIndex = 0, bool srcAllowSelect = false)
        {
            InitializeComponent();
            unitIndex = srcUnitIndex;
            accelIndex = srcAccelIndex;
            allowSelect = srcAllowSelect;
            Load();
        }

        public ModifyAcceleration(ActiveDataElement srcActiveData, int srcAccelIndex = 0, bool srcAllowSelect = false)
        {

            InitializeComponent();
            unitIndex = srcActiveData.Unit.Index;
            accelIndex = srcAccelIndex;
            allowSelect = srcAllowSelect;
            Load();

        }

        private void UpdateAllowSelect(bool srcAllowSelect)
        {
            allowSelect = srcAllowSelect;
                      
        }

        private void Load()
        {
            startUnitIndex = unitIndex;
            cbUnit.Items.AddRange(DescSpec.UnitNamesFromRomIndex);
            cbUnit.Items.Add("Missile");
            cbUnit.SelectedIndex = unitIndex;
            
            btnSelect.Enabled = allowSelect;

            OnSelectUnit();
        }

        private void OnSelectUnit()
        {
            activeData.SetUnit(UnitHandler.GetUnit(unitIndex));
            tabAccel.LoadNode(accelIndex);

            btnSelect.Enabled = startUnitIndex == unitIndex;
       
        }
        private void OnChangeUnit(object sender, EventArgs e)
        {
            unitIndex = cbUnit.SelectedIndex;
            accelIndex = 0;
            OnSelectUnit();
        }

        public int GetSelectedIndex()
        {
            return selectedIndex;
        }
        private void OnClickSelect(object sender, EventArgs e)
        {
            selectedIndex = startUnitIndex == unitIndex ? tabAccel.PrimaryIndex : -1;
            DialogResult = DialogResult.OK;
        }



    }
}
