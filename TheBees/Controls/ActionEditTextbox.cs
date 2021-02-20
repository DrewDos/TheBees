using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TheBees.Forms
{
    public class ActionEditTextbox : TextBox
    {
        public event Action<string> TextSendEvent;

        public ActionEditTextbox()
            : base()
        {

        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (TextSendEvent != null)
                    TextSendEvent(Text);
            }
            base.OnKeyPress(e);
        }

        public void SetTextFromSelect(string newText)
        {
            Text = newText;
            SelectAll();
        }
    }
}
