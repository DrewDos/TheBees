using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TheBees.GameRom;

namespace TheBees.Forms
{
    public partial class RecordSummary : Form
    {
        public RecordSummary()
        {
            InitializeComponent();

            NodeSequence.OnRecordableAction += UpdateRecordSummary;
            UpdateRecordSummary();
        }

        private void UpdateRecordSummary()
        {
            //tbRecordSummary.Text = Debugging.GetRecordSummary();
        }
    }
}
