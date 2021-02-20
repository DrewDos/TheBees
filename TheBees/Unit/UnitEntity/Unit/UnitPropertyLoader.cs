using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheBees.UnitData
{
    class UnitPropertyLoader : PropertyLoader
    {
        private CommandSet commandSet;
        private GameRom.PalletIndexSet[] palletIndexSets;
        private OrbitalBasisGroup obGroup;

        public CommandSet UnitCommandSet { get { return commandSet; } }
        public GameRom.PalletIndexSet[] PalletIndexSets { get { return palletIndexSets; }}
        public OrbitalBasisGroup OBGroup { get { return obGroup; } }
        
        public UnitPropertyLoader(Unit unit)
            :base(unit)
        {
            
        }

        public override void LoadPropertyGroups()
        {
            base.LoadPropertyGroups();

            // load commands
            commandSet = new CommandSet(unit.Index);

            // load accelerations
            if (GetMax(PropertyType.Acceleration) == 0)
            {
                GetMaxAccel();
            }

            CallLoadGroup(PropertyType.Acceleration, GameRom.NodeType.Acceleration);

            // add sa effect
            uint saEffectAddress = UnitSpec.SAEffectOffset + ((uint)index * UnitSpec.SAEffectIndexSize);
            SetMax(PropertyType.SAEffect, 3);
            //CallLoadGroup(PropertyType.SAEffect, GameRom.NodeType.SASettings);
            unit.PropertyGroups.Add(PropertyType.SAEffect, new PropertyGroup(saEffectAddress, 3, GameRom.NodeType.SASettings, PropertyType.SAEffect));

            // load pallets
            int numPallets = (int)(UnitSpec.UnitPalletIndexSize / UnitSpec.PalletIndexSize);
            unit.PropertyGroups.Add(PropertyType.Pallet, new PropertyGroup(UnitSpec.UnitPalletAddressOffset + (UnitSpec.UnitPalletIndexSize * (uint)index), numPallets, GameRom.NodeType.PalletSpec, PropertyType.Pallet));

            //load pallet index sets
            palletIndexSets = new GameRom.PalletIndexSet[7];
            for(int setCounter = 0; setCounter < 7; setCounter++)
            {
                List<GameRom.DataNode> nodes = new List<GameRom.DataNode>();
                int groupOffset;
                for (int i = 0; i < 0x0E*2; i++)
                {
                    groupOffset = i/0x0E;
                    nodes.Add(unit.PropertyGroups[PropertyType.Pallet].GetNode(0x0E * setCounter + groupOffset*0x62 + i-groupOffset*0x0E));

                }

                palletIndexSets[setCounter] = new GameRom.PalletIndexSet(nodes.ToArray());
            }


            // load orbital spec addresses
            obGroup = new OrbitalBasisGroup(UnitSpec.OrbitalBasisOffsets[unit.Index], UnitSpec.OrbitalBasisAddressCount);

            // load enemy ctrls
            unit.PropertyGroups.Add(PropertyType.EnemyCtrl, new PropertyGroup(RomData.Get32(UnitSpec.EnemyCtrlPointerOffset + (uint)(unit.Index * 4)), GetMax(PropertyType.EnemyCtrl), GameRom.NodeType.EnemyCtrl, PropertyType.EnemyCtrl));

        }
        private void GetMaxEnemyCtrl()
        {
            
        }


        private void GetMaxAccel()
        {
            int count = Enum.GetValues(typeof(GameRom.TrickAccelType)).Cast<int>().Max() + 1;
            int maxAccel = 0;

            for (int i = 0; i < count; i++)
            {
                if (commandSet.TypeAvailable((GameRom.TrickAccelType)i))
                {
                    GameRom.NodeGroup group = commandSet.GetNodeGroup((GameRom.TrickAccelType)i);

                    for (int j = 0; j < group.Count; j++)
                    {
                        uint accel1 = group.GetNode(j).GetValue("accel1");
                        uint accel2 = group.GetNode(j).GetValue("accel2");

                        if (accel1 > maxAccel)
                        {
                            maxAccel = (int)accel1;
                        }

                        if (accel2 > maxAccel)
                        {
                            maxAccel = (int)accel2;
                        }
                    }
                }
            }

            maxAccel += 1;

            SetMax(PropertyType.Acceleration, maxAccel);
        }
    }
}
