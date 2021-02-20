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
using TheBees.User;
using TheBees.Forms.Verification;

namespace TheBees.Forms
{
    public partial class ModifyCharacterPallet : Form
    {
        private bool preventSideUpdate = false;
        private bool preventSetOptionUpdate = false;
        private bool preventTypeUpdate = false;
        private bool preventLimitUpdate = false;

        private int spriteIndex;
        private int unitIndex;
        private int groupIndex;
        private int palletIndex;
        private int limitIndex;

        private int startLimitIndex = 0;
        private int startNewIndex = 0;

        private UnitPalletSideIndex sideIndex;
        private UnitPalletType activePalletType;

        private UnitCharacter unit;
        private bool selectByRaw = false;

        private SpriteViewer spriteViewer;
        private PalletModifier palletModifier;

        private Color[] activePallet;

        private DirectionalKeyAction keyAction;

        // not yet implemented

        //private VerifyHandler verification;
        //private VerifyManual verifyAxis;
        //private VerifyManual verifyPallet;

        public ModifyCharacterPallet()
        {
            InitializeComponent();
            Initialize();

        }
        
        private void Initialize()
        {
            keyAction = new DirectionalKeyAction(true);
            keyAction.LeftEvent += () => tbSpriteIndex.Decrease();
            keyAction.RightEvent += () => tbSpriteIndex.Increase();

            cbUnitSel.Items.AddRange(Description.DescSpec.UnitNamesFromRomIndex);
            tbSpriteIndex.MaxValue = SpriteSpec.MaxSpriteIndex-1;
            //tbUnitIndex.MaxValue = UnitData.UnitSpec.CharacterUnitCount;
            tbGroupIndex.MaxValue = UnitData.UnitSpec.UnitPalletNumGroups-1;
            //tbPalletIndex.MaxValue = UnitData.UnitSpec.UnitPalletSideSize / UnitData.UnitSpec.UnitPalletNumGroups / UnitData.UnitSpec.PalletIndexSize;

            tbSpriteIndex.Value = 0;
            cbUnitSel.SelectedIndex = 0;
            tbGroupIndex.Value = 0;
            tbPalletIndex.Value = 0;

            spriteIndex = 0;
            unitIndex = 0;
            groupIndex = 0;
            palletIndex = 0;
            limitIndex = 0;

            spriteViewer = new SpriteViewer();
            spriteViewer.Panel.SetModifyMode(ModifyMode.None);
            spriteViewer.Panel.SpriteOffsetChanged = AxisChanged;
            spriteViewer.CtrlKeyAction = keyAction;

            unit = (UnitCharacter)UnitHandler.GetUnit(0);

            palletModifier = new PalletModifier(new ColorAdjuster(trackRed, trackGreen, trackBlue), palletControl);
            palletModifier.Adjuster.SetMode(TrackMode.Set);
            palletModifier.UpdatePallet = OnUpdatePallet;

            preventLimitUpdate = true;
            UpdateEnableSpriteSelect();
            chkLimitRegion.Checked = SpriteRegionGuide.SpriteRegions.Count > 0;
            chkLimitSession.Checked = !chkLimitRegion.Checked && SpriteSessionGuide.CreationReferences.Count > 0;
            preventLimitUpdate = false;
            //cbLimitSelect.Enabled = false;
            //cbLimitSelect.SelectedIndex = limitIndex;


            sideIndex = UnitPalletSideIndex.Left;
            preventSideUpdate = true;
            rbSideLeft.Checked = true;
            preventSideUpdate = false;

            activePalletType = UnitPalletType.Normal;
            preventTypeUpdate = true;
            rbTypeNormal.Checked = true;
            preventTypeUpdate = false;

            preventSetOptionUpdate = true;
            rbSetColor.Checked = true;
            preventSetOptionUpdate = false;

            UpdateGroupSelect();
            UpdateLimitChecked();


            //UpdatePalletSelect();
        }


        ////////////////////////////////////////
        // updates
        ////////////////////////////////////////

        private void UpdateTypeSelect(UnitPalletType newType)
        {
            if (newType != activePalletType)
            {
                activePalletType = newType;
                UpdateGroupSelect();
            }
        }

        private void UpdateSideSelect(UnitPalletSideIndex newSideIndex)
        {
            if (newSideIndex != sideIndex)
            {
                sideIndex = newSideIndex;
                UpdateGroupSelect();
            }

        }

        private void UpdateUnitSelect()
        {
            unit = (UnitCharacter)UnitHandler.GetUnit(unitIndex);
            tbGroupIndex.Value = 0;
            groupIndex = 0;
            UpdateGroupSelect();
        }
        private void UpdateGroupSelect()
        {
            tbPalletIndex.Value = 0;
            tbPalletIndex.MaxValue = (uint)unit.PalletSet.GetIndexCount(activePalletType)-1;
            palletIndex = 0;
            UpdatePalletSelect();
        }

        private void OnUpdatePallet(Color [] newPallet)
        {
            activePallet = newPallet;
            spriteViewer.Panel.UpdatePallet(0, newPallet);
            spriteViewer.Panel.Invalidate();

            unit.PalletSet.SetPallet(activePalletType, sideIndex, groupIndex, palletIndex, newPallet);

        }

        private void UpdatePalletSelect()
        {
            uint targetAddress = 0;

            if (!selectByRaw)
            {
                targetAddress = unit.PalletSet.GetPalletAddress(activePalletType, sideIndex, groupIndex, palletIndex);
            }

            activePallet = Pallet.GetPallet(targetAddress);
            Color[] palletCopy = new Color[activePallet.Length];
            palletControl.LoadPallet(activePallet);
            Array.Copy(activePallet, palletCopy, activePallet.Length);
            palletModifier.SetBasePallet(palletCopy);

            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            if (spriteViewer.Visible)
            {
                if (spriteIndex != -1)
                {
                    bool select = chkModifyAxis.Checked;
                    SpriteRequest req = new SpriteRequest(spriteIndex, activePallet, 0, 0, false, false, !select);
                    if (spriteViewer.ShowNormalSprite(new List<SpriteRequest>() { req }))
                    {
                        if (select)
                            spriteViewer.Panel.SelectSprite(0);
                    }
                }
                else
                {
                    spriteViewer.Clear();
                }
            }
        }

        private void UpdateRegionNames()
        {
            cbLimitSelect.Items.AddRange(SpriteRegionGuide.GetRegionNames());
        }

        private void UpdateSessionNames()
        {
            cbLimitSelect.Items.AddRange(SpriteSessionGuide.GetSessionNames());
        }

        private void UpdateLimitChecked()
        {
            cbLimitSelect.Items.Clear();

            if (chkLimitRegion.Checked)
            {
                if (SpriteRegionGuide.SpriteRegions.Count == 0)
                    throw new Exception("No regions available");

                cbLimitSelect.Enabled = true;
                UpdateRegionNames();

                SpriteRegion region = SpriteRegionGuide.SpriteRegions.Find((x) => x.StartIndex <= spriteIndex && x.LastIndex >= spriteIndex);
                limitIndex = region == null ? 0 : SpriteRegionGuide.SpriteRegions.IndexOf(region);
                cbLimitSelect.SelectedIndex = limitIndex;

                UpdateRegionSelect();
            }
            else if (chkLimitSession.Checked)
            {
                if (SpriteSessionGuide.CreationReferences.Count == 0)
                    throw new Exception("No creation references available");

                cbLimitSelect.Enabled = true;
                UpdateSessionNames();
                limitIndex = startLimitIndex;
                cbLimitSelect.SelectedIndex = limitIndex;
                UpdateSessionSelect();
            }
            else
            {
                cbLimitSelect.Enabled = false;
                EnableSpriteIndex();
                tbSpriteIndex.SetMode(BitEditMode.Ranged);
                tbSpriteIndex.MinValue = 0;
                tbSpriteIndex.MaxValue = SpriteSpec.MaxSpriteIndex;
            }
        }


        private void UpdateRegionSelect()
        {
            EnableSpriteIndex();
            tbSpriteIndex.SetMode(BitEditMode.Ranged);
            SpriteRegion region = SpriteRegionGuide.SpriteRegions[limitIndex];
            tbSpriteIndex.MinValue = (uint)region.StartIndex;
            tbSpriteIndex.MaxValue = (uint)region.LastIndex;

            if (spriteIndex < region.StartIndex || spriteIndex > region.LastIndex)
            {
                spriteIndex = region.StartIndex;
                tbSpriteIndex.Value = (uint)spriteIndex;
                UpdateDisplay();
            }
        }

        private void UpdateSessionSelect()
        {
            SpriteSessionRef session = SpriteSessionGuide.CreationReferences[limitIndex];
            if (session.Indexes.Length > 0)
            {
                EnableSpriteIndex();
                List<uint> indexes = new List<uint>();
                Array.ForEach(session.Indexes, (x) => indexes.Add((uint)x));
                tbSpriteIndex.SetMode(BitEditMode.ByValues, indexes.ToArray());

                spriteIndex = (int)indexes[startNewIndex];
                tbSpriteIndex.SetValue((uint)spriteIndex);
            }
            else
            {
                EnableSpriteIndex(false);
                spriteIndex = -1;
            }

            UpdateDisplay();
        }

        private void EnableSpriteIndex(bool enable = true)
        {
            tbSpriteIndex.Enabled = enable;
        }

        private void UpdateEnableSpriteSelect()
        {            
            chkLimitSession.Enabled = SpriteSessionGuide.CreationReferences.Count > 0;
            chkLimitRegion.Enabled = SpriteRegionGuide.SpriteRegions.Count > 0;
        }
        
        ////////////////////////////////////////
        // basic functions
        ////////////////////////////////////////

        private void AxisChanged(int index, int xPos, int yPos)
        {
            NormalSprite sprite = spriteViewer.Panel.GetSpriteInfo(index).Sprite;

            SpriteMap.UpdateSpriteAxis(spriteIndex, (short)(sprite.AxisX + xPos), (short)(sprite.AxisY + yPos));
        }

        ////////////////////////////////////////
        // events
        ////////////////////////////////////////

        private void OnCheckSideLeft(object sender, EventArgs e)
        {
            if (rbSideLeft.Checked && !preventSideUpdate)
            {
                UpdateSideSelect(UnitPalletSideIndex.Left);
            }
        }

        private void OnCheckSideRight(object sender, EventArgs e)
        {

            if (rbSideRight.Checked && !preventSideUpdate)
            {
                UpdateSideSelect(UnitPalletSideIndex.Right);
            }
        }

        private void OnPalletIndexChanged(object sender, EventArgs e)
        {
            if (((BitEdit)sender).ChangeType == BitEditChange.Input)
            {
                if (palletIndex != tbPalletIndex.Value)
                {
                    palletIndex = (int)tbPalletIndex.Value;
                    UpdatePalletSelect();

                }
            }
        }

        private void OnGroupNumberChanged(object sender, EventArgs e)
        {
            if (((BitEdit)sender).ChangeType == BitEditChange.Input)
            {
                if (groupIndex != tbGroupIndex.Value)
                {
                    groupIndex = (int)tbGroupIndex.Value;
                    UpdatePalletSelect();

                }
            }
        }

        private void OnChangeSpriteIndex(object sender, EventArgs e)
        {
            if (((BitEdit)sender).ChangeType == BitEditChange.Input)
            {
                if (spriteIndex != tbSpriteIndex.Value)
                {
                    spriteIndex = (int)tbSpriteIndex.Value;
                    UpdateDisplay();
                }
            }
        }

        private void OnSelectUnitFromCombo(object sender, EventArgs e)
        {

            if (unitIndex != cbUnitSel.SelectedIndex)
            {
                unitIndex = cbUnitSel.SelectedIndex;
                UpdateUnitSelect();

            }
        }


        private void OnShown(object sender, EventArgs e)
        {
            spriteViewer.Show(this);
            UpdateDisplay();
            //OnClickRemoveSprites(sender, e);
        }

        private void OnCheckSetColor(object sender, EventArgs e)
        {
            if (!preventSetOptionUpdate && rbSetColor.Checked)
            {
                palletModifier.Adjuster.SetMode(TrackMode.Set);
            }
        }

        private void OnCheckAdjustColor(object sender, EventArgs e)
        {

            if (!preventSetOptionUpdate && rbAdjustColor.Checked)
            {
                palletModifier.Adjuster.SetMode(TrackMode.Adjust);
            }
        }

        private void OnClickTypeEX(object sender, EventArgs e)
        {
            if (rbTypeEX.Checked && !preventTypeUpdate)
            {
                UpdateTypeSelect(UnitPalletType.EX);
            }
        }

        private void OnClickTypeDim(object sender, EventArgs e)
        {
            if (rbTypeDim.Checked && !preventTypeUpdate)
            {
                UpdateTypeSelect(UnitPalletType.Dim);
            }
        }

        private void OnClickTypeNormal(object sender, EventArgs e)
        {
            if (rbTypeNormal.Checked && !preventTypeUpdate)
            {
                UpdateTypeSelect(UnitPalletType.Normal);
            }
        }

        private void OnRegionSelectChanged(object sender, EventArgs e)
        {
            if (cbLimitSelect.SelectedIndex != limitIndex)
            {
                limitIndex = cbLimitSelect.SelectedIndex;
                if (chkLimitRegion.Checked)
                {
                    UpdateRegionSelect();
                }
                else if(chkLimitSession.Checked)
                {
                    UpdateSessionSelect();
                }
            }
        }

        private void OnClickAddSprites(object sender, EventArgs e)
        {
            SpriteManager sm = new SpriteManager();
            sm.ShowDialog();

            if (sm.SessionIndex != -1 && sm.SelectedNewIndex != -1)
            {
                startLimitIndex = sm.SessionIndex;
                startNewIndex = sm.SelectedNewIndex;

                UpdateEnableSpriteSelect();

                preventLimitUpdate = true;
                chkLimitSession.Checked = true;
                preventLimitUpdate = false;

                OnLimitSessionCheckedChanged(chkLimitSession, EventArgs.Empty);
                
                startLimitIndex = 0;
                startNewIndex = 0;
            }
        }

        private void OnClickRemoveSprites(object sender, EventArgs e)
        {
            RemoveSprites rs = new RemoveSprites();
            rs.ShowDialog();

            if (rs.RegionsModified && chkLimitRegion.Checked)
            {
                cbLimitSelect.Items.Clear();

                if (SpriteRegionGuide.SpriteRegions.Count == 0)
                {
                    chkLimitRegion.Checked = false;
                    chkLimitRegion.Enabled = false;
                    cbLimitSelect.Enabled = false;
                    UpdateDisplay();
                }
                else
                {
                    UpdateRegionNames();
                    limitIndex = 0;
                    cbLimitSelect.SelectedIndex = 0;
                    UpdateSessionSelect();
                }
            }

            if (rs.SessionsModified && chkLimitSession.Checked)
            {
                cbLimitSelect.Items.Clear();

                if (SpriteSessionGuide.CreationReferences.Count == 0)
                {
                    chkLimitSession.Checked = false;
                    chkLimitSession.Enabled = false;
                    cbLimitSelect.Enabled = false;
                    UpdateDisplay();
                }
                else
                {
                    UpdateSessionNames();
                    limitIndex = 0;
                    cbLimitSelect.SelectedIndex = 0;
                    UpdateRegionSelect();
                    
                }
            }
        }


        private void OnLimitByRegionChanged(object sender, EventArgs e)
        {
            if (!preventLimitUpdate)
            {
                if (chkLimitRegion.Checked)
                {
                    preventLimitUpdate = true;
                    chkLimitSession.Checked = false;
                    preventLimitUpdate = false;
                }

                UpdateLimitChecked();
            }
        }
        private void OnLimitSessionCheckedChanged(object sender, EventArgs e)
        {
            if (!preventLimitUpdate)
            {
                if (chkLimitSession.Checked)
                {
                    preventLimitUpdate = true;
                    chkLimitRegion.Checked = false;
                    preventLimitUpdate = false;
                }

                UpdateLimitChecked();
            }
        }


        private void ModifyAxisCheckedChanged(object sender, EventArgs e)
        {
            if (chkModifyAxis.Checked)
            {
                spriteViewer.Panel.SetModifyMode(ModifyMode.Sprite);
                UpdateDisplay();
            }
            else
            {
                spriteViewer.Panel.SetModifyMode(ModifyMode.None);
                UpdateDisplay();
            }
        }

        private void OnClickLoadPallet(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "ACT Files (*.ACT)|*.act";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                palletModifier.SetPallet(SpriteCreator.PalletFile.Get(dlg.FileName));

            }
        }



        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyAction.Process(ModifierKeys, keyData))
                return true;

            return base.ProcessCmdKey(ref msg, keyData);
        }

    }
}
