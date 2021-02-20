using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheBees
{
    public static class Clipboard
    {

        static private IClipboardItem clipItem;

        static public void SetItem(IClipboardItem newItem)
        {
            clipItem = newItem;
        }

        static public IClipboardItem GetItem()
        {
            return clipItem;
        }

        static public IClipboardItem ClipboardItem { get { return clipItem; } }
    }
}
