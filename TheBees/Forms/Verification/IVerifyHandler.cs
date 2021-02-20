using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheBees.Forms.Verification
{
    public interface IVerification
    {
        bool Pending { get; set; }
        bool SuspendPendingUpdate { get; set; }
    }
}
