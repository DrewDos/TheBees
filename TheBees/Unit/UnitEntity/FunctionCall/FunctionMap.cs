using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheBees.UnitData
{
    static class FunctionMap
    {
        static public Dictionary<int, FunctionType> FunctionTypeMap = new Dictionary<int, FunctionType>()
        {
            { 0x00, FunctionType.Unknown },
            { 0x0D, FunctionType.None },
            { 0x03, FunctionType.FullReference }, 
            { 0x04, FunctionType.FullReference }, 
            { 0x05, FunctionType.FullReference }, 
            { 0x10, FunctionType.FullReference }, 
            { 0x12, FunctionType.FullReference }, 
            { 0x14, FunctionType.FullReference }, 
            { 0x16, FunctionType.FullReference }, 
            { 0x18, FunctionType.FullReference }, 
            { 0x1A, FunctionType.FullReference }, 
            { 0x1C, FunctionType.FullReference }, 
            { 0x1E, FunctionType.FullReference }, 
            { 0x20, FunctionType.FullReference }, 
            //{ 0x23, FunctionType.FullReference }, 
            //{ 0x24, FunctionType.FullReference }, 
            { 0x37, FunctionType.FullReference }, 
            { 0x39, FunctionType.FullReference }, 
            { 0x55, FunctionType.FullReference }, 
            { 0x56, FunctionType.FullReference }, 
            //{ 0x77, FunctionType.FullReference },
            { 0x0C, FunctionType.Basic },
            { 0x2B, FunctionType.Basic },
            { 0x2D, FunctionType.Basic },
            { 0x2E, FunctionType.Basic },
            { 0x2F, FunctionType.Basic },
            { 0x31, FunctionType.Basic },
            { 0x32, FunctionType.Basic },
            { 0x34, FunctionType.Basic },
            { 0x35, FunctionType.Basic },
            { 0x42, FunctionType.Basic },

            

        };

        static public string[] GetFunctionNames()
        {
            string [] output = new string[0xFF];
            string desc = "";
            for (int i = 0; i < 0xFF; i++)
            {
                if (FunctionNames.ContainsKey(i))
                    desc = FunctionNames[i];
                else
                    desc = "???";

                output[i] = "0x" + i.ToString("X2") + ": " + desc;
                
            }

            return output;
        }

        static public Dictionary<int, string> FunctionNames = new Dictionary<int, string>()
        {
            { 0x00, "Filler" },
            { 0x05, "Set Landing Behavior" },
            { 0x0C, "Begin Repeat" },
            { 0x0D, "End Repeat" },
            { 0x1E, "Jump On Hit" },
            { 0x2B, "Display Spark"},
            { 0x69, "Throw Client Behavior Action"},
            { 0x2D, "Acceleration On Hit"},
            { 0x2E, "Jump On Random"}, 
            { 0x2F, "Jump On Attack With Option"},
            { 0x31, "Skip On Attack Whiff"},
            { 0x32, "Landing (Unconfirmed)"},
            { 0x34, "Apply Shake Effect"},
            { 0x35, "Execute If Held"},
            { 0x42, "Apply Tweak Motion"},
            { 0x46, "Apply Acceleration"},


        };
        static public int[] GameReferenceMap = new int[] 
        { 
            0, // Basic Operation
            1, // Reactions 1
            3, // Throws
            4, // Reactions 3
            5, // Attacks
            6, // Specials
            2, // Reactions 2
            7, // Landing Behavior
            8, // Subroutines
            9  // Victory Pose
        };

        static public FunctionType GetFunctionType(int functionCode)
        {
            if (FunctionTypeMap.ContainsKey(functionCode))
                return FunctionTypeMap[functionCode];

            return FunctionType.Unknown;
        }

        static public string[] GetSettings(int functionCode)
        {
            if (BasicSettings.ContainsKey(functionCode))
                return BasicSettings[functionCode];
            else
                return null;
        }

        static private Dictionary<int, string[]> BasicSettings = new Dictionary<int, string[]>()
        {
            
            { 0x0C,
                new string[]
                {
                    null,
                    "Repeat Amount",
                    null
                }
            },

            { 0x0D, null },
            
            { 0x2B,
                new string[]
                {
                    "Group Index",
                    "Spark Index",
                    "???"
                }
            },
            { 0x2D,
                new string[]
                {
                    "Acceleration Index",
                    null,
                    null
                }
            },
            
            { 0x2E,
                new string[]
                {
                    "Random Value",
                    "On True",
                    "On False"
                }
            },

            { 0x2F,
                new string[]
                {
                    "On Hit",
                    "On Guard",
                    "On Parry"
                }
            },
            { 0x31,
                new string[]
                {
                    null,
                    null,
                    "Skip Amount"
                }
            },

            { 0x32,
                new string[]
                {
                    null,
                    null,
                    "???"
                }
            },
            
            { 0x34,
                new string[]
                {
                    "Shake Value",
                    null,
                    null
                }
            },

            { 0x35,
                new string[]
                {
                    "Button Flags",
                    "On True",
                    "On False"
                }
            },
            
            { 0x42,
                new string[]
                {
                    "Tweak Motion Index",
                    null,
                    null
                }
            },

            { 0x46,
                new string[]
                {
                    "Acceleration Index",
                    null,
                    null
                }
            },


            
        };
    }
}
