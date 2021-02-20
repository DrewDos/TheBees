using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TheBees.User;
using TheBees.Records;

namespace TheBees.Sound
{
    static public class SampleDataMap
    {
        static private RecordableObserver observer;
        static private RawSampleDataGroup mainGroup;
        static public RawSampleDataGroup MainGroup { get { return mainGroup; } }

        static public void LoadSampleDataGroup()
        {
            mainGroup = RawSampleDataGroup.GetRecordable(SampleSpec.GetSampleDataGroupPointers()[0]);
            observer = new RecordableObserver(mainGroup, UpdateGroupAddresses);
        }

        static public void SetSampleData(int index, byte [] newSample)
        {
            RecordSpace space = RecordGuide.UserSpace.GetSpaceFromFreeSize(newSample.Length);
            if (space == null)
                throw new Exception("Not enough free space");

            uint newAddress = space.GetNewRecordStart();
            RomData.SetBlock(newAddress, newSample);
            Record newRecord = RecordGuide.CreateRecord(newAddress, newSample.Length);
            space.AddRawRecord(newRecord);
            mainGroup.GetSampleDetails(index).UpdateValues(new SampleDataDetails(
                newAddress, 
                newAddress+(uint)newSample.Length-1,
                newAddress + (uint)newSample.Length - 1, 
                0x50
                ));
            mainGroup.SetSampleData(index);
            mainGroup.SampleMap.ReplaceMap(index, SampleBlock.GetRecordable(index));
            
        }

        static private void UpdateGroupAddresses(RecordableMoveParams p)
        {
            uint[] addresses = SampleSpec.GetSampleDataGroupPointers();

            foreach (uint address in addresses)
            {
                RomData.Set32(address, p.ToAddress);
            }
        }
    }
}
