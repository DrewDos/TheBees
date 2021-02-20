using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheBees.UnitData.Node
{
    class SupportGraphicSpec : GameRom.DataNode
    {
        public SupportGraphicSpec(uint address)
            : base(address, GameRom.NodeType.SupportGfxSpec)
        {
        }

        public int LayerValue
        {
            get { return (int)GetValue("frontOrBack"); }
            set { SetValue("frontOrBack", (uint)value); }
        }
        public int SpriteIndex
        {
            get { return (int)GetValue("spriteIndex"); }
            set { SetValue("spriteIndex", (uint)value); }
        }
        public int PalletIndex
        {
            get { return (int)GetValue("pallet"); }
            set { SetValue("pallet", (uint)value); }
        }
        public short XPos
        {
            get { return (short)GetValue("xPos"); }
            set { SetValue("xPos", (uint)value); }
        }

        public short YPos
        {
            get { return (short)GetValue("yPos"); }
            set { SetValue("yPos", (uint)value); }
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
    }
}
