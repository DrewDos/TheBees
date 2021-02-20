using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheBees.General
{
    interface ICustomObservable<T, X>
    {
        void AddObserver(T ob);
        void RemoveObserver(T ob);
        void Notify(X p);
    }
}
