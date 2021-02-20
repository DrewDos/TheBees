using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TheBees.GameRom;
namespace TheBees.UnitData
{
    public class SuperArtSettings : DataNode
    {
        public SuperArtSettings(uint address)
            : base(address, NodeType.SASettings)
        {
        }

        public SuperArtFlag Flag
        {
            get
            {
                return (SuperArtFlag)GetValue("flags");
                
            }
            set
            {
                SetValue("flags", (uint)value);
            }
        }
    }

    public enum SuperArtFlag
    {
        Normal = 0x00,
        DecreaseGauge = 0x01,
        ActivateOnDeath = 0x03
    }
}
