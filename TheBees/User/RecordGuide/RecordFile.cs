using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using TheBees.Records;

namespace TheBees.User
{

    // Begin with record space definitions


    static class RecordFile
    {
        static public event Action<Record> RecordLoadEvent = null;

        static public bool Exists(string source)
        {
            return File.Exists(source);
        }

        static public void LoadRecords(BinaryReader r)
        {
            uint count = r.ReadUInt32();

            for (int i = 0; i < count; i++)
            {
                byte groupValue = r.ReadByte();

                switch (groupValue)
                {
                    case 0:
                        if (RecordGuide.ProgramSpace != null)
                            throw new Exception("DataSpace is not null");
                        RecordSpaceGroup dataGroup = new RecordSpaceGroup();
                        LoadRecordGroupData(r, dataGroup);
                        RecordGuide.ProgramSpace = dataGroup;
                        break;
                    case 1:
                        if (RecordGuide.UserSpace != null)
                            throw new Exception("UserSpace is not null");
                        RecordSpaceGroup userGroup = new RecordSpaceGroup();
                        LoadRecordGroupData(r, userGroup);
                        RecordGuide.UserSpace = userGroup;
                        break;
                }
            }

        }

        static public bool LoadRecordsToFile(string source)
        {
            if (!File.Exists(source))
                throw new Exception("File does not exist");

            BinaryReader r = new BinaryReader(File.Open(source, FileMode.Open));

            try
            {
                LoadRecords(r);
            }
            catch (EndOfStreamException)
            {
                r.Close();
                throw new Exception("Error loading Record file");
            }

            if(RecordGuide.ProgramSpace != null)
                RecordGuide.ProgramSpace.Sort();

            if(RecordGuide.UserSpace != null)
                RecordGuide.UserSpace.Sort();

            r.Close();

            return true;

        }

        static public void SaveRecordsToFile(string source)
        {
            BinaryWriter w = new BinaryWriter(File.Open(source, FileMode.Create));
            SaveRecords(w);
            w.Close();
        }

        static public void SaveRecords(BinaryWriter w)
        {
            w.Write((uint)0x02); // record group count
            SaveRecordGroupData(w, RecordGuide.ProgramSpace, 0);
            SaveRecordGroupData(w, RecordGuide.UserSpace, 1);
        }
        static public void LoadRecordGroupData(BinaryReader r, RecordSpaceGroup group)
        {
            uint spaceCount = r.ReadUInt32();

            for (int i = 0; i < spaceCount; i++)
            {
                RecordSpace newSpace = group.CreateSpace(r.ReadUInt32(), r.ReadUInt32());

                uint recordCount = r.ReadUInt32();

                for (int j = 0; j < recordCount; j++)
                {
                    string tag = r.ReadString();
                    uint start = r.ReadUInt32();
                    int size = (int)r.ReadUInt32() - (int)start;
                    Record newRecord = new Record(start, size);
                    newSpace.AddRawRecord(newRecord);
                    if (RecordLoadEvent != null)
                        RecordLoadEvent(newRecord);
                }
            }

            group.Sort();
        }

        static public void SaveRecordGroupData(BinaryWriter w, RecordSpaceGroup group, int refIndex)
        {
            if (group == null)
                return;

            // write the group index
            w.Write((byte)refIndex);

            // write the count of record spaces in the group
            w.Write((uint)group.SpaceList.Count);

            foreach (RecordSpace space in group.SpaceList)
            {
                // expecting space group here
                
                // write start
                w.Write((uint)space.Start);

                // write end
                w.Write((uint)space.End);

                // write record count
                w.Write((uint)space.Records.Count);

                foreach (Record record in space.Records)
                {
                    w.Write("");
                    w.Write((uint)record.Start);
                    w.Write((uint)record.End);
                }
            }
            
        }
    }
}
