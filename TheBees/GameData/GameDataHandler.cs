using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TheBees.GameRom;

namespace TheBees.GameData
{
    class GameDataHandler
    {
        static private SuppleValueRange specialGraphicRedirect;
        static public SuppleValueRange SpecialGraphicRedirect { get { return specialGraphicRedirect; } }

        static public void Initialize()
        {
            specialGraphicRedirect = new SuppleValueRange(0x61B8CFC, 0x0E, 2);
        }
    }
}
