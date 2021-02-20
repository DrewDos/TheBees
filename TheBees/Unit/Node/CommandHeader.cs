using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TheBees.GameRom;

namespace TheBees.UnitData.Node
{
    class CommandHeader : DataNode
    {
        public CommandHeader(uint addr)
            : base(addr, NodeType.CommandHeader)
        {
        }

        public int OrbitalBasisL
        {
            get { return (ushort)(GetValue("orbitalBasis1") & 0x0000FFFF); }
            set { SetValue("orbitalBasis1", (GetValue("orbitalBasis1") & 0xFFFF0000) | (uint)value); }
        }
        public int OrbitalBasisM
        {
            get { return (ushort)((GetValue("orbitalBasis1") & 0xFFFF0000) >> 16); }
            set { SetValue("orbitalBasis1", (GetValue("orbitalBasis1") & 0x0000FFFF) | (uint)(value << 16)); }
        }
        public int OrbitalBasisH
        {
            get { return (ushort)(GetValue("orbitalBasis2") & 0x0000FFFF); }
            set { SetValue("orbitalBasis2", (GetValue("orbitalBasis2") & 0xFFFF0000) | (uint)value); }
        }
        public int OrbitalBasisEX
        {
            get { return (ushort)((GetValue("orbitalBasis2") & 0xFFFF0000) >> 16); }
            set { SetValue("orbitalBasis2", (GetValue("orbitalBasis2") & 0x0000FFFF) | (uint)(value << 16)); }
        }
    }
}
