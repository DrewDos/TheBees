using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;

using TheBees.GameRom;
using TheBees.General;
using TheBees.Forms.Support.DataControl;
using TheBees.Forms.Verification;

namespace TheBees.Forms
{
    public class NodeLayoutControlSet
    {
        public List<DataControl> dataCtrls = new List<DataControl>();
        private Dictionary<Control, DataControl> hashedDataCtrls = new Dictionary<Control, DataControl>();
        private Dictionary<string, DataControl> keyedDataCtrls = new Dictionary<string, DataControl>();
        private DataNode node;
        private DataControlObserver defaultCallback;

        private VerifyHandler verifyHdlr;
        public VerifyHandler Verification { get { return verifyHdlr; } }

        public List<DataControl> Controls { get { return dataCtrls; } }
        public Dictionary<Control, DataControl> HashedDataCtrls { get { return hashedDataCtrls; } }

        public bool PreventControlEvent { set { dataCtrls.ForEach((x) => { x.PreventControlEvent = value; /*verifyHdlr.PreventUpdate = value;*/ }); } }
        public bool SuspendPendingUpdate { set { dataCtrls.ForEach((x) => { x.SuspendPendingUpdate = value; /*verifyHdlr.PreventUpdate = value;*/ }); } }

        public NodeLayoutControlSet(DataNode srcNode, DataControlObserver srcDefaultCallback)
        {
            node = srcNode;
            defaultCallback = srcDefaultCallback;
            verifyHdlr = new VerifyHandler();
        }

        public static Control[] ControlsToArray(params Control[] controls)
        {
            return controls;
        }

        public void SetNode(DataNode newNode)
        {
            node = newNode;
        }

        public DataControl RegisterControl(Control control, Ref<uint> reference, DataControlObserver callback = null, string key = "", bool captureVerification = true, bool suspendData = false)
        {
            DataControl activeControl;
            Ref<uint> srcValue = null;

            if (!suspendData)
                srcValue = reference;

            if (!hashedDataCtrls.ContainsKey(control))
            {
                activeControl = DataControlFactory.FromControl(control, srcValue);
                hashedDataCtrls[control] = activeControl;
                if (key == "") key = "unspecified_" + Controls.Count.ToString();
                activeControl.Key = key;
                keyedDataCtrls[key] = activeControl;
                activeControl.Key = key;
                dataCtrls.Add(activeControl);
                verifyHdlr.AddChild(activeControl);
                AddObserver(control, callback);
            }
            else
            {
                activeControl = hashedDataCtrls[control];
                activeControl.UpdateValue(srcValue);
                activeControl.SetEnableFlag(srcValue != null);
            }

            return activeControl;
        }

        public DataControl RegisterControlRange(Control[] controls, Ref<uint> reference, DataControlObserver callback = null, string key = "", bool captureVerification = true, bool suspendData = false)
        {
            DataControl activeControl;
            Ref<uint> srcValue = null;

            if (!suspendData)
                srcValue = reference;

            if (!hashedDataCtrls.ContainsKey(controls[0]))
            {

                activeControl = DataControlFactory.FromControlRange(controls, srcValue);
                hashedDataCtrls[controls[0]] = activeControl;
                if (key == "") key = "unspecified_" + Controls.Count.ToString();
                activeControl.Key = key;
                dataCtrls.Add(activeControl);
                verifyHdlr.AddChild(activeControl);
                AddObserver(controls[0], callback);
            }
            else
            {
                activeControl = hashedDataCtrls[controls[0]];
                activeControl.UpdateValue(srcValue);
                activeControl.SetEnableFlag(srcValue != null);
            }

            return activeControl;

        }

        public DataControl RegisterControl(Control control, string key, DataControlObserver callback = null, bool captureVerification = true, bool suspendData = false)
        {
            DataControl activeControl;
            NodeSuppleValue srcSuppleValue = null;

            if (!suspendData)
                srcSuppleValue = node.GetSuppleValue(key);

            if (!hashedDataCtrls.ContainsKey(control))
            {

                activeControl = DataControlFactory.FromControl(control, srcSuppleValue);
                hashedDataCtrls[control] = activeControl;
                keyedDataCtrls[key] = activeControl;
                activeControl.Key = key;
                dataCtrls.Add(activeControl);
                verifyHdlr.AddChild(activeControl);
                AddObserver(control, callback);
            }
            else
            {
                activeControl = hashedDataCtrls[control];
                activeControl.UpdateValue(srcSuppleValue);
                activeControl.SetEnableFlag(srcSuppleValue != null);
            }

            return activeControl;

        }



        public DataControl RegisterControlRange(Control[] controls, string key, DataControlObserver callback = null, bool captureVerification = true, bool suspendData = false)
        {
            DataControl activeControl;
            NodeSuppleValue srcSuppleValue = null;

            if (!suspendData)
                srcSuppleValue = node.GetSuppleValue(key);

            if (!hashedDataCtrls.ContainsKey(controls[0]))
            {
                activeControl = DataControlFactory.FromControlRange(controls, srcSuppleValue);
                hashedDataCtrls[controls[0]] = activeControl;
                keyedDataCtrls[key] = activeControl;
                activeControl.Key = key;
                dataCtrls.Add(activeControl);
                verifyHdlr.AddChild(activeControl);
                AddObserver(controls[0], callback);
            }
            else
            {
                activeControl = hashedDataCtrls[controls[0]];
                activeControl.UpdateValue(srcSuppleValue);
                activeControl.SetEnableFlag(srcSuppleValue != null);
            }

            return activeControl;

        }

        private void AddObserver(Control control, DataControlObserver callback)
        {
            if (callback != null)
                hashedDataCtrls[control].AddObserver(callback);
            else
                hashedDataCtrls[control].AddObserver(defaultCallback);
        }

        public DataControl GetControlByKey(string key)
        {
            if (!keyedDataCtrls.ContainsKey(key))
            {
                throw new Exception("Key does not exist");
            }

            return keyedDataCtrls[key];
        }

        private void SetKey(Control control, string key)
        {
        }

        public void UpdateValuesFromSet(NodeLayoutControlSet set)
        {
            if (dataCtrls.Count != set.Controls.Count)
                throw new ArgumentException("Counts of both sets must match.");

            for (int i = 0; i < dataCtrls.Count; i++)
            {
                Controls[i].UpdateControl();
            }
        }

        protected virtual void RegisterControls()
        {
            //throw new Exception("Cannot register controls with base class");
        }

    }
}
