using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheBees.Records
{

    public enum SourceSpace
    {
        Unused,
        Allocated
    }

    class RecordComparer : IComparer<Record>
    {
        public int Compare(Record x, Record y)
        {
            return x.Start.CompareTo(y.Start);
        }
    }

    class RecordSpaceComparer : IComparer<RecordSpace>
    {
        public int Compare(RecordSpace x, RecordSpace y)
        {
            return x.Start.CompareTo(y.Start);
        }
    }

    public enum ConsolidateDirection
    {
        Forward,
        Reverse
    }


    public class RecordSpace
    {
        private List<Record> allRecords = new List<Record>();
        private Dictionary<uint, Record> keyedRecords = new Dictionary<uint,Record>();

        private uint start;
        private uint end;
        private int freeSpace = 0;
        public int FreeSpace { get { return freeSpace; } }
        public Dictionary<uint, Record> KeyedRecords { get { return keyedRecords; } }
        public List<Record> Records { get { return allRecords; } }
        private RecordSpaceGroup parent;
        static public List<RecordSpace> PendingConsolidations = new List<RecordSpace>();
        public RecordSpace(uint startSource, uint endSource, RecordSpaceGroup srcParent)
        {
            start = startSource;
            end = endSource;
            freeSpace = (int)(end - start);
            parent = srcParent;
        }

        ////////////////////////////////////////
        // helper
        ////////////////////////////////////////

        public void SortAllRecords()
        {
            IComparer<Record> sorter = new RecordComparer();
            allRecords.Sort(sorter);
        }

        public uint GetNewRecordStart()
        {
            if (allRecords.Count > 0)
            {
                return allRecords[allRecords.Count - 1].End;
            }
            else
            {
                return start;
            }
        }

        public bool RecordExists(Record record)
        {
            return (keyedRecords.ContainsKey(record.Start));
        }
       
        ////////////////////////////////////////
        // events
        ////////////////////////////////////////

        private void BeforeDataMove(int start, int end)
        {
            for(int i = start; i <= end; i++)
            {
                allRecords[i].BeforeDataMove();
            }
        }

        private void AfterSetAddress(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                allRecords[i].AfterSetAddress();
            }
        }

        ////////////////////////////////////////
        // add / remove records
        ////////////////////////////////////////

        public uint AddRecord(Record sourceRecord)
        {
            uint newRecordStart = GetNewRecordStart();
            sourceRecord.SetAddress(newRecordStart);
            AddRawRecord(sourceRecord);
            return newRecordStart;
        }

        public uint AddRawRecord(Record newRecord)
        {
            // and align the size
            freeSpace -= newRecord.Size;

            if (freeSpace < 0)
                throw new ArgumentException("Raw record must be equal to or less than the size of the space");

            if (!(newRecord.Start >= start && newRecord.End <= end))
                throw new Exception("Record is not in range");

            newRecord.Index = allRecords.Count;
            allRecords.Add(newRecord);
            keyedRecords[newRecord.Start] = newRecord;
            newRecord.Parent = this;

            return newRecord.Start;
        }

        public void ClearRecord(Record record, bool consolidate = true)
        {
            if (!allRecords.Contains(record))
                throw new Exception("Record does not exist in this space");

            if (consolidate)
            {
                ClearWithConsolidate(record.Start);
            }
            else
            {
                ClearWithoutConsolidate(record.Start);
            }
        }
        
        private void ClearWithoutConsolidate(uint address)
        {
            allRecords.Remove(keyedRecords[address]);
            keyedRecords.Remove(address);
            PendConsolidate(this);
        }

        private void ClearWithConsolidate(uint address)
        {
            int index = keyedRecords[address].Index;
            
            ResizeRecord(address, 0);

            for (int i = index+1; i < allRecords.Count; i++)
            {
                allRecords[i].Index -= 1;
            }

            //keyedRecords.Remove(address);

            allRecords.RemoveAt(index);

        }

        ////////////////////////////////////////
        // record movement and adjustments
        ////////////////////////////////////////

        private void Consolidate()
        {
            uint currentAddress = start;

            SortAllRecords();

            keyedRecords.Clear();
            BeforeDataMove(0,RecordCount-1);

            int i = 0;
            while (i < allRecords.Count)
            {
                Record record = allRecords[i];

                if (record.Start != currentAddress)
                {
                    RomData.MoveBlock(record.Start, currentAddress, record.Size);
                    record.SetAddress(currentAddress);
                }

                record.Index = i;
                keyedRecords[currentAddress] = record;

                currentAddress += (uint)record.Size;
                i++;
            }

            AfterSetAddress(0, RecordCount-1);
            freeSpace = (int)(end - currentAddress);
        }    

        static public void ConsolidatePending(RecordSpaceGroup parent)
        {
            int count = PendingConsolidations.Count;

            for(int i = count-1; i >=0; i--)
            {
                RecordSpace space = PendingConsolidations[i];
                if (space.parent == parent)
                {
                    space.Consolidate();
                    PendingConsolidations.Remove(space);
                }
            }

           
        }

        public void ResizeRecord(uint address, int newSize, bool maintainSize = false)
        {
            Record record = keyedRecords[address];
            int oldSize = record.Size;
            int adjustment = newSize - record.Size;

            if (adjustment == 0)
                throw new Exception("No adjustments to be made");
            
            // clear key if size is 0
            if (newSize == 0)   
            {
                KeyedRecords.Remove(record.Start);
            }

            if (newSize -record.Size > freeSpace)
            {
                throw new Exception("Not enough free space");
            }

            int index = record.Index+1;

            bool reverse = false;
            reverse = adjustment > 0 ? true : false;

            if(reverse)
            {
                AdjustRecords(index, adjustment, reverse);

                if (!maintainSize)
                {
                    record.AdjustSize(newSize);
                }
            }
            else
            {
                if (maintainSize)
                {
                    throw new ArgumentException("Maintaining thes size of a record should only apply to data removal");
                }
                record.AdjustSize(newSize);
                AdjustRecords(index, adjustment, reverse);
            }

            freeSpace = freeSpace + adjustment*-1;

            OnResizeRecord(address, oldSize, newSize);
       
        }

        private void AdjustRecords(int startIndex, int adjustment, bool reverse = false)
        {
            int add;
            int adjustStart, adjustEnd;

            if(reverse)
            {
                add = -1;
                adjustStart = allRecords.Count - 1;
                adjustEnd = startIndex-1;

                if (adjustStart == adjustEnd)
                {
                    // no adjustments taking place
                    return;
                }
            }
            else
            {
                add = 1;
                adjustStart = startIndex;
                adjustEnd = allRecords.Count;
            }
            
            ClearAdjustmentKeys(startIndex);

            for(int i = adjustStart; i != adjustEnd; i+=add)
            {
                allRecords[i].BeforeDataMove();
                allRecords[i].AdjustPosition(adjustment);
                allRecords[i].AfterSetAddress();
            }

            AssignAdjustmentKeys(startIndex);
        }

        public uint MoveTo(uint recordKey, RecordSpace toSpace)
        {
            Record copy = KeyedRecords[recordKey].GetCopy();
            Record baseRecord = keyedRecords[recordKey];
            baseRecord.BeforeDataMove();
            uint newAddress = toSpace.AddRecord(baseRecord);
            baseRecord.AfterSetAddress();

            keyedRecords[recordKey] = copy;
            ClearWithConsolidate(recordKey);
            return newAddress;
        }

        private void ClearAdjustmentKeys(int startIndex)
        {

            for (int i = startIndex; i < allRecords.Count; i++)
            {
                keyedRecords.Remove(allRecords[i].Start);
            }
        }

        private void AssignAdjustmentKeys(int startIndex = 0)
        {
            for (int i = startIndex; i < allRecords.Count; i++)
            {
                keyedRecords[allRecords[i].Start] = allRecords[i];
            }
        }

        static private void PendConsolidate(RecordSpace src)
        {
            if(!PendingConsolidations.Contains(src))
                PendingConsolidations.Add(src);
        }

        static public void ConsolidateAll()
        {
            foreach (RecordSpace space in PendingConsolidations)
            {
                space.Consolidate();
            }
        }
        ////////////////////////////////////////
        // events
        ////////////////////////////////////////

        private void OnAddRecord(uint source, uint destination, int size)
        {
            RomData.MoveBlock(source, destination, size);
        }

        private void OnResizeRecord(uint source, int size, int newSize)
        {
            if (newSize - size > 0)
            {
                RomData.FillBlock(source + (uint)size, newSize - size);
            }
        }

        ////////////////////////////////////////
        // debugging
        ////////////////////////////////////////

        public void Scramble()
        {
            // for testing purposes
            Random random = new Random();
            List<Record> newRecordList = new List<Record>();

            while (allRecords.Count > 0)
            {
                int rand = random.Next(0, allRecords.Count);
                newRecordList.Add(allRecords[rand]);
                allRecords.RemoveAt(rand);
            }

            // reset the free space
            freeSpace = (int)(end - start);

            newRecordList.ForEach((x) => x.BeforeDataMove());
            newRecordList.ForEach((x) => AddRecord(x));
            newRecordList.ForEach((x) => x.AfterSetAddress());

            if (freeSpace != 0) throw new Exception("Error scrambling");
        }

        public uint Start { get { return start; } }
        public uint End { get { return end; } }
        public int RecordCount { get { return allRecords.Count; } }
    }
      
    public class NotEnoughFreeSpaceException : Exception
    {
        public NotEnoughFreeSpaceException()
            : base("Not enough free space")
        {
        }
    }
}
