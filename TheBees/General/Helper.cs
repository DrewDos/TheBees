using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheBees.General
{
    static class Helper
    {
        static public void PreventListUpdate(ref bool preventVar, Action action)
        {
            preventVar = true;
            action();
            preventVar = false;
        }
    }
}
