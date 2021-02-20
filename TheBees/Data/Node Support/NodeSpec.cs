using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheBees.GameRom
{
    public enum NodeType
    {
        None,
        ActionHeader,
        ActionFooter,
        Motion8,
        Motion16,
        Motion24,
        FunctionCall8,
        FunctionCall16,
        FunctionCall24,
        Collision4,
        Collision16,
        AllCollision,
        TweakMotion,
        Acceleration,
        AttackDetails,
        MissileConfig,
        TrickDef,
        TrickDefAlt,
        InputSpec,
        CommandHeader,
        CommandLever,
        CommandFooter,
        PalletSpec,
        SupportGfxSpec,
        SupportGfxSpecExt,
        ThrownOpponentSpec,
        SASettings,
        RawSampleHeader,
        RawSampleDataRef,
        EnemyCtrl,
        SAEffect,

        Test,

    }

    public enum RawNodeType
    {
        FunctionCall,
        MortalJump,
        Motion,
        None
    }


    public enum TrickAccelType
    {
        CrouchingNormals,
        StandingNormals,
        JumpNeutral,
        JumpForward,
        JumpBack,
        Specials,
    };



    public enum CharacterButton
    {
        LP, MP, HP, LK, MK, HK
    }

    public enum CharacterDirectional
    {
        U, D, L, R
    }

    public struct NodeValue
    {
        public string Name;
        public int Size;

        public NodeValue(string newName, int newSize)
        {
            Name = newName;
            Size = newSize;
        }
    }

    static class NodeSpec
    {
        private const int BYTE = 1;
        private const int WORD = 2;
        private const int DWORD = 4;

        static private Dictionary<NodeType, NodeValue [] > nodeSpecList = new Dictionary<NodeType, NodeValue[]>()
        {
            
            { NodeType.CommandHeader, 
                new NodeValue []{
                    new NodeValue("undef1", WORD),
                    new NodeValue("undef2", DWORD),
                    new NodeValue("orbitalBasis1", DWORD),
                    new NodeValue("orbitalBasis2", DWORD),
                    new NodeValue("usableCndts", BYTE),
                    new NodeValue("undef3", BYTE),
                    new NodeValue("btnCfg1", WORD),
                    new NodeValue("btnCfg2", WORD),
                    new NodeValue("btnCfg3", WORD),
                    new NodeValue("btnCfg4", WORD),
                }
            },
            
            { NodeType.CommandLever, 
                new NodeValue []{
                    new NodeValue("undef1", WORD),
                    new NodeValue("undef2", WORD),
                    new NodeValue("undef3", WORD),
                    new NodeValue("trans1", WORD),
                }
            },

            { NodeType.CommandFooter, 
                new NodeValue []{
                    new NodeValue("undef1", WORD),
                }
            },
            

            { NodeType.ActionHeader,  
                new NodeValue []{
                    new NodeValue("lengthOfData", WORD),
                    new NodeValue("judgmentRelated", BYTE),
                    new NodeValue("techRelated", BYTE),
                    new NodeValue("undef1", WORD),
                    new NodeValue("undef2", WORD),
                }
            },
            
            { NodeType.ActionFooter, 
                new NodeValue []{
                    new NodeValue("undef1", DWORD),
                    new NodeValue("undef2", DWORD),
                }
            },
            { NodeType.Motion8, 
                new NodeValue [] {
                    new NodeValue("frame", BYTE),
                    new NodeValue("jumpFlagEtc", BYTE),
                    new NodeValue("sound", WORD),
                    new NodeValue("gfx1", WORD),
                    new NodeValue("gfx2", WORD),
                }
            },

            { NodeType.Motion16, 
                new NodeValue [] {
                    new NodeValue("frame", BYTE),
                    new NodeValue("jumpFlagEtc", BYTE),
                    new NodeValue("sound", WORD),
                    new NodeValue("gfx1", WORD),
                    new NodeValue("gfx2", WORD),
                    new NodeValue("physDecTTCCmd", DWORD),
                    new NodeValue("lineJumpOnHitGuard", BYTE),
                    new NodeValue("cancel", BYTE),
                    new NodeValue("unknownRef", BYTE),
                    new NodeValue("tweakMotion", BYTE),
                }
            },
            
            { NodeType.Motion24, 
                new NodeValue [] {
                    new NodeValue("frame", BYTE),
                    new NodeValue("jumpFlagEtc", BYTE),
                    new NodeValue("sound", WORD),
                    new NodeValue("gfx1", WORD),
                    new NodeValue("gfx2", WORD),
                    new NodeValue("physDecTTCCmd", DWORD),
                    new NodeValue("lineJumpOnHitGuard", BYTE),
                    new NodeValue("cancel", BYTE),//
                    new NodeValue("gfx3", WORD),
                    new NodeValue("zoom", WORD),
                    new NodeValue("opSpecOpponent", WORD),
                    new NodeValue("tweakMotion", WORD),
                    new NodeValue("lineJump", BYTE),
                    new NodeValue("undef1", BYTE),
                }
            },            
            
            { NodeType.FunctionCall8, 
                new NodeValue [] {
                    new NodeValue("callNum", WORD),
                    new NodeValue("value1", WORD),
                    new NodeValue("value2", WORD),
                    new NodeValue("value3", WORD),
                }
            },
            { NodeType.FunctionCall16, 
                new NodeValue [] {
                    new NodeValue("callNum", WORD),
                    new NodeValue("value1", WORD),
                    new NodeValue("value2", WORD),
                    new NodeValue("value3", WORD),
                    new NodeValue("value4", WORD),
                    new NodeValue("value5", WORD),
                    new NodeValue("value6", WORD),
                    new NodeValue("value7", WORD),
                }
            },
            { NodeType.FunctionCall24, 
                new NodeValue [] {
                    new NodeValue("callNum", WORD),
                    new NodeValue("value1", WORD),
                    new NodeValue("value2", WORD),
                    new NodeValue("value3", WORD),
                    new NodeValue("value4", WORD),
                    new NodeValue("value5", WORD),
                    new NodeValue("value6", WORD),
                    new NodeValue("value7", WORD),
                    new NodeValue("value8", WORD),
                    new NodeValue("value9", WORD),
                    new NodeValue("valueA", WORD),
                    new NodeValue("valueB", WORD),
                }
            },
           
            { NodeType.AllCollision, 
                new NodeValue [] {
                    new NodeValue("decision1", WORD),
                    new NodeValue("undef1", WORD),
                    new NodeValue("decision2", WORD),
                    new NodeValue("undef2", WORD),
                    new NodeValue("throwJgmt", WORD),
                    new NodeValue("jgmtThrown", WORD),
                    new NodeValue("atkRoll", WORD),
                    new NodeValue("decision3", WORD),
                }
            },

            { NodeType.Collision16, 
                new NodeValue [] {
                    new NodeValue("x1_start", WORD),
                    new NodeValue("x1_width", WORD),
                    new NodeValue("y1_start", WORD),
                    new NodeValue("y1_width", WORD),
                    new NodeValue("x2_start", WORD),
                    new NodeValue("x2_width", WORD),
                    new NodeValue("y2_start", WORD),
                    new NodeValue("y2_width", WORD),
                    new NodeValue("x3_start", WORD),
                    new NodeValue("x3_width", WORD),
                    new NodeValue("y3_start", WORD),
                    new NodeValue("y3_width", WORD),
                    new NodeValue("x4_start", WORD),
                    new NodeValue("x4_width", WORD),
                    new NodeValue("y4_start", WORD),
                    new NodeValue("y4_width", WORD),
                }
            },

            { NodeType.Collision4, 
                new NodeValue [] {
                    new NodeValue("x1_start", WORD),
                    new NodeValue("x1_width", WORD),
                    new NodeValue("y1_start", WORD),
                    new NodeValue("y1_width", WORD),
                }
            },

            { NodeType.AttackDetails, 
                new NodeValue [] {
                    new NodeValue("effectHits1", BYTE),
                    new NodeValue("effectHits2", BYTE),
                    new NodeValue("guardDispPosEffect", BYTE),
                    new NodeValue("andCtrlEnemy", BYTE),
                    new NodeValue("translate1", BYTE),
                    new NodeValue("jgmtOnLowerGuard", BYTE),
                    new NodeValue("bendBackReductVal", BYTE),
                    new NodeValue("undef1", BYTE),
                    new NodeValue("damage", BYTE),
                    new NodeValue("boolHitBack", BYTE),
                    new NodeValue("gaugeStun", BYTE),
                    new NodeValue("undef2", BYTE),
                    new NodeValue("flags1", BYTE),
                    new NodeValue("flags2", BYTE),
                    new NodeValue("hitEffectsSndGfx", BYTE),
                    new NodeValue("undef3", BYTE),
                }
             },

            { NodeType.MissileConfig,
                new NodeValue [] {
                    new NodeValue("blowOffset", WORD),
                    new NodeValue("undef1", BYTE),
                    new NodeValue("undef2", BYTE),
                    new NodeValue("undef3", BYTE),
                    new NodeValue("undef4", BYTE),
                    new NodeValue("reaction", BYTE),
                    new NodeValue("undef5", BYTE),
                    new NodeValue("usuallySetTo1", BYTE),
                    new NodeValue("usuallySetTo2", BYTE),
                    new NodeValue("numberWhenHit", BYTE),
                    new NodeValue("numberGuard", BYTE),
                    new NodeValue("numberOffset", BYTE),
                    new NodeValue("pallet", BYTE),
                    new NodeValue("undef6", BYTE),
                    new NodeValue("accel1", BYTE),
                    new NodeValue("accel2", BYTE),
                    new NodeValue("transparency", BYTE),
                    new NodeValue("numberOfHits", BYTE),
                    new NodeValue("undef7", BYTE),
                    new NodeValue("generationTime", WORD),
                    new NodeValue("xAxis", WORD),
                    new NodeValue("yAxis", WORD),
                    new NodeValue("undef8", WORD),
                }
             },
             
            { NodeType.Acceleration, 
                new NodeValue [] {
                    new NodeValue("xMuzzleVel", WORD),
                    new NodeValue("xAccel", WORD),
                    new NodeValue("undef1", WORD),
                    new NodeValue("yMuzzleVel", WORD),
                    new NodeValue("yAccel", WORD),
                    new NodeValue("undef2", WORD),
                }
             },

            { NodeType.TrickDef, 
                new NodeValue [] {
                    new NodeValue("accel1", WORD),
                    new NodeValue("trick", WORD),
                    new NodeValue("accel2", WORD),
                    new NodeValue("unused?", WORD)
                }
             },

            { NodeType.TrickDefAlt, 
                new NodeValue [] {
                    new NodeValue("TI Number", WORD),
                    new NodeValue("Trick Number", WORD),
                    new NodeValue("Accel #", WORD),
                    new NodeValue("unused?", WORD)
                }
             },

            { NodeType.InputSpec, 
                new NodeValue [] {
                    new NodeValue("L P3", WORD),
                    new NodeValue("L P2", WORD),
                    new NodeValue("M P3", WORD),
                    new NodeValue("M P2", WORD),
                    new NodeValue("H P3", WORD),
                    new NodeValue("H P2", WORD),
                    new NodeValue("L K3", WORD),
                    new NodeValue("L K2", WORD),
                    new NodeValue("M K3", WORD),
                    new NodeValue("M K2", WORD),
                    new NodeValue("H K3", WORD),
                    new NodeValue("H K2", WORD)
                }
             },

             { NodeType.PalletSpec,
                 new NodeValue [] {
                    new NodeValue("offset", DWORD),
                    new NodeValue("destination", DWORD),
                    new NodeValue("size", DWORD),
                 }
             },
            { NodeType.SupportGfxSpecExt,
                 new NodeValue [] {
                     new NodeValue("gfxIndex1", WORD),
                     new NodeValue("gfxIndex2", WORD),
                     new NodeValue("gfxIndex3", WORD),
                     new NodeValue("gfxIndex4", WORD),
                 }
             },
            { NodeType.SupportGfxSpec,
                 new NodeValue [] {
                     new NodeValue("xPos", WORD),
                     new NodeValue("yPos", WORD),
                     new NodeValue("undef4", BYTE),
                     new NodeValue("pallet", BYTE),
                     new NodeValue("frontOrBack", BYTE), // 2 = front, 1 = back
                     new NodeValue("flipFlags", BYTE),
                     new NodeValue("duration", BYTE),
                     new NodeValue("undef7", BYTE),
                     new NodeValue("undef8", BYTE),
                     new NodeValue("undef9", BYTE),
                     new NodeValue("undefA", BYTE),
                     new NodeValue("jumpTo", BYTE), // skip = 0
                     new NodeValue("spriteIndex", WORD),
                 }
             },
             
            { NodeType.TweakMotion,
                 new NodeValue [] {
                     new NodeValue("value1", BYTE),
                     new NodeValue("value2", BYTE),
                     new NodeValue("value3", BYTE),
                     new NodeValue("value4", BYTE),
                 }
             },
            { NodeType.ThrownOpponentSpec,
                 new NodeValue [] {
                     new NodeValue("xPos", WORD),
                     new NodeValue("yPos", WORD),
                     new NodeValue("layerValue", BYTE),
                     new NodeValue("flipFlags", BYTE),
                     new NodeValue("dataIndex", WORD),
                 }
             },

             

            { NodeType.EnemyCtrl, 
                new NodeValue [] {
                    new NodeValue("(Size1) xMuzzleVel", WORD),
                    new NodeValue("(Size1) xAccel", WORD),
                    new NodeValue("(Size1) undef1", WORD),
                    new NodeValue("(Size1) yMuzzleVel", WORD),
                    new NodeValue("(Size1) yAccel", WORD),
                    new NodeValue("(Size1) undef2", WORD),

                    new NodeValue("(Size2) xMuzzleVel", WORD),
                    new NodeValue("(Size2) xAccel", WORD),
                    new NodeValue("(Size2) undef1", WORD),
                    new NodeValue("(Size2) yMuzzleVel", WORD),
                    new NodeValue("(Size2) yAccel", WORD),
                    new NodeValue("(Size2) undef2", WORD),

                    new NodeValue("(Size3) xMuzzleVel", WORD),
                    new NodeValue("(Size3) xAccel", WORD),
                    new NodeValue("(Size3) undef1", WORD),
                    new NodeValue("(Size3) yMuzzleVel", WORD),
                    new NodeValue("(Size3) yAccel", WORD),
                    new NodeValue("(Size3) undef2", WORD),

                    new NodeValue("(Size4) xMuzzleVel", WORD),
                    new NodeValue("(Size4) xAccel", WORD),
                    new NodeValue("(Size4) undef1", WORD),
                    new NodeValue("(Size4) yMuzzleVel", WORD),
                    new NodeValue("(Size4) yAccel", WORD),
                    new NodeValue("(Size4) undef2", WORD),
                }
             },
             
            
            { NodeType.SASettings, 
                new NodeValue [] {
                    new NodeValue("saNumber", BYTE),
                    new NodeValue("maxSA1", BYTE),
                    new NodeValue("maxSA2", BYTE),
                    new NodeValue("airSA", BYTE),
                    new NodeValue("undef1", WORD),
                    new NodeValue("flags", WORD),
                    new NodeValue("undef2", BYTE),
                    new NodeValue("volume", BYTE),
                    new NodeValue("undef3", BYTE),
                    new NodeValue("numberOfGauge", BYTE),
                    new NodeValue("decreaseSpeed", DWORD)
                }
             },
             
            
            { NodeType.SAEffect, 
                new NodeValue [] {
                    new NodeValue("xAxis", BYTE),
                    new NodeValue("yAxis", BYTE),
                    new NodeValue("numberEffectData", BYTE),
                    new NodeValue("maxSA", BYTE),
                    new NodeValue("undef1", WORD)
                }
             },

            
            { NodeType.Test, 
                new NodeValue [] {
                    new NodeValue("test", BYTE),
                }
             },

            /*   SampleHeader,
             *   RawSampleHeader,
             *   RawSampleDataRef,
             */
            
            { NodeType.RawSampleHeader, 
                new NodeValue [] {
                    new NodeValue("undef0", BYTE),
                    new NodeValue("undef1", BYTE),
                    new NodeValue("undef2", BYTE),
                    new NodeValue("undef3", BYTE),
                    new NodeValue("undef4", WORD),
                    new NodeValue("undef6", BYTE),
                    new NodeValue("undef7", BYTE),
                    new NodeValue("undef8", BYTE),
                    new NodeValue("undef9", BYTE),
                    new NodeValue("undefA", BYTE),
                    new NodeValue("undefB", BYTE),
                    new NodeValue("undefC", BYTE),
                    new NodeValue("undefD", BYTE),
                    new NodeValue("undefE", BYTE),
                    new NodeValue("undefF", BYTE),
                    new NodeValue("undef10", BYTE),
                    new NodeValue("undef11", BYTE),
                    new NodeValue("undef12", BYTE),
                    new NodeValue("undef13", BYTE),
                    new NodeValue("undef14", BYTE),
                    new NodeValue("undef15", BYTE),
                    new NodeValue("undef16", BYTE),
                    new NodeValue("undef17", BYTE),
                }
             },
            { NodeType.RawSampleDataRef, 
                new NodeValue [] {
                    new NodeValue("start", DWORD),
                    new NodeValue("end", DWORD),
                    new NodeValue("endSecond", DWORD),
                    new NodeValue("undef3", DWORD),
                }
             },
            
            /*
            { TokenID.GAUGEINCREASE, 
                new NodeValue [] (){
                    new NodeValue("onWhiff", WORD),
                    new NodeValue("onGuard", WORD),
                    new NodeValue("onHit", WORD),
                    new NodeValue("unused?", WORD)
                }
             },
            { TokenID.STUNGAUGE, 
                new List<NodeValue>(){
                    new NodeValue("BYTE", BYTE)
                }
             },
            { TokenID.CMDLIST, 
                new List<NodeValue>(){
                    new NodeValue("CMDLIST", DWORD)
                }
             }
            */
        };

        static private Dictionary<NodeType, int> specSizes = GetSpecSizes();
        static private Dictionary<NodeType, Dictionary<string, int>> keyedIndexes = GetKeyedIndexes();
        static private Dictionary<NodeType, List<uint>> specOffsets = GetSpecOffsets();
        static private Dictionary<NodeType, int[]> valueSizes = GetValueSizes();

        static public Dictionary<NodeType, Dictionary<string, int>> KeyedIndexes { get { return keyedIndexes; }}
        static public Dictionary<NodeType, int> SpecSizes { get { return specSizes; } }
        static public Dictionary<NodeType, List<uint>> SpecOffsets { get { return specOffsets; } }
        static public Dictionary<NodeType, int[]> ValueSizes { get { return valueSizes; } }
        static public Dictionary<NodeType, NodeValue[]> NodeSpecList { get { return nodeSpecList; } }

        static private Dictionary<NodeType, int> GetSpecSizes()
        {
            Dictionary<NodeType, int> newSpecSizes = new Dictionary<NodeType, int>();

            foreach (NodeType token in nodeSpecList.Keys)
            {
                int currSize = 0;

                foreach (NodeValue spec in nodeSpecList[token])
                {
                    currSize += spec.Size;
                }

                newSpecSizes[token] = currSize;
            }

            return newSpecSizes;
        }

        static private Dictionary<NodeType, Dictionary<string, int>> GetKeyedIndexes()
        {

            Dictionary<NodeType, Dictionary<string, int>> newKeyedIndexes = new Dictionary<NodeType, Dictionary<string, int>>();

            foreach (NodeType token in nodeSpecList.Keys)
            {
                int i = 0;
                newKeyedIndexes[token] = new Dictionary<string, int>();
                foreach (NodeValue spec in nodeSpecList[token])
                {
                    newKeyedIndexes[token][spec.Name] = i;
                    i++;
                }
            }

            return newKeyedIndexes;

        }

        
        static private Dictionary<NodeType, List<uint>> GetSpecOffsets()
        {
            Dictionary<NodeType, List<uint>> newSpecOffsets = new Dictionary<NodeType,List<uint>>();

            foreach(KeyValuePair<NodeType, NodeValue []> entry in nodeSpecList)
            {
                uint currOffset = 0;

                newSpecOffsets[entry.Key] = new List<uint>();
                for (int i = 0; i < entry.Value.Length; i++)
                {
                    newSpecOffsets[entry.Key].Add(currOffset);
                    currOffset += (uint)entry.Value[i].Size;
                }
            }

            return newSpecOffsets;
        }


        static private Dictionary<NodeType, int[]> GetValueSizes()
        {
            Dictionary<NodeType, int[]> newValueSizes = new Dictionary<NodeType, int[]>();

            foreach (KeyValuePair<NodeType, NodeValue[]> entry in nodeSpecList)
            {
                List<int> indexes = new List<int>();

                foreach (NodeValue value in entry.Value)
                {
                    indexes.Add((int)value.Size);
                }

                newValueSizes[entry.Key] = indexes.ToArray();
            }
            return newValueSizes;
        }

        static public uint GetValueOffset(NodeType type, string key)
        {
            return specOffsets[type][keyedIndexes[type][key]];
        }

        static public int GetValueSize(NodeType type, string key)
        {
            return valueSizes[type][keyedIndexes[type][key]];
        }

        public static string[] GetKeys(NodeType type)
        {
            int count = nodeSpecList[type].Length;
            string[] output = new string[count];

            for (int i = 0; i < count; i++)
            {
                output[i] = nodeSpecList[type][i].Name;
            }

            return output;
        }

        public static string[] GetCollisionKeysFromIndex(int index)
        {
            string[] keys = new string[4];

            keys[0] = string.Format("x{0}_start", index + 1);
            keys[1] = string.Format("x{0}_width", index + 1);
            keys[2] = string.Format("y{0}_start", index + 1);
            keys[3] = string.Format("y{0}_width", index + 1);

            return keys;

        }

        public static string[] GetAllCollisionKeys()
        {
            string[] keys = new string[4 * 4];

            for (int i = 0; i < keys.Length; i += 4)
            {
                keys[i + 0] = string.Format("x{0}_start", i / 4 + 1);
                keys[i + 1] = string.Format("x{0}_width", i / 4 + 1);
                keys[i + 2] = string.Format("y{0}_start", i / 4 + 1);
                keys[i + 3] = string.Format("y{0}_width", i / 4 + 1);
            }

            return keys;
        }
    }
}
