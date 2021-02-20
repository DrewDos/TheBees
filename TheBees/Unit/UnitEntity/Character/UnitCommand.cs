using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TheBees.GameRom;
using TheBees.UnitData.Node;

namespace TheBees.UnitData
{
    public class UnitCommand : NodeSequence
    {
        private int leverCount = 0;

        static private bool maintainData = true;
        public override bool MaintainData { get { return maintainData; } }
        static public List<UnitCommand> AllCommands;

        private UnitCommand(uint newAddress)
            : base(newAddress)
        {
            InitData();
        }

        ////////////////////////////////////////
        // general methods
        ////////////////////////////////////////

        public override DataNode AddNodeByType(NodeType type)
        {
            if (type == NodeType.CommandHeader)
            {
                CommandHeader newNode = new CommandHeader(currentAddress);
                dataNodes.Add(newNode);
                int currSize = NodeSpec.SpecSizes[type];
                size += currSize;
                currentAddress += (uint)currSize;
                return newNode;
            }
            else
            {
                return base.AddNodeByType(type);
            }

        }
        private void InitData()
        {
            // load the header -- no special checks needed
            //AddNode(NodeType.CommandHeader);
            AddNodeByType(NodeType.CommandHeader);

            // keep adding lever nodes until we get to the footer
            ushort check = RomData.Get16(currentAddress);

            while (check != 0x1C)
            {
                AddNodeByType(NodeType.CommandLever);
                leverCount += 1;

                check = RomData.Get16(currentAddress);
            }

            // load the footer
            AddNodeByType(NodeType.CommandFooter);
        }

        public DataNode GetHeader()
        {
            return dataNodes[0];
        }

        public DataNode GetLever(int index)
        {
            return dataNodes[index + 1];
        }

        public int GetLeverCount()
        {
            return dataNodes.Count - 2;
        }

        public DataNode GetFooter()
        {
            return dataNodes[dataNodes.Count - 1];
        }

        ////////////////////////////////////////
        // recordable methods
        ////////////////////////////////////////

        static public UnitCommand GetRecordable(uint address)
        {
            if (!MasterList.ContainsKey(address))
            {
                MasterList[address] = new UnitCommand(address);
                // no record for commands yet
                if (creatingBaseRecords) MasterList[address].InitializeRecord();
                if (AllCommands == null)
                    AllCommands = new List<UnitCommand>();
                AllCommands.Add(((UnitCommand)MasterList[address]));
            }

            return (UnitCommand)MasterList[address];
        }

        ////////////////////////////////////////
        // properties
        ////////////////////////////////////////

        public int LeverCount { get { return leverCount; } }
    }
}
