namespace TheBees.Forms
{
    partial class TabActionHeader
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
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label38 = new System.Windows.Forms.Label();
            this.rb8Byte = new System.Windows.Forms.RadioButton();
            this.rb16Byte = new System.Windows.Forms.RadioButton();
            this.rb24Byte = new System.Windows.Forms.RadioButton();
            this.label31 = new System.Windows.Forms.Label();
            this.tbJudgmentRelated = new TheBees.BitEdit();
            this.tbTechRelated = new TheBees.BitEdit();
            this.label32 = new System.Windows.Forms.Label();
            this.tbUnknown1 = new TheBees.BitEdit();
            this.tbUnknown2 = new TheBees.BitEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tableLayoutPanel.Controls.Add(this.label2, 0, 7);
            this.tableLayoutPanel.Controls.Add(this.label38, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.rb16Byte, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.rb24Byte, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.label31, 0, 4);
            this.tableLayoutPanel.Controls.Add(this.tbJudgmentRelated, 1, 4);
            this.tableLayoutPanel.Controls.Add(this.tbTechRelated, 1, 5);
            this.tableLayoutPanel.Controls.Add(this.label32, 0, 5);
            this.tableLayoutPanel.Controls.Add(this.rb8Byte, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.tbUnknown1, 1, 6);
            this.tableLayoutPanel.Controls.Add(this.tbUnknown2, 1, 7);
            this.tableLayoutPanel.Controls.Add(this.label1, 0, 6);
            this.tableLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 8;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(220, 210);
            this.tableLayoutPanel.TabIndex = 2;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(3, 34);
            this.label38.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(80, 13);
            this.label38.TabIndex = 1;
            this.label38.Text = "Length Of Data";
            // 
            // rb8Byte
            // 
            this.rb8Byte.AutoSize = true;
            this.rb8Byte.Location = new System.Drawing.Point(128, 29);
            this.rb8Byte.Name = "rb8Byte";
            this.rb8Byte.Size = new System.Drawing.Size(55, 17);
            this.rb8Byte.TabIndex = 20;
            this.rb8Byte.TabStop = true;
            this.rb8Byte.Text = "8 Byte";
            this.rb8Byte.UseVisualStyleBackColor = true;
            // 
            // rb16Byte
            // 
            this.rb16Byte.AutoSize = true;
            this.rb16Byte.Location = new System.Drawing.Point(128, 55);
            this.rb16Byte.Name = "rb16Byte";
            this.rb16Byte.Size = new System.Drawing.Size(61, 17);
            this.rb16Byte.TabIndex = 21;
            this.rb16Byte.TabStop = true;
            this.rb16Byte.Text = "16 Byte";
            this.rb16Byte.UseVisualStyleBackColor = true;
            // 
            // rb24Byte
            // 
            this.rb24Byte.AutoSize = true;
            this.rb24Byte.Location = new System.Drawing.Point(128, 81);
            this.rb24Byte.Name = "rb24Byte";
            this.rb24Byte.Size = new System.Drawing.Size(61, 17);
            this.rb24Byte.TabIndex = 22;
            this.rb24Byte.TabStop = true;
            this.rb24Byte.Text = "24 Byte";
            this.rb24Byte.UseVisualStyleBackColor = true;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(3, 112);
            this.label31.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(93, 13);
            this.label31.TabIndex = 3;
            this.label31.Text = "Judgment Related";
            // 
            // tbJudgmentRelated
            // 
            this.tbJudgmentRelated.Location = new System.Drawing.Point(128, 107);
            this.tbJudgmentRelated.MaxLength = 16;
            this.tbJudgmentRelated.MaxValue = ((uint)(0u));
            this.tbJudgmentRelated.MinValue = ((uint)(0u));
            this.tbJudgmentRelated.Name = "tbJudgmentRelated";
            this.tbJudgmentRelated.Size = new System.Drawing.Size(70, 20);
            this.tbJudgmentRelated.TabIndex = 18;
            this.tbJudgmentRelated.Text = "0";
            this.tbJudgmentRelated.Value = ((uint)(0u));
            // 
            // tbTechRelated
            // 
            this.tbTechRelated.Location = new System.Drawing.Point(128, 133);
            this.tbTechRelated.MaxLength = 16;
            this.tbTechRelated.MaxValue = ((uint)(0u));
            this.tbTechRelated.MinValue = ((uint)(0u));
            this.tbTechRelated.Name = "tbTechRelated";
            this.tbTechRelated.Size = new System.Drawing.Size(70, 20);
            this.tbTechRelated.TabIndex = 19;
            this.tbTechRelated.Text = "0";
            this.tbTechRelated.Value = ((uint)(0u));
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(3, 138);
            this.label32.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(72, 13);
            this.label32.TabIndex = 4;
            this.label32.Text = "Tech Related";
            // 
            // tbUnknown1
            // 
            this.tbUnknown1.Location = new System.Drawing.Point(128, 159);
            this.tbUnknown1.MaxLength = 16;
            this.tbUnknown1.MaxValue = ((uint)(0u));
            this.tbUnknown1.MinValue = ((uint)(0u));
            this.tbUnknown1.Name = "tbUnknown1";
            this.tbUnknown1.Size = new System.Drawing.Size(70, 20);
            this.tbUnknown1.TabIndex = 23;
            this.tbUnknown1.Text = "0";
            this.tbUnknown1.Value = ((uint)(0u));
            // 
            // tbUnknown2
            // 
            this.tbUnknown2.Location = new System.Drawing.Point(128, 185);
            this.tbUnknown2.MaxLength = 16;
            this.tbUnknown2.MaxValue = ((uint)(0u));
            this.tbUnknown2.MinValue = ((uint)(0u));
            this.tbUnknown2.Name = "tbUnknown2";
            this.tbUnknown2.Size = new System.Drawing.Size(70, 20);
            this.tbUnknown2.TabIndex = 24;
            this.tbUnknown2.Text = "0";
            this.tbUnknown2.Value = ((uint)(0u));
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 164);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "unknown 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 190);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "unknown 2";
            // 
            // TabActionHeader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "TabActionHeader";
            this.Size = new System.Drawing.Size(226, 216);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label32;
        private BitEdit tbJudgmentRelated;
        private BitEdit tbTechRelated;
        private System.Windows.Forms.RadioButton rb8Byte;
        private System.Windows.Forms.RadioButton rb16Byte;
        private System.Windows.Forms.RadioButton rb24Byte;
        private System.Windows.Forms.Label label2;
        private BitEdit tbUnknown1;
        private BitEdit tbUnknown2;
        private System.Windows.Forms.Label label1;
    }
}
