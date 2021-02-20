using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TheBees.Records;

namespace TheBees.UnitData.Missile
{
    class MissilePropertyLoader : PropertyLoader
    {
        private PropertyGroup missileGroup;
        private int missileConfigCount = 0;
        private uint pointer;

        public PropertyGroup MissileGroup { get { return missileGroup; } }

        public MissilePropertyLoader(Unit unit, int configCount, uint configPointer)
            : base(unit)
        {
            missileConfigCount = configCount;
            pointer = configPointer;
        }
        public override void LoadPropertyGroups()
        {
            base.LoadPropertyGroups();

            missileConfigCount = GetMax(PropertyType.MissileConfig);
            if (missileConfigCount == 0)
                missileConfigCount = UnitSpec.MissileConfigCount;

            missileGroup = new PropertyGroup(RomData.Get32(pointer), missileConfigCount, GameRom.NodeType.MissileConfig, PropertyType.MissileConfig);
            unit.PropertyGroups[PropertyType.MissileConfig] = missileGroup;
            SetMax(PropertyType.MissileConfig, (int)missileConfigCount);

            if (GetMax(PropertyType.Acceleration) == 0)
            {
                GetMaxAccel();
            }

            CallLoadGroup(PropertyType.Acceleration, GameRom.NodeType.Acceleration);

            SetMax(PropertyType.MissileConfig, missileConfigCount);

            missileGroup.AddObserver(OnMissileGroupAddressChanged);
        }

        private void OnMissileGroupAddressChanged(RecordableMoveParams p)
        {
            RomData.Set32(pointer, p.ToAddress);
        }

        private void GetMaxAccel()
        {
            int maxAccel = 0;

            for (int i = 0; i < UnitSpec.MissileConfigCount; i++)
            {
                uint currIndex = missileGroup.GetNode(i).GetValue("accel1");
                uint currIndex2 = missileGroup.GetNode(i).GetValue("accel2");

                if (currIndex > maxAccel)
                {
                    maxAccel = (int)currIndex;
                }

                if (currIndex2 > maxAccel)
                {
                    maxAccel = (int)currIndex2;
                }

            }

            maxAccel += 1;

            SetMax(PropertyType.Acceleration, maxAccel);
        }
    }
}
