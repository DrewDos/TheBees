namespace TheBees.Forms
{
    partial class ModifyUserCommand
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
            this.btnSetCommand = new System.Windows.Forms.Button();
            this.tabCommandHeader = new TheBees.Forms.TabCommandHeader(activeData);
            this.tabCommandLever = new TheBees.Forms.TabCommandLever(activeData);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSetCommand
            // 
            this.btnSetCommand.Location = new System.Drawing.Point(451, 366);
            this.btnSetCommand.Name = "btnSetCommand";
            this.btnSetCommand.Size = new System.Drawing.Size(110, 23);
            this.btnSetCommand.TabIndex = 2;
            this.btnSetCommand.Text = "Select Command";
            this.btnSetCommand.UseVisualStyleBackColor = true;
            this.btnSetCommand.Click += new System.EventHandler(this.OnSetCommand);
            // 
            // tabCommandHeader
            // 
            this.tabCommandHeader.Location = new System.Drawing.Point(16, 19);
            this.tabCommandHeader.Name = "tabCommandHeader";
            this.tabCommandHeader.Size = new System.Drawing.Size(258, 347);
            this.tabCommandHeader.TabIndex = 0;
            // 
            // tabCommandLever
            // 
            this.tabCommandLever.Location = new System.Drawing.Point(15, 19);
            this.tabCommandLever.Name = "tabCommandLever";
            this.tabCommandLever.Size = new System.Drawing.Size(262, 157);
            this.tabCommandLever.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabCommandHeader);
            this.groupBox1.Location = new System.Drawing.Point(40, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(297, 361);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Command Select";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tabCommandLever);
            this.groupBox2.Location = new System.Drawing.Point(356, 139);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(297, 201);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Modify Command";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(567, 366);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.OnCancel);
            // 
            // ModifyUserCommand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 401);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSetCommand);
            this.Name = "ModifyUserCommand";
            this.Text = "ModifyUserCommand";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TabCommandHeader tabCommandHeader;
        private TabCommandLever tabCommandLever;
        private System.Windows.Forms.Button btnSetCommand;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCancel;

    }
}