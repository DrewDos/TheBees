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
    public partial class FCReference : NodeLayout
    {
        private UnitSelector selector;
        private FunctionCall functionNode;
        private bool populating = true;
        private FunctionCallPanel parent;

        public event Action<int, int, int> JumpToEvent;
        public event Action ReferenceInvalidEvent;
        public FCReference(ActiveDataElement source)
            : base(source)
        {
            selector = new UnitSelector(null, cbCategoryIndex, cbActionIndex, cbDataIndex);
            selector.ActiveData = source;
            selector.CompleteSettings();
            selector.LoadFromUnit(activeData.Unit.Index);
            selector.SelectComplete += OnSelectComplete;
        }

        public override void PopulateControls()
        {
            populating = true;
            //selector.MakeSelection(-1, FunctionMap.GameReferenceMap[(int)functionNode.Value1], (int)functionNode.Value2, activeData.Action.GetFromRealIndex((int)functionNode.Value3 + 1), true);
            int groupNum = FunctionMap.GameReferenceMap[(int)functionNode.Value1];
            int dataNum = 0;
            try
            {

                activeData.Unit.GetActionGroup((ActionType)groupNum).GetAction((int)functionNode.Value2).GetFromRealIndex((int)functionNode.Value3);
                selector.MakeSelection(-1, groupNum, (int)functionNode.Value2, dataNum, true);
                base.PopulateControls();
            }
            catch
            {
                InvalidReference();
            }
            populating = false;

        }

        public override void LoadNode(DataNode newNode)
        {
            functionNode = (FunctionCall)newNode;
            base.LoadNode(newNode);
        }

        private void OnSelectComplete()
        {
            if (populating)
                return;

            functionNode.Value1 = (uint)Array.IndexOf(FunctionMap.GameReferenceMap, selector.GroupNum);
            functionNode.Value2 = (uint)selector.ActionNum;
            functionNode.Value3 = (uint)activeData.Action.GetRealFromListIndex(selector.DataNum - 1 < 0 ? 0 : selector.DataNum);

            OnChangeValue(null);
        }

        private void OnClickJumpTo(object sender, EventArgs e)
        {
            if (JumpToEvent != null)
            {
                JumpToEvent(FunctionMap.GameReferenceMap[(int)functionNode.Value1], (int)functionNode.Value2, activeData.Action.GetFromRealIndex((int)functionNode.Value3));
            }
        }

        private void InvalidReference()
        {
            cbActionIndex.Items.Clear();
            cbActionIndex.Enabled = false;
            cbDataIndex.Items.Clear();
            cbDataIndex.Enabled = false;
            cbCategoryIndex.Items.Clear();
            cbCategoryIndex.Enabled = false;

            if (ReferenceInvalidEvent != null)
                ReferenceInvalidEvent();
        }
    }
}
