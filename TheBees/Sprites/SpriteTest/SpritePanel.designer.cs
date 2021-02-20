namespace SpriteTest
{
    partial class SpritePanel
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
            this.SuspendLayout();
            // 
            // SpritePanel
            // 
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SpritePanel_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SpritePanel_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SpritePanel_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SpritePanel_MouseUp);
            this.Move += new System.EventHandler(this.SpritePanel_Move);
            this.Resize += new System.EventHandler(this.SpritePanel_Resize);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
