namespace TheBees.Forms
{
    partial class FunctionCallPanel
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
            this.cbFunctionCode = new System.Windows.Forms.ComboBox();
            this.gbFunctionDetails = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.gbFunctionDetails.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Function Code";
            // 
            // cbFunctionCode
            // 
            this.cbFunctionCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFunctionCode.FormattingEnabled = true;
            this.cbFunctionCode.Location = new System.Drawing.Point(110, 1);
            this.cbFunctionCode.Name = "cbFunctionCode";
            this.cbFunctionCode.Size = new System.Drawing.Size(314, 21);
            this.cbFunctionCode.TabIndex = 6;
            this.cbFunctionCode.SelectionChangeCommitted += new System.EventHandler(this.OnCodeChangeCommitted);
            // 
            // gbFunctionDetails
            // 
            this.gbFunctionDetails.Controls.Add(this.panel1);
            this.gbFunctionDetails.Location = new System.Drawing.Point(17, 42);
            this.gbFunctionDetails.Name = "gbFunctionDetails";
            this.gbFunctionDetails.Size = new System.Drawing.Size(407, 188);
            this.gbFunctionDetails.TabIndex = 9;
            this.gbFunctionDetails.TabStop = false;
            this.gbFunctionDetails.Text = "Function Details";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblStatus);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 158);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(401, 27);
            this.panel1.TabIndex = 0;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatus.Location = new System.Drawing.Point(0, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(35, 13);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "label2";
            // 
            // FunctionCallPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbFunctionDetails);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbFunctionCode);
            this.Name = "FunctionCallPanel";
            this.Size = new System.Drawing.Size(525, 372);
            this.gbFunctionDetails.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbFunctionCode;
        private System.Windows.Forms.GroupBox gbFunctionDetails;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblStatus;
    }
}
