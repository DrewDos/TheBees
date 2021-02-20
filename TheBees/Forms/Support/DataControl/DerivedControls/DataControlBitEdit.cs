using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TheBees.GameRom;
using TheBees.General;

namespace TheBees.Forms.Support.DataControl.DerivedControls
{
    public class DataControlBitEdit : DataControl
    {
        private BitEdit control;

        protected override Control MainControl { get { return control; } }
        protected override Control[] MainControlSet { get { return null; } }

        public DataControlBitEdit(Control control, NodeSuppleValue value)
            : base(control, value)
        {
            control.TextChanged += OnValueChanged;
        }

        public DataControlBitEdit(Control control, Ref<uint> reference)
            : base(control, reference)
        {
            control.TextChanged += OnValueChanged;
        }

        protected override void DoUpdateValue()
        {
            Value = control.Value;
        }

        protected override void SetControl(Control srcControl)
        {
            control = ((BitEdit)srcControl);
        }

        protected override void DoUpdateControl()
        {
            control.Value = Value;
        }

        protected override void DoUpdateControl(object value)
        {
            if (!(value is uint))
                throw new ArgumentException("Object must be bool");

            control.Value = (uint)value;
        }

        protected override uint GetNotifyValue(Object sender)
        {
            return control.Value;
        }
    }
}
