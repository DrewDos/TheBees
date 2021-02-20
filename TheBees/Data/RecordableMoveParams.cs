using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheBees.Records
{
    public class RecordableMoveParams
    {
        public uint FromAddress { get; set; }
        public uint ToAddress { get; set; }

        public RecordableMoveParams(uint newFrom, uint newTo)
        {
            FromAddress = newFrom;
            ToAddress = newTo;
        }
    }
}
