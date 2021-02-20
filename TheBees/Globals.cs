using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheBees
{
    static class Globals
    {
        static public bool RomLoaded { get; set; }
        static public string RomLocation { get; set; }
        static public RomType LoadedType { get; set; }
        static public bool GetGuideDataAsBase { get; set; }
        static public bool HasStaticData { get; set; }
        static public bool IsBaseRom { get; set; }
    }
}
