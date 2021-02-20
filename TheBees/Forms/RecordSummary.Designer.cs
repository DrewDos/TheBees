namespace TheBees.Forms
{
    partial class RecordSummary
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
            this.tbRecordSummary = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbRecordSummary
            // 
            this.tbRecordSummary.BackColor = System.Drawing.SystemColors.Control;
            this.tbRecordSummary.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbRecordSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbRecordSummary.Location = new System.Drawing.Point(0, 0);
            this.tbRecordSummary.Margin = new System.Windows.Forms.Padding(13);
            this.tbRecordSummary.Multiline = true;
            this.tbRecordSummary.Name = "tbRecordSummary";
            this.tbRecordSummary.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbRecordSummary.Size = new System.Drawing.Size(284, 575);
            this.tbRecordSummary.TabIndex = 0;
            this.tbRecordSummary.TabStop = false;
            // 
            // RecordSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 575);
            this.Controls.Add(this.tbRecordSummary);
            this.Name = "RecordSummary";
            this.Text = "RecordSummary";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbRecordSummary;
    }
}