namespace TheBees.Forms
{
    partial class ModifyCommand
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
            this.cbCharacterSel = new System.Windows.Forms.ComboBox();
            this.rbStanding = new System.Windows.Forms.RadioButton();
            this.rbCrouching = new System.Windows.Forms.RadioButton();
            this.rbNeutralJump = new System.Windows.Forms.RadioButton();
            this.rbForwardJump = new System.Windows.Forms.RadioButton();
            this.rbBackJump = new System.Windows.Forms.RadioButton();
            this.rbSpecials = new System.Windows.Forms.RadioButton();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.tbXMuzzle = new TheBees.BitEdit();
            this.tbXAccel = new TheBees.BitEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbYAccel = new TheBees.BitEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.tbYMuzzle = new TheBees.BitEdit();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.tbUndef1 = new TheBees.BitEdit();
            this.tbUndef2 = new TheBees.BitEdit();
            this.lblAccel1 = new System.Windows.Forms.Label();
            this.cbAcceleration = new System.Windows.Forms.ComboBox();
            this.cbCommand = new System.Windows.Forms.ComboBox();
            this.cbBankSel = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbAction = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblAccel2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tbUndef22 = new TheBees.BitEdit();
            this.tbUndef21 = new TheBees.BitEdit();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tbXMuzzle2 = new TheBees.BitEdit();
            this.tbXAccel2 = new TheBees.BitEdit();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tbYAccel2 = new TheBees.BitEdit();
            this.label12 = new System.Windows.Forms.Label();
            this.tbYMuzzle2 = new TheBees.BitEdit();
            this.cbAcceleration2 = new System.Windows.Forms.ComboBox();
            this.specOpponentTable = new System.Windows.Forms.TableLayoutPanel();
            this.label15 = new System.Windows.Forms.Label();
            this.cbInputType = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.btnModifyCommand = new System.Windows.Forms.Button();
            this.btnToStream = new System.Windows.Forms.Button();
            this.tbSelectedCommand = new System.Windows.Forms.TextBox();
            this.btnSetCommand = new System.Windows.Forms.Button();
            this.btnBankConfig = new System.Windows.Forms.Button();
            this.cbUsesAccel = new System.Windows.Forms.RadioButton();
            this.cbUsesOrbital = new System.Windows.Forms.RadioButton();
            this.pnlPrimaryAccel = new System.Windows.Forms.Panel();
            this.accelTools1 = new TheBees.Controls.PropertyToolset();
            this.pnlOrbitalBasis = new System.Windows.Forms.Panel();
            this.cbOrbitalBasisIndex = new System.Windows.Forms.ComboBox();
            this.accelTools2 = new TheBees.Controls.PropertyToolset();
            this.btnGoToAction = new System.Windows.Forms.Button();
            this.groupBox.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlPrimaryAccel.SuspendLayout();
            this.pnlOrbitalBasis.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Character";
            // 
            // cbCharacterSel
            // 
            this.cbCharacterSel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCharacterSel.FormattingEnabled = true;
            this.cbCharacterSel.Location = new System.Drawing.Point(24, 52);
            this.cbCharacterSel.Name = "cbCharacterSel";
            this.cbCharacterSel.Size = new System.Drawing.Size(121, 21);
            this.cbCharacterSel.TabIndex = 1;
            this.cbCharacterSel.SelectionChangeCommitted += new System.EventHandler(this.OnCharacterSelect);
            // 
            // rbStanding
            // 
            this.rbStanding.AutoSize = true;
            this.rbStanding.Location = new System.Drawing.Point(24, 106);
            this.rbStanding.Name = "rbStanding";
            this.rbStanding.Size = new System.Drawing.Size(108, 17);
            this.rbStanding.TabIndex = 2;
            this.rbStanding.TabStop = true;
            this.rbStanding.Text = "Normals Standing";
            this.rbStanding.UseVisualStyleBackColor = true;
            this.rbStanding.CheckedChanged += new System.EventHandler(this.OnNormalsStandingChanged);
            // 
            // rbCrouching
            // 
            this.rbCrouching.AutoSize = true;
            this.rbCrouching.Location = new System.Drawing.Point(24, 129);
            this.rbCrouching.Name = "rbCrouching";
            this.rbCrouching.Size = new System.Drawing.Size(114, 17);
            this.rbCrouching.TabIndex = 3;
            this.rbCrouching.TabStop = true;
            this.rbCrouching.Text = "Normals Crouching";
            this.rbCrouching.UseVisualStyleBackColor = true;
            this.rbCrouching.CheckedChanged += new System.EventHandler(this.OnNormalsCrouchingChanged);
            // 
            // rbNeutralJump
            // 
            this.rbNeutralJump.AutoSize = true;
            this.rbNeutralJump.Enabled = false;
            this.rbNeutralJump.Location = new System.Drawing.Point(24, 152);
            this.rbNeutralJump.Name = "rbNeutralJump";
            this.rbNeutralJump.Size = new System.Drawing.Size(128, 17);
            this.rbNeutralJump.TabIndex = 4;
            this.rbNeutralJump.TabStop = true;
            this.rbNeutralJump.Text = "Normals Neutral Jump";
            this.rbNeutralJump.UseVisualStyleBackColor = true;
            this.rbNeutralJump.CheckedChanged += new System.EventHandler(this.OnNeutralJumpChanged);
            // 
            // rbForwardJump
            // 
            this.rbForwardJump.AutoSize = true;
            this.rbForwardJump.Enabled = false;
            this.rbForwardJump.Location = new System.Drawing.Point(24, 175);
            this.rbForwardJump.Name = "rbForwardJump";
            this.rbForwardJump.Size = new System.Drawing.Size(132, 17);
            this.rbForwardJump.TabIndex = 5;
            this.rbForwardJump.TabStop = true;
            this.rbForwardJump.Text = "Normals Jump Forward";
            this.rbForwardJump.UseVisualStyleBackColor = true;
            this.rbForwardJump.CheckedChanged += new System.EventHandler(this.OnJumpForwardChanged);
            // 
            // rbBackJump
            // 
            this.rbBackJump.AutoSize = true;
            this.rbBackJump.Enabled = false;
            this.rbBackJump.Location = new System.Drawing.Point(24, 198);
            this.rbBackJump.Name = "rbBackJump";
            this.rbBackJump.Size = new System.Drawing.Size(119, 17);
            this.rbBackJump.TabIndex = 6;
            this.rbBackJump.TabStop = true;
            this.rbBackJump.Text = "Normals Jump Back";
            this.rbBackJump.UseVisualStyleBackColor = true;
            this.rbBackJump.CheckedChanged += new System.EventHandler(this.OnJumpBackChanged);
            // 
            // rbSpecials
            // 
            this.rbSpecials.AutoSize = true;
            this.rbSpecials.Enabled = false;
            this.rbSpecials.Location = new System.Drawing.Point(24, 221);
            this.rbSpecials.Name = "rbSpecials";
            this.rbSpecials.Size = new System.Drawing.Size(65, 17);
            this.rbSpecials.TabIndex = 7;
            this.rbSpecials.TabStop = true;
            this.rbSpecials.Text = "Specials";
            this.rbSpecials.UseVisualStyleBackColor = true;
            this.rbSpecials.CheckedChanged += new System.EventHandler(this.OnSpecialsChanged);
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.cbCharacterSel);
            this.groupBox.Controls.Add(this.label1);
            this.groupBox.Controls.Add(this.rbSpecials);
            this.groupBox.Controls.Add(this.rbStanding);
            this.groupBox.Controls.Add(this.rbBackJump);
            this.groupBox.Controls.Add(this.rbCrouching);
            this.groupBox.Controls.Add(this.rbForwardJump);
            this.groupBox.Controls.Add(this.rbNeutralJump);
            this.groupBox.Location = new System.Drawing.Point(13, 24);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(188, 509);
            this.groupBox.TabIndex = 9;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Source";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(227, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Bank Select";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tbXMuzzle, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tbXAccel, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label8, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.tbYAccel, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.label7, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.tbYMuzzle, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.label17, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label18, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.tbUndef1, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.tbUndef2, 1, 5);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 67);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 9;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(165, 156);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "x Acceleration";
            // 
            // tbXMuzzle
            // 
            this.tbXMuzzle.Location = new System.Drawing.Point(83, 3);
            this.tbXMuzzle.MaxLength = 16;
            this.tbXMuzzle.MaxValue = ((uint)(0u));
            this.tbXMuzzle.MinValue = ((uint)(0u));
            this.tbXMuzzle.Name = "tbXMuzzle";
            this.tbXMuzzle.Size = new System.Drawing.Size(67, 20);
            this.tbXMuzzle.TabIndex = 24;
            this.tbXMuzzle.Tag = "1";
            this.tbXMuzzle.Text = "0";
            this.tbXMuzzle.Value = ((uint)(0u));
            this.tbXMuzzle.TextChanged += new System.EventHandler(this.OnAccel1TextChanged);
            // 
            // tbXAccel
            // 
            this.tbXAccel.Location = new System.Drawing.Point(83, 28);
            this.tbXAccel.MaxLength = 16;
            this.tbXAccel.MaxValue = ((uint)(0u));
            this.tbXAccel.MinValue = ((uint)(0u));
            this.tbXAccel.Name = "tbXAccel";
            this.tbXAccel.Size = new System.Drawing.Size(67, 20);
            this.tbXAccel.TabIndex = 25;
            this.tbXAccel.Tag = "1";
            this.tbXAccel.Text = "0";
            this.tbXAccel.Value = ((uint)(0u));
            this.tbXAccel.TextChanged += new System.EventHandler(this.OnAccel1TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "x Muzzle Vel";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 100);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "y Acceleration";
            // 
            // tbYAccel
            // 
            this.tbYAccel.Location = new System.Drawing.Point(83, 103);
            this.tbYAccel.MaxLength = 16;
            this.tbYAccel.MaxValue = ((uint)(0u));
            this.tbYAccel.MinValue = ((uint)(0u));
            this.tbYAccel.Name = "tbYAccel";
            this.tbYAccel.Size = new System.Drawing.Size(67, 20);
            this.tbYAccel.TabIndex = 27;
            this.tbYAccel.Tag = "1";
            this.tbYAccel.Text = "0";
            this.tbYAccel.Value = ((uint)(0u));
            this.tbYAccel.TextChanged += new System.EventHandler(this.OnAccel1TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "y Muzzle Vel";
            // 
            // tbYMuzzle
            // 
            this.tbYMuzzle.Location = new System.Drawing.Point(83, 78);
            this.tbYMuzzle.MaxLength = 16;
            this.tbYMuzzle.MaxValue = ((uint)(0u));
            this.tbYMuzzle.MinValue = ((uint)(0u));
            this.tbYMuzzle.Name = "tbYMuzzle";
            this.tbYMuzzle.Size = new System.Drawing.Size(67, 20);
            this.tbYMuzzle.TabIndex = 26;
            this.tbYMuzzle.Tag = "1";
            this.tbYMuzzle.Text = "0";
            this.tbYMuzzle.Value = ((uint)(0u));
            this.tbYMuzzle.TextChanged += new System.EventHandler(this.OnAccel1TextChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(3, 50);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(25, 13);
            this.label17.TabIndex = 28;
            this.label17.Text = "???";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(3, 125);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(25, 13);
            this.label18.TabIndex = 29;
            this.label18.Text = "???";
            // 
            // tbUndef1
            // 
            this.tbUndef1.Location = new System.Drawing.Point(83, 53);
            this.tbUndef1.MaxLength = 16;
            this.tbUndef1.MaxValue = ((uint)(0u));
            this.tbUndef1.MinValue = ((uint)(0u));
            this.tbUndef1.Name = "tbUndef1";
            this.tbUndef1.Size = new System.Drawing.Size(67, 20);
            this.tbUndef1.TabIndex = 30;
            this.tbUndef1.Tag = "1";
            this.tbUndef1.Text = "0";
            this.tbUndef1.Value = ((uint)(0u));
            this.tbUndef1.TextChanged += new System.EventHandler(this.OnAccel1TextChanged);
            // 
            // tbUndef2
            // 
            this.tbUndef2.Location = new System.Drawing.Point(83, 128);
            this.tbUndef2.MaxLength = 16;
            this.tbUndef2.MaxValue = ((uint)(0u));
            this.tbUndef2.MinValue = ((uint)(0u));
            this.tbUndef2.Name = "tbUndef2";
            this.tbUndef2.Size = new System.Drawing.Size(67, 20);
            this.tbUndef2.TabIndex = 31;
            this.tbUndef2.Tag = "1";
            this.tbUndef2.Text = "0";
            this.tbUndef2.Value = ((uint)(0u));
            this.tbUndef2.TextChanged += new System.EventHandler(this.OnAccel1TextChanged);
            // 
            // lblAccel1
            // 
            this.lblAccel1.AutoSize = true;
            this.lblAccel1.Location = new System.Drawing.Point(230, 242);
            this.lblAccel1.Name = "lblAccel1";
            this.lblAccel1.Size = new System.Drawing.Size(82, 13);
            this.lblAccel1.TabIndex = 10;
            this.lblAccel1.Text = "Acceleration #1";
            // 
            // cbAcceleration
            // 
            this.cbAcceleration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAcceleration.FormattingEnabled = true;
            this.cbAcceleration.Location = new System.Drawing.Point(0, 3);
            this.cbAcceleration.Name = "cbAcceleration";
            this.cbAcceleration.Size = new System.Drawing.Size(66, 21);
            this.cbAcceleration.TabIndex = 8;
            this.cbAcceleration.SelectionChangeCommitted += new System.EventHandler(this.OnSelectAcceleration);
            // 
            // cbCommand
            // 
            this.cbCommand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCommand.FormattingEnabled = true;
            this.cbCommand.Location = new System.Drawing.Point(368, 60);
            this.cbCommand.Name = "cbCommand";
            this.cbCommand.Size = new System.Drawing.Size(148, 21);
            this.cbCommand.TabIndex = 7;
            this.cbCommand.SelectionChangeCommitted += new System.EventHandler(this.OnSelectCommand);
            // 
            // cbBankSel
            // 
            this.cbBankSel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBankSel.FormattingEnabled = true;
            this.cbBankSel.Location = new System.Drawing.Point(230, 60);
            this.cbBankSel.Name = "cbBankSel";
            this.cbBankSel.Size = new System.Drawing.Size(93, 21);
            this.cbBankSel.TabIndex = 1;
            this.cbBankSel.SelectionChangeCommitted += new System.EventHandler(this.OnSelectBank);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(365, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Command";
            // 
            // cbAction
            // 
            this.cbAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAction.FormattingEnabled = true;
            this.cbAction.Location = new System.Drawing.Point(441, 172);
            this.cbAction.Name = "cbAction";
            this.cbAction.Size = new System.Drawing.Size(162, 21);
            this.cbAction.TabIndex = 11;
            this.cbAction.SelectionChangeCommitted += new System.EventHandler(this.OnSelectAction);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(438, 156);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Action";
            // 
            // lblAccel2
            // 
            this.lblAccel2.AutoSize = true;
            this.lblAccel2.Location = new System.Drawing.Point(434, 242);
            this.lblAccel2.Name = "lblAccel2";
            this.lblAccel2.Size = new System.Drawing.Size(82, 13);
            this.lblAccel2.TabIndex = 15;
            this.lblAccel2.Text = "Acceleration #2";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.tbUndef22, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.tbUndef21, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label20, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label19, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label11, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbXMuzzle2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbXAccel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label14, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label13, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.tbYAccel2, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label12, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tbYMuzzle2, 1, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(437, 328);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(165, 156);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // tbUndef22
            // 
            this.tbUndef22.Location = new System.Drawing.Point(83, 128);
            this.tbUndef22.MaxLength = 16;
            this.tbUndef22.MaxValue = ((uint)(0u));
            this.tbUndef22.MinValue = ((uint)(0u));
            this.tbUndef22.Name = "tbUndef22";
            this.tbUndef22.Size = new System.Drawing.Size(67, 20);
            this.tbUndef22.TabIndex = 33;
            this.tbUndef22.Tag = "2";
            this.tbUndef22.Text = "0";
            this.tbUndef22.Value = ((uint)(0u));
            this.tbUndef22.TextChanged += new System.EventHandler(this.OnAccel2TextChanged);
            // 
            // tbUndef21
            // 
            this.tbUndef21.Location = new System.Drawing.Point(83, 53);
            this.tbUndef21.MaxLength = 16;
            this.tbUndef21.MaxValue = ((uint)(0u));
            this.tbUndef21.MinValue = ((uint)(0u));
            this.tbUndef21.Name = "tbUndef21";
            this.tbUndef21.Size = new System.Drawing.Size(67, 20);
            this.tbUndef21.TabIndex = 32;
            this.tbUndef21.Tag = "2";
            this.tbUndef21.Text = "0";
            this.tbUndef21.Value = ((uint)(0u));
            this.tbUndef21.TextChanged += new System.EventHandler(this.OnAccel2TextChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(3, 50);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(25, 13);
            this.label20.TabIndex = 31;
            this.label20.Text = "???";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(3, 125);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(25, 13);
            this.label19.TabIndex = 30;
            this.label19.Text = "???";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 25);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "x Acceleration";
            // 
            // tbXMuzzle2
            // 
            this.tbXMuzzle2.Location = new System.Drawing.Point(83, 3);
            this.tbXMuzzle2.MaxLength = 16;
            this.tbXMuzzle2.MaxValue = ((uint)(0u));
            this.tbXMuzzle2.MinValue = ((uint)(0u));
            this.tbXMuzzle2.Name = "tbXMuzzle2";
            this.tbXMuzzle2.Size = new System.Drawing.Size(67, 20);
            this.tbXMuzzle2.TabIndex = 24;
            this.tbXMuzzle2.Tag = "2";
            this.tbXMuzzle2.Text = "0";
            this.tbXMuzzle2.Value = ((uint)(0u));
            this.tbXMuzzle2.TextChanged += new System.EventHandler(this.OnAccel2TextChanged);
            // 
            // tbXAccel2
            // 
            this.tbXAccel2.Location = new System.Drawing.Point(83, 28);
            this.tbXAccel2.MaxLength = 16;
            this.tbXAccel2.MaxValue = ((uint)(0u));
            this.tbXAccel2.MinValue = ((uint)(0u));
            this.tbXAccel2.Name = "tbXAccel2";
            this.tbXAccel2.Size = new System.Drawing.Size(67, 20);
            this.tbXAccel2.TabIndex = 25;
            this.tbXAccel2.Tag = "2";
            this.tbXAccel2.Text = "0";
            this.tbXAccel2.Value = ((uint)(0u));
            this.tbXAccel2.TextChanged += new System.EventHandler(this.OnAccel2TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(3, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(66, 13);
            this.label14.TabIndex = 11;
            this.label14.Text = "x Muzzle Vel";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 100);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(74, 13);
            this.label13.TabIndex = 14;
            this.label13.Text = "y Acceleration";
            // 
            // tbYAccel2
            // 
            this.tbYAccel2.Location = new System.Drawing.Point(83, 103);
            this.tbYAccel2.MaxLength = 16;
            this.tbYAccel2.MaxValue = ((uint)(0u));
            this.tbYAccel2.MinValue = ((uint)(0u));
            this.tbYAccel2.Name = "tbYAccel2";
            this.tbYAccel2.Size = new System.Drawing.Size(67, 20);
            this.tbYAccel2.TabIndex = 27;
            this.tbYAccel2.Tag = "2";
            this.tbYAccel2.Text = "0";
            this.tbYAccel2.Value = ((uint)(0u));
            this.tbYAccel2.TextChanged += new System.EventHandler(this.OnAccel2TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 75);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(66, 13);
            this.label12.TabIndex = 13;
            this.label12.Text = "y Muzzle Vel";
            // 
            // tbYMuzzle2
            // 
            this.tbYMuzzle2.Location = new System.Drawing.Point(83, 78);
            this.tbYMuzzle2.MaxLength = 16;
            this.tbYMuzzle2.MaxValue = ((uint)(0u));
            this.tbYMuzzle2.MinValue = ((uint)(0u));
            this.tbYMuzzle2.Name = "tbYMuzzle2";
            this.tbYMuzzle2.Size = new System.Drawing.Size(67, 20);
            this.tbYMuzzle2.TabIndex = 26;
            this.tbYMuzzle2.Tag = "2";
            this.tbYMuzzle2.Text = "0";
            this.tbYMuzzle2.Value = ((uint)(0u));
            this.tbYMuzzle2.TextChanged += new System.EventHandler(this.OnAccel2TextChanged);
            // 
            // cbAcceleration2
            // 
            this.cbAcceleration2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAcceleration2.FormattingEnabled = true;
            this.cbAcceleration2.Location = new System.Drawing.Point(437, 261);
            this.cbAcceleration2.Name = "cbAcceleration2";
            this.cbAcceleration2.Size = new System.Drawing.Size(66, 21);
            this.cbAcceleration2.TabIndex = 14;
            this.cbAcceleration2.SelectionChangeCommitted += new System.EventHandler(this.OnSelectAcceleration2);
            // 
            // specOpponentTable
            // 
            this.specOpponentTable.ColumnCount = 1;
            this.specOpponentTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.specOpponentTable.Location = new System.Drawing.Point(696, 490);
            this.specOpponentTable.Name = "specOpponentTable";
            this.specOpponentTable.RowCount = 12;
            this.specOpponentTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.specOpponentTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.specOpponentTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.specOpponentTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.specOpponentTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.specOpponentTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.specOpponentTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.specOpponentTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.specOpponentTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.specOpponentTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.specOpponentTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.specOpponentTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.specOpponentTable.Size = new System.Drawing.Size(200, 304);
            this.specOpponentTable.TabIndex = 17;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(708, 95);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(95, 13);
            this.label15.TabIndex = 18;
            this.label15.Text = "Input Specification";
            // 
            // cbInputType
            // 
            this.cbInputType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbInputType.FormattingEnabled = true;
            this.cbInputType.Location = new System.Drawing.Point(230, 172);
            this.cbInputType.Name = "cbInputType";
            this.cbInputType.Size = new System.Drawing.Size(132, 21);
            this.cbInputType.TabIndex = 19;
            this.cbInputType.SelectionChangeCommitted += new System.EventHandler(this.OnChangeInputType);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(227, 156);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(58, 13);
            this.label16.TabIndex = 20;
            this.label16.Text = "Input Type";
            // 
            // btnModifyCommand
            // 
            this.btnModifyCommand.Location = new System.Drawing.Point(368, 114);
            this.btnModifyCommand.Name = "btnModifyCommand";
            this.btnModifyCommand.Size = new System.Drawing.Size(119, 23);
            this.btnModifyCommand.TabIndex = 21;
            this.btnModifyCommand.Text = "Modify Commands";
            this.btnModifyCommand.UseVisualStyleBackColor = true;
            this.btnModifyCommand.Click += new System.EventHandler(this.OnClickModifyCommand);
            // 
            // btnToStream
            // 
            this.btnToStream.Location = new System.Drawing.Point(510, 510);
            this.btnToStream.Name = "btnToStream";
            this.btnToStream.Size = new System.Drawing.Size(92, 23);
            this.btnToStream.TabIndex = 22;
            this.btnToStream.Text = "Send To Stream";
            this.btnToStream.UseVisualStyleBackColor = true;
            this.btnToStream.Click += new System.EventHandler(this.btnToStream_Click);
            // 
            // tbSelectedCommand
            // 
            this.tbSelectedCommand.Location = new System.Drawing.Point(368, 88);
            this.tbSelectedCommand.Name = "tbSelectedCommand";
            this.tbSelectedCommand.ReadOnly = true;
            this.tbSelectedCommand.Size = new System.Drawing.Size(235, 20);
            this.tbSelectedCommand.TabIndex = 23;
            this.tbSelectedCommand.Text = "Current: ";
            // 
            // btnSetCommand
            // 
            this.btnSetCommand.Location = new System.Drawing.Point(528, 58);
            this.btnSetCommand.Name = "btnSetCommand";
            this.btnSetCommand.Size = new System.Drawing.Size(75, 23);
            this.btnSetCommand.TabIndex = 24;
            this.btnSetCommand.Text = "Set";
            this.btnSetCommand.UseVisualStyleBackColor = true;
            this.btnSetCommand.Click += new System.EventHandler(this.OnSetCommand);
            // 
            // btnBankConfig
            // 
            this.btnBankConfig.Location = new System.Drawing.Point(230, 114);
            this.btnBankConfig.Name = "btnBankConfig";
            this.btnBankConfig.Size = new System.Drawing.Size(93, 23);
            this.btnBankConfig.TabIndex = 27;
            this.btnBankConfig.Text = "Set Bank Config";
            this.btnBankConfig.UseVisualStyleBackColor = true;
            this.btnBankConfig.Click += new System.EventHandler(this.OnClickBankConfig);
            // 
            // cbUsesAccel
            // 
            this.cbUsesAccel.AutoSize = true;
            this.cbUsesAccel.Location = new System.Drawing.Point(227, 487);
            this.cbUsesAccel.Name = "cbUsesAccel";
            this.cbUsesAccel.Size = new System.Drawing.Size(111, 17);
            this.cbUsesAccel.TabIndex = 28;
            this.cbUsesAccel.TabStop = true;
            this.cbUsesAccel.Text = "Uses Acceleration";
            this.cbUsesAccel.UseVisualStyleBackColor = true;
            // 
            // cbUsesOrbital
            // 
            this.cbUsesOrbital.AutoSize = true;
            this.cbUsesOrbital.Location = new System.Drawing.Point(228, 510);
            this.cbUsesOrbital.Name = "cbUsesOrbital";
            this.cbUsesOrbital.Size = new System.Drawing.Size(110, 17);
            this.cbUsesOrbital.TabIndex = 29;
            this.cbUsesOrbital.TabStop = true;
            this.cbUsesOrbital.Text = "Uses Orbital Basis";
            this.cbUsesOrbital.UseVisualStyleBackColor = true;
            // 
            // pnlPrimaryAccel
            // 
            this.pnlPrimaryAccel.Controls.Add(this.cbAcceleration);
            this.pnlPrimaryAccel.Controls.Add(this.tableLayoutPanel2);
            this.pnlPrimaryAccel.Controls.Add(this.accelTools1);
            this.pnlPrimaryAccel.Location = new System.Drawing.Point(230, 259);
            this.pnlPrimaryAccel.Name = "pnlPrimaryAccel";
            this.pnlPrimaryAccel.Size = new System.Drawing.Size(173, 229);
            this.pnlPrimaryAccel.TabIndex = 30;
            // 
            // accelTools1
            // 
            this.accelTools1.Location = new System.Drawing.Point(0, 30);
            this.accelTools1.Name = "accelTools1";
            this.accelTools1.Size = new System.Drawing.Size(108, 31);
            this.accelTools1.TabIndex = 25;
            // 
            // pnlOrbitalBasis
            // 
            this.pnlOrbitalBasis.Controls.Add(this.cbOrbitalBasisIndex);
            this.pnlOrbitalBasis.Location = new System.Drawing.Point(230, 259);
            this.pnlOrbitalBasis.Name = "pnlOrbitalBasis";
            this.pnlOrbitalBasis.Size = new System.Drawing.Size(175, 31);
            this.pnlOrbitalBasis.TabIndex = 31;
            // 
            // cbOrbitalBasisIndex
            // 
            this.cbOrbitalBasisIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOrbitalBasisIndex.FormattingEnabled = true;
            this.cbOrbitalBasisIndex.Location = new System.Drawing.Point(3, 3);
            this.cbOrbitalBasisIndex.Name = "cbOrbitalBasisIndex";
            this.cbOrbitalBasisIndex.Size = new System.Drawing.Size(169, 21);
            this.cbOrbitalBasisIndex.TabIndex = 0;
            this.cbOrbitalBasisIndex.SelectionChangeCommitted += new System.EventHandler(this.OnSelectAcceleration);
            // 
            // accelTools2
            // 
            this.accelTools2.Location = new System.Drawing.Point(437, 288);
            this.accelTools2.Name = "accelTools2";
            this.accelTools2.Size = new System.Drawing.Size(108, 31);
            this.accelTools2.TabIndex = 26;
            // 
            // btnGoToAction
            // 
            this.btnGoToAction.Location = new System.Drawing.Point(520, 199);
            this.btnGoToAction.Name = "btnGoToAction";
            this.btnGoToAction.Size = new System.Drawing.Size(83, 26);
            this.btnGoToAction.TabIndex = 32;
            this.btnGoToAction.Text = "Go To Action";
            this.btnGoToAction.UseVisualStyleBackColor = true;
            this.btnGoToAction.Click += new System.EventHandler(this.OnClickGoToAction);
            // 
            // ModifyCommand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 555);
            this.Controls.Add(this.btnGoToAction);
            this.Controls.Add(this.pnlOrbitalBasis);
            this.Controls.Add(this.pnlPrimaryAccel);
            this.Controls.Add(this.lblAccel1);
            this.Controls.Add(this.cbUsesOrbital);
            this.Controls.Add(this.cbUsesAccel);
            this.Controls.Add(this.btnBankConfig);
            this.Controls.Add(this.accelTools2);
            this.Controls.Add(this.btnSetCommand);
            this.Controls.Add(this.tbSelectedCommand);
            this.Controls.Add(this.btnToStream);
            this.Controls.Add(this.btnModifyCommand);
            this.Controls.Add(this.cbInputType);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.specOpponentTable);
            this.Controls.Add(this.lblAccel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.cbAcceleration2);
            this.Controls.Add(this.cbAction);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbCommand);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.cbBankSel);
            this.Controls.Add(this.label3);
            this.Name = "ModifyCommand";
            this.Text = "ModfyCommand";
            this.Shown += new System.EventHandler(this.OnShown);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.pnlPrimaryAccel.ResumeLayout(false);
            this.pnlOrbitalBasis.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbCharacterSel;
        private System.Windows.Forms.RadioButton rbStanding;
        private System.Windows.Forms.RadioButton rbCrouching;
        private System.Windows.Forms.RadioButton rbNeutralJump;
        private System.Windows.Forms.RadioButton rbForwardJump;
        private System.Windows.Forms.RadioButton rbBackJump;
        private System.Windows.Forms.RadioButton rbSpecials;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private BitEdit tbXMuzzle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private BitEdit tbXAccel;
        private BitEdit tbYMuzzle;
        private BitEdit tbYAccel;
        private System.Windows.Forms.Label lblAccel1;
        private System.Windows.Forms.ComboBox cbAcceleration;
        private System.Windows.Forms.ComboBox cbCommand;
        private System.Windows.Forms.ComboBox cbBankSel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbAction;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblAccel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private BitEdit tbXMuzzle2;
        private BitEdit tbXAccel2;
        private BitEdit tbYMuzzle2;
        private BitEdit tbYAccel2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cbAcceleration2;
        private System.Windows.Forms.TableLayoutPanel specOpponentTable;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cbInputType;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnModifyCommand;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private BitEdit tbUndef1;
        private BitEdit tbUndef2;
        private BitEdit tbUndef22;
        private BitEdit tbUndef21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btnToStream;
        private System.Windows.Forms.TextBox tbSelectedCommand;
        private System.Windows.Forms.Button btnSetCommand;
        private Controls.PropertyToolset accelTools1;
        private Controls.PropertyToolset accelTools2;
        private System.Windows.Forms.Button btnBankConfig;
        private System.Windows.Forms.RadioButton cbUsesAccel;
        private System.Windows.Forms.RadioButton cbUsesOrbital;
        private System.Windows.Forms.Panel pnlPrimaryAccel;
        private System.Windows.Forms.Panel pnlOrbitalBasis;
        private System.Windows.Forms.ComboBox cbOrbitalBasisIndex;
        private System.Windows.Forms.Button btnGoToAction;
    }
}