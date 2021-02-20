using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TheBees.UnitData;

namespace TheBees.Forms
{
    public partial class EditCommandName : Form
    {
        private DirectionalKeyAction keyAction;
        private ModifyCommand modifyCmd;
        private UnitCommand activeCmd;

        public EditCommandName(ModifyCommand srcModifyCmd, DirectionalKeyAction srcKeyAction)
        {
            InitializeComponent();

            modifyCmd = srcModifyCmd;
            modifyCmd.SpecialBankSelectEvent += OnCommandSelect;
            if (srcKeyAction == null)
                throw new ArgumentException("srcKeyAction cannot be null");

            keyAction = srcKeyAction;
            tbCommandName.TextSendEvent += AssignCommandText;

        }

        public EditCommandName()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyAction.Process(ModifierKeys, keyData))
                return true;

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void OnClosed(object sender, FormClosedEventArgs e)
        {
            modifyCmd.SpecialBankSelectEvent -= OnCommandSelect;
        }

        private void OnCommandSelect(UnitCommand command)
        {
            activeCmd = command;
            if (command != null)
            {
                string tag = command.Tag;
                if (tag == "")
                    tag = command.Address.ToString("X8");

                tbCommandName.Text = tag;
                tbCommandName.SelectAll();
            }
            else
            {
                tbCommandName.Text = "";
            }
        }

        private void AssignCommandText(string newText)
        {
            if (activeCmd != null)
            {
                activeCmd.SetTag(newText);
                modifyCmd.UpdateUnitCommandText(UserCommandMap.GetCommandIndex(activeCmd.Address), newText);
            }
        }
    }
}
