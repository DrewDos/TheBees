using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TheBees.Records;

namespace TheBees.Data
{
    public class MappedRecordableList
    {
        private List<Recordable> recordableList = new List<Recordable>();
        private HashSet<Recordable> recordableHash = new HashSet<Recordable>();
        private Dictionary<Recordable, RecordableObserver> observers = new Dictionary<Recordable,RecordableObserver>();

        private Action onUpdateActionAddress;

        public MappedRecordableList(Action actionUpdateActionAddress)
        {
            onUpdateActionAddress = actionUpdateActionAddress;
        }

        public void AddMap(Recordable newRecordable)
        {
            recordableList.Add(newRecordable);

            if (newRecordable != null && !recordableHash.Contains(newRecordable))
            {
                recordableHash.Add(newRecordable);
                observers[newRecordable] = new RecordableObserver(newRecordable, (x) => { onUpdateActionAddress(); });
                
            }
        }

        public Recordable GetMap(int index)
        {
            return recordableList[index];
        }

        public void ClearMap(int index, bool update = true, bool consolidate = false)
        {
            Recordable recordable = recordableList[index];
            recordableList[index] = null;

            if (!recordableList.Contains(recordable))
            {

                recordableHash.Remove(recordable);

                observers[recordable].DisassociateBlock(consolidate);
                observers.Remove(recordable);

                if (update)
                    onUpdateActionAddress();
            }
        }

        public void ReplaceMap(int index, Recordable newRecordable)
        {
            ClearMap(index, false);

            if (!recordableList.Contains(newRecordable))
            {
                recordableHash.Add(newRecordable);
                observers.Add(newRecordable, new RecordableObserver(newRecordable, (x) => { onUpdateActionAddress(); }));
            }

            recordableList[index] = newRecordable;

            onUpdateActionAddress();
        }

        public uint[] GetAddressList()
        {
            List<uint> output = new List<uint>();

            for (int i = 0; i < recordableList.Count; i++)
            {
                output.Add(recordableList[i].Address);

            }

            return output.ToArray();
        }

        public int[] GetIndexes(Recordable recordable)
        {
            List<int> indexes = new List<int>();

            int max = recordableList.Count;
            int foundIndex = recordableList.IndexOf(recordable, 0);

            while (foundIndex != -1)
            {
                int start = foundIndex;
                indexes.Add(foundIndex);
                foundIndex = recordableList.IndexOf(recordable, start + 1);
            }

            return indexes.ToArray();
        }

        public int MapCount { get { return recordableList.Count; } }
    }
}
