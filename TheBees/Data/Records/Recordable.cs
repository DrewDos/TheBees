using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TheBees.User;

using TheBees.General;

namespace TheBees.Records
{
    public delegate void RecordableMove(RecordableMoveParams p);

    public abstract class Recordable : ICustomObservable<RecordableMove, RecordableMoveParams>
    {
        static public event Action<Recordable> OnInstantiateRecordable;
        static public event Action<Recordable> SetTagEvent;
        private string tag = "";
        public string Tag { get { return tag; } }

        protected Record record = null;
        protected uint address;
        
        public uint Address { get { return address; } }
        public Record RecordEntity { get { return record; } set { SetRecord(value); } }

        private bool loadComplete = false;
        private List<RecordableObserver> observers = new List<RecordableObserver>();
        static public Dictionary<uint, Recordable> MasterList = new Dictionary<uint, Recordable>();
        static public bool RecordMustExist = true;

        public event RecordableMove RecordableMoveEvent;
        static protected bool creatingBaseRecords = false;
        static public bool CreatingBaseRecords { set { creatingBaseRecords = value; } }
        static protected bool sortOnOnit = false;
        static public bool SortOnInit { set { sortOnOnit = value; } }

        public Recordable(uint dataAddress, bool finalize)
        {
            address = dataAddress;
            if(finalize)
                FinalizeAddress(dataAddress);
        }


        ////////////////////////////////////////
        // initialization
        ////////////////////////////////////////

        public void InitializeRecord()
        {
            if (record == null)
            {
                Record tempRec = new Record(address, SizeInBytes);
                spaceGroup.InitRecord(tempRec, sortOnOnit);
                SetRecord(tempRec);
            }
        }

        public virtual void SetRecord(Record newRecord)
        {
            if (record != null)
                throw new ArgumentException("Record is already set");

            record = newRecord;
            record.UpdateAddressEvent += OnUpdateAddress;
            record.ActionBeforeDataMove = BeforeDataMove;
            record.ActionAfterSetAddress = AfterSetAddress;
        }

        protected virtual void OnGetFreeAddress(uint newAddress)
        {
            throw new NotImplementedException();
        }

        ////////////////////////////////////////
        // general methods
        ////////////////////////////////////////

        public void SetTag(string newTag)
        {
            if (newTag == "")
            {
                tag = address.ToString("X8");
                return;
            }
  
            tag = newTag;
            if (SetTagEvent != null)
                SetTagEvent(this);
        }
        public virtual void FinalizeAddress(uint newAddress)
        {
            address = newAddress;

            if (OnInstantiateRecordable != null)
                OnInstantiateRecordable(this);

            if (MasterList.ContainsKey(newAddress))
                throw new ArgumentException("Recordable already exists at this key");

            MasterList[newAddress] = this;
            
        }

        protected bool CanResize(int newSize)
        {
            return spaceGroup.FreeSizeAvailable(record, newSize);
        }

        protected virtual bool PrepareResize(int newSize)
        {
            if (!spaceGroup.FreeSizeAvailable(record, newSize))
                return false;

            InitializeRecord();
            spaceGroup.ResizeRecord(record, newSize);

            return true;
        }

        static public void AllLoadComplete()
        {
            foreach (Recordable recordable in MasterList.Values)
            {
                recordable.LoadComplete();
            }
        }

        ////////////////////////////////////////
        // observable methods
        ////////////////////////////////////////
        
        public void Associate(RecordableObserver observer)
        {
            if (loadComplete == true)
                throw new Exception("Loading observers has already been completed");

            if (observers.Exists((x) => x == observer))
                throw new Exception("Parent already exists");

            observers.Add(observer);
            AddObserver(observer.RecordableMoveAction);
        }

        public void Disassociate(RecordableObserver observer, bool consolidate)
        {
            if (!observers.Exists((x) => x == observer))
                throw new Exception("Parent does not exist");

            observers.Remove(observer);
            RemoveObserver(observer.RecordableMoveAction);

            if (observers.Count == 0 && !MaintainData) // loadcomplete currently removed
            {
                MasterList.Remove(address);
                record.ClearFromSpace(consolidate);
            }
        }

        public void LoadComplete()
        {
            loadComplete = true;
        }

        public void Reset()
        {
            loadComplete = false;
        }

        public void AddObserver(RecordableMove o)
        {
            RecordableMoveEvent += o;
        }

        public void RemoveObserver(RecordableMove o)
        {
            RecordableMoveEvent -= o;
        }

        public void Notify(RecordableMoveParams p)
        {
            if (RecordableMoveEvent != null)
                RecordableMoveEvent(p);
        }


        protected virtual void OnUpdateAddress(uint oldAddress, uint newAddress)
        {
            address = newAddress;
            Notify(new RecordableMoveParams(oldAddress, newAddress));
        }

        protected virtual void BeforeDataMove()
        {
            MasterList.Remove(address);
            //RecordTagGuide.ClearTag(address);
        }
        protected virtual void AfterSetAddress()
        {
            MasterList[address] = this;
            //RecordTagGuide.SetRecordTag(address, Tag);
        }

        static public void SetupBaseInfo(bool isBaseData, bool obtainingBaseData)
        {
            Recordable.CreatingBaseRecords = obtainingBaseData; // load records for all recordables since no base data exists
            Recordable.SortOnInit = !obtainingBaseData; // sort manually to avoid multiple sorts on adding space groups

        }

        ////////////////////////////////////////
        // tools
        ////////////////////////////////////////

        public virtual Recordable GetCopyRecorded()
        {
            if (!spaceGroup.FreeSizeAvailable(SizeInBytes))
                return null;

            RecordSpace targetSpace = spaceGroup.GetSpaceFromFreeSize(SizeInBytes);
            Record newRecord = new Record(targetSpace.GetNewRecordStart(), SizeInBytes);
            targetSpace.AddRecord(newRecord);
            BufferData();
            Recordable newRecordable = GetCopy();
            newRecordable.MakeEmptyBuffer();
            newRecordable.SetBuffer(this);
            ClearBuffer();
            newRecordable.SetRecord(newRecord);
            newRecordable.FinalizeAddress(newRecord.Start);
            newRecord.SetAddress(newRecord.Start);
            newRecordable.ApplyBuffer();
            newRecordable.ClearBuffer();
            return newRecordable;          
        }

        protected virtual Recordable GetCopy()
        {
            throw new Exception("Must be implemented in a subclass");
        }

        protected virtual void BufferData()
        {
            throw new Exception("Must be implemented in a subclass");
        }

        protected virtual void SetBuffer(Recordable srcRecordable)
        {
            throw new Exception("Must be implemented in a subclass");
        }

        protected virtual void MakeEmptyBuffer()
        {
            throw new Exception("Must be implemented in a subclass");
        }

        protected virtual void ApplyBuffer()
        {
            throw new Exception("Must be implemented in a subclass");
        }

        protected virtual void ClearBuffer()
        {
            throw new Exception("Must be implemented in a subclass");
        }

        ////////////////////////////////////////
        // properties
        ////////////////////////////////////////

        protected virtual RecordSpaceGroup spaceGroup
        {
            get
            {
                throw new Exception("Cannot have record space in base class");
            }
            set
            {
                throw new Exception("Cannot set space group in base class");
            }
        }

        public bool HasRecord { get { return record != null; } }

        abstract public int SizeInBytes { get; }
        abstract public bool MaintainData { get; }
    }
}
