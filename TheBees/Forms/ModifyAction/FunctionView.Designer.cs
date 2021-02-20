namespace TheBees.Forms
{
    partial class FunctionView
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
            this.btnNext = new System.Windows.Forms.Button();
            this.cbFunction = new System.Windows.Forms.ComboBox();
            this.lblIndex = new System.Windows.Forms.Label();
            this.btnPrev = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblReferenceSet = new System.Windows.Forms.Label();
            this.btnWriteReference = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(127, 104);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.OnClickNext);
            // 
            // cbFunction
            // 
            this.cbFunction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFunction.FormattingEnabled = true;
            this.cbFunction.Location = new System.Drawing.Point(12, 41);
            this.cbFunction.Name = "cbFunction";
            this.cbFunction.Size = new System.Drawing.Size(190, 21);
            this.cbFunction.TabIndex = 1;
            this.cbFunction.SelectedIndexChanged += new System.EventHandler(this.OnChangeFunction);
            // 
            // lblIndex
            // 
            this.lblIndex.AutoSize = true;
            this.lblIndex.Location = new System.Drawing.Point(91, 75);
            this.lblIndex.Name = "lblIndex";
            this.lblIndex.Size = new System.Drawing.Size(34, 13);
            this.lblIndex.TabIndex = 2;
            this.lblIndex.Text = "0 of 0";
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(12, 104);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(75, 23);
            this.btnPrev.TabIndex = 3;
            this.btnPrev.Text = "Previous";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.OnClickPrevious);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Function Code";
            // 
            // lblReferenceSet
            // 
            this.lblReferenceSet.AutoSize = true;
            this.lblReferenceSet.Location = new System.Drawing.Point(76, 149);
            this.lblReferenceSet.Name = "lblReferenceSet";
            this.lblReferenceSet.Size = new System.Drawing.Size(70, 13);
            this.lblReferenceSet.TabIndex = 5;
            this.lblReferenceSet.Text = "Refrence Set";
            // 
            // btnWriteReference
            // 
            this.btnWriteReference.Location = new System.Drawing.Point(71, 123);
            this.btnWriteReference.Name = "btnWriteReference";
            this.btnWriteReference.Size = new System.Drawing.Size(75, 23);
            this.btnWriteReference.TabIndex = 6;
            this.btnWriteReference.Text = "Write Text";
            this.btnWriteReference.UseVisualStyleBackColor = true;
            this.btnWriteReference.Click += new System.EventHandler(this.OnWriteText);
            // 
            // FunctionView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(217, 171);
            this.Controls.Add(this.btnWriteReference);
            this.Controls.Add(this.lblReferenceSet);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.lblIndex);
            this.Controls.Add(this.cbFunction);
            this.Controls.Add(this.btnNext);
            this.Name = "FunctionView";
            this.Text = "FunctionView";
            this.Shown += new System.EventHandler(this.OnShown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.ComboBox cbFunction;
        private System.Windows.Forms.Label lblIndex;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblReferenceSet;
        private System.Windows.Forms.Button btnWriteReference;
    }
}