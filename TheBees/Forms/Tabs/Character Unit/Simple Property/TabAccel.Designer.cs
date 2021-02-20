namespace TheBees.Forms
{
    partial class TabAccel : PropertyLayout
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabel = new System.Windows.Forms.TableLayoutPanel();
            this.tbXMuzzleVelocity = new TheBees.BitEdit();
            this.tbXAcceleration = new TheBees.BitEdit();
            this.tbYAcceleration = new TheBees.BitEdit();
            this.tbYMuzzleVelocity = new TheBees.BitEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.cbAccelIndex = new System.Windows.Forms.ComboBox();
            this.optionsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemCopyNode = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNewNode = new System.Windows.Forms.ToolStripMenuItem();
            this.tools = new TheBees.Controls.PropertyToolset();
            this.tabel.SuspendLayout();
            this.optionsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 25);
            this.label1.TabIndex = 19;
            this.label1.Text = "x Muzzle Velocity";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "x Accel";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 25);
            this.label3.TabIndex = 21;
            this.label3.Text = "y Muzzle Velocity";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "y Accel";
            // 
            // tabel
            // 
            this.tabel.ColumnCount = 4;
            this.tabel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 91F));
            this.tabel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 91F));
            this.tabel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 91F));
            this.tabel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 297F));
            this.tabel.Controls.Add(this.label2, 0, 1);
            this.tabel.Controls.Add(this.tbXMuzzleVelocity, 1, 0);
            this.tabel.Controls.Add(this.tbXAcceleration, 1, 1);
            this.tabel.Controls.Add(this.label1, 0, 0);
            this.tabel.Controls.Add(this.label3, 0, 4);
            this.tabel.Controls.Add(this.label4, 0, 3);
            this.tabel.Controls.Add(this.tbYAcceleration, 1, 4);
            this.tabel.Controls.Add(this.tbYMuzzleVelocity, 1, 3);
            this.tabel.Location = new System.Drawing.Point(9, 78);
            this.tabel.Name = "tabel";
            this.tabel.RowCount = 12;
            this.tabel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tabel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tabel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tabel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tabel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tabel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tabel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tabel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tabel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tabel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tabel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tabel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tabel.Size = new System.Drawing.Size(182, 152);
            this.tabel.TabIndex = 2;
            // 
            // tbXMuzzleVelocity
            // 
            this.tbXMuzzleVelocity.Location = new System.Drawing.Point(94, 3);
            this.tbXMuzzleVelocity.MaxLength = 16;
            this.tbXMuzzleVelocity.MaxValue = ((uint)(0u));
            this.tbXMuzzleVelocity.MinValue = ((uint)(0u));
            this.tbXMuzzleVelocity.Name = "tbXMuzzleVelocity";
            this.tbXMuzzleVelocity.Size = new System.Drawing.Size(85, 20);
            this.tbXMuzzleVelocity.TabIndex = 8;
            this.tbXMuzzleVelocity.Text = "0";
            this.tbXMuzzleVelocity.Value = ((uint)(0u));
            // 
            // tbXAcceleration
            // 
            this.tbXAcceleration.Location = new System.Drawing.Point(94, 28);
            this.tbXAcceleration.MaxLength = 16;
            this.tbXAcceleration.MaxValue = ((uint)(0u));
            this.tbXAcceleration.MinValue = ((uint)(0u));
            this.tbXAcceleration.Name = "tbXAcceleration";
            this.tbXAcceleration.Size = new System.Drawing.Size(85, 20);
            this.tbXAcceleration.TabIndex = 9;
            this.tbXAcceleration.Text = "0";
            this.tbXAcceleration.Value = ((uint)(0u));
            // 
            // tbYAcceleration
            // 
            this.tbYAcceleration.Location = new System.Drawing.Point(94, 103);
            this.tbYAcceleration.MaxLength = 16;
            this.tbYAcceleration.MaxValue = ((uint)(0u));
            this.tbYAcceleration.MinValue = ((uint)(0u));
            this.tbYAcceleration.Name = "tbYAcceleration";
            this.tbYAcceleration.Size = new System.Drawing.Size(85, 20);
            this.tbYAcceleration.TabIndex = 11;
            this.tbYAcceleration.Text = "0";
            this.tbYAcceleration.Value = ((uint)(0u));
            // 
            // tbYMuzzleVelocity
            // 
            this.tbYMuzzleVelocity.Location = new System.Drawing.Point(94, 78);
            this.tbYMuzzleVelocity.MaxLength = 16;
            this.tbYMuzzleVelocity.MaxValue = ((uint)(0u));
            this.tbYMuzzleVelocity.MinValue = ((uint)(0u));
            this.tbYMuzzleVelocity.Name = "tbYMuzzleVelocity";
            this.tbYMuzzleVelocity.Size = new System.Drawing.Size(85, 20);
            this.tbYMuzzleVelocity.TabIndex = 10;
            this.tbYMuzzleVelocity.Text = "0";
            this.tbYMuzzleVelocity.Value = ((uint)(0u));
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Acceleration Index";
            // 
            // cbAccelIndex
            // 
            this.cbAccelIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAccelIndex.FormattingEnabled = true;
            this.cbAccelIndex.Location = new System.Drawing.Point(117, 17);
            this.cbAccelIndex.Name = "cbAccelIndex";
            this.cbAccelIndex.Size = new System.Drawing.Size(74, 21);
            this.cbAccelIndex.TabIndex = 4;
            // 
            // optionsMenu
            // 
            this.optionsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemCopyNode,
            this.menuItemNewNode});
            this.optionsMenu.Name = "optionsMenu";
            this.optionsMenu.Size = new System.Drawing.Size(178, 48);
            // 
            // menuItemCopyNode
            // 
            this.menuItemCopyNode.Name = "menuItemCopyNode";
            this.menuItemCopyNode.Size = new System.Drawing.Size(177, 22);
            this.menuItemCopyNode.Text = "Copy As New Node";
            // 
            // menuItemNewNode
            // 
            this.menuItemNewNode.Name = "menuItemNewNode";
            this.menuItemNewNode.Size = new System.Drawing.Size(177, 22);
            this.menuItemNewNode.Text = "Add Empty Node";
            // 
            // tools
            // 
            this.tools.Location = new System.Drawing.Point(115, 41);
            this.tools.Name = "tools";
            this.tools.Size = new System.Drawing.Size(77, 31);
            this.tools.TabIndex = 5;
            // 
            // TabAccel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tools);
            this.Controls.Add(this.cbAccelIndex);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tabel);
            this.Name = "TabAccel";
            this.Size = new System.Drawing.Size(198, 303);
            this.tabel.ResumeLayout(false);
            this.tabel.PerformLayout();
            this.optionsMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TableLayoutPanel tabel;
        private BitEdit tbXMuzzleVelocity;
        private BitEdit tbXAcceleration;
        private BitEdit tbYMuzzleVelocity;
        private BitEdit tbYAcceleration;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbAccelIndex;
        private System.Windows.Forms.ContextMenuStrip optionsMenu;
        private System.Windows.Forms.ToolStripMenuItem menuItemCopyNode;
        private System.Windows.Forms.ToolStripMenuItem menuItemNewNode;
        private Controls.PropertyToolset tools;



    }
}
