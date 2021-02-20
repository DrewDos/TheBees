using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TheBees.GameRom;

namespace TheBees
{
    public class ClipItemDataNode : IClipboardItem
    {
        public Type DataType { get { return typeof(DataNode); } }
        private DataNode[] items;
        
        public ClipItemDataNode(params DataNode [] newItems)
        {
            items = newItems;
        }

        public object GetItems()
        {
            List<DataNode> newItems = new List<DataNode>();
            Array.ForEach(items, (x) => newItems.Add(x.GetCopy(true)));

            return newItems.ToArray();
        }

        static private DataNode[] ConvertItems(object itemsToConvert)
        {
            if(!(typeof(object) == typeof(DataNode[])))
                    throw new ArgumentException("Object does not match expected type");

            return ((DataNode[])itemsToConvert);
        }
    }
}
