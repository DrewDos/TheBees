namespace TheBees.Forms
{
    partial class FCReference
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbCategoryIndex = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.cbDataIndex = new System.Windows.Forms.ComboBox();
            this.cbActionIndex = new System.Windows.Forms.ComboBox();
            this.btnJumpTo = new System.Windows.Forms.Button();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Category";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Action";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Data Index";
            // 
            // cbCategoryIndex
            // 
            this.cbCategoryIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategoryIndex.FormattingEnabled = true;
            this.cbCategoryIndex.Location = new System.Drawing.Point(132, 3);
            this.cbCategoryIndex.Name = "cbCategoryIndex";
            this.cbCategoryIndex.Size = new System.Drawing.Size(121, 21);
            this.cbCategoryIndex.TabIndex = 3;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.cbDataIndex, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.cbActionIndex, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.cbCategoryIndex, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.btnJumpTo, 1, 3);
            this.tableLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 4;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(259, 135);
            this.tableLayoutPanel.TabIndex = 4;
            // 
            // cbDataIndex
            // 
            this.cbDataIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDataIndex.FormattingEnabled = true;
            this.cbDataIndex.Location = new System.Drawing.Point(132, 63);
            this.cbDataIndex.Name = "cbDataIndex";
            this.cbDataIndex.Size = new System.Drawing.Size(124, 21);
            this.cbDataIndex.TabIndex = 5;
            // 
            // cbActionIndex
            // 
            this.cbActionIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbActionIndex.FormattingEnabled = true;
            this.cbActionIndex.Location = new System.Drawing.Point(132, 33);
            this.cbActionIndex.Name = "cbActionIndex";
            this.cbActionIndex.Size = new System.Drawing.Size(121, 21);
            this.cbActionIndex.TabIndex = 4;
            // 
            // btnJumpTo
            // 
            this.btnJumpTo.Location = new System.Drawing.Point(132, 93);
            this.btnJumpTo.Name = "btnJumpTo";
            this.btnJumpTo.Size = new System.Drawing.Size(75, 23);
            this.btnJumpTo.TabIndex = 6;
            this.btnJumpTo.Text = "Jump To";
            this.btnJumpTo.UseVisualStyleBackColor = true;
            this.btnJumpTo.Click += new System.EventHandler(this.OnClickJumpTo);
            // 
            // FCReference
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "FCReference";
            this.Size = new System.Drawing.Size(266, 138);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbCategoryIndex;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.ComboBox cbDataIndex;
        private System.Windows.Forms.ComboBox cbActionIndex;
        private System.Windows.Forms.Button btnJumpTo;
    }
}
