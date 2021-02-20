namespace TheBees.Forms
{
    partial class ModifyCharacterPallet
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBoxPalletSelect = new System.Windows.Forms.GroupBox();
            this.panelSelectByUnit = new System.Windows.Forms.Panel();
            this.panelPalType = new System.Windows.Forms.Panel();
            this.rbTypeDim = new System.Windows.Forms.RadioButton();
            this.rbTypeNormal = new System.Windows.Forms.RadioButton();
            this.rbTypeEX = new System.Windows.Forms.RadioButton();
            this.panelSideIndex = new System.Windows.Forms.Panel();
            this.rbSideRight = new System.Windows.Forms.RadioButton();
            this.rbSideLeft = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.cbUnitSel = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBoxSpriteSelect = new System.Windows.Forms.GroupBox();
            this.chkLimitSession = new System.Windows.Forms.CheckBox();
            this.cbLimitSelect = new System.Windows.Forms.ComboBox();
            this.chkLimitRegion = new System.Windows.Forms.CheckBox();
            this.groupPallet = new System.Windows.Forms.GroupBox();
            this.trackRed = new System.Windows.Forms.TrackBar();
            this.trackBlue = new System.Windows.Forms.TrackBar();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.rbAdjustColor = new System.Windows.Forms.RadioButton();
            this.trackGreen = new System.Windows.Forms.TrackBar();
            this.rbSetColor = new System.Windows.Forms.RadioButton();
            this.lblDataAddress = new System.Windows.Forms.Label();
            this.lblSourceOfAddress = new System.Windows.Forms.Label();
            this.lblAsGameAddress = new System.Windows.Forms.Label();
            this.lblRawIndex = new System.Windows.Forms.Label();
            this.btnAddSprites = new System.Windows.Forms.Button();
            this.btnRemoveSprites = new System.Windows.Forms.Button();
            this.chkModifyAxis = new System.Windows.Forms.CheckBox();
            this.palletControl = new TheBees.PalletControl();
            this.tbSpriteIndex = new TheBees.BitEdit();
            this.tbGroupIndex = new TheBees.BitEdit();
            this.tbPalletIndex = new TheBees.BitEdit();
            this.btnLoadPallet = new System.Windows.Forms.Button();
            this.groupBoxPalletSelect.SuspendLayout();
            this.panelSelectByUnit.SuspendLayout();
            this.panelPalType.SuspendLayout();
            this.panelSideIndex.SuspendLayout();
            this.groupBoxSpriteSelect.SuspendLayout();
            this.groupPallet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBlue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackGreen)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sprite Index";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Unit";
            // 
            // groupBoxPalletSelect
            // 
            this.groupBoxPalletSelect.Controls.Add(this.panelSelectByUnit);
            this.groupBoxPalletSelect.Location = new System.Drawing.Point(12, 159);
            this.groupBoxPalletSelect.Name = "groupBoxPalletSelect";
            this.groupBoxPalletSelect.Size = new System.Drawing.Size(235, 223);
            this.groupBoxPalletSelect.TabIndex = 28;
            this.groupBoxPalletSelect.TabStop = false;
            this.groupBoxPalletSelect.Text = "Select Pallet";
            // 
            // panelSelectByUnit
            // 
            this.panelSelectByUnit.Controls.Add(this.panelPalType);
            this.panelSelectByUnit.Controls.Add(this.panelSideIndex);
            this.panelSelectByUnit.Controls.Add(this.label6);
            this.panelSelectByUnit.Controls.Add(this.cbUnitSel);
            this.panelSelectByUnit.Controls.Add(this.label2);
            this.panelSelectByUnit.Controls.Add(this.label3);
            this.panelSelectByUnit.Controls.Add(this.tbGroupIndex);
            this.panelSelectByUnit.Controls.Add(this.label5);
            this.panelSelectByUnit.Controls.Add(this.label4);
            this.panelSelectByUnit.Controls.Add(this.tbPalletIndex);
            this.panelSelectByUnit.Location = new System.Drawing.Point(10, 23);
            this.panelSelectByUnit.Name = "panelSelectByUnit";
            this.panelSelectByUnit.Size = new System.Drawing.Size(219, 164);
            this.panelSelectByUnit.TabIndex = 32;
            // 
            // panelPalType
            // 
            this.panelPalType.Controls.Add(this.rbTypeDim);
            this.panelPalType.Controls.Add(this.rbTypeNormal);
            this.panelPalType.Controls.Add(this.rbTypeEX);
            this.panelPalType.Location = new System.Drawing.Point(86, 63);
            this.panelPalType.Name = "panelPalType";
            this.panelPalType.Size = new System.Drawing.Size(116, 42);
            this.panelPalType.TabIndex = 51;
            // 
            // rbTypeDim
            // 
            this.rbTypeDim.AutoSize = true;
            this.rbTypeDim.Location = new System.Drawing.Point(66, 3);
            this.rbTypeDim.Name = "rbTypeDim";
            this.rbTypeDim.Size = new System.Drawing.Size(43, 17);
            this.rbTypeDim.TabIndex = 40;
            this.rbTypeDim.TabStop = true;
            this.rbTypeDim.Text = "Dim";
            this.rbTypeDim.UseVisualStyleBackColor = true;
            this.rbTypeDim.CheckedChanged += new System.EventHandler(this.OnClickTypeDim);
            // 
            // rbTypeNormal
            // 
            this.rbTypeNormal.AutoSize = true;
            this.rbTypeNormal.Location = new System.Drawing.Point(3, 3);
            this.rbTypeNormal.Name = "rbTypeNormal";
            this.rbTypeNormal.Size = new System.Drawing.Size(58, 17);
            this.rbTypeNormal.TabIndex = 38;
            this.rbTypeNormal.TabStop = true;
            this.rbTypeNormal.Text = "Normal";
            this.rbTypeNormal.UseVisualStyleBackColor = true;
            this.rbTypeNormal.CheckedChanged += new System.EventHandler(this.OnClickTypeNormal);
            // 
            // rbTypeEX
            // 
            this.rbTypeEX.AutoSize = true;
            this.rbTypeEX.Location = new System.Drawing.Point(3, 23);
            this.rbTypeEX.Name = "rbTypeEX";
            this.rbTypeEX.Size = new System.Drawing.Size(39, 17);
            this.rbTypeEX.TabIndex = 39;
            this.rbTypeEX.TabStop = true;
            this.rbTypeEX.Text = "EX";
            this.rbTypeEX.UseVisualStyleBackColor = true;
            this.rbTypeEX.CheckedChanged += new System.EventHandler(this.OnClickTypeEX);
            // 
            // panelSideIndex
            // 
            this.panelSideIndex.Controls.Add(this.rbSideRight);
            this.panelSideIndex.Controls.Add(this.rbSideLeft);
            this.panelSideIndex.Location = new System.Drawing.Point(85, 39);
            this.panelSideIndex.Name = "panelSideIndex";
            this.panelSideIndex.Size = new System.Drawing.Size(121, 24);
            this.panelSideIndex.TabIndex = 41;
            // 
            // rbSideRight
            // 
            this.rbSideRight.AutoSize = true;
            this.rbSideRight.Location = new System.Drawing.Point(67, 3);
            this.rbSideRight.Name = "rbSideRight";
            this.rbSideRight.Size = new System.Drawing.Size(50, 17);
            this.rbSideRight.TabIndex = 35;
            this.rbSideRight.TabStop = true;
            this.rbSideRight.Text = "Right";
            this.rbSideRight.UseVisualStyleBackColor = true;
            this.rbSideRight.CheckedChanged += new System.EventHandler(this.OnCheckSideRight);
            // 
            // rbSideLeft
            // 
            this.rbSideLeft.AutoSize = true;
            this.rbSideLeft.Location = new System.Drawing.Point(4, 3);
            this.rbSideLeft.Name = "rbSideLeft";
            this.rbSideLeft.Size = new System.Drawing.Size(43, 17);
            this.rbSideLeft.TabIndex = 34;
            this.rbSideLeft.TabStop = true;
            this.rbSideLeft.Text = "Left";
            this.rbSideLeft.UseVisualStyleBackColor = true;
            this.rbSideLeft.CheckedChanged += new System.EventHandler(this.OnCheckSideLeft);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 37;
            this.label6.Text = "Pallet Type";
            // 
            // cbUnitSel
            // 
            this.cbUnitSel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUnitSel.FormattingEnabled = true;
            this.cbUnitSel.Location = new System.Drawing.Point(88, 12);
            this.cbUnitSel.Name = "cbUnitSel";
            this.cbUnitSel.Size = new System.Drawing.Size(99, 21);
            this.cbUnitSel.TabIndex = 36;
            this.cbUnitSel.SelectionChangeCommitted += new System.EventHandler(this.OnSelectUnitFromCombo);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Side";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Group Number";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "Pallet Index";
            // 
            // groupBoxSpriteSelect
            // 
            this.groupBoxSpriteSelect.Controls.Add(this.chkLimitSession);
            this.groupBoxSpriteSelect.Controls.Add(this.cbLimitSelect);
            this.groupBoxSpriteSelect.Controls.Add(this.chkLimitRegion);
            this.groupBoxSpriteSelect.Controls.Add(this.label1);
            this.groupBoxSpriteSelect.Controls.Add(this.tbSpriteIndex);
            this.groupBoxSpriteSelect.Location = new System.Drawing.Point(12, 12);
            this.groupBoxSpriteSelect.Name = "groupBoxSpriteSelect";
            this.groupBoxSpriteSelect.Size = new System.Drawing.Size(235, 141);
            this.groupBoxSpriteSelect.TabIndex = 29;
            this.groupBoxSpriteSelect.TabStop = false;
            this.groupBoxSpriteSelect.Text = "Sprite Select";
            // 
            // chkLimitSession
            // 
            this.chkLimitSession.AutoSize = true;
            this.chkLimitSession.Location = new System.Drawing.Point(115, 28);
            this.chkLimitSession.Name = "chkLimitSession";
            this.chkLimitSession.Size = new System.Drawing.Size(102, 17);
            this.chkLimitSession.TabIndex = 28;
            this.chkLimitSession.Text = "Limit By Session";
            this.chkLimitSession.UseVisualStyleBackColor = true;
            this.chkLimitSession.CheckedChanged += new System.EventHandler(this.OnLimitSessionCheckedChanged);
            // 
            // cbLimitSelect
            // 
            this.cbLimitSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLimitSelect.FormattingEnabled = true;
            this.cbLimitSelect.Location = new System.Drawing.Point(10, 61);
            this.cbLimitSelect.Name = "cbLimitSelect";
            this.cbLimitSelect.Size = new System.Drawing.Size(128, 21);
            this.cbLimitSelect.TabIndex = 27;
            this.cbLimitSelect.SelectionChangeCommitted += new System.EventHandler(this.OnRegionSelectChanged);
            // 
            // chkLimitRegion
            // 
            this.chkLimitRegion.AutoSize = true;
            this.chkLimitRegion.Location = new System.Drawing.Point(10, 28);
            this.chkLimitRegion.Name = "chkLimitRegion";
            this.chkLimitRegion.Size = new System.Drawing.Size(99, 17);
            this.chkLimitRegion.TabIndex = 26;
            this.chkLimitRegion.Text = "Limit By Region";
            this.chkLimitRegion.UseVisualStyleBackColor = true;
            this.chkLimitRegion.CheckedChanged += new System.EventHandler(this.OnLimitByRegionChanged);
            // 
            // groupPallet
            // 
            this.groupPallet.Controls.Add(this.btnLoadPallet);
            this.groupPallet.Controls.Add(this.trackRed);
            this.groupPallet.Controls.Add(this.palletControl);
            this.groupPallet.Controls.Add(this.trackBlue);
            this.groupPallet.Controls.Add(this.label9);
            this.groupPallet.Controls.Add(this.label8);
            this.groupPallet.Controls.Add(this.label10);
            this.groupPallet.Controls.Add(this.rbAdjustColor);
            this.groupPallet.Controls.Add(this.trackGreen);
            this.groupPallet.Controls.Add(this.rbSetColor);
            this.groupPallet.Location = new System.Drawing.Point(265, 12);
            this.groupPallet.Name = "groupPallet";
            this.groupPallet.Size = new System.Drawing.Size(178, 370);
            this.groupPallet.TabIndex = 31;
            this.groupPallet.TabStop = false;
            this.groupPallet.Text = "Pallet";
            // 
            // trackRed
            // 
            this.trackRed.AutoSize = false;
            this.trackRed.Location = new System.Drawing.Point(16, 162);
            this.trackRed.Name = "trackRed";
            this.trackRed.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackRed.Size = new System.Drawing.Size(44, 113);
            this.trackRed.TabIndex = 41;
            this.trackRed.TickFrequency = 0;
            this.trackRed.TickStyle = System.Windows.Forms.TickStyle.Both;
            // 
            // trackBlue
            // 
            this.trackBlue.AutoSize = false;
            this.trackBlue.Location = new System.Drawing.Point(116, 162);
            this.trackBlue.Name = "trackBlue";
            this.trackBlue.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBlue.Size = new System.Drawing.Size(44, 113);
            this.trackBlue.TabIndex = 47;
            this.trackBlue.TickFrequency = 0;
            this.trackBlue.TickStyle = System.Windows.Forms.TickStyle.Both;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(79, 280);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(15, 13);
            this.label9.TabIndex = 44;
            this.label9.Text = "G";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 280);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 13);
            this.label8.TabIndex = 43;
            this.label8.Text = "R: 31";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(129, 280);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(14, 13);
            this.label10.TabIndex = 45;
            this.label10.Text = "B";
            // 
            // rbAdjustColor
            // 
            this.rbAdjustColor.AutoSize = true;
            this.rbAdjustColor.Location = new System.Drawing.Point(6, 336);
            this.rbAdjustColor.Name = "rbAdjustColor";
            this.rbAdjustColor.Size = new System.Drawing.Size(81, 17);
            this.rbAdjustColor.TabIndex = 50;
            this.rbAdjustColor.TabStop = true;
            this.rbAdjustColor.Text = "Adjust Color";
            this.rbAdjustColor.UseVisualStyleBackColor = true;
            this.rbAdjustColor.CheckedChanged += new System.EventHandler(this.OnCheckAdjustColor);
            // 
            // trackGreen
            // 
            this.trackGreen.AutoSize = false;
            this.trackGreen.Location = new System.Drawing.Point(66, 162);
            this.trackGreen.Name = "trackGreen";
            this.trackGreen.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackGreen.Size = new System.Drawing.Size(44, 113);
            this.trackGreen.TabIndex = 46;
            this.trackGreen.TickFrequency = 0;
            this.trackGreen.TickStyle = System.Windows.Forms.TickStyle.Both;
            // 
            // rbSetColor
            // 
            this.rbSetColor.AutoSize = true;
            this.rbSetColor.Location = new System.Drawing.Point(6, 313);
            this.rbSetColor.Name = "rbSetColor";
            this.rbSetColor.Size = new System.Drawing.Size(68, 17);
            this.rbSetColor.TabIndex = 49;
            this.rbSetColor.TabStop = true;
            this.rbSetColor.Text = "Set Color";
            this.rbSetColor.UseVisualStyleBackColor = true;
            this.rbSetColor.CheckedChanged += new System.EventHandler(this.OnCheckSetColor);
            // 
            // lblDataAddress
            // 
            this.lblDataAddress.AutoSize = true;
            this.lblDataAddress.Location = new System.Drawing.Point(473, 31);
            this.lblDataAddress.Name = "lblDataAddress";
            this.lblDataAddress.Size = new System.Drawing.Size(74, 13);
            this.lblDataAddress.TabIndex = 34;
            this.lblDataAddress.Text = "Data Address:";
            // 
            // lblSourceOfAddress
            // 
            this.lblSourceOfAddress.AutoSize = true;
            this.lblSourceOfAddress.Location = new System.Drawing.Point(462, 76);
            this.lblSourceOfAddress.Name = "lblSourceOfAddress";
            this.lblSourceOfAddress.Size = new System.Drawing.Size(85, 13);
            this.lblSourceOfAddress.TabIndex = 35;
            this.lblSourceOfAddress.Text = "Address Source:";
            this.lblSourceOfAddress.Visible = false;
            // 
            // lblAsGameAddress
            // 
            this.lblAsGameAddress.AutoSize = true;
            this.lblAsGameAddress.Location = new System.Drawing.Point(453, 54);
            this.lblAsGameAddress.Name = "lblAsGameAddress";
            this.lblAsGameAddress.Size = new System.Drawing.Size(94, 13);
            this.lblAsGameAddress.TabIndex = 36;
            this.lblAsGameAddress.Text = "As Game Address:";
            // 
            // lblRawIndex
            // 
            this.lblRawIndex.AutoSize = true;
            this.lblRawIndex.Location = new System.Drawing.Point(483, 94);
            this.lblRawIndex.Name = "lblRawIndex";
            this.lblRawIndex.Size = new System.Drawing.Size(61, 13);
            this.lblRawIndex.TabIndex = 39;
            this.lblRawIndex.Text = "Raw Index:";
            // 
            // btnAddSprites
            // 
            this.btnAddSprites.Location = new System.Drawing.Point(452, 330);
            this.btnAddSprites.Name = "btnAddSprites";
            this.btnAddSprites.Size = new System.Drawing.Size(95, 23);
            this.btnAddSprites.TabIndex = 51;
            this.btnAddSprites.Text = "Add Sprites";
            this.btnAddSprites.UseVisualStyleBackColor = true;
            this.btnAddSprites.Click += new System.EventHandler(this.OnClickAddSprites);
            // 
            // btnRemoveSprites
            // 
            this.btnRemoveSprites.Location = new System.Drawing.Point(452, 359);
            this.btnRemoveSprites.Name = "btnRemoveSprites";
            this.btnRemoveSprites.Size = new System.Drawing.Size(95, 23);
            this.btnRemoveSprites.TabIndex = 52;
            this.btnRemoveSprites.Text = "Remove Sprites";
            this.btnRemoveSprites.UseVisualStyleBackColor = true;
            this.btnRemoveSprites.Click += new System.EventHandler(this.OnClickRemoveSprites);
            // 
            // chkModifyAxis
            // 
            this.chkModifyAxis.AutoSize = true;
            this.chkModifyAxis.Location = new System.Drawing.Point(452, 307);
            this.chkModifyAxis.Name = "chkModifyAxis";
            this.chkModifyAxis.Size = new System.Drawing.Size(79, 17);
            this.chkModifyAxis.TabIndex = 53;
            this.chkModifyAxis.Text = "Modify Axis";
            this.chkModifyAxis.UseVisualStyleBackColor = true;
            this.chkModifyAxis.CheckedChanged += new System.EventHandler(this.ModifyAxisCheckedChanged);
            // 
            // palletControl
            // 
            this.palletControl.Location = new System.Drawing.Point(18, 19);
            this.palletControl.Name = "palletControl";
            this.palletControl.Size = new System.Drawing.Size(137, 137);
            this.palletControl.TabIndex = 30;
            // 
            // tbSpriteIndex
            // 
            this.tbSpriteIndex.Location = new System.Drawing.Point(10, 107);
            this.tbSpriteIndex.MaxLength = 16;
            this.tbSpriteIndex.MaxValue = ((uint)(0u));
            this.tbSpriteIndex.MinValue = ((uint)(0u));
            this.tbSpriteIndex.Name = "tbSpriteIndex";
            this.tbSpriteIndex.Size = new System.Drawing.Size(67, 20);
            this.tbSpriteIndex.TabIndex = 25;
            this.tbSpriteIndex.Tag = "2";
            this.tbSpriteIndex.Text = "0";
            this.tbSpriteIndex.Value = ((uint)(0u));
            this.tbSpriteIndex.TextChanged += new System.EventHandler(this.OnChangeSpriteIndex);
            // 
            // tbGroupIndex
            // 
            this.tbGroupIndex.Location = new System.Drawing.Point(88, 107);
            this.tbGroupIndex.MaxLength = 16;
            this.tbGroupIndex.MaxValue = ((uint)(0u));
            this.tbGroupIndex.MinValue = ((uint)(0u));
            this.tbGroupIndex.Name = "tbGroupIndex";
            this.tbGroupIndex.Size = new System.Drawing.Size(67, 20);
            this.tbGroupIndex.TabIndex = 31;
            this.tbGroupIndex.Tag = "2";
            this.tbGroupIndex.Text = "0";
            this.tbGroupIndex.Value = ((uint)(0u));
            this.tbGroupIndex.TextChanged += new System.EventHandler(this.OnGroupNumberChanged);
            // 
            // tbPalletIndex
            // 
            this.tbPalletIndex.Location = new System.Drawing.Point(88, 133);
            this.tbPalletIndex.MaxLength = 16;
            this.tbPalletIndex.MaxValue = ((uint)(0u));
            this.tbPalletIndex.MinValue = ((uint)(0u));
            this.tbPalletIndex.Name = "tbPalletIndex";
            this.tbPalletIndex.Size = new System.Drawing.Size(67, 20);
            this.tbPalletIndex.TabIndex = 33;
            this.tbPalletIndex.Tag = "2";
            this.tbPalletIndex.Text = "0";
            this.tbPalletIndex.Value = ((uint)(0u));
            this.tbPalletIndex.TextChanged += new System.EventHandler(this.OnPalletIndexChanged);
            // 
            // btnLoadPallet
            // 
            this.btnLoadPallet.Location = new System.Drawing.Point(95, 330);
            this.btnLoadPallet.Name = "btnLoadPallet";
            this.btnLoadPallet.Size = new System.Drawing.Size(77, 23);
            this.btnLoadPallet.TabIndex = 54;
            this.btnLoadPallet.Text = "Load Pallet";
            this.btnLoadPallet.UseVisualStyleBackColor = true;
            this.btnLoadPallet.Click += new System.EventHandler(this.OnClickLoadPallet);
            // 
            // ModifyCharacterPallet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 421);
            this.Controls.Add(this.chkModifyAxis);
            this.Controls.Add(this.btnRemoveSprites);
            this.Controls.Add(this.btnAddSprites);
            this.Controls.Add(this.lblRawIndex);
            this.Controls.Add(this.lblAsGameAddress);
            this.Controls.Add(this.lblSourceOfAddress);
            this.Controls.Add(this.lblDataAddress);
            this.Controls.Add(this.groupPallet);
            this.Controls.Add(this.groupBoxSpriteSelect);
            this.Controls.Add(this.groupBoxPalletSelect);
            this.Name = "ModifyCharacterPallet";
            this.Text = "ModifyPallesSprites";
            this.Shown += new System.EventHandler(this.OnShown);
            this.groupBoxPalletSelect.ResumeLayout(false);
            this.panelSelectByUnit.ResumeLayout(false);
            this.panelSelectByUnit.PerformLayout();
            this.panelPalType.ResumeLayout(false);
            this.panelPalType.PerformLayout();
            this.panelSideIndex.ResumeLayout(false);
            this.panelSideIndex.PerformLayout();
            this.groupBoxSpriteSelect.ResumeLayout(false);
            this.groupBoxSpriteSelect.PerformLayout();
            this.groupPallet.ResumeLayout(false);
            this.groupPallet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBlue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackGreen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private BitEdit tbSpriteIndex;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBoxPalletSelect;
        private System.Windows.Forms.RadioButton rbSideRight;
        private System.Windows.Forms.RadioButton rbSideLeft;
        private System.Windows.Forms.Label label4;
        private BitEdit tbPalletIndex;
        private System.Windows.Forms.Label label5;
        private BitEdit tbGroupIndex;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBoxSpriteSelect;
        private System.Windows.Forms.ComboBox cbUnitSel;
        private PalletControl palletControl;
        private System.Windows.Forms.GroupBox groupPallet;
        private System.Windows.Forms.Panel panelSelectByUnit;
        private System.Windows.Forms.Label lblDataAddress;
        private System.Windows.Forms.Label lblSourceOfAddress;
        private System.Windows.Forms.Label lblAsGameAddress;
        private System.Windows.Forms.Label lblRawIndex;
        private System.Windows.Forms.TrackBar trackRed;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TrackBar trackGreen;
        private System.Windows.Forms.TrackBar trackBlue;
        private System.Windows.Forms.RadioButton rbSetColor;
        private System.Windows.Forms.RadioButton rbAdjustColor;
        private System.Windows.Forms.RadioButton rbTypeDim;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton rbTypeEX;
        private System.Windows.Forms.RadioButton rbTypeNormal;
        private System.Windows.Forms.Panel panelPalType;
        private System.Windows.Forms.Panel panelSideIndex;
        private System.Windows.Forms.ComboBox cbLimitSelect;
        private System.Windows.Forms.CheckBox chkLimitRegion;
        private System.Windows.Forms.Button btnAddSprites;
        private System.Windows.Forms.Button btnRemoveSprites;
        private System.Windows.Forms.CheckBox chkLimitSession;
        private System.Windows.Forms.CheckBox chkModifyAxis;
        private System.Windows.Forms.Button btnLoadPallet;
    }
}