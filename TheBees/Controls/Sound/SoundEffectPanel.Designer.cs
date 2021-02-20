namespace TheBees.Controls
{
    partial class SoundEffectPanel
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.tbSoundIndex = new TheBees.BitEdit();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.soundNodePanel = new TheBees.Forms.SoundNodePanel();
            this.label3 = new System.Windows.Forms.Label();
            this.cbNodeIndex = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbDescription);
            this.groupBox1.Controls.Add(this.tbSoundIndex);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(352, 98);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sound Effect Index";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(90, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "Description";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Sound Index";
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(90, 51);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(244, 20);
            this.tbDescription.TabIndex = 33;
            // 
            // tbSoundIndex
            // 
            this.tbSoundIndex.Location = new System.Drawing.Point(20, 51);
            this.tbSoundIndex.MaxLength = 16;
            this.tbSoundIndex.MaxValue = ((uint)(0u));
            this.tbSoundIndex.MinValue = ((uint)(0u));
            this.tbSoundIndex.Name = "tbSoundIndex";
            this.tbSoundIndex.Size = new System.Drawing.Size(64, 20);
            this.tbSoundIndex.TabIndex = 32;
            this.tbSoundIndex.Tag = "2";
            this.tbSoundIndex.Text = "0";
            this.tbSoundIndex.Value = ((uint)(0u));
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.soundNodePanel);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cbNodeIndex);
            this.groupBox2.Location = new System.Drawing.Point(3, 107);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(352, 296);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sound Effect Details";
            // 
            // soundNodePanel
            // 
            this.soundNodePanel.Location = new System.Drawing.Point(15, 79);
            this.soundNodePanel.Name = "soundNodePanel";
            this.soundNodePanel.Size = new System.Drawing.Size(319, 198);
            this.soundNodePanel.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Node Index";
            // 
            // cbNodeIndex
            // 
            this.cbNodeIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNodeIndex.FormattingEnabled = true;
            this.cbNodeIndex.Location = new System.Drawing.Point(20, 46);
            this.cbNodeIndex.Name = "cbNodeIndex";
            this.cbNodeIndex.Size = new System.Drawing.Size(77, 21);
            this.cbNodeIndex.TabIndex = 0;
            // 
            // SoundEffectPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "SoundEffectPanel";
            this.Size = new System.Drawing.Size(359, 405);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbDescription;
        private BitEdit tbSoundIndex;
        private System.Windows.Forms.GroupBox groupBox2;
        private Forms.SoundNodePanel soundNodePanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbNodeIndex;
    }
}
