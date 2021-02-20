using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TheBees.General;

namespace TheBees.Forms
{
    public partial class SoundNodePanel : UserControl
    {
        private const int controlCount = 0x10;

        private List<SoundNodeControlGroup> controlGroups = new List<SoundNodeControlGroup>();
        public event Action<int, NotifyParams> DataValueChangedEvent;
        public SoundNodePanel()
        {
            InitializeComponent();

            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;

            for (int i = 0; i < 0x16; i++)
            {
                int index = i;
                controlGroups.Add(new SoundNodeControlGroup((x) =>
                {
                    if (DataValueChangedEvent != null)
                        DataValueChangedEvent(index, x);
                }));
                tableLayoutPanel1.Controls.Add(controlGroups[i].CodeDisplay, 0, i);
                tableLayoutPanel1.Controls.Add(controlGroups[i].Edit, 1, i);
                controlGroups[i].Hide();
            }
        }

        public void ClearValues()
        {
            controlGroups.ForEach((x) => x.ClearValues());
        }

        public void SetControl(int index, byte code, byte [] values)
        {
            if (index < 0 || index >= controlCount)
                return;

            controlGroups[index].LoadValues(code, values);
        }

        public void SetControlsComplete()
        {

            for (int i = 0; i < controlCount; i++)
            {
                if (controlGroups[i].HasValues)
                {
                    controlGroups[i].Show();
                }
                else
                {
                    controlGroups[i].Clear();
                    controlGroups[i].Hide();
                }
            }
        }

        public void Clear()
        {
            controlGroups.ForEach((x) => { x.Clear(); x.Hide(); });
        }
    }

    public class SoundNodeControlGroup
    {
        private byte code;
        private List<byte> values = new List<byte>();
        private TextBox codeDisplay;
        private BitEdit edit;

        public TextBox CodeDisplay { get { return codeDisplay; } }
        public BitEdit Edit { get { return edit; } }

        public bool HasValues { get { return values != null && values.Count > 0; } }

        public SoundNodeControlGroup(NotifyObserver valueChangedAction)
        {
            if (valueChangedAction == null)
                throw new Exception("Value Changed Action cannot be null");

            edit = new BitEdit();
            codeDisplay = new TextBox();


            codeDisplay.ReadOnly = true;

            edit.MinValue = 0x00000000;
            edit.MaxValue = 0xFFFFFFFF;
            edit.ValueChangedEvent += (x) => valueChangedAction(x);
        }

        public void Clear()
        {
            edit.Value = 0;
            codeDisplay.Text = "";
            ClearValues();
            code = 0x00;
        }

        public void ClearValues()
        {
            values.Clear();
        }
        public void Hide()
        {
            edit.Hide();
            codeDisplay.Hide();
        }

        public void Show()
        {
            edit.Show();
            codeDisplay.Show();
        }
        public void LoadValues(byte newCode, byte [] srcValues)
        {
            code = newCode;
            values.Clear();
            values.AddRange(srcValues);

            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            uint displayData = 0x00;
            int i = 0;

            foreach (byte value in values)
            {
                uint uintValue = value;
                displayData += (uintValue << (i * 8));
                i++;
            }

            edit.Value = displayData;
            codeDisplay.Text = "0x" + code.ToString("X2");


        }

    }
}
