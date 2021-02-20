namespace TheBees.Forms
{
    partial class SpriteViewer
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showCollision1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showCollision2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showCollision3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showAttackCollisionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showThrowCollisionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showCollisionThrownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showAxisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoom1x = new System.Windows.Forms.ToolStripMenuItem();
            this.zoom2x = new System.Windows.Forms.ToolStripMenuItem();
            this.zoom3x = new System.Windows.Forms.ToolStripMenuItem();
            this.zoom4x = new System.Windows.Forms.ToolStripMenuItem();
            this.spritePanel = new TheBees.SpritePanel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.zoomMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(353, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showCollision1ToolStripMenuItem,
            this.showCollision2ToolStripMenuItem,
            this.showCollision3ToolStripMenuItem,
            this.showAttackCollisionToolStripMenuItem,
            this.showThrowCollisionToolStripMenuItem,
            this.showCollisionThrownToolStripMenuItem,
            this.showAxisToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // showCollision1ToolStripMenuItem
            // 
            this.showCollision1ToolStripMenuItem.Name = "showCollision1ToolStripMenuItem";
            this.showCollision1ToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.showCollision1ToolStripMenuItem.Text = "Show Collision 1";
            // 
            // showCollision2ToolStripMenuItem
            // 
            this.showCollision2ToolStripMenuItem.Name = "showCollision2ToolStripMenuItem";
            this.showCollision2ToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.showCollision2ToolStripMenuItem.Text = "Show Collision 2";
            // 
            // showCollision3ToolStripMenuItem
            // 
            this.showCollision3ToolStripMenuItem.Name = "showCollision3ToolStripMenuItem";
            this.showCollision3ToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.showCollision3ToolStripMenuItem.Text = "Show Collision 3";
            // 
            // showAttackCollisionToolStripMenuItem
            // 
            this.showAttackCollisionToolStripMenuItem.Name = "showAttackCollisionToolStripMenuItem";
            this.showAttackCollisionToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.showAttackCollisionToolStripMenuItem.Text = "Show Attack Collision";
            // 
            // showThrowCollisionToolStripMenuItem
            // 
            this.showThrowCollisionToolStripMenuItem.Name = "showThrowCollisionToolStripMenuItem";
            this.showThrowCollisionToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.showThrowCollisionToolStripMenuItem.Text = "Show Throw Collision";
            // 
            // showCollisionThrownToolStripMenuItem
            // 
            this.showCollisionThrownToolStripMenuItem.Name = "showCollisionThrownToolStripMenuItem";
            this.showCollisionThrownToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.showCollisionThrownToolStripMenuItem.Text = "Show Collision Thrown";
            // 
            // showAxisToolStripMenuItem
            // 
            this.showAxisToolStripMenuItem.Name = "showAxisToolStripMenuItem";
            this.showAxisToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.showAxisToolStripMenuItem.Text = "Show Axis";
            // 
            // zoomMenuItem
            // 
            this.zoomMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoom1x,
            this.zoom2x,
            this.zoom3x,
            this.zoom4x});
            this.zoomMenuItem.Name = "zoomMenuItem";
            this.zoomMenuItem.Size = new System.Drawing.Size(51, 20);
            this.zoomMenuItem.Text = "Zoom";
            // 
            // zoom1x
            // 
            this.zoom1x.Name = "zoom1x";
            this.zoom1x.Size = new System.Drawing.Size(85, 22);
            this.zoom1x.Text = "1x";
            this.zoom1x.Click += new System.EventHandler(this.OnZoom1x);
            // 
            // zoom2x
            // 
            this.zoom2x.Name = "zoom2x";
            this.zoom2x.Size = new System.Drawing.Size(85, 22);
            this.zoom2x.Text = "2x";
            this.zoom2x.Click += new System.EventHandler(this.OnZoom2x);
            // 
            // zoom3x
            // 
            this.zoom3x.Name = "zoom3x";
            this.zoom3x.Size = new System.Drawing.Size(85, 22);
            this.zoom3x.Text = "3x";
            this.zoom3x.Click += new System.EventHandler(this.OnZoom3x);
            // 
            // zoom4x
            // 
            this.zoom4x.Name = "zoom4x";
            this.zoom4x.Size = new System.Drawing.Size(85, 22);
            this.zoom4x.Text = "4x";
            this.zoom4x.Click += new System.EventHandler(this.OnZoom4x);
            // 
            // spritePanel
            // 
            this.spritePanel.Location = new System.Drawing.Point(12, 27);
            this.spritePanel.Name = "spritePanel";
            this.spritePanel.Size = new System.Drawing.Size(330, 250);
            this.spritePanel.TabIndex = 0;
            this.spritePanel.Text = "spritePanel";
            // 
            // SpriteViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 284);
            this.Controls.Add(this.spritePanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SpriteViewer";
            this.Text = "Sprite Viewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.Resize += new System.EventHandler(this.OnResize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SpritePanel spritePanel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showCollision1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showCollision2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showCollision3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showAttackCollisionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showThrowCollisionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showCollisionThrownToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showAxisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoom1x;
        private System.Windows.Forms.ToolStripMenuItem zoom2x;
        private System.Windows.Forms.ToolStripMenuItem zoom3x;
        private System.Windows.Forms.ToolStripMenuItem zoom4x;
    }
}