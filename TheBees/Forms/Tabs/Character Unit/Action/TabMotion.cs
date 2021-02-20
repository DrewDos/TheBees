using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TheBees.GameRom;
using TheBees.UnitData;
using TheBees.General;

using TheBees.Forms.Support.DataControl;

namespace TheBees.Forms
{
    public partial class TabMotion : NodeLayout
    {
        Motion motionNode;

        private int numGraphicIndexes = 0;
        public int NumGraphicIndexes { set { numGraphicIndexes = value; } }

        public event DataControlObserver OnGraphicValueChanged;

        public TabMotion(ActiveDataElement source)
            : base(source)
        {
        }

        protected override void RegisterControls()
        {
            bool m16 = motionNode.LengthOfDataInBytes >= 16;
            bool m24 = motionNode.LengthOfDataInBytes == 24;

            if (unitChanged)
            {
                tbFramesActive.MaxValue = 0xFF;
                tbSound.MaxValue = 0xFFFF;
                tbGraphic1.MaxValue = (uint)activeData.Unit.PropertyLoader.GetMax(PropertyType.SupportGraphicsExt);
                tbGraphic2.MaxValue = 0xFFFF;
                tbLineJump.MaxValue = 0xFFFF;
                tbGraphic3.MaxValue = 0xFFFF;
                tbZoom.MaxValue = 0xFFFF;
                tbUnknownRef.MaxValue = 0xFFFF;
                tbTweakMotion.MaxValue = 0xFFFF;
                tbLineJumpOnHit.MaxValue = 0xFFFF;
                tbOperationSpec.MaxValue = (uint)activeData.Unit.PropertyLoader.GetMax(PropertyType.ThrownOpponentSpec);
                tbCancelSpec.MaxValue = 0xFFFF;

            }
            // all motions
            ControlSet.RegisterControl(tbFramesActive, "frame");
            ControlSet.RegisterControl(tbJumpFlag, "jumpFlagEtc");
            ControlSet.RegisterControl(tbSound, new Ref<uint>(() => (uint)motionNode.Sound, (x) => motionNode.Sound = (int)x));
            ControlSet.RegisterControl(cbFlipX, new Ref<uint>(() => (uint)(motionNode.FlipX ? 1 : 0), (x) => motionNode.FlipX = x > 0 ? true : false), GraphicValueChanged);
            ControlSet.RegisterControl(cbFlipY, new Ref<uint>(() => (uint)(motionNode.FlipY ? 1 : 0), (x) => motionNode.FlipY = x > 0 ? true : false), GraphicValueChanged);
            ControlSet.RegisterControl(tbGraphic1, new Ref<uint>(() => (uint)motionNode.SupportGfxIndex, (x) => motionNode.SupportGfxIndex = (int)x), GraphicValueChanged);
            ControlSet.RegisterControl(tbGraphic2, new Ref<uint>(() => (uint)motionNode.SpriteIndex, (x) => motionNode.SpriteIndex = (int)x), GraphicValueChanged, "gfx2");

            // motion 16 and up
            ControlSet.RegisterControl(tbUnknownRef, "unknownRef", suspendData: !m16 || m24 ).SetEnableFlag(m16 && !m24);
            ControlSet.RegisterControl(tbTweakMotion, "tweakMotion", suspendData: !m16).SetEnableFlag(m16);
            ControlSet.RegisterControl(tbLineJumpOnHit, "lineJumpOnHitGuard", suspendData: !m16).SetEnableFlag(m16);

            ControlSet.RegisterControl(
                cbCancelHighJump, 
                new Ref<uint>(() => (uint)(motionNode.CancelSuperJump ? 1 : 0), (x) => motionNode.CancelSuperJump = x > 0 ? true : false),
                suspendData: !m16
                ).SetEnableFlag(m16);

            ControlSet.RegisterControl(
                cbCancelDash, 
                new Ref<uint>(() => (uint)(motionNode.CancelDash ? 1 : 0), (x) => motionNode.CancelDash = x > 0 ? true : false),
                suspendData: !m16
                ).SetEnableFlag(m16);

            ControlSet.RegisterControl(
                cbCancelTC,
                new Ref<uint>(() => (uint)(motionNode.CancelTC ? 1 : 0), (x) => motionNode.CancelTC = x > 0 ? true : false),
                suspendData: !m16
                ).SetEnableFlag(m16);

            ControlSet.RegisterControl(
                cbCancelSpecial, 
                new Ref<uint>(() => (uint)(motionNode.CancelSpecial ? 1 : 0), (x) => motionNode.CancelSpecial = x > 0 ? true : false),
                suspendData: !m16
                ).SetEnableFlag(m16);

            ControlSet.RegisterControl(
                cbCancelSuper, 
                new Ref<uint>(() => (uint)(motionNode.CancelSuper ? 1 : 0), (x) => motionNode.CancelSuper = x > 0 ? true : false),
                suspendData: !m16
                ).SetEnableFlag(m16);

            ControlSet.RegisterControl(
                tbCancelSpec,
                new Ref<uint>(() => motionNode.CancelSpec, (x) => motionNode.CancelSpec = x),
                suspendData: !m16
                ).SetEnableFlag(m16);

            
            // motion 24 and up
            ControlSet.RegisterControl(tbLineJump, "lineJump", suspendData: !m24).SetEnableFlag(m24);
            ControlSet.RegisterControl(tbGraphic3, "gfx3", suspendData: !m24).SetEnableFlag(m24);
            ControlSet.RegisterControl(tbZoom, "zoom", suspendData: !m24).SetEnableFlag(m24);
            ControlSet.RegisterControl(
                tbOperationSpec, 
                new Ref<uint>(() => motionNode.ThrownOpponentIndex, (x) => motionNode.ThrownOpponentIndex = x)
                ).SetEnableFlag(m24);
        }

        private void GraphicValueChanged(DataControlEventParams p)
        {
            base.OnChangeValue(p);

            if (OnGraphicValueChanged != null)
                OnGraphicValueChanged(p);
        }
        protected override void OnLoadNode()
        {
            motionNode = (Motion)node;

            base.OnLoadNode();
        }

        protected override void OnLoadLayout()
        {
            base.OnLoadLayout();
        }

        private void OnClickCancelSpecConfig(object sender, EventArgs e)
        {
            CancelConfig cancelDlg = new CancelConfig((ushort)motionNode.CancelSpec);

            if (cancelDlg.ShowDialog() == DialogResult.OK)
            {
                motionNode.CancelSpec = cancelDlg.SpecValue;
                OnChangeValue(new DataControlEventParams(cancelDlg.SpecValue, null));
            }
        }

    }
}
