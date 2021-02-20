namespace TheBees.Forms
{
    partial class RemoveSprites
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
            this.rbByRegion = new System.Windows.Forms.RadioButton();
            this.rbBySession = new System.Windows.Forms.RadioButton();
            this.rbByRange = new System.Windows.Forms.RadioButton();
            this.gbRange = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbTo = new TheBees.BitEdit();
            this.tbFrom = new TheBees.BitEdit();
            this.button1 = new System.Windows.Forms.Button();
            this.gbRegion = new System.Windows.Forms.GroupBox();
            this.cbRegion = new System.Windows.Forms.ComboBox();
            this.gbSession = new System.Windows.Forms.GroupBox();
            this.cbSession = new System.Windows.Forms.ComboBox();
            this.chkSingleIndex = new System.Windows.Forms.CheckBox();
            this.gbRange.SuspendLayout();
            this.gbRegion.SuspendLayout();
            this.gbSession.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbByRegion
            // 
            this.rbByRegion.AutoSize = true;
            this.rbByRegion.Location = new System.Drawing.Point(12, 141);
            this.rbByRegion.Name = "rbByRegion";
            this.rbByRegion.Size = new System.Drawing.Size(74, 17);
            this.rbByRegion.TabIndex = 0;
            this.rbByRegion.TabStop = true;
            this.rbByRegion.Text = "By Region";
            this.rbByRegion.UseVisualStyleBackColor = true;
            this.rbByRegion.CheckedChanged += new System.EventHandler(this.ByRegionCheckedChanged);
            // 
            // rbBySession
            // 
            this.rbBySession.AutoSize = true;
            this.rbBySession.Location = new System.Drawing.Point(17, 234);
            this.rbBySession.Name = "rbBySession";
            this.rbBySession.Size = new System.Drawing.Size(77, 17);
            this.rbBySession.TabIndex = 1;
            this.rbBySession.TabStop = true;
            this.rbBySession.Text = "By Session";
            this.rbBySession.UseVisualStyleBackColor = true;
            this.rbBySession.CheckedChanged += new System.EventHandler(this.BySessionCheckedChanged);
            // 
            // rbByRange
            // 
            this.rbByRange.AutoSize = true;
            this.rbByRange.Location = new System.Drawing.Point(12, 12);
            this.rbByRange.Name = "rbByRange";
            this.rbByRange.Size = new System.Drawing.Size(72, 17);
            this.rbByRange.TabIndex = 2;
            this.rbByRange.TabStop = true;
            this.rbByRange.Text = "By Range";
            this.rbByRange.UseVisualStyleBackColor = true;
            this.rbByRange.CheckedChanged += new System.EventHandler(this.ByRangeCheckedChanged);
            // 
            // gbRange
            // 
            this.gbRange.Controls.Add(this.label2);
            this.gbRange.Controls.Add(this.label1);
            this.gbRange.Controls.Add(this.tbTo);
            this.gbRange.Controls.Add(this.tbFrom);
            this.gbRange.Location = new System.Drawing.Point(12, 35);
            this.gbRange.Name = "gbRange";
            this.gbRange.Size = new System.Drawing.Size(213, 89);
            this.gbRange.TabIndex = 3;
            this.gbRange.TabStop = false;
            this.gbRange.Text = "Range";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(120, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "From";
            // 
            // tbTo
            // 
            this.tbTo.Location = new System.Drawing.Point(123, 44);
            this.tbTo.MaxLength = 16;
            this.tbTo.MaxValue = ((uint)(0u));
            this.tbTo.MinValue = ((uint)(0u));
            this.tbTo.Name = "tbTo";
            this.tbTo.Size = new System.Drawing.Size(67, 20);
            this.tbTo.TabIndex = 33;
            this.tbTo.Tag = "2";
            this.tbTo.Text = "0";
            this.tbTo.Value = ((uint)(0u));
            // 
            // tbFrom
            // 
            this.tbFrom.Location = new System.Drawing.Point(27, 44);
            this.tbFrom.MaxLength = 16;
            this.tbFrom.MaxValue = ((uint)(0u));
            this.tbFrom.MinValue = ((uint)(0u));
            this.tbFrom.Name = "tbFrom";
            this.tbFrom.Size = new System.Drawing.Size(67, 20);
            this.tbFrom.TabIndex = 32;
            this.tbFrom.Tag = "2";
            this.tbFrom.Text = "0";
            this.tbFrom.Value = ((uint)(0u));
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(150, 333);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Remove";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OnClickRemove);
            // 
            // gbRegion
            // 
            this.gbRegion.Controls.Add(this.cbRegion);
            this.gbRegion.Location = new System.Drawing.Point(12, 164);
            this.gbRegion.Name = "gbRegion";
            this.gbRegion.Size = new System.Drawing.Size(218, 54);
            this.gbRegion.TabIndex = 4;
            this.gbRegion.TabStop = false;
            this.gbRegion.Text = "Region";
            // 
            // cbRegion
            // 
            this.cbRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRegion.FormattingEnabled = true;
            this.cbRegion.Location = new System.Drawing.Point(10, 19);
            this.cbRegion.Name = "cbRegion";
            this.cbRegion.Size = new System.Drawing.Size(197, 21);
            this.cbRegion.TabIndex = 0;
            this.cbRegion.SelectedIndexChanged += new System.EventHandler(this.OnSelectRegion);
            // 
            // gbSession
            // 
            this.gbSession.Controls.Add(this.cbSession);
            this.gbSession.Location = new System.Drawing.Point(12, 253);
            this.gbSession.Name = "gbSession";
            this.gbSession.Size = new System.Drawing.Size(218, 51);
            this.gbSession.TabIndex = 5;
            this.gbSession.TabStop = false;
            this.gbSession.Text = "Session";
            // 
            // cbSession
            // 
            this.cbSession.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSession.FormattingEnabled = true;
            this.cbSession.Location = new System.Drawing.Point(10, 19);
            this.cbSession.Name = "cbSession";
            this.cbSession.Size = new System.Drawing.Size(197, 21);
            this.cbSession.TabIndex = 1;
            this.cbSession.SelectedIndexChanged += new System.EventHandler(this.OnSelectSession);
            // 
            // chkSingleIndex
            // 
            this.chkSingleIndex.AutoSize = true;
            this.chkSingleIndex.Location = new System.Drawing.Point(101, 12);
            this.chkSingleIndex.Name = "chkSingleIndex";
            this.chkSingleIndex.Size = new System.Drawing.Size(84, 17);
            this.chkSingleIndex.TabIndex = 0;
            this.chkSingleIndex.Text = "Single Index";
            this.chkSingleIndex.UseVisualStyleBackColor = true;
            this.chkSingleIndex.CheckedChanged += new System.EventHandler(this.SingleIndexCheckedChanged);
            // 
            // RemoveSprites
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(247, 373);
            this.Controls.Add(this.chkSingleIndex);
            this.Controls.Add(this.gbSession);
            this.Controls.Add(this.gbRegion);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gbRange);
            this.Controls.Add(this.rbByRange);
            this.Controls.Add(this.rbBySession);
            this.Controls.Add(this.rbByRegion);
            this.Name = "RemoveSprites";
            this.Text = "RemoveSprites";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.gbRange.ResumeLayout(false);
            this.gbRange.PerformLayout();
            this.gbRegion.ResumeLayout(false);
            this.gbSession.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbByRegion;
        private System.Windows.Forms.RadioButton rbBySession;
        private System.Windows.Forms.RadioButton rbByRange;
        private System.Windows.Forms.GroupBox gbRange;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox gbRegion;
        private System.Windows.Forms.GroupBox gbSession;
        private System.Windows.Forms.CheckBox chkSingleIndex;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private BitEdit tbTo;
        private BitEdit tbFrom;
        private System.Windows.Forms.ComboBox cbRegion;
        private System.Windows.Forms.ComboBox cbSession;
    }
}