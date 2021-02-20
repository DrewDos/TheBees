using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheBees.Controls
{
    public enum DataToolButtonType
    {
        New,
        Copy,
        MoveUp,
        MoveDown,
        Remove,
        Extra
    }

    public class DataToolConfig
    {
        public DataToolButtonType[] ButtonTypes { get { return buttonTypes; } }
        private DataToolButtonType[] buttonTypes;

        public event Action OnAddEvent;
        public event Action OnCopyEvent;
        public event Action OnRemoveEvent;
        public event Action OnMoveUpEvent;
        public event Action OnMoveDownEvent;
        public event Action OnBtnExtraEvent;

        public DataToolConfig(params DataToolButtonType[] newButtonTypes)
        {
            if (newButtonTypes.Length == 0)
                throw new ArgumentException("buttons cannot have a length of 0");

            Array.ForEach(newButtonTypes, (x) => { if (Array.FindAll(newButtonTypes, (y) => x == y).Length > 1) throw new Exception("cannot have multiple type of a button"); });

            buttonTypes = newButtonTypes;
        }

        public void OnAdd()
        {
            if (OnAddEvent != null)
                OnAddEvent();
        }

        public void OnCopy()
        {
            if (OnCopyEvent != null)
                OnCopyEvent();
        }

        public void OnMoveUp()
        {
            if (OnMoveUpEvent != null)
                OnMoveUpEvent();
        }

        public void OnMoveDown()
        {
            if (OnMoveDownEvent != null)
                OnMoveDownEvent();
        }

        public void OnRemove()
        {
            if (OnRemoveEvent != null)
                OnRemoveEvent();
        }

        public void OnExtra()
        {
            if (OnBtnExtraEvent != null)
                OnBtnExtraEvent();
        }
    }
}
