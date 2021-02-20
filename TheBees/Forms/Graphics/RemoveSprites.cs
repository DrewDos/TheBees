using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TheBees.User;
using TheBees.Sprites;
using TheBees.Records;

namespace TheBees.Forms
{
    public partial class RemoveSprites : Form
    {

        private int regionNum = 0;
        private int sessionNum = 0;

        public bool RegionsModified = false;
        public bool SessionsModified = false;

        private const string MessageBoxHeader = "Data Removal Confirmation";
        public RemoveSprites()
        {
            InitializeComponent();

            LoadCombos();
            tbFrom.MaxValue = SpriteSpec.MaxSpriteIndex;
            tbTo.MaxValue = SpriteSpec.MaxSpriteIndex;

            if (cbRegion.Items.Count > 0)
            {
                cbRegion.SelectedIndex = regionNum;
            }

            if (cbSession.Items.Count > 0)
            {
                cbSession.SelectedIndex = sessionNum;
            }

            UpdateEnableRegion();
            UpdateEnableSession();

            tbFrom.MinValue = 0;
            tbTo.MaxValue = Sprites.SpriteSpec.MaxSpriteIndex;

            rbByRange.Checked = true;
            chkSingleIndex.Checked = true;
            rbByRegion.Checked = false;
            rbBySession.Checked = false;

            // fire the event handlers to disable the controls properly
            ByRegionCheckedChanged(null, EventArgs.Empty);
            BySessionCheckedChanged(null, EventArgs.Empty);

        }

        private void UpdateEnableSession()
        {
            if (cbSession.Items.Count == 0)
            {
                rbBySession.Enabled = false;
                cbSession.Enabled = false;
                gbSession.Enabled = false;
            }
        }

        private void UpdateEnableRegion()
        {
            if (cbRegion.Items.Count == 0)
            {
                rbByRegion.Enabled = false;
                cbRegion.Enabled = false;
                gbRegion.Enabled = false;
            }
        }
        
        ////////////////////////////////////////
        // combo loading functions
        ////////////////////////////////////////

        private void LoadCombos()
        {
            cbRegion.Items.Clear();
            cbSession.Items.Clear();

            foreach (SpriteRegion region in SpriteRegionGuide.SpriteRegions)
            {
                cbRegion.Items.Add(region.Tag);
            }

            foreach (SpriteSessionRef reference in SpriteSessionGuide.CreationReferences)
            {
                cbSession.Items.Add(reference.Name);
            }
        }

        ////////////////////////////////////////
        // primary functions
        ////////////////////////////////////////

        private void Process()
        {
            if (rbByRegion.Checked)
            {
                string regionName = SpriteRegionGuide.SpriteRegions[regionNum].Tag;
                string msg = "Are you sure you want to remove all sprites from the region " + regionName + "?";
                if (MessageBox.Show(msg, MessageBoxHeader, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DeleteRegion(regionNum);
                    if (MessageBox.Show("Remove Region " + regionName + "?", MessageBoxHeader, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        SpriteRegionGuide.SpriteRegions.RemoveAt(regionNum);
                        cbRegion.Items.RemoveAt(sessionNum);
                        UpdateEnableRegion();
                        RegionsModified = true;
                    }
                    return;
                }
            }

            if (rbBySession.Checked)
            {
                string sessionName = SpriteSessionGuide.CreationReferences[sessionNum].Name;
                string msg = "Are you sure you want to remove all sprites from the session " + sessionName + "?";
                if (MessageBox.Show(msg, MessageBoxHeader, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                   
                    DeleteSession(sessionNum);

                    if (MessageBox.Show("Remove session?", MessageBoxHeader, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        SpriteSessionGuide.RemoveSessionRef(sessionNum);
                        cbSession.Items.RemoveAt(sessionNum);
                        UpdateEnableSession();
                        SessionsModified = true;
                    }
                }

                return;
            }

            if (rbByRange.Checked)
            {
                if (chkSingleIndex.Checked)
                {
                    string msg = "Are you sure you want to remove sprites from the index " + tbFrom.Value.ToString("X4") + "?";
                    if (MessageBox.Show(msg, MessageBoxHeader, MessageBoxButtons.YesNo) == DialogResult.Yes)

                        DeleteIndex((int)tbFrom.Value);
                }
                else
                {
                    string msg = "Are you sure you want to remove all sprite indexes from " + tbFrom.Value.ToString("X4") + " to " + tbTo.Value.ToString("X4") + "?";
                    if (MessageBox.Show(msg, MessageBoxHeader, MessageBoxButtons.YesNo) == DialogResult.Yes)
                        DeleteRange((int)tbFrom.Value, (int)tbTo.Value);
                }
                return;
            }
        }

        private void DeleteRegion(int index)
        {
            SpriteRegion region = SpriteRegionGuide.SpriteRegions[regionNum];
            RemoveSpritesShowSummary(region.GetIndexes());
        }

        private void DeleteSession(int index)
        {
            SpriteSessionRef session = SpriteSessionGuide.CreationReferences[sessionNum];
            RemoveSpritesShowSummary(session.Indexes);
        }

        private void DeleteIndex(int index)
        {
            RemoveSpritesShowSummary((int)tbFrom.Value);
        }

        private void DeleteRange(int from, int to)
        {
            List<int> indexes = new List<int>();
            for (int i = from; i <= to; i++)
            {
                indexes.Add(i);
            }

            RemoveSpritesShowSummary(indexes.ToArray());
        }

        private void RemoveSpritesShowSummary(params int[] indexes)
        {
            DataOpSummary opSummary = SpriteHandler.RemoveSpriteWithSummary(indexes);

            if (opSummary.AffectedAmt == 0)
            {
                MessageBox.Show("No sprites have been removed", MessageBoxHeader);
                return;
            }

            string summary = "Removed Indexes: " + opSummary.AffectedAmt + Environment.NewLine + Environment.NewLine + opSummary.GetFinalSummaryString();

            MessageBox.Show(summary, MessageBoxHeader, MessageBoxButtons.OK);

        }

        ////////////////////////////////////////
        // events
        ////////////////////////////////////////

        private void ByRangeCheckedChanged(object sender, EventArgs e)
        {
            tbFrom.Enabled = rbByRange.Checked;
            chkSingleIndex.Enabled = rbByRange.Checked;
            tbTo.Enabled = rbByRange.Checked && !chkSingleIndex.Checked;
        }

        private void ByRegionCheckedChanged(object sender, EventArgs e)
        {
            cbRegion.Enabled = rbByRegion.Checked;
        }

        private void BySessionCheckedChanged(object sender, EventArgs e)
        {
            cbSession.Enabled = rbBySession.Checked;
        }

        private void SingleIndexCheckedChanged(object sender, EventArgs e)
        {
            tbTo.Enabled = rbByRange.Checked && !chkSingleIndex.Checked;
        }

        private void OnSelectRegion(object sender, EventArgs e)
        {
            regionNum = cbRegion.SelectedIndex;
        }

        private void OnSelectSession(object sender, EventArgs e)
        {
            sessionNum = cbSession.SelectedIndex;
        }

        private void OnClickRemove(object sender, EventArgs e)
        {
            Process();
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
