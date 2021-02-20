using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheBees.General
{
    sealed public class Ref<T>
    {
        private readonly Func<T> getter;
        private readonly Action<T> setter;
        public Ref(Func<T> getter, Action<T> setter)
        {
            this.getter = getter;
            this.setter = setter;
        }
        public T Value { get { return getter(); } set { setter(value); } }
    }
}
