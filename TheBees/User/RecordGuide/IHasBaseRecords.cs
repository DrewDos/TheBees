using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheBees.User
{
    public interface IHasBaseRecords
    {
        void InitBaseData();
        void LoadIntoSpace();
    }
}
