using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace TheBees.Forms.Verification
{
    public class VerifyHandler : IVerification
    {
        private List<IVerification> children = new List<IVerification>();

        public virtual bool Pending 
        { 
            get 
            { 
                return pending || ChildrenPending; 
            }
            set 
            {
                if (value == true && !SuspendPendingUpdate)
                {
                    pending = value;
                    return;
                }

                pending = value;

                if (value == false) ChildrenPending = value;
            } 
        }

        public event Action ProceedEvent;
        public event Action MakeChangesEvent;
        public event Action CancelEvent;

        protected bool pending = false;
        public bool SuspendPendingUpdate { get; set; }

        public VerifyHandler()
        {
            SuspendPendingUpdate = false;
        }

        public bool Confirm(string caption, string message)
        {
            if (Pending && !Settings.AutoUpdate)
            {
                DialogResult res = MessageBox.Show(null, message, caption, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);

                switch (res)
                {
                    case DialogResult.Yes:
                        Pending = false;
                        if (MakeChangesEvent != null)
                            MakeChangesEvent();
                        if (ProceedEvent != null)
                            ProceedEvent();
                        return true;
                    case DialogResult.No:
                        Pending = false;
                        if (ProceedEvent != null)
                            ProceedEvent();
                        return true;
                    case DialogResult.Cancel:
                        if (CancelEvent != null)
                            CancelEvent();
                        return false;
                }
            }

            if (Pending && Settings.AutoUpdate)
            {
                if (MakeChangesEvent != null)
                    MakeChangesEvent();
            }

            if (ProceedEvent != null)
                ProceedEvent();

            return true;
            
        }
        public void ConfirmNoMessage()
        {
            Pending = false;
            if (MakeChangesEvent != null)
                MakeChangesEvent();
            if (ProceedEvent != null)
                ProceedEvent();
        }
        public void AddChild(IVerification handler)
        {
            //handler.ChildValueChanged += PendVerification;
            children.Add(handler);
        }

        private bool ChildrenPending 
        { 
            get 
            {
                return children.Exists((x) => x.Pending);
            }
            set 
            {

                children.ForEach((x) => x.Pending = value);
            }
        }


    }
}
