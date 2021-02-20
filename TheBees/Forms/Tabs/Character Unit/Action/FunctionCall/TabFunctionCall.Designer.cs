namespace TheBees.Forms
{
    partial class TabFunctionCall
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
            this.fcReference1 = new TheBees.Forms.Tabs.Character_Unit.Action.FunctionCall.FCReference();
            this.gbFunctionDetails = new System.Windows.Forms.GroupBox();
            this.cbFunctionCode = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbFunctionDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // fcReference1
            // 
            this.fcReference1.Location = new System.Drawing.Point(23, 34);
            this.fcReference1.Name = "fcReference1";
            this.fcReference1.Size = new System.Drawing.Size(291, 103);
            this.fcReference1.TabIndex = 3;
            // 
            // gbFunctionDetails
            // 
            this.gbFunctionDetails.Controls.Add(this.fcReference1);
            this.gbFunctionDetails.Location = new System.Drawing.Point(23, 63);
            this.gbFunctionDetails.Name = "gbFunctionDetails";
            this.gbFunctionDetails.Size = new System.Drawing.Size(322, 143);
            this.gbFunctionDetails.TabIndex = 4;
            this.gbFunctionDetails.TabStop = false;
            this.gbFunctionDetails.Text = "Function Details";
            // 
            // cbFunctionCode
            // 
            this.cbFunctionCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFunctionCode.FormattingEnabled = true;
            this.cbFunctionCode.Location = new System.Drawing.Point(130, 24);
            this.cbFunctionCode.Name = "cbFunctionCode";
            this.cbFunctionCode.Size = new System.Drawing.Size(130, 21);
            this.cbFunctionCode.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Function Code";
            // 
            // TabFunctionCall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbFunctionCode);
            this.Controls.Add(this.gbFunctionDetails);
            this.Name = "TabFunctionCall";
            this.Size = new System.Drawing.Size(380, 226);
            this.gbFunctionDetails.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Tabs.Character_Unit.Action.FunctionCall.FCReference fcReference1;
        private System.Windows.Forms.GroupBox gbFunctionDetails;
        private System.Windows.Forms.ComboBox cbFunctionCode;
        private System.Windows.Forms.Label label1;
    }
}
