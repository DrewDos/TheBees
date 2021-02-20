namespace TheBees.Forms
{
    partial class ModifyAction
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cbUnit = new System.Windows.Forms.ComboBox();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.cbProperty = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.panelNoData = new System.Windows.Forms.Panel();
            this.btnCopyAction = new System.Windows.Forms.Button();
            this.btnNewAction = new System.Windows.Forms.Button();
            this.lblNoActionMessage = new System.Windows.Forms.Label();
            this.lblDataCount = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOpenSpriteViewer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSpriteSelector = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDataToolsExtra = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemNewFunction = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNewMotion = new System.Windows.Forms.ToolStripMenuItem();
            this.menuModifyProperty = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.rbBase = new System.Windows.Forms.RadioButton();
            this.rbCollisionProperties = new System.Windows.Forms.RadioButton();
            this.rbAttackProperties = new System.Windows.Forms.RadioButton();
            this.lblDataAddress = new System.Windows.Forms.Label();
            this.btnGoBack = new System.Windows.Forms.Button();
            this.lblActionIndex = new System.Windows.Forms.Label();
            this.btnGetDoubleFunctions = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.actionEditTextbox1 = new TheBees.Forms.ActionEditTextbox();
            this.actionToolset1 = new TheBees.Controls.ActionToolset();
            this.actionDataToolset1 = new TheBees.Controls.ActionDataToolset();
            this.lbDataIndex = new TheBees.Controls.ActionDataListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox.SuspendLayout();
            this.panelNoData.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.menuDataToolsExtra.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbUnit
            // 
            this.cbUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUnit.FormattingEnabled = true;
            this.cbUnit.Location = new System.Drawing.Point(15, 52);
            this.cbUnit.Name = "cbUnit";
            this.cbUnit.Size = new System.Drawing.Size(155, 21);
            this.cbUnit.TabIndex = 2;
            this.cbUnit.Tag = "UnitSelect";
            // 
            // cbCategory
            // 
            this.cbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(16, 95);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(154, 21);
            this.cbCategory.TabIndex = 3;
            this.cbCategory.Tag = "CategorySelect";
            // 
            // cbProperty
            // 
            this.cbProperty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProperty.FormattingEnabled = true;
            this.cbProperty.Location = new System.Drawing.Point(16, 140);
            this.cbProperty.Name = "cbProperty";
            this.cbProperty.Size = new System.Drawing.Size(154, 21);
            this.cbProperty.TabIndex = 4;
            this.cbProperty.Tag = "PropertySelect";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Unit";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Action Set";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Action";
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.panelNoData);
            this.groupBox.Location = new System.Drawing.Point(194, 52);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(522, 389);
            this.groupBox.TabIndex = 10;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Data Properties";
            // 
            // panelNoData
            // 
            this.panelNoData.Controls.Add(this.btnCopyAction);
            this.panelNoData.Controls.Add(this.btnNewAction);
            this.panelNoData.Controls.Add(this.lblNoActionMessage);
            this.panelNoData.Location = new System.Drawing.Point(15, 19);
            this.panelNoData.Name = "panelNoData";
            this.panelNoData.Size = new System.Drawing.Size(334, 213);
            this.panelNoData.TabIndex = 0;
            this.panelNoData.Visible = false;
            // 
            // btnCopyAction
            // 
            this.btnCopyAction.Location = new System.Drawing.Point(16, 69);
            this.btnCopyAction.Name = "btnCopyAction";
            this.btnCopyAction.Size = new System.Drawing.Size(124, 23);
            this.btnCopyAction.TabIndex = 1;
            this.btnCopyAction.Text = "Copy Existing Action";
            this.btnCopyAction.UseVisualStyleBackColor = true;
            // 
            // btnNewAction
            // 
            this.btnNewAction.Location = new System.Drawing.Point(16, 40);
            this.btnNewAction.Name = "btnNewAction";
            this.btnNewAction.Size = new System.Drawing.Size(124, 23);
            this.btnNewAction.TabIndex = 1;
            this.btnNewAction.Text = "Create New Action";
            this.btnNewAction.UseVisualStyleBackColor = true;
            // 
            // lblNoActionMessage
            // 
            this.lblNoActionMessage.AutoSize = true;
            this.lblNoActionMessage.Location = new System.Drawing.Point(16, 15);
            this.lblNoActionMessage.Name = "lblNoActionMessage";
            this.lblNoActionMessage.Size = new System.Drawing.Size(185, 13);
            this.lblNoActionMessage.TabIndex = 0;
            this.lblNoActionMessage.Text = "No actions are available for this group";
            // 
            // lblDataCount
            // 
            this.lblDataCount.AutoSize = true;
            this.lblDataCount.Location = new System.Drawing.Point(681, 447);
            this.lblDataCount.Name = "lblDataCount";
            this.lblDataCount.Size = new System.Drawing.Size(35, 13);
            this.lblDataCount.TabIndex = 4;
            this.lblDataCount.Text = "Count";
            this.lblDataCount.Visible = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(16, 203);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(59, 13);
            this.label17.TabIndex = 3;
            this.label17.Text = "Data Index";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(882, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOpenSpriteViewer});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            this.viewToolStripMenuItem.DropDownOpening += new System.EventHandler(this.ViewDropDownOpening);
            // 
            // menuOpenSpriteViewer
            // 
            this.menuOpenSpriteViewer.Name = "menuOpenSpriteViewer";
            this.menuOpenSpriteViewer.Size = new System.Drawing.Size(174, 22);
            this.menuOpenSpriteViewer.Text = "Open Sprite Viewer";
            this.menuOpenSpriteViewer.Click += new System.EventHandler(this.OnOpenSpriteViewer);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSpriteSelector});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            this.toolsToolStripMenuItem.DropDownOpening += new System.EventHandler(this.OnToolsDropDownOpening);
            // 
            // menuSpriteSelector
            // 
            this.menuSpriteSelector.Name = "menuSpriteSelector";
            this.menuSpriteSelector.Size = new System.Drawing.Size(152, 22);
            this.menuSpriteSelector.Text = "Sprite Selector";
            this.menuSpriteSelector.Click += new System.EventHandler(this.OnClickMenuSpriteSelector);
            // 
            // menuDataToolsExtra
            // 
            this.menuDataToolsExtra.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemNewFunction,
            this.menuItemNewMotion});
            this.menuDataToolsExtra.Name = "menuDataModify";
            this.menuDataToolsExtra.Size = new System.Drawing.Size(172, 48);
            // 
            // menuItemNewFunction
            // 
            this.menuItemNewFunction.Name = "menuItemNewFunction";
            this.menuItemNewFunction.Size = new System.Drawing.Size(171, 22);
            this.menuItemNewFunction.Text = "New Function Call";
            // 
            // menuItemNewMotion
            // 
            this.menuItemNewMotion.Name = "menuItemNewMotion";
            this.menuItemNewMotion.Size = new System.Drawing.Size(171, 22);
            this.menuItemNewMotion.Text = "New Motion";
            // 
            // menuModifyProperty
            // 
            this.menuModifyProperty.Name = "menuModifyProperty";
            this.menuModifyProperty.Size = new System.Drawing.Size(61, 4);
            // 
            // rbBase
            // 
            this.rbBase.AutoSize = true;
            this.rbBase.Location = new System.Drawing.Point(738, 157);
            this.rbBase.Name = "rbBase";
            this.rbBase.Size = new System.Drawing.Size(49, 17);
            this.rbBase.TabIndex = 14;
            this.rbBase.TabStop = true;
            this.rbBase.Text = "Base";
            this.rbBase.UseVisualStyleBackColor = true;
            // 
            // rbCollisionProperties
            // 
            this.rbCollisionProperties.AutoSize = true;
            this.rbCollisionProperties.Location = new System.Drawing.Point(738, 203);
            this.rbCollisionProperties.Name = "rbCollisionProperties";
            this.rbCollisionProperties.Size = new System.Drawing.Size(113, 17);
            this.rbCollisionProperties.TabIndex = 17;
            this.rbCollisionProperties.TabStop = true;
            this.rbCollisionProperties.Text = "Collision Properties";
            this.rbCollisionProperties.UseVisualStyleBackColor = true;
            // 
            // rbAttackProperties
            // 
            this.rbAttackProperties.AutoSize = true;
            this.rbAttackProperties.Location = new System.Drawing.Point(738, 180);
            this.rbAttackProperties.Name = "rbAttackProperties";
            this.rbAttackProperties.Size = new System.Drawing.Size(106, 17);
            this.rbAttackProperties.TabIndex = 16;
            this.rbAttackProperties.TabStop = true;
            this.rbAttackProperties.Text = "Attack Properties";
            this.rbAttackProperties.UseVisualStyleBackColor = true;
            // 
            // lblDataAddress
            // 
            this.lblDataAddress.AutoSize = true;
            this.lblDataAddress.Location = new System.Drawing.Point(716, 140);
            this.lblDataAddress.Name = "lblDataAddress";
            this.lblDataAddress.Size = new System.Drawing.Size(71, 13);
            this.lblDataAddress.TabIndex = 18;
            this.lblDataAddress.Text = "Data Address";
            // 
            // btnGoBack
            // 
            this.btnGoBack.Location = new System.Drawing.Point(722, 261);
            this.btnGoBack.Name = "btnGoBack";
            this.btnGoBack.Size = new System.Drawing.Size(75, 23);
            this.btnGoBack.TabIndex = 44;
            this.btnGoBack.Text = "Go Back";
            this.btnGoBack.UseVisualStyleBackColor = true;
            this.btnGoBack.Click += new System.EventHandler(this.OnClickGoBack);
            // 
            // lblActionIndex
            // 
            this.lblActionIndex.AutoSize = true;
            this.lblActionIndex.Location = new System.Drawing.Point(733, 326);
            this.lblActionIndex.Name = "lblActionIndex";
            this.lblActionIndex.Size = new System.Drawing.Size(96, 13);
            this.lblActionIndex.TabIndex = 45;
            this.lblActionIndex.Text = "Action Index: 0000";
            // 
            // btnGetDoubleFunctions
            // 
            this.btnGetDoubleFunctions.Location = new System.Drawing.Point(719, 382);
            this.btnGetDoubleFunctions.Name = "btnGetDoubleFunctions";
            this.btnGetDoubleFunctions.Size = new System.Drawing.Size(107, 23);
            this.btnGetDoubleFunctions.TabIndex = 46;
            this.btnGetDoubleFunctions.Text = "GetDoubleFunctions";
            this.btnGetDoubleFunctions.UseVisualStyleBackColor = true;
            this.btnGetDoubleFunctions.Click += new System.EventHandler(this.OnClickGetDoubleFunctions);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(722, 411);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 47;
            this.button1.Text = "Next";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // actionEditTextbox1
            // 
            this.actionEditTextbox1.Location = new System.Drawing.Point(12, 400);
            this.actionEditTextbox1.Name = "actionEditTextbox1";
            this.actionEditTextbox1.Size = new System.Drawing.Size(158, 20);
            this.actionEditTextbox1.TabIndex = 43;
            // 
            // actionToolset1
            // 
            this.actionToolset1.Location = new System.Drawing.Point(16, 166);
            this.actionToolset1.Name = "actionToolset1";
            this.actionToolset1.Size = new System.Drawing.Size(154, 31);
            this.actionToolset1.TabIndex = 37;
            // 
            // actionDataToolset1
            // 
            this.actionDataToolset1.Location = new System.Drawing.Point(12, 363);
            this.actionDataToolset1.Name = "actionDataToolset1";
            this.actionDataToolset1.Size = new System.Drawing.Size(158, 31);
            this.actionDataToolset1.TabIndex = 36;
            // 
            // lbDataIndex
            // 
            this.lbDataIndex.FormattingEnabled = true;
            this.lbDataIndex.Location = new System.Drawing.Point(15, 223);
            this.lbDataIndex.Name = "lbDataIndex";
            this.lbDataIndex.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbDataIndex.Size = new System.Drawing.Size(155, 134);
            this.lbDataIndex.TabIndex = 35;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(719, 353);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 48;
            this.button2.Text = "Find";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.OnFindActions);
            // 
            // ModifyAction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 469);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnGetDoubleFunctions);
            this.Controls.Add(this.lblActionIndex);
            this.Controls.Add(this.btnGoBack);
            this.Controls.Add(this.actionEditTextbox1);
            this.Controls.Add(this.actionToolset1);
            this.Controls.Add(this.actionDataToolset1);
            this.Controls.Add(this.lbDataIndex);
            this.Controls.Add(this.lblDataAddress);
            this.Controls.Add(this.rbCollisionProperties);
            this.Controls.Add(this.rbAttackProperties);
            this.Controls.Add(this.rbBase);
            this.Controls.Add(this.lblDataCount);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbProperty);
            this.Controls.Add(this.cbCategory);
            this.Controls.Add(this.cbUnit);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ModifyAction";
            this.Text = "Action Modifier";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClose);
            this.Shown += new System.EventHandler(this.OnShown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ModifyAction_KeyDown);
            this.groupBox.ResumeLayout(false);
            this.panelNoData.ResumeLayout(false);
            this.panelNoData.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.menuDataToolsExtra.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.ComboBox cbUnit;
        protected System.Windows.Forms.ComboBox cbCategory;
        protected System.Windows.Forms.ComboBox cbProperty;
        protected System.Windows.Forms.Label label1;
        protected System.Windows.Forms.Label label2;
        protected System.Windows.Forms.Label label3;
        protected System.Windows.Forms.GroupBox groupBox;
        protected System.Windows.Forms.Label label17;
        protected System.Windows.Forms.MenuStrip menuStrip1;
        protected System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem menuOpenSpriteViewer;
        protected System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        protected System.Windows.Forms.Label lblDataCount;
        private System.Windows.Forms.ContextMenuStrip menuDataToolsExtra;
        private System.Windows.Forms.ToolStripMenuItem menuItemNewFunction;
        private System.Windows.Forms.ToolStripMenuItem menuItemNewMotion;
        private System.Windows.Forms.ContextMenuStrip menuModifyProperty;
        private System.Windows.Forms.RadioButton rbBase;
        private System.Windows.Forms.RadioButton rbCollisionProperties;
        private System.Windows.Forms.RadioButton rbAttackProperties;
        private System.Windows.Forms.Label lblDataAddress;
        private System.Windows.Forms.Panel panelNoData;
        private System.Windows.Forms.Button btnCopyAction;
        private System.Windows.Forms.Button btnNewAction;
        private System.Windows.Forms.Label lblNoActionMessage;
        private Controls.ActionDataListBox lbDataIndex;
        private Controls.ActionDataToolset actionDataToolset1;
        private Controls.ActionToolset actionToolset1;
        private ActionEditTextbox actionEditTextbox1;
        private System.Windows.Forms.Button btnGoBack;
        private System.Windows.Forms.Label lblActionIndex;
        private System.Windows.Forms.Button btnGetDoubleFunctions;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuSpriteSelector;
        private System.Windows.Forms.Button button2;


    }
}

