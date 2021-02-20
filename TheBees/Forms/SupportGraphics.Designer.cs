namespace TheBees.Forms
{
    partial class SupportGraphics
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
            this.cbUnit = new System.Windows.Forms.ComboBox();
            this.cbBaseIndex = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbCategoryRef = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbDataRef = new System.Windows.Forms.ComboBox();
            this.cbActionRef = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.supportGfx4 = new TheBees.Forms.TabSupportGfx();
            this.supportGfx3 = new TheBees.Forms.TabSupportGfx();
            this.supportGfx2 = new TheBees.Forms.TabSupportGfx();
            this.supportGfx1 = new TheBees.Forms.TabSupportGfx();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Unit";
            // 
            // cbUnit
            // 
            this.cbUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUnit.FormattingEnabled = true;
            this.cbUnit.Location = new System.Drawing.Point(85, 48);
            this.cbUnit.Name = "cbUnit";
            this.cbUnit.Size = new System.Drawing.Size(79, 21);
            this.cbUnit.TabIndex = 1;
            // 
            // cbBaseIndex
            // 
            this.cbBaseIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBaseIndex.FormattingEnabled = true;
            this.cbBaseIndex.Location = new System.Drawing.Point(85, 75);
            this.cbBaseIndex.Name = "cbBaseIndex";
            this.cbBaseIndex.Size = new System.Drawing.Size(79, 21);
            this.cbBaseIndex.TabIndex = 2;
            this.cbBaseIndex.SelectionChangeCommitted += new System.EventHandler(this.OnBaseIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Base Index";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 112);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Reference Category";
            // 
            // cbCategoryRef
            // 
            this.cbCategoryRef.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategoryRef.FormattingEnabled = true;
            this.cbCategoryRef.Location = new System.Drawing.Point(15, 128);
            this.cbCategoryRef.Name = "cbCategoryRef";
            this.cbCategoryRef.Size = new System.Drawing.Size(151, 21);
            this.cbCategoryRef.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 152);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Reference Action";
            // 
            // cbDataRef
            // 
            this.cbDataRef.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDataRef.FormattingEnabled = true;
            this.cbDataRef.Location = new System.Drawing.Point(15, 209);
            this.cbDataRef.Name = "cbDataRef";
            this.cbDataRef.Size = new System.Drawing.Size(151, 21);
            this.cbDataRef.TabIndex = 23;
            // 
            // cbActionRef
            // 
            this.cbActionRef.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbActionRef.FormattingEnabled = true;
            this.cbActionRef.Location = new System.Drawing.Point(13, 168);
            this.cbActionRef.Name = "cbActionRef";
            this.cbActionRef.Size = new System.Drawing.Size(151, 21);
            this.cbActionRef.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 193);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Reference Data Index";
            // 
            // supportGfx4
            // 
            this.supportGfx4.Location = new System.Drawing.Point(512, 22);
            this.supportGfx4.Name = "supportGfx4";
            this.supportGfx4.ShowText = false;
            this.supportGfx4.Size = new System.Drawing.Size(167, 296);
            this.supportGfx4.TabIndex = 9;
            // 
            // supportGfx3
            // 
            this.supportGfx3.Location = new System.Drawing.Point(431, 22);
            this.supportGfx3.Name = "supportGfx3";
            this.supportGfx3.ShowText = false;
            this.supportGfx3.Size = new System.Drawing.Size(167, 296);
            this.supportGfx3.TabIndex = 8;
            // 
            // supportGfx2
            // 
            this.supportGfx2.Location = new System.Drawing.Point(348, 22);
            this.supportGfx2.Name = "supportGfx2";
            this.supportGfx2.ShowText = false;
            this.supportGfx2.Size = new System.Drawing.Size(167, 296);
            this.supportGfx2.TabIndex = 7;
            // 
            // supportGfx1
            // 
            this.supportGfx1.Location = new System.Drawing.Point(189, 22);
            this.supportGfx1.Name = "supportGfx1";
            this.supportGfx1.ShowText = true;
            this.supportGfx1.Size = new System.Drawing.Size(227, 296);
            this.supportGfx1.TabIndex = 6;
            // 
            // SupportGraphics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 348);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbCategoryRef);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbDataRef);
            this.Controls.Add(this.cbActionRef);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbBaseIndex);
            this.Controls.Add(this.cbUnit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.supportGfx4);
            this.Controls.Add(this.supportGfx3);
            this.Controls.Add(this.supportGfx2);
            this.Controls.Add(this.supportGfx1);
            this.Name = "SupportGraphics";
            this.Text = "SupportGraphics";
            this.Shown += new System.EventHandler(this.OnShow);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbUnit;
        private System.Windows.Forms.ComboBox cbBaseIndex;
        private System.Windows.Forms.Label label2;
        private TabSupportGfx supportGfx1;
        private TabSupportGfx supportGfx2;
        private TabSupportGfx supportGfx3;
        private TabSupportGfx supportGfx4;

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbCategoryRef;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbDataRef;
        private System.Windows.Forms.ComboBox cbActionRef;
        private System.Windows.Forms.Label label6;
    }

}