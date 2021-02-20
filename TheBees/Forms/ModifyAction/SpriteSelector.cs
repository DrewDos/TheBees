using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TheBees.UnitData;
using TheBees.User;
using TheBees.Sprites;
using TheBees.General;

namespace TheBees.Forms
{
    public partial class SpriteSelector : Form
    {

        public event Action<int> SpriteIndexChangedEvent;
        private SpriteSessionRef activeSessionRef;
        private SpriteRegion activeRegion;
        private bool usingRegion = false;
        private bool usingSessionRef = false;
        private bool hasRegion = false, hasSession = false;
        private int rangeIndex = 0;
        private bool activated = false;

        public SpriteSelector()
        {
            InitializeComponent();

            hasSession = SpriteSessionGuide.CreationReferences.Count > 0;
            hasRegion = SpriteRegionGuide.SpriteRegions.Count > 0;

            rbByRegion.Enabled = hasRegion;
            rbBySession.Enabled = hasSession;
            tbGraphicIndex.ValueChangedEvent += SpriteIndexChanged;

            if(hasRegion)
            {
                usingRegion = true;
                rbByRegion.Checked = true;
            }
            else if (hasSession)
            {
                usingSessionRef = true;
                rbBySession.Checked = true;
            }

            UpdateMainList();

        }

        public void ActivateSelector()
        {
            rbByRegion.Enabled = hasRegion;
            rbBySession.Enabled = hasSession;
            cbRangeSelection.Enabled = (hasSession || hasRegion);
            tbGraphicIndex.Enabled = (hasSession || hasRegion);
            btnSetValue.Enabled = (hasSession || hasRegion);
            activated = true;
        }

        public void DeactivateSelector()
        {

            rbByRegion.Enabled =
            rbBySession.Enabled =
            cbRangeSelection.Enabled =
            tbGraphicIndex.Enabled =
            btnSetValue.Enabled = 
            activated = false;
        }

        private void UpdateMainList()
        {
            cbRangeSelection.Items.Clear();
            if (usingSessionRef)
            {
                cbRangeSelection.Items.AddRange(SpriteSessionGuide.GetSessionNames());
            }
            else if (usingRegion)
            {
                cbRangeSelection.Items.AddRange(SpriteRegionGuide.GetRegionNames());
            }

            if (usingSessionRef || usingRegion)
            {
                rangeIndex = 0;
                cbRangeSelection.SelectedIndex = rangeIndex;
                UpdateRangeSelect();
            }

        }

        private void UpdateRangeSelect()
        {
            if (usingSessionRef)
            {
                activeSessionRef = SpriteSessionGuide.CreationReferences[rangeIndex];
                UpdateSessionSelect();
                return;
            }

            if (usingRegion)
            {
                activeRegion = SpriteRegionGuide.SpriteRegions[rangeIndex];
                UpdateRegionSelect();
                return;
            }
        }

        private void UpdateValue()
        {
            if (SpriteIndexChangedEvent != null)
                SpriteIndexChangedEvent((int)tbGraphicIndex.Value);
        }

        private void UpdateSessionSelect()
        {
            List<uint> indexes = new List<uint>();
            Array.ForEach(activeSessionRef.Indexes, (x) => indexes.Add((uint)x));

            tbGraphicIndex.SetMode(BitEditMode.ByValues, indexes.ToArray());
            tbGraphicIndex.Value = indexes[0];
            if(chkAutoSet.Checked) UpdateValue();
        }

        private void SpriteIndexChanged(NotifyParams p)
        {
            if (chkAutoSet.Checked)
            {
                if (SpriteIndexChangedEvent != null)
                    SpriteIndexChangedEvent(p.Value);
            }
        }

        private void UpdateRegionSelect()
        {
            tbGraphicIndex.SetMode(BitEditMode.Ranged);
            tbGraphicIndex.MinValue = (uint)activeRegion.StartIndex;
            tbGraphicIndex.MaxValue = (uint)activeRegion.LastIndex;
            tbGraphicIndex.Value = (uint)activeRegion.StartIndex;
            if (chkAutoSet.Checked) UpdateValue();

        }

        private void OnBySessionCheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked && activated)
            {
                usingRegion = false;
                usingSessionRef = true;
                UpdateMainList();
            }
        }

        private void OnByRegionCheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked && activated)
            {
                usingSessionRef = false;
                usingRegion = true;
                UpdateMainList();
            }
        }

        private void OnRangeSelectCommitted(object sender, EventArgs e)
        {
            rangeIndex = cbRangeSelection.SelectedIndex;

            UpdateRangeSelect();
        }

        private void OnClickSetValue(object sender, EventArgs e)
        {
            UpdateValue();
        }

        private void OnAutoSetCheckedChanged(object sender, EventArgs e)
        {
            if(((CheckBox)sender).Checked)
            {
                UpdateValue();
            }
        }
    }
}
