namespace TheBees.Forms
{
    partial class ModifyOrbitalBasis
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
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.cbUnit = new System.Windows.Forms.ComboBox();
            this.lbOBBase = new System.Windows.Forms.ListBox();
            this.btnSetOrbital = new System.Windows.Forms.Button();
            this.tbSummary = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 6;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanel.Location = new System.Drawing.Point(12, 48);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 9;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(419, 187);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // cbUnit
            // 
            this.cbUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUnit.FormattingEnabled = true;
            this.cbUnit.Location = new System.Drawing.Point(12, 12);
            this.cbUnit.Name = "cbUnit";
            this.cbUnit.Size = new System.Drawing.Size(149, 21);
            this.cbUnit.TabIndex = 1;
            this.cbUnit.SelectionChangeCommitted += new System.EventHandler(this.OnUnitIndexChanged);
            // 
            // lbOBBase
            // 
            this.lbOBBase.FormattingEnabled = true;
            this.lbOBBase.Location = new System.Drawing.Point(456, 48);
            this.lbOBBase.Name = "lbOBBase";
            this.lbOBBase.Size = new System.Drawing.Size(104, 186);
            this.lbOBBase.TabIndex = 2;
            this.lbOBBase.SelectedIndexChanged += new System.EventHandler(this.OnSelectOBChanged);
            // 
            // btnSetOrbital
            // 
            this.btnSetOrbital.Location = new System.Drawing.Point(485, 240);
            this.btnSetOrbital.Name = "btnSetOrbital";
            this.btnSetOrbital.Size = new System.Drawing.Size(75, 23);
            this.btnSetOrbital.TabIndex = 3;
            this.btnSetOrbital.Text = "Set";
            this.btnSetOrbital.UseVisualStyleBackColor = true;
            this.btnSetOrbital.Click += new System.EventHandler(this.OnClickSetOB);
            // 
            // tbSummary
            // 
            this.tbSummary.BackColor = System.Drawing.SystemColors.Control;
            this.tbSummary.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbSummary.Location = new System.Drawing.Point(613, 37);
            this.tbSummary.Multiline = true;
            this.tbSummary.Name = "tbSummary";
            this.tbSummary.ReadOnly = true;
            this.tbSummary.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbSummary.Size = new System.Drawing.Size(168, 184);
            this.tbSummary.TabIndex = 0;
            // 
            // ModifyOrbitalBasis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 285);
            this.Controls.Add(this.tbSummary);
            this.Controls.Add(this.btnSetOrbital);
            this.Controls.Add(this.lbOBBase);
            this.Controls.Add(this.cbUnit);
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "ModifyOrbitalBasis";
            this.Text = "ModifyOrbitalBasis";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.ComboBox cbUnit;
        private System.Windows.Forms.ListBox lbOBBase;
        private System.Windows.Forms.Button btnSetOrbital;
        private System.Windows.Forms.TextBox tbSummary;
    }
}