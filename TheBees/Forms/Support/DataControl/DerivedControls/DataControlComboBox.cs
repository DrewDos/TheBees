using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TheBees.GameRom;
using TheBees.General;

namespace TheBees.Forms.Support.DataControl.DerivedControls
{
    class DataControlComboBox : DataControl
    {
        private ComboBox control;

        protected override Control MainControl { get { return control; } }
        protected override Control [] MainControlSet { get { return null; } }

        public DataControlComboBox(Control srcControl, NodeSuppleValue value)
            : base(srcControl, value)
        {
            control.SelectionChangeCommitted += OnValueChanged;
        }

        public DataControlComboBox(Control srcControl, Ref<uint> reference)
            : base(srcControl, reference)
        {
            control.SelectionChangeCommitted += OnValueChanged;
        }

        protected override void SetControl(Control srcControl)
        {
            control = ((ComboBox)srcControl);
        }

        protected override void DoUpdateValue()
        {
            Value = (uint)control.SelectedIndex;
        }

        protected override void DoUpdateControl(object value)
        {
            if (!(value is int))
            {
                throw new ArgumentException("Object must be int");
            }

            control.SelectedIndex = (int)value;
        }

        protected override void DoUpdateControl()
        {
            //control.SelectedIndex = (int)Value;
        }

        protected override uint GetNotifyValue(Object sender)
        {
            return (uint)control.SelectedIndex;
        }

    }
}
