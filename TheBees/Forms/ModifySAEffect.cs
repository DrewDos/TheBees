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
    public partial class ModifySAEffect : Form
    {
        private int unitIndex;
        private int saIndex;
        private ActiveDataElement activeData = ActiveData.GetDataElement(FormIndex.ModifySAEffect);
        //private DataNode activeNode;
        //private PropertyGroup activeGroup;
        private bool preventSAUpdate = false;
        static public General.BasicDelegate OnUpdateNode = null;
        private RadioButton[] rbSuperArtGroup = new RadioButton[3];

        public ModifySAEffect()
        {
            InitializeComponent();

            Initialize();
        }
        private void Initialize()
        {
            tabSAEffect.ValueChangedEvent += OnTabEditChanged;
            cbUnitSel.Items.AddRange(DescSpec.UnitNamesFromRomIndex);
            cbUnitSel.SelectedIndex = 0;
            unitIndex = 0;
            activeData.SetUnit(UnitHandler.GetUnit(unitIndex));
            rbSuperArtGroup[0] = rbSuperArt1;
            rbSuperArtGroup[1] = rbSuperArt2;
            rbSuperArtGroup[2] = rbSuperArt3;


            preventSAUpdate = true;
            rbSuperArt1.Checked = true;
            preventSAUpdate = false;
            UpdateSASelect(0);
        }

        private void UpdateUnitSelect()
        {
            unitIndex = cbUnitSel.SelectedIndex;
            activeData.SetUnit(UnitHandler.GetUnit(unitIndex));
            LoadNode();
        }

        private void UpdateSASelect(int index)
        {
            saIndex = index;
            LoadNode();

        }

        private void LoadNode()
        {
            activeData.SetDataNode(activeData.Unit.GetPropertyGroup(PropertyType.SAEffect).GetNode(saIndex));
            tabSAEffect.LoadNode(activeData.Data);
        }

        private void OnUnitSelect(object sender, EventArgs e)
        {
            if (tabSAEffect.Verification.Confirm("Update Changes", "Update Changes?"))
            {
                UpdateUnitSelect();
            }
            else
            {
                cbUnitSel.SelectedIndex = unitIndex;
            }
        }

        private void OnSelectSuperArtNum(object sender, EventArgs e)
        {
            if (!preventSAUpdate && ((RadioButton)sender).Checked )
            {
                if (tabSAEffect.Verification.Confirm("Update Changes", "Update Changes?"))
                {
                    UpdateSASelect(Convert.ToInt32(((string)((RadioButton)sender).Tag)));
                }
                else
                {
                    preventSAUpdate = true;
                    rbSuperArtGroup[saIndex].Checked = true;
                    preventSAUpdate = false;
                }
            }
        }

        private void CallOnUpdateAll()
        {
            if (OnUpdateNode != null)
                OnUpdateNode();
        }
        private void OnTabEditChanged(DataControlEventParams p)
        {
            if (Settings.AutoUpdate)
            {
                tabSAEffect.UpdateNode();
                CallOnUpdateAll();
            }
        }


    }
}
