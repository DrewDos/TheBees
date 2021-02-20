using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TheBees.GameRom;
using TheBees.UnitData;
using TheBees.General;

using TheBees.Forms.Support.DataControl;
namespace TheBees.Forms
{
    public partial class TabActionHeader : NodeLayout
    {
        ActionHeader nodeHeader = null;

        public event Action<int> DataLengthChangedEvent;

        public TabActionHeader(ActiveDataElement source)
            : base(source)
        {
            //InitializeComponent();
        }

        protected override void RegisterControls()
        {
            tbTechRelated.MaxValue = 0xFFFF;
            tbJudgmentRelated.MaxValue = 0xFFFF;
            tbUnknown1.MaxValue = 0xFFFF;
            tbUnknown2.MaxValue = 0xFFFF;

            rb8Byte.Tag = 8;
            rb16Byte.Tag = 16;
            rb24Byte.Tag = 24;

            ControlSet.RegisterControl(tbTechRelated, "judgmentRelated");
            ControlSet.RegisterControl(tbJudgmentRelated, "techRelated");
            ControlSet.RegisterControl(tbUnknown1, "undef1");
            ControlSet.RegisterControl(tbUnknown2, "undef2");
            ControlSet.RegisterControlRange(
                NodeLayoutControlSet.ControlsToArray(rb8Byte, rb16Byte, rb24Byte),
                new Ref<uint>(() => (uint)nodeHeader.DataLengthInBytes, (x) => { }),
                OnDataLengthChanged,
                "radios"
            );
        }

        public override void LoadNode(DataNode newNode)
        {
            nodeHeader = (ActionHeader)newNode;

            base.LoadNode(newNode);
        }

        public void OnDataLengthChanged(DataControlEventParams p)
        {
            if (p.Value == nodeHeader.DataLengthInBytes)
                return;

            int newLength = p.Value;
            bool changeData = true;

            if (newLength < nodeHeader.DataLengthInBytes)
            {
                changeData = false;

                if(MessageBox.Show(
                    "Data loss on some values will occur when reducing length of data. Continue?", 
                    "Data Loss Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    changeData = true;
                }
            }

            if (changeData)
            {
                //nodeHeader.DataLengthInBytes = newLength;
                if (DataLengthChangedEvent != null)
                    DataLengthChangedEvent(newLength);
            }
            else
            {
                p.Control.PreventControlEvent = true;
                p.Control.UpdateControl(nodeHeader.DataLengthInBytes);
                p.Control.PreventControlEvent = false;
            }
        }


    }
}
