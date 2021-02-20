using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TheBees.Description;
using TheBees.UnitData;
using TheBees.Sprites;
using TheBees.GameRom;

namespace TheBees.Forms
{
    public partial class ModifyAction : Form
    {
        protected static int unitIndex, categoryIndex, propertyIndex, dataIndex;

        protected int startUnit = 2;
        protected int startCategory = 3;
        protected int startProperty = 0x1C;
        private bool loadProperty = true;

        protected int GetStartIndex(ComboBox box)
        {
            if (loadProperty)
            {
                int value = 0;
                switch ((string)box.Tag)
                {
                    case "UnitSelect":
                        value = startUnit;
                        break;
                    case "PropertySelect":
                        loadProperty = false;
                        value = startProperty;
                        break;
                    case "CategorySelect":
                        value = startCategory;
                        break;
                }

                if (value < box.Items.Count)
                    return value;
            }

            return 0;
        }

        private int CopyIndices()
        {
            return 0;
        }

        private int PasteIndices()
        {
            return 0;
        }

    }
}
