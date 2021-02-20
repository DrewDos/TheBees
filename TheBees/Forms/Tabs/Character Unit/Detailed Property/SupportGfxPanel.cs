using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TheBees.UnitData.Node;
using TheBees.General;
using TheBees.GameRom;
using TheBees.Forms.Support.DataControl;
using TheBees.Description;
using TheBees.UnitData;

namespace TheBees.Forms
{
    public partial class TabSupportGfx : NodeLayout
    {
        private int changedIndex;
        private int primaryIndex;

        private bool preventCheckCallback = false;
        SupportGraphicSpec gfxNode = null;
        public ComboBox GraphicIndexCombo { get { return cbGraphicIndex; } }
        private int startWidth;

        private bool showOld;
        private Control[] labels;
        private Control[] dataControls;
        private Control[] checkBoxes;
        private bool showText = true;
        public bool ShowText { get { return showText; } set { showText = value; UpdateTextDisplay(); } }

        public event Action<int> PrimaryIndexChanged;
        public event Action GraphicsChangedEvent;

        public TabSupportGfx()
            : base(null)
        {
            //InitializeComponent();
            showOld = showText;
            startWidth = this.Width;
            GetControls();

        }
        public TabSupportGfx(ActiveDataElement source = null, bool sourceShowText = true)
            : base(source)
        {
            //InitializeComponent();
            showOld = showText;
            startWidth = this.Width;
            GetControls();
        }


        protected override void RegisterControls()
        {
            tbSpriteIndex.MaxValue = 0xFFFF;
            tbPalletIndex.MaxValue = 0xFFFF;
            tbXPos.MaxValue = 0xFFFF;
            tbYPos.MaxValue = 0xFFFF;
            tbDuration.MaxValue = 0xFFFF;
            tbLayerValue.MaxValue = 0xFFFF;

            ControlSet.RegisterControl(tbSpriteIndex, "spriteIndex", GraphicsChanged);
            ControlSet.RegisterControl(tbPalletIndex, "pallet", GraphicsChanged);
            ControlSet.RegisterControl(tbXPos, "xPos", GraphicsChanged);
            ControlSet.RegisterControl(tbYPos, "yPos", GraphicsChanged);
            ControlSet.RegisterControl(tbDuration, "duration");
            ControlSet.RegisterControl(tbLayerValue, "frontOrBack", GraphicsChanged);
            ControlSet.RegisterControl(chkFlipX, new Ref<uint>(() => (uint)(gfxNode.FlipX ? 1 : 0), (x) => { gfxNode.FlipX = x > 0 ? true : false; }), GraphicsChanged);
            ControlSet.RegisterControl(chkFlipY, new Ref<uint>(() => (uint)(gfxNode.FlipY ? 1 : 0), (x) => { gfxNode.FlipY = x > 0 ? true : false; }), GraphicsChanged);
            ControlSet.RegisterControl(cbJump, "jumpTo");
            ControlSet.RegisterControl(cbGraphicIndex, new Ref<uint>(() => { return (uint)primaryIndex; }, (x) => changedIndex = (int)x), GraphicIndexChanged)
                .CaptureVerification = false;

        }

        public override void LoadNode(DataNode newNode)
        {
            gfxNode = ((UnitData.Node.SupportGraphicSpec)newNode);

            base.LoadNode(newNode);
        }

        private void GraphicsChanged(DataControlEventParams p)
        {
            if (GraphicsChangedEvent != null)
                GraphicsChangedEvent();

            OnChangeValue(p);

        }
        private void GetControls()
        {
            labels = new Control[]
            {
                label1,
                label2,
                label3,
                label4,
                label5,
                label6,
                label7,
                label8
            };

            dataControls = new Control[]
            {
                tbDuration,
                tbLayerValue,
                tbSpriteIndex,
                tbPalletIndex,
                tbXPos,
                tbYPos,
                cbJump,
                cbGraphicIndex
            };

            checkBoxes = new Control[]
            {
                chkFlipX,
                chkFlipY
            };

        }

        protected override void OnPrimaryCancel()
        {
            cbGraphicIndex.SelectedIndex = primaryIndex;
            base.OnPrimaryCancel();
        }

        protected override void OnPrimaryProceed()
        {
            primaryIndex = changedIndex;
            LoadNodeByGfxIndex(primaryIndex);
            base.OnPrimaryProceed();
        }

        protected override void OnLoadNode()
        {
            if (unitChanged)
            {
                string[] list = DescSpec.GetIndexedList(activeData.Unit.GetPropertyGroup(PropertyType.SupportGraphics));

                cbGraphicIndex.Items.Clear();
                cbGraphicIndex.Items.AddRange(list);

                cbJump.Items.Clear();
                cbJump.Items.AddRange(list);
            }

            cbGraphicIndex.SelectedIndex = primaryIndex;
            cbJump.SelectedIndex = (int)gfxNode.GetValue("jumpTo");

            base.OnLoadNode();
        }

        public void LoadNodeByGfxIndex(int index)
        {
            primaryIndex = index;
            LoadNode(activeData.Unit.GetPropertyGroup(PropertyType.SupportGraphics).GetNode(index));
        }

        private void UpdateTextDisplay()
        {
            int newXPos = 0;
            int newCheckXPos = 0;

            if (showOld != showText)
            {
                if (showText)
                {
                    newXPos = 60;
                    newCheckXPos = 60;
                    this.Width += 60;

                }

                this.Width = startWidth + newXPos;

                foreach (Label label in labels)
                {
                    label.Visible = showText;
                }

                foreach (Control control in dataControls)
                {
                    control.Left = newXPos;
                }

                foreach (CheckBox checkBox in checkBoxes)
                {
                    checkBox.Left = newCheckXPos;
                }

                propertyToolset1.Left = newXPos;
                showOld = showText;

            }
        }
        private void JumpChanged(DataControlEventParams p)
        {
        }

        private void GraphicIndexChanged(DataControlEventParams p)
        {
            if (Verification.Confirm("Update current changes?", "Update current changes?"))
            {
                if (PrimaryIndexChanged != null)
                    PrimaryIndexChanged(primaryIndex);
            }
        }

        private void UpdateGraphicIndexes()
        {
            int itemCount = activeData.Unit.GetPropertyGroup(UnitData.PropertyType.SupportGraphics).Count;
            int itemCountPrev = cbJump.Items.Count;

            if (itemCount < itemCountPrev)
            {
                for (int i = 0; i < itemCount - itemCountPrev; i++)
                {
                    cbJump.Items.RemoveAt(itemCount - 1 - i);
                    cbGraphicIndex.Items.RemoveAt(itemCount - 1 - i);
                }
            }
            else if (itemCount > itemCountPrev)
            {
                string[] items = Description.DescSpec.GetIndexedList(itemCount, itemCountPrev);
                cbJump.Items.AddRange(items);
                cbGraphicIndex.Items.AddRange(items);
            }

        }
    }
}
