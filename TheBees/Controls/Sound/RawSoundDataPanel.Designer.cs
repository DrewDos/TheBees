namespace TheBees.Controls
{
    partial class RawSoundDataPanel
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
        private void InitializeComponent()
        {
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnReplace = new System.Windows.Forms.Button();
            this.btnDump = new System.Windows.Forms.Button();
            this.rawSoundToolset = new TheBees.Controls.RawSoundToolset();
            this.label5 = new System.Windows.Forms.Label();
            this.tbRawSoundIndex = new TheBees.BitEdit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnReplace);
            this.groupBox3.Controls.Add(this.btnDump);
            this.groupBox3.Controls.Add(this.rawSoundToolset);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.tbRawSoundIndex);
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(352, 98);
            this.groupBox3.TabIndex = 36;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Raw Sound Select";
            // 
            // btnReplace
            // 
            this.btnReplace.Location = new System.Drawing.Point(227, 48);
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.Size = new System.Drawing.Size(70, 23);
            this.btnReplace.TabIndex = 39;
            this.btnReplace.Text = "Replace";
            this.btnReplace.UseVisualStyleBackColor = true;
            this.btnReplace.Click += new System.EventHandler(this.OnClickReplace);
            // 
            // btnDump
            // 
            this.btnDump.Location = new System.Drawing.Point(156, 48);
            this.btnDump.Name = "btnDump";
            this.btnDump.Size = new System.Drawing.Size(65, 23);
            this.btnDump.TabIndex = 38;
            this.btnDump.Text = "Dump";
            this.btnDump.UseVisualStyleBackColor = true;
            this.btnDump.Click += new System.EventHandler(this.OnClickDump);
            // 
            // rawSoundToolset
            // 
            this.rawSoundToolset.Location = new System.Drawing.Point(93, 48);
            this.rawSoundToolset.Name = "rawSoundToolset";
            this.rawSoundToolset.Size = new System.Drawing.Size(57, 30);
            this.rawSoundToolset.TabIndex = 37;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "Sound Index";
            // 
            // tbRawSoundIndex
            // 
            this.tbRawSoundIndex.Location = new System.Drawing.Point(20, 51);
            this.tbRawSoundIndex.MaxLength = 16;
            this.tbRawSoundIndex.MaxValue = ((uint)(0u));
            this.tbRawSoundIndex.MinValue = ((uint)(0u));
            this.tbRawSoundIndex.Name = "tbRawSoundIndex";
            this.tbRawSoundIndex.Size = new System.Drawing.Size(64, 20);
            this.tbRawSoundIndex.TabIndex = 32;
            this.tbRawSoundIndex.Tag = "2";
            this.tbRawSoundIndex.Text = "0";
            this.tbRawSoundIndex.Value = ((uint)(0u));
            // 
            // RawSoundDataPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Name = "RawSoundDataPanel";
            this.Size = new System.Drawing.Size(362, 104);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnReplace;
        private System.Windows.Forms.Button btnDump;
        private RawSoundToolset rawSoundToolset;
        private System.Windows.Forms.Label label5;
        private BitEdit tbRawSoundIndex;
    }
}
