using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SpriteTest.Graphics;

namespace SpriteTest
{
    struct Pixel
    {
        private int xPos;
        private int yPos;
        private Color color;

        public Pixel(int newXPos, int newYPos, Color newColor)
        {
            xPos = newXPos;
            yPos = newYPos;
            color = newColor;
        }
    }

    public partial class SpritePanel : Control
    {
        Bitmap b;

        int oldMouseX = 0;
        int oldMouseY = 0;
        int xOffs = 0, yOffs = 0;
        int imageW;
        int imageH;
        int zoom = 1;

        bool bMouseDown;

        Rectangle srcRect, dstRect;

        public SpritePanel()
        {
            DoubleBuffered = true;
            InitializeComponent();
        }

        public void SetImageSize(int newImageW, int newImageH)
        {
            imageW = newImageW;
            imageH = newImageH;
        }
        public void SetBitmap(Bitmap newBitmap)
        {
            b = newBitmap;
            SetRect();
        }

        public void Draw()
        {
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            //base.OnPaint(pe);

            System.Drawing.Graphics gfx = pe.Graphics;

            Rectangle rc = ClientRectangle;
            rc.Width -= 1;
            rc.Height -= 1;

            gfx.FillRectangle(new SolidBrush(Color.Black), rc);
            

            if (b != null)
            {
                gfx.DrawImage(b, dstRect, srcRect, GraphicsUnit.Pixel);
            }
        }

        private void SpritePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SpritePanel_MouseDown(object sender, MouseEventArgs e)
        {
            bMouseDown = true;
            oldMouseX = e.X;
            oldMouseY = e.Y;
        }

        private void SpritePanel_Move(object sender, EventArgs e)
        {

        }

        private void SpritePanel_MouseUp(object sender, MouseEventArgs e)
        {
            bMouseDown = false;
        }

        private void SpritePanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (bMouseDown)
            {
                int oldXOffs = xOffs;
                int oldYOffs = yOffs;

                xOffs += e.X - oldMouseX;
                if (xOffs < 0)
                    xOffs = 0;
                if (xOffs + srcRect.Width > imageW)
                    xOffs = imageW - srcRect.Width;
                

                yOffs += e.Y - oldMouseY;
                if (yOffs < 0)
                    yOffs = 0;
                if (yOffs + srcRect.Height > imageH)
                    yOffs = imageH - srcRect.Height;

                oldMouseX = e.X;
                oldMouseY = e.Y;
                if (oldXOffs != xOffs || oldYOffs != yOffs)
                    Invalidate();
            }

            SetRect();

        }

        private void SpritePanel_Resize(object sender, EventArgs e)
        {
            SetRect();
            Invalidate();
        }

        private void SetRect()
        {
            // set the source rectangle;
            srcRect = ClientRectangle;
            dstRect = ClientRectangle;

            srcRect.Width /= zoom;
            srcRect.Height /= zoom;

            srcRect.Offset(xOffs, yOffs);
        }
    }
}
