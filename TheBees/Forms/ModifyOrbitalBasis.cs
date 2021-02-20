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
using TheBees.GameData;
using TheBees.GameRom;

namespace TheBees.Forms
{
    public partial class ModifyOrbitalBasis : Form
    {
        private RadioButton[] rbSelections;
        private BitEdit[] tbAddresses;
        private Label[] lblLabels;

        private Dictionary<uint, DescriptorRef> obRefs;
        private List<uint> obIndexes;

        private int obIndex = 0;
        private int unitIndex = 0;
        private int obBaseIndex = 0;

        private OrbitalBasisGroup obGroup = null;
        private bool preventSelect = false;
        private bool preventBaseSelectUpdate = false;

        public ModifyOrbitalBasis()
        {
            InitializeComponent();

            InitPanel();
            InitUnitList();

            // get ob refs from here
            obRefs = StaticDescriptor.GetDescriptorsByTag("OrbitalBasis").OrderBy(kvp => kvp.Key).ToDictionary(kvp => kvp.Key, kvp=>kvp.Value);
            obIndexes = obRefs.Select(kvp => kvp.Key).ToList();

            unitIndex = 0;
            cbUnit.SelectedIndex = 0;
            UpdateUnitSelect();

            preventSelect = true;
            rbSelections[0].Checked = true;
            preventSelect = false;

            LoadOrbitalList();
            obBaseIndex = 0;
            preventBaseSelectUpdate = true;
            lbOBBase.SelectedIndex = obBaseIndex;
            preventBaseSelectUpdate = false;
            UpdateOBBaseSelect();
            
        }

        private void InitPanel()
        {
            List<Label> lblDescriptions = new List<Label>();
            List<RadioButton> rbButtons = new List<RadioButton>();
            List<BitEdit> tbBoxes = new List<BitEdit>();

            for (int x = 0; x < 2; x++)
            {
                for (int y = 0; y < 9; y++)
                {

                    int index = x * 9 + y;
                    Label newLabel = new Label();
                    newLabel.Padding = new Padding(0, 6, 0, 0);
                    newLabel.Text = "0x" + (index + 0x10).ToString("X2");

                    RadioButton newButton = new RadioButton();
                    //newButton.Name = "Selection_" + (x * y + y).ToString();
                    newButton.Text = "";

                    // event handler for radio buttons
                    newButton.CheckedChanged += (s, e) =>
                    {
                        if (!preventSelect && rbSelections[index].Checked)
                        {
                            OnSelectAddress(index);
                        }
                    };

                    BitEdit newEdit = new BitEdit();
                    newEdit.MaxValue = 0xFFFFFFFF;
                    newEdit.ReadOnly = true;

                    tableLayoutPanel.Controls.Add(newLabel, x * 3, y);
                    tableLayoutPanel.Controls.Add(newButton, x * 3+1, y);
                    tableLayoutPanel.Controls.Add(newEdit, x * 3+2, y);
                    
                    rbButtons.Add(newButton);
                    tbBoxes.Add(newEdit);
                    lblDescriptions.Add(newLabel);

                }
            }

            rbSelections = rbButtons.ToArray();
            tbAddresses = tbBoxes.ToArray();
        }

        private void PopulateControls()
        {
            for (int i = 0; i < UnitSpec.OrbitalBasisAddressCount; i++)
            {
                tbAddresses[i].Value = obGroup.GetValue(i);
            }
        }

        private void UpdateUnitSelect()
        {
            obGroup = ((UnitPropertyLoader)UnitHandler.GetUnit(unitIndex).PropertyLoader).OBGroup;

            PopulateControls();
        }

        private void UpdateOBBaseSelect()
        {
            tbSummary.Text = /* obIndexes[obBaseIndex].ToString("X8") + ": \r\n\r\n" + */obRefs[obIndexes[obBaseIndex]].Description;
        }

        private void InitUnitList()
        {
            cbUnit.Items.Clear();
            cbUnit.Items.AddRange(Description.DescSpec.UnitNamesFromRomIndex);
        }

        private void OnSelectAddress(int index)
        {
            obIndex = index;
        }

        private void OnUnitIndexChanged(object sender, EventArgs e)
        {
            unitIndex = cbUnit.SelectedIndex;

            UpdateUnitSelect();
        }

        private void LoadOrbitalList()
        {

            foreach (KeyValuePair<uint, DescriptorRef> currRef in obRefs)
            {
                lbOBBase.Items.Add("0x" + currRef.Key.ToString("X8"));
            }
        }

        private void OnSelectOBChanged(object sender, EventArgs e)
        {
            if (!preventBaseSelectUpdate)
            {
                obBaseIndex = lbOBBase.SelectedIndex;
                UpdateOBBaseSelect();
            }
        }

        private void OnClickSetOB(object sender, EventArgs e)
        {
            uint newOBValue = obIndexes[obBaseIndex];
            SuppleValue value = ((UnitPropertyLoader)UnitHandler.GetUnit(unitIndex).PropertyLoader).OBGroup.GetSuppleValue(obIndex);
            value.Value = obIndexes[obBaseIndex];
            value.ApplyValue();
            tbAddresses[obIndex].Value = newOBValue;
        }
    }
}
