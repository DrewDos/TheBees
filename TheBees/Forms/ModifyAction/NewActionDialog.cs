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
    public partial class NewActionDialog : Form
    {
        public ActionReference Reference;
        private int sizeInBytes;
        public UnitAction NewAction;

        public NewActionDialog()
        {
            InitializeComponent();

            sizeInBytes = 8;
            rb8Byte.Checked = true;
        }

        private void OnClickSelect(object sender, EventArgs e)
        {

            NewAction = UnitAction.CreateRecordable(Reference, sizeInBytes, chkAddFooter.Checked);
            DialogResult = DialogResult.OK;

        }

        private void OnClickCancel(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void On8ByteCheckedChanegd(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                sizeInBytes = 8;
            }
        }

        private void On16ByteCheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                sizeInBytes = 16;
            }
        }

        private void On24ByteCheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                sizeInBytes = 24;
            }

        }

        private void OnShown(object sender, EventArgs e)
        {
            if (Reference == null)
                throw new Exception("Reference has not been set");
        }
    }
}
