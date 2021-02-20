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
using TheBees.Description;
using TheBees.Forms.Support.DataControl;
using TheBees.General;

namespace TheBees.Forms
{
    public partial class TabMissileConfig : NodeLayout
    {
        private int changedIndex;

        public TabMissileConfig()
            : base(null)
        {

        }
        public TabMissileConfig(ActiveDataElement source)
            : base(source)
        {
        }

        protected override void LoadLayout()
        {
            base.LoadLayout();

            string [] items = UnitDescription.GetActionGroupNames(UnitHandler.GetUnit(0x15).GetActionGroup(ActionType.NormalOperation));
            string[] accelIndexes = DescSpec.GetIndexedList(UnitHandler.GetUnit(0x15).GetPropertyGroup(PropertyType.Acceleration).Count);
            cbMainAction.Items.AddRange(items);
            cbFloorAction.Items.AddRange(items);
            cbActionOnGuard.Items.AddRange(items);
            cbActionOnHit.Items.AddRange(items);
            cbActionOnParry.Items.AddRange(items);

            cbAccel1.Items.AddRange(accelIndexes);
            cbAccel2.Items.AddRange(accelIndexes);
        }

        protected override void RegisterControls()
        {
            tbBlowOffset.MaxValue = 0xFFFF;
            tbReaction.MaxValue = 0xFFFF; 
            tbPallet.MaxValue = 0xFFFF;
            tbTransparency.MaxValue = 0xFFFF; 
            tbNumHits.MaxValue = 0xFFFF;
            tbGenerationTime.MaxValue = 0xFFFF;
            tbXAxis.MaxValue = 0xFFFF;
            tbYAxis.MaxValue = 0xFFFF; 

            ControlSet.RegisterControl(tbBlowOffset,"blowOffset");
            ControlSet.RegisterControl(tbReaction, "reaction");
            ControlSet.RegisterControl(tbPallet, "pallet");
            ControlSet.RegisterControl(tbTransparency, "transparency");
            ControlSet.RegisterControl(tbNumHits, "numberOfHits");
            ControlSet.RegisterControl(tbGenerationTime, "generationTime");
            ControlSet.RegisterControl(tbXAxis, "xAxis");
            ControlSet.RegisterControl(tbYAxis,"yAxis");

            ControlSet.RegisterControl(cbMainAction, new Ref<uint>(() => { return (uint)cbMainAction.SelectedIndex; }, (x) => changedIndex = (int)x), OnMainActionChanged);
            ControlSet.RegisterControl(cbFloorAction, new Ref<uint>(() => { return (uint)cbFloorAction.SelectedIndex; }, (x) => changedIndex = (int)x), OnFloorActionChanged);
            ControlSet.RegisterControl(cbActionOnGuard, new Ref<uint>(() => { return (uint)cbActionOnGuard.SelectedIndex; }, (x) => changedIndex = (int)x), OnActionGuardChanged);
            ControlSet.RegisterControl(cbActionOnHit, new Ref<uint>(() => { return (uint)cbActionOnHit.SelectedIndex; }, (x) => changedIndex = (int)x), OnActionGuardChanged);
            ControlSet.RegisterControl(cbActionOnParry, new Ref<uint>(() => { return (uint)cbActionOnParry.SelectedIndex; }, (x) => changedIndex = (int)x), OnActionParryChanged);
            ControlSet.RegisterControl(cbAccel1, new Ref<uint>(() => { return (uint)cbAccel1.SelectedIndex; }, (x) => changedIndex = (int)x), OnChangeAccel1, "accel1");
            ControlSet.RegisterControl(cbAccel2, new Ref<uint>(() => { return (uint)cbAccel2.SelectedIndex; }, (x) => changedIndex = (int)x), OnChangeAccel2, "accel2");
        }

        protected override void OnLoadNode()
        {
            base.OnLoadNode();

            cbMainAction.SelectedIndex = (int)node.GetValue("usuallySetTo1");
            cbFloorAction.SelectedIndex = (int)node.GetValue("usuallySetTo2");
            cbActionOnGuard.SelectedIndex = (int)node.GetValue("numberGuard");
            cbActionOnHit.SelectedIndex = (int)node.GetValue("numberWhenHit");
            cbActionOnParry.SelectedIndex = (int)node.GetValue("numberOffset");
            cbAccel1.SelectedIndex = (int)node.GetValue("accel1");
            cbAccel2.SelectedIndex = (int)node.GetValue("accel2");
        }

        public void LoadNode(int index)
        {
            LoadNode(activeData.Unit.GetPropertyGroup(PropertyType.MissileConfig).GetNode(index));
        }

        public override void UpdateNode()
        {

            base.UpdateNode();
        }

        private void OnMainActionChanged(DataControlEventParams p)
        {
            node.SetValue("usuallySetTo1", (uint)cbMainAction.SelectedIndex);
            OnChangeValue(p);
        }

        private void OnFloorActionChanged(DataControlEventParams p)
        {
            node.SetValue("usuallySetTo2", (uint)cbFloorAction.SelectedIndex);
            OnChangeValue(p);
        }

        private void OnActionGuardChanged(DataControlEventParams p)
        {
            node.SetValue("numberWhenHit", (uint)cbActionOnGuard.SelectedIndex);
            OnChangeValue(p);
        }

        private void OnActionHitChanged(DataControlEventParams p)
        {
            node.SetValue("numberOffset", (uint)cbActionOnHit.SelectedIndex);
            OnChangeValue(p);
        }

        private void OnActionParryChanged(DataControlEventParams p)
        {
            node.SetValue("usuallySetTo1", (uint)cbActionOnParry.SelectedIndex);
            OnChangeValue(p);
        }

        private void OnClickOpenAccel2(object sender, EventArgs e)
        {
            LoadAccelForm(false);
        }

        private void OnClickOpenAccel1(object sender, EventArgs e)
        {
            LoadAccelForm();
        }

        private void LoadAccelForm(bool primaryAccel = true)
        {
            int accelIndex = primaryAccel ? cbAccel1.SelectedIndex : cbAccel2.SelectedIndex;

            ModifyAcceleration modifyAccel = new ModifyAcceleration(activeData, accelIndex, true);
            modifyAccel.AccelTab.Toolset.AddExtraCombo(cbAccel1);
            modifyAccel.AccelTab.Toolset.AddExtraCombo(cbAccel2);

            if (modifyAccel.ShowDialog() == DialogResult.OK && modifyAccel.GetSelectedIndex() != -1)
            {
                if (primaryAccel)
                {
                    cbAccel1.SelectedIndex = modifyAccel.GetSelectedIndex();
                    OnChangeAccel1(new DataControlEventParams((uint)modifyAccel.GetSelectedIndex(), ControlSet.GetControlByKey("accel1")));
                }
                else
                {
                    cbAccel2.SelectedIndex = modifyAccel.GetSelectedIndex();
                    OnChangeAccel2(new DataControlEventParams((uint)modifyAccel.GetSelectedIndex(), ControlSet.GetControlByKey("accel2")));
                }
            }
        }

        private void OnChangeAccel1(DataControlEventParams p)
        {
            node.SetValue("accel1", (uint)cbAccel1.SelectedIndex);
            OnChangeValue(p);
            
        }

        private void OnChangeAccel2(DataControlEventParams p)
        {

            node.SetValue("accel2", (uint)cbAccel2.SelectedIndex);
            OnChangeValue(p);
        }
    }
}
