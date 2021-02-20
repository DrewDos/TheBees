using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TheBees.GameRom;

namespace TheBees.UnitData
{
    class OrbitalBasisGroup : SuppleValueRange
    {

        public OrbitalBasisGroup(uint srcAddress, int srcCount)
            :base(srcAddress, srcCount, 4)
        {

        }


    }
}
