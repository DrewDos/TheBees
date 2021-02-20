using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TheBees.Data;
using TheBees.GameRom;
using TheBees.Sound;
using TheBees.Description;

namespace TheBees.Controls
{
    public partial class RawSoundGuidePanel : UserControl
    {
        private int valueCount;

        private int groupIndex;
        private int guideIndex;

        private Label[] labels;
        private BitEdit [] edits;

        private RawSampleGroup currGroup = null;
        private DataNode currNode = null;

        public RawSoundGuidePanel()
        {
            InitializeComponent();

            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;

            tbGuideIndex.ValueChangedEvent += (x) =>
            {
                guideIndex = (int)tbGuideIndex.Value;
                UpdateGuideSelect();
            };
            tbGuideIndex.MinValue = 0x00;
            tbGuideIndex.MaxValue = 0x100 / 2 - 1;

            valueCount = NodeSpec.ValueSizes[NodeType.RawSampleHeader].Length;
            labels = new Label[valueCount];
            edits = new BitEdit[valueCount];

            for (int i = 0; i < valueCount; i++)
            {
                Label newLabel = new Label();
                newLabel.Text = "Index " + i.ToString("X2");

                BitEdit edit = new BitEdit();
                edit.SetMode(BitEditMode.Ranged);
                edit.MinValue = 0x00;
                edit.MaxValue = (uint)(NodeSpec.ValueSizes[NodeType.RawSampleHeader][i]*0x100-1);
                edit.Tag = NodeSpec.GetKeys(NodeType.RawSampleHeader)[i];
                edit.ValueChangedEvent += (x) =>
                {
                    currNode.SetValue(((string)edit.Tag), (uint)x.Value);
                    currNode.ApplyBuffer();
                };

                tableLayoutPanel.Controls.Add(newLabel, 0 + 2 * (i >= valueCount / 2 ? 1 : 0), i - (i >= valueCount / 2 ? valueCount / 2 : 0));
                tableLayoutPanel.Controls.Add(edit, 1 + 2 * (i >= valueCount / 2 ? 1 : 0), i - (i >= valueCount / 2 ? valueCount / 2 : 0));
                labels[i] = newLabel;
                edits[i] = edit;
            }

            groupIndex = 0;
            cbGroupIndex.Items.AddRange(DescSpec.GetIndexedList(0x10));
            cbGroupIndex.SelectedIndex = 0;
            UpdateGroupSelect();
        }

        private void ValidGroup()
        {
            Array.ForEach(edits, (x) => x.Enabled = true);
            Array.ForEach(labels, (x) => x.Enabled = true);
        }

        private void InvalidGroup()
        {
            Array.ForEach(edits, (x) => { x.Enabled = false; x.Value = 0;});
            Array.ForEach(labels, (x) => x.Enabled = false);
        }

        public void UpdateGroupSelect()
        {
            currGroup = RawSampleHeaderMap.GetRawSampleGroup(groupIndex);

            guideIndex = 0;
            tbGuideIndex.Value = 0;
            UpdateGuideSelect();
        }

        public void UpdateGuideSelect()
        {
            if (currNode != null)
            {
                currNode.ApplyBuffer();
                currNode.ClearBuffer();
            }

            currNode = currGroup.GetSampleHeader(guideIndex);

            if (currNode == null)
            {
                InvalidGroup();
                return;
            }

            ValidGroup();

            currNode.BufferValues();
            LoadNode(currNode);
        }

        public void LoadNode(DataNode srcNode)
        {
            for (int i = 0; i < srcNode.Values.Length; i++)
            {
                edits[i].Value = srcNode.Values[i].Value;
            }
        }

        private void OnChangeGroupIndex(object sender, EventArgs e)
        {
            groupIndex = cbGroupIndex.SelectedIndex;
            UpdateGroupSelect();
        }
    }
}
