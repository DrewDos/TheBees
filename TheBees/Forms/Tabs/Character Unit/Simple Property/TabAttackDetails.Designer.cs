namespace TheBees.Forms
{
    partial class TabAttackDetails : NodeLayout
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        public override void InitializeComponent()
        {
            this.cbAttackDef = new System.Windows.Forms.ComboBox();
            this.label28 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tbHitEffect1 = new TheBees.BitEdit();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.tbHitEffect2 = new TheBees.BitEdit();
            this.tbGuardDisp = new TheBees.BitEdit();
            this.tbControlEnemy = new TheBees.BitEdit();
            this.tbCrouchCollision = new TheBees.BitEdit();
            this.tbBendBack = new TheBees.BitEdit();
            this.tbDamage = new TheBees.BitEdit();
            this.tbHitBack = new TheBees.BitEdit();
            this.tbStunGauge = new TheBees.BitEdit();
            this.tbHitEffects = new TheBees.BitEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbFlags1 = new TheBees.BitEdit();
            this.tbFlags2 = new TheBees.BitEdit();
            this.propertyToolset1 = new TheBees.Controls.PropertyToolset();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbAttackDef
            // 
            this.cbAttackDef.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAttackDef.FormattingEnabled = true;
            this.cbAttackDef.Location = new System.Drawing.Point(132, 3);
            this.cbAttackDef.Name = "cbAttackDef";
            this.cbAttackDef.Size = new System.Drawing.Size(121, 21);
            this.cbAttackDef.TabIndex = 6;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(7, 6);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(114, 13);
            this.label28.TabIndex = 5;
            this.label28.Text = "Attack Definition Index";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 201F));
            this.tableLayoutPanel2.Controls.Add(this.tbHitEffect1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label18, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label19, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label20, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label21, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.label22, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.label23, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.label24, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.label25, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.label26, 0, 8);
            this.tableLayoutPanel2.Controls.Add(this.label27, 0, 9);
            this.tableLayoutPanel2.Controls.Add(this.tbHitEffect2, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.tbGuardDisp, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.tbControlEnemy, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.tbCrouchCollision, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.tbBendBack, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.tbDamage, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.tbHitBack, 1, 7);
            this.tableLayoutPanel2.Controls.Add(this.tbStunGauge, 1, 8);
            this.tableLayoutPanel2.Controls.Add(this.tbHitEffects, 1, 9);
            this.tableLayoutPanel2.Controls.Add(this.label1, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.tbFlags1, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.tbFlags2, 3, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 30);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 16;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(576, 300);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // tbHitEffect1
            // 
            this.tbHitEffect1.Location = new System.Drawing.Point(128, 3);
            this.tbHitEffect1.MaxLength = 16;
            this.tbHitEffect1.MaxValue = ((uint)(0u));
            this.tbHitEffect1.MinValue = ((uint)(0u));
            this.tbHitEffect1.Name = "tbHitEffect1";
            this.tbHitEffect1.Size = new System.Drawing.Size(100, 20);
            this.tbHitEffect1.TabIndex = 7;
            this.tbHitEffect1.Text = "0";
            this.tbHitEffect1.Value = ((uint)(0u));
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(3, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(60, 13);
            this.label18.TabIndex = 0;
            this.label18.Text = "Hit Effect 1";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(3, 26);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(60, 13);
            this.label19.TabIndex = 1;
            this.label19.Text = "Hit Effect 2";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(3, 52);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(90, 13);
            this.label20.TabIndex = 2;
            this.label20.Text = "Guard Disposition";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(3, 78);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(75, 13);
            this.label21.TabIndex = 3;
            this.label21.Text = "Control Enemy";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(3, 104);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(96, 13);
            this.label22.TabIndex = 4;
            this.label22.Text = "Crouching Collision";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(3, 130);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(90, 13);
            this.label23.TabIndex = 5;
            this.label23.Text = "Bend Back Value";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(3, 156);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(47, 13);
            this.label24.TabIndex = 6;
            this.label24.Text = "Damage";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(3, 182);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(48, 13);
            this.label25.TabIndex = 6;
            this.label25.Text = "Hit Back";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(3, 208);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(64, 13);
            this.label26.TabIndex = 6;
            this.label26.Text = "Stun Gauge";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(3, 234);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(103, 13);
            this.label27.TabIndex = 6;
            this.label27.Text = "Hit Effects - Snd Gfx";
            // 
            // tbHitEffect2
            // 
            this.tbHitEffect2.Location = new System.Drawing.Point(128, 29);
            this.tbHitEffect2.MaxLength = 16;
            this.tbHitEffect2.MaxValue = ((uint)(0u));
            this.tbHitEffect2.MinValue = ((uint)(0u));
            this.tbHitEffect2.Name = "tbHitEffect2";
            this.tbHitEffect2.Size = new System.Drawing.Size(100, 20);
            this.tbHitEffect2.TabIndex = 7;
            this.tbHitEffect2.Text = "0";
            this.tbHitEffect2.Value = ((uint)(0u));
            // 
            // tbGuardDisp
            // 
            this.tbGuardDisp.Location = new System.Drawing.Point(128, 55);
            this.tbGuardDisp.MaxLength = 16;
            this.tbGuardDisp.MaxValue = ((uint)(0u));
            this.tbGuardDisp.MinValue = ((uint)(0u));
            this.tbGuardDisp.Name = "tbGuardDisp";
            this.tbGuardDisp.Size = new System.Drawing.Size(100, 20);
            this.tbGuardDisp.TabIndex = 7;
            this.tbGuardDisp.Text = "0";
            this.tbGuardDisp.Value = ((uint)(0u));
            // 
            // tbControlEnemy
            // 
            this.tbControlEnemy.Location = new System.Drawing.Point(128, 81);
            this.tbControlEnemy.MaxLength = 16;
            this.tbControlEnemy.MaxValue = ((uint)(0u));
            this.tbControlEnemy.MinValue = ((uint)(0u));
            this.tbControlEnemy.Name = "tbControlEnemy";
            this.tbControlEnemy.Size = new System.Drawing.Size(100, 20);
            this.tbControlEnemy.TabIndex = 7;
            this.tbControlEnemy.Text = "0";
            this.tbControlEnemy.Value = ((uint)(0u));
            // 
            // tbCrouchCollision
            // 
            this.tbCrouchCollision.Location = new System.Drawing.Point(128, 107);
            this.tbCrouchCollision.MaxLength = 16;
            this.tbCrouchCollision.MaxValue = ((uint)(0u));
            this.tbCrouchCollision.MinValue = ((uint)(0u));
            this.tbCrouchCollision.Name = "tbCrouchCollision";
            this.tbCrouchCollision.Size = new System.Drawing.Size(100, 20);
            this.tbCrouchCollision.TabIndex = 7;
            this.tbCrouchCollision.Text = "0";
            this.tbCrouchCollision.Value = ((uint)(0u));
            // 
            // tbBendBack
            // 
            this.tbBendBack.Location = new System.Drawing.Point(128, 133);
            this.tbBendBack.MaxLength = 16;
            this.tbBendBack.MaxValue = ((uint)(0u));
            this.tbBendBack.MinValue = ((uint)(0u));
            this.tbBendBack.Name = "tbBendBack";
            this.tbBendBack.Size = new System.Drawing.Size(100, 20);
            this.tbBendBack.TabIndex = 7;
            this.tbBendBack.Text = "0";
            this.tbBendBack.Value = ((uint)(0u));
            // 
            // tbDamage
            // 
            this.tbDamage.Location = new System.Drawing.Point(128, 159);
            this.tbDamage.MaxLength = 16;
            this.tbDamage.MaxValue = ((uint)(0u));
            this.tbDamage.MinValue = ((uint)(0u));
            this.tbDamage.Name = "tbDamage";
            this.tbDamage.Size = new System.Drawing.Size(100, 20);
            this.tbDamage.TabIndex = 7;
            this.tbDamage.Text = "0";
            this.tbDamage.Value = ((uint)(0u));
            // 
            // tbHitBack
            // 
            this.tbHitBack.Location = new System.Drawing.Point(128, 185);
            this.tbHitBack.MaxLength = 16;
            this.tbHitBack.MaxValue = ((uint)(0u));
            this.tbHitBack.MinValue = ((uint)(0u));
            this.tbHitBack.Name = "tbHitBack";
            this.tbHitBack.Size = new System.Drawing.Size(100, 20);
            this.tbHitBack.TabIndex = 7;
            this.tbHitBack.Text = "0";
            this.tbHitBack.Value = ((uint)(0u));
            // 
            // tbStunGauge
            // 
            this.tbStunGauge.Location = new System.Drawing.Point(128, 211);
            this.tbStunGauge.MaxLength = 16;
            this.tbStunGauge.MaxValue = ((uint)(0u));
            this.tbStunGauge.MinValue = ((uint)(0u));
            this.tbStunGauge.Name = "tbStunGauge";
            this.tbStunGauge.Size = new System.Drawing.Size(100, 20);
            this.tbStunGauge.TabIndex = 7;
            this.tbStunGauge.Text = "0";
            this.tbStunGauge.Value = ((uint)(0u));
            // 
            // tbHitEffects
            // 
            this.tbHitEffects.Location = new System.Drawing.Point(128, 237);
            this.tbHitEffects.MaxLength = 16;
            this.tbHitEffects.MaxValue = ((uint)(0u));
            this.tbHitEffects.MinValue = ((uint)(0u));
            this.tbHitEffects.Name = "tbHitEffects";
            this.tbHitEffects.Size = new System.Drawing.Size(100, 20);
            this.tbHitEffects.TabIndex = 7;
            this.tbHitEffects.Text = "0";
            this.tbHitEffects.Value = ((uint)(0u));
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(253, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Flags 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(253, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Flags 2";
            // 
            // tbFlags1
            // 
            this.tbFlags1.Location = new System.Drawing.Point(378, 3);
            this.tbFlags1.MaxLength = 16;
            this.tbFlags1.MaxValue = ((uint)(0u));
            this.tbFlags1.MinValue = ((uint)(0u));
            this.tbFlags1.Name = "tbFlags1";
            this.tbFlags1.Size = new System.Drawing.Size(100, 20);
            this.tbFlags1.TabIndex = 7;
            this.tbFlags1.Text = "0";
            this.tbFlags1.Value = ((uint)(0u));
            // 
            // tbFlags2
            // 
            this.tbFlags2.Location = new System.Drawing.Point(378, 29);
            this.tbFlags2.MaxLength = 16;
            this.tbFlags2.MaxValue = ((uint)(0u));
            this.tbFlags2.MinValue = ((uint)(0u));
            this.tbFlags2.Name = "tbFlags2";
            this.tbFlags2.Size = new System.Drawing.Size(100, 20);
            this.tbFlags2.TabIndex = 7;
            this.tbFlags2.Text = "0";
            this.tbFlags2.Value = ((uint)(0u));
            // 
            // propertyToolset1
            // 
            this.propertyToolset1.Location = new System.Drawing.Point(260, 3);
            this.propertyToolset1.Name = "propertyToolset1";
            this.propertyToolset1.Size = new System.Drawing.Size(104, 24);
            this.propertyToolset1.TabIndex = 7;
            // 
            // TabAttackDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.propertyToolset1);
            this.Controls.Add(this.cbAttackDef);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "TabAttackDetails";
            this.Size = new System.Drawing.Size(607, 353);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbAttackDef;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private BitEdit tbHitEffect1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private BitEdit tbHitEffect2;
        private BitEdit tbGuardDisp;
        private BitEdit tbControlEnemy;
        private BitEdit tbCrouchCollision;
        private BitEdit tbBendBack;
        private BitEdit tbDamage;
        private BitEdit tbHitBack;
        private BitEdit tbStunGauge;
        private BitEdit tbHitEffects;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private BitEdit tbFlags1;
        private BitEdit tbFlags2;
        private Controls.PropertyToolset propertyToolset1;
    }
}
