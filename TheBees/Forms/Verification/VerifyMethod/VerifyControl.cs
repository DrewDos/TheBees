using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace TheBees.Forms.Verification
{
    public class VerifyControl : VerifyHandler
    {
        private List<VerifyObject> verifyObjects = new List<VerifyObject>();
        public bool PreventUpdate { set { verifyObjects.ForEach((x) => { x.PreventUpdate = value; }); } }

        public void AddObject(Control control)
        {
            verifyObjects.Add(new VerifyObject(control, PendVerification));
        }

        public void AddObject(Control[] controls)
        {
            Array.ForEach(controls, (x) => AddObject(x));
        }

        private void PendVerification()
        {
            pending = true;
        }

    }
}
