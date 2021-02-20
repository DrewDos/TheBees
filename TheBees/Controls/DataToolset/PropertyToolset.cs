using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TheBees.Forms;
using TheBees.UnitData;
using TheBees.GameRom;
using TheBees.Forms.Verification;

namespace TheBees.Controls
{
    public class PropertyToolset : DataToolset
    {
        private ComboBox combo;
        private ComboBox [] comboExtra;
        private PropertyGroup pGroup;
        private ContextMenu extraMenu;

        private Action beforeChange;
        private MenuItem itemCopy, itemPaste;

        public event Action<int> ComboChangedEvent;

        public PropertyToolset()
            : base()
        {            
            DataToolConfig config = new DataToolConfig
            (
                DataToolButtonType.New,
                DataToolButtonType.Copy,
                DataToolButtonType.Remove,
                DataToolButtonType.Extra
            );

            config.OnAddEvent += OnClickNew;
            config.OnCopyEvent += OnClickCopy;
            config.OnRemoveEvent += OnClickRemove;

            SetConfig(config);
        }

        public void SetControls(Action srcBeforeChange, ComboBox srcCombo, params ComboBox [] srcComboExtra)
        {
            beforeChange = srcBeforeChange;
            combo = srcCombo;
            comboExtra = srcComboExtra;
        }

        public void AddExtraCombo(ComboBox newCombo)
        {
            List<ComboBox> tmpList = comboExtra.ToList();
            tmpList.Add(newCombo);
            comboExtra = tmpList.ToArray();
        }

        public void SetPropertyGroup(PropertyGroup newGroup)
        {
            pGroup = newGroup;
        }

        private void SetupExtraMenu()
        {
            extraMenu = new ContextMenu();

            itemCopy = new MenuItem("&Copy Current Property", (o, e) => OnMenuCopyProperty());
            itemPaste = new MenuItem("&Append Copied Property", (o, e) => OnMenuPasteProperty());

            extraMenu.MenuItems.Add(itemCopy);
            extraMenu.MenuItems.Add(itemPaste);
        }

        private void OnClickNew()
        {
            if (beforeChange != null)
                beforeChange();

            DataNode node = NodeUtil.GetProperNode(pGroup.Type, 0);

            node.MakeEmptyBuffer();
            int res = pGroup.AppendNodeRecorded(node);

            if (res == -1)
                throw new Exception("Not enough space");

            AddAndSelect(res);
        }

        private void OnClickCopy()
        {
            if (beforeChange != null)
                beforeChange();

            int res = pGroup.AppendNodeRecorded(combo.SelectedIndex);

            if (res == -1)
                throw new Exception("Not enough space");

            AddAndSelect(res);
        }

        private void OnClickRemove()
        {
        }

        private void OnMenuCopyProperty()
        {
            Clipboard.SetItem(new ClipItemDataNode(pGroup.GetNode(combo.SelectedIndex).GetCopy(true)));
        }
        private void OnMenuPasteProperty()
        {
            if (beforeChange != null)
                beforeChange();

            int newIndex = pGroup.AppendNodeRecorded((DataNode[])Clipboard.ClipboardItem.GetItems());

            if (newIndex == -1)
                throw new Exception("Not enough free space");

            AddAndSelect(newIndex);
        }

        private void AddAndSelect(int newIndex)
        {
            combo.Items.Add(newIndex.ToString("X4"));
            SelectIndex(newIndex);

            if (comboExtra != null && comboExtra.Length > 0)
            {
                foreach (ComboBox currCombo in comboExtra)
                {
                    currCombo.Items.Add(newIndex.ToString("X4"));
                }
            }
        }

        private void SelectIndex(int newIndex)
        {
            combo.SelectedIndex = newIndex;
            if (ComboChangedEvent != null)
                ComboChangedEvent(newIndex);
        }
    }
}
