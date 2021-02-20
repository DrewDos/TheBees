using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TheBees.Forms;
using TheBees.GameRom;
using TheBees.UnitData;

namespace TheBees.Controls
{
    public class ActionToolset : DataToolset
    {
        private ComboBox comboBox;
        private ActiveDataElement activeData;
        private UnitSelector selector;

        public ActionToolset()
            : base()
        {
            DataToolConfig config = new DataToolConfig
            (
                DataToolButtonType.New,
                DataToolButtonType.Copy,
                DataToolButtonType.Remove
            );

            config.OnCopyEvent += () => DuplicateAction();
            config.OnAddEvent += () => OnNewAction();
            SetConfig(config);
        }

        public void SetControls(UnitSelector srcSelector, ComboBox srcCombo)
        {
            activeData = srcSelector.ActiveData;
            comboBox = srcCombo;
            selector = srcSelector;

            selector.SelectAction += UpdateActionTools;
        }
        private void CheckValues()
        {
        }

        private void UpdateActionTools()
        {

            // update action controls
            if (activeData.Action == null)
            {
                btnCopy.Enabled = false;
                btnRemove.Enabled = false;
            }
            else
            {
                btnCopy.Enabled = true;
                btnRemove.Enabled = true;
            }
        }

        private int DuplicateAction()
        {
            if (activeData.Group.AppendActionRecorded(selector.ActionNum) < 0)
                return -1;

            int newIndex = activeData.Group.Count - 1;
            comboBox.Items.Add("Copy of " + comboBox.Items[selector.ActionNum].ToString());
            selector.MakeSelection(-1, -1, activeData.Group.Count - 1, 0);

            return -1;
        }

        private void OnNewAction()
        {
            NewActionDialog newAction = new NewActionDialog();
            newAction.Reference = new ActionReference(selector.UnitNum, selector.GroupNum, activeData.Group.Count, 0);

            if (newAction.ShowDialog() == DialogResult.OK)
            {
                int newActionIndex = activeData.Group.AppendActionRecorded(newAction.NewAction);

                comboBox.Items.Add(newAction.NewAction.Address.ToString("X8"));
                selector.MakeSelection(-1, -1, newActionIndex, 0);
            }
        }
    }
}
