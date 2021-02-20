using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TheBees.UnitData;

namespace TheBees.Forms
{
    public partial class CancelConfig : Form
    {
        private CancelSpec spec;
        private ushort specValue;
        public ushort SpecValue { get { return specValue; } }

        private RadioButton [] directionals = new RadioButton[0x10];

        public CancelConfig(ushort startValue)
        {
            InitializeComponent();

            spec = new CancelSpec(startValue);

            directionals[0] = rbNone;
            directionals[1] = rbDF;
            directionals[2] = rbD;
            directionals[3] = rbDB;
            directionals[4] = rbF;
            directionals[5] = rbN;
            directionals[6] = rbB;
            directionals[7] = rbUF;
            directionals[8] = rbU;
            directionals[9] = rbUB;
            directionals[0x0C] = rbForN;
            directionals[0x0D] = rbBorN;
            directionals[0x0E] = rbBorF;
            directionals[0x0F] = rbBForN;
            directionals[0x0A] = rbNoDBDDF;
            directionals[0x0B] = rbNoUBUUF;

            SetControls();

        }

        private void SetControls()
        {
            directionals[(int)spec.Direction].Checked = true;
            chkStrictDirections.Checked = spec.StrictDirections;

            chkLP.Checked = spec.LP;
            chkMP.Checked = spec.MP;
            chkHP.Checked = spec.HP;
            chkLK.Checked = spec.LK;
            chkMK.Checked = spec.MK;
            chkHK.Checked = spec.HK;

            if (spec.Target == CancelTarget.Any)
                rbCancelToAnything.Checked = true;
            else
                rbCancelToTarget.Checked = true;
        }
        private void OnCancel(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void OnClickOK(object sender, EventArgs e)
        {
            spec.LP = chkLP.Checked;
            spec.MP = chkMP.Checked;
            spec.HP = chkHP.Checked;
            spec.LK = chkLK.Checked;
            spec.MK = chkMK.Checked;
            spec.HK = chkHK.Checked;
            int index = Array.IndexOf(directionals, Array.Find(directionals, (x) => x.Checked));
            spec.StrictDirections = chkStrictDirections.Checked;
            spec.Direction = (CancelDirection)index;
            spec.Target = rbCancelToTarget.Checked ? CancelTarget.Target : CancelTarget.Any;

            specValue = spec.Value;

            DialogResult = DialogResult.OK;
        }
    }
}
