using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TheBees.GameRom;

namespace TheBees.UnitData
{

    public class Motion : ActionNode
    {
        public override RawNodeType RawType
        {
            get { return RawNodeType.Motion; }
        }

        public override string Description
        {
            get
            {
                return "Frame Definition";
            }
        }

        public Motion(uint offset, NodeType nodeType)
            : base(offset, nodeType)
        {

        }

        public override DataNode GetCopy(bool ensureBuffer)
        {
            Motion newMotion = new Motion(address, type);
            if (ensureBuffer)
            {
                newMotion.MakeEmptyBuffer();
                newMotion.SetBuffer(this);
            }
            return newMotion;
        }

        public int SpriteIndex
        {
            get { return (int)GetValue("gfx2"); }
            set { SetValue("gfx2", (uint)value); }
        }

        public bool FlipX
        {
            get{ return (GetValue("sound") & 0x01) > 0; } 
            set{SetValue("sound", (GetValue("sound") & (uint)0xFFFE) | (uint)(value ? 0x01:0));}
        }

        public int Sound
        {
            get { return (int)(GetValue("sound") >> 4); }
            set { SetValue("sound", (GetValue("sound") & 0x000F) | (uint)(value << 4)); }
        }

        public bool FlipY
        {
            get { return (GetValue("sound") & 0x02) > 0; }
            set { SetValue("sound", (GetValue("sound") & (uint)0xFFFD) | (uint)(value ? 0x02 : 0)); }
        }

        public bool CancelSuperJump
        {
            get { return (GetValue("cancel") & 0x01) > 0; }
            set
            {
                uint newValue = GetValue("cancel");
                SetValue("cancel", value == true ? newValue | 0x01 : newValue & (0x01 ^ 0xFFFFFFFF) );
                
            }
        }

        public bool CancelDash
        {
            get { return (GetValue("cancel") & 0x02) > 0; }
            set
            {
                uint newValue = GetValue("cancel");
                SetValue("cancel", value == true ? newValue | 0x02 : newValue & (0x02 ^ 0xFFFFFFFF) );

            }
        }
        public bool CancelTC
        {
            get { return (GetValue("cancel") & 0x08) > 0; }
            set
            {
                uint newValue = GetValue("cancel");
                SetValue("cancel", value == true ? newValue | 0x08 : newValue & (0x08 ^ 0xFFFFFFFF));

            }
        }
        public bool CancelSpecial
        {
            get { return (GetValue("cancel") & 0x20) > 0; }
            set
            {
                uint newValue = GetValue("cancel");
                SetValue("cancel", value == true ? newValue | 0x20 : newValue & (0x20 ^ 0xFFFFFFFF));

            }
        }
        public bool CancelSuper
        {
            get { return (GetValue("cancel") & 0x40) > 0; }
            set
            {
                uint newValue = GetValue("cancel");
                SetValue("cancel", value == true ? newValue | 0x40 : newValue & (0x40 ^ 0xFFFFFFFF));

            }
        }

        public uint AttackIndex
        {

            get
            {
                int current = (int)GetValue("physDecTTCCmd");

                if ((0x80000000 & (uint)current) == 0x80000000)
                {
                    current = current >> 16;
                    current = current >> 6;
                    current = current * -1;
                    return (uint)current;
                }

                return 0;
                
            }
            set
            {
                uint valueSet = 0;
                valueSet = value;
                SetValue("physDecTTCCmd", (GetValue("physDecTTCCmd") & ~(uint)0xFFC00000) | ((0x1000 - 4 * valueSet) << 20)); 
            }
            
        }

        public uint AllCollisionIndex
        {
            get
            {
                return ((GetValue("physDecTTCCmd") << 3) >> 16) & 0x000001FF;
            }
            set {

                SetValue("physDecTTCCmd", GetValue("physDecTTCCmd") & ~(uint)0x003FF000  | (value << 13)); 
            }
        }

        public uint CancelSpec
        {
            get { return GetValue("physDecTTCCmd") & 0x00000FFF; }
            set { SetValue("physDecTTCCmd", GetValue("physDecTTCCmd") & ~(uint)0x00000FFF | value); }
        }

        public int SupportGfxIndex
        {
            get { return (int)GetValue("gfx1") >> 4; }
            set { SetValue("gfx1", ((uint)value << 4)); }
        }

        public uint TweakMotion
        {
            get { return (GetValue("tweakMotion")&0xFF); }
            set { uint tweakValue = GetValue("tweakMotion"); SetValue("tweakMotion", (value | (tweakValue & 0xFF00))); }
        }

        public uint ThrownOpponentIndex
        {
            get { return GetValue("opSpecOpponent") / 0x18; }
            set { SetValue("opSpecOpponent", value * 0x18); }
        }
    }
}
