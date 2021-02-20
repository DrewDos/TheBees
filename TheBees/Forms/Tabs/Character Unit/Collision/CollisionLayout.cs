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
    public partial class CollisionLayout : NodeLayout
    {
        public Action<int> OnCollisionInputValueChanged = null;
        public Action<int> OnCollisionRawValueChanged = null;
        public Action OnUpdateCollisionNode = null;

        private string[] keys = null;
        private BitEdit[] edits = null;

        private bool isClsn16;

        public CollisionLayout(ActiveDataElement source)
            :base(source)
        {
        }

        protected override void RegisterControls()
        {
            if (keys == null && edits == null)
            {
                keys = NodeSpec.GetAllCollisionKeys();

                edits = new BitEdit[]
                {
                        tbClsnX1Start, tbClsnX1Width, tbClsnY1Start, tbClsnY1Width,
                        tbClsnX2Start, tbClsnX2Width, tbClsnY2Start, tbClsnY2Width,
                        tbClsnX3Start, tbClsnX3Width, tbClsnY3Start, tbClsnY3Width,
                        tbClsnX4Start, tbClsnX4Width, tbClsnY4Start, tbClsnY4Width
                };

                for (int i = 0; i < keys.Length; i++)
                {
                    edits[i].Tag = i;
                    edits[i].MaxValue = 0xFFFF;
                    edits[i].TextChanged += OnChangeBitEdit;
                }

            }
            bool suspend;

            for (int i = 0; i < keys.Length; i++)
            {
                suspend = i >= 4 && !isClsn16;
                ControlSet.RegisterControl(edits[i], keys[i], suspendData: suspend);
            }
        }
        public void PopulateBox(int index)
        {
            for (int i = index * 4; i < index * 4 + 4; i++)
            {
                ControlSet.Controls[i].UpdateControl();
            }
        }

        private void UpdateBox(int index)
        {
            for (int i = index * 4; i < index * 4 + 4; i++)
            {
                ControlSet.Controls[i].UpdateValue();
            }
        }

        public override void UpdateNode()
        {
            base.UpdateNode();

            if (OnUpdateCollisionNode != null)
            {
                OnUpdateCollisionNode();
            }
        }

        public override void LoadNode(DataNode newNode)
        {
            isClsn16 = newNode.GetNodeType() == NodeType.Collision16;
            base.LoadNode(newNode);
        }
        private void OnChangeBitEdit(object sender, EventArgs e)
        {
            if (((BitEdit)sender).ChangeType == BitEditChange.Input)
            {
                int index = (int)Convert.ToInt32(((BitEdit)sender).Tag);
                UpdateBox(index / 4);

                ControlSet.Verification.Pending = true;

                if (OnCollisionInputValueChanged != null)
                {
                    OnCollisionInputValueChanged(index);
                }
            }
        }
    }
}
