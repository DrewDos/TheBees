using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TheBees.Description;
using TheBees.GameRom;
using TheBees.UnitData;
using TheBees.Sprites;
using TheBees.Forms.Verification;

namespace TheBees.Forms
{

    public abstract class NodePanel
    {
        protected ActiveDataElement activeData;

        protected ModifyAction form;

        protected int pageCount = 0;
        protected NodeLayout[] pages;
            
        protected TabControl tabControl;
        protected TabPage[] tabPages;

        private VerifyHandler verifyHandler;
        public VerifyHandler Verification { get { return verifyHandler; } }

        //protected OnEditChangedDelegate onEditChanged;

        abstract protected void LoadPanel();
        abstract protected void SetupPages();
        abstract protected void SetVariables();
        abstract public void LoadNode(DataNode source);

        public NodePanel(int xPosition, int yPosition, int width, int height, ActiveDataElement activeDataSource)
        {
            activeData = activeDataSource;
            //SetAllActiveData();

            SetVariables();
            LoadPanel();
            SetupPages();
            verifyHandler = new VerifyHandler();
            SetupVerifyHandler();
            Array.ForEach(pages, (x) => verifyHandler.AddChild(x.Verification));
            InitializeTabControl(xPosition, yPosition, width, height);
        }

        private void SetupVerifyHandler()
        {
            verifyHandler.ProceedEvent += UpdateNodeData;
        }

        /*
        public void SetAllActiveData()
        {

            for (int i = 0; i < pageCount; i++)
            {
                pages[i].SetActiveData(activeData);
            }
        }
        */

        protected void InitializeTabControl(int xPosition, int yPosition, int width, int height)
        {
            tabControl = new TabControl();
            
            tabControl.Width = width;
            tabControl.Height = height;
            tabControl.Location = new System.Drawing.Point(xPosition, yPosition);

            LoadTabs();
        }

        private void LoadTabs()
        {
            tabPages = new TabPage[pageCount];

            for (int i = 0; i < pageCount; i++)
            {
                tabPages[i] =  new TabPage();

                tabControl.Controls.Add(tabPages[i]);
                tabPages[i].Location = new System.Drawing.Point(6, 250);
                //tabPages[i].Name = "tabMain";
                tabPages[i].Padding = new System.Windows.Forms.Padding(3);
                tabPages[i].Size = new System.Drawing.Size(585, 347);
                tabPages[i].TabIndex = 0;
                //tabPages[i].Text = pages[i].Caption;
                tabPages[i].UseVisualStyleBackColor = true;


                tabPages[i].Controls.Add(pages[i]);
                pages[i].Location = new Point(0, 12);
                //pages[i].Dock = DockStyle.Fill;
                pages[i].SendToBack();

                tabControl.Visible = false;
            }

            OnLoadTabs();
        }

        public virtual void UpdateNode(DataNode source)
        {
            throw new NotImplementedException();
        }

        protected virtual void OnLoadTabs()
        {
            return;
        }

        public void Hide()
        {
            tabControl.Visible = false;
        }

        public void Show()
        {
            tabControl.Visible = true;
        }

        protected void EnableTab(int index, bool enable = true)
        {
            tabPages[index].Enabled = enable;
        }
       
        public virtual void UpdateNodeData()
        {
            for (int i = 0; i < pages.Length; i++)
            {
                pages[i].UpdateNode();
            }
        }

        public TabControl GetTabControl()
        {
            return tabControl;
        }

        public void UpdateAllChanges()
        {
            for (int i = 0; i < pageCount; i++)
            {
                if (pages[i].Verification.Pending)
                {
                    pages[i].UpdateNode();
                }
            }
        }

        public bool VerifyChanges()
        {
            return verifyHandler.Confirm("Update changes?", "Update Changes?");
        }
    }
    
}
