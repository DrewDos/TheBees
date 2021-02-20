using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TheBees.GameRom;
using TheBees.Description;

namespace TheBees.UnitData
{
    static class UnitDescription
    {
        static public string[] GetActionGroupNames(ActionGroup group)
        {
            List<string> output = new List<string>();
            int count = group.RecordableList.MapCount;

            for (int i = 0; i < count; i++)
            {
                output.Add(group.RecordableList.GetMap(i).Tag);
            }

            return output.ToArray();
        }

        static public string[] GetMissileNames(Unit unit)
        {
            ActionGroup group = unit.GetActionGroup(ActionType.NormalOperation);
            if(group != null)
            {
                DescriptionBody.GetIndexedList(unit.Index, (int)ActionType.NormalOperation, group.Count, "X4");
            }
            
            return null;

        }

        static public string[] GetActionGroupIndexes(Unit unit, ActionType type)
        {
            ActionGroup group = unit.GetActionGroup(type);
            if (group != null)
            {
                return DescriptionBody.GetIndexedList(unit.Index, (int)type, group.Count, "X4");
            }

            return null;
        }

        static public string[] GetPropertyGroupIndexes(Unit unit, PropertyType type)
        {
            PropertyGroup group = unit.GetPropertyGroup(type);

            if (group != null)
            {
                return DescriptionBody.GetIndexedList(unit.Index, (int)type, group.Count, "X4");
            }
            return null;
        }
    }
}
