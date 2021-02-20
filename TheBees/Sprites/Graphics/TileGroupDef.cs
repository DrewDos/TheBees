using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheBees.Sprites
{
    public class TileGroupDef
    {
        private ushort tileStartOffset;
        private byte byte3;
        private byte flipHorizontal;
        private byte flipVertical;
        private short _xOffset;
        private byte width;
        private byte height;
        private short _yOffset;
        private short xOffset { set { _xOffset = FromSigned12(value); } }
        private short yOffset { set { _yOffset = FromSigned12(value); } }
        private byte unknownFlag;


        public byte Byte3 { get { return byte3; } }
        public ushort TileStartOffset { get { return tileStartOffset; } }
        public short XOffset { get { return _xOffset; } }
        public short YOffset { get { return _yOffset; } }
        public byte Width { get { return width; } }
        public byte Height { get { return height; } }
        public byte FlipHorizontal { get { return flipHorizontal; } }
        public byte FlipVertical { get { return flipVertical; } }
        public byte UnknownFlag { get { return unknownFlag; } }

        public TileGroupDef(byte[] buf)
        {
            tileStartOffset = (RomData.Rotate16((ushort)BitConverter.ToInt16(buf, 0)));

            flipVertical = (byte)((buf[2] & 0x08) >> 3);
            flipHorizontal = (byte)((buf[2] & 0x10) >> 4);
            unknownFlag = (byte)(buf[2] & 0x07);


            byte3 = buf[3];
            width = (byte)((buf[6] >> 4) & 0x03);
            height = (byte)((buf[6] >> 6) & 0x03);

            width = width == (byte)3 ? (byte)4 : width;
            height = height == (byte)3 ? (byte)4 : height;

            xOffset = (short)(RomData.Rotate16((ushort)BitConverter.ToInt16(buf, 4)) & 0x0FFF);
            yOffset = (short)(RomData.Rotate16((ushort)BitConverter.ToInt16(buf, 6)) & 0x0FFF);
        }

        private short FromSigned12(short val)
        {
            ushort output = (ushort)val;

            if ((val & 0x0800) > 0)
            {
                output |= 0xF000;
            }

            return (short)output;

        }
    }
}
