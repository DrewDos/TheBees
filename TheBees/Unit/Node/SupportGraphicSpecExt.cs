using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TheBees.GameRom;

namespace TheBees.UnitData.Node
{
    class SupportGraphicSpecExt : DataNode
    {
        public SupportGraphicSpecExt(uint address)
            : base(address, GameRom.NodeType.SupportGfxSpecExt)
        {
        }

        public override DataNode GetCopy(bool ensureBuffer)
        {
            DataNode copy = new SupportGraphicSpec(address);
            if (ensureBuffer)
            {
                copy.MakeEmptyBuffer();
                copy.SetBuffer(this);
            }

            return copy;
        }


        public int Graphic1
        {
            get { return (int)GetValue("gfxIndex1"); }
            set { SetValue("gfxIndex1", (uint)value); }
        }

        public int Graphic2
        {
            get { return (int)GetValue("gfxIndex2"); }
            set { SetValue("gfxIndex2", (uint)value); }
        }

        public int Graphic3
        {
            get { return (int)GetValue("gfxIndex3"); }
            set { SetValue("gfxIndex3", (uint)value); }
        }

        public int Graphic4
        {
            get { return (int)GetValue("gfxIndex4"); }
            set { SetValue("gfxIndex4", (uint)value); }
        }
    }
}
