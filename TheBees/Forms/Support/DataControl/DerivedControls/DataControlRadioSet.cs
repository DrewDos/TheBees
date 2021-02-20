using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TheBees.GameRom;
using TheBees.General;

namespace TheBees.Forms.Support.DataControl.DerivedControls
{
    class DataControlRadioSet : DataControl
    {
        RadioButton[] controls;

        protected override Control MainControl { get { return null; } }
        protected override Control[] MainControlSet { get { return controls; } }

        public DataControlRadioSet(Control [] srcControls, NodeSuppleValue value)
            : base(srcControls, value)
        {
            controls = (RadioButton[])srcControls;
        }

        public DataControlRadioSet(Control[] srcControls, Ref<uint> reference)
            : base(srcControls, reference)
        {
            SetupUpdateCallbacks();
        }

        private void SetupUpdateCallbacks()
        {
            foreach (RadioButton rb in controls)
            {
                RadioButton btnTarget = rb;
                rb.CheckedChanged += (o, e) => { if (btnTarget.Checked && !PreventControlEvent) OnValueChanged(o, e); };
            }
        }
        protected override uint GetNotifyValue(Object sender)
        {
            return Convert.ToUInt32(((RadioButton)sender).Tag);
        }
        protected override void SetControl(Control [] srcControl)
        {
            controls = new RadioButton[srcControl.Length];
            for (int i = 0; i < srcControl.Length; i++)
            {
                controls[i] = (RadioButton)srcControl[i];
            }
        }

        protected override void DoUpdateValue()
        {
            Value = Convert.ToUInt32(Array.Find(controls, x => x.Checked == true).Tag);
        }


        protected override void DoUpdateControl(object value)
        {
            if (!(value is int))
                throw new ArgumentException("Object must be bool");

            RadioButton button = Array.Find(controls, (x) => ((int)x.Tag) == (int)value);

            if (button != null)
            {
                button.Checked = true;
                Array.ForEach(controls, (x) => { if (((int)x.Tag) != (int)value) x.Checked = false; });
            }
            else
            {
                throw new ArgumentException("Control not found");
            }
        }
        protected override void DoUpdateControl()
        {
            Array.Find(controls, (x) => ((int)x.Tag) == Value).Checked = true;
        }
    }
}
