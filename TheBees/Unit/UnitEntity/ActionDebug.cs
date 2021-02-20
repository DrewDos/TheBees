using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace TheBees.UnitData
{
    static public class ActionDebug
    {
        static public Dictionary<int, List<ActionReference>> FunctionReferences;

        static public event Action<int> NextActionEvent;
        static public event Action<int> GetActionCountEvent;
        static public event Action CompleteEvent;

         private const string FileName = @"functionswithreferences.dat";
         private const string ReferenceArrayLoc = @"c:\sf3\refrence.txt";

        static private List<int> functionsWithReferences;

        static public void GetAllFunctionReferences()
        {
            int actionCount = UnitAction.AllActions.Count;
            FunctionReferences = new Dictionary<int,List<ActionReference>>();

            if(GetActionCountEvent!=null)
                GetActionCountEvent(actionCount);
            
            for(int i = 0; i < actionCount; i++)
            {
                if(NextActionEvent!=null)
                    NextActionEvent(i);

                UnitAction action = UnitAction.AllActions[i];
                for(int nodeCtr = 0; nodeCtr < action.Count; nodeCtr++)
                {
                    if(action.DataNodes[nodeCtr] is FunctionCall)
                    {
                        FunctionCall call = (FunctionCall)action.DataNodes[nodeCtr];
                        if(!FunctionReferences.ContainsKey(call.FunctionCode))
                            FunctionReferences[call.FunctionCode] = new List<ActionReference>();

                        ActionReference baseReference = action.GetReference(0);

                        FunctionReferences[call.FunctionCode].Add(
                            new ActionReference(baseReference.UnitNum, baseReference.GroupNum, baseReference.ActionNum, nodeCtr)
                            );
                    }
                }
            }

            if (CompleteEvent != null)
                CompleteEvent();
        }

        static private void SetIsReference(int functionCode)
        {
            if (!functionsWithReferences.Contains(functionCode))
            {
                functionsWithReferences.Add(functionCode);
                SaveWithReferences();
            }
        }

        static private void ClearIsReference(int functionCode)
        {
            int index = functionsWithReferences.IndexOf(functionsWithReferences.Find((x) => x == functionCode));

            if (index != -1)
            {
                functionsWithReferences.RemoveAt(index);
                SaveWithReferences();
            }
        }

        static public bool ToggleIsReference(int functionCode)
        {
            if (functionsWithReferences.Contains(functionCode))
            {
                ClearIsReference(functionCode);
                return false;
            }
            else
            {
                SetIsReference(functionCode);
                return true;
            }
        }

        static public bool HasIsReference(int functionCode)
        {
            return functionsWithReferences.Contains(functionCode);
        }

        static public void SaveWithReferences()
        {
            BinaryWriter w = new BinaryWriter(File.Open(FileName, FileMode.Create));

            w.Write((uint)functionsWithReferences.Count);

            foreach (int code in functionsWithReferences)
            {
                w.Write(code);
            }

            w.Close();
        }

        static public void LoadWithReferences()
        {

            // for debugging purposes
            functionsWithReferences = new List<int>();

            try
            {
                BinaryReader r = new BinaryReader(File.Open(FileName, FileMode.Open));


                uint count = r.ReadUInt32();

                for (int i = 0; i < count; i++)
                {
                    functionsWithReferences.Add(r.ReadInt32());
                }

                r.Close();
            }
            catch
            {
            }
        }

        static public void WriteReferenceArray()
        {
            string output = "";
            string nl = Environment.NewLine;

            foreach(int index in functionsWithReferences)
            {
                output += "    { 0x" + index.ToString("X2") + ", FunctionType.FullReference }, " + nl;
            }

            File.WriteAllText(ReferenceArrayLoc, output);
        }
    }
}
