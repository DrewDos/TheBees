using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TheBees.GameRom;
using TheBees.General;
using TheBees.UnitData;
using TheBees.Records;
using TheBees.Description;
using TheBees.Forms.Verification;
using TheBees.Forms.Support.DataControl;

namespace TheBees.Forms
{
    public partial class TabAccel : PropertyLayout
    {

        protected override ComboBox PrimaryCombo { get { return cbAccelIndex; } }
        protected override PropertyType MainType { get { return PropertyType.Acceleration;}}
        public override Controls.PropertyToolset Toolset { get { return tools; } }

        private int currUnitIndex = -1;
        public TabAccel()
            : base(null)
        {
           
        }


        public TabAccel(ActiveDataElement source)
            : base(source)
        {
            tools.SetControls(Verification.ConfirmNoMessage, cbAccelIndex);
            tools.ComboChangedEvent += (x) => { changedIndex = x;  OnChangePrimaryIndex(new DataControlEventParams((uint)x, ControlSet.GetControlByKey("accel"))); };
        }

        protected override void RegisterControls()
        {
            tbXMuzzleVelocity.MaxValue = 0xFFFF;
            tbXAcceleration.MaxValue = 0xFFFF;
            tbYAcceleration.MaxValue = 0xFFFF;
            tbYMuzzleVelocity.MaxValue = 0xFFFF;

            ControlSet.RegisterControl(tbXMuzzleVelocity, "xMuzzleVel");
            ControlSet.RegisterControl(tbXAcceleration, "xAccel");
            ControlSet.RegisterControl(tbYMuzzleVelocity, "yMuzzleVel");
            ControlSet.RegisterControl(tbYAcceleration, "yAccel");

            base.RegisterControls();
        }

        protected override void OnLoadNode()
        {
            
            tools.SetPropertyGroup(activeData.Unit.GetPropertyGroup(PropertyType.Acceleration));
            base.OnLoadNode();
        }
    }
}
