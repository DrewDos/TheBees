using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TheBees.Forms;
using TheBees.GameRom;
using TheBees.UnitData;

namespace TheBees.Controls
{
    public class ActionDataToolset : DataToolset
    {
        private ActiveDataElement activeData;
        private UnitSelector selector;
        private ActionDataListBox lbDataIndex;
        private ContextMenu extraMenu;

        private MenuItem itemNewMotion, itemNewFunction, itemCopyData, itemPasteData, itemAppendCopiedData;

        private bool CanPasteData
        {
            get
            {
                return Clipboard.ClipboardItem != null
                    && Clipboard.ClipboardItem.DataType == typeof(DataNode)
                    && CheckNodes((DataNode[])(Clipboard.ClipboardItem).GetItems());
            }
        }

        private bool CanAppendFromClipboard
        {
            get
            {
                return CanPasteData && !selector.ActiveData.Action.HasBaseFooter;
            }
        }

        private bool CanCopyData 
        { 
            get 
            {
                if(lbDataIndex.GetSelectedIndices().Length > 0)
                {
                    return CheckNodes(activeData.Action.GetNodesFromIndexes(lbDataIndex.GetSelectedIndices()));
                }

                return false;
            }
        }

        private bool CheckNodes(DataNode[] nodes)
        {
            foreach (DataNode node in nodes)
            {
                RawNodeType rawType = NodeUtil.GetRawFromNodeType(node.GetNodeType());
                if (rawType != RawNodeType.FunctionCall && rawType != RawNodeType.Motion)
                    return false;
            }

            return true;
        }

        public ActionDataToolset()
        {
            DataToolConfig config = new DataToolConfig
            (
                DataToolButtonType.New,
                DataToolButtonType.Copy,
                DataToolButtonType.MoveUp,
                DataToolButtonType.MoveDown,
                DataToolButtonType.Remove,
                DataToolButtonType.Extra
            );


            config.OnMoveUpEvent += () => MoveIndices(-1);
            config.OnMoveDownEvent += () => MoveIndices(1);
            config.OnCopyEvent += () => DuplicateIndices();
            config.OnBtnExtraEvent += () => ShowExtraMenu();
            config.OnRemoveEvent += () => RemoveIndices();

            SetConfig(config);
            SetupExtraMenu();
        }

        public void SetControls(UnitSelector srcSelector, ActionDataListBox srcListBox)
        {
            selector = srcSelector;
            activeData = srcSelector.ActiveData;
            lbDataIndex = srcListBox;

            selector.SelectComplete += UpdateDataTools;
        }

        private void SetupExtraMenu()
        {
            extraMenu = new ContextMenu();

            itemNewFunction  = new MenuItem("Insert New &Function", (o, e) => OnMenuNewFunction());
            itemNewMotion = new MenuItem("Insert New &Motion", (o, e) => OnMenuNewMotion());
            itemCopyData = new MenuItem("&Copy Selected Data", (o, e) => OnMenuCopyData());
            itemPasteData = new MenuItem("&Paste Data At Index", (o, e) => OnMenuPasteData());
            itemAppendCopiedData = new MenuItem("&Append Copied Data", (o, e) => OnMenuAppendCopied());

            extraMenu.MenuItems.Add(itemNewFunction);
            extraMenu.MenuItems.Add(itemNewMotion);
            extraMenu.MenuItems.Add(itemCopyData);
            extraMenu.MenuItems.Add(itemPasteData);
            extraMenu.MenuItems.Add(itemAppendCopiedData);
        }

        private void ShowExtraMenu()
        {
            itemNewMotion.Enabled = false;
            itemCopyData.Enabled = CanCopyData;
            itemPasteData.Enabled = CanPasteData;
            itemAppendCopiedData.Enabled = CanAppendFromClipboard;
            extraMenu.Show(btnExtra, new System.Drawing.Point(10, 10));

        }

        private void CopyIndices()
        {
            if (!CanCopyData)
                throw new Exception("Cannot copy data");

            Clipboard.SetItem(new ClipItemDataNode(activeData.Action.GetNodeCopiesFromIndexes(lbDataIndex.GetSelectedIndices())));

        }

        // combo box / data option helper functions

        private void RemoveIndices()
        {
            int[] indices = lbDataIndex.GetSelectedIndices();

            if (indices == null || indices.Length == 0)
                throw new ArgumentException("Invalid Selected Indexes");

            if (indices.Length > 0)
            {
                activeData.Action.RemoveNodesRecorded(indices);
                RemoveListItems(indices);
            }

        }

        private int[] DuplicateIndices()
        {
            int[] indices = lbDataIndex.GetSelectedIndices();

            if (indices.Length > 0)
            {


                DataNode[] copiedNodes = activeData.Action.GetNodeCopiesFromIndexes(indices);
                int targetIndex = activeData.Action.HasBaseFooter ? activeData.Action.Count - 1 : activeData.Action.Count;
                int [] newIndices = activeData.Action.InsertNodesRecorded(targetIndex, copiedNodes);


                InsertListItems(newIndices[0], lbDataIndex.Items.Count - 1, newIndices);
                return newIndices;
            }

            return null;
        }

        private void InsertListItems(int firstIndex, int targetIndex, int [] srcIndexes)
        {
            UnitAction action = selector.ActiveData.Action;
            DataNode[] nodes = action.GetNodesFromIndexes(srcIndexes);
            int removeAmt = lbDataIndex.Items.Count - targetIndex;
            for (int i = 0; i < removeAmt; i++)
            {
                lbDataIndex.Items.RemoveAt(targetIndex);
            }

            lbDataIndex.Items.AddRange(Description.DescSpec.GetNodeGroupDescriptions(nodes, srcIndexes));

            for (int i = 0; i < removeAmt; i++)
            {
                int nodeIndex = i+targetIndex+srcIndexes.Length;
                lbDataIndex.Items.Add(Description.DescSpec.GetDataNodeName(action.DataNodes[nodeIndex], nodeIndex));
            }
            lbDataIndex.ClearSelected();

            selector.PreventUpdateData = true;
            foreach (int currIndex in srcIndexes)
            {
                selector.PreventUpdateData = !(currIndex == firstIndex);
                lbDataIndex.SetSelected(currIndex, true);
            }

            UpdateDataTools();
            selector.PreventUpdateData = false;
        }

        private void RemoveListItems(int [] srcIndexes)
        {
            int firstIndex = srcIndexes[0];

            lbDataIndex.ClearSelected();

            for (int i = srcIndexes.Length - 1; i >= 0; i--)
            {
                lbDataIndex.Items.RemoveAt(srcIndexes[i]);
            }

            if (lbDataIndex.Items.Count - 1 >= firstIndex)
            {

                for (int i = firstIndex; i < lbDataIndex.Items.Count; i++)
                {
                    lbDataIndex.Items[i] = Description.DescSpec.GetDataNodeName(selector.ActiveData.Action.DataNodes[i], i);
                }
            }

            lbDataIndex.SetSelected(firstIndex - 1, true);
        }

        private int[] PasteItems(bool append = false)
        {
            int targetIndex = 0;
            if (!CanPasteData)
                throw new Exception("Clipboard item is invalid type");

            if (append)
            {
                if (!CanAppendFromClipboard)
                    throw new Exception("Cannot append data");

                targetIndex = activeData.Action.Count;
            }
            else
            {
                targetIndex = lbDataIndex.FirstSelectedIndex;
            }
            
            DataNode[] nodes = (DataNode[])Clipboard.ClipboardItem.GetItems();
            int[] newIndices = activeData.Action.InsertNodesRecorded(targetIndex, nodes);
            if (newIndices == null)
                throw new Exception("Error pasting nodes");

            InsertListItems(lbDataIndex.FirstSelectedIndex, targetIndex, newIndices);

            return newIndices;

        }

        private int[] MoveIndices(int offset)
        {

            int firstIndex = -1;
            int[] indices = lbDataIndex.GetSelectedIndices();
            List<int> newIndexes = new List<int>();
            int count = indices.Length;
            int start = offset > 0 ? count - 1 : 0;
            int end = offset > 0 ? -1 : count;
            int add = offset > 0 ? -1 : 1;

            if (count > 0)
            {
                selector.PreventUpdateData = true;

                lbDataIndex.BeginUpdate();
                for (int i = start; i != end; i+=add)
                {
                    int index = indices[i];
                    int newIndex = activeData.Action.SwapNodes(index, index + offset);
                    firstIndex = firstIndex != -1 ? firstIndex : newIndex;
                    selector.SwapListText(UnitCombo.Data, index, index + offset);
                    newIndexes.Add(newIndex);
                }

                foreach (int index in indices)
                {
                    lbDataIndex.SetSelected(index + offset, true);
                }
                lbDataIndex.EndUpdate();
                UpdateDataTools();
                selector.PreventUpdateData = false;
                return newIndexes.ToArray();
            }

            return null;
        }

        private void UpdateDataTools()
        {

            // update data controls
            if (activeData.Action != null)
            {
                // update move controls
                btnMoveDown.Enabled = lbDataIndex.LastSelectedIndex < activeData.Action.Count - 1 && activeData.Action.GetNode(lbDataIndex.LastSelectedIndex + 1).GetNodeType() != NodeType.ActionFooter;
                btnMoveUp.Enabled = lbDataIndex.FirstSelectedIndex > 0 && activeData.Action.GetNode(lbDataIndex.FirstSelectedIndex + -1).GetNodeType() != NodeType.ActionHeader;

                DataNode [] nodes = activeData.Action.GetNodesFromIndexes(lbDataIndex.GetSelectedIndices());
                foreach(DataNode node in nodes)
                {
                    
                    // update copy/remove controls
                    NodeType dataNodeType = node.GetNodeType();
                    bool getOut = false;

                    btnMoveDown.Enabled = true;
                    btnMoveUp.Enabled = true;
                    btnCopy.Enabled = true;
                    btnRemove.Enabled = true;

                    switch (dataNodeType)
                    {
                        case NodeType.ActionHeader:
                            btnMoveDown.Enabled = false;
                            btnMoveUp.Enabled = false;
                            btnCopy.Enabled = false;
                            btnRemove.Enabled = false;
                            break;
                        case NodeType.ActionFooter:
                            btnMoveDown.Enabled = false;
                            btnMoveUp.Enabled = false;
                            btnCopy.Enabled = false;
                            break;
                        default:
                            break;
                    }

                    if (getOut) break;                    
                }
            }
            else
            {
                btnNew.Enabled = false;
                btnCopy.Enabled = false;
                btnRemove.Enabled = false;
                btnMoveUp.Enabled = false;
                btnMoveDown.Enabled = false;
            }
        }

        /////////////////////////////
        //
        /////////////////////////////

        private void OnMenuNewMotion()
        {
        }

        private void OnMenuNewFunction()
        {
        }

        private void OnMenuCopyData()
        {
            CopyIndices();
        }

        private void OnMenuPasteData()
        {
            PasteItems();
        }

        private void OnMenuAppendCopied()
        {
            PasteItems(true);
        }

    }
}
