namespace TheBees.Forms
{
    partial class TabSAEffect
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
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label38 = new System.Windows.Forms.Label();
            this.tbSuperArtNum = new TheBees.BitEdit();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.tbMaxSA1 = new TheBees.BitEdit();
            this.tbMaxSA2 = new TheBees.BitEdit();
            this.tbDecreaseSpeed = new TheBees.BitEdit();
            this.label36 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.tbGaugeCount = new TheBees.BitEdit();
            this.tbVolume = new TheBees.BitEdit();
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbAirSA = new TheBees.BitEdit();
            this.rbNormal = new System.Windows.Forms.RadioButton();
            this.rbUsesGuage = new System.Windows.Forms.RadioButton();
            this.rbActivateOnDeath = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.tableLayoutPanel.Controls.Add(this.label38, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.label31, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.label32, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.label1, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.label33, 0, 4);
            this.tableLayoutPanel.Controls.Add(this.tbSuperArtNum, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.tbMaxSA1, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.tbMaxSA2, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.tbAirSA, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.label36, 0, 9);
            this.tableLayoutPanel.Controls.Add(this.tbDecreaseSpeed, 1, 9);
            this.tableLayoutPanel.Controls.Add(this.tbGaugeCount, 1, 8);
            this.tableLayoutPanel.Controls.Add(this.label35, 0, 8);
            this.tableLayoutPanel.Controls.Add(this.tbVolume, 1, 7);
            this.tableLayoutPanel.Controls.Add(this.label34, 0, 7);
            this.tableLayoutPanel.Controls.Add(this.rbNormal, 1, 4);
            this.tableLayoutPanel.Controls.Add(this.rbUsesGuage, 1, 5);
            this.tableLayoutPanel.Controls.Add(this.rbActivateOnDeath, 1, 6);
            this.tableLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 12;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(253, 340);
            this.tableLayoutPanel.TabIndex = 2;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(3, 8);
            this.label38.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(61, 13);
            this.label38.TabIndex = 1;
            this.label38.Text = "Super Art #";
            // 
            // tbSuperArtNum
            // 
            this.tbSuperArtNum.Location = new System.Drawing.Point(128, 3);
            this.tbSuperArtNum.MaxLength = 16;
            this.tbSuperArtNum.MaxValue = ((uint)(0u));
            this.tbSuperArtNum.MinValue = ((uint)(0u));
            this.tbSuperArtNum.Name = "tbSuperArtNum";
            this.tbSuperArtNum.Size = new System.Drawing.Size(70, 20);
            this.tbSuperArtNum.TabIndex = 0;
            this.tbSuperArtNum.Text = "0";
            this.tbSuperArtNum.Value = ((uint)(0u));
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(3, 34);
            this.label31.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(50, 13);
            this.label31.TabIndex = 3;
            this.label31.Text = "Max SA1";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(3, 60);
            this.label32.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(50, 13);
            this.label32.TabIndex = 4;
            this.label32.Text = "Max SA2";
            // 
            // tbMaxSA1
            // 
            this.tbMaxSA1.Location = new System.Drawing.Point(128, 29);
            this.tbMaxSA1.MaxLength = 16;
            this.tbMaxSA1.MaxValue = ((uint)(0u));
            this.tbMaxSA1.MinValue = ((uint)(0u));
            this.tbMaxSA1.Name = "tbMaxSA1";
            this.tbMaxSA1.Size = new System.Drawing.Size(70, 20);
            this.tbMaxSA1.TabIndex = 18;
            this.tbMaxSA1.Text = "0";
            this.tbMaxSA1.Value = ((uint)(0u));
            // 
            // tbMaxSA2
            // 
            this.tbMaxSA2.Location = new System.Drawing.Point(128, 55);
            this.tbMaxSA2.MaxLength = 16;
            this.tbMaxSA2.MaxValue = ((uint)(0u));
            this.tbMaxSA2.MinValue = ((uint)(0u));
            this.tbMaxSA2.Name = "tbMaxSA2";
            this.tbMaxSA2.Size = new System.Drawing.Size(70, 20);
            this.tbMaxSA2.TabIndex = 19;
            this.tbMaxSA2.Text = "0";
            this.tbMaxSA2.Value = ((uint)(0u));
            // 
            // tbDecreaseSpeed
            // 
            this.tbDecreaseSpeed.Location = new System.Drawing.Point(128, 237);
            this.tbDecreaseSpeed.MaxLength = 16;
            this.tbDecreaseSpeed.MaxValue = ((uint)(0u));
            this.tbDecreaseSpeed.MinValue = ((uint)(0u));
            this.tbDecreaseSpeed.Name = "tbDecreaseSpeed";
            this.tbDecreaseSpeed.Size = new System.Drawing.Size(70, 20);
            this.tbDecreaseSpeed.TabIndex = 23;
            this.tbDecreaseSpeed.Text = "0";
            this.tbDecreaseSpeed.Value = ((uint)(0u));
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(3, 242);
            this.label36.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(87, 13);
            this.label36.TabIndex = 8;
            this.label36.Text = "Decrease Speed";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(3, 216);
            this.label35.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(70, 13);
            this.label35.TabIndex = 7;
            this.label35.Text = "Gauge Count";
            // 
            // tbGaugeCount
            // 
            this.tbGaugeCount.Location = new System.Drawing.Point(128, 211);
            this.tbGaugeCount.MaxLength = 16;
            this.tbGaugeCount.MaxValue = ((uint)(0u));
            this.tbGaugeCount.MinValue = ((uint)(0u));
            this.tbGaugeCount.Name = "tbGaugeCount";
            this.tbGaugeCount.Size = new System.Drawing.Size(70, 20);
            this.tbGaugeCount.TabIndex = 22;
            this.tbGaugeCount.Text = "0";
            this.tbGaugeCount.Value = ((uint)(0u));
            // 
            // tbVolume
            // 
            this.tbVolume.Location = new System.Drawing.Point(128, 185);
            this.tbVolume.MaxLength = 16;
            this.tbVolume.MaxValue = ((uint)(0u));
            this.tbVolume.MinValue = ((uint)(0u));
            this.tbVolume.Name = "tbVolume";
            this.tbVolume.Size = new System.Drawing.Size(70, 20);
            this.tbVolume.TabIndex = 21;
            this.tbVolume.Text = "0";
            this.tbVolume.Value = ((uint)(0u));
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(3, 190);
            this.label34.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(42, 13);
            this.label34.TabIndex = 6;
            this.label34.Text = "Volume";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(3, 112);
            this.label33.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(32, 13);
            this.label33.TabIndex = 5;
            this.label33.Text = "Flags";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 86);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Air SA";
            // 
            // tbAirSA
            // 
            this.tbAirSA.Location = new System.Drawing.Point(128, 81);
            this.tbAirSA.MaxLength = 16;
            this.tbAirSA.MaxValue = ((uint)(0u));
            this.tbAirSA.MinValue = ((uint)(0u));
            this.tbAirSA.Name = "tbAirSA";
            this.tbAirSA.Size = new System.Drawing.Size(70, 20);
            this.tbAirSA.TabIndex = 20;
            this.tbAirSA.Text = "0";
            this.tbAirSA.Value = ((uint)(0u));
            // 
            // rbNormal
            // 
            this.rbNormal.AutoSize = true;
            this.rbNormal.Location = new System.Drawing.Point(128, 107);
            this.rbNormal.Name = "rbNormal";
            this.rbNormal.Size = new System.Drawing.Size(108, 17);
            this.rbNormal.TabIndex = 24;
            this.rbNormal.TabStop = true;
            this.rbNormal.Text = "Normal Activation";
            this.rbNormal.UseVisualStyleBackColor = true;
            // 
            // rbUsesGuage
            // 
            this.rbUsesGuage.AutoSize = true;
            this.rbUsesGuage.Location = new System.Drawing.Point(128, 133);
            this.rbUsesGuage.Name = "rbUsesGuage";
            this.rbUsesGuage.Size = new System.Drawing.Size(121, 17);
            this.rbUsesGuage.TabIndex = 25;
            this.rbUsesGuage.TabStop = true;
            this.rbUsesGuage.Text = "Gauge Consumption";
            this.rbUsesGuage.UseVisualStyleBackColor = true;
            // 
            // rbActivateOnDeath
            // 
            this.rbActivateOnDeath.AutoSize = true;
            this.rbActivateOnDeath.Location = new System.Drawing.Point(128, 159);
            this.rbActivateOnDeath.Name = "rbActivateOnDeath";
            this.rbActivateOnDeath.Size = new System.Drawing.Size(113, 17);
            this.rbActivateOnDeath.TabIndex = 26;
            this.rbActivateOnDeath.TabStop = true;
            this.rbActivateOnDeath.Text = "Activate On Death";
            this.rbActivateOnDeath.UseVisualStyleBackColor = true;
            // 
            // TabSAEffect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "TabSAEffect";
            this.Size = new System.Drawing.Size(264, 366);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label label38;
        private BitEdit tbSuperArtNum;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label36;
        private BitEdit tbMaxSA1;
        private BitEdit tbMaxSA2;
        private BitEdit tbVolume;
        private BitEdit tbGaugeCount;
        private BitEdit tbDecreaseSpeed;
        private System.Windows.Forms.Label label1;
        private BitEdit tbAirSA;
        private System.Windows.Forms.RadioButton rbNormal;
        private System.Windows.Forms.RadioButton rbUsesGuage;
        private System.Windows.Forms.RadioButton rbActivateOnDeath;
    }
}
