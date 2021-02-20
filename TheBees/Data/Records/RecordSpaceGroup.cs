using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheBees.Records
{
    public class RecordSpaceGroup
    {
        public List<RecordSpace> SpaceList = new List<RecordSpace>();
        public static event Action OperationCompleteEvent;
        private bool sorted = true;

        private static int collisions = 0;
        public RecordSpaceGroup()
        {
        }

        public void InitRecord(Record record, bool sort)
        {
            //if (GetSpaceFromRecord(record) == null)
            //{
                CreateSpaceFromRecord(record, sort).AddRecord(record);
            //}
        }

        public Record CreateRecordForNewData(int size)
        {
            RecordSpace space = GetSpaceFromFreeSize(size);
            if (space == null)
                throw new Exception("Not enough free size");

            Record record = new Record(0, size);
            space.AddRecord(record);
            
            return record;
        }

        private void CheckSorted()
        {
            if (!sorted) throw new Exception("Not sorted");
        }

        public void Sort()
        {
            SpaceList.Sort(new RecordSpaceComparer());
            sorted = true;
        }

        public void PreventCollision(uint start, uint end)
        {
            foreach(RecordSpace space in SpaceList)
            {
                if (start >= space.Start && end <= space.End)
                {
                    collisions += 1;
                    return;
                }
            }
        }

        public RecordSpace CreateSpace(uint start, uint end, bool sort = false)
        {
            //PreventCollision(start, end);

            RecordSpace newSpace = new RecordSpace(start, end, this);
            SpaceList.Add(newSpace);
            if (sort)
            {
                Sort();
            }
            sorted = sort;
            return newSpace;

        }

        public RecordSpace CreateSpaceFromRecord(Record record, bool sort)
        {
            return CreateSpace(record.Start, record.End, sort);
        }

        public bool FreeSizeAvailable(Record record, int newSize)
        {
            if (record != null)
            {
                RecordSpace space = GetSpaceFromRecord(record);
                if (space.FreeSpace >= newSize - record.Size)
                    return true;
            }

            return FreeSizeAvailable(newSize);
        }

        public bool FreeSizeAvailable(int size)
        {
            CheckSorted();
            return SpaceList.Find((x) => x.FreeSpace >= size) != null;
        }

        public RecordSpace GetSpaceFromFreeSize(int size)
        {
            CheckSorted();
            return SpaceList.Find((x) => x.FreeSpace >= size);
        }

        public bool RecordExists(Record record)
        {
            return GetSpaceFromRecord(record) != null;
        }

        public RecordSpace GetSpaceFromRecord(Record record)
        {
            CheckSorted();
            return SpaceList.Find((x) => x.KeyedRecords.ContainsKey(record.Start));
        }

        public RecordSpace GetNewSizeTarget(Record record, int newSize)
        {
            RecordSpace space = GetSpaceFromRecord(record);

            if (space == null)
            {
                throw new ArgumentException("Record must exist!");
            }

            if (newSize > record.Size)
            {
                if (space.FreeSpace >= newSize - record.Size)
                {
                    return space;
                }
                else
                {
                    return GetSpaceFromFreeSize(newSize);
                }
            }
            else
            {
                return space;
            }
        }

        public bool ResizeRecord(Record record, int newSize)
        {
            RecordSpace space = GetSpaceFromRecord(record);
            int adjustment = newSize - record.Size;
            if (space == null)
            {
                Debugging.Stop = true;
                return false;
                //throw new Exception("Record does not exist");
                
            }

            if (adjustment > 0)
            {
                if (space.FreeSpace >= adjustment)
                {
                    space.ResizeRecord(record.Start, newSize);
                }
                else
                {
                    RecordSpace freeSpace = GetSpaceFromFreeSize(newSize);

                    if (freeSpace == null)
                    {
                        throw new Exception("Not enough free size");
                    }
                    else
                    {
                        space.MoveTo(record.Start, freeSpace);
                        freeSpace.ResizeRecord(record.Start, newSize);
                        return true;
                    }
                }
            }
            else
            {
                space.ResizeRecord(record.Start, newSize);
                return true;
            }

            return false;
        }

        // refactor

        public List<List<int>> GetSequenceIndexes()
        {
            uint currentEnd = 0;
            int i = 1;
            int seqCtr = 0;
            List<List<int>> allSequences = new List<List<int>>();
            if (SpaceList.Count > 0)
            {
                currentEnd = SpaceList[0].End;
                allSequences.Add(new List<int>());
                allSequences[seqCtr].Add(0);

                do
                {
                    if (currentEnd != SpaceList[i].Start)
                    {
                        UpdateSequence(allSequences, ref seqCtr, i, false);
            
                    }
                    currentEnd = SpaceList[i].End;
                    i++;
                }
                while (i < SpaceList.Count);

                UpdateSequence(allSequences, ref seqCtr, i, true);
            }

            return allSequences;
        }

        private void UpdateSequence(List<List<int>> sequences, ref int counter, int currIndex, bool final )
        {
            if (sequences[counter][0] == currIndex - 1)
            {
                sequences.RemoveAt(counter);
                sequences.Add(new List<int>());
                sequences[counter].Add(currIndex);
            }
            else
            {
                sequences[counter].Add(currIndex - 1);

                if (!final)
                {
                    counter += 1;
                    sequences.Add(new List<int>());
                    sequences[counter].Add(currIndex);
                }
            }
        }

        public void ConsolidateGroup()
        {
            Sort();

            List<List<int>> sequences = GetSequenceIndexes();
            List<int> removedIndexes = new List<int>();

            foreach (List<int> currSeq in sequences)
            {
                if (currSeq.Count < 2) continue;
        
                RecordSpace newSpace = new RecordSpace(SpaceList[currSeq[0]].Start, SpaceList[currSeq[1]].End, this);

                int start = currSeq[0];
                for (int i = currSeq[0]; i <= currSeq[1]; i++)
                {
                    List<Record> records = SpaceList[i].Records;

                    for (int j = 0; j < records.Count; j++)
                    {
                        newSpace.AddRecord(records[j]);
                    }

                    removedIndexes.Add(i);
                }

                SpaceList.Add(newSpace);
            }

            for (int i = removedIndexes.Count - 1; i >= 0; i--)
            {
                SpaceList.RemoveAt(removedIndexes[i]);
            }

            Sort();
        }

        public void ConsolidateEachSpace()
        {
            RecordSpace.ConsolidatePending(this);
        }

        static public void OperationComplete()
        {
            if (OperationCompleteEvent != null)
                OperationCompleteEvent();
        }

        ////////////////////////////////////////
        // extended properties
        ////////////////////////////////////////

        public int FreeSpace 
        {
            get 
            { 
                int freeSpace = 0; 
                SpaceList.ForEach((x) => freeSpace += x.FreeSpace);
                return freeSpace;
            }
        }
        public int LargestBlockAvail
        {
            get
            {
                int largestBlock = 0;
                SpaceList.ForEach((x) => largestBlock = x.FreeSpace > largestBlock ? x.FreeSpace : largestBlock);
                return largestBlock;
            }
        }
    }
}
