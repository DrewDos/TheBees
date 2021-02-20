namespace TheBees.Forms
{
    partial class ModifySAEffect
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
            this.cbUnitSel = new System.Windows.Forms.ComboBox();
            this.rbSuperArt1 = new System.Windows.Forms.RadioButton();
            this.rbSuperArt2 = new System.Windows.Forms.RadioButton();
            this.rbSuperArt3 = new System.Windows.Forms.RadioButton();
            this.tabSAEffect = new TheBees.Forms.TabSAEffect(activeData);
            this.SuspendLayout();
            // 
            // cbUnitSel
            // 
            this.cbUnitSel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUnitSel.FormattingEnabled = true;
            this.cbUnitSel.Location = new System.Drawing.Point(25, 37);
            this.cbUnitSel.Name = "cbUnitSel";
            this.cbUnitSel.Size = new System.Drawing.Size(121, 21);
            this.cbUnitSel.TabIndex = 1;
            this.cbUnitSel.SelectionChangeCommitted += new System.EventHandler(this.OnUnitSelect);
            // 
            // rbSuperArt1
            // 
            this.rbSuperArt1.AutoSize = true;
            this.rbSuperArt1.Location = new System.Drawing.Point(25, 64);
            this.rbSuperArt1.Name = "rbSuperArt1";
            this.rbSuperArt1.Size = new System.Drawing.Size(78, 17);
            this.rbSuperArt1.TabIndex = 2;
            this.rbSuperArt1.TabStop = true;
            this.rbSuperArt1.Tag = "0";
            this.rbSuperArt1.Text = "Super Art 1";
            this.rbSuperArt1.UseVisualStyleBackColor = true;
            this.rbSuperArt1.CheckedChanged += new System.EventHandler(this.OnSelectSuperArtNum);
            // 
            // rbSuperArt2
            // 
            this.rbSuperArt2.AutoSize = true;
            this.rbSuperArt2.Location = new System.Drawing.Point(25, 87);
            this.rbSuperArt2.Name = "rbSuperArt2";
            this.rbSuperArt2.Size = new System.Drawing.Size(78, 17);
            this.rbSuperArt2.TabIndex = 3;
            this.rbSuperArt2.TabStop = true;
            this.rbSuperArt2.Tag = "1";
            this.rbSuperArt2.Text = "Super Art 2";
            this.rbSuperArt2.UseVisualStyleBackColor = true;
            this.rbSuperArt2.CheckedChanged += new System.EventHandler(this.OnSelectSuperArtNum);
            // 
            // rbSuperArt3
            // 
            this.rbSuperArt3.AutoSize = true;
            this.rbSuperArt3.Location = new System.Drawing.Point(25, 110);
            this.rbSuperArt3.Name = "rbSuperArt3";
            this.rbSuperArt3.Size = new System.Drawing.Size(78, 17);
            this.rbSuperArt3.TabIndex = 4;
            this.rbSuperArt3.TabStop = true;
            this.rbSuperArt3.Tag = "2";
            this.rbSuperArt3.Text = "Super Art 3";
            this.rbSuperArt3.UseVisualStyleBackColor = true;
            this.rbSuperArt3.CheckedChanged += new System.EventHandler(this.OnSelectSuperArtNum);
            // 
            // tabSAEffect
            // 
            this.tabSAEffect.Location = new System.Drawing.Point(12, 136);
            this.tabSAEffect.Name = "tabSAEffect";
            this.tabSAEffect.Size = new System.Drawing.Size(264, 252);
            this.tabSAEffect.TabIndex = 0;
            // 
            // ModifySAEffect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(251, 417);
            this.Controls.Add(this.rbSuperArt3);
            this.Controls.Add(this.rbSuperArt2);
            this.Controls.Add(this.rbSuperArt1);
            this.Controls.Add(this.cbUnitSel);
            this.Controls.Add(this.tabSAEffect);
            this.Name = "ModifySAEffect";
            this.Text = "ModifySAEffect";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TabSAEffect tabSAEffect;
        private System.Windows.Forms.ComboBox cbUnitSel;
        private System.Windows.Forms.RadioButton rbSuperArt1;
        private System.Windows.Forms.RadioButton rbSuperArt2;
        private System.Windows.Forms.RadioButton rbSuperArt3;
    }
}