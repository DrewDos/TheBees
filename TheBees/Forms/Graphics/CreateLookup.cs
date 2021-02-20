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
using TheBees.Data;

namespace TheBees.Forms
{
    public partial class CreateLookup : Form
    {
        public LookupTag NewTag;

        public CreateLookup()
        {
            InitializeComponent();
        }

        private void OnClickCancel(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void OnOK(object sender, EventArgs e)
        {
            string newName = tbNewLookupName.Text;
            newName = newName.Trim();

            if (newName == "")
            {
                MessageBox.Show("Tag cannot be empty", "New Tag");
                return;
            }
            if (LookupTagGuide.LookupTags.ToList().Find((x) => x.Tag == newName) != null)
            {
                MessageBox.Show("Tag \"" + newName + "\" already exists", "New Tag");
                return;
            }

            RomDataBlock newTable = LookupBlock.CreateLookupTable();
            NewTag = LookupTagGuide.CreateLookupTag(newTable.Address, newName);

            DialogResult = System.Windows.Forms.DialogResult.OK;
            
        }
    }
}
