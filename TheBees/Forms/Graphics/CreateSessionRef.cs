using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TheBees.Sprites;
using TheBees.User;

namespace TheBees.Forms
{
    public partial class CreateSessionRef : Form
    {
        public SpriteSessionRef SessionReference;

        public CreateSessionRef()
        {
            InitializeComponent();
        }

        private void OnOK(object sender, EventArgs e)
        {
            string newRef = tbNewSessionRefName.Text.Trim();

            if (newRef == "")
            {
                MessageBox.Show("Session Reference cannot be empty", "Create Session Reference");
                return;
            }

            if (SpriteSessionGuide.CheckCreationRefExists(newRef))
            {
                MessageBox.Show("Session Reference alerady exists", "Create Session Reference");
                return;
            }

            SessionReference = SpriteSessionGuide.MakeCreationReference(newRef);
            DialogResult = DialogResult.OK;
        }

        private void OnCancel(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
