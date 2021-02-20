using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TheBees.GameRom;
using TheBees.Data;

namespace TheBees.UnitData
{
    public class CommandSet
    { 
        private int unit;
        static private uint[] inputSpecOffsets;
        static private uint[] commandDefOffsets;
        static private bool inputSpecOffsetsSet = false;
   
        private const int numInputSpecs = 5;

        private Dictionary<TrickAccelType, NodeGroup> commandGroups = new Dictionary<TrickAccelType, NodeGroup>();
        private Dictionary<TrickAccelType, DataNode> inputSpecs = new Dictionary<TrickAccelType, DataNode>();

        private MappedRecordableList commandMap;
        public MappedRecordableList CommandMap { get { return commandMap; } }

        public const uint UnitCommandAddress = 0x6120710;
        public const uint CharCommandAddress = 0x661381C;
        public const uint UnitButtonPressOffset = 0x18;
        private const int NumBanksNormals = 18;

        public CommandSet(int unitSource)
        {
            unit = unitSource;
            commandMap = new MappedRecordableList(UpdateCommandAddresses);
            Initialize();
            InitData();
        }

        static public void Clear()
        {
            inputSpecOffsets = null;
            commandDefOffsets = null;
            inputSpecOffsetsSet = false;
        }

        private void Initialize()
        {
            if (inputSpecOffsetsSet == false)
            {
                inputSpecOffsets = new uint[]
                {
                    // crouching normals
                    0x065F7690,
                    // standing normals
                    0x065F66D0,
                    // jump neutral
                    0x065F8650,
                    // jump forward
                    0x065F9610,
                    // jump back
                    0x065FA5D0
                };

                commandDefOffsets = new uint[]
                {
                    // crouching normals
                    0x065F78D0,
                    // standing normals
                    0x065F6910,
                    // jump neutral
                    0x065F8890,
                    // jump forward
                    0x065F9850,
                    // jump back
                    0x065FA810,
                    // specials
                    0x0661381C,
                };
                inputSpecOffsetsSet = true;
            }
        }

        private void GetInputSpecs()
        {
            for (int i = 0; i < numInputSpecs; i++)
            {
                inputSpecs[(TrickAccelType)i] = new DataNode(inputSpecOffsets[i] + ((((uint)unit << 1) + (uint)unit) << 3), NodeType.InputSpec); 
            }
        }
        protected void InitData()
        {
            // get the first group
            LoadTrickAccel(TrickAccelType.CrouchingNormals);
            LoadTrickAccel(TrickAccelType.StandingNormals);
            LoadTrickAccel(TrickAccelType.JumpNeutral);
            LoadTrickAccel(TrickAccelType.JumpForward);
            LoadTrickAccel(TrickAccelType.JumpBack);
            LoadTrickAccel(TrickAccelType.Specials);

            LoadUnitCommands();
            
            // load all input specs
            GetInputSpecs();

        }
        
        private uint GetCharCommandAddress()
        {
            return CharCommandAddress + (UnitSpec.CommandListOffsetSize * 4 * (uint)unit);
        }

        private void LoadUnitCommands()
        {
            int count = (int)UnitSpec.CommandListOffsetSize;

            List<uint> commandAddresses = RomData.GetAddressList(GetCharCommandAddress(), count);

            for (int i = 0; i < count; i++)
            {
                commandMap.AddMap(UnitCommand.GetRecordable(commandAddresses[i]));
            }
        }
        static public bool IsNormal(TrickAccelType type)
        {
            switch (type)
            {
                case TrickAccelType.StandingNormals:
                case TrickAccelType.CrouchingNormals:
                case TrickAccelType.JumpNeutral:
                case TrickAccelType.JumpForward:
                case TrickAccelType.JumpBack:
                    return true;
                case TrickAccelType.Specials:
                    return false;
            }

            throw new ArgumentException("Bad TrickAccelType");
        }
        private void LoadTrickAccel(TrickAccelType type)
        {
            NodeGroup newGroup = new NodeGroup();

            if (IsNormal(type))
            {


                for (int i = 0; i < NumBanksNormals; i++)
                {
                    newGroup.AddNodeByType(GetTrickAccelAddress(type, i), NodeType.TrickDef);
                }

            }
            else if (type == TrickAccelType.Specials)
            {
                uint offset = (((uint)unit << 3) + (uint)unit) << 6;
                int specSize = NodeSpec.SpecSizes[NodeType.TrickDef];
                for (int i = 0; i < UnitSpec.ActiveSpecialAccelDefCount; i++)
                {
                    newGroup.AddNodeByType(UnitSpec.SpecialCommandDefAddress + offset + (uint)(i * specSize), NodeType.TrickDef);
                }
            }
            else
            {
                throw new ArgumentException("Invalid TrickAccelType Specified");
            }

            commandGroups[type] = newGroup;
        }



        private uint GetTrickAccelAddress(TrickAccelType type, int index)
        {
            int specSize = NodeSpec.SpecSizes[NodeType.TrickDef];
            uint offset = ((((uint)unit << 3) + (uint)unit) << 4);
            //offset += unit << 3;
            offset += (uint)(specSize * index);
            offset += (uint)commandDefOffsets[(int)type];

            return offset;

        }

        public bool TypeAvailable(TrickAccelType type)
        {
            if (commandGroups.ContainsKey(type))
                return true;

            return false;
        }

        public static int GetNodeIndex(TrickAccelType type, int index, int commandOffset)
        {
            if (IsNormal(type))
            {
               return index * 3 + commandOffset;
            }
            else if (type == TrickAccelType.Specials)
            {
                return index * 4 + commandOffset;
            }

            throw new ArgumentException("Invalid TrickAccelType specified");

        }
        public DataNode GetInputSpec(TrickAccelType type)
        {
            return inputSpecs[type];
        }

        public DataNode GetDef(TrickAccelType type, CharacterButton button)
        {
            if (!commandGroups.ContainsKey(type))
            {
                return null;
            }

            return commandGroups[type].GetNode((int)button);
        }

        public NodeGroup GetNodeGroup(TrickAccelType type)
        {
            return commandGroups[type];
        }

        public DataNode GetNode(TrickAccelType type, int index, int commandOffset = 0)
        {
            if (IsNormal(type))
            {
                return commandGroups[type].GetNode(index * 3 + commandOffset );
            }
            else if (type == TrickAccelType.Specials)
            {
                return commandGroups[TrickAccelType.Specials].GetNode(index * 4 + commandOffset);
            }

            throw new ArgumentException("Invalid TrickAccelType specified");
        }

        public int GetCommandCount()
        {
            return (int)UnitSpec.CommandListOffsetSize;
        }


        ////////////////////////////////////////
        // unit command
        ////////////////////////////////////////

        public UnitCommand GetUnitCommand(int index)
        {
            return (UnitCommand)CommandMap.GetMap(index);
        }

        public void UpdateCommandAddresses()
        {
            int count = (int)UnitSpec.CommandListOffsetSize;
            uint[] addresses = commandMap.GetAddressList();
            for (int i = 0; i < count; i++)
            {
                RomData.Set32(GetCharCommandAddress() + (uint)(i * 4), addresses[i]);
            }

        }
    }
}
