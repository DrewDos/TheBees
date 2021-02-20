using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TheBees.UnitData.Node;
using TheBees.Description;
using TheBees.GameData;

namespace TheBees.UnitData
{
    static class OrbitalBasisHandler
    {
        static private Dictionary<int, Dictionary<uint, OrbitalBasisRef>> GetDescriptionsFromAllUnits(UnitCharacter [] unitSet)
        {

            Dictionary<int, Dictionary<uint, OrbitalBasisRef>> allRefs = new Dictionary<int, Dictionary<uint, OrbitalBasisRef>>();

            foreach (UnitCharacter unit in unitSet)
            {
                allRefs[unit.Index] = GetDescriptionsFromUnit(unit);
            }

            return allRefs;

        }

        static private Dictionary<uint, OrbitalBasisRef> GetDescriptionsFromUnit(UnitCharacter unit)
        {
            CommandSet set = unit.GetCommandSet();
            int count = UnitSpec.ActiveSpecialAccelDefCount/4;
            int start = 0x14;
            string unitName = DescSpec.UnitNamesFromRomIndex[unit.Index];

            Dictionary<uint, OrbitalBasisRef> obOffsets = new Dictionary<uint, OrbitalBasisRef>();
            for (int i = 0; i < count; i++)
            {
                // command start aligned to bank = 0x14
                CommandHeader header = (CommandHeader)unit.GetCommandSet().GetUnitCommand(start+i).GetHeader();
                int[] indexes = new int[] { header.OrbitalBasisL, header.OrbitalBasisM, header.OrbitalBasisH, header.OrbitalBasisEX };

                for(int j = 0; j < 4; j++)
                {
                    if (indexes[j] >= 0x10)
                    {
                        int actionIndex = (int)unit.GetCommandSet().GetNode(GameRom.TrickAccelType.Specials, i, j).GetValue("trick");
                        uint obAddress = ((UnitPropertyLoader)unit.PropertyLoader).OBGroup.GetSuppleValue(indexes[j] - 0x10).Value;

                        if (!obOffsets.ContainsKey(obAddress))
                        {
                            obOffsets[obAddress] = new OrbitalBasisRef(
                                indexes[j],
                                obAddress,
                                unitName + ":\r\n  " + unit.GetActionGroup(ActionType.Mortals).GetAction(actionIndex).Tag);
                        }
                        else
                        {
                            obOffsets[obAddress].Description += ":\r\n  " + unit.GetActionGroup(ActionType.Mortals).GetAction(actionIndex).Tag;
                        }
                    }
                }
            }

            return obOffsets;
        }

        static public void LoadDescriptors()
        {
             Dictionary<int, Dictionary<uint, OrbitalBasisRef>> separatedDescriptors = GetDescriptionsFromAllUnits(UnitHandler.GetCharacterUnits());
             Dictionary<uint, OrbitalBasisRef> combinedDescriptors = new Dictionary<uint,OrbitalBasisRef>(); 
             if (separatedDescriptors != null)
            {
                StaticDescriptor.ClearDescriptorByTag("OrbitalBasis");

                // combine all descriptors
                foreach (KeyValuePair<int, Dictionary<uint, OrbitalBasisRef>> obBase in separatedDescriptors)
                {
                    foreach (KeyValuePair<uint, OrbitalBasisRef> obRef in obBase.Value)
                    {
                        if (!combinedDescriptors.ContainsKey(obRef.Key))
                        {
                            combinedDescriptors[obRef.Key] = obRef.Value;
                        }
                        else
                        {
                            combinedDescriptors[obRef.Key].Description += "\r\n" + obRef.Value.Description;
                        }
                    }
                }


                // set all descriptors
                foreach (KeyValuePair<uint, OrbitalBasisRef> obRef in combinedDescriptors)
                {
                    StaticDescriptor.SetDescriptor(obRef.Key, "OrbitalBasis", obRef.Value.Description);
                }
                
            }
            else
            {
                throw new Exception("Descriptions have not been set");
            }
            
        }
    }


}
