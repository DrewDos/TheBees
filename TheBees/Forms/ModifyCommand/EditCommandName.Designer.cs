namespace TheBees.Forms
{
    partial class EditCommandName
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
            this.tbCommandName = new TheBees.Forms.ActionEditTextbox();
            this.SuspendLayout();
            // 
            // tbCommandName
            // 
            this.tbCommandName.Location = new System.Drawing.Point(12, 12);
            this.tbCommandName.Name = "tbCommandName";
            this.tbCommandName.Size = new System.Drawing.Size(220, 20);
            this.tbCommandName.TabIndex = 0;
            // 
            // EditCommandName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 42);
            this.Controls.Add(this.tbCommandName);
            this.Name = "EditCommandName";
            this.Text = "EditCommandName";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ActionEditTextbox tbCommandName;
    }
}