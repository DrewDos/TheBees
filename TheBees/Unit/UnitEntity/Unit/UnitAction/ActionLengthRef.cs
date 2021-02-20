using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheBees.UnitData
{
    public class ActionLengthRef
    {
        private uint actionAddress;
        private int length;

        public uint ActionAddress { get { return actionAddress; } }
        public int Length { get { return length; } }

        public ActionLengthRef(uint newActionAddress, int newLength)
        {
            actionAddress = newActionAddress;
            length = newLength;
        }
    }
}
