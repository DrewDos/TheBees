using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TheBees.Data;
using TheBees.Records;

namespace TheBees.Sound
{
    static public class RawSampleHeaderMap
    {
        static private MappedRecordableList headerMap;

        static public void LoadAllHeaderGroups()
        {
            headerMap = new MappedRecordableList(UpdateAddressList);
            for (int i = 0; i < SampleSpec.RawSampleHeaderListAmount; i++)
            {
                uint src = RomData.Get32(SampleSpec.RawSampleHeaderPointers + ((uint)i * 4));

                if (src != 0x00)
                {
                    headerMap.AddMap(RawSampleGroup.GetRecordable(src));
                }
                else
                {
                    headerMap.AddMap(null);
                }
            }
        }

        static public RawSampleGroup GetRawSampleGroup(int index)
        {
            return (RawSampleGroup)headerMap.GetMap(index);
        }

        static public void UpdateAddressList()
        {
            for (int i = 0; i < headerMap.MapCount; i++)
            {
                RawSampleGroup group = (RawSampleGroup)headerMap.GetMap(i);
                if (group != null)
                {
                    RomData.Set32(SampleSpec.RawSampleHeaderPointers + ((uint)i * 4), group.Address);
                }
            }
        }
    }
}
