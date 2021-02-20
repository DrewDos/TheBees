using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TheBees.General;
using TheBees.GameRom;
using TheBees.Forms.Support.DataControl;

namespace TheBees.Forms
{
    public partial class TabThrownOpponent : NodeLayout
    {

        UnitData.Node.ThrownOpponent tiNode = null;
        public event Action FlipFlagChangedEvent;

        public TabThrownOpponent()
            : base(null)
        {
        }
        public TabThrownOpponent(ActiveDataElement source = null, bool sourceShowText = true)
            : base(source)
        {
        }

        protected override void RegisterControls()
        {
            tbXPos.MaxValue = 0xFFFF;
            tbYPos.MaxValue = 0xFFFF;
            tbLayerValue.MaxValue = 0xFFFF;

            ControlSet.RegisterControl(tbXPos, "xPos");
            ControlSet.RegisterControl(tbYPos, "yPos");
            ControlSet.RegisterControl(tbLayerValue, "layerValue");
            ControlSet.RegisterControl(chkFlipX, new Ref<uint>(() => (uint)(tiNode.FlipX ? 1 : 0), (x) => tiNode.FlipX = (x > 0 ? true : false)), OnFlipFlagChanged);
            ControlSet.RegisterControl(chkFlipY, new Ref<uint>(() => (uint)(tiNode.FlipY ? 1 : 0), (x) => tiNode.FlipY = (x > 0 ? true : false)), OnFlipFlagChanged);
        }
        public override void LoadNode(DataNode newNode)
        {
            tiNode = ((UnitData.Node.ThrownOpponent)newNode);

            base.LoadNode(newNode);
        }
        protected override void OnLoadLayout()
        {

            base.OnLoadLayout();
        }

        public void OnFlipFlagChanged(DataControlEventParams p)
        {
            if (FlipFlagChangedEvent != null)
                FlipFlagChangedEvent();
        }

    }
}
