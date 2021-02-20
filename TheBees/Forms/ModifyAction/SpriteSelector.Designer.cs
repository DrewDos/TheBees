namespace TheBees.Forms
{
    partial class SpriteSelector
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
            this.cbRangeSelection = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSetValue = new System.Windows.Forms.Button();
            this.chkAutoSet = new System.Windows.Forms.CheckBox();
            this.tbGraphicIndex = new TheBees.BitEdit();
            this.SuspendLayout();
            // 
            // rbByRegion
            // 
            this.rbByRegion.AutoSize = true;
            this.rbByRegion.Location = new System.Drawing.Point(23, 12);
            this.rbByRegion.Name = "rbByRegion";
            this.rbByRegion.Size = new System.Drawing.Size(74, 17);
            this.rbByRegion.TabIndex = 0;
            this.rbByRegion.TabStop = true;
            this.rbByRegion.Text = "By Region";
            this.rbByRegion.UseVisualStyleBackColor = true;
            this.rbByRegion.CheckedChanged += new System.EventHandler(this.OnByRegionCheckedChanged);
            // 
            // rbBySession
            // 
            this.rbBySession.AutoSize = true;
            this.rbBySession.Location = new System.Drawing.Point(103, 12);
            this.rbBySession.Name = "rbBySession";
            this.rbBySession.Size = new System.Drawing.Size(77, 17);
            this.rbBySession.TabIndex = 1;
            this.rbBySession.TabStop = true;
            this.rbBySession.Text = "By Session";
            this.rbBySession.UseVisualStyleBackColor = true;
            this.rbBySession.CheckedChanged += new System.EventHandler(this.OnBySessionCheckedChanged);
            // 
            // cbRangeSelection
            // 
            this.cbRangeSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRangeSelection.FormattingEnabled = true;
            this.cbRangeSelection.Location = new System.Drawing.Point(23, 35);
            this.cbRangeSelection.Name = "cbRangeSelection";
            this.cbRangeSelection.Size = new System.Drawing.Size(157, 21);
            this.cbRangeSelection.TabIndex = 2;
            this.cbRangeSelection.SelectionChangeCommitted += new System.EventHandler(this.OnRangeSelectCommitted);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(156, 139);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 21;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnSetValue
            // 
            this.btnSetValue.Location = new System.Drawing.Point(22, 88);
            this.btnSetValue.Name = "btnSetValue";
            this.btnSetValue.Size = new System.Drawing.Size(75, 23);
            this.btnSetValue.TabIndex = 22;
            this.btnSetValue.Text = "Set Value";
            this.btnSetValue.UseVisualStyleBackColor = true;
            this.btnSetValue.Click += new System.EventHandler(this.OnClickSetValue);
            // 
            // chkAutoSet
            // 
            this.chkAutoSet.AutoSize = true;
            this.chkAutoSet.Location = new System.Drawing.Point(22, 139);
            this.chkAutoSet.Name = "chkAutoSet";
            this.chkAutoSet.Size = new System.Drawing.Size(97, 17);
            this.chkAutoSet.TabIndex = 23;
            this.chkAutoSet.Text = "Auto Set Value";
            this.chkAutoSet.UseVisualStyleBackColor = true;
            this.chkAutoSet.CheckedChanged += new System.EventHandler(this.OnAutoSetCheckedChanged);
            // 
            // tbGraphicIndex
            // 
            this.tbGraphicIndex.Location = new System.Drawing.Point(23, 62);
            this.tbGraphicIndex.MaxLength = 16;
            this.tbGraphicIndex.MaxValue = ((uint)(0u));
            this.tbGraphicIndex.MinValue = ((uint)(0u));
            this.tbGraphicIndex.Name = "tbGraphicIndex";
            this.tbGraphicIndex.Size = new System.Drawing.Size(70, 20);
            this.tbGraphicIndex.TabIndex = 20;
            this.tbGraphicIndex.Tag = "gfx1";
            this.tbGraphicIndex.Text = "0";
            this.tbGraphicIndex.Value = ((uint)(0u));
            // 
            // SpriteSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 174);
            this.Controls.Add(this.chkAutoSet);
            this.Controls.Add(this.btnSetValue);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbGraphicIndex);
            this.Controls.Add(this.cbRangeSelection);
            this.Controls.Add(this.rbBySession);
            this.Controls.Add(this.rbByRegion);
            this.Name = "SpriteSelector";
            this.Text = "SpriteSelector";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbByRegion;
        private System.Windows.Forms.RadioButton rbBySession;
        private System.Windows.Forms.ComboBox cbRangeSelection;
        private BitEdit tbGraphicIndex;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSetValue;
        private System.Windows.Forms.CheckBox chkAutoSet;
    }
}