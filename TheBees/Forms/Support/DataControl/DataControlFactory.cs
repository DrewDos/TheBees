using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TheBees.Forms.Support.DataControl.DerivedControls;
using TheBees.GameRom;
using TheBees.General;

namespace TheBees.Forms.Support.DataControl
{
    static public class DataControlFactory
    {
        public delegate DataControl NewDataControlDelegate(Control control, NodeSuppleValue value);
        public delegate DataControl NewDataControlRefDelegate(Control control, Ref<uint> reference);
        public delegate DataControl NewDataControlRangeDelegate(Control[] control, NodeSuppleValue value);
        public delegate DataControl NewDataControlRangeRefDelegate(Control[] control, Ref<uint> reference);

        private static Dictionary<Type, NewDataControlDelegate> methods = null;
        private static Dictionary<Type, NewDataControlRangeDelegate> rangeMethods = null;
        private static Dictionary<Type, NewDataControlRefDelegate> refMethods = null;
        private static Dictionary<Type, NewDataControlRangeRefDelegate> rangeRefMethods = null;

        static public DataControl FromControl(Control control, NodeSuppleValue value)
        {
            InitializeMethods();
            return methods[control.GetType()](control, value);
        }

        static public DataControl FromControlRange(Control[] controls, NodeSuppleValue value)
        {
            InitializeMethodsRanged();
            if (controls.Length <= 1)
            {
                throw new ArgumentException("Controls must be greater than 2");
            }

            return rangeMethods[controls[0].GetType()](controls, value);

        }

        static public DataControl FromControl(Control control, Ref<uint> reference)
        {
            InitializeRefMethods();
            return refMethods[control.GetType()](control, reference);
        }

        static public DataControl FromControlRange(Control[] controls, Ref<uint> reference)
        {
            InitializeRefMethodsRanged();
            if (controls.Length <= 1)
            {
                throw new ArgumentException("Controls must be greater than 2");
            }

            return rangeRefMethods[controls[0].GetType()](controls, reference);

        }

        private static void InitializeMethodsRanged()
        {
            if (rangeMethods == null)
            {
                rangeMethods = new Dictionary<Type, NewDataControlRangeDelegate>();
                rangeMethods[typeof(RadioButton)] = (c, v) => { return new DataControlRadioSet(c, v); };
            }
        }
        private static void InitializeMethods()
        {
            if (methods == null)
            {
                methods = new Dictionary<Type, NewDataControlDelegate>();
                methods[typeof(BitEdit)] = (c, v) => { return new DataControlBitEdit(c, v); };
                methods[typeof(ComboBox)] = (c, v) => { return new DataControlComboBox(c, v); };
                methods[typeof(CheckBox)] = (c, v) => { return new DataControlCheckBox(c, v); };
            }
        }
        private static void InitializeRefMethodsRanged()
        {
            if (rangeRefMethods == null)
            {
                rangeRefMethods = new Dictionary<Type, NewDataControlRangeRefDelegate>();
                rangeRefMethods[typeof(RadioButton)] = (c, v) => { return new DataControlRadioSet(c, v); };
            }
        }
        private static void InitializeRefMethods()
        {
            if (refMethods == null)
            {
                refMethods = new Dictionary<Type, NewDataControlRefDelegate>();
                refMethods[typeof(BitEdit)] = (c, v) => { return new DataControlBitEdit(c, v); };
                refMethods[typeof(ComboBox)] = (c, v) => { return new DataControlComboBox(c, v); };
                refMethods[typeof(CheckBox)] = (c, v) => { return new DataControlCheckBox(c, v); };
            }
        }
    }
}
