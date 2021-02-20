using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;


namespace TheBees
{
    public enum RomType
    {
        COMBINED,
        SEPARATED,
        NONE
    }
    public delegate void OnUpdateNode();

    static class RomData
    {
        static public byte[] Checksum { get { return GetMD5();} }
        static public byte[] programData;
        static public byte[] userData;

        static private string[] romNamesCombined = GetRomNamesCombined();
        static private string[] romNamesSeparated = GetRomNamesSeparated();

        private const int combinedRomSize = 0x800000;
        private const int separatedRomSize = 0x200000;

        static private Action<int, string> onLoadFileUpdate = null;
        static public Action<int, string> OnLoadFileUpdate { set { onLoadFileUpdate = value; } }

        static private int romFileCountCombined = 0;
        static private int romFileCountSeparated = 0;

        static public string[] RomNamesCombined { get { return romNamesCombined; } }
        static public string[] RomNamesSeparated { get { return romNamesSeparated; } }

        static public int RomFileCountCombined { get { return romFileCountCombined; }}
        static public int RomFileCountSeparated { get { return romFileCountSeparated; } }

        static private Dictionary<int, Func<uint, int, uint>> getMethods = RetrieveGetMethods();
        static private Dictionary<int, Action<uint, uint>> setMethods = RetrieveSetMethods();

        static public void Clear()
        {
            programData = null;
            userData = null;
        }

        static public void Initialize()
        {
            romFileCountCombined = romNamesCombined.Count();
            romFileCountSeparated = romNamesSeparated.Count();
        }

        static public void LoadRomData(string source, RomType type)
        {
            switch (type)
            {
                case RomType.COMBINED:
                    LoadCombined(source);
                    break;

                case RomType.SEPARATED:
                    LoadSeparated(source);
                    break;
            }
        }

        static private byte[] GetMD5()
        {
            MD5 md5 = MD5.Create();
            md5.ComputeHash(programData, 0, combinedRomSize * 2);
            return md5.Hash;
        }

        static public void SaveRomData(string source, RomType type)
        {
            switch (type)
            {
                case RomType.SEPARATED:
                    break;
                case RomType.COMBINED:
                    SaveCombined(source);
                    break;
            }
        }

        static public List<uint> GetAddressList(uint offset)
        {

            uint address = Rotate32(Get32(programData, (int)GetProperOffset(offset)));
            List<uint> list = new List<uint>();

            while (address >= 0x06000000 && address <= 0x7000000)
            {
                list.Add(address);
                offset += 4;
                address = Rotate32(Get32(programData, (int)GetProperOffset(offset)));
            }

            return list;
        }
        static public List<uint> GetAddressList(uint offset, int count)
        {

            List<uint> list = new List<uint>();

            for (int i = 0; i < count; i++)
            {
                list.Add(Rotate32(Get32(programData, (int)GetProperOffset(offset + (uint)(i * 4)))));
            }

            return list;
        }

        static private Dictionary<int, Func<uint, int, uint>> RetrieveGetMethods()
        {
            Dictionary<int, Func<uint, int, uint>> output = new Dictionary<int, Func<uint, int, uint>>();
            output[1] = (a, o) => { return (uint)Get8(a, o); };
            output[2] = (a, o) => { return (uint)Get16(a, o); };
            output[4] = Get32;

            return output;
        }

        static private Dictionary<int, Action<uint, uint>> RetrieveSetMethods()
        {
            Dictionary<int, Action<uint, uint>> output = new Dictionary<int, Action<uint, uint>>();

            output[1] = (a, d) => { Set8(a, (byte)d); };
            output[2] = (a, d) => { Set16(a, (ushort)d); };
            output[4] = (a, d) => { Set32(a, (uint)d); };

            return output;
        }

        static public uint GetData(uint address, int sizeInBytes)
        {
            switch (sizeInBytes)
            {
                case 1:
                    return (uint)Get8(address);
                case 2:
                    return (uint)Get16(address);
                case 4:
                    return Get32(address);
                default:
                    throw new ArgumentException("sizeInBytes can only be 1, 2, or 4");
            }

           // return getMethods[sizeInBytes](address, 0);
        }


        static public void SetData(uint address, uint data, int sizeInBytes)
        {
            switch (sizeInBytes)
            {
                case 1:
                    Set8(address, (byte)data);
                    return;
                case 2:
                    Set16(address, (ushort)data);
                    return;
                case 4:
                    Set32(address, (uint)data);
                    return;
                default:
                    throw new ArgumentException("sizeInBytes can only be 1, 2, or 4");
            }

            //setMethods[sizeInBytes](address, data);
        }

        static public byte Get8(uint address, int offset = 0)
        {
            address += (uint)offset;
            return GetBuffer(address)[GetProperOffset(address)];
        }

        static public ushort Get16(uint address, int offset = 0)
        {
            address += (uint)offset;
            return Rotate16(Get16(GetBuffer(address), (int)GetProperOffset(address)));
        }

        static public uint Get32(uint address, int offset = 0)
        {
            address += (uint)offset;
            return Rotate32(Get32(GetBuffer(address), (int)GetProperOffset(address)));
        }

        static public byte GetRaw8(uint address, int offset = 0)
        {
            address += (uint)offset;
            return GetBuffer(address)[GetProperOffset(address)];
        }

        static public ushort GetRaw16(uint address, int offset = 0)
        {
            address += (uint)offset;
            return Get16(GetBuffer(address), (int)GetProperOffset(address));
        }

        static public uint GetRaw32(uint address, int offset = 0)
        {
            address += (uint)offset;
            return Get32(GetBuffer(address), (int)GetProperOffset(address));
        }

        static public void Set8(uint address, byte data)
        {
            GetBuffer(address)[GetProperOffset(address)] = data;
        }

        static public void Set16(uint address, ushort data)
        {
            Set16(GetBuffer(address), Rotate16(data), (int)GetProperOffset(address));
        }

        static public void Set32(uint address, uint data)
        {
            Set32(GetBuffer(address), Rotate32(data), (int)GetProperOffset(address));
        }

        static public byte[] GetBlock(uint address, int size)
        {
            byte [] output = new byte[size];

            Buffer.BlockCopy(GetBuffer(address), (int)GetProperOffset(address), output, 0, size);
            return output;
        }

        static public void SetBlock(uint address, byte[] block)
        {
            Buffer.BlockCopy(block, 0, GetBuffer(address), (int)GetProperOffset(address), block.Length);
        }
        
        static private string [] GetRomNamesCombined()
        {
            return new string[] { "10", "20", "30", "31", "40", "41", "50", "51", "60", "61" };
        }

        static private string [] GetRomNamesSeparated()
        {
            
            string [] output = new string[40]; // 5 roms, 4 roms have 8 files, 2 roms have 4 (40)
            int index = 0;

            for (int i = 0; i < 6; i++)
            {
                int max = i > 1 ? 8 : 4;

                for (int j = 0; j < max; j++)
                {
                    output[index] = String.Format("sfiii3-simm{0}.{1}", (i + 1), j);
                    index++;
                }
            }

            return output;            
        }

        static private void SaveCombined(string source)
        {
            
            byte[] encryptedProgramData = new byte[combinedRomSize * 2];
            Buffer.BlockCopy(programData, 0, encryptedProgramData, 0, combinedRomSize * 2);
            RomEncrypt.MaskRomData(encryptedProgramData, combinedRomSize * 2);
            //RomEncrypt.MaskRomData(encryptedProgramData, combinedRomSize * 2);

            byte[] target = encryptedProgramData;

            for (int i = 0; i < romNamesCombined.Count(); i++)
            {
                if (i >= 2)
                    target = userData;

                
                BinaryWriter w = new BinaryWriter(File.Open(source + romNamesCombined[i], FileMode.Create));

                w.Write(target, (i - (i >= 2 ? 2 : 0)) * combinedRomSize, combinedRomSize);
                w.Close();
                
            }
        }

        static private void SaveSeparated(string source)
        {

        }

        static private void LoadCombined(string source)
        {
            // load the program roms
            programData = new byte[combinedRomSize * 2];
            userData = new byte[combinedRomSize * 8];

            byte[] target = programData;

            for (int i = 0; i < romNamesCombined.Count(); i++)
            {
                if (i >= 2)
                    target = userData;

                if (onLoadFileUpdate != null)
                {
                    onLoadFileUpdate(i, romNamesCombined[i]);
                }

                BinaryReader b = new BinaryReader(File.Open(source + romNamesCombined[i], FileMode.Open));
                b.Read(target, (i - (i >= 2 ? 2 : 0)) * combinedRomSize, combinedRomSize);
                b.Close();
            }

            RomEncrypt.MaskRomData(programData, 2 * combinedRomSize);
        }

        static private void LoadSeparated(string source)
        {
            byte[] target = programData;

            // load the program roms
            programData = new byte[separatedRomSize * 8];
            userData = new byte[separatedRomSize * 32];

            for (int i = 0; i < romNamesSeparated.Count(); i++)
            {
                if (i >= 2)
                    target = userData;

                if (onLoadFileUpdate != null)
                {
                    onLoadFileUpdate(i, romNamesSeparated[i]);
                }
                BinaryReader b = new BinaryReader(File.Open(source + romNamesSeparated[i], FileMode.Open));
                b.Read(target, i - (i >= 8 ? 8 : 0) * separatedRomSize, separatedRomSize);
                b.Close();
            }

            RomEncrypt.MaskRomData(programData, 8 * separatedRomSize);
        }

        /*
        static private bool CheckDataLoaded()
        {
            if (programData == null || UserData == null)
            {
                // throw exception
                throw new ArgumentNullException("Data has not been loaded");
            }

            return true;
        }
        */

        //static public byte [] GetBlock(uint sourceAddress, int length)
        //{
        //    byte[] sourceBuffer = GetBuffer(sourceAddress);
        //    byte[] output = new byte[length];

        //    uint sourceOffset = GetProperOffset(sourceAddress);
        //    Buffer.BlockCopy(sourceBuffer, (int)sourceOffset, output, 0, (int)length);

        //    return output;
        //}

        static public void CopyBlock(uint sourceAddress, uint destinationAddress, int length)
        {
            byte[] sourceBuffer = GetBuffer(sourceAddress);
            byte[] destBuffer = GetBuffer(destinationAddress);

            if (sourceBuffer != destBuffer)
            {
                throw new Exception("Cannot copy between program and user roms");
            }

            uint sourceOffset = GetProperOffset(sourceAddress);
            Buffer.BlockCopy(sourceBuffer, (int)sourceOffset, sourceBuffer, (int)GetProperOffset(destinationAddress), (int)length);

        }

        static public void MoveBlock(uint sourceAddress, uint destinationAddress, int length)
        {

            CopyBlock(sourceAddress, destinationAddress, length);

            //for (int i = 0; i < length; i++)
            //{
            //    sourceBuffer[sourceOffset + i] = 0xAE;
            //}
        }

        static public void FillBlock(uint startAddress, int length, byte fill = 0xAE)
        {
            byte[] buffer = GetBuffer(startAddress);
            for (int i = 0; i < length; i++)
            {
                buffer[GetProperOffset(startAddress + (uint)i)] = fill;
            }
        }

        static public void ChangePointers(uint newAddress, int pointerOffset, params uint[] pointerAddresses)
        {
            for (int i = 0; i < pointerAddresses.Length; i++)
            {
                Set32(pointerAddresses[i], (uint)((int)newAddress+pointerOffset));
            }
        }
        unsafe static private void Set16(byte[] buffer, ushort data, int offset)
        {
            fixed (byte* byteSrc = buffer)
            {
                ushort* shortSrc = (ushort*)&byteSrc[offset];

                shortSrc[0] = data;
            }

        }

        unsafe static private void Set32(byte[] buffer, uint data, int offset)
        {
            fixed (byte* byteSrc = buffer)
            {
                uint* intSrc = (uint*)&byteSrc[offset];

                intSrc[0] = data;
            }
        }

        unsafe static private ushort Get16(byte[] buffer, int offset)
        {
            fixed (byte* byteSrc = buffer)
            {
                ushort* shortSrc = (ushort*)&byteSrc[offset];

                return shortSrc[0];
            }
        }

        unsafe static private uint Get32(byte[] buffer, int offset)
        {
            fixed (byte* byteSrc = buffer)
            {
                uint* intSrc = (uint*)&byteSrc[offset];

                return intSrc[0];
            }
        }


        static private byte[] GetBuffer(uint address)
        {
            //CheckDataLoaded();

            if (address >= 0x6000000)
            {
                return programData;
            }
            else
            {
                return userData;
            }

        }

        static private uint GetProperOffset(uint address)
        {
            return address > 0x6000000 ? address - 0x6000000 : address;
        }

        static public ushort Rotate16(ushort source)
        {
            return (ushort)((int)(source >> 8) | (int)(source << 8));
        }

        static public uint Rotate32(uint source)
        {
            return (uint)((int)(source << 24) + ((int)(source & 0x0000FF00) << 8) + ((int)(source & 0x00FF0000) >> 8) + (int)(source >> 24));
        }
        /*
        static private byte[] ProgramData
        {
            get
            {
                if (programData == null)
                {
                    // throw exception
                    throw new ArgumentNullException("Data has not been loaded");
                }
                else
                    return programData;
            }
        }
        

        static private byte[] UserData
        {
            get
            {
                if (userData == null)
                {
                    // throw exception
                    throw new ArgumentNullException("Data has not been loaded");
                }
                else
                    return userData;
            }
        }
        
        */
    }

    static class RomEncrypt
    {
        
        private const uint size = 0x800000;
        private const uint addr = 0x6000000;
        private const uint key1 = 0xA55432B4;
        private const uint key2 = 0xC129981;

        static private uint mirror32(uint value)
        {
            return (value & 0x000000FF) << 24 | (value & 0x0000FF00) << 8 | (value & 0x00FF0000) >> 8 | (value & 0xFF000000) >> 24;
        }

        static private ushort rotate_left(ushort value, ushort n)
        {
            ushort aux = (ushort)(value >> (16 - n));
            return (ushort)(((value << n) | aux) % 0x10000);
        }

        static private ushort rotxor(ushort val, ushort xorval)
        {

            ushort res;
            res = (ushort)(val + rotate_left(val, 2));
            res = (ushort)(rotate_left(res, 4) ^ (res & (val ^ xorval)));
            return res;
        }

        static private uint cps3_mask(uint address, uint key1, uint key2)
        {

            ushort val;
            address ^= key1;
            val = (ushort)((address & 0xffff) ^ 0xffff);

            val = (ushort)(rotxor(val, (ushort)(key2 & 0xffff)));
            val ^= (ushort)((address >> 16) ^ 0xffff);
            val = (ushort)(rotxor(val, (ushort)(key2 >> 16)));
            val ^= (ushort)((address & 0xffff) ^ (key2 & 0xffff));
            return (uint)((uint)val | ((uint)val << 16));
        }

        unsafe static public void MaskRomData(byte[] sourceData, int length)
        {
            fixed (byte* sourcePtr = sourceData)
            {
                uint* data = (uint*)sourcePtr;

                for (uint i = 0; i < length; i += 4)
                {
                    uint value = data[i / 4];
                    uint masked = mirror32(mirror32(value) ^ cps3_mask(i + addr, key1, key2));
                    data[i / 4] = masked;
                }
            }
        }
    }
}
