using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TheBees.GameRom;
using TheBees.General;

namespace TheBees.Forms.Support.DataControl.DerivedControls
{
    class DataControlCheckBox : DataControl
    {
        private CheckBox control;

        protected override Control MainControl { get { return control; } }
        protected override Control[] MainControlSet { get { return null; } }

        public DataControlCheckBox(Control control, NodeSuppleValue value)
            : base(control, value)
        {
            this.control.CheckedChanged += OnValueChanged;
        }

        public DataControlCheckBox(Control control, Ref<uint> reference)
            : base(control, reference)
        {
            this.control.CheckedChanged += OnValueChanged;
        }

        protected override void SetControl(Control srcControl)
        {
            control = ((CheckBox)srcControl);
        }

        protected override void DoUpdateValue()
        {
            Value = (uint)(control.Checked ? 1 : 0);
        }

        protected override void DoUpdateControl()
        {
            control.Checked = Value > 0 ? true : false;
        }

        protected override void DoUpdateControl(object value)
        {
            if (!(value is bool))
                throw new ArgumentException("Object must be bool");

            control.Checked = (bool)value;
        }

        protected override uint GetNotifyValue(Object sender)
        {
            return (uint)(control.Checked ? 1 : 0);
        }
    }
}
