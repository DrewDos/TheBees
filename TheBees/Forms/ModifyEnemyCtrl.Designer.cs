namespace TheBees.Forms
{
    partial class ModifyEnemyCtrl
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
            this.tabEnemyCtrl1 = new TheBees.Forms.TabEnemyCtrl(activeData);
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbUnitSel
            // 
            this.cbUnitSel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUnitSel.FormattingEnabled = true;
            this.cbUnitSel.Location = new System.Drawing.Point(25, 29);
            this.cbUnitSel.Name = "cbUnitSel";
            this.cbUnitSel.Size = new System.Drawing.Size(121, 21);
            this.cbUnitSel.TabIndex = 1;
            // 
            // tabEnemyCtrl1
            // 
            this.tabEnemyCtrl1.Location = new System.Drawing.Point(6, 19);
            this.tabEnemyCtrl1.Name = "tabEnemyCtrl1";
            this.tabEnemyCtrl1.Size = new System.Drawing.Size(507, 400);
            this.tabEnemyCtrl1.TabIndex = 2;
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.tabEnemyCtrl1);
            this.groupBox.Location = new System.Drawing.Point(19, 65);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(524, 425);
            this.groupBox.TabIndex = 3;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Property Select";
            // 
            // ModifyEnemyCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 506);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.cbUnitSel);
            this.Name = "ModifyEnemyCtrl";
            this.Text = "Modify Enemy Ctrl";
            this.groupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbUnitSel;
        private TabEnemyCtrl tabEnemyCtrl1;
        private System.Windows.Forms.GroupBox groupBox;
    }
}