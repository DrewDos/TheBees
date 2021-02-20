using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TheBees.UnitData;

namespace TheBees.Forms
{
    public class ReferenceQueue
    {
        private Stack<ActionReference> prevStack;

        public ReferenceQueue()
        {
            prevStack = new Stack<ActionReference>();
        }

        public void Push(ActionReference reference)
        {
            prevStack.Push(reference);
        }

        public ActionReference GetPrevous()
        {
            return prevStack.Pop();
        }

        public bool HasPrevious()
        {
            return prevStack.Count > 0;
        }
    }
}
