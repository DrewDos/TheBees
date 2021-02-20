using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace TheBees.Controls
{
    public class ActionDataListBox : ListBox
    {
        public ActionDataListBox()
            : base()
        {
        }

        public int[] GetSelectedIndices()
        {
            List<int> indices = new List<int>();
            foreach (int index in SelectedIndices) { indices.Add(index); }
            return indices.ToArray();
        }
        public int FirstSelectedIndex
        {
            get {return SelectedIndices.Count > 0 ? SelectedIndices[0] : -1; }
        }

        public int LastSelectedIndex
        {
            get { return SelectedIndices.Count > 0 ? SelectedIndices[SelectedIndices.Count - 1] : -1; }
        }

        public bool ListSelectLinear
        {
            get
            {
                int prev = -1;

                foreach (int item in SelectedIndices)
                {
                    if (prev != -1)
                    {
                        if (item - prev > 1)
                            return false;
                    }
                    prev = item;
                }

                return true;
            }
        }


    }
}
