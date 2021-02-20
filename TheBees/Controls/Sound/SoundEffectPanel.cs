using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TheBees.General;
using TheBees.Sound;
using TheBees.User;
using TheBees.Description;

namespace TheBees.Controls
{
    public partial class SoundEffectPanel : UserControl
    {
        private int effectIndex;
        private int nodeIndex;

        private SoundEffect activeSoundEffect;
        private SampleNode activeSampleNode;

        public SoundEffectPanel()
        {
            InitializeComponent();

            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
                Init();
        }

        private void Init()
        {
            // setup sound effect panel
            soundNodePanel.DataValueChangedEvent += OnDataValueChanged;
            uint [] tmpIndexes = SoundEffectMap.MainGroup.GetValidIndexes();
            tbSoundIndex.SetMode(BitEditMode.ByValues, tmpIndexes);
            tbSoundIndex.Value = tmpIndexes[0];
            effectIndex = (int)tmpIndexes[0];

            cbNodeIndex.Items.AddRange(DescSpec.GetIndexedList(0x10));
            cbNodeIndex.SelectedIndex = 0;
            nodeIndex = 0;

            tbSoundIndex.ValueChangedEvent += OnChangeSoundIndex;

            // setup raw header guide panel
            UpdateEffectSelect();
        }
        private void OnChangeSoundIndex(NotifyParams p)
        {
            effectIndex = (int)p.Value;
            UpdateEffectSelect();
        }

        private void OnDataValueChanged(int index, NotifyParams p)
        {
            activeSoundEffect.SampleNodes[nodeIndex].UpdateData(index, (uint)p.Value);
        }

        private void UpdateEffectSelect()
        {
            activeSoundEffect = SoundEffectMap.MainGroup.GetSoundEffect(effectIndex);

            if (activeSoundEffect == null || activeSoundEffect.ValidNodeIndexes.Length == 0)
            {
                NoSoundEffect();
                return;
            }

            SoundEffectValid();

            string descTxt = RecordTagGuide.GetRecordTag(activeSoundEffect.Address);
            if (descTxt == "") descTxt = activeSoundEffect.Address.ToString("X8");
            tbDescription.Text = descTxt;


            cbNodeIndex.Items.Clear();
            int[] nodeIndexes = activeSoundEffect.ValidNodeIndexes;
            foreach (int index in nodeIndexes)
            {
                cbNodeIndex.Items.Add(index.ToString("X2"));
            }
            nodeIndex = nodeIndexes[0];
            cbNodeIndex.SelectedIndex = 0;

            UpdateNodeSelect();

        }

        private void UpdateNodeSelect()
        {
            activeSampleNode = activeSoundEffect.SampleNodes[nodeIndex];

            if (activeSampleNode != null && activeSampleNode.Values.Count > 0)
            {
                soundNodePanel.ClearValues();
                for (int i = 0; i < activeSampleNode.Values.Count; i++)
                {
                    SampleNodeValue node = activeSampleNode.Values[i];
                    soundNodePanel.SetControl(i, node.Code, node.Values);
                }

                soundNodePanel.SetControlsComplete();
            }
            else
            {
                soundNodePanel.Clear();
            }

        }

        private void SoundEffectValid()
        {
            cbNodeIndex.SelectedIndex = 0;
            nodeIndex = 0;
            cbNodeIndex.Enabled = true;
            soundNodePanel.Enabled = true;

        }

        private void NoSoundEffect()
        {
            cbNodeIndex.SelectedIndex = 0;
            nodeIndex = 0;
            cbNodeIndex.Enabled = false;
            tbDescription.Text = "";
            soundNodePanel.Clear();
            soundNodePanel.Enabled = false;
        }

        private void OnChangeNodeIndex(object sender, EventArgs e)
        {
            nodeIndex = activeSoundEffect.ValidNodeIndexes[cbNodeIndex.SelectedIndex];

            UpdateNodeSelect();
        }

    }
}
