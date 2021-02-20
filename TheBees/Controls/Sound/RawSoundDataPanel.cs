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
namespace TheBees.Controls
{
    public partial class RawSoundDataPanel : UserControl
    {
        private int rawSoundIndex = 0;
        private SampleBlock activeSample;

        public RawSoundDataPanel()
        {
            InitializeComponent();

            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;

            tbRawSoundIndex.MinValue = 0x00;
            tbRawSoundIndex.MaxValue = (uint)SampleDataMap.MainGroup.SampleMap.MapCount-1;

            tbRawSoundIndex.ValueChangedEvent += OnChangeRawSoundIndex;
            rawSoundToolset.SetControls(UpdateRawSoundSelect, tbRawSoundIndex);

            rawSoundIndex = 0;
            UpdateRawSoundSelect();
        }

        public void OnChangeRawSoundIndex(NotifyParams p)
        {
            rawSoundIndex = (int)tbRawSoundIndex.Value;
            UpdateRawSoundSelect();
        }

        public void UpdateRawSoundSelect()
        {
            activeSample = SampleDataMap.MainGroup.GetSampleBlock(rawSoundIndex);

            if (activeSample == null)
            {
                InvalidSample();
            }
            else
            {
                ValidSample();
            }

        }

        private void InvalidSample()
        {
            btnDump.Enabled =
            btnReplace.Enabled = false;
            rawSoundToolset.DisableButton(DataToolButtonType.Remove);
        }

        private void ValidSample()
        {
            btnDump.Enabled =
            btnReplace.Enabled = true;
            rawSoundToolset.EnableButton(DataToolButtonType.Remove);
        }

        private void OnClickDump(object sender, EventArgs e)
        {
        }

        private void OnClickReplace(object sender, EventArgs e)
        {

        }
    }
}
