namespace TheBees.Forms
{
    partial class TabCollision : NodeLayout
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
            this.label30 = new System.Windows.Forms.Label();
            this.cbAllClsnIndex = new System.Windows.Forms.ComboBox();
            this.label29 = new System.Windows.Forms.Label();
            this.cbClsnIndex = new System.Windows.Forms.ComboBox();
            this.rbCollisionThrown = new System.Windows.Forms.RadioButton();
            this.rbCollisionThrow = new System.Windows.Forms.RadioButton();
            this.rbCollisionAttack = new System.Windows.Forms.RadioButton();
            this.rbCollision3 = new System.Windows.Forms.RadioButton();
            this.rbCollision2 = new System.Windows.Forms.RadioButton();
            this.rbCollision1 = new System.Windows.Forms.RadioButton();
            this.toolsAllCollision = new TheBees.Controls.PropertyToolset();
            this.toolsActiveCollision = new TheBees.Controls.PropertyToolset();
            this.SuspendLayout();
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(112, 7);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(88, 13);
            this.label30.TabIndex = 21;
            this.label30.Text = "All Collision Index";
            // 
            // cbAllClsnIndex
            // 
            this.cbAllClsnIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAllClsnIndex.FormattingEnabled = true;
            this.cbAllClsnIndex.Location = new System.Drawing.Point(216, 3);
            this.cbAllClsnIndex.Name = "cbAllClsnIndex";
            this.cbAllClsnIndex.Size = new System.Drawing.Size(77, 21);
            this.cbAllClsnIndex.TabIndex = 20;
            this.cbAllClsnIndex.SelectionChangeCommitted += new System.EventHandler(this.OnAllCollisionIndexChange);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(320, 7);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(74, 13);
            this.label29.TabIndex = 19;
            this.label29.Text = "Collision Index";
            // 
            // cbClsnIndex
            // 
            this.cbClsnIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbClsnIndex.FormattingEnabled = true;
            this.cbClsnIndex.Location = new System.Drawing.Point(400, 4);
            this.cbClsnIndex.Name = "cbClsnIndex";
            this.cbClsnIndex.Size = new System.Drawing.Size(77, 21);
            this.cbClsnIndex.TabIndex = 18;
            this.cbClsnIndex.SelectionChangeCommitted += new System.EventHandler(this.OnCollisionIndexChange);
            // 
            // rbCollisionThrown
            // 
            this.rbCollisionThrown.AutoSize = true;
            this.rbCollisionThrown.Location = new System.Drawing.Point(6, 122);
            this.rbCollisionThrown.Name = "rbCollisionThrown";
            this.rbCollisionThrown.Size = new System.Drawing.Size(89, 17);
            this.rbCollisionThrown.TabIndex = 17;
            this.rbCollisionThrown.TabStop = true;
            this.rbCollisionThrown.Tag = "jgmtThrown";
            this.rbCollisionThrown.Text = "Jump Thrown";
            this.rbCollisionThrown.UseVisualStyleBackColor = true;
            this.rbCollisionThrown.CheckedChanged += new System.EventHandler(this.OnCollisionTypeChanged);
            // 
            // rbCollisionThrow
            // 
            this.rbCollisionThrow.AutoSize = true;
            this.rbCollisionThrow.Location = new System.Drawing.Point(6, 99);
            this.rbCollisionThrow.Name = "rbCollisionThrow";
            this.rbCollisionThrow.Size = new System.Drawing.Size(55, 17);
            this.rbCollisionThrow.TabIndex = 16;
            this.rbCollisionThrow.TabStop = true;
            this.rbCollisionThrow.Tag = "throwJgmt";
            this.rbCollisionThrow.Text = "Throw";
            this.rbCollisionThrow.UseVisualStyleBackColor = true;
            this.rbCollisionThrow.CheckedChanged += new System.EventHandler(this.OnCollisionTypeChanged);
            // 
            // rbCollisionAttack
            // 
            this.rbCollisionAttack.AutoSize = true;
            this.rbCollisionAttack.Location = new System.Drawing.Point(6, 76);
            this.rbCollisionAttack.Name = "rbCollisionAttack";
            this.rbCollisionAttack.Size = new System.Drawing.Size(56, 17);
            this.rbCollisionAttack.TabIndex = 15;
            this.rbCollisionAttack.TabStop = true;
            this.rbCollisionAttack.Tag = "atkRoll";
            this.rbCollisionAttack.Text = "Attack";
            this.rbCollisionAttack.UseVisualStyleBackColor = true;
            this.rbCollisionAttack.CheckedChanged += new System.EventHandler(this.OnCollisionTypeChanged);
            // 
            // rbCollision3
            // 
            this.rbCollision3.AutoSize = true;
            this.rbCollision3.Location = new System.Drawing.Point(6, 53);
            this.rbCollision3.Name = "rbCollision3";
            this.rbCollision3.Size = new System.Drawing.Size(72, 17);
            this.rbCollision3.TabIndex = 14;
            this.rbCollision3.TabStop = true;
            this.rbCollision3.Tag = "decision3";
            this.rbCollision3.Text = "Collision 3";
            this.rbCollision3.UseVisualStyleBackColor = true;
            this.rbCollision3.CheckedChanged += new System.EventHandler(this.OnCollisionTypeChanged);
            // 
            // rbCollision2
            // 
            this.rbCollision2.AutoSize = true;
            this.rbCollision2.Location = new System.Drawing.Point(6, 30);
            this.rbCollision2.Name = "rbCollision2";
            this.rbCollision2.Size = new System.Drawing.Size(72, 17);
            this.rbCollision2.TabIndex = 13;
            this.rbCollision2.Tag = "decision2";
            this.rbCollision2.Text = "Collision 2";
            this.rbCollision2.UseVisualStyleBackColor = true;
            this.rbCollision2.CheckedChanged += new System.EventHandler(this.OnCollisionTypeChanged);
            // 
            // rbCollision1
            // 
            this.rbCollision1.AutoSize = true;
            this.rbCollision1.Checked = true;
            this.rbCollision1.Location = new System.Drawing.Point(6, 7);
            this.rbCollision1.Name = "rbCollision1";
            this.rbCollision1.Size = new System.Drawing.Size(72, 17);
            this.rbCollision1.TabIndex = 12;
            this.rbCollision1.TabStop = true;
            this.rbCollision1.Tag = "decision1";
            this.rbCollision1.Text = "Collision 1";
            this.rbCollision1.UseVisualStyleBackColor = true;
            this.rbCollision1.CheckedChanged += new System.EventHandler(this.OnCollisionTypeChanged);
            // 
            // toolsAllCollision
            // 
            this.toolsAllCollision.Location = new System.Drawing.Point(216, 26);
            this.toolsAllCollision.Name = "toolsAllCollision";
            this.toolsAllCollision.Size = new System.Drawing.Size(77, 24);
            this.toolsAllCollision.TabIndex = 22;
            // 
            // toolsActiveCollision
            // 
            this.toolsActiveCollision.Location = new System.Drawing.Point(400, 26);
            this.toolsActiveCollision.Name = "toolsActiveCollision";
            this.toolsActiveCollision.Size = new System.Drawing.Size(77, 24);
            this.toolsActiveCollision.TabIndex = 23;
            // 
            // TabCollision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolsActiveCollision);
            this.Controls.Add(this.toolsAllCollision);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.cbAllClsnIndex);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.cbClsnIndex);
            this.Controls.Add(this.rbCollisionThrown);
            this.Controls.Add(this.rbCollisionThrow);
            this.Controls.Add(this.rbCollisionAttack);
            this.Controls.Add(this.rbCollision3);
            this.Controls.Add(this.rbCollision2);
            this.Controls.Add(this.rbCollision1);
            this.Name = "TabCollision";
            this.Size = new System.Drawing.Size(498, 363);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.ComboBox cbAllClsnIndex;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.ComboBox cbClsnIndex;
        private System.Windows.Forms.RadioButton rbCollisionThrown;
        private System.Windows.Forms.RadioButton rbCollisionThrow;
        private System.Windows.Forms.RadioButton rbCollisionAttack;
        private System.Windows.Forms.RadioButton rbCollision3;
        private System.Windows.Forms.RadioButton rbCollision2;
        private System.Windows.Forms.RadioButton rbCollision1;
        private Controls.PropertyToolset toolsAllCollision;
        private Controls.PropertyToolset toolsActiveCollision;
    }
}
