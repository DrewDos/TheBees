using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TheBees.GameRom;

namespace TheBees.UnitData
{
    class UnitMissile : Unit
    {
        private PropertyGroup missileGroup;
        public PropertyGroup MissileGroup { get { return missileGroup; } }

        public UnitMissile(uint address, int index, uint configPointerSource, int sourceConfigCount = 0)
            : base(address, index)
        {
            propertyLoader = new Missile.MissilePropertyLoader(this, sourceConfigCount, configPointerSource);
            propertyLoader.CallLoadGroup = OnCallLoadPropertyGroup;

            LoadUnit();

            missileGroup = ((Missile.MissilePropertyLoader)propertyLoader).MissileGroup;
        }



    }
}
