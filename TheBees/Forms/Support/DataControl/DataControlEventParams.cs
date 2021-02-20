using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TheBees.General;

namespace TheBees.Forms.Support.DataControl
{
    public class DataControlEventParams : NotifyParams
    {
        public DataControl Control { get; set; }
        public DataControlEventParams(uint value, DataControl control)
            : base((int)value)
        {
            Control = control;
        }
    }
}
