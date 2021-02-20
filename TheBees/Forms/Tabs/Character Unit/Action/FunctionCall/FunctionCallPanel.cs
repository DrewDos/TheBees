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

namespace TheBees.Forms
{
    public partial class FunctionCallPanel : NodeLayout
    {
        private FunctionCall functionNode;
        private NodeLayout currLayout;
        private FunctionType currType = FunctionType.Null;
        private ActiveDataElement parentActiveData = null;
        public Action<int, int, int> JumpToAction = null;
        private bool referenceInvalid = false;

        public FunctionCallPanel(ActiveDataElement srcActiveData)
            :base(null)
        {
            parentActiveData = srcActiveData;
            activeData = new ActiveDataElement();
        }

        protected override void  LoadLayout()
        {
            cbFunctionCode.Items.AddRange(FunctionMap.GetFunctionNames());

            base.LoadLayout();
        }

        public override void  LoadNode(DataNode newNode)
        {
            activeData.SetUnit(parentActiveData.Unit);
            functionNode = (FunctionCall)newNode;
            cbFunctionCode.SelectedIndex = functionNode.FunctionCode;
            SetupPanel(functionNode.FunctionCode);
        }

        private void SetupPanel(int functionCode, FunctionType forceType = FunctionType.Null)
        {
            NodeLayout newLayout;
            FunctionType type;
            if (forceType != FunctionType.Null)
            {
                type = forceType;
            }
            else
            {
                type = FunctionMap.GetFunctionType(functionCode);
            }
            activeData.SetUnit(parentActiveData.Unit);

            if (type != currType)
            {
                switch (type)
                {
                    case FunctionType.None:
                        newLayout = new FCBasic();
                        ((FCBasic)newLayout).SetNoSettings();
                        SetPanel(newLayout);
                        break;
                    case FunctionType.FullReference:
                        newLayout = new FCReference(activeData);
                        ((FCReference)newLayout).JumpToEvent += JumpToAction;
                        ((FCReference)newLayout).ReferenceInvalidEvent += ReferenceInvalid;
                        SetPanel(newLayout);
                        break;
                    case FunctionType.Unknown:
                    case FunctionType.Basic:
                        newLayout = new FCBasic();
                        SetPanel(newLayout);
                        break;
                }
            }
            else
            {
                currLayout.LoadNode(functionNode);
            }

            currType = type;

            if (referenceInvalid)
            {
                referenceInvalid = false;
                SetupPanel(functionNode.FunctionCode, FunctionType.None);
            }
            
        }

        protected void GetReferenceSettings(int functionCode)
        {

        }

        private void ReferenceInvalid()
        {
            referenceInvalid = true;
        }

        protected void SetPanel(NodeLayout newLayout)
        {
            if (currLayout != null)
            {
                gbFunctionDetails.Controls.Remove(currLayout);
                currLayout.UnloadNode();
                currLayout = null;
            }
            currLayout = newLayout;
            currLayout.ValueChangedEvent += TriggerValueChangedEvent;
            currLayout.LoadNode(functionNode);
            currLayout.Left = 20;
            currLayout.Top = 20;
            currLayout.Size = new Size(275, 200);
            gbFunctionDetails.Controls.Add(currLayout);
        }

        private void OnCodeChangeCommitted(object sender, EventArgs e)
        {
            SetupPanel(functionNode.FunctionCode);
            functionNode.FunctionCode = cbFunctionCode.SelectedIndex;
            if (functionNode.Buffered) functionNode.ApplyBuffer();
            TriggerValueChangedEvent(null);
        }

    }
}
