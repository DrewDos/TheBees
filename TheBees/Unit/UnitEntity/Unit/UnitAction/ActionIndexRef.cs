using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheBees.UnitData
{
    public class ActionIndexRef
    {
        private uint actionAddress;
        private int dataIndex;

        public uint ActionAddress { get { return actionAddress; } }
        public int DataIndex { get { return dataIndex; } }

        public ActionIndexRef(uint newActionAddress, int newLastIndex)
        {
            actionAddress = newActionAddress;
            dataIndex = newLastIndex;
        }

    }
}
