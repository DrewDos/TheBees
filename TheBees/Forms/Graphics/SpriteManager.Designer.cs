namespace TheBees.Forms
{
    partial class SpriteManager
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
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.tbSourcePallet = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbTargetRegion = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbLookupTag = new System.Windows.Forms.ComboBox();
            this.btnAddLookup = new System.Windows.Forms.Button();
            this.btnAddRegion = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tbSourceFile = new System.Windows.Forms.TextBox();
            this.btnSelectPallet = new System.Windows.Forms.Button();
            this.tbSourceDirectory = new System.Windows.Forms.TextBox();
            this.btnSelectDir = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cbNewIndexes = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnRemoveIndex = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnAddSessionRef = new System.Windows.Forms.Button();
            this.cbSessionRef = new System.Windows.Forms.ComboBox();
            this.btnLoadUnloadPallet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(286, 386);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(75, 23);
            this.btnSelectFile.TabIndex = 30;
            this.btnSelectFile.Text = "Select";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.OnSelectSourceFile);
            // 
            // tbSourcePallet
            // 
            this.tbSourcePallet.Location = new System.Drawing.Point(31, 305);
            this.tbSourcePallet.Name = "tbSourcePallet";
            this.tbSourcePallet.ReadOnly = true;
            this.tbSourcePallet.Size = new System.Drawing.Size(231, 20);
            this.tbSourcePallet.TabIndex = 29;
            this.tbSourcePallet.TextChanged += new System.EventHandler(this.OnSrcPalletTextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 285);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Source Pallet";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 372);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Source File";
            // 
            // cbTargetRegion
            // 
            this.cbTargetRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTargetRegion.FormattingEnabled = true;
            this.cbTargetRegion.Location = new System.Drawing.Point(31, 132);
            this.cbTargetRegion.Name = "cbTargetRegion";
            this.cbTargetRegion.Size = new System.Drawing.Size(146, 21);
            this.cbTargetRegion.TabIndex = 2;
            this.cbTargetRegion.SelectionChangeCommitted += new System.EventHandler(this.OnTargetRegionChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Target Region";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Lookup Tag";
            // 
            // cbLookupTag
            // 
            this.cbLookupTag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLookupTag.FormattingEnabled = true;
            this.cbLookupTag.Location = new System.Drawing.Point(33, 54);
            this.cbLookupTag.Name = "cbLookupTag";
            this.cbLookupTag.Size = new System.Drawing.Size(144, 21);
            this.cbLookupTag.TabIndex = 5;
            this.cbLookupTag.SelectedIndexChanged += new System.EventHandler(this.OnLookupTagChanged);
            // 
            // btnAddLookup
            // 
            this.btnAddLookup.Location = new System.Drawing.Point(78, 81);
            this.btnAddLookup.Name = "btnAddLookup";
            this.btnAddLookup.Size = new System.Drawing.Size(99, 23);
            this.btnAddLookup.TabIndex = 31;
            this.btnAddLookup.Text = "Add Lookup";
            this.btnAddLookup.UseVisualStyleBackColor = true;
            this.btnAddLookup.Click += new System.EventHandler(this.OnAddLookup);
            // 
            // btnAddRegion
            // 
            this.btnAddRegion.Location = new System.Drawing.Point(78, 159);
            this.btnAddRegion.Name = "btnAddRegion";
            this.btnAddRegion.Size = new System.Drawing.Size(99, 23);
            this.btnAddRegion.TabIndex = 32;
            this.btnAddRegion.Text = "Add Region";
            this.btnAddRegion.UseVisualStyleBackColor = true;
            this.btnAddRegion.Click += new System.EventHandler(this.OnAddRegion);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 421);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "Source Directory";
            // 
            // tbSourceFile
            // 
            this.tbSourceFile.Location = new System.Drawing.Point(31, 388);
            this.tbSourceFile.Name = "tbSourceFile";
            this.tbSourceFile.Size = new System.Drawing.Size(231, 20);
            this.tbSourceFile.TabIndex = 33;
            this.tbSourceFile.TextChanged += new System.EventHandler(this.OnSrcFileTextChanged);
            // 
            // btnSelectPallet
            // 
            this.btnSelectPallet.Location = new System.Drawing.Point(286, 302);
            this.btnSelectPallet.Name = "btnSelectPallet";
            this.btnSelectPallet.Size = new System.Drawing.Size(75, 23);
            this.btnSelectPallet.TabIndex = 34;
            this.btnSelectPallet.Text = "Select";
            this.btnSelectPallet.UseVisualStyleBackColor = true;
            this.btnSelectPallet.Click += new System.EventHandler(this.OnSelectSourcePallet);
            // 
            // tbSourceDirectory
            // 
            this.tbSourceDirectory.Location = new System.Drawing.Point(31, 437);
            this.tbSourceDirectory.Name = "tbSourceDirectory";
            this.tbSourceDirectory.Size = new System.Drawing.Size(231, 20);
            this.tbSourceDirectory.TabIndex = 35;
            this.tbSourceDirectory.TextChanged += new System.EventHandler(this.OnSrcDirTextChanged);
            // 
            // btnSelectDir
            // 
            this.btnSelectDir.Location = new System.Drawing.Point(286, 435);
            this.btnSelectDir.Name = "btnSelectDir";
            this.btnSelectDir.Size = new System.Drawing.Size(75, 23);
            this.btnSelectDir.TabIndex = 36;
            this.btnSelectDir.Text = "Select";
            this.btnSelectDir.UseVisualStyleBackColor = true;
            this.btnSelectDir.Click += new System.EventHandler(this.OnSelectSourceDir);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 193);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 13);
            this.label6.TabIndex = 34;
            this.label6.Text = "Session Reference";
            // 
            // cbNewIndexes
            // 
            this.cbNewIndexes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNewIndexes.FormattingEnabled = true;
            this.cbNewIndexes.Location = new System.Drawing.Point(223, 54);
            this.cbNewIndexes.Name = "cbNewIndexes";
            this.cbNewIndexes.Size = new System.Drawing.Size(121, 21);
            this.cbNewIndexes.TabIndex = 35;
            this.cbNewIndexes.SelectedIndexChanged += new System.EventHandler(this.OnSelectNewIndex);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(220, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 36;
            this.label7.Text = "New Indexes";
            // 
            // btnRemoveIndex
            // 
            this.btnRemoveIndex.Location = new System.Drawing.Point(269, 81);
            this.btnRemoveIndex.Name = "btnRemoveIndex";
            this.btnRemoveIndex.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveIndex.TabIndex = 37;
            this.btnRemoveIndex.Text = "Remove";
            this.btnRemoveIndex.UseVisualStyleBackColor = true;
            this.btnRemoveIndex.Click += new System.EventHandler(this.OnRemoveNewIndex);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(286, 493);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 38;
            this.button1.Text = "Load Sprites";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OnClickLoadSprites);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(269, 132);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 39;
            this.button2.Text = "Debug";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnAddSessionRef
            // 
            this.btnAddSessionRef.Location = new System.Drawing.Point(78, 235);
            this.btnAddSessionRef.Name = "btnAddSessionRef";
            this.btnAddSessionRef.Size = new System.Drawing.Size(99, 23);
            this.btnAddSessionRef.TabIndex = 40;
            this.btnAddSessionRef.Text = "Add Session Ref";
            this.btnAddSessionRef.UseVisualStyleBackColor = true;
            this.btnAddSessionRef.Click += new System.EventHandler(this.OnAddRefClick);
            // 
            // cbSessionRef
            // 
            this.cbSessionRef.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSessionRef.FormattingEnabled = true;
            this.cbSessionRef.Location = new System.Drawing.Point(31, 208);
            this.cbSessionRef.Name = "cbSessionRef";
            this.cbSessionRef.Size = new System.Drawing.Size(146, 21);
            this.cbSessionRef.TabIndex = 41;
            this.cbSessionRef.SelectedIndexChanged += new System.EventHandler(this.OnChangeSessionRef);
            // 
            // btnLoadUnloadPallet
            // 
            this.btnLoadUnloadPallet.Location = new System.Drawing.Point(286, 331);
            this.btnLoadUnloadPallet.Name = "btnLoadUnloadPallet";
            this.btnLoadUnloadPallet.Size = new System.Drawing.Size(75, 23);
            this.btnLoadUnloadPallet.TabIndex = 42;
            this.btnLoadUnloadPallet.Text = "Load";
            this.btnLoadUnloadPallet.UseVisualStyleBackColor = true;
            this.btnLoadUnloadPallet.Click += new System.EventHandler(this.OnClickLoadUnload);
            // 
            // SpriteManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 555);
            this.Controls.Add(this.btnLoadUnloadPallet);
            this.Controls.Add(this.cbSessionRef);
            this.Controls.Add(this.btnAddSessionRef);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnRemoveIndex);
            this.Controls.Add(this.btnSelectDir);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbNewIndexes);
            this.Controls.Add(this.tbSourceDirectory);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnAddRegion);
            this.Controls.Add(this.btnSelectPallet);
            this.Controls.Add(this.btnAddLookup);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbLookupTag);
            this.Controls.Add(this.tbSourceFile);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbTargetRegion);
            this.Controls.Add(this.tbSourcePallet);
            this.Controls.Add(this.btnSelectFile);
            this.Name = "SpriteManager";
            this.Text = "SpriteManager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.Shown += new System.EventHandler(this.OnShown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.TextBox tbSourcePallet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbTargetRegion;
        private System.Windows.Forms.Button btnAddRegion;
        private System.Windows.Forms.Button btnAddLookup;
        private System.Windows.Forms.ComboBox cbLookupTag;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSelectDir;
        private System.Windows.Forms.TextBox tbSourceDirectory;
        private System.Windows.Forms.Button btnSelectPallet;
        private System.Windows.Forms.TextBox tbSourceFile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnRemoveIndex;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbNewIndexes;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnAddSessionRef;
        private System.Windows.Forms.ComboBox cbSessionRef;
        private System.Windows.Forms.Button btnLoadUnloadPallet;
    }
}