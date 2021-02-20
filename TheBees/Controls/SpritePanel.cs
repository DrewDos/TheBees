using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;

using TheBees.Sprites;
using BaseGraphics = System.Drawing.Graphics;

namespace TheBees
{


    public delegate void OnRectChangeDelegate(int collisionID);
    //public delegate void OnResizeCollisionDelegate(int collisionID);

    public partial class SpritePanel : Control
    {
        private delegate void PointEvent(int x, int y);
        public delegate void OnSpriteOffsetChangedDelegate(int index, int x, int y);

        private const int maxWidth = 1024;
        private const int maxHeight = 1024;
        private const int startYAxisPos = 48;
        private const int maxSprites = 4;

        int oldMouseX = 0;
        int oldMouseY = 0;
        int xOffs = 0, yOffs = 0;
        //int imageW;
        //int imageH;
        int zoom = 1;

        public int AxisX = 0;
        public int AxisY = 0;

        public bool mouseDown = false;
        public bool controlDown = false;

        private int axisBottomMargin = 96;
        private Image axisBitmap;
        private BaseGraphics g;
        private Bitmap controlBitmap = new Bitmap(maxWidth, maxHeight);

        private List<SpriteInfo> spriteInfoSet;
        private int activeSpriteCount;

        Rectangle srcRect, dstRect;
        private List<int> activateQueue = new List<int>();
        private int queueIndex = 0;
        private int selectedIndex;
        //private int [] layerIndexes;

        //private bool collisionActive = false;
        private bool movingBox;

        private List<CollisionBox> allBoxes = new List<CollisionBox>();

        private PointEvent onMouseMove = null;
        private PointEvent onMouseDown = null;
        private PointEvent onMouseUp = null;
        public Action<int> NudgeSelection = null;

        private Dictionary<int, bool> lockedIndexes = new Dictionary<int, bool>();
        private ModifyMode modifyMode;

        private OnSpriteOffsetChangedDelegate spriteOffsetChanged = null;
        public OnSpriteOffsetChangedDelegate SpriteOffsetChanged { set { spriteOffsetChanged = value; } }

        public SpritePanel()
        {
            DoubleBuffered = true;
            InitializeComponent();

            axisBitmap = Properties.Resources.axis;
            g = BaseGraphics.FromImage(axisBitmap);

            spriteInfoSet = new List<SpriteInfo>();
            // setup all boxes
            // InitCollision();
        }



        public void SetModifyMode(ModifyMode newModifyMode)
        {
            switch (newModifyMode)
            {
                case ModifyMode.Sprite:
                    onMouseUp = UpdateSpriteMouseUp;
                    onMouseDown = UpdateSpriteMouseDown;
                    onMouseMove = UpdateSpriteMouseMove;
                    NudgeSelection = NudgeSprite;
                    break;
                case ModifyMode.Collision:
                    onMouseUp = UpdateCollisionMouseUp;
                    onMouseDown = UpdateCollisionMouseDown;
                    onMouseMove = UpdateCollisionMouseMove;
                    NudgeSelection = null;
                    break;
                case ModifyMode.None:
                    onMouseUp = null;
                    onMouseDown = null;
                    onMouseMove = null;
                    NudgeSelection = null;
                    break;
            }

            modifyMode = newModifyMode;
        }

        public void BeginLoadSprites()
        {
            spriteInfoSet = new List<SpriteInfo>();
            activateQueue = new List<int>();
            selectedIndex = 0;
            lockedIndexes.Clear();
        }

        public void LoadSprite(Sprite sprite, Color [] pallet, int xOffset, int yOffset)
        {
            SpriteInfo newInfo = new SpriteInfo((NormalSprite)sprite, xOffset, yOffset);
            newInfo.SetDestRect(AxisX, AxisY);
            newInfo.SetPallet(pallet);
            spriteInfoSet.Add(newInfo);

            activeSpriteCount = spriteInfoSet.Count;
        }

        public void UpdatePallet(int index, Color[] newPallet)
        {
            if (index >= spriteInfoSet.Count || index < 0)
            {
                throw new ArgumentOutOfRangeException("Sprite index does not exist");
            }

            spriteInfoSet[index].SetPallet(newPallet);
        }

        public void SetZoom(int zoomIndex)
        {
            zoom = zoomIndex+1;
            UpdateDisplayValues();
            Invalidate();
        }

        public void SetPallet(int index, Color[] pallet)
        {
            spriteInfoSet[index].SetPallet(pallet);
        }

        public void ClearSprites()
        {
            activeSpriteCount = 0;
        }

        public void ClearBitmap(int index)
        {
            Bitmap b = spriteInfoSet[index].Bitmap;
            System.Drawing.Graphics gfx = System.Drawing.Graphics.FromImage(b);
            gfx.FillRectangle(Brushes.Black, new Rectangle(0, 0, b.Width, b.Height));
        }

        public void Draw()
        {
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {

            System.Drawing.Graphics gfx = pe.Graphics;
            System.Drawing.Graphics baseGfx = System.Drawing.Graphics.FromImage(controlBitmap);

            Rectangle rc = ClientRectangle;

            if (activeSpriteCount > 0)
            {
                baseGfx.FillRectangle(new SolidBrush(Color.Black), dstRect);
                for (int i = 0; i < activeSpriteCount; i++)
                {
                    SpriteInfo spriteInfo = spriteInfoSet[i];
                    baseGfx.DrawImage(spriteInfo.Bitmap, spriteInfo.TargetRect, new Rectangle(0, 0, spriteInfo.Sprite.Width, spriteInfo.Sprite.Height), GraphicsUnit.Pixel);
                    if (spriteInfo.Selected)
                    {
                        baseGfx.DrawRectangle(new Pen(Brushes.Aqua), spriteInfo.TargetRect);
                    }
                }

                baseGfx.DrawImage(axisBitmap, AxisX - 6, AxisY - 6);
                DrawCollision(baseGfx);
                gfx.DrawImage(controlBitmap, dstRect, srcRect, GraphicsUnit.Pixel);
            }
            else
            {
                gfx.FillRectangle(new SolidBrush(Color.Black), rc);
            }
            
        }

        private void SpritePanel_MouseDown(object sender, MouseEventArgs e)
        {

            mouseDown = true;

            int realX = RealXPos(e.X);
            int realY = RealYPos(e.Y);

            if (onMouseDown != null)
            {
                onMouseDown(realX, realY);
            }

            oldMouseX = RealXPos(e.X);
            oldMouseY = RealYPos(e.Y);
        }
        
        private void SpritePanel_MouseUp(object sender, MouseEventArgs e)
        {
            int realX = RealXPos(e.X);
            int realY = RealYPos(e.Y);

            mouseDown = false;

            if (onMouseDown != null)
            {
                onMouseUp(realX, realY);
            }

        }

        private void SpritePanel_MouseMove(object sender, MouseEventArgs e)
        {
            int realX = RealXPos(e.X);
            int realY = RealYPos(e.Y);

            if (onMouseMove != null)
            {
                onMouseMove(realX, realY);
            }
        }

        private void UpdateSpriteMouseDown(int xPos, int yPos)
        {

            List<int> newQueue = new List<int>();

            for (int i = 0; i < activeSpriteCount; i++)
            {

                if (!lockedIndexes.ContainsKey(i) || lockedIndexes[i] == false)
                {
                    if (spriteInfoSet[i].TargetRect.Contains(new Point(xPos, yPos)))
                    {
                        newQueue.Add(i);
                    }
                }
            }

            if (newQueue.Count > 0)
            {
                if (activateQueue.SequenceEqual(newQueue))
                {
                    queueIndex += 1;

                    if (queueIndex >= activateQueue.Count)
                    {
                        queueIndex = 0;
                    }
                }
                else
                {
                    activateQueue = newQueue;
                    queueIndex = 0;
                }
                if (selectedIndex < activeSpriteCount && selectedIndex >= 0)
                {
                    spriteInfoSet[selectedIndex].Selected = false;
                }

                selectedIndex = activateQueue[queueIndex];
                spriteInfoSet[selectedIndex].Selected = true;
                Invalidate();
            }
            else
            {
                if (selectedIndex >= 0)
                {

                    spriteInfoSet[selectedIndex].Selected = false;
                    selectedIndex = -1;
                    Invalidate();
                }
            }

        }

        private void UpdateSpriteMouseMove(int xPos, int yPos)
        {

            if (mouseDown && selectedIndex >= 0 && spriteInfoSet.Count > selectedIndex && spriteInfoSet[selectedIndex].Selected)
            {
                int diffX = xPos - oldMouseX;
                int diffY = yPos - oldMouseY;

                spriteInfoSet[selectedIndex].MovePositionX += diffX;
                spriteInfoSet[selectedIndex].MovePositionY += diffY;
                spriteInfoSet[selectedIndex].SetDestRect(AxisX, AxisY);

                OnSpriteOffsetChanged(selectedIndex, spriteInfoSet[selectedIndex].MovePositionX, spriteInfoSet[selectedIndex].MovePositionY);

                Invalidate();
            }

            oldMouseX = xPos;
            oldMouseY = yPos;
        }

        private int[] GetNudgeValues(int direction)
        {
            int diffX = 0;
            int diffY = 0;
            switch (direction)
            {
                case 8:
                    diffY = -1;
                    break;
                case 2:
                    diffY = 1;
                    break;
                case 4:
                    diffX = -1;
                    break;
                case 6:
                    diffX = 1;
                    break;
            }

            return new int[] { diffX, diffY };
        }

        public void NudgeSprite(int direction)
        {
            int[] nudgeValues = GetNudgeValues(direction);
            spriteInfoSet[selectedIndex].MovePositionX += nudgeValues[0];
            spriteInfoSet[selectedIndex].MovePositionY += nudgeValues[1];
            spriteInfoSet[selectedIndex].SetDestRect(AxisX, AxisY);

            OnSpriteOffsetChanged(selectedIndex, spriteInfoSet[selectedIndex].MovePositionX, spriteInfoSet[selectedIndex].MovePositionY);

            Invalidate();
        }

        public void NudgeCollision(int direction)
        {
            int[] nudgeValues = GetNudgeValues(direction);
        }

        private void UpdateSpriteMouseUp(int xPos, int yPos)
        {
            if (selectedIndex >= 0)
            {
                spriteInfoSet[selectedIndex].Selected = true;
                Invalidate();
            }
        }

        private void SpritePanel_Resize(object sender, EventArgs e)
        {
            UpdateDisplayValues();
            Invalidate();
        }

        public void SelectSprite(int index)
        {
            if (spriteInfoSet.Count > 0)
            {
                activateQueue.Clear();

                if (index < 0 || index > spriteInfoSet.Count)
                    throw new Exception("Index out of range");

                foreach (SpriteInfo spriteInfo in spriteInfoSet)
                {
                    spriteInfo.Selected = false;

                }

                selectedIndex = index;
                spriteInfoSet[index].Selected = true;
            }
            
            
        }

        private void UpdateDisplayValues()
        {
            UpdateAxisPos();
            // set the source rectangle;
            srcRect = ClientRectangle;
            dstRect = ClientRectangle;

            srcRect.Width /= zoom;
            srcRect.Height /= zoom;
            srcRect.X = AxisX - (srcRect.Width / 2);
            srcRect.Y = AxisY - (srcRect.Height) + axisBottomMargin;
            srcRect.Offset(xOffs, yOffs);

            for (int i = 0; i < activeSpriteCount; i++)
            {
                spriteInfoSet[i].SetDestRect(AxisX, AxisY);
            }

            for (int i = 0; i < allBoxes.Count; i++)
            {
                allBoxes[i].SetOffset(AxisX, AxisY);
            }
        }

        private void UpdateAxisPos()
        {
            AxisX = this.Width / 2;
            AxisY = this.Height - axisBottomMargin;

            for (int i = 0; i < activeSpriteCount; i++)
            {
                spriteInfoSet[i].SetDestRect(AxisX, AxisY);
            }
        }

        private void DrawCollision(BaseGraphics gfx)
        {
            
            for (int i = 0; i < allBoxes.Count; i++)
            {
                gfx.DrawRectangle(allBoxes[i].Outline, allBoxes[i].BaseRect);
                gfx.FillRectangle(allBoxes[i].Fill, allBoxes[i].BaseRect);
            }
            
        }

        public void LockMovement(int spriteIndex)
        {
            if (spriteIndex >= spriteInfoSet.Count)
            {
                throw new ArgumentException("spriteIndex is greater than the current amount");
            }

            lockedIndexes[spriteIndex] = true;
        }

        private void UpdateCollisionMouseMove(int x, int y)
        {
            movingBox = false;

            for (int i = 0; i < allBoxes.Count; i++)
            {
                if (allBoxes[i].UpdateMouseMove(x, y))
                {
                    movingBox = true;
                }
            }

            if (movingBox)
            {
                Invalidate();
            }
        }

        private void UpdateCollisionMouseDown(int x, int y)
        {
            for (int i = 0; i < allBoxes.Count; i++)
            {
                allBoxes[i].UpdateMouseDown(x, y);
            }
        }

        private void UpdateCollisionMouseUp(int x, int y)
        {

            if (!movingBox)
            {
                CollisionBox currBox;
                List<int> clickedIndexes = new List<int>();
                // get all of the boxes that have been clicked notified

                for (int i = 0; i < allBoxes.Count; i++)
                {
                    currBox = allBoxes[i];
                    currBox.UpdateMouseUp();

                    if (currBox.GetClearClicked())
                    {
                        clickedIndexes.Add(i);
                    }
                }

                // make sure the queue is the same size as the clicked indexes, although the coutned indexes match


                if (clickedIndexes.Count > 0 && !clickedIndexes.SequenceEqual(activateQueue))
                {
                    activateQueue = clickedIndexes;
                    queueIndex = 0;
                }
                else if (activateQueue.Count > 0)
                {
                    queueIndex += 1;

                    if (queueIndex >= activateQueue.Count)
                    {
                        queueIndex = 0;
                    }
                }
                else
                {

                    queueIndex = -1;
                }
                
                if (selectedIndex >= 0 && allBoxes.Count > selectedIndex)
                {
                    allBoxes[selectedIndex].DeActivate();
                }
                if (queueIndex >= 0)
                {
                    
                    selectedIndex = activateQueue[queueIndex];
                    allBoxes[selectedIndex].Activate();
                }
                else
                {
                    selectedIndex = -1;
                }

                Invalidate();


            }
            else
            {
                if (selectedIndex >= 0)
                {
                    allBoxes[selectedIndex].UpdateMouseUp();
                }                
            }
        }

        public void ClearCollision()
        {
            allBoxes.Clear();
        }

        public CollisionBox GetCollisionBox(int id)
        {
            return allBoxes[id];
        }

        public int AddCollisionBox(Rectangle rect, Color fillColor, Color outlineColor)
        {
            int newID = allBoxes.Count;
            CollisionBox newBox = new CollisionBox(new Pen(outlineColor), new SolidBrush(fillColor), rect);
            newBox.SetOffset(AxisX, AxisY);
            newBox.SetID(newID);
            allBoxes.Add(newBox);
            return newID;
        }

        public void UpdateCollisionBox(int id, Rectangle rect)
        {
            allBoxes[id].SetRect(rect);
            allBoxes[id].SetOffset(AxisX, AxisY);
        }

        private void OnSizeChanged(object sender, EventArgs e)
        {
            UpdateDisplayValues();
        }

        public int RealXPos(int srcX)
        {
            return srcX/zoom + srcRect.X;
        }

        public int RealYPos(int srcY)
        {
            return srcY/zoom + srcRect.Y;
        }

        private void OnKeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            //if(e.KeyCode == Keys.Control)
            //{
            //    controlDown = false;
            //}

            //if (selectedIndex >= 0 && spriteInfoSet[selectedIndex].Selected)
            //{
            //    int add = controlDown ? 10 : 1;
            //    switch (e.KeyCode)
            //    {
            //        case Keys.Left:
            //            spriteInfoSet[selectedIndex].MovePositionX += -add;
            //            Invalidate();
            //            break;
            //        case Keys.Right:
            //            spriteInfoSet[selectedIndex].MovePositionX += add;
            //            Invalidate();
            //            break;
            //        case Keys.Up:
            //            spriteInfoSet[selectedIndex].MovePositionY += -add;
            //            Invalidate();
            //            break;
            //        case Keys.Down:
            //            spriteInfoSet[selectedIndex].MovePositionY += add;
            //            Invalidate();
            //            break;
            //    }
            //}
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {

            //if (e.KeyCode == Keys.Control)
            //{
            //    controlDown = true;
            //}
        }

        private void OnSpriteOffsetChanged(int index, int xPos, int yPos)
        {
            if (spriteOffsetChanged != null)
            {
                spriteOffsetChanged(index, xPos, yPos);
            }
        }

        public SpriteInfo GetSpriteInfo(int index)
        {
            if (index < 0 || index > spriteInfoSet.Count - 1)
                return null;

            return spriteInfoSet[index];
        }

        public bool CanNudge
        {
            get
            {
                return modifyMode == ModifyMode.Sprite && spriteInfoSet.Find((x) => x.Selected) != null;

            }
        }
    }

    public enum ModifyMode
    {
        Collision,
        None,
        Sprite
    }

    public class SpriteInfo
    {
        private Bitmap bitmap;
        private Color[] pallet;
        private int drawOffsetX;
        private int drawOffsetY;
        private int movePositionX;
        private int movePositionY;
        private int xAxis;
        private int yAxis;
        //private bool flipX;
        //private bool flipY;
        private NormalSprite sprite;
        private Rectangle destRect;


        public SpriteInfo(NormalSprite sourceSprite, int modifyPositionX = 0, int modifyPositionY = 0)
        {
            sprite = sourceSprite;
            drawOffsetX = sprite.AxisX - sprite.BaseX;
            drawOffsetY = sprite.AxisY - sprite.BaseY;
            bitmap = new Bitmap(sprite.Width, sprite.Height);
            movePositionX = modifyPositionX;
            movePositionY = modifyPositionY;
            xAxis = 0;
            yAxis = 0;

        }

        public void SetPallet(Color[] newPallet)
        {
            pallet = newPallet;

            sprite.DrawSprite(bitmap, pallet, 0, 0);
        }

        public void SetDestRect(int xAxis, int yAxis)
        {
            this.xAxis = xAxis;
            this.yAxis = yAxis;

            UpdateDestRect();
        }

        private void UpdateDestRect()
        {
            destRect = new Rectangle(drawOffsetX + xAxis + movePositionX, drawOffsetY + yAxis + movePositionY, sprite.Width, sprite.Height);
        }

        public int DrawOffsetX { get { return drawOffsetX; } set { drawOffsetX = value; } }
        public int DrawOffsetY { get { return drawOffsetY; } set { drawOffsetY = value; } }
        public int MovePositionX { get { return movePositionX; } set { movePositionX = value; UpdateDestRect(); } }
        public int MovePositionY { get { return movePositionY; } set { movePositionY = value; UpdateDestRect(); } }
        public NormalSprite Sprite { get { return sprite; }}
        public Bitmap Bitmap { get { return bitmap; } }
        public Rectangle TargetRect { get { return destRect; } }
        public bool Selected { get; set; }
        public bool Locked { get; set; }


    }
}
