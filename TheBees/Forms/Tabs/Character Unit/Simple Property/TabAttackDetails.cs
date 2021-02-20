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
using TheBees.General;
using TheBees.Forms.Support.DataControl;
using TheBees.Forms.Verification;

namespace TheBees.Forms
{
    public partial class TabAttackDetails : NodeLayout
    {
        
        
        private static int attackIndex;
        private static int changedIndex;
        private static int startIndex = -1;

        public event Action<int> PrimaryIndexChanged;

        public TabAttackDetails(ActiveDataElement source = null)
            : base(source)
        {
            propertyToolset1.SetControls(Verification.ConfirmNoMessage, cbAttackDef);
            propertyToolset1.ComboChangedEvent += (x) => { changedIndex = x;  OnChangeAttack(new DataControlEventParams((uint)x, ControlSet.GetControlByKey("primary"))); };
        }

        // fill in values for nodes
        protected override void RegisterControls()
        {
            tbHitEffect1.MaxValue =  0xFFFF;
            tbHitEffect2.MaxValue =  0xFFFF;
            tbGuardDisp.MaxValue =  0xFFFF;
            tbControlEnemy.MaxValue =  0xFFFF;
            tbCrouchCollision.MaxValue =  0xFFFF;
            tbBendBack.MaxValue =  0xFFFF;
            tbDamage.MaxValue =  0xFFFF;
            tbHitBack.MaxValue = 0xFFFF;
            tbStunGauge.MaxValue = 0xFFFF;
            tbHitEffects.MaxValue = 0xFFFF;

            tbFlags1.MaxValue = 0xFFFF;
            tbFlags2.MaxValue = 0xFFFF;

            ControlSet.RegisterControl(tbHitEffect1, "effectHits1");
            ControlSet.RegisterControl(tbHitEffect2, "effectHits2");
            ControlSet.RegisterControl(tbGuardDisp, "guardDispPosEffect");
            ControlSet.RegisterControl(tbControlEnemy, "andCtrlEnemy");
            ControlSet.RegisterControl(tbCrouchCollision, "jgmtOnLowerGuard");
            ControlSet.RegisterControl(tbBendBack, "bendBackReductVal");
            ControlSet.RegisterControl(tbDamage, "damage");
            ControlSet.RegisterControl(tbHitBack, "boolHitBack");
            ControlSet.RegisterControl(tbStunGauge, "gaugeStun");
            ControlSet.RegisterControl(tbHitEffects, "hitEffectsSndGfx");
            ControlSet.RegisterControl(tbFlags1, "flags1");
            ControlSet.RegisterControl(tbFlags2, "flags2");
            ControlSet.RegisterControl(cbAttackDef, new Ref<uint>(() => { return (uint)changedIndex; }, (x) => changedIndex = (int)x), OnChangeAttack, "primary")
                .CaptureVerification = false;

        }

        protected override void OnLoadNode()
        {

            if (unitChanged)
            {
                cbAttackDef.Items.Clear();
                cbAttackDef.Items.AddRange(UnitDescription.GetPropertyGroupIndexes(activeData.Unit, PropertyType.AttackDetails));
                propertyToolset1.SetPropertyGroup(activeData.Unit.GetPropertyGroup(PropertyType.AttackDetails));
            }

            if (startIndex != -1)
            {
                cbAttackDef.SelectedIndex = (int)((Motion)activeData.Data).AttackIndex;
                startIndex = -1;
            }

            base.OnLoadNode();
        }

        protected override void OnPrimaryProceed()
        {
            UpdateAttackSelect();
            if (PrimaryIndexChanged != null)
                PrimaryIndexChanged(attackIndex);

            base.OnPrimaryProceed();
        }

        protected override void OnPrimaryCancel()
        {
            cbAttackDef.SelectedIndex = attackIndex;
        }

        private void UpdateAttackSelect()
        {
            LoadNodeFromGroup(attackIndex);
        }

        private void LoadNodeFromGroup(int index)
        {
            LoadNode(activeData.Unit.GetPropertyGroup(PropertyType.AttackDetails).GetNode(index));
        }

        public void LoadNodeExternal(int index)
        {
            startIndex = index;
            attackIndex = index;
            LoadNodeFromGroup(index);
        }
        private void OnChangeAttack(DataControlEventParams p)
        {
            attackIndex = changedIndex;
            Verification.Confirm("Update Attack", "Update attack index?");

            base.OnChangeValue(p);

        }

        private void OnClickCopy(object sender, EventArgs e)
        {
            if (activeData.Unit.GetPropertyGroup(PropertyType.AttackDetails).CopyNodeRecorded(attackIndex))
            {
                cbAttackDef.Items.Add("New Copy");
                cbAttackDef.SelectedIndex = cbAttackDef.Items.Count - 1;
                attackIndex = cbAttackDef.SelectedIndex;
                UpdateAttackSelect();
            }
        }

    }
}