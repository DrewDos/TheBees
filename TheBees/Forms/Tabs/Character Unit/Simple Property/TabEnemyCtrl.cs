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
using TheBees.Forms.Support.DataControl;
using TheBees.Forms.Verification;

namespace TheBees.Forms
{
    public partial class TabEnemyCtrl : PropertyLayout
    {


        protected override ComboBox PrimaryCombo { get { return cbEnemyCtrlIndex; } }
        protected override PropertyType MainType { get { return PropertyType.SettingsFooterDamage; } }

        private List<BitEdit> edits = new List<BitEdit>();

        public TabEnemyCtrl(ActiveDataElement source = null)
            : base(source)
        {
            Init();
        }

        public TabEnemyCtrl()
            : base()
        {
            Init();
        }

        public void Init()
        {
            string [] keys = NodeSpec.GetKeys(NodeType.EnemyCtrl);

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    Label label = new Label();
                    label.Text = keys[i * 6 + j];
                    BitEdit newEdit = new BitEdit();
                    newEdit.MaxValue = 0xFFFF;
                    tableLayoutPanel.Controls.Add(label, i / 2 * 2, j + (i % 2 * 6 + (i % 2 > 0 ? 1 : 0)));
                    tableLayoutPanel.Controls.Add(newEdit, i / 2 * 2 + 1, j + (i % 2 * 6 + (i % 2 > 0 ? 1 : 0)));
                    edits.Add(newEdit);
                }
            }
        }

        // fill in values for nodes
        protected override void RegisterControls()
        {

            string[] keys = NodeSpec.GetKeys(NodeType.EnemyCtrl);

            for(int i = 0; i < keys.Length; i++)
            {
                ControlSet.RegisterControl(edits[i], keys[i]);
            }
        }

        private void OnClickCopy(object sender, EventArgs e)
        {
            if (activeData.Unit.GetPropertyGroup(PropertyType.AttackDetails).CopyNodeRecorded(primaryIndex))
            {
                cbEnemyCtrlIndex.Items.Add("New Copy");
                cbEnemyCtrlIndex.SelectedIndex = cbEnemyCtrlIndex.Items.Count - 1;
            }
        }

    }
}