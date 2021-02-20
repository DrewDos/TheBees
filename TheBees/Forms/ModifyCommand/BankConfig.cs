using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TheBees.UnitData;
using TheBees.GameRom;

namespace TheBees.Forms
{
    public partial class BankConfig : Form
    {
        private InputConfig config;
        public ushort Value = 0;
        private bool preventUpdate = false;

        public BankConfig(ushort data)
        {
            InitializeComponent();

            config = new InputConfig(data);
            tbExclusionDistance.MaxValue = 0xFF;

            preventUpdate = true;
            if (config.Distance != 0)
            {
                rbUseDistance.Checked = true;
                rbUseDirectional.Checked = false;

                tbExclusionDistance.Value = config.Distance;

                DisableDirectional();
            }
            else
            {
                rbUseDirectional.Checked = true;
                rbUseDistance.Checked = false;

                EnableDirectional();
            }

            chkNeutral.Checked = config.N;
            chkUp.Checked = config.U;

            preventUpdate = false;

            chkDown.Checked = config.D;
            chkForward.Checked = config.F;
            chkBack.Checked = config.B;

            chkWhileRising.Checked = config.WhileRising;
            chkWhileFalling.Checked = config.WhileFalling;
            chkLenientDirectionFlag.Checked = config.LenientDirectional;
            chkStrictDirectionFlag.Checked = config.StrictDirectional;

        }

        public void EnableDirectional(bool enable = true)
        {
            chkNeutral.Enabled =
            chkUp.Enabled =
            chkDown.Enabled =
            chkForward.Enabled =
            chkBack.Enabled =

            chkWhileRising.Enabled =
            chkWhileFalling.Enabled =
            chkLenientDirectionFlag.Enabled =
            chkStrictDirectionFlag.Enabled = enable;
        }

        public void DisableDirectional()
        {
            EnableDirectional(false);
        }

        private void OnClickOK(object sender, EventArgs e)
        {
            if (rbUseDistance.Checked)
            {
                config.Distance = (byte)tbExclusionDistance.Value;
                DialogResult = DialogResult.OK;
            }
            else
            {
                config.N = chkNeutral.Checked;
                config.U = chkUp.Checked;
                config.D = chkDown.Checked;
                config.F = chkForward.Checked;
                config.B = chkBack.Checked;

                config.WhileRising = chkWhileRising.Checked;
                config.WhileFalling = chkWhileFalling.Checked;
                config.StrictDirectional = chkStrictDirectionFlag.Checked;
                config.LenientDirectional = chkLenientDirectionFlag.Checked;

                Value = config.Value;

                DialogResult = DialogResult.OK;
            }
        }

        private void OnClickCancel(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void OnRBUseDistanceCheckedChanged(object sender, EventArgs e)
        {
            if (!preventUpdate && ((RadioButton)sender).Checked)
            {
                tbExclusionDistance.Enabled = true;
                DisableDirectional();
            }
        }

        private void OnRBUseDirectionalCheckedChanged(object sender, EventArgs e)
        {
            if (!preventUpdate && ((RadioButton)sender).Checked)
            {
                tbExclusionDistance.Enabled = false;
                EnableDirectional();
            }
        }

        private void UpCheckedChanged(object sender, EventArgs e)
        {
            if (!preventUpdate && ((CheckBox)sender).Checked)
            {
                preventUpdate = true;
                chkNeutral.Checked = false;
                preventUpdate = false;
            }
        }

        private void NeutralCheckedChanged(object sender, EventArgs e)
        {

            if (!preventUpdate && ((CheckBox)sender).Checked)
            {
                preventUpdate = true;
                chkUp.Checked = false;
                preventUpdate = false;
            }
        }

        private void StrictDirectionCheckedChanged(object sender, EventArgs e)
        {
            if (!preventUpdate)
            {
                chkNeutral.Enabled = !((CheckBox)sender).Checked;
            }
        }
    }
}
