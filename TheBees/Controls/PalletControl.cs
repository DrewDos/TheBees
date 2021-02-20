using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TheBees.Forms;

namespace TheBees
{
    public partial class PalletControl : UserControl
    {
        public delegate void SelectionChangeDelegate(int selectAmount);

        private int boxSize = 16;
        private int borderWidth = 1;
        private int indexAmount = 64;
        private int displayWidth = 0;
        private int displayHeight = 0;
        private int numBoxesX = 8;
        private int numBoxesY;

        private int hoverIndex = -1;

        private bool mouseDown = false;

        private Color backgroundColor = Color.Black;
        private Color[] pallet;
        public Color[] Pallet { get { return pallet; } }

        private ColorSelection selection = new ColorSelection();

        private int selectStart = -1;
        private int selectEnd = -1;

        public PalletControl()
        {
            InitializeComponent();

            InitSize(64);
            LoadSamplePallet();
            DoubleBuffered = true;
            selection.UpdateComplete = OnUpdateComplete;
            //rangeSelected = new bool[indexAmount];
            //Invalidate();
        }



        //public int SetColor(int index, Color color)
        //{
        //}

        private SelectionChangeDelegate selectionChange = null;
        public SelectionChangeDelegate SelectionChange { set { selectionChange = value; } }

        private void InitSize(int newIndexAmount)
        {
            indexAmount = newIndexAmount;

            numBoxesY = indexAmount / numBoxesX + (indexAmount % numBoxesX > 0 ? 1 : 0);
            if (numBoxesY == 0) numBoxesY = 1;
            displayWidth = numBoxesX * boxSize + numBoxesX * borderWidth + borderWidth;
            displayHeight = numBoxesY * boxSize + numBoxesY * borderWidth + borderWidth;
            this.Size = new Size(displayWidth, displayHeight);


        }

        private int GetHoverIndex(int x, int y)
        {
            int indexX = x/ (boxSize + borderWidth);
            int indexY = y / (boxSize + borderWidth);
            int palletIndex = -1;

            if (indexX == numBoxesX)
                indexX--;

            if (indexY == numBoxesY)
                indexY--;

            palletIndex = indexY * numBoxesX + indexX;

            if (palletIndex >= indexAmount)
            {
                // invalid highlight
                return -1;
            }

            if (hoverIndex != palletIndex)
                hoverIndex = palletIndex;

            return palletIndex;
        }

        private void UpdateSelection()
        {
            if (selectStart != -1 && selectEnd != -1)
            {
                int indexStart, indexEnd;
                if (selectStart > selectEnd)
                {
                    indexStart = selectEnd;
                    indexEnd = selectStart;
                }
                else
                {
                    indexStart = selectStart;
                    indexEnd = selectEnd;
                }
                for (int i = indexStart; i <= indexEnd; i++)
                {
                    selection.ColorIndexes.Add(new ColorIndex(pallet[i].R, pallet[i].G, pallet[i].B, i));
                }

                OnSelectionChange(indexEnd-indexStart+1);
            }
        }

        public ColorSelection GetColorSelection()
        {
            //ColorSelection selection = new ColorSelection(pallet, rangeSelected);
            //selection.UpdateComplete = SelectComplete;
            return selection;
        }

        private void OnUpdateComplete(ColorSelection selection)
        {
            foreach (ColorIndex index in selection.ColorIndexes)
            {
                pallet[index.Index] = Color.FromArgb(255, index.R, index.G, index.B);
            }

            Invalidate();
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            int oldHover = hoverIndex;
            hoverIndex = GetHoverIndex(e.X, e.Y);


            if (hoverIndex != -1 && oldHover != hoverIndex)
            {
                if (mouseDown)
                {
                    selectEnd = hoverIndex;
                    selection.ColorIndexes.Clear();
                    UpdateSelection();
                }

                Invalidate();
            }

        }


        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            selection.ColorIndexes.Clear();
            selectStart = hoverIndex;
            selectEnd = hoverIndex;
            UpdateSelection();
            Invalidate();
        }

        private Rectangle GetBoxRect(int x, int y)
        {
            return new Rectangle(x * (boxSize) + borderWidth + x, y * (boxSize) + borderWidth + y, boxSize, boxSize);
        }

        private Rectangle GetSelectRect(int index)
        {
            int x = index % numBoxesX;
            int y = index / numBoxesY;

            return new Rectangle(x * (boxSize) + x, y * (boxSize) + y, boxSize, boxSize);
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            
            Rectangle rect = new Rectangle(0, 0, displayWidth, displayHeight);

            e.Graphics.FillRectangle(new SolidBrush(backgroundColor), rect);

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            int x = 0;
            int y = 0;

            for (int i = 0; i < indexAmount; i++)
            {
                Rectangle boxRect = GetBoxRect(x, y);
                e.Graphics.FillRectangle(new SolidBrush(pallet[i]), boxRect);
                x += 1;

                if (x == numBoxesX)
                {
                    x = 0;
                    y += 1;
                    if (y == numBoxesY)
                        break;
                }
            }

            foreach(ColorIndex ci in selection.ColorIndexes)
            {                
                e.Graphics.DrawRectangle(new Pen(Color.Red), GetSelectRect(ci.Index));
            }

            if(hoverIndex != -1)
            {
                e.Graphics.DrawRectangle(new Pen(Color.Red), GetSelectRect(hoverIndex));
            }
        }
        public void UpdatePallet(int index, Color newColor)
        {
            pallet[index] = newColor;
        }
        public void LoadPallet(Color[] newPallet)
        {
            pallet = newPallet;
            InitSize(newPallet.Length);
            Invalidate();
        }

        private void LoadSamplePallet()
        {
            pallet = new Color[indexAmount];

            for (int i = 0; i < indexAmount; i++)
            {
                pallet[i] = Color.Black;
            }
        }

        public void ClearSelection()
        {
            selection.Clear();
            OnSelectionChange(0);
        }
        public void OnSelectionChange(int count)
        {
            if(selectionChange != null)
            {
                selectionChange(count);
            }
        }
    }



   
}
