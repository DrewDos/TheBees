namespace TheBees.Controls
{
    partial class DataToolset
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataToolset));
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.btnExtra = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCopy
            // 
            this.btnCopy.Image = ((System.Drawing.Image)(resources.GetObject("btnCopy.Image")));
            this.btnCopy.Location = new System.Drawing.Point(33, 3);
            this.btnCopy.Margin = new System.Windows.Forms.Padding(0);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(24, 24);
            this.btnCopy.TabIndex = 41;
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.OnBtnCopyClick);
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Image = ((System.Drawing.Image)(resources.GetObject("btnMoveUp.Image")));
            this.btnMoveUp.Location = new System.Drawing.Point(63, 3);
            this.btnMoveUp.Margin = new System.Windows.Forms.Padding(0);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(24, 24);
            this.btnMoveUp.TabIndex = 40;
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.Click += new System.EventHandler(this.OnBtnMoveUpClick);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Image = ((System.Drawing.Image)(resources.GetObject("btnMoveDown.Image")));
            this.btnMoveDown.Location = new System.Drawing.Point(93, 3);
            this.btnMoveDown.Margin = new System.Windows.Forms.Padding(0);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(24, 24);
            this.btnMoveDown.TabIndex = 39;
            this.btnMoveDown.UseVisualStyleBackColor = true;
            this.btnMoveDown.Click += new System.EventHandler(this.OnBtnMoveDownClick);
            // 
            // btnRemove
            // 
            this.btnRemove.Image = ((System.Drawing.Image)(resources.GetObject("btnRemove.Image")));
            this.btnRemove.Location = new System.Drawing.Point(123, 3);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(0);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(24, 24);
            this.btnRemove.TabIndex = 38;
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.OnBtnRemoveClick);
            // 
            // btnNew
            // 
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.Location = new System.Drawing.Point(3, 3);
            this.btnNew.Margin = new System.Windows.Forms.Padding(0);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(24, 24);
            this.btnNew.TabIndex = 37;
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.OnBtnAddClick);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 6;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(190, 31);
            this.tableLayoutPanel.TabIndex = 42;
            // 
            // btnExtra
            // 
            this.btnExtra.Location = new System.Drawing.Point(153, 3);
            this.btnExtra.Margin = new System.Windows.Forms.Padding(0);
            this.btnExtra.Name = "btnExtra";
            this.btnExtra.Size = new System.Drawing.Size(24, 24);
            this.btnExtra.TabIndex = 43;
            this.btnExtra.UseVisualStyleBackColor = true;
            this.btnExtra.Click += new System.EventHandler(this.OnBtnExtraClick);
            // 
            // DataToolset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "DataToolset";
            this.Size = new System.Drawing.Size(189, 31);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Button btnCopy;
        protected System.Windows.Forms.Button btnMoveUp;
        protected System.Windows.Forms.Button btnMoveDown;
        protected System.Windows.Forms.Button btnRemove;
        protected System.Windows.Forms.Button btnNew;
        protected System.Windows.Forms.Button btnExtra;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
    }
}
