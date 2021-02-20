using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TheBees.UnitData;
using TheBees.GameRom;

namespace TheBees.Forms
{
    public partial class FCBasic : NodeLayout
    {
        private FunctionCall functionNode;
        private BitEdit[] edits;
        private Label[] labels;
        private bool[] valueAvailable;
        public FCBasic()
            : base()
        {
            edits = new BitEdit[3];
            labels = new Label[3];
            valueAvailable = new bool[3];

            edits[0] = tbUnknownVal1;
            edits[1] = tbUnknownVal2;
            edits[2] = tbUnknownVal3;

            labels[0] = lblValue1;
            labels[1] = lblValue2;
            labels[2] = lblValue3;

            valueAvailable[0] = false;
            valueAvailable[1] = false;
            valueAvailable[2] = false;
        }
        public void SetNoSettings()
        {
            for (int i = 0; i < 3; i++)
                valueAvailable[i] = false;

            UpdateLayout();
        }

        public void SetSettings(string[] newDescriptions)
        {
            if (newDescriptions != null)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (newDescriptions[i] == null)
                        valueAvailable[i] = false;
                    else
                    {
                        valueAvailable[i] = true;
                        SetLabel(i, newDescriptions[i]);
                    }
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    valueAvailable[i] = true;
                    SetLabel(i, "Value " + i.ToString());
                }
            }

            UpdateLayout();
        }

        private void SetLabel(int index, string text)
        {
            labels[index].Text = text;
        }

        public void UpdateLayout()
        {
            int layoutRow = 0;

            for(int i = 0; i < 3; i++)
            {
                if (valueAvailable[i])
                {
                    labels[i].Visible = true;
                    edits[i].Visible = true;
                    tableLayoutPanel4.Controls.Add(labels[i], 0, layoutRow);
                    tableLayoutPanel4.Controls.Add(edits[i], 1, layoutRow);

                    layoutRow += 1;
                }
                else
                {
                    labels[i].Visible = false;
                    edits[i].Visible = false;
                    tableLayoutPanel4.Controls.Remove(labels[i]);
                    tableLayoutPanel4.Controls.Remove(edits[i]);
                }
            }
        }

        protected override void RegisterControls()
        {
            tbUnknownVal1.MaxValue = 0xFFFF;
            tbUnknownVal2.MaxValue = 0xFFFF;
            tbUnknownVal3.MaxValue = 0xFFFF;

            ControlSet.RegisterControl(tbUnknownVal1, "value1");
            ControlSet.RegisterControl(tbUnknownVal2, "value2");
            ControlSet.RegisterControl(tbUnknownVal3, "value3");
        }

        public override void LoadNode(DataNode newNode)
        {
            functionNode = (FunctionCall)newNode;

            SetSettings(FunctionMap.GetSettings(functionNode.FunctionCode));

            base.LoadNode(newNode);
        }
    }
}
