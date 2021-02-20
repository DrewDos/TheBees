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

namespace TheBees.Forms
{
    public partial class TabFunctionCall : NodeLayout
    {
        private FunctionCall functionNode;
        public event Action<int, int, int> JumpToEvent;

        public TabFunctionCall(ActiveDataElement source)
            : base(source)
        {
        }

        protected override void RegisterControls()
        {
            tbUnknownVal1.MaxValue = 0xFFFF;
            tbUnknownVal2.MaxValue = 0xFFFF;
            tbUnknownVal3.MaxValue = 0xFFFF;
            tbUnknownVal4.MaxValue = 0xFFFF;

            ControlSet.RegisterControl(tbUnknownVal1, "callNum");
            ControlSet.RegisterControl(tbUnknownVal2, "value1");
            ControlSet.RegisterControl(tbUnknownVal3, "value2");
            ControlSet.RegisterControl(tbUnknownVal4, "value3");
        }
        protected override void OnLoadNode()
        {
            functionNode = (FunctionCall)node;
            btnJumpTo.Enabled = FunctionMap.GetFunctionType(functionNode.FunctionCode) == FunctionType.FullReference;
            base.OnLoadNode();
        }

        private void OnClickJumpTo(object sender, EventArgs e)
        {
            if (JumpToEvent != null)
                JumpToEvent(FunctionMap.GameReferenceMap[(int)functionNode.Value1], (int)functionNode.Value2, (int)functionNode.Value3);
        }

    }
}
