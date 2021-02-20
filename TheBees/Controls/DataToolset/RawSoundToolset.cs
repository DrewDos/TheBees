using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TheBees.Forms;
using TheBees.Sound;

namespace TheBees.Controls
{
    public class RawSoundToolset : DataToolset
    {
        private BitEdit edit;
        //private ContextMenu extraMenu;

        private Action reloadValue;
        //private MenuItem itemCopy, itemPaste;

        public event Action<int> ComboChangedEvent;

        public RawSoundToolset()
            : base()
        {            
            DataToolConfig config = new DataToolConfig
            (
                DataToolButtonType.New,
                DataToolButtonType.Remove
            );

            config.OnAddEvent += OnClickNew;
            config.OnRemoveEvent += OnClickRemove;

            SetConfig(config);
        }

        public void SetControls(Action srcReloadValue, BitEdit srcEdit)
        {
            reloadValue = srcReloadValue;
            edit = srcEdit;
        }

        private void SetupExtraMenu()
        {
            //extraMenu = new ContextMenu();

            //itemCopy = new MenuItem("&Copy Current Property", (o, e) => OnMenuCopyProperty());
            //itemPaste = new MenuItem("&Append Copied Property", (o, e) => OnMenuPasteProperty());

            //extraMenu.MenuItems.Add(itemCopy);
            //extraMenu.MenuItems.Add(itemPaste);
        }

        private void OnClickNew()
        {
            ConvertWav convertForm = new ConvertWav();
            if (convertForm.ShowDialog() == DialogResult.OK)
            {
                SampleDataMap.SetSampleData((int)edit.Value, convertForm.NewSampleBytes);
                if (reloadValue != null)
                    reloadValue();
            }
        }
        
        private void OnClickRemove()
        {
            if (MessageBox.Show("Are you sure you want to remove the selected index?", "Confirm Data Removal", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SampleDataMap.MainGroup.ClearBlock((int)edit.Value);

                if (reloadValue != null)
                    reloadValue();
            }
        }
    }
}
