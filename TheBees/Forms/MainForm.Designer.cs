namespace TheBees.Forms
{
    partial class MainForm
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
            this.btnModifyCharacter = new System.Windows.Forms.Button();
            this.btnModifyProjectileDef = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnModifyCommands = new System.Windows.Forms.Button();
            this.btnEditSAEffect = new System.Windows.Forms.Button();
            this.btnModifyPallets = new System.Windows.Forms.Button();
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.menuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemOpenDirectory = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemClose = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.utilitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuGenerateStaticDescriptor = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupUnit = new System.Windows.Forms.GroupBox();
            this.btnModifySound = new System.Windows.Forms.Button();
            this.btnModifyEnemyCtrl = new System.Windows.Forms.Button();
            this.btnModifyOrbitalBasis = new System.Windows.Forms.Button();
            this.btnEditSupportGfx = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupGame = new System.Windows.Forms.GroupBox();
            this.btnRestoreBaseRom = new System.Windows.Forms.Button();
            this.btnReloadAll = new System.Windows.Forms.Button();
            this.btnDebug = new System.Windows.Forms.Button();
            this.newDebug = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.menuMain.SuspendLayout();
            this.groupUnit.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnModifyCharacter
            // 
            this.btnModifyCharacter.Location = new System.Drawing.Point(16, 106);
            this.btnModifyCharacter.Name = "btnModifyCharacter";
            this.btnModifyCharacter.Size = new System.Drawing.Size(160, 23);
            this.btnModifyCharacter.TabIndex = 0;
            this.btnModifyCharacter.Text = "Modify Character Actions";
            this.btnModifyCharacter.UseVisualStyleBackColor = true;
            this.btnModifyCharacter.Click += new System.EventHandler(this.OnClickModifyChar);
            // 
            // btnModifyProjectileDef
            // 
            this.btnModifyProjectileDef.Location = new System.Drawing.Point(16, 135);
            this.btnModifyProjectileDef.Name = "btnModifyProjectileDef";
            this.btnModifyProjectileDef.Size = new System.Drawing.Size(160, 23);
            this.btnModifyProjectileDef.TabIndex = 2;
            this.btnModifyProjectileDef.Text = "Modify Projectile Defs";
            this.btnModifyProjectileDef.UseVisualStyleBackColor = true;
            this.btnModifyProjectileDef.Click += new System.EventHandler(this.OnClickModifyMissileConfig);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(41, 294);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(160, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save Changes";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.OnClickSaveChanges);
            // 
            // btnModifyCommands
            // 
            this.btnModifyCommands.Location = new System.Drawing.Point(16, 19);
            this.btnModifyCommands.Name = "btnModifyCommands";
            this.btnModifyCommands.Size = new System.Drawing.Size(160, 23);
            this.btnModifyCommands.TabIndex = 4;
            this.btnModifyCommands.Text = "Modify Commands";
            this.btnModifyCommands.UseVisualStyleBackColor = true;
            this.btnModifyCommands.Click += new System.EventHandler(this.OnClickModifyCommands);
            // 
            // btnEditSAEffect
            // 
            this.btnEditSAEffect.Location = new System.Drawing.Point(16, 77);
            this.btnEditSAEffect.Name = "btnEditSAEffect";
            this.btnEditSAEffect.Size = new System.Drawing.Size(160, 23);
            this.btnEditSAEffect.TabIndex = 5;
            this.btnEditSAEffect.Text = "Edit Super Art Effect";
            this.btnEditSAEffect.UseVisualStyleBackColor = true;
            this.btnEditSAEffect.Click += new System.EventHandler(this.OnClickEditSuperArt);
            // 
            // btnModifyPallets
            // 
            this.btnModifyPallets.Location = new System.Drawing.Point(16, 48);
            this.btnModifyPallets.Name = "btnModifyPallets";
            this.btnModifyPallets.Size = new System.Drawing.Size(160, 23);
            this.btnModifyPallets.TabIndex = 6;
            this.btnModifyPallets.Text = "Modify Pallets";
            this.btnModifyPallets.UseVisualStyleBackColor = true;
            this.btnModifyPallets.Click += new System.EventHandler(this.OnModifyPalletsSprites);
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemFile,
            this.utilitiesToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(716, 24);
            this.menuMain.TabIndex = 7;
            this.menuMain.Text = "Main Menu";
            // 
            // menuItemFile
            // 
            this.menuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemOpen,
            this.menuItemOpenDirectory,
            this.menuItemClose,
            this.menuItemSave,
            this.toolStripSeparator1,
            this.menuItemExit});
            this.menuItemFile.Name = "menuItemFile";
            this.menuItemFile.Size = new System.Drawing.Size(37, 20);
            this.menuItemFile.Text = "&File";
            this.menuItemFile.DropDownOpening += new System.EventHandler(this.OnMenuFileOpening);
            // 
            // menuItemOpen
            // 
            this.menuItemOpen.Enabled = false;
            this.menuItemOpen.Name = "menuItemOpen";
            this.menuItemOpen.Size = new System.Drawing.Size(154, 22);
            this.menuItemOpen.Text = "&Open File";
            this.menuItemOpen.Click += new System.EventHandler(this.OnMenuOpenFile);
            // 
            // menuItemOpenDirectory
            // 
            this.menuItemOpenDirectory.Name = "menuItemOpenDirectory";
            this.menuItemOpenDirectory.Size = new System.Drawing.Size(154, 22);
            this.menuItemOpenDirectory.Text = "Open &Directory";
            this.menuItemOpenDirectory.Click += new System.EventHandler(this.OnMenuOpenDirectory);
            // 
            // menuItemClose
            // 
            this.menuItemClose.Name = "menuItemClose";
            this.menuItemClose.Size = new System.Drawing.Size(154, 22);
            this.menuItemClose.Text = "&Close";
            this.menuItemClose.Click += new System.EventHandler(this.OnMenuClose);
            // 
            // menuItemSave
            // 
            this.menuItemSave.Name = "menuItemSave";
            this.menuItemSave.Size = new System.Drawing.Size(154, 22);
            this.menuItemSave.Text = "&Save";
            this.menuItemSave.Click += new System.EventHandler(this.OnMenuSave);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(151, 6);
            // 
            // menuItemExit
            // 
            this.menuItemExit.Name = "menuItemExit";
            this.menuItemExit.Size = new System.Drawing.Size(154, 22);
            this.menuItemExit.Text = "E&xit";
            this.menuItemExit.Click += new System.EventHandler(this.OnMenuExit);
            // 
            // utilitiesToolStripMenuItem
            // 
            this.utilitiesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuGenerateStaticDescriptor});
            this.utilitiesToolStripMenuItem.Name = "utilitiesToolStripMenuItem";
            this.utilitiesToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.utilitiesToolStripMenuItem.Text = "&Utilities";
            // 
            // menuGenerateStaticDescriptor
            // 
            this.menuGenerateStaticDescriptor.Name = "menuGenerateStaticDescriptor";
            this.menuGenerateStaticDescriptor.Size = new System.Drawing.Size(210, 22);
            this.menuGenerateStaticDescriptor.Text = "&Generate Static Descriptor";
            this.menuGenerateStaticDescriptor.Click += new System.EventHandler(this.OnGenerateStaticDescriptor);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(19, 20);
            this.toolStripMenuItem1.Text = "&";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // groupUnit
            // 
            this.groupUnit.Controls.Add(this.btnModifySound);
            this.groupUnit.Controls.Add(this.btnModifyEnemyCtrl);
            this.groupUnit.Controls.Add(this.btnModifyOrbitalBasis);
            this.groupUnit.Controls.Add(this.btnEditSupportGfx);
            this.groupUnit.Controls.Add(this.button1);
            this.groupUnit.Controls.Add(this.btnModifyPallets);
            this.groupUnit.Controls.Add(this.btnEditSAEffect);
            this.groupUnit.Controls.Add(this.btnModifyProjectileDef);
            this.groupUnit.Controls.Add(this.btnModifyCommands);
            this.groupUnit.Controls.Add(this.btnModifyCharacter);
            this.groupUnit.Location = new System.Drawing.Point(25, 38);
            this.groupUnit.Name = "groupUnit";
            this.groupUnit.Size = new System.Drawing.Size(358, 233);
            this.groupUnit.TabIndex = 8;
            this.groupUnit.TabStop = false;
            this.groupUnit.Text = "Unit Properties";
            // 
            // btnModifySound
            // 
            this.btnModifySound.Location = new System.Drawing.Point(182, 193);
            this.btnModifySound.Name = "btnModifySound";
            this.btnModifySound.Size = new System.Drawing.Size(160, 23);
            this.btnModifySound.TabIndex = 11;
            this.btnModifySound.Text = "Modify Sounds";
            this.btnModifySound.UseVisualStyleBackColor = true;
            this.btnModifySound.Click += new System.EventHandler(this.OnClickModifySounds);
            // 
            // btnModifyEnemyCtrl
            // 
            this.btnModifyEnemyCtrl.Location = new System.Drawing.Point(182, 48);
            this.btnModifyEnemyCtrl.Name = "btnModifyEnemyCtrl";
            this.btnModifyEnemyCtrl.Size = new System.Drawing.Size(160, 23);
            this.btnModifyEnemyCtrl.TabIndex = 10;
            this.btnModifyEnemyCtrl.Text = "Modify Enemy Ctrl";
            this.btnModifyEnemyCtrl.UseVisualStyleBackColor = true;
            this.btnModifyEnemyCtrl.Click += new System.EventHandler(this.OnModifyEnemyCtrl);
            // 
            // btnModifyOrbitalBasis
            // 
            this.btnModifyOrbitalBasis.Location = new System.Drawing.Point(182, 19);
            this.btnModifyOrbitalBasis.Name = "btnModifyOrbitalBasis";
            this.btnModifyOrbitalBasis.Size = new System.Drawing.Size(160, 23);
            this.btnModifyOrbitalBasis.TabIndex = 9;
            this.btnModifyOrbitalBasis.Text = "Modify Orbital Basis";
            this.btnModifyOrbitalBasis.UseVisualStyleBackColor = true;
            this.btnModifyOrbitalBasis.Click += new System.EventHandler(this.OnModifyOrbital);
            // 
            // btnEditSupportGfx
            // 
            this.btnEditSupportGfx.Location = new System.Drawing.Point(16, 193);
            this.btnEditSupportGfx.Name = "btnEditSupportGfx";
            this.btnEditSupportGfx.Size = new System.Drawing.Size(160, 23);
            this.btnEditSupportGfx.TabIndex = 8;
            this.btnEditSupportGfx.Text = "Edit Support Graphics";
            this.btnEditSupportGfx.UseVisualStyleBackColor = true;
            this.btnEditSupportGfx.Click += new System.EventHandler(this.OnClickEditSupportGfx);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 164);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Edit Thrown Opponent";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OnClickEditThrownOpponent);
            // 
            // groupGame
            // 
            this.groupGame.Location = new System.Drawing.Point(389, 38);
            this.groupGame.Name = "groupGame";
            this.groupGame.Size = new System.Drawing.Size(172, 233);
            this.groupGame.TabIndex = 9;
            this.groupGame.TabStop = false;
            this.groupGame.Text = "Game Properties";
            // 
            // btnRestoreBaseRom
            // 
            this.btnRestoreBaseRom.Location = new System.Drawing.Point(587, 57);
            this.btnRestoreBaseRom.Name = "btnRestoreBaseRom";
            this.btnRestoreBaseRom.Size = new System.Drawing.Size(107, 23);
            this.btnRestoreBaseRom.TabIndex = 11;
            this.btnRestoreBaseRom.Text = "Restore Base Rom";
            this.btnRestoreBaseRom.UseVisualStyleBackColor = true;
            this.btnRestoreBaseRom.Click += new System.EventHandler(this.OnBtnRestoreBaseRom);
            // 
            // btnReloadAll
            // 
            this.btnReloadAll.Location = new System.Drawing.Point(587, 86);
            this.btnReloadAll.Name = "btnReloadAll";
            this.btnReloadAll.Size = new System.Drawing.Size(107, 23);
            this.btnReloadAll.TabIndex = 12;
            this.btnReloadAll.Text = "Reload All";
            this.btnReloadAll.UseVisualStyleBackColor = true;
            this.btnReloadAll.Click += new System.EventHandler(this.OnBtnReloadAll);
            // 
            // btnDebug
            // 
            this.btnDebug.Location = new System.Drawing.Point(587, 144);
            this.btnDebug.Name = "btnDebug";
            this.btnDebug.Size = new System.Drawing.Size(107, 23);
            this.btnDebug.TabIndex = 13;
            this.btnDebug.Text = "Get Samples";
            this.btnDebug.UseVisualStyleBackColor = true;
            this.btnDebug.Click += new System.EventHandler(this.OnClickDebug);
            // 
            // newDebug
            // 
            this.newDebug.Location = new System.Drawing.Point(587, 173);
            this.newDebug.Name = "newDebug";
            this.newDebug.Size = new System.Drawing.Size(107, 23);
            this.newDebug.TabIndex = 14;
            this.newDebug.Text = "DebugToo";
            this.newDebug.UseVisualStyleBackColor = true;
            this.newDebug.Click += new System.EventHandler(this.OnDebugToo);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(587, 202);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(107, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "Sprite Research";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(587, 231);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(107, 23);
            this.button3.TabIndex = 16;
            this.button3.Text = "More Sprites";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 351);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.newDebug);
            this.Controls.Add(this.btnDebug);
            this.Controls.Add(this.btnReloadAll);
            this.Controls.Add(this.btnRestoreBaseRom);
            this.Controls.Add(this.groupGame);
            this.Controls.Add(this.groupUnit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.menuMain);
            this.MainMenuStrip = this.menuMain;
            this.Name = "MainForm";
            this.Text = "TheBees";
            this.Shown += new System.EventHandler(this.OnShown);
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.groupUnit.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnModifyCharacter;
        private System.Windows.Forms.Button btnModifyProjectileDef;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnModifyCommands;
        private System.Windows.Forms.Button btnEditSAEffect;
        private System.Windows.Forms.Button btnModifyPallets;
        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem menuItemFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemOpen;
        private System.Windows.Forms.ToolStripMenuItem menuItemSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuItemExit;
        private System.Windows.Forms.GroupBox groupUnit;
        private System.Windows.Forms.GroupBox groupGame;
        private System.Windows.Forms.ToolStripMenuItem menuItemOpenDirectory;
        private System.Windows.Forms.ToolStripMenuItem menuItemClose;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnEditSupportGfx;
        private System.Windows.Forms.ToolStripMenuItem utilitiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuGenerateStaticDescriptor;
        private System.Windows.Forms.Button btnModifyOrbitalBasis;
        private System.Windows.Forms.Button btnModifyEnemyCtrl;
        private System.Windows.Forms.Button btnRestoreBaseRom;
        private System.Windows.Forms.Button btnReloadAll;
        private System.Windows.Forms.Button btnDebug;
        private System.Windows.Forms.Button newDebug;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnModifySound;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}