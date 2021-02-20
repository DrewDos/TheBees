using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheBees.Forms
{
    interface IModifyForm
    {
        void SetSaveDelegate();
        void OnSave();
    }
}
