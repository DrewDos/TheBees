using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

using TheBees.Sound;
using TheBees.Description;
using TheBees.User;
using TheBees.General;

namespace TheBees.Forms
{
    public partial class SoundEffectManager : Form
    {

        private EditModeSelection editMode = EditModeSelection.None;
        private Dictionary<EditModeSelection, UserControl> panels;

        public SoundEffectManager()
        {
            InitializeComponent();

            panels = new Dictionary<EditModeSelection, UserControl>()
            {
                {EditModeSelection.SoundEffect, soundEffectPanel1},
                {EditModeSelection.RawData, rawSoundDataPanel1},
                {EditModeSelection.RawGuide, rawSoundGuidePanel1},
            };
            rawSoundDataPanel1.Visible = false;
            rawSoundGuidePanel1.Visible = false;
            soundEffectPanel1.Visible = false;

            rbSoundEffect.Checked = true;
        }

        private void UpdateModeSelect(EditModeSelection newSelection)
        {
            if(editMode == newSelection)
                return;

            if (editMode != EditModeSelection.None)
            {
                panels[editMode].Hide();
            }
            editMode = newSelection;
            panels[editMode].Show();
        }

        private void RawDataCheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                UpdateModeSelect(EditModeSelection.RawData);
            }

        }

        private void RawDataGuideCheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                UpdateModeSelect(EditModeSelection.RawGuide);
            }

        }

        private void SoundEffectCheckedChanged(object sender, EventArgs e)
        {

            if (((RadioButton)sender).Checked)
            {
                UpdateModeSelect(EditModeSelection.SoundEffect);
            }

        }

        private void OnClickCheckSox(object sender, EventArgs e)
        {
            
        }

        private void OnRemoveSprite(object sender, EventArgs e)
        {

        }

        private void OnRemoveSound(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x20; i++)
            {
                if (SampleDataMap.MainGroup.GetSampleBlock(i) != null)
                {
                    SampleDataMap.MainGroup.ClearBlock(i);
                }
            }
        }

        private void OnPingIndexes(object sender, EventArgs e)
        {
            SampleDataMap.MainGroup.UpdateAddressList();
        }


    }

    public enum EditModeSelection
    {
        None,
        SoundEffect,
        RawGuide,
        RawData
    }
}
