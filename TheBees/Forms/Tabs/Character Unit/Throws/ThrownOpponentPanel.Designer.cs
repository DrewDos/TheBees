namespace TheBees.Forms
{
    partial class TabThrownOpponent
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
            this.label12 = new System.Windows.Forms.Label();
            this.tbLayerValue = new TheBees.BitEdit();
            this.chkFlipY = new System.Windows.Forms.CheckBox();
            this.chkFlipX = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbXPos = new TheBees.BitEdit();
            this.tbYPos = new TheBees.BitEdit();
            this.SuspendLayout();
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(17, 93);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 13);
            this.label12.TabIndex = 39;
            this.label12.Text = "Layer Value";
            // 
            // tbLayerValue
            // 
            this.tbLayerValue.Location = new System.Drawing.Point(17, 109);
            this.tbLayerValue.MaxLength = 16;
            this.tbLayerValue.MaxValue = ((uint)(0u));
            this.tbLayerValue.Name = "tbLayerValue";
            this.tbLayerValue.Size = new System.Drawing.Size(55, 20);
            this.tbLayerValue.TabIndex = 38;
            this.tbLayerValue.Text = "0";
            this.tbLayerValue.Value = ((uint)(0u));
            // 
            // chkFlipY
            // 
            this.chkFlipY.AutoSize = true;
            this.chkFlipY.Location = new System.Drawing.Point(20, 165);
            this.chkFlipY.Name = "chkFlipY";
            this.chkFlipY.Size = new System.Drawing.Size(52, 17);
            this.chkFlipY.TabIndex = 37;
            this.chkFlipY.Text = "Flip Y";
            this.chkFlipY.UseVisualStyleBackColor = true;
            // 
            // chkFlipX
            // 
            this.chkFlipX.AutoSize = true;
            this.chkFlipX.Location = new System.Drawing.Point(20, 142);
            this.chkFlipX.Name = "chkFlipX";
            this.chkFlipX.Size = new System.Drawing.Size(52, 17);
            this.chkFlipX.TabIndex = 36;
            this.chkFlipX.Text = "Flip X";
            this.chkFlipX.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 55);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 13);
            this.label10.TabIndex = 35;
            this.label10.Text = "Y Position";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "X Position";
            // 
            // tbXPos
            // 
            this.tbXPos.Location = new System.Drawing.Point(15, 30);
            this.tbXPos.MaxLength = 16;
            this.tbXPos.MaxValue = ((uint)(0u));
            this.tbXPos.Name = "tbXPos";
            this.tbXPos.Size = new System.Drawing.Size(57, 20);
            this.tbXPos.TabIndex = 33;
            this.tbXPos.Text = "0";
            this.tbXPos.Value = ((uint)(0u));
            // 
            // tbYPos
            // 
            this.tbYPos.Location = new System.Drawing.Point(17, 71);
            this.tbYPos.MaxLength = 16;
            this.tbYPos.MaxValue = ((uint)(0u));
            this.tbYPos.Name = "tbYPos";
            this.tbYPos.Size = new System.Drawing.Size(54, 20);
            this.tbYPos.TabIndex = 32;
            this.tbYPos.Text = "0";
            this.tbYPos.Value = ((uint)(0u));
            // 
            // TabThrownOpponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label12);
            this.Controls.Add(this.tbLayerValue);
            this.Controls.Add(this.chkFlipY);
            this.Controls.Add(this.chkFlipX);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbXPos);
            this.Controls.Add(this.tbYPos);
            this.Name = "TabThrownOpponent";
            this.Size = new System.Drawing.Size(91, 195);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label12;
        private BitEdit tbLayerValue;
        private System.Windows.Forms.CheckBox chkFlipY;
        private System.Windows.Forms.CheckBox chkFlipX;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label4;
        private BitEdit tbXPos;
        private BitEdit tbYPos;

    }
}
