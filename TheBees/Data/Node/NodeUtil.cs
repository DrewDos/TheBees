using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheBees.GameRom
{
    static class NodeUtil
    {
        public static NodeType GetNodeTypeFromRaw(RawNodeType type, int sourceDataLength)
        {
            switch (type)
            {
                case RawNodeType.Motion:
                    return (NodeType)NodeType.Motion8 + (sourceDataLength / 8 - 1);
                case RawNodeType.FunctionCall:
                    return (NodeType)NodeType.FunctionCall8 + (sourceDataLength / 8 - 1);
                default:
                    throw new ArgumentException("Length of data in action invalid");

            }
        }

        public static int GetByteCountFromNode(NodeType type)
        {
            switch (type)
            {
                case NodeType.Motion8:
                case NodeType.FunctionCall8:
                    return 8;
                case NodeType.Motion16:
                case NodeType.FunctionCall16:
                    return 16;
                case NodeType.Motion24:
                case NodeType.FunctionCall24:
                    return 24;
                default:
                    throw new ArgumentException("Invalid node type");
            }
        }

        public static RawNodeType GetRawFromNodeType(NodeType type)
        {
            switch (type)
            {
                case NodeType.Motion8:
                case NodeType.Motion16:
                case NodeType.Motion24:
                    return RawNodeType.Motion;
                case NodeType.FunctionCall8:
                case NodeType.FunctionCall16:
                case NodeType.FunctionCall24:
                    return RawNodeType.FunctionCall;
            }

            return RawNodeType.None;
        }

        public static DataNode GetProperNode(NodeType type, uint address)
        {
            switch (type)
            {
                case NodeType.ThrownOpponentSpec:
                    return new UnitData.Node.ThrownOpponent(address);
                case NodeType.SupportGfxSpec:
                    return new UnitData.Node.SupportGraphicSpec(address);
                case NodeType.SupportGfxSpecExt:
                    return new UnitData.Node.SupportGraphicSpecExt(address);
                case NodeType.SASettings:
                    return new UnitData.SuperArtSettings(address);
                default:
                    return new DataNode(address, type);
            }
        }
    }
}
