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
    public partial class ModifyUserCommand : Form
    {
        ActiveDataElement activeData = null;
        private int commandIndex = 0;
        public int CommandIndex { get { return commandIndex; } }

        public ModifyUserCommand(ActiveDataElement activeDataSource, int sourceIndex)
        {
            this.activeData = activeDataSource;
            commandIndex = sourceIndex;

            InitializeComponent();
            Initialize();
        }

        public ModifyUserCommand(ActiveDataElement activeDataSource)
        {
            this.activeData = activeDataSource;

            InitializeComponent();
            Initialize();


        }
        public ModifyUserCommand()
        {
            InitializeComponent();

        }

        public void Initialize()
        {
            tabCommandHeader.PrimaryIndexChanged += OnCommandIndexChanged;
            tabCommandHeader.LoadNodeExternal(commandIndex);
            tabCommandLever.SetCommand(commandIndex);
            //tabCommandLever.LoadLever(0);
        }

        public void OnCommandIndexChanged(int index)
        {
            commandIndex = index;
            tabCommandLever.SetCommand(index);
        }

        private void OnOK(object sender, EventArgs e)
        {
        }

        private void OnSetCommand(object sender, EventArgs e)
        {
            tabCommandHeader.UpdateNode();
            tabCommandLever.UpdateNode();

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void OnCancel(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }




    }
}
