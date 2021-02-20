namespace TheBees.Forms
{
    partial class AboutForm
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
            this.lblApplicationName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblGithub = new System.Windows.Forms.Label();
            this.llWebsite = new System.Windows.Forms.LinkLabel();
            this.llGithub = new System.Windows.Forms.LinkLabel();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblDetails = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.tbContributors = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblApplicationName
            // 
            this.lblApplicationName.AutoSize = true;
            this.lblApplicationName.Location = new System.Drawing.Point(12, 9);
            this.lblApplicationName.Name = "lblApplicationName";
            this.lblApplicationName.Size = new System.Drawing.Size(50, 13);
            this.lblApplicationName.TabIndex = 21;
            this.lblApplicationName.Text = "TheBees";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Website:";
            // 
            // lblGithub
            // 
            this.lblGithub.AutoSize = true;
            this.lblGithub.Location = new System.Drawing.Point(12, 66);
            this.lblGithub.Name = "lblGithub";
            this.lblGithub.Size = new System.Drawing.Size(43, 13);
            this.lblGithub.TabIndex = 18;
            this.lblGithub.Text = "GitHub:";
            // 
            // llWebsite
            // 
            this.llWebsite.AutoSize = true;
            this.llWebsite.Location = new System.Drawing.Point(67, 79);
            this.llWebsite.Name = "llWebsite";
            this.llWebsite.Size = new System.Drawing.Size(58, 13);
            this.llWebsite.TabIndex = 17;
            this.llWebsite.TabStop = true;
            this.llWebsite.Text = "drewdos.io";
            // 
            // llGithub
            // 
            this.llGithub.AutoSize = true;
            this.llGithub.Location = new System.Drawing.Point(67, 66);
            this.llGithub.Name = "llGithub";
            this.llGithub.Size = new System.Drawing.Size(108, 13);
            this.llGithub.TabIndex = 16;
            this.llGithub.TabStop = true;
            this.llGithub.Text = "github.com/DrewDos";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(12, 23);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(72, 13);
            this.lblVersion.TabIndex = 15;
            this.lblVersion.Text = "Version 0.003";
            // 
            // lblDetails
            // 
            this.lblDetails.AutoSize = true;
            this.lblDetails.Location = new System.Drawing.Point(12, 37);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size(105, 13);
            this.lblDetails.TabIndex = 14;
            this.lblDetails.Text = "Created by DrewDos";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(155, 139);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 13;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // tbContributors
            // 
            this.tbContributors.BackColor = System.Drawing.SystemColors.Control;
            this.tbContributors.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbContributors.Location = new System.Drawing.Point(12, 110);
            this.tbContributors.Multiline = true;
            this.tbContributors.Name = "tbContributors";
            this.tbContributors.ReadOnly = true;
            this.tbContributors.Size = new System.Drawing.Size(218, 23);
            this.tbContributors.TabIndex = 20;
            this.tbContributors.Text = "The group that created the sterling file for 3S";
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 169);
            this.Controls.Add(this.lblApplicationName);
            this.Controls.Add(this.tbContributors);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblGithub);
            this.Controls.Add(this.llWebsite);
            this.Controls.Add(this.llGithub);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblDetails);
            this.Controls.Add(this.btnOK);
            this.Name = "AboutForm";
            this.Text = "AboutForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblApplicationName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblGithub;
        private System.Windows.Forms.LinkLabel llWebsite;
        private System.Windows.Forms.LinkLabel llGithub;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblDetails;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox tbContributors;
    }
}