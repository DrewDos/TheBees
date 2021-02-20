namespace SpriteTest
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.trackBarH = new System.Windows.Forms.TrackBar();
            this.trackBarW = new System.Windows.Forms.TrackBar();
            this.labelH = new System.Windows.Forms.Label();
            this.labelW = new System.Windows.Forms.Label();
            this.trackBarSprIndex = new System.Windows.Forms.TrackBar();
            this.labelSprIndex = new System.Windows.Forms.Label();
            this.spritePanel = new SpriteTest.SpritePanel();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSprIndex)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1094, 566);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Load";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // trackBarH
            // 
            this.trackBarH.Location = new System.Drawing.Point(1015, 332);
            this.trackBarH.Name = "trackBarH";
            this.trackBarH.Size = new System.Drawing.Size(154, 45);
            this.trackBarH.TabIndex = 3;
            this.trackBarH.TickFrequency = 0;
            this.trackBarH.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarH.Scroll += new System.EventHandler(this.trackBarH_Scroll);
            // 
            // trackBarW
            // 
            this.trackBarW.Location = new System.Drawing.Point(1015, 415);
            this.trackBarW.Name = "trackBarW";
            this.trackBarW.Size = new System.Drawing.Size(154, 45);
            this.trackBarW.TabIndex = 4;
            this.trackBarW.TickFrequency = 0;
            this.trackBarW.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarW.Scroll += new System.EventHandler(this.trackBarW_Scroll);
            // 
            // labelH
            // 
            this.labelH.AutoSize = true;
            this.labelH.Enabled = false;
            this.labelH.Location = new System.Drawing.Point(1134, 58);
            this.labelH.Name = "labelH";
            this.labelH.Size = new System.Drawing.Size(35, 13);
            this.labelH.TabIndex = 5;
            this.labelH.Text = "label1";
            // 
            // labelW
            // 
            this.labelW.AutoSize = true;
            this.labelW.Enabled = false;
            this.labelW.Location = new System.Drawing.Point(1024, 399);
            this.labelW.Name = "labelW";
            this.labelW.Size = new System.Drawing.Size(33, 13);
            this.labelW.TabIndex = 6;
            this.labelW.Text = "Index";
            // 
            // trackBarSprIndex
            // 
            this.trackBarSprIndex.Location = new System.Drawing.Point(1015, 501);
            this.trackBarSprIndex.Name = "trackBarSprIndex";
            this.trackBarSprIndex.Size = new System.Drawing.Size(154, 45);
            this.trackBarSprIndex.TabIndex = 7;
            this.trackBarSprIndex.TickFrequency = 0;
            this.trackBarSprIndex.Scroll += new System.EventHandler(this.trackBarSprIndex_Scroll);
            // 
            // labelSprIndex
            // 
            this.labelSprIndex.AutoSize = true;
            this.labelSprIndex.Location = new System.Drawing.Point(1024, 316);
            this.labelSprIndex.Name = "labelSprIndex";
            this.labelSprIndex.Size = new System.Drawing.Size(65, 13);
            this.labelSprIndex.TabIndex = 8;
            this.labelSprIndex.Text = "Pallet Index:";
            this.labelSprIndex.Click += new System.EventHandler(this.labelSprIndex_Click);
            // 
            // spritePanel
            // 
            this.spritePanel.Location = new System.Drawing.Point(12, 12);
            this.spritePanel.Name = "spritePanel";
            this.spritePanel.Size = new System.Drawing.Size(997, 577);
            this.spritePanel.TabIndex = 2;
            this.spritePanel.Text = "spritePanel1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1187, 601);
            this.Controls.Add(this.labelSprIndex);
            this.Controls.Add(this.trackBarSprIndex);
            this.Controls.Add(this.labelW);
            this.Controls.Add(this.labelH);
            this.Controls.Add(this.trackBarW);
            this.Controls.Add(this.trackBarH);
            this.Controls.Add(this.spritePanel);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Sprite Test";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSprIndex)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private SpritePanel spritePanel;
        private System.Windows.Forms.TrackBar trackBarH;
        private System.Windows.Forms.TrackBar trackBarW;
        private System.Windows.Forms.Label labelH;
        private System.Windows.Forms.Label labelW;
        private System.Windows.Forms.TrackBar trackBarSprIndex;
        private System.Windows.Forms.Label labelSprIndex;
    }
}

