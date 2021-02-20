using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TheBees.User;
using TheBees.Records;

namespace TheBees.UnitData
{
    static public class UserCommandMap
    {
        static public string[] GetCommandNames()
        {
            List<string> output = new List<string>();
            UnitCommand.AllCommands.ForEach((x) => {

                string tag = RecordTagGuide.GetRecordTag(x.Address);
                if (tag == "")
                    tag = x.Address.ToString("X8");

                output.Add(tag);
            
            });
            return output.ToArray();
        }

        static public int GetCommandIndex(uint address)
        {
            return UnitCommand.AllCommands.IndexOf(((UnitCommand)Recordable.MasterList[address]));
        }

        static public UnitCommand GetCommand(uint address)
        {
            if (!Recordable.MasterList.ContainsKey(address))
                throw new Exception("Bad user command address");

            return (UnitCommand)Recordable.MasterList[address];
        }

        static public UnitCommand GetCommand(int index)
        {
            return UnitCommand.AllCommands[index];
        }
    }
}
