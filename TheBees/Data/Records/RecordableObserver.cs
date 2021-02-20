using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheBees.Records
{
    public class RecordableObserver
    {
        public RecordableMove RecordableMoveAction;
        public Recordable Data;

        public RecordableObserver(Recordable newBlock, RecordableMove moveAction)
        {
            Data = newBlock;
            RecordableMoveAction = moveAction;
            Data.Associate(this);
        }

        public void DisassociateBlock(bool consolidate = false)
        {
            Data.Disassociate(this, consolidate);
        }


    }
}
