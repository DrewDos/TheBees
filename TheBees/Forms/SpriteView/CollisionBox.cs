using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;

using BaseGraphics = System.Drawing.Graphics;

namespace TheBees
{

    public class CollisionBox
    {
        private const int cornerSize = 6;

        private static SolidBrush activeFill = new SolidBrush(Color.FromArgb(100, 255, 255, 255));

        public Rectangle BaseRect;
        public Rectangle RawRect;

        public Pen Outline;
        private bool OverCollision = false;
        private bool overResizable = false;

        private int oldX;
        private int oldY;
        private bool isActive = false;
        private bool pendingClick = false;
        //private bool mouseDown = false;
        private bool movingBox = false;
        private bool resizingBox = false;
        private int id;
        private bool clicked;
        private int cornerIndex = 0;

        private SolidBrush currFill;
        private SolidBrush baseFill;

        private int xOffset = 0;
        private int yOffset = 0;

        public OnRectChangeDelegate OnRectChange;
        //public OnResizeCollisionDelegate OnResizeCollision;

        public CollisionBox(Pen newOutline, SolidBrush newFill, Rectangle newRawRect)
        {
            Outline = newOutline;
            baseFill = newFill;
            RawRect = newRawRect;
            BaseRect = newRawRect;
            OverCollision = false;
            currFill = baseFill;
        }



        public void SetID(int newID)
        {
            id = newID;
        }



        public bool UpdateMouseMove(int x, int y)
        {
            OverCollision = BaseRect.Contains(x, y);

            if (isActive)
            {


                CheckUpdateCorners(x, y);

                if (movingBox)
                {

                    BaseRect.X += x - oldX;
                    BaseRect.Y += y - oldY;
                    RawRect.X += x - oldX;
                    RawRect.Y += y - oldY;
                    oldX = x;
                    oldY = y;


                    if (OnRectChange != null)
                    {
                        OnRectChange(id);
                    }


                    return true;
                }
                else if (resizingBox)
                {
                    int diffX = x - oldX;
                    int diffY = y - oldY;

                    Rectangle start = BaseRect;
                    //int currX = BaseRect.X, currY = BaseRect.Y, currWidth = BaseRect.Width, currHeight = BaseRect.Height;
                    
                    switch (cornerIndex)
                    {
                        case 7:

                            BaseRect.X += diffX;
                            BaseRect.Width -= diffX;
                            BaseRect.Y += diffY;
                            BaseRect.Height -= diffY;
                            break;
                        case 9:

                            //BaseRect.X += diffX;
                            BaseRect.Width += diffX;
                            BaseRect.Y += diffY;
                            BaseRect.Height -= diffY;
                            break;
                        case 1:

                            BaseRect.X += diffX;
                            BaseRect.Width -= diffX;
                            //BaseRect.Y += diffY;
                            BaseRect.Height += diffY;
                            break;
                        case 3:

                            //BaseRect.X += diffX;
                            BaseRect.Width += diffX;
                            //BaseRect.Y += diffY;
                            BaseRect.Height += diffY;
                            break;
                    }

                    RawRect.X += BaseRect.X - start.X;
                    RawRect.Y += BaseRect.Y - start.Y;
                    RawRect.Width += BaseRect.Width - start.Width;
                    RawRect.Height += BaseRect.Height - start.Height;

                    oldX = x;
                    oldY = y;

                    if (OnRectChange != null)
                    {
                        OnRectChange(id);
                    }
                    return true;
                }
            }

            return false;
        }

        public bool UpdateMouseDown(int x, int y)
        {

            // over resizable takes priority
            if (overResizable)
            {
                oldX = x;
                oldY = y;
                resizingBox = true;
                return true;
            }
            if (OverCollision)
            {
                oldX = x;
                oldY = y;
                movingBox = true;
                pendingClick = true;
                return true;
            }
            return false;
        }

        public void UpdateMouseUp()
        {
            if (OverCollision)
            {
                if (pendingClick)
                {
                    clicked = true;
                }
            }

            pendingClick = false;
            movingBox = false;
            resizingBox = false;
        }

        public void ToggleActivation()
        {
            if (isActive)
            {
                currFill = baseFill;
                isActive = false;
            }
            else
            {
                currFill = activeFill;
                isActive = true;

            }
        }

        public void Activate()
        {
            currFill = activeFill;
            isActive = true;
        }

        public void DeActivate()
        {
            currFill = baseFill;
            isActive = false;
        }

        public bool GetClearClicked()
        {
            if (clicked)
            {
                clicked = false;
                return true;
            }

            return false;
        }

        public void CheckUpdateCorners(int x, int y)
        {
            overResizable = false;

            if (x >= (BaseRect.Width + BaseRect.X) - (cornerSize / 2) && x <= (BaseRect.Width + BaseRect.X) + (cornerSize / 2))
            {
                if (y >= (BaseRect.Y) - (cornerSize / 2) && y <= (BaseRect.Y) + (cornerSize / 2))
                {
                    Cursor.Current = Cursors.SizeNESW;
                    cornerIndex = 9;
                    overResizable = true;
                }

                if (y >= (BaseRect.Y + BaseRect.Height) - (cornerSize / 2) && y <= (BaseRect.Y + BaseRect.Height) + (cornerSize / 2))
                {
                    Cursor.Current = Cursors.SizeNWSE;
                    cornerIndex = 3;
                    overResizable = true;
                }
            }

            if (x >= (BaseRect.X) - (cornerSize / 2) && x <= (BaseRect.X) + (cornerSize / 2))
            {
                if (y >= (BaseRect.Y) - (cornerSize / 2) && y <= (BaseRect.Y) + (cornerSize / 2))
                {
                    Cursor.Current = Cursors.SizeNWSE;
                    cornerIndex = 7;
                    overResizable = true;
                }

                if (y >= (BaseRect.Y + BaseRect.Height) - (cornerSize / 2) && y <= (BaseRect.Y + BaseRect.Height) + (cornerSize / 2))
                {
                    Cursor.Current = Cursors.SizeNESW;
                    cornerIndex = 1;
                    overResizable = true;
                }
            }

        }

        public void SetOffset(int xAxis, int yAxis)
        {
            xOffset = xAxis;
            yOffset = yAxis;

            UpdateRect();
        }
        private void UpdateRect()
        {

            BaseRect = RawRect;
            BaseRect.Offset(new Point(xOffset, yOffset));
        }

        public void SetRect(Rectangle newRect)
        {
            RawRect = newRect;
            BaseRect = newRect;
        }
        public SolidBrush Fill { get { return currFill; } }

        public int ID { get { return id; } }
        public bool Clicked { get { return clicked; } }
    }
}
