using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TheBees.Forms.Support.DataControl;

namespace TheBees.Forms.Verification
{
    class VerifyObject
    {
        static private Dictionary<Type, Action<Control, VerifyObject>> bindControlMethods = GetBindControlMethods();
        public Action changedEvent = null;
        public bool PreventUpdate = false;

        public VerifyObject(Control control, Action srcChangedEvent)
        {
            bindControlMethods[control.GetType()](control, this);
            changedEvent = srcChangedEvent;
        }

        public VerifyObject(Control [] controls, Action srcChangedEvent)
        {
            Array.ForEach(controls, (x) => bindControlMethods[x.GetType()](x, this));
            changedEvent = srcChangedEvent;
        }

        private void OnValueChanged()
        {
            if(!PreventUpdate)
                changedEvent();
        }

        static private Dictionary<Type, Action<Control, VerifyObject>> GetBindControlMethods()
        {
            Dictionary<Type, Action<Control, VerifyObject>> output = new Dictionary<Type, Action<Control, VerifyObject>>();

            output[typeof(ComboBox)] = (c, vo) => ((ComboBox)c).SelectionChangeCommitted += (o, e) => { if (!vo.PreventUpdate) vo.OnValueChanged(); };
            output[typeof(BitEdit)] = (c, vo) => ((BitEdit)c).ValueChangedEvent += (o) => {
                if (!vo.PreventUpdate) vo.OnValueChanged(); 
            }; ;
            output[typeof(CheckBox)] = (c, vo) => ((CheckBox)c).CheckedChanged += (o, e) => { if (!vo.PreventUpdate)vo.OnValueChanged(); };
            output[typeof(RadioButton)] = (c, vo) => ((RadioButton)c).CheckedChanged += (o, e) => { if (!vo.PreventUpdate) vo.OnValueChanged(); };

            return output;
        }
    }
}
