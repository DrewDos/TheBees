using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using TheBees.Forms.Support.DataControl;
using TheBees.General;
using TheBees.GameRom;

namespace TheBees.Forms
{
    class ControlSetParams
    {
        DataControlObserver Callback { get; set; }
        string Key { get; set; }
        bool CaptureVerification { get; set; }
        bool SuspendData { get; set; }
    }
}
