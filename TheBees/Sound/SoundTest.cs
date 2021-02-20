using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using TheBees.GameRom;

namespace TheBees.Sound
{
    // sample list address
    // has all of the offsets to the sample headers

    // raw sample header offset
    // raw sample header

    // raw sample data reference

    //public static class SoundTest
    //{
    //    private static uint[] rawHeaderGroupList = null;

    //    private static uint GetSampleHeaderOffset(int numSample)
    //    {
    //        uint offset = RomData.Get32(SampleSpec.SampleHeaderListAddress, (numSample << 2));

    //        if (offset == 0)
    //        {
    //            throw new InvalidSampleHeaderOffsetException();
    //        }
    //        else
    //        {
    //            return offset;
    //        }
    //    }

    //    private static uint GetSampleHeaderAddress(uint headerOffset)
    //    {
    //        return SampleSpec.SampleHeaderListAddress + headerOffset;
    //    }

    //    private static SoundEffect GetSampleHeader(uint address)
    //    {
    //        return new SoundEffect(address);
    //    }

    //    private static RawSampleHeader GetRawSampleHeader(int rawHeaderGroupNum, uint sampleOffset)
    //    {
    //        return new RawSampleHeader( RomData.Get16(rawHeaderGroupList[rawHeaderGroupNum], (int)sampleOffset*2) + rawHeaderGroupList[rawHeaderGroupNum]);
    //    }

    //    private static RawSampleDataRef GetRawSampleDataRef(int refNum)
    //    {
    //        return new RawSampleDataRef( SampleSpec.RawSampleDataListAddress + (uint)(refNum << 4));
    //    }

    //    private static void SetGroupList()
    //    {
    //        if (rawHeaderGroupList == null)
    //        {
    //            rawHeaderGroupList = RomData.GetAddressList(SampleSpec.RawSampleHeaderListAddress, SampleSpec.RawSampleHeaderListAmount).ToArray();
    //        }
    //    }

    //    public static void TestGetSample(int numSample)
    //    {
    //        SetGroupList();

    //        uint sampleHeaderOffset = GetSampleHeaderAddress(GetSampleHeaderOffset(numSample+1));

    //        SoundEffect sampleHeader = GetSampleHeader(sampleHeaderOffset);

    //        if (sampleHeader.SampleNodes.Count > 0)
    //        {
    //            for (int i = 0; i < sampleHeader.SampleNodes.Count; i++)
    //            {
    //                SampleNode currNode = sampleHeader.SampleNodes[i];

    //                if (currNode.BankIndex == -1 || currNode.SoundIndex == -1)
    //                    continue;

    //                RawSampleHeader rawHeader = GetRawSampleHeader(currNode.BankIndex, (uint)currNode.SoundIndex);
    //                RawSampleDataRef dataRef = GetRawSampleDataRef(rawHeader.RawSampleDataRefNum);

    //                // save file
    //                string fileName = (numSample).ToString("X4") + "-" + i.ToString("X2") + ".raw";
    //                if (!Directory.Exists(@"C:\sf3sound\base\"))
    //                {
    //                    Directory.CreateDirectory(@"C:\sf3sound\base\");
    //                }
    //                string target = @"C:\sf3sound\base\" + fileName;

    //                //Wav wav = new Wav(RomData.GetBlock(dataRef.Start, dataRef.Length));
    //                //wav.SaveRaw(target);
    //            }
    //        }

    //        sampleHeader.WriteSoundEffect();
    //    }

    //    public static void TestGetSampleSet()
    //    {
    //        for (int i = 0x000; i < 0xA00; i += 1)
    //        {
    //            try
    //            {
    //                TestGetSample(i);
    //            }
    //            catch (InvalidSampleHeaderOffsetException)
    //            {
    //                continue;
    //            }
    //        }

    //        //for (int i = 0; i < 0x2DD; i++)
    //        //{
    //        //    RawSampleDataRef dataRef = GetRawSampleDataRef(i);
    //        //    string fileName = i.ToString("X3")+".raw";
    //        //    string target = @"C:\sf3sound\base\" + fileName;

    //        //    //Wav wav = new Wav(RomData.GetBlock(dataRef.Start, dataRef.Length));
    //        //    //wav.SaveRaw(target);

    //        //    RomData.FillBlock(dataRef.Start, dataRef.Length, 0x00);
    //        //}
    //    }
    //}
}
