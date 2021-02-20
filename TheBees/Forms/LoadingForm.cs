using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TheBees.Forms
{
    public partial class LoadingForm : Form
    {
        public LoadingForm()
        {
            InitializeComponent();
        }

        public void SetMessage(string message)
        {
            lblMessage.Text = message;
        }

        public void SetProgressMax(int value)
        {
            progressBar.Maximum = value;
        }

        public void SetProgress(int value)
        {
            progressBar.Value = value;
        }

        public void UpdateLoading()
        {
        }
    }
}
