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
    public partial class CreateRegion : Form
    {
        public SpriteRegion NewRegion;

        public CreateRegion()
        {
            InitializeComponent();
        }

        private void OnOK(object sender, EventArgs e)
        {
            string newName = tbRegionName.Text;
            newName = newName.Trim();

            if (newName == "")
            {
                MessageBox.Show("Tag cannot be empty", "New Region");
                return;
            }
            if (SpriteRegionGuide.RegionExistsByTag(newName))
            {
                MessageBox.Show("Tag \"" + newName + "\" already exists", "New Region");
                return;
            }

            if (!ValidateRange())
            {
                MessageBox.Show("Range not valid", "New Region");
                return;
            }

            NewRegion = SpriteRegionGuide.CreateSpriteRegion((int)tbFromIndex.Value, (int)tbToIndex.Value, newName);
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private bool ValidateRange()
        {
            if(tbFromIndex.Value > tbToIndex.Value || tbToIndex.Value < tbFromIndex.Value )
                return false;

            return true;
        }

        private void OnCancel(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
