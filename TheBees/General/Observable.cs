using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheBees.General
{
    public delegate void NotifyObserver(NotifyParams p);

    public class Observable: ICustomObservable<NotifyObserver, NotifyParams>
    {
        protected event NotifyObserver NotifyObserverEvent;

        public void AddObserver(NotifyObserver ob)
        {
            NotifyObserverEvent += ob;
        }

        public void RemoveObserver(NotifyObserver ob)
        {
            NotifyObserverEvent -= ob;
        }

        public virtual void Notify(NotifyParams p)
        {
            if (NotifyObserverEvent != null)
            {
                NotifyObserverEvent(p);
            }
        }
    }
}
