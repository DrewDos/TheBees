namespace TheBees.Forms
{
    partial class SoundEffectManager
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
            this.gbOption = new System.Windows.Forms.GroupBox();
            this.rbRawDataGuide = new System.Windows.Forms.RadioButton();
            this.rbRawData = new System.Windows.Forms.RadioButton();
            this.rbSoundEffect = new System.Windows.Forms.RadioButton();
            this.btnCheckSox = new System.Windows.Forms.Button();
            this.btnRemoveSound = new System.Windows.Forms.Button();
            this.rawSoundGuidePanel1 = new TheBees.Controls.RawSoundGuidePanel();
            this.rawSoundDataPanel1 = new TheBees.Controls.RawSoundDataPanel();
            this.soundEffectPanel1 = new TheBees.Controls.SoundEffectPanel();
            this.btnPing = new System.Windows.Forms.Button();
            this.gbOption.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbOption
            // 
            this.gbOption.Controls.Add(this.rbRawDataGuide);
            this.gbOption.Controls.Add(this.rbRawData);
            this.gbOption.Controls.Add(this.rbSoundEffect);
            this.gbOption.Location = new System.Drawing.Point(12, 12);
            this.gbOption.Name = "gbOption";
            this.gbOption.Size = new System.Drawing.Size(352, 50);
            this.gbOption.TabIndex = 2;
            this.gbOption.TabStop = false;
            this.gbOption.Text = "Option";
            // 
            // rbRawDataGuide
            // 
            this.rbRawDataGuide.AutoSize = true;
            this.rbRawDataGuide.Location = new System.Drawing.Point(134, 19);
            this.rbRawDataGuide.Name = "rbRawDataGuide";
            this.rbRawDataGuide.Size = new System.Drawing.Size(104, 17);
            this.rbRawDataGuide.TabIndex = 2;
            this.rbRawDataGuide.TabStop = true;
            this.rbRawDataGuide.Text = "Raw Data Guide";
            this.rbRawDataGuide.UseVisualStyleBackColor = true;
            this.rbRawDataGuide.CheckedChanged += new System.EventHandler(this.RawDataGuideCheckedChanged);
            // 
            // rbRawData
            // 
            this.rbRawData.AutoSize = true;
            this.rbRawData.Location = new System.Drawing.Point(261, 19);
            this.rbRawData.Name = "rbRawData";
            this.rbRawData.Size = new System.Drawing.Size(73, 17);
            this.rbRawData.TabIndex = 1;
            this.rbRawData.TabStop = true;
            this.rbRawData.Text = "Raw Data";
            this.rbRawData.UseVisualStyleBackColor = true;
            this.rbRawData.CheckedChanged += new System.EventHandler(this.RawDataCheckedChanged);
            // 
            // rbSoundEffect
            // 
            this.rbSoundEffect.AutoSize = true;
            this.rbSoundEffect.Location = new System.Drawing.Point(20, 19);
            this.rbSoundEffect.Name = "rbSoundEffect";
            this.rbSoundEffect.Size = new System.Drawing.Size(87, 17);
            this.rbSoundEffect.TabIndex = 0;
            this.rbSoundEffect.TabStop = true;
            this.rbSoundEffect.Text = "Sound Effect";
            this.rbSoundEffect.UseVisualStyleBackColor = true;
            this.rbSoundEffect.CheckedChanged += new System.EventHandler(this.SoundEffectCheckedChanged);
            // 
            // btnCheckSox
            // 
            this.btnCheckSox.Location = new System.Drawing.Point(12, 479);
            this.btnCheckSox.Name = "btnCheckSox";
            this.btnCheckSox.Size = new System.Drawing.Size(75, 23);
            this.btnCheckSox.TabIndex = 6;
            this.btnCheckSox.Text = "Check Sox";
            this.btnCheckSox.UseVisualStyleBackColor = true;
            this.btnCheckSox.Click += new System.EventHandler(this.OnClickCheckSox);
            // 
            // btnRemoveSound
            // 
            this.btnRemoveSound.Location = new System.Drawing.Point(93, 479);
            this.btnRemoveSound.Name = "btnRemoveSound";
            this.btnRemoveSound.Size = new System.Drawing.Size(96, 23);
            this.btnRemoveSound.TabIndex = 7;
            this.btnRemoveSound.Text = "Sound Remove";
            this.btnRemoveSound.UseVisualStyleBackColor = true;
            this.btnRemoveSound.Click += new System.EventHandler(this.OnRemoveSound);
            // 
            // rawSoundGuidePanel1
            // 
            this.rawSoundGuidePanel1.Location = new System.Drawing.Point(12, 68);
            this.rawSoundGuidePanel1.Name = "rawSoundGuidePanel1";
            this.rawSoundGuidePanel1.Size = new System.Drawing.Size(365, 405);
            this.rawSoundGuidePanel1.TabIndex = 4;
            // 
            // rawSoundDataPanel1
            // 
            this.rawSoundDataPanel1.Location = new System.Drawing.Point(12, 68);
            this.rawSoundDataPanel1.Name = "rawSoundDataPanel1";
            this.rawSoundDataPanel1.Size = new System.Drawing.Size(362, 104);
            this.rawSoundDataPanel1.TabIndex = 3;
            // 
            // soundEffectPanel1
            // 
            this.soundEffectPanel1.Location = new System.Drawing.Point(12, 68);
            this.soundEffectPanel1.Name = "soundEffectPanel1";
            this.soundEffectPanel1.Size = new System.Drawing.Size(359, 405);
            this.soundEffectPanel1.TabIndex = 5;
            // 
            // btnPing
            // 
            this.btnPing.Location = new System.Drawing.Point(195, 479);
            this.btnPing.Name = "btnPing";
            this.btnPing.Size = new System.Drawing.Size(96, 23);
            this.btnPing.TabIndex = 8;
            this.btnPing.Text = "Ping Indexes";
            this.btnPing.UseVisualStyleBackColor = true;
            this.btnPing.Click += new System.EventHandler(this.OnPingIndexes);
            // 
            // SoundEffectManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 524);
            this.Controls.Add(this.btnPing);
            this.Controls.Add(this.btnRemoveSound);
            this.Controls.Add(this.btnCheckSox);
            this.Controls.Add(this.rawSoundGuidePanel1);
            this.Controls.Add(this.rawSoundDataPanel1);
            this.Controls.Add(this.gbOption);
            this.Controls.Add(this.soundEffectPanel1);
            this.Name = "SoundEffectManager";
            this.Text = "SoundEffectManager";
            this.gbOption.ResumeLayout(false);
            this.gbOption.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbOption;
        private System.Windows.Forms.RadioButton rbRawDataGuide;
        private System.Windows.Forms.RadioButton rbRawData;
        private System.Windows.Forms.RadioButton rbSoundEffect;
        private Controls.RawSoundDataPanel rawSoundDataPanel1;
        private Controls.RawSoundGuidePanel rawSoundGuidePanel1;
        private Controls.SoundEffectPanel soundEffectPanel1;
        private System.Windows.Forms.Button btnCheckSox;
        private System.Windows.Forms.Button btnRemoveSound;
        private System.Windows.Forms.Button btnPing;
    }
}