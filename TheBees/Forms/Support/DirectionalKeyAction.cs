using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace TheBees.Forms
{
    public class DirectionalKeyAction
    {
        public event Action UpEvent;
        public event Action DownEvent;
        public event Action LeftEvent;
        public event Action RightEvent;
        private bool requiresCtrlDown;

        public DirectionalKeyAction(bool ctrlRequired = true)
        {
            requiresCtrlDown = ctrlRequired;
        }

        public bool Process(Keys ModifierKeys, Keys keyData)
        {
            if ((ModifierKeys & Keys.Control) == Keys.Control || !requiresCtrlDown)
            {
                if ((keyData & Keys.Right) == Keys.Right)
                {
                    if (RightEvent != null)
                        RightEvent();
                    return true;
                }
                if ((keyData & Keys.Left) == Keys.Left)
                {
                    if (LeftEvent != null)
                        LeftEvent();
                    return true;
                }
                if ((keyData & Keys.Up) == Keys.Up)
                {
                    if (UpEvent != null)
                        UpEvent();
                    return true;
                }
                if ((keyData & Keys.Down) == Keys.Down)
                {
                    if (DownEvent != null)
                        DownEvent();
                    return true;
                }

            }

            return false;
        }
    }
}
