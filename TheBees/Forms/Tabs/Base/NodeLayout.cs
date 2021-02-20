using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TheBees.GameRom;
using TheBees.UnitData;
using TheBees.General;
using TheBees.Forms.Support.DataControl;
using TheBees.Forms.Verification;
using System.ComponentModel;

namespace TheBees.Forms
{
    public class NodeLayout : UserControl
    {
        public NodeLayoutControlSet ControlSet;
        private NodeLayoutControlSet primaryControlSet;
        protected ActiveDataElement activeData;
        public ActiveDataElement ActiveData { set { activeData = value; } }
        protected DataNode node;
        protected int unitNum = -1;
        protected bool unitChanged = false;
        private bool setupVerificationComplete = false;
        public bool PreventBufferRelease = false;

        public event DataControlObserver ValueChangedEvent;
        static public event Action GlobalValueChangedEvent;

        // sibling management
        private List<NodeLayout> clones = new List<NodeLayout>();
        public bool HasClones { get { return clones.Count > 0; } }
        public List<NodeLayout> MatchingClones { get { return clones.FindAll((x) => x.node == node); } }
        private bool ClonesUsingNode { get { return clones.Exists((x) => x.node == node); } }
        private bool isPrimaryClone = false;

        public bool PreventLockBuffer = false;

        public NodeLayout(ActiveDataElement source)
        {
            InitializeComponent();

            if (!(LicenseManager.UsageMode == LicenseUsageMode.Designtime))
            {
                activeData = source;
                ControlSet = new NodeLayoutControlSet(null, OnChangeValue);
                LoadLayout();
            }
        }

        public NodeLayout()
        {
            InitializeComponent();

            if (!(LicenseManager.UsageMode == LicenseUsageMode.Designtime))
            {
                ControlSet = new NodeLayoutControlSet(null, OnChangeValue);
                LoadLayout();
            }
        }

        public virtual void InitializeComponent()
        {
        }

        protected virtual void InitControls()
        {
            throw new Exception("Cannot initialize controls in base class");
        }

        protected virtual void RegisterControls()
        {
        }
        
        protected virtual void LoadLayout()
        {
            OnLoadLayout();
        }

        protected virtual void OnLoadLayout()
        {
            // do nothing
        }

        protected virtual void OnPrimaryYes()
        {
            UpdateNode();
        }

        protected virtual void OnPrimaryCancel()
        {
            // do nothing
        }

        protected virtual void OnPrimaryProceed()
        {
        }

        protected virtual void SetupVerification()
        {
            Verification.MakeChangesEvent += OnPrimaryYes;
            Verification.ProceedEvent += OnPrimaryProceed;
            Verification.CancelEvent += OnPrimaryCancel;
            OnSetupVerification();

        }

        protected virtual void OnSetupVerification()
        {
        }

        public virtual void UpdateNode()
        {
            node.ApplyBuffer();
        }

        public virtual void PopulateControls()
        {
            if (isPrimaryClone)
            {
                ControlSet.Controls.ForEach((x) => { x.UpdateControlNoEvent(); });
            }
            else
            {
                ControlSet.UpdateValuesFromSet(primaryControlSet);
            }
        }

        // sibling management
        public void AddClone(NodeLayout newClone)
        {
            if (newClone != this)
            {
                clones.Add(newClone);
            }
        }



        public virtual void LoadNode(DataNode newNode)
        {
            bool wasPrimaryClone = isPrimaryClone;
            isPrimaryClone = true;



            if (node != null && !PreventBufferRelease && !ClonesUsingNode)
            {
                if (node.Buffered)
                {
                    node.UnlockBuffer();
                    node.ClearBuffer();
                }
            }

            if (newNode == null)
            {
                DisableLayout();
                return;
            }
            else
            {
                EnableLayout();
            }
            if (HasClones)
            {
                if (newNode != null)
                {
                    NodeLayout primary = null;
                    primary = clones.Find((x) => x.node == newNode && x.isPrimaryClone);
                    isPrimaryClone = primary == null;
                    if (primary != null)
                        primaryControlSet = primary.ControlSet;
                }
            }

            if (isPrimaryClone)
            {


                if (newNode == null)
                {
                    DisableLayout();
                }
                else
                {

                    if (activeData != null && activeData.Unit.Index != unitNum)
                    {
                        unitChanged = true;
                        unitNum = activeData.Unit.Index;
                    }
                    else
                    {
                        unitChanged = false;
                    }

                    node = newNode;
                    node.BufferValues();
                    if(!PreventLockBuffer) node.LockBuffer();
                    ControlSet.SetNode(node);

                    if (!wasPrimaryClone)
                        ControlSet.Controls.ForEach((x) => { x.DisplayOnly(false); });
                }

                Verification.Pending = false;
            }
            else
            {
                unitChanged = true;
                node = newNode;
                ControlSet.SetNode(node);
            }

            OnLoadNode();
        }

        protected virtual void EnableLayout()
        {
            this.Enabled = true;
        }

        protected virtual void DisableLayout()
        {
            this.Enabled = false;
        }

        public void UnloadNode()
        {
            //throw new NotImplementedException();
        }
        protected virtual void OnLoadNode()
        {
            RegisterControls();
            ControlSet.Controls.ForEach((x) => { x.DisplayOnly(!isPrimaryClone); });
            if (!setupVerificationComplete)
            {
                SetupVerification();
                OnSetupVerification();
                setupVerificationComplete = true;
            }
            PopulateControls();
        }

        protected virtual void OnChangeValue(DataControlEventParams p)
        {
            if (HasClones)
            {
                //MatchingClones.ForEach((x) => x.ControlSet.GetControlByKey(p.Control.Key).SetValue(p.Control.Value));
            }

            if (Settings.AutoUpdate)
                UpdateNode();

            TriggerValueChangedEvent(p);
        }

        protected void TriggerValueChangedEvent(DataControlEventParams p)
        {
            if (ValueChangedEvent != null)
                ValueChangedEvent(p);
            
        }

        public DataNode Node { get { return node; } }
        public VerifyHandler Verification { get { return ControlSet.Verification; } }
    }    
}
