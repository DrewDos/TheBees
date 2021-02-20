    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TheBees.GameRom;
using TheBees.General;
using TheBees.Forms.Verification;

namespace TheBees.Forms.Support.DataControl
{
    public delegate void DataControlObserver(DataControlEventParams p);

    public abstract class DataControl : ICustomObservable<DataControlObserver, DataControlEventParams>, IVerification
    {
        public string Key { get; set; }
        protected object value;
        protected Type valueType;
        private Func<uint> getter;
        private Action<uint> setter;
        private Func<string> getNotifyKey;
        protected event DataControlObserver dataControlEvents = null;
        protected bool enabled = true;
        protected bool captureVerification = true;
        public bool CaptureVerification { get { return captureVerification; } set { captureVerification = value; } }

        protected abstract Control MainControl { get;}
        protected abstract Control[] MainControlSet { get; }

        public bool PreventControlEvent { get; set; }
        public bool PreventControlUpdate { get; set; }

        public virtual bool Pending { get; set; }
        public bool SuspendPendingUpdate { get; set; }

        private DataControl(NodeSuppleValue srcValue)
        {
            valueType = typeof(NodeSuppleValue);
            value = srcValue;
        }

        private DataControl(Ref<uint> srcValue)
        {
            valueType = typeof(Ref<uint>);
            value = srcValue;
        }
        public DataControl(Control srcControl, NodeSuppleValue srcValue)
            :this(srcValue)
        {
            SetControl(srcControl);
            InitFunc();
        }
        
        public DataControl(Control[] srcControls, NodeSuppleValue srcValue)
            :this(srcValue)
        {
            SetControl(srcControls);
            InitFunc();
        }

        public DataControl(Control srcControl, Ref<uint> srcValue)
            :this(srcValue)
        {
            SetControl(srcControl);
            InitFunc();
        }

        public DataControl(Control[] srcControls, Ref<uint> srcValue)
            :this(srcValue)
        {
            SetControl(srcControls);
            InitFunc();
        }


        public void UpdateValue(NodeSuppleValue srcValue)
        {
            value = srcValue;
            
        }
        public void UpdateValue(Ref<uint> srcValue)
        {
            value = srcValue;
        }

        public void UpdateValue()
        {
            if (enabled)
            {
                DoUpdateValue();

                if (!SuspendPendingUpdate && captureVerification)
                    Pending = true;
            }
        }
        public void UpdateControl(object value)
        {
            if (enabled)
            {
                DoUpdateControl(value);
            }
        }

        public void UpdateControl()
        {
            if (enabled)
            {
                DoUpdateControl();
            }
        }

        public void UpdateControlNoEvent()
        {
            PreventControlEvent = true;
            PreventControlUpdate = true;
            UpdateControl();
            PreventControlEvent = false;
            PreventControlUpdate = false;
        }

        public void DisplayOnly(bool set)
        {
            PreventControlEvent = set;
            PreventControlUpdate = set;
            CaptureVerification = !set;
        }

        public DataControl SetValue(uint newValue, bool fireEvent = false)
        {
            if (getter() != newValue)
            {
                setter(newValue);

                if (!SuspendPendingUpdate && captureVerification)
                    Pending = true;

                if (fireEvent)
                {
                    UpdateControlNoEvent();
                }
                else
                {
                    UpdateControl();
                }
            }

            return this;
        }

        private void InitFunc()
        {
            if (valueType == typeof(NodeSuppleValue))
            {
                getter = NodeSuppleValueGetter;
                setter = NodeSuppleValueSetter;
                getNotifyKey = () => ((NodeSuppleValue)value).Key;
            }
            else if (valueType == typeof(Ref<uint>))
            {
                getter = RefGetter;
                setter = RefSetter;
                getNotifyKey = () => "";
            }
            else
            {
                throw new Exception("Invalid value type");
            }
        }
        private uint RefGetter()
        {
            return ((Ref<uint>)value).Value;
        }

        private void RefSetter(uint srcValue)
        {
            ((Ref<uint>)value).Value = srcValue;
        }

        private uint NodeSuppleValueGetter()
        {
            return ((NodeSuppleValue)value).Value;
        }
        
        private void NodeSuppleValueSetter(uint srcValue)
        {
            ((NodeSuppleValue)value).Value = srcValue;
        }

        public uint Value
        {
            get { return getter(); }
            set { setter(value); }
        }

        public void AddObserver(DataControlObserver o)
        {
            dataControlEvents += o;
        }

        public void RemoveObserver(DataControlObserver o)
        {
            dataControlEvents -= o;
        }
        public void Notify(DataControlEventParams p)
        {
            if (dataControlEvents != null)
                dataControlEvents(p);
        }

        public void SetEnableFlag(bool doEnable = true)
        {

            if (enabled != doEnable)
            {
                enabled = doEnable;
                if (MainControl != null)
                    MainControl.Enabled = doEnable;
                if (MainControlSet != null)
                    Array.ForEach(MainControlSet, (x) => x.Enabled = doEnable);
            }
            
        }

        protected virtual void SetControl(Control control)
        {
            throw new NotImplementedException("Must be set in derived class");
        }
        protected virtual void SetControl(Control[] controls)
        {
            throw new NotImplementedException("Must be set in derived class, or control array not supported in DataControl");
        }

        protected virtual uint GetNotifyValue(Object sender)
        {
            throw new NotImplementedException("Must be set in derived class");
        }

        protected virtual void OnValueChanged(Object sender, EventArgs e)
        {
            if(!PreventControlUpdate)
                UpdateValue();

            if (!PreventControlEvent)
            {
                //if(verifySimple != null)
                //    verifySimple.Pending = true;
                Notify(new DataControlEventParams(GetNotifyValue(sender), this));
            }
        }

        protected abstract void DoUpdateValue();
        protected abstract void DoUpdateControl();
        protected abstract void DoUpdateControl(object value);

    }
}
