using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheBees.UnitData.Node
{
    class ThrownOpponent : GameRom.DataNode
    {
        public ThrownOpponent(uint address)
            : base(address, GameRom.NodeType.ThrownOpponentSpec)
        {
        }

        public int LayerValue
        {
            get
            {
                return (int)GetValue("layerValue");
            }
            set
            {
                SetValue("layerValue", (uint)value);
            }
        }
        public bool FlipX
        {
            get
            {
                return (GetValue("flipFlags") & 0x01) > 0;
            }
            set
            {
                SetValue("flipFlags", (GetValue("flipFlags") & 0xFFFE) | (uint)(value ? 0x01 : 0x00));
            }
        }

        public bool FlipY
        {
            get
            {
                return (GetValue("flipFlags") & 0x02) > 0;
            }
            set
            {
                SetValue("flipFlags", (GetValue("flipFlags") & 0xFFFD) | (uint)(value ? 0x02 : 0x00));
            }
        }

        public short xOffset
        {
            get
            {
                return (short)(GetValue("xPos"));
            }
            set
            {
                SetValue("xPos", (uint)value & 0x0000FFFF);
            }
        }

        public short yOffset
        {
            get
            {
                return (short)(GetValue("yPos"));
            }
            set
            {
                SetValue("yPos", (uint)value & 0x0000FFFF);
            }
        }

        public int DataIndex
        {
            get
            {
                return (int)(GetValue("dataIndex"));
            }
            set
            {
                SetValue("dataIndex", (uint)value);
            }
        }
    }
}
