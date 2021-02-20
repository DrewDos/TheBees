using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using TheBees.GameRom;

namespace TheBees
{
    //public enum KeyType
    //{
    //    Unit
    //}

    //static class RomGuide
    //{
    //    private const int MAX_UNIT = 0x80;
    //    static private readonly int MAX_KEY = 0x80;
        
    //    private const int totalKeySize = 1 + 1 + 4; // unit size + guide key size + value size

    //    static private int[][] guideData = new int[MAX_UNIT][];
    //    static private byte[] md5 = null;
    //    static private bool initialized = false;
    //    static private byte currentUnit;

    //    static private bool dataLoaded = false;
    //    static private bool pendingSave = false;
    //    static public bool DataLoaded { get { return dataLoaded; } }
    //    static public bool PendingSave { get { return pendingSave; } }
 
    //    static public byte[] Checksum { get { return md5; } set { md5 = value; } }
    //    static private string target = "";

    //    static public void Clear()
    //    {
    //        guideData = null;
    //        guideData = new int[MAX_UNIT][];
    //        dataLoaded = false;
    //        pendingSave = false;
    //        md5 = null;
    //        initialized = false;
    //        Initialize();
    //    }
    //    static public void Initialize()
    //    {
    //        if (!initialized)
    //        {
    //            Array.Clear(guideData, 0, MAX_UNIT);

    //            initialized = true;
    //        }
    //    }

    //    static public void SetMD5(byte[] newMD5)
    //    {
    //        md5 = null;
    //        md5 = new byte[newMD5.Length];

    //        Array.Copy(newMD5, md5, newMD5.Length);
    //    }

    //    static public bool LoadData(string source)
    //    {
    //        if (!File.Exists(source))
    //            return false;
            
    //        BinaryReader reader = new BinaryReader(File.Open(source, FileMode.Open));
    //        uint md5Count = reader.ReadUInt32();
    //        md5 = reader.ReadBytes((int)md5Count);
    //        // length should be fine
    //        // it should never go past int type
    //        int fileSize = (int)reader.BaseStream.Length-sizeof(uint)-md5.Length;
    //        int count = fileSize / totalKeySize;
    //        byte unit, key;
    //        int value;
        

    //        for (int i = 0; i < count; i++)
    //        {
    //            try
    //            {
    //                unit = reader.ReadByte();
    //                key = reader.ReadByte();
    //                value = (int)reader.ReadUInt32();
    //            }
    //            catch (EndOfStreamException)
    //            {
    //                reader.Close();
    //                File.Delete(source);
    //                Clear();
    //                return false;
    //            }

    //            if (!UnitExists(unit))
    //                InitUnit(unit);

    //            guideData[unit][key] = value;
    //        }

    //        reader.Close();
    //        dataLoaded = true;
    //        return true;
    //    }

    //    static public void SaveData(string destination)
    //    {
    //        BinaryWriter writer = new BinaryWriter(File.Open(destination, FileMode.Create));

    //        writer.Write((uint)md5.Length);
    //        writer.Write(md5, 0, md5.Length);

    //        for (byte i = 0; i < MAX_UNIT; i++)
    //        {
    //            if (UnitExists(i))
    //            {
    //                for (int j = 0; j < MAX_KEY; j++)
    //                {
    //                    if (KeyExists(i, j))
    //                    {
    //                        // write unit
    //                        writer.Write(i);

    //                        // write guide key
    //                        writer.Write((byte)j);

    //                        // write value
    //                        writer.Write(guideData[i][j]);
    //                    }
    //                }
    //            }
    //        }

    //        writer.Close();

    //        pendingSave = false;
    //    }

    //    static public void SetValue(int unit, int key, int value)
    //    {
    //        if (guideData[unit] == null) throw new ArgumentException("unit has not been initialized");

    //        guideData[unit][(byte)key] = value;
    //        pendingSave = true;
    //    }
    //    /*
    //    static public void SetValue(int unit, GuideKey key, uint value)
    //    {
    //        guideData[currentUnit][(int)key] = value;
    //        pendingSave = true;
    //    }
    //    */

    //    static public int GetValue(int unit, int key)
    //    {
    //        if (guideData[unit] != null)
    //        {
    //            return guideData[unit][key];
    //        }

    //        return 0;
    //    }

    //    //static public uint GetValue(int key)
    //    //{
    //    //    return guideData[currentUnit][(byte)key];
    //    //}

    //    static private bool UnitExists(int unit)
    //    {
    //        if(guideData[unit] != null) 
    //            return true;
    //        else
    //            return false;
    //    }
    //    static private bool KeyExists(int unit, int key)
    //    {
    //        return guideData[unit][(byte)key] != 0 ? true : false;
    //    }

    //    static public void InitUnit(int unit)
    //    {
    //        if (!UnitExists(unit))
    //        {
    //            guideData[unit] = new int[MAX_KEY];
    //            ClearUnit(unit);
    //        }
    //    }

    //    static private void InitAllUnits()
    //    {
    //        for (int i = 0; i < MAX_UNIT; i++)
    //        {
    //            InitUnit(i);
    //        }
    //    }

    //    static private void ClearUnit(int unit)
    //    {
    //        Array.Clear(guideData[unit], 0, MAX_KEY);
    //    }

    //    static private void ClearAllUnits()
    //    {
    //        for (int i = 0; i < MAX_UNIT; i++)
    //        {
    //            ClearUnit(i);
    //            pendingSave = false;
    //        }
    //    }

    //    static public void SetUnit(byte unit)
    //    {
    //        if (unit >= MAX_UNIT)
    //        {
    //            throw new IndexOutOfRangeException();
    //        }
    //        else
    //        {
    //            currentUnit = unit;
    //            InitUnit(unit);
    //        }

    //    }

    //    static public void OnRomLoad()
    //    {
    //        // load, or set, the proper guide
    //        Globals.GetGuideDataAsBase = false;

    //        if (Globals.IsBaseRom)
    //        {
    //            // base rom 

    //            // load guide data
    //            if (!File.Exists(Settings.BaseGuideSource))
    //            {
    //                Globals.GetGuideDataAsBase = true;
    //            }
    //            else
    //            {
    //                if (!RomGuide.LoadData(Settings.BaseGuideSource))
    //                {
    //                    Globals.GetGuideDataAsBase = true;
    //                }
    //            }

    //            target = Settings.BaseGuideSource;

    //        }
    //        else
    //        {
    //            // not base rom

    //            // load guide data
    //            if (!RomGuide.LoadData(Settings.GuideSource) || !RomGuide.Checksum.SequenceEqual(RomData.Checksum))
    //            {
    //                RomGuide.Clear();
    //                Globals.GetGuideDataAsBase = true;
    //                target = Settings.GuideSource;
    //            }

    //        }
    //    }

    //    static public void OnUnitsLoaded()
    //    {

    //        // get guide data after units are loaded
    //        if (Globals.GetGuideDataAsBase)
    //        {
    //            RomGuide.SetMD5(RomSpec.BaseChecksum);
    //            RomGuide.SaveData(target);
    //        }
    //    }
    //}
}
