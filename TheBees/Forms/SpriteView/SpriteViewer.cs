using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TheBees.UnitData;
using TheBees.Sprites;

namespace TheBees.Forms
{

    public partial class SpriteViewer : Form
    {
        private Sprite activeSprite;
        private Color[] activePallet;

        private Dictionary<string, int[]> clsnGroup = new Dictionary<string, int[]>();
        private Dictionary<int, CollisionIndexExt> clsnIndexMap = new Dictionary<int, CollisionIndexExt>();
        
        private DirectionalKeyAction keyAction;
        private DirectionalKeyAction ctrlKeyAction;
        public DirectionalKeyAction CtrlKeyAction { set { ctrlKeyAction = value; } }

        private Size currSize;
        OnCollisionRectChangeDelegateExt onCollisionRectChange;

        public SpriteViewer()
        {
            InitializeComponent();
            currSize = Size;

            keyAction = new DirectionalKeyAction(false);
            keyAction.UpEvent += () => NudgeSelection(8);
            keyAction.DownEvent += () => NudgeSelection(2);
            keyAction.LeftEvent += () => NudgeSelection(4);
            keyAction.RightEvent += () => NudgeSelection(6);
            
        }

        private void NudgeSelection(int index)
        {
            if (spritePanel.CanNudge)
            {
                spritePanel.NudgeSelection(index);
            }
        }

        public bool ShowNormalSprite(List<SpriteRequest> requests)
        {
            int spriteCount = 0;

            if (requests != null && requests.Count != 0)
            {
                spritePanel.BeginLoadSprites();
                int spriteCountActive = 0;
                for (int i = 0; i < requests.Count; i++)
                {
                    SpriteRequest request=requests[i];
                    int spriteIndex = request.Index;
                    Color[] pallet = request.Pallet;
                    if (spriteIndex > 0 && spriteIndex < SpriteSpec.MaxSpriteIndex)
                    {
                        activePallet = pallet;
                        activeSprite = SpriteHandler.GetSprite(spriteIndex, request.FlipX, request.FlipY);

                        if (activeSprite != null)
                        {

                            spritePanel.LoadSprite(activeSprite, activePallet, request.XPos, request.YPos);
                            spritePanel.SetPallet(spriteCount, activePallet);
                            if (request.LockMovement)
                            {
                                spritePanel.LockMovement(spriteCount);
                            }

                            spriteCountActive += 1;
                        }
                    }
                    spriteCount++;
                }

                if (spriteCountActive == 0)
                {
                    spritePanel.ClearSprites();
                }
            }
            else
            {
                spritePanel.ClearSprites();
            }

            spritePanel.Invalidate();

            return spriteCount > 0;
        }

        public int ShowNormalSprite(int spriteIndex, Color [] pallet)
        {
            activePallet = pallet;
            activeSprite = SpriteHandler.GetSprite(spriteIndex);

            if (activeSprite != null)
            {
                spritePanel.BeginLoadSprites();
                spritePanel.LoadSprite((NormalSprite)activeSprite, pallet, 0, 0);
            }
            else
            {
                spritePanel.ClearSprites();
            }

            spritePanel.Invalidate();

            return 1;
        }

        public void InitializeCollision()
        {
            // remove all collision indexes
            spritePanel.ClearCollision();
        }

        public void SetCollision(string type, Rectangle [] rects, Color color)
        {
            int numClsn = rects.Length;

            clsnGroup[type] = new int[numClsn];

            for (int i = 0; i < numClsn; i++)
            {

                clsnGroup[type][i] = spritePanel.AddCollisionBox(rects[i], Color.FromArgb(0, 0, 0, 0), color);
                spritePanel.GetCollisionBox(clsnGroup[type][i]).OnRectChange = OnCollisionRectChange;
                clsnIndexMap[clsnGroup[type][i]] = new CollisionIndexExt(i, type);
            }
        }

        public void UpdateCollision(string type, Rectangle [] rects, int offset = 0)
        {
            int numClsn = rects.Length;

            for (int i = 0; i < numClsn; i++)
            {

                spritePanel.UpdateCollisionBox(clsnGroup[type][i+offset], rects[i]);
            }
        }

        public void CollisionSetComplete()
        {
            spritePanel.Invalidate();
        }

        public CollisionBox GetCollisionBox(string type, int index)
        {
            return spritePanel.GetCollisionBox(clsnGroup[type][index]);
        }

        private void OnCollisionRectChange(int id)
        {
            if(onCollisionRectChange != null)
                onCollisionRectChange(clsnIndexMap[id].type, clsnIndexMap[id].index);
        }

        public void Clear()
        {
            Panel.ClearSprites();
            Panel.Invalidate();
        }
        public SpritePanel Panel { get { return spritePanel; } }
        public OnCollisionRectChangeDelegateExt OnCollisionRectChangeDelegate { set { onCollisionRectChange = value; } }

        private void OnZoom1x(object sender, EventArgs e)
        {
            spritePanel.SetZoom(0);
        }

        private void OnZoom2x(object sender, EventArgs e)
        {
            spritePanel.SetZoom(1);
        }

        private void OnZoom3x(object sender, EventArgs e)
        {
            spritePanel.SetZoom(2);
        }

        private void OnZoom4x(object sender, EventArgs e)
        {
            spritePanel.SetZoom(3);
        }

        private void OnResize(object sender, EventArgs e)
        {
            int widthDiff = this.Size.Width - currSize.Width;
            int heightDiff = this.Size.Height - currSize.Height;

            spritePanel.Size = new Size(spritePanel.Size.Width + widthDiff, spritePanel.Size.Height + heightDiff);

            spritePanel.Invalidate();
            currSize = Size;
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            this.Parent = null;
            e.Cancel = true;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (ctrlKeyAction != null && ctrlKeyAction.Process(ModifierKeys, keyData) || keyAction.Process(ModifierKeys, keyData))
                return true;

            return base.ProcessCmdKey(ref msg, keyData);
        }

    }
    public class SpriteRequest
    {
        private int index;
        private Color[] pallet;

        public int Index { get { return index; } }
        public Color[] Pallet { get { return pallet; } }
        private int xPos = 0;
        private int yPos = 0;
        private bool flipX = false;
        private bool flipY = false;
        private bool lockMovement = false;
        public int XPos { get { return xPos; } }
        public int YPos { get { return yPos; } }
        public bool FlipX { get { return flipX; } }
        public bool FlipY { get { return flipY; } }
        public bool LockMovement { get { return lockMovement; } set { lockMovement = value; } }

        public SpriteRequest(int newIndex, Color[] newPallet, int newXPos = 0, int newYPos = 0, bool sourceFlipX = false, bool sourceFlipY = false, bool sourceLockMovement = false)
        {
            xPos = newXPos;
            yPos = newYPos;

            flipX = sourceFlipX;
            flipY = sourceFlipY;

            index = newIndex;
            pallet = newPallet;
            lockMovement = sourceLockMovement;
        }
    }

    struct CollisionIndexExt
    {
        public int index;
        public string type;

        public CollisionIndexExt(int newIndex, string newType)
        {
            index = newIndex;
            type = newType;
        }

    }

    public delegate void OnCollisionRectChangeDelegateExt(string type, int index);
}
