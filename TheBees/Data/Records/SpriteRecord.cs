//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//using TheBees.Sprites;
//using System.IO;

//namespace TheBees.Records
//{
//    static class SpriteRecord
//    {
//        static private Dictionary<uint, List<uint>> tileDataPointerList = new Dictionary<uint, List<uint>>();
//        static private Dictionary<uint, int> tileDataSizes = new Dictionary<uint, int>();

//        static private Dictionary<uint, List<uint>> lookupTablePtrList = new Dictionary<uint, List<uint>>();
//        //static private Dictionary<uint, int> lookupTableList = new Dictionary<uint, int>();

//        static private Dictionary<int, NormalSpriteDef> spriteDefs = new Dictionary<int, NormalSpriteDef>();


//        static private uint[] problemIndexes = new uint[]
//        {
//            0x000009DD,
//            0x000022C2,
//            0x000027CC,
//            0x00002FA0,
//            0x00003ACF,
//            0x0000410B,
//            0x0000539B,
//            0x00005883,
//            0x000065FF,
//            0x00006B10,
//            0x0000714B,
//            0x0000767F,
//            0x00009513,
//            0x000095DE,
//            0x000096D7,
//            0x0000974A,
//            0x0000994E,
//            0x00009A1B,
//            0x00009B0E,
//            0x00009B2B,
//            0x00009B37,
//            0x00009B63,
//            0x00009B6B,
//            0x00009B77,
//            0x00009B8F,
//            0x00009B9B,
//            0x00009BA7,
//            0x00009C87,
//            0x00009D24,
//            0x00009DA7,
//            0x00009DBF,
//            0x00009E67,
//            0x00009FF6,
//            0x0000A1DA,
//            0x0000A9F7,
//            0x0000B1E7,
//            0x0000B2B2,
//            0x0000B348,
//            0x0000B40D,
//            0x0000B4B7,
//            0x0000B4ED,
//            0x0000B521,
//            0x0000B5A7,
//            0x0000B627,
//            0x0000B6A7,
//            0x0000B727,
//            0x0000B7A7,
//            0x0000B827,
//            0x0000B8A7,
//            0x0000B927,
//            0x0000B9A7,
//            0x0000BA27,
//            0x0000BAA7,
//            0x0000BB27,
//            0x0000BBA7,
//            0x0000BC27,
//            0x0000BCA2,
//            0x0000BD1D,
//            0x0000BD57,
//            0x0000BDE7,
//            0x0000D87F,
//            0x0000D8CF,
//            0x0000D96F,
//            0x0000DA2F,
//            0x0000DA6F,
//            0x0000DABF,
//            0x0000DAFF,
//            0x0000DB3F,
//            0x0000DBEF,
//            0x0000DC3F,
//            0x0000DC9F,
//            0x0000DCDF,
//            0x0000DD5F,
//            0x0000DEDF,
//            0x0000DF1F,
//            0x0000DF88,
//            0x0000E09F,
//            0x0000E14F,
//            0x0000E16F,
//            0x0000E1EF,
//            0x0000E21F,
//            0x0000E272,
//            0x0000E2CF,
//            0x0000E31F,
//            0x0000E35F,
//            0x0000E3AF,
//            0x0000E3CF,
//            0x0000E3EF,
//            0x0000E44F,
//            0x0000E46F,
//            0x0000E597,
//            0x0000E5B7
//        };


//        static private Dictionary<uint, Record> records = new Dictionary<uint, Record>();

//        static public void LoadAllSpriteDefs()
//        {
//            int start = 0x00000 / 8;
//            int max = 0x80000 / 8;
//            int count = max - start;

//            List<uint> spriteAddresses = new List<uint>();

//            for (int i = 0; i < count; i++)
//            {
//                uint address = RomData.Get32(0x6800004, (i * 8));

//                if (address != 0)
//                {
//                    spriteDefs[i] = new NormalSpriteDef(address);
//                }
//                else
//                {
//                    spriteDefs[i] = null;
//                }
//            }
//        }

//        static public void ClearAllSpriteDefs()
//        {
//            uint extraAmt = 0;

//            for (int i = 0; i < spriteDefs.Count; i++)
//            {
//                if (spriteDefs[i] != null)
//                {
                    
//                    if(Array.Find(problemIndexes, (x) => x == (uint)i) != 0)
//                    {
//                        extraAmt = 8;
//                    }
//                    else
//                    {
//                        extraAmt = 0;
//                    }

//                    RomData.FillBlock(spriteDefs[i].Address, spriteDefs[i].SizeInBytes + (int)extraAmt, 0x69);
//                }
//            }
//        }

//        static public int CheckZeroData()
//        {
//            int nonZeroCount = 0;
//            List<uint> nonZeroLocs = new List<uint>();
//            List<uint> nonZeroStarts = new List<uint>();
//            List<int> indexesToCheck = new List<int>();
//            HashSet<int> problems = new HashSet<int>();

//            for (int i = 0x6880000; i < 0x7000000; i++)
//            {
//                byte value = RomData.Get8((uint)i, 0);
//                if (value != 0 && value != 0x69)
//                {
//                    nonZeroCount += 1;
//                    nonZeroLocs.Add((uint)i);
//                }
                
//            }

//            if (nonZeroLocs.Count > 1)
//            {
//                int sequenceCount = 1;

//                uint prev = nonZeroLocs[0];
//                nonZeroStarts.Add(prev);
//                int i = 1;
//                for (; i < nonZeroLocs.Count; i++)
//                {
//                    if (nonZeroLocs[i] != prev + 1)
//                    {
//                        nonZeroStarts.Add(nonZeroLocs[i]);
//                        sequenceCount += 1;
//                    }

//                    prev = nonZeroLocs[i];

//                }
//                nonZeroStarts[3] += 8;
//                for (i = 0; i < 0x80000 / 8; i++)
//                {
//                    if (spriteDefs[i] != null)
//                    {
//                        uint currDefEnd = spriteDefs[i].Address + (uint)spriteDefs[i].SizeInBytes;
//                        uint currCheckAddr = nonZeroStarts.Find((x) => x < currDefEnd + 8 );

//                        for (int j = 0; j < nonZeroStarts.Count; j++)
//                        {
//                            if (nonZeroStarts[j] < currDefEnd + 8 && nonZeroStarts[j] >= currDefEnd)
//                            {
//                                if (!problems.Contains(i))
//                                {
//                                    problems.Add(i);
//                                }
//                            }

//                            if (nonZeroStarts[j] >= spriteDefs[i].Address && nonZeroStarts[j] < spriteDefs[i].Address + 8)
//                            {
//                                throw new Exception("found");
//                            }
//                        }
//                        if (currCheckAddr != 0)
//                        {
//                            indexesToCheck.Add(i);
//                        }
//                    }
//                }
//            }

//            List<string> output = new List<string>();
//            output.Add("static private uint[] problemIndexes = new uint[]");
//            output.Add("{");
//            foreach(int addIndex in problems)
//            {
//                output.Add("    0x" + addIndex.ToString("X8") + ",");

//            }
//            output[output.Count - 1] = output[output.Count - 1].Substring(0, output[output.Count - 1].Length - 1);
//            output.Add("}");

//            if (indexesToCheck.Count > 0)
//            {
//                File.WriteAllLines(@"C:\indexesToCheck.txt", output.ToArray());
//            }

//            output.Clear();

//            foreach (int addIndex in indexesToCheck)
//            {
//                output.Add((spriteDefs[addIndex].Address - 0x6800000).ToString("X8") + " - " + spriteDefs[addIndex].Address.ToString("X8"));

//            }
//            if (indexesToCheck.Count > 0)
//            {
//                File.WriteAllLines(@"C:\addressOfDefs.txt", output.ToArray());
//            }

//            output.Clear();

//            foreach (KeyValuePair<int, NormalSpriteDef> kvp in spriteDefs)
//            {
//                NormalSpriteDef sd = kvp.Value;

//                if (sd != null && sd.StartValue != 0x8000)
//                {
//                    output.Add((sd.Address - 0x6800000).ToString("X8") + " - " + sd.Address.ToString("X8"));
//                }
//            }
//            if (indexesToCheck.Count > 0)
//            {
//                File.WriteAllLines(@"C:\hasStarts.txt", output.ToArray());
//            }
//            return nonZeroCount;
//        }
//        static public void AnalazeData()
//        {
//            List<uint> spriteAddresses = new List<uint>();

//            int start = 0x00000 / 8;
//            int max = 0x80000 / 8;
//            int count = max - start;
//            //for (int i = 0; i < 1000; i++)
//            for (int i = start; i < max; i++)
//            {
//                spriteAddresses.Add(RomData.Get32(0x6800004, (i * 8)));
//            }
            
//            int tileListStart = 0x0C;
//            int tileListBlock = 0x08;

//            //for (int i = 0; i < 1000; i++)
//            for (int i = 0; i < count; i++)
//            {
//                uint address = spriteAddresses[i];
                
//                if (address != 0)
//                {
//                    ushort startTag = RomData.Get16(address);
//                    ushort tileCt = RomData.Get16(address, 4);
//                    ushort tileGroupCt = RomData.Get16(address, 6);
//                    uint lookupAddr = RomData.Get32(address, 8);
//                    lookupAddr = (lookupAddr << 1) - 0x400000;
//                    ushort unknown = RomData.Get16(address, 2);

//                    int spriteDefSize = 0x0C + tileCt * 8 + tileGroupCt * 8;
//                    if(!records.ContainsKey(address))
//                    {
//                        records[address] = new Record(address, spriteDefSize);
//                    }
//                    TileDef[] tileDefs = new TileDef[tileCt];


//                    if (!lookupTablePtrList.ContainsKey(lookupAddr))
//                    {
//                        lookupTablePtrList[lookupAddr] = new List<uint>();
//                    }

//                    lookupTablePtrList[lookupAddr].Add(address + 8);

//                    for (int tileNum = 0; tileNum < tileCt; tileNum++)
//                    {
//                        int dataOffset = tileListStart + tileNum * tileListBlock;

//                        tileDefs[tileNum] = new TileDef(
//                            null,
//                            RomData.Get16(address, dataOffset + 4),
//                            RomData.Get16(address, dataOffset + 6),
//                            RomData.Get32(address, dataOffset));

                        
//                        uint pointerAddr = address+(uint)(dataOffset);
//                        if (!tileDataPointerList.ContainsKey(tileDefs[tileNum].RealSource))
//                        {
//                            tileDataPointerList[tileDefs[tileNum].RealSource] = new List<uint>();
//                        }

//                        tileDataPointerList[tileDefs[tileNum].RealSource].Add(pointerAddr);

//                    }

//                    int rawSize = GetRawDataSize(tileDefs);
//                    int dataSize = 0;

//                    for (int tileNum = 0; tileNum < tileCt; tileNum++)
//                    {
//                        if (tileDefs[tileNum].RealDestination != 0)
//                        {
//                            int a = 0;
//                        }
//                        dataSize = CalcSpriteDataSize(
//                            tileDefs[tileNum].RealSource,
//                            tileDefs[tileNum].RealDestination,
//                            tileDefs[tileNum].RealLength,
//                            lookupAddr,
//                            rawSize);

//                        tileDataSizes[tileDefs[tileNum].RealSource] = dataSize;
//                    }
//                }
//            }

//            foreach (KeyValuePair<uint, List<uint>> lookupPtrs in lookupTablePtrList)
//            {
//                Record record = new Record(lookupPtrs.Key, 0x100);
//                records[lookupPtrs.Key] = record;
//            }

//            foreach (KeyValuePair<uint, int> dataSize in tileDataSizes)
//            {
//                Record record = new Record(dataSize.Key, dataSize.Value);
//                records[dataSize.Key] = record;
//            }

//            records.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

//            uint addressStart = 0xFFFFFFFF;
//            uint addressEnd = 0;

//            foreach (KeyValuePair<uint, Record> record in records)
//            {
//                RomData.FillBlock(record.Value.Start, record.Value.Size-1, 0x00);
//                RomData.Set8(record.Value.Start + (uint)record.Value.Size, 0xFF);
//            }
            
//            Record previousRecord = null;
//            int index = 0;
//            foreach (KeyValuePair<uint, Record> record in records)
//            {
//                if (addressStart > record.Value.Start)
//                    addressStart = record.Value.Start;

//                if (addressEnd < record.Value.Start + record.Value.Size)
//                    addressEnd = (uint)record.Value.Size + record.Value.Start;

//                previousRecord = record.Value;
//                index++;
//            }
            
//        }

//        static private int GetRawDataSize(TileDef[] tileList)
//        {
//            int len = tileList.Length;
//            uint result = 0;
//            uint currSz = 0;

//            for (int i = 0; i < len; i++)
//            {
//                currSz = tileList[i].RealDestination + tileList[i].RealLength;
//                if (result < currSz)
//                    result = currSz;
//            }

//            return (int)result;
//        }

//        static private int CalcSpriteDataSize(uint realSource, uint realDestination, uint realLength, uint lookupAddr, int rawDataSize)
//        {
//            uint startSource = realSource;
//            int length = 0;

//            uint lengthRemaining = realLength;
//            byte lastNormalByte = 0;

//            while (lengthRemaining > 0)
//            {
//                byte currentByte = RomData.Get8(realSource);
//                realSource++;
//                length = (int)(realSource - startSource);

//                if ((currentByte & 0x80) > 0)
//                {

//                    byte realByte;
//                    uint lengthProcessed;
//                    currentByte &= 0x7f;

//                    realByte = RomData.Get8(lookupAddr, currentByte * 2 + 0);

//                    lengthProcessed = ProcessByte(realByte, realDestination, lengthRemaining, rawDataSize, ref lastNormalByte);
//                    lengthRemaining -= lengthProcessed; // subtract the number of bytes the operation has taken
//                    realDestination += lengthProcessed; // add it onto the destination
//                    if (realDestination > rawDataSize) return length;
//                    if (lengthRemaining <= 0) return length; // if we've expired, exit

//                    realByte = RomData.Get8(lookupAddr, currentByte * 2 + 1);

//                    lengthProcessed = ProcessByte(realByte, realDestination, lengthRemaining, rawDataSize, ref lastNormalByte);
//                    lengthRemaining -= lengthProcessed; // subtract the number of bytes the operation has taken
//                    realDestination += (uint)lengthProcessed; // add it onto the destination
//                    //if (realDestination > rawDataSize) return;
//                    if (lengthRemaining <= 0) return length;  // if we've expired, exit

//                }
//                else
//                {

//                    uint lengthProcessed;
//                    lengthProcessed = (uint)ProcessByte(currentByte, realDestination, lengthRemaining, rawDataSize, ref lastNormalByte);
//                    lengthRemaining -= lengthProcessed; // subtract the number of bytes the operation has taken
//                    realDestination += lengthProcessed; // add it onto the destination
//                    //if (realDestination > rawDataSize) return;
//                    if (lengthRemaining <= 0) return length;  // if we've expired, exit

//                }
//            }

//            return length;
//        }

//        static private uint ProcessByte(byte realByte, uint destination, uint maxLength, int rawDataSize, ref byte lastNormalByte)
//        {

//            if ((realByte & 0x40) > 0)
//            {
//                uint tranfercount = 0;
//                int rleLength = (int)(realByte & (uint)0x3f) + 1;

//                while (rleLength > 0)
//                {
//                    //int index = (int)(destination + tranfercount);
//                    //if (index >= 0)
//                        //rawData[index] = (byte)(lastNormalByte & 0x3f);


//                    tranfercount++;
//                    rleLength--;
//                    maxLength--;
//                    if ((destination + tranfercount) > rawDataSize) return maxLength;
//                }

//                return tranfercount;
//            }
//            else
//            {
//                //uint index = (destination);
//                //if ((int)index >= 0)
//                    //rawData[index] = realByte;
//                lastNormalByte = realByte;
//                return 1;
//            }
//        }
//    }
//}
