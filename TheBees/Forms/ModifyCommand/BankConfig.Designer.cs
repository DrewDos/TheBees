namespace TheBees.Forms
{
    partial class BankConfig
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
            this.chkUp = new System.Windows.Forms.CheckBox();
            this.chkDown = new System.Windows.Forms.CheckBox();
            this.chkForward = new System.Windows.Forms.CheckBox();
            this.chkBack = new System.Windows.Forms.CheckBox();
            this.rbUseDirectional = new System.Windows.Forms.RadioButton();
            this.rbUseDistance = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.tbExclusionDistance = new TheBees.BitEdit();
            this.chkLenientDirectionFlag = new System.Windows.Forms.CheckBox();
            this.chkStrictDirectionFlag = new System.Windows.Forms.CheckBox();
            this.chkWhileRising = new System.Windows.Forms.CheckBox();
            this.chkWhileFalling = new System.Windows.Forms.CheckBox();
            this.gbDirection = new System.Windows.Forms.GroupBox();
            this.gbDistance = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.chkNeutral = new System.Windows.Forms.CheckBox();
            this.gbDirection.SuspendLayout();
            this.gbDistance.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkUp
            // 
            this.chkUp.AutoSize = true;
            this.chkUp.Location = new System.Drawing.Point(122, 37);
            this.chkUp.Name = "chkUp";
            this.chkUp.Size = new System.Drawing.Size(40, 17);
            this.chkUp.TabIndex = 7;
            this.chkUp.Text = "Up";
            this.chkUp.UseVisualStyleBackColor = true;
            this.chkUp.CheckedChanged += new System.EventHandler(this.UpCheckedChanged);
            // 
            // chkDown
            // 
            this.chkDown.AutoSize = true;
            this.chkDown.Location = new System.Drawing.Point(122, 60);
            this.chkDown.Name = "chkDown";
            this.chkDown.Size = new System.Drawing.Size(54, 17);
            this.chkDown.TabIndex = 8;
            this.chkDown.Text = "Down";
            this.chkDown.UseVisualStyleBackColor = true;
            // 
            // chkForward
            // 
            this.chkForward.AutoSize = true;
            this.chkForward.Location = new System.Drawing.Point(187, 37);
            this.chkForward.Name = "chkForward";
            this.chkForward.Size = new System.Drawing.Size(64, 17);
            this.chkForward.TabIndex = 9;
            this.chkForward.Text = "Forward";
            this.chkForward.UseVisualStyleBackColor = true;
            // 
            // chkBack
            // 
            this.chkBack.AutoSize = true;
            this.chkBack.Location = new System.Drawing.Point(187, 60);
            this.chkBack.Name = "chkBack";
            this.chkBack.Size = new System.Drawing.Size(51, 17);
            this.chkBack.TabIndex = 10;
            this.chkBack.Text = "Back";
            this.chkBack.UseVisualStyleBackColor = true;
            // 
            // rbUseDirectional
            // 
            this.rbUseDirectional.AutoSize = true;
            this.rbUseDirectional.Location = new System.Drawing.Point(12, 121);
            this.rbUseDirectional.Name = "rbUseDirectional";
            this.rbUseDirectional.Size = new System.Drawing.Size(130, 17);
            this.rbUseDirectional.TabIndex = 11;
            this.rbUseDirectional.Text = "Use Directional Config";
            this.rbUseDirectional.UseVisualStyleBackColor = true;
            this.rbUseDirectional.CheckedChanged += new System.EventHandler(this.OnRBUseDirectionalCheckedChanged);
            // 
            // rbUseDistance
            // 
            this.rbUseDistance.AutoSize = true;
            this.rbUseDistance.Location = new System.Drawing.Point(12, 13);
            this.rbUseDistance.Name = "rbUseDistance";
            this.rbUseDistance.Size = new System.Drawing.Size(137, 17);
            this.rbUseDistance.TabIndex = 12;
            this.rbUseDistance.Text = "Use Distance Exclusion";
            this.rbUseDistance.UseVisualStyleBackColor = true;
            this.rbUseDistance.CheckedChanged += new System.EventHandler(this.OnRBUseDistanceCheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Distance";
            // 
            // tbExclusionDistance
            // 
            this.tbExclusionDistance.Location = new System.Drawing.Point(70, 30);
            this.tbExclusionDistance.MaxLength = 16;
            this.tbExclusionDistance.MaxValue = ((uint)(0u));
            this.tbExclusionDistance.MinValue = ((uint)(0u));
            this.tbExclusionDistance.Name = "tbExclusionDistance";
            this.tbExclusionDistance.Size = new System.Drawing.Size(46, 20);
            this.tbExclusionDistance.TabIndex = 25;
            this.tbExclusionDistance.Tag = "1";
            this.tbExclusionDistance.Text = "0";
            this.tbExclusionDistance.Value = ((uint)(0u));
            // 
            // chkLenientDirectionFlag
            // 
            this.chkLenientDirectionFlag.AutoSize = true;
            this.chkLenientDirectionFlag.Location = new System.Drawing.Point(122, 93);
            this.chkLenientDirectionFlag.Name = "chkLenientDirectionFlag";
            this.chkLenientDirectionFlag.Size = new System.Drawing.Size(129, 17);
            this.chkLenientDirectionFlag.TabIndex = 29;
            this.chkLenientDirectionFlag.Text = "Lenient Direction Flag";
            this.chkLenientDirectionFlag.UseVisualStyleBackColor = true;
            // 
            // chkStrictDirectionFlag
            // 
            this.chkStrictDirectionFlag.AutoSize = true;
            this.chkStrictDirectionFlag.Location = new System.Drawing.Point(122, 116);
            this.chkStrictDirectionFlag.Name = "chkStrictDirectionFlag";
            this.chkStrictDirectionFlag.Size = new System.Drawing.Size(118, 17);
            this.chkStrictDirectionFlag.TabIndex = 30;
            this.chkStrictDirectionFlag.Text = "Strict Direction Flag";
            this.chkStrictDirectionFlag.UseVisualStyleBackColor = true;
            this.chkStrictDirectionFlag.CheckedChanged += new System.EventHandler(this.StrictDirectionCheckedChanged);
            // 
            // chkWhileRising
            // 
            this.chkWhileRising.AutoSize = true;
            this.chkWhileRising.Location = new System.Drawing.Point(21, 93);
            this.chkWhileRising.Name = "chkWhileRising";
            this.chkWhileRising.Size = new System.Drawing.Size(85, 17);
            this.chkWhileRising.TabIndex = 27;
            this.chkWhileRising.Text = "While Rising";
            this.chkWhileRising.UseVisualStyleBackColor = true;
            // 
            // chkWhileFalling
            // 
            this.chkWhileFalling.AutoSize = true;
            this.chkWhileFalling.Location = new System.Drawing.Point(21, 116);
            this.chkWhileFalling.Name = "chkWhileFalling";
            this.chkWhileFalling.Size = new System.Drawing.Size(86, 17);
            this.chkWhileFalling.TabIndex = 28;
            this.chkWhileFalling.Text = "While Falling";
            this.chkWhileFalling.UseVisualStyleBackColor = true;
            // 
            // gbDirection
            // 
            this.gbDirection.Controls.Add(this.chkNeutral);
            this.gbDirection.Controls.Add(this.chkUp);
            this.gbDirection.Controls.Add(this.chkLenientDirectionFlag);
            this.gbDirection.Controls.Add(this.chkDown);
            this.gbDirection.Controls.Add(this.chkStrictDirectionFlag);
            this.gbDirection.Controls.Add(this.chkBack);
            this.gbDirection.Controls.Add(this.chkWhileRising);
            this.gbDirection.Controls.Add(this.chkForward);
            this.gbDirection.Controls.Add(this.chkWhileFalling);
            this.gbDirection.Location = new System.Drawing.Point(12, 148);
            this.gbDirection.Name = "gbDirection";
            this.gbDirection.Size = new System.Drawing.Size(293, 143);
            this.gbDirection.TabIndex = 31;
            this.gbDirection.TabStop = false;
            this.gbDirection.Text = "Direction";
            // 
            // gbDistance
            // 
            this.gbDistance.Controls.Add(this.tbExclusionDistance);
            this.gbDistance.Controls.Add(this.label1);
            this.gbDistance.Location = new System.Drawing.Point(12, 36);
            this.gbDistance.Name = "gbDistance";
            this.gbDistance.Size = new System.Drawing.Size(293, 70);
            this.gbDistance.TabIndex = 32;
            this.gbDistance.TabStop = false;
            this.gbDistance.Text = "Distance";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(239, 341);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 34;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.OnClickCancel);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(158, 341);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 35;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OnClickOK);
            // 
            // chkNeutral
            // 
            this.chkNeutral.AutoSize = true;
            this.chkNeutral.Location = new System.Drawing.Point(21, 37);
            this.chkNeutral.Name = "chkNeutral";
            this.chkNeutral.Size = new System.Drawing.Size(60, 17);
            this.chkNeutral.TabIndex = 31;
            this.chkNeutral.Text = "Neutral";
            this.chkNeutral.UseVisualStyleBackColor = true;
            this.chkNeutral.CheckedChanged += new System.EventHandler(this.NeutralCheckedChanged);
            // 
            // BankConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 376);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.gbDistance);
            this.Controls.Add(this.gbDirection);
            this.Controls.Add(this.rbUseDistance);
            this.Controls.Add(this.rbUseDirectional);
            this.Name = "BankConfig";
            this.Text = "BankConfig";
            this.gbDirection.ResumeLayout(false);
            this.gbDirection.PerformLayout();
            this.gbDistance.ResumeLayout(false);
            this.gbDistance.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkUp;
        private System.Windows.Forms.CheckBox chkDown;
        private System.Windows.Forms.CheckBox chkForward;
        private System.Windows.Forms.CheckBox chkBack;
        private System.Windows.Forms.RadioButton rbUseDirectional;
        private System.Windows.Forms.RadioButton rbUseDistance;
        private System.Windows.Forms.Label label1;
        private BitEdit tbExclusionDistance;
        private System.Windows.Forms.CheckBox chkLenientDirectionFlag;
        private System.Windows.Forms.CheckBox chkStrictDirectionFlag;
        private System.Windows.Forms.CheckBox chkWhileRising;
        private System.Windows.Forms.CheckBox chkWhileFalling;
        private System.Windows.Forms.GroupBox gbDirection;
        private System.Windows.Forms.GroupBox gbDistance;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox chkNeutral;
    }
}