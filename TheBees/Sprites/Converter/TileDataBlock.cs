using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpriteCreator
{
    public class TileDataBlock
    {
        public byte[] RawData { get { return rawData; }}
        public int Length { get { return length;}}
        public int Destination { get { return destination; } }

        private byte[] rawData;
        private int length;
        private int destination;

        public TileDataBlock(byte[] rawDataSource, int sourceLength, int sourceDestination)
        {
            rawData = rawDataSource;
            length = sourceLength;
            destination = sourceDestination;
        }
    }
}
