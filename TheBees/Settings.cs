using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheBees
{
    static public class Settings
    {
        public const bool AutoUpdate = false;
        public const bool InstantUpdate = true;

        //public const string RomBackupSource = @"C:\Emulator\Arcade\cps3emulator\roms\sfiii3\DO_NOT_TOUCH\";
        public const string RomSource = @"C:\SF3\Roms\sfiii3\";
        public const string RomTarget = @"C:\SF3\Roms\sfiii3\";
        public const string GuideSource = @"guide.dat";
        public const string BaseRecordsSource = @"baserecords.dat";

        public const string DescriptionSource = @"description.dat";

        public const string StreamDataTarget = @"C:\fbasrc\research\";
        public const string StaticDescriptorSource = @"staticdesc.dat";

        public static bool GetGuideData = false;
        public const bool ShowModifyActionDataCount = true;
        public const bool SaveBaseData = true;
        public const bool SetStreamingData = true;
        public const bool AutoLoad = false;
        public const bool Debug = false;
    }
}
