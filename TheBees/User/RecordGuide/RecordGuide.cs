using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using TheBees.UnitData;
using TheBees.Records;

namespace TheBees.User
{
    public delegate uint OnMoveRecord(uint address, int size, uint newAddress, uint[] pointerLocations);
    public delegate uint OnAddRemoveData(uint adderss, uint offset, int adjustment);
        

    class RecordGuide : IUserMap
    {
        public int GuideIndex { get { return 0x04; } }
        public static RecordSpaceGroup ProgramSpace = null;
        public static RecordSpaceGroup UserSpace = null;
        public static RecordSpaceGroup SoundSpace = null;
        public static Dictionary<uint, Record> MasterRecordMap = new Dictionary<uint,Record>();
        public static event Action LoadCompleteEvent;

        static private bool hasBaseData = false;
        static public bool HasBaseData { get { return hasBaseData; } }

        public static void Initialize()
        {
            RecordFile.RecordLoadEvent += OnLoadRecord;
            Recordable.OnInstantiateRecordable += OnRecordableInstantiated;
        }


        public void Clear()
        {
            ProgramSpace = new RecordSpaceGroup();
            UserSpace = new RecordSpaceGroup();
            SoundSpace = new RecordSpaceGroup();

            MasterRecordMap.Clear();
        }

        //static public void OnRomLoad()
        //{
        //    if (Globals.IsBaseRom)
        //    {
        //        try
        //        {
        //            RecordFile.LoadRecords(Settings.BaseRecordsSource);
        //        }
        //        catch
        //        {
        //            GetBaseData();
        //            saveBaseRecords = true;
        //        }
        //    }
        //    else
        //    {
        //        // see if the sequences are equal
        //        if (!File.Exists(Settings.RecordsSource))
        //            throw new Exception("Non-base records file does not exist");

        //        // file exists
        //        if(!RecordFile.LoadRecords(Settings.RecordsSource))
        //            throw new Exception("Unable to load records");
        //    }
        //}

        static public void LoadComplete(bool consolidateSpaces, bool scrambleSpaces)
        {
            if (MasterRecordMap.Count != 0)
                throw new Exception("All records not accounted for");

            if (consolidateSpaces)
            {
                ProgramSpace.ConsolidateGroup();
                UserSpace.ConsolidateGroup();

                if (consolidateSpaces && scrambleSpaces)
                {
                    foreach (RecordSpace space in ProgramSpace.SpaceList)
                        space.Scramble();
                    foreach (RecordSpace space in UserSpace.SpaceList)
                        space.Scramble();
                }
                else
                {
                    SaveBaseData();
                }


                RecordSpaceGroup.OperationComplete();
            }

            if (LoadCompleteEvent != null)
                LoadCompleteEvent();
        }

        static public void OnLoadRecord(Record record)
        {
            MasterRecordMap[record.Start] = record;
        }

        static private void OnRecordableInstantiated(Recordable rec)
        {
            uint start = rec.Address;

            if (MasterRecordMap.ContainsKey(start))
            {
                rec.SetRecord(MasterRecordMap[start]);
                MasterRecordMap.Remove(start);
            }
            
        }

        static public Record CreateRecord(uint start, int size)
        {
            Record record = new Record(start, size);
            MasterRecordMap[start] = record;
            return record;
        }

        static public void SaveBaseData()
        {
            RecordFile.SaveRecordsToFile(Settings.BaseRecordsSource);
        }

        public void LoadBaseData()
        {
            try
            {
                hasBaseData = true;
                RecordFile.LoadRecordsToFile(Settings.BaseRecordsSource);
            }
            catch
            {
                Clear();
                hasBaseData = false;

                ProgramSpace.CreateSpace(RecordSpec.UnusedStart, RecordSpec.UnusedEnd);
            }

        }

        public void LoadData(BinaryReader r)
        {
            RecordFile.LoadRecords(r);
        }

        public void SaveData(BinaryWriter w)
        {
            RecordFile.SaveRecords(w);
        }
    }
}