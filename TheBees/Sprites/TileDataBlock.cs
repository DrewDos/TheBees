using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TheBees.Data;
using TheBees.Records;
using TheBees.User;

namespace TheBees.Sprites
{
    public class TileDataBlock : RomDataBlock
    {
        protected override RecordSpaceGroup spaceGroup { get { return RecordGuide.UserSpace; } }

        public TileDataBlock(uint start)
            : base(start)
        {
        }

        static public TileDataBlock GetRecordable(TileDef def)
        {
            if (!MasterList.ContainsKey(def.RealSource))
            {
                int newBlockSize = -1;
                if(creatingBaseRecords) newBlockSize = GetTileDataSize(def, def.Parent.RealLookupAddress, def.Parent.GetRawDataSize());
                TileDataBlock newBlock = new TileDataBlock(def.RealSource);
                if (creatingBaseRecords)
                {
                    newBlock.BlockSize = newBlockSize;
                    newBlock.InitializeRecord();
                }
            }

            return (TileDataBlock)MasterList[def.RealSource];
        }

        static private int GetTileDataSize(TileDef def, uint lookupAddress, int rawSize)
        {

            uint currSource = def.RealSource;
            int dataSize;

            if (!Recordable.MasterList.ContainsKey(currSource))
            {
                dataSize = CalcSpriteDataSize(
                    def.RealSource,
                    def.RealDestination,
                    def.RealLength,
                    lookupAddress,
                    rawSize);

            }
            else
            {
                dataSize = Recordable.MasterList[currSource].SizeInBytes;
            }

            if (dataSize % 2 > 0)
            {
                dataSize += 1;
            }
            
            return dataSize;
        }



        static private int CalcSpriteDataSize(uint realSource, uint realDestination, uint realLength, uint lookupAddr, int rawDataSize)
        {
            uint startSource = realSource;
            int length = 0;

            uint lengthRemaining = realLength;
            byte lastNormalByte = 0;

            while (lengthRemaining > 0)
            {
                byte currentByte = RomData.Get8(realSource);
                realSource++;
                length = (int)(realSource - startSource);

                if ((currentByte & 0x80) > 0)
                {

                    byte realByte;
                    uint lengthProcessed;
                    currentByte &= 0x7f;

                    realByte = RomData.Get8(lookupAddr, currentByte * 2 + 0);

                    lengthProcessed = ProcessByte(realByte, realDestination, lengthRemaining, rawDataSize, ref lastNormalByte);
                    lengthRemaining -= lengthProcessed; // subtract the number of bytes the operation has taken
                    realDestination += lengthProcessed; // add it onto the destination
                    if (realDestination > rawDataSize) return length;
                    if (lengthRemaining <= 0) return length; // if we've expired, exit

                    realByte = RomData.Get8(lookupAddr, currentByte * 2 + 1);

                    lengthProcessed = ProcessByte(realByte, realDestination, lengthRemaining, rawDataSize, ref lastNormalByte);
                    lengthRemaining -= lengthProcessed; // subtract the number of bytes the operation has taken
                    realDestination += (uint)lengthProcessed; // add it onto the destination
                    //if (realDestination > rawDataSize) return;
                    if (lengthRemaining <= 0) return length;  // if we've expired, exit

                }
                else
                {

                    uint lengthProcessed;
                    lengthProcessed = (uint)ProcessByte(currentByte, realDestination, lengthRemaining, rawDataSize, ref lastNormalByte);
                    lengthRemaining -= lengthProcessed; // subtract the number of bytes the operation has taken
                    realDestination += lengthProcessed; // add it onto the destination
                    //if (realDestination > rawDataSize) return;
                    if (lengthRemaining <= 0) return length;  // if we've expired, exit

                }
            }

            return length;
        }


        static private uint ProcessByte(byte realByte, uint destination, uint maxLength, int rawDataSize, ref byte lastNormalByte)
        {

            if ((realByte & 0x40) > 0)
            {
                uint tranfercount = 0;
                int rleLength = (int)(realByte & (uint)0x3f) + 1;

                while (rleLength > 0)
                {
                    tranfercount++;
                    rleLength--;
                    maxLength--;
                    if ((destination + tranfercount) > rawDataSize) return maxLength;
                }

                return tranfercount;
            }
            else
            {
                lastNormalByte = realByte;
                return 1;
            }
        }
    }
}
