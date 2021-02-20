using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using TheBees.GameRom;
using System.Drawing;

namespace TheBees.UnitData
{
    class UnitCharacter : Unit
    {
        private CommandSet commandSet;
        private UnitPalletSet palletSet;
        public UnitPalletSet PalletSet { get { return palletSet; } }

        public UnitCharacter(uint address, int index)
            : base(address, index)
        {
            propertyLoader = new UnitPropertyLoader(this);
            propertyLoader.CallLoadGroup = OnCallLoadPropertyGroup;

            LoadUnit();

            commandSet = ((UnitPropertyLoader)propertyLoader).UnitCommandSet;
            palletSet = new UnitPalletSet(((UnitPropertyLoader)propertyLoader).PalletIndexSets);
        }

        public CommandSet GetCommandSet()
        {
            return commandSet;
        }
        
    }
}
