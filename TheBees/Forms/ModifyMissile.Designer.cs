namespace TheBees.Forms
{
    partial class ModifyMissile
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
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.tabMissileConfig1 = new TheBees.Forms.TabMissileConfig(activeData);
            this.label1 = new System.Windows.Forms.Label();
            this.cbMissileSelect = new System.Windows.Forms.ComboBox();
            this.lblDataAddress = new System.Windows.Forms.Label();
            this.toolsMissile = new TheBees.Controls.PropertyToolset();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.tabMissileConfig1);
            this.groupBox.Location = new System.Drawing.Point(15, 89);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(609, 344);
            this.groupBox.TabIndex = 1;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Edit Missile Properties";
            // 
            // tabMissileConfig1
            // 
            this.tabMissileConfig1.Location = new System.Drawing.Point(17, 19);
            this.tabMissileConfig1.Name = "tabMissileConfig1";
            this.tabMissileConfig1.Size = new System.Drawing.Size(589, 310);
            this.tabMissileConfig1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Missile";
            // 
            // cbMissileSelect
            // 
            this.cbMissileSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMissileSelect.FormattingEnabled = true;
            this.cbMissileSelect.Location = new System.Drawing.Point(12, 25);
            this.cbMissileSelect.Name = "cbMissileSelect";
            this.cbMissileSelect.Size = new System.Drawing.Size(154, 21);
            this.cbMissileSelect.TabIndex = 3;
            this.cbMissileSelect.SelectionChangeCommitted += new System.EventHandler(this.OnMissileSelectCommitted);
            // 
            // lblDataAddress
            // 
            this.lblDataAddress.AutoSize = true;
            this.lblDataAddress.Location = new System.Drawing.Point(189, 52);
            this.lblDataAddress.Name = "lblDataAddress";
            this.lblDataAddress.Size = new System.Drawing.Size(77, 13);
            this.lblDataAddress.TabIndex = 7;
            this.lblDataAddress.Text = "Data Address: ";
            // 
            // toolsMissile
            // 
            this.toolsMissile.Location = new System.Drawing.Point(67, 52);
            this.toolsMissile.Name = "toolsMissile";
            this.toolsMissile.Size = new System.Drawing.Size(105, 31);
            this.toolsMissile.TabIndex = 8;
            // 
            // ModifyMissile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 445);
            this.Controls.Add(this.toolsMissile);
            this.Controls.Add(this.lblDataAddress);
            this.Controls.Add(this.cbMissileSelect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox);
            this.Name = "ModifyMissile";
            this.Text = "ModifyMissile";
            this.groupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbMissileSelect;
        private System.Windows.Forms.Label lblDataAddress;
        private Controls.PropertyToolset toolsMissile;
        private TabMissileConfig tabMissileConfig1;
    }
}