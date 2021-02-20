namespace TheBees.Forms
{
    partial class CreateRegion
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
            this.tbRegionName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbFromIndex = new TheBees.BitEdit();
            this.tbToIndex = new TheBees.BitEdit();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbRegionName
            // 
            this.tbRegionName.Location = new System.Drawing.Point(12, 38);
            this.tbRegionName.Name = "tbRegionName";
            this.tbRegionName.Size = new System.Drawing.Size(225, 20);
            this.tbRegionName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter Region Description";
            // 
            // tbFromIndex
            // 
            this.tbFromIndex.Location = new System.Drawing.Point(12, 82);
            this.tbFromIndex.MaxLength = 16;
            this.tbFromIndex.MaxValue = ((uint)(0u));
            this.tbFromIndex.MinValue = ((uint)(0u));
            this.tbFromIndex.Name = "tbFromIndex";
            this.tbFromIndex.Size = new System.Drawing.Size(67, 20);
            this.tbFromIndex.TabIndex = 32;
            this.tbFromIndex.Tag = "2";
            this.tbFromIndex.Text = "0";
            this.tbFromIndex.Value = ((uint)(0u));
            // 
            // tbToIndex
            // 
            this.tbToIndex.Location = new System.Drawing.Point(128, 82);
            this.tbToIndex.MaxLength = 16;
            this.tbToIndex.MaxValue = ((uint)(0u));
            this.tbToIndex.MinValue = ((uint)(0u));
            this.tbToIndex.Name = "tbToIndex";
            this.tbToIndex.Size = new System.Drawing.Size(67, 20);
            this.tbToIndex.TabIndex = 33;
            this.tbToIndex.Tag = "2";
            this.tbToIndex.Text = "0";
            this.tbToIndex.Value = ((uint)(0u));
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(174, 147);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 34;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.OnCancel);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(83, 147);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 35;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.OnOK);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "From";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(125, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "To";
            // 
            // CreateRegion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 182);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tbToIndex);
            this.Controls.Add(this.tbFromIndex);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbRegionName);
            this.Name = "CreateRegion";
            this.Text = "CreateRegion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbRegionName;
        private System.Windows.Forms.Label label1;
        private BitEdit tbFromIndex;
        private BitEdit tbToIndex;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}