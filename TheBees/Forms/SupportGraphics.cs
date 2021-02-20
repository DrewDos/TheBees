using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TheBees.UnitData;
using TheBees.UnitData.Node;
using TheBees.GameRom;

namespace TheBees.Forms
{
    public partial class SupportGraphics : Form
    {
        private ActiveDataElement activeData = new ActiveDataElement();
        private PropertyGroup baseGroup = null;
        private PropertyGroup supportGroup = null;
        //private Unit unit;

        private int unitNum = 0;
        private int unitNumPrev = -1;
        private int baseIndexNum = 0;

        private ComboBox [] giBoxes = new ComboBox[4];
        private TabSupportGfx[] sgTabs = new TabSupportGfx[4];
        private UnitSelector unitSelector = null;

        private SpriteViewer viewer;
        private Dictionary<int, int> spriteIndexMap = new Dictionary<int, int>();

        static private General.BasicDelegate updateComplete = null;
        static public General.BasicDelegate UpdateComplete { set { updateComplete = value; } }

        public SupportGraphics()
        {
            InitializeComponent();
            Initialize();

            viewer = new SpriteViewer();
            viewer.Panel.SetModifyMode(ModifyMode.Sprite);
            viewer.Panel.SpriteOffsetChanged = OnSpriteOffsetChanged;

            unitSelector = new UnitSelector(cbUnit, cbCategoryRef, cbActionRef, cbDataRef);
            unitSelector.ListMode = GroupListMode.ByAction;
            unitSelector.MotionIndexesOnly = true;
            unitSelector.CompleteSettings();
            unitSelector.LoadFromUnit();
            unitSelector.SelectComplete = OnUnitDataSelect;
            unitSelector.SelectUnit = OnSelectUnit;
            //cbUnit.Items.AddRange(Description.DescSpec.UnitNamesFromRomIndex);
            //cbUnit.SelectedIndex = unitNum;
            UpdateUnitSelect();
        }

        private void Initialize()
        {
            sgTabs[0] = supportGfx1;
            sgTabs[1] = supportGfx2;
            sgTabs[2] = supportGfx3;
            sgTabs[3] = supportGfx4;

            InitSGData();

        }

        private void InitSGData()
        {
            for (int i = 0; i < sgTabs.Length; i++)
            {
                int value = i;
                sgTabs[i].ActiveData = activeData;
                //sgTabs[i].CloneQualify = CloneQualifier.Node;
                //sgTabs[i].AddClone(sgTabs);
                Array.ForEach(sgTabs, (x) => sgTabs[i].AddClone(x));
                //sgTabs[i].OnEditChanged = (layout, edit) => { if ((string)edit.Tag != "duration") { sgTabs[value].UpdateNode(); OnUpdateComplete();  UpdateDisplay(); } };
                giBoxes[i] = sgTabs[i].GraphicIndexCombo;
                //giBoxes[i].SelectionChangeCommitted += (x, y) => { UpdateGraphicNodeSelect(value, sgTabs[value].GraphicIndexCombo.SelectedIndex); };
                sgTabs[i].GraphicsChangedEvent += () => { OnGraphicsChanged(value); };
               
            }
        }
        private void UpdateUnitSelect()
        {
            if (unitNum != unitNumPrev)
            {
                activeData.SetUnit(UnitHandler.GetUnit(unitNum));
                baseGroup = activeData.Unit.GetPropertyGroup(PropertyType.SupportGraphicsExt);
                supportGroup = activeData.Unit.GetPropertyGroup(PropertyType.SupportGraphics);

                if (baseGroup != null)
                {
                    cbBaseIndex.Items.Clear();
                    cbBaseIndex.Items.AddRange(Description.DescSpec.GetIndexedList(baseGroup));

                    baseIndexNum = 0;
                    cbBaseIndex.SelectedIndex = baseIndexNum;
                    UpdateBaseIndexSelect();
                }
                else
                {
                    // disable controls
                }
                unitNumPrev = unitNum;
            }
        }

        private void UpdateBaseIndexSelect()
        {
            activeData.SetDataNode(baseGroup.GetNode(baseIndexNum));
            PopulateTabs();
        }

        private void PopulateTabs()
        {
            int[] indexes = new int[4];

            indexes[0] = (int)activeData.Data.GetValue("gfxIndex1");
            indexes[1] = (int)activeData.Data.GetValue("gfxIndex2");
            indexes[2] = (int)activeData.Data.GetValue("gfxIndex3");
            indexes[3] = (int)activeData.Data.GetValue("gfxIndex4");

            for (int i = 0; i < 4; i++)
            {
                sgTabs[i].LoadNodeByGfxIndex(indexes[i]);
                //giBoxes[i].SelectedIndex = indexes[i];
            }

            UpdateDisplay();
        }

        

        private void UpdateDisplay()
        {
            List<SupportGraphicSpec> specList = new List<SupportGraphicSpec>();
            HashSet<int> indexHash = new HashSet<int>();

            spriteIndexMap.Clear();

            for(int i = 0; i < sgTabs.Length; i++)
            {
                SupportGraphicSpec supportNode = ((SupportGraphicSpec)sgTabs[i].Node);
                if(supportNode.SpriteIndex != 0)
                {
                    specList.Add(supportNode);
                }

            }

            Motion unitMotion = null;
            if (unitSelector.ActiveData.Data.GetType() == typeof(Motion))
            {
                unitMotion = (Motion)unitSelector.ActiveData.Data;
            }

            MotionRequest motionRequest = DisplayHelper.GetRequestsFromRange(activeData.Unit, unitMotion, specList.ToArray());

            foreach (KeyValuePair<DataNode, int> mapRef in motionRequest.Map)
            {
                if (mapRef.Key == unitMotion)
                {
                    motionRequest.Requests[mapRef.Value].LockMovement = true;
                }

                int foundIndex = sgTabs.ToList().FindIndex(x => x.Node == mapRef.Key);
                if (foundIndex >= 0)
                {
                    spriteIndexMap[mapRef.Value] = foundIndex;

                }
            }
            viewer.ShowNormalSprite(motionRequest.Requests);
        }

        private void UpdateGraphicNodeSelect(int supportIndex, int value)
        {
            sgTabs[supportIndex].LoadNode(supportGroup.GetNode(value));
            SupportGraphicSpecExt nodeGfxExt = (SupportGraphicSpecExt)activeData.Data;
            switch (supportIndex)
            {
                case 0:
                    nodeGfxExt.Graphic1 = value;
                    break;
                case 1:
                    nodeGfxExt.Graphic2 = value;
                    break;
                case 2:
                    nodeGfxExt.Graphic3 = value;
                    break;
                case 3:
                    nodeGfxExt.Graphic4 = value;
                    break;
            }

            OnUpdateComplete();
            UpdateDisplay();
        }

        private void OnTestCheckChanged(object sender, EventArgs e)
        {
            //supportGfx2.ShowText = checkBox1.Checked;
        }

        private void OnBaseIndexChanged(object sender, EventArgs e)
        {
            baseIndexNum = cbBaseIndex.SelectedIndex;
            UpdateBaseIndexSelect();
        }

        private void OnUnitDataSelect()
        {
            baseIndexNum = ((Motion)unitSelector.ActiveData.Data).SupportGfxIndex;
            cbBaseIndex.SelectedIndex = baseIndexNum;
            UpdateBaseIndexSelect();
        }

        private void OnSelectUnit()
        {
            unitNum = cbUnit.SelectedIndex;
            UpdateUnitSelect();
        }

        private void OnShow(object sender, EventArgs e)
        {
            viewer.Show(this);
        }

        private void OnSpriteOffsetChanged(int index, int xPos, int yPos)
        {
            index = spriteIndexMap[index];
            yPos *= -1;
            sgTabs[index].ControlSet.GetControlByKey("xPos").Value = (uint)xPos;
            sgTabs[index].ControlSet.GetControlByKey("yPos").Value = (uint)yPos;
            ((SupportGraphicSpec)sgTabs[index].Node).XPos = (short)xPos;
            ((SupportGraphicSpec)sgTabs[index].Node).YPos = (short)yPos;

        }

        private void OnGraphicsChanged(int index)
        {
            sgTabs[index].UpdateNode();
            OnUpdateComplete();
            UpdateDisplay();
        }

        private void OnTab1EditChanged(NodeLayout layout, BitEdit edit)
        {

        }
        
        static private void OnUpdateComplete()
        {
            if (updateComplete != null)
            {
                updateComplete();
            }
        }
    }
}
