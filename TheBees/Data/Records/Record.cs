using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheBees.Records
{

    public class Record : BaseRecord
    {
        public event Action<uint, uint> UpdateAddressEvent;

        public RecordSpace Parent;

        private Action beforeDataMove;
        private Action afterSetAddress;

        public Action ActionBeforeDataMove { get { return beforeDataMove; } set { if (beforeDataMove != null) throw new Exception("BufferData already set"); beforeDataMove = value; } }
        public Action ActionAfterSetAddress { get { return afterSetAddress; } set { if (afterSetAddress != null) throw new Exception("ApplyBuffer already set"); afterSetAddress = value; } }

        public Record(uint start, int size)
            :base(start, size)
        {
            IsChild = false;
        }

        public void ClearFromSpace(bool consolidate)
        {
            Parent.ClearRecord(this, consolidate);
        }

        public virtual Record GetCopy()
        {
            Record record = new Record(start, Size);
            record.Index = Index;
            record.beforeDataMove = beforeDataMove;
            record.afterSetAddress = afterSetAddress;
            return record;
        }

        public void AdjustSize(int newSize)
        {
            int endInt = (int)end, returnValue = newSize - (int)(end - start);
            endInt += newSize - (int)(end - start);
            end = (uint)endInt;

            //return returnValue;
        }


        public virtual void AdjustPosition(int adjustment)
        {
            uint oldStart = start;

            start = (uint)((int)start + adjustment);
            end = (uint)((int)end + adjustment);

            if (oldStart != start)
            {
                MoveData(oldStart);
                
                if (UpdateAddressEvent != null)
                    UpdateAddressEvent(oldStart, start);
            }
        }

        public override void SetAddress(uint newAddress)
        {
            uint oldAddress = start;

            if (oldAddress != newAddress || true)
            {
                base.SetAddress(newAddress);

                //MoveData(oldAddress);

                if (UpdateAddressEvent != null)
                    UpdateAddressEvent(oldAddress, newAddress);
            }
        }

        protected virtual void MoveData(uint fromAddress)
        {
            RomData.MoveBlock(fromAddress, start, Size);
        }

        public void BeforeDataMove()
        {
            if (beforeDataMove != null) beforeDataMove();
        }
        public void AfterSetAddress()
        {
            if (afterSetAddress != null) afterSetAddress();
        }

        //public BaseRecord AddChildOrGetExisting(uint start, int length)
        //{
        //    BaseRecord foundRecord = childRecords.Find(x => x.Start == start);

        //    if (foundRecord == null)
        //    {
        //        ChildRecord childRecord = new ChildRecord(start, (int)start+length);
        //        childRecords.Add(childRecord);
        //        return childRecord;
        //    }
        //    else
        //    {
        //        return foundRecord;
        //    }
        //}

        //private void OnUpdateAddressChildren(uint parentAddress)
        //{
        //    //for (int i = 0; i < childRecords.Count; i++)
        //    //{
        //    //    for (int j = 0; j < childRecords[i].OnUpdateAddress.Count; j++)
        //    //    {
        //    //        childRecords[i].OnUpdateAddress[j](parentAddress + (childRecords[i].End - childRecords[i].Start));
        //    //    }
        //    //}
        //}
    }
}
