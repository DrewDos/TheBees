using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TheBees.Controls
{
    public partial class DataToolset : UserControl
    {
        private Dictionary<DataToolButtonType, Button> mappedButtons;
        private DataToolConfig config;

        public DataToolset()
        {
            InitializeComponent();
            SetMappedButtons();
        }

        public void SetConfig(DataToolConfig newConfig)
        {
            config = newConfig;
            int ctrlIndex = 0;
            foreach (DataToolButtonType btnType in config.ButtonTypes)
            {
                tableLayoutPanel.Controls.Add(mappedButtons[btnType], ctrlIndex, 0);
                ctrlIndex += 1;
            }

            foreach (Control control in tableLayoutPanel.Controls)
            {
                //control.Padding = new Padding(0);
                //control.Margin = new Padding(0);
            }
        }

        private void SetMappedButtons()
        {
            mappedButtons = new Dictionary<DataToolButtonType, Button>()
            {
                {DataToolButtonType.New, btnNew},
                {DataToolButtonType.Copy, btnCopy},
                {DataToolButtonType.MoveUp, btnMoveUp},
                {DataToolButtonType.MoveDown, btnMoveDown},
                {DataToolButtonType.Remove, btnRemove},
                {DataToolButtonType.Extra, btnExtra},

            };

        }

        public void DisableButton(DataToolButtonType type)
        {
            mappedButtons[type].Enabled = false;
        }

        public void EnableButton(DataToolButtonType type)
        {
            mappedButtons[type].Enabled = true;
        }
        private void OnBtnAddClick(object sender, EventArgs e)
        {
            config.OnAdd();
        }

        private void OnBtnCopyClick(object sender, EventArgs e)
        {
            config.OnCopy();
        }

        private void OnBtnMoveUpClick(object sender, EventArgs e)
        {
            config.OnMoveUp();
        }

        private void OnBtnMoveDownClick(object sender, EventArgs e)
        {
            config.OnMoveDown();
        }

        private void OnBtnRemoveClick(object sender, EventArgs e)
        {
            config.OnRemove();
        }

        private void OnBtnExtraClick(object sender, EventArgs e)
        {
            config.OnExtra();
        }
    }
}
