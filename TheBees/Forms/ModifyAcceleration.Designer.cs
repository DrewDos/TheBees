namespace TheBees.Forms
{
    partial class ModifyAcceleration
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
            this.tabAccel = new TheBees.Forms.TabAccel(activeData);
            this.label1 = new System.Windows.Forms.Label();
            this.cbUnit = new System.Windows.Forms.ComboBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tabAccel
            // 
            this.tabAccel.Location = new System.Drawing.Point(12, 32);
            this.tabAccel.Name = "tabAccel";
            this.tabAccel.Size = new System.Drawing.Size(198, 242);
            this.tabAccel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Unit";
            // 
            // cbUnit
            // 
            this.cbUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUnit.FormattingEnabled = true;
            this.cbUnit.Location = new System.Drawing.Point(81, 20);
            this.cbUnit.Name = "cbUnit";
            this.cbUnit.Size = new System.Drawing.Size(121, 21);
            this.cbUnit.TabIndex = 2;
            this.cbUnit.SelectionChangeCommitted += new System.EventHandler(this.OnChangeUnit);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(138, 270);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(74, 29);
            this.btnSelect.TabIndex = 3;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.OnClickSelect);
            // 
            // ModifyAcceleration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 311);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.cbUnit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabAccel);
            this.Name = "ModifyAcceleration";
            this.Text = "ModifyAcceleration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TabAccel tabAccel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbUnit;
        private System.Windows.Forms.Button btnSelect;
    }
}