using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheBees.General
{
    public class NotifyParams
    {
        public virtual int Value { get; set; }

        public NotifyParams(int newValue)
        {
            Value = newValue;
        }
    }
}
