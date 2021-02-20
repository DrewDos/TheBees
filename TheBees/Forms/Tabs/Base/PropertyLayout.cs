using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TheBees.UnitData;
using TheBees.Forms.Support.DataControl;
using TheBees.General;
using TheBees.Controls;

namespace TheBees.Forms
{
    public class PropertyLayout : NodeLayout
    {
        protected int primaryIndex;
        public int PrimaryIndex { get { return primaryIndex; } set { UpdateIndexList(); PrimaryCombo.SelectedIndex = value; UpdatePrimarySelect(); } }
        protected int changedIndex;
        public Action<int> PrimaryIndexChanged;
        protected virtual PropertyType MainType { get { throw new Exception("MainType not set"); } }
        protected virtual ComboBox PrimaryCombo { get { throw new Exception("Combo not set for property layout"); } }
        public virtual PropertyToolset Toolset { get { throw new Exception("Toolset not set"); } }

        public PropertyLayout(ActiveDataElement source)
            :base(source)
        {
        }

        public PropertyLayout()
            :base()
        {
        }
        protected override void RegisterControls()
        {

            ControlSet.RegisterControl(
                PrimaryCombo, new Ref<uint>(() => (uint)changedIndex, (x) => changedIndex = (int)x), 
                OnChangePrimaryIndex, "accel"
                )
                .CaptureVerification = false;

            base.RegisterControls();
        }

        protected override void OnLoadNode()
        {
            UpdateIndexList();

            base.OnLoadNode();
        }

        private void UpdateIndexList()
        {
            if (unitChanged)
            {
                PrimaryCombo.Items.Clear();
                PrimaryCombo.Items.AddRange(UnitDescription.GetPropertyGroupIndexes(activeData.Unit, MainType));
            }
        }

        protected virtual void OnPrimaryIndexChanged()
        {
            throw new NotImplementedException("Not implemented for this tab");
        }

        protected override void OnPrimaryYes()
        {
            base.OnPrimaryYes();
        }

        protected override void OnPrimaryProceed()
        {
            primaryIndex = changedIndex;
            UpdatePrimarySelect();
            if (PrimaryIndexChanged != null)
                PrimaryIndexChanged(primaryIndex);

            base.OnPrimaryProceed();
        }
        protected override void OnPrimaryCancel()
        {
            PrimaryCombo.SelectedIndex = primaryIndex;

            base.OnPrimaryCancel();
        }

        public void LoadNode(int index)
        {
            LoadNode(activeData.Unit.GetPropertyGroup(MainType).GetNode(index));
            PrimaryCombo.SelectedIndex = index;
        }

        protected void UpdatePrimarySelect()
        {
            LoadNode(primaryIndex);
        }

        protected virtual void OnChangePrimaryIndex(DataControlEventParams p)
        {
            primaryIndex = (int)p.Value;
            LoadNode(p.Value);
        }
    }
}
