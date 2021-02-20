namespace TheBees.Forms
{
    partial class NewActionDialog
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
            this.btnSelect = new System.Windows.Forms.Button();
            this.rb24Byte = new System.Windows.Forms.RadioButton();
            this.rb16Byte = new System.Windows.Forms.RadioButton();
            this.rb8Byte = new System.Windows.Forms.RadioButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkAddFooter = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(100, 177);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 0;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.OnClickSelect);
            // 
            // rb24Byte
            // 
            this.rb24Byte.AutoSize = true;
            this.rb24Byte.Location = new System.Drawing.Point(25, 75);
            this.rb24Byte.Name = "rb24Byte";
            this.rb24Byte.Size = new System.Drawing.Size(60, 17);
            this.rb24Byte.TabIndex = 1;
            this.rb24Byte.TabStop = true;
            this.rb24Byte.Text = "24 byte";
            this.rb24Byte.UseVisualStyleBackColor = true;
            this.rb24Byte.CheckedChanged += new System.EventHandler(this.On24ByteCheckedChanged);
            // 
            // rb16Byte
            // 
            this.rb16Byte.AutoSize = true;
            this.rb16Byte.Location = new System.Drawing.Point(25, 52);
            this.rb16Byte.Name = "rb16Byte";
            this.rb16Byte.Size = new System.Drawing.Size(60, 17);
            this.rb16Byte.TabIndex = 2;
            this.rb16Byte.TabStop = true;
            this.rb16Byte.Text = "16 byte";
            this.rb16Byte.UseVisualStyleBackColor = true;
            this.rb16Byte.CheckedChanged += new System.EventHandler(this.On16ByteCheckedChanged);
            // 
            // rb8Byte
            // 
            this.rb8Byte.AutoSize = true;
            this.rb8Byte.Location = new System.Drawing.Point(25, 29);
            this.rb8Byte.Name = "rb8Byte";
            this.rb8Byte.Size = new System.Drawing.Size(54, 17);
            this.rb8Byte.TabIndex = 3;
            this.rb8Byte.TabStop = true;
            this.rb8Byte.Text = "8 byte";
            this.rb8Byte.UseVisualStyleBackColor = true;
            this.rb8Byte.CheckedChanged += new System.EventHandler(this.On8ByteCheckedChanegd);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(19, 177);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.OnClickCancel);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb16Byte);
            this.groupBox1.Controls.Add(this.rb24Byte);
            this.groupBox1.Controls.Add(this.rb8Byte);
            this.groupBox1.Location = new System.Drawing.Point(19, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(156, 118);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Size Of Data";
            // 
            // chkAddFooter
            // 
            this.chkAddFooter.AutoSize = true;
            this.chkAddFooter.Location = new System.Drawing.Point(26, 145);
            this.chkAddFooter.Name = "chkAddFooter";
            this.chkAddFooter.Size = new System.Drawing.Size(78, 17);
            this.chkAddFooter.TabIndex = 6;
            this.chkAddFooter.Text = "Add Footer";
            this.chkAddFooter.UseVisualStyleBackColor = true;
            // 
            // NewActionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(192, 216);
            this.Controls.Add(this.chkAddFooter);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSelect);
            this.Name = "NewActionDialog";
            this.Text = "NewActionDialog";
            this.Shown += new System.EventHandler(this.OnShown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.RadioButton rb24Byte;
        private System.Windows.Forms.RadioButton rb16Byte;
        private System.Windows.Forms.RadioButton rb8Byte;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkAddFooter;
    }
}