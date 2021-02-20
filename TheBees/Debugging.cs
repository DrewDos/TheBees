using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using TheBees.UnitData;
using TheBees.GameRom;
using TheBees.Records;
using TheBees.Sprites;
using TheBees.User;

namespace TheBees
{
    static public class Debugging
    {
        static private int mainCtr = 0;
        static public bool Stop = false;

        static private int unitCtr = 0;
        static private int propertyCounter = 0;

        static private PropertyType[] types = new PropertyType[] { PropertyType.AttackDetails, PropertyType.AllCollision, PropertyType.Collision1, PropertyType.Acceleration };
        static private List<ActionReference> RefsToCheckDst = new List<ActionReference>();
        static private List<ActionReference> RefsToCheckSrc = new List<ActionReference>();
        static private List<uint> ActionAddresses = new List<uint>();
        static public List<Recordable> AllActions = GetAllActions();
        static private int refCtr = 0;
        static private int zeroCtr = 0;


        static private List<Recordable> finalDstActions = new List<Recordable>();
        static private List<Recordable> finalSrcActions = new List<Recordable>();

        static private List<ActionReference> WithZeroFooters = new List<ActionReference>();

        static private HashSet<UnitAction> targetActions = new HashSet<UnitAction>();
        static private int targetActionIndex = -1;
        static public ActionReference DoubleFunctionNext()
        {
            targetActionIndex+=1;

            if(targetActionIndex > targetActions.Count)
                targetActionIndex = 0;

            return targetActions.ToList()[targetActionIndex].GetReference(0);
        }
        static public void GetDoubleFunctions()
        {
            List<UnitAction> allActions = UnitAction.AllActions;
            HashSet<UnitAction> tempActions = new HashSet<UnitAction>();

            targetActions.Clear();

            foreach (UnitAction action in allActions)
            {
            //    foreach (DataNode node in action.DataNodes)
            //    {
            //        if (node is Motion)
            //        {
            //            if (((Motion)node).SizeInBytes == 0x18)
            //            {
            //                uint gfx3Value = node.GetValue("gfx3");

            //                if (gfx3Value < 0x200 && gfx3Value > 0x2FF || gfx3Value != 0)
            //                {
            //                    if (!targetActions.Contains(action))
            //                        targetActions.Add(action);
            //                }
            //            }
            //        }
            //    }
                int checkAmt = action.Header.DataLengthInBytes / 8;

                int counter = 0;

                for (int i = 0; i < action.Count; i++)
                {
                    if (action.DataNodes[i] is FunctionCall)
                    {
                        counter += 1;
                        if (counter == checkAmt)
                            counter = 0;
                    }
                    else
                    {
                        if (counter < checkAmt && counter > 0)
                        {
                            if (!tempActions.Contains(action))
                                tempActions.Add(action);

                        }
                    }
                }

                if (counter < checkAmt && counter > 0)
                {
                    if (!tempActions.Contains(action))
                        tempActions.Add(action);

                }
            }

            targetActions = tempActions;
            //foreach (UnitAction action in tempActions)
            //{
            //    DataNode lastNode = action.DataNodes.Last();
            //    if (lastNode is FunctionCall)
            //    {
            //        if (((FunctionCall)lastNode).FunctionCode != 0x06 && ((FunctionCall)lastNode).FunctionCode != 0x45)
            //        {

            //            if (!targetActions.Contains(action))
            //                targetActions.Add(action);
            //        }
            //    }
            //}
        }

        static public void PokeActions()
        {
            List<UnitAction> groups = new List<UnitAction>();

            foreach(Recordable recordable in Recordable.MasterList.Values)
            {
                if (recordable is UnitAction)
                {
                    groups.Add((UnitAction)recordable);
                }
            }

            int ctr = 0;

            foreach (UnitAction group in groups)
            {
                group.RecordEntity.SetAddress(group.Address);
                ctr += 1;
            }
        }

        static private List<Recordable> GetAllActions()
        {
            if(AllActions != null)
                return AllActions;

            List<Recordable> newList = new List<Recordable>();
            foreach (KeyValuePair<uint, Recordable> pair in Recordable.MasterList)
            {
                if (pair.Value.RecordEntity != null && (pair.Value is UnitAction || pair.Value is PropertyGroup || pair.Value is ActionGroup))
                {
                    ActionAddresses.Add(pair.Key);
                    newList.Add((Recordable)pair.Value);
                }
            }

            return newList;
        }
        static public void GetZeroFooters()
        {
            GetAllActions();
            WithZeroFooters = new List<ActionReference>();
            foreach (Recordable action in AllActions)
            {
                if (action is UnitAction && ((UnitAction)action).ZeroFooter)
                    WithZeroFooters.Add(((UnitAction)action).GetReference(0));
            }
        }

        static public ActionReference GetNextZeroFooter()
        {
            //return null;
            ActionReference output = WithZeroFooters[zeroCtr];
            zeroCtr++;
            if (zeroCtr == WithZeroFooters.Count)
                zeroCtr = 0;

            return output;
        }
        static public void CheckNestedActions()
        {
            GetAllActions();
            List<int[]> childPair = new List<int[]>();
            Recordable srcAction;
            Recordable dstAction;

            for (int i = 0; i < AllActions.Count; i++)
            {
                srcAction = AllActions[i];
                Record srcRecord = AllActions[i].RecordEntity;
                uint srcAddress = ActionAddresses[i];

                for (int j = 0; j < AllActions.Count; j++)
                {
                    dstAction = AllActions[j];
                    if (srcAction == dstAction) continue;

                    Record dstRecord = AllActions[j].RecordEntity;
                    uint dstAddress = ActionAddresses[j];
                    if (srcRecord.Start >= dstRecord.Start && srcRecord.Start < dstRecord.End)
                    {
                        if (!finalSrcActions.Contains(srcAction))
                            finalSrcActions.Add(srcAction);
                        if(!finalDstActions.Contains(dstAction))
                            finalDstActions.Add(dstAction);
                    }
                }
            }

            //string output = "";
            //string nl = Environment.NewLine;

            //output += "static private uint [] ProblemActions = new uint[]" + nl;
            //output += "{";
            //foreach (UnitAction action in finalDstActions)
            //{
            //    output += "    0x" + action.Address.ToString("X8") + "," + nl;
            //    RefsToCheckDst.Add(action.GetReference(0));
            //}
            //output += "};";

            //File.WriteAllText(@"C:\sf3\actionproblems.txt", output);
            
        }

        static public void IncreaseRefCtr()
        {
            refCtr += 1;
            if (finalDstActions.Count == refCtr)
                refCtr = 0;

        }
        static public ActionReference GetSrcRef()
        {

            ActionReference toReturn = ((UnitAction)finalSrcActions[refCtr]).GetReference(0);
            return toReturn;
        }
        static public ActionReference GetDstRef()
        {

            ActionReference toReturn = ((UnitAction)finalDstActions[refCtr]).GetReference(0);


            return toReturn;
        }

        static public void GetLookupValues()
        {
            //string output = "";
            //string nl = Environment.NewLine;

            //output += "return new LookupTag[]" + nl;
            //output += "{" + nl;
            
            //foreach (SpriteRegion region in SpriteGuide.SpriteRegions)
            //{
            //    NormalSpriteDef def = SpriteMap.SpriteDataMasterList[RomData.Get32(0x6800004 + (uint)(region.StartIndex + 5) * 8)];
            //    output += "    new LookupTag(0x" + def.RealLookupAddress.ToString("X8") + ", \"" + region.Tag + "\")," + nl;

            //    uint mainLookup = def.RealLookupAddress;

            //    for (int i = region.StartIndex; i <= region.LastIndex; i++)
            //    {
            //        uint address = RomData.Get32(0x6800004 + (uint)(i) * 8);

            //        if (address != 0)
            //        {
            //            if (SpriteMap.SpriteDataMasterList[address].RealLookupAddress != mainLookup)
            //                throw new Exception("Damn...");
            //        }
            //    }
            //}

             
            //output += "};" + nl;

            //File.WriteAllText(@"c:\sf3\lookupNames.txt", output);

        }

        static public void GetRanges()
        {
            string output = "";
            string nl = Environment.NewLine;

            output += "return new SpriteRegion[]" + nl;
            output += "{" + nl;
            uint start = 0;
            uint end = 0x5FF;
            for (int i = 0; i < UnitSpec.CharacterUnitCount; i++)
            {
                if (Description.DescSpec.UnitNamesFromRomIndex[i] == "Shin Akuma")
                    continue;

                output += "    new SpriteRegion(0x" +  start.ToString("X8") + ", 0x" + end.ToString("X8") + ", \"" + Description.DescSpec.UnitNamesFromRomIndex[i] + "\")," + nl;
                start += 0x600;
                end += 0x600;

            }
            output += "};" + nl;

            File.WriteAllText(@"c:\sf3\regionNames.txt", output);

        }

        static public void SaveActionCounts()
        {
            string output = "";
            string nl = Environment.NewLine;

            output += "return new ActionLength[]" + nl;
            output += "{" + nl;

            foreach (KeyValuePair<uint, int> actionLength in ActionGuide.ActionLengths)
            {
                output += "    new ActionLengthRef(0x" + actionLength.Key.ToString("X8") + ", 0x" + actionLength.Value.ToString("X4") + ")," + nl;
                
            }

            output += "};" + nl;

            File.WriteAllText(@"c:\sf3\regionNames.txt", output);
        }

        static public void SomeStuff()
        {
            // check record start set

            
            //List<RecordSpace> spaceList = RecordHandler.UserSpace.SpaceList;
            //for (int i = 0; i < spaceList.Count; i++)
            //{
            //    foreach (Record record in spaceList[i].Records)
            //    {
            //        record.SetAddress(record.Start + 2);
            //        break;
            //    }
            //    break;
            //}

            //SpriteMap.ApplyAllDefs();
            

            // check record overlap

            //List<Record> masterRecordList = new List<Record>();

            //List<RecordSpace> spaceList = RecordHandler.UserSpace.SpaceList;
            //for (int i = 0; i < spaceList.Count; i++)
            //{
            //    foreach (Record record in spaceList[i].Records)
            //    {
            //        masterRecordList.Add(record);
            //    }
            //}

            //while (masterRecordList.Count > 1)
            //{
            //    Record target = masterRecordList[0];

            //    for (int i = 1; i < masterRecordList.Count; i++)
            //    {
            //        Record src = masterRecordList[i];

            //        if (target.End > src.Start && target.Start < src.Start)
            //        {
            //            throw new Exception("Overlapping exists");
            //        }
            //    }

            //    masterRecordList.RemoveAt(0);
            //}
        }
        static public void SpriteStuff()
        {
        //    TileDef.MasterList.Values.ToList().ForEach((x) => x.BufferBlock());
        //    NormalSpriteDef.MasterList.Values.ToList().ForEach((x) => x.BufferBlock());

        //    List<RecordSpace> spaceList = RecordHandler.UserSpace.SpaceList;
        //    for(int i = 0; i < spaceList.Count; i++)
        //    {
        //        spaceList[i].Scramble();    
        //    }
            
        //    RecordHandler.ProgramSpace.SpaceList[1].Scramble();


        //    TileDef.MasterList.Values.ToList().ForEach((x) => { x.ApplyBuffer(); x.ClearBuffer(); });
        //    NormalSpriteDef.MasterList.Values.ToList().ForEach((x) => { x.ApplyBuffer(); x.ClearBuffer(); });

        //    SpriteMap.ApplyAllDefs();

            //File.WriteAllText(@"c:\recordsummary.txt", GetRecordSummary());

        }

        static public string GetRecordSummary()
        {
            //RecordSpaceGroup group = RecordHandler.UserSpace;
            //string res = "";
            //string tab = "";
            //string newLine = "\r\n";

            //if (group == null)
            //    return "No record data available";

            //res += mainCtr.ToString("X8") + newLine;
            //res += "DataSpace: " + newLine;

            //int ctr = 0;
            //foreach (RecordSpace space in group.SpaceList)
            //{
            //    if (ctr == 1)
            //        break;
            //    tab = "    ";
            //    res += tab + "RecordSpace:" + newLine;

            //    tab += tab;
            //    res += tab + "Start: " + space.Start.ToString("X8") + newLine;
            //    res += tab + "End: " + space.End.ToString("X8") + newLine;
            //    res += tab + "Size: " + (space.End - space.Start).ToString("X8") + newLine;
            //    res += tab + "FreeSpace: " + space.FreeSpace.ToString("X8") + newLine;
            //    res += tab + "Records: " + newLine;
            //    res += tab + "Keys: " + newLine;
            //    space.KeyedRecords.ToList().ForEach((kvp) => res += "    " + kvp.Key.ToString("X8") + newLine);

            //    tab += tab;

            //    foreach (Record record in space.Records)
            //    {
            //        res += tab + "Index: " + record.Index.ToString() + newLine;
            //        res += tab + "    " + "Start: " + record.Start.ToString("X8") + newLine;
            //        res += tab + "    " + "End: " + record.End.ToString("X8") + newLine;
            //        res += tab + "    " + "Size: " + record.Size.ToString("X8") + newLine;
            //    }

            //    ctr += 1;
            //}

    
            //return res;
            return "";
        }

        static public void YepAnotherOne()
        {
            for (int i = 0; i < 10000; i++)
                Debugging.DoAnotherThing();
        }
        static public void DoSomething()
        {
            for (int i = 0; i < 20; i++)
            {
                UnitCharacter unit = (UnitCharacter)UnitHandler.UnitSet[i];

                PropertyGroup group = unit.GetPropertyGroup(PropertyType.AttackDetails);

                for (int j = 0; j < group.Count; j++)
                {
                    DataNode node = group.GetNode(j);

                    if (node.Buffered)
                        node.ClearBuffer();
                    int count = NodeSpec.KeyedIndexes[NodeType.AttackDetails].Count;
                    for (int k = 0; k < count; k++)
                    {

                        node.SetValue(NodeSpec.GetKeys(NodeType.AttackDetails)[k], (uint)0xF0 + (uint)i);
                    }


                    //node.SetValue(NodeSpec.GetKeys(NodeType.AttackDetails)[0], 0xFF - (uint)i);
                    //node.SetValue(NodeSpec.GetKeys(NodeType.AttackDetails)[NodeSpec.KeyedIndexes[NodeType.AttackDetails].Count-1], 0xFF - (uint)i);
                }
            }
        }
        static public void DoAnotherThing()
        {
            UnitCharacter unit = (UnitCharacter)UnitHandler.UnitSet[unitCtr];
            Random rand = new Random();
            unit.PropertyGroups[types[propertyCounter]].CopyNodeRecorded(rand.Next(0, unit.PropertyLoader.GetMax(types[propertyCounter])));
            propertyCounter += 1;

            if(propertyCounter == 4)
            {
                propertyCounter = 0;
                unitCtr += 1;

                if (unitCtr > 20)
                {
                    unitCtr = 0;
                }
            }

            mainCtr += 1;

        }

        static public void DoSomethingElse()
        {
            for (int i = 0; i < 20; i++)
            {
                UnitCharacter unit = (UnitCharacter)UnitHandler.UnitSet[i];

                PropertyGroup group = unit.GetPropertyGroup(PropertyType.AttackDetails);
                PropertyGroup group1 = unit.GetPropertyGroup(PropertyType.Acceleration);
                PropertyGroup group2 = unit.GetPropertyGroup(PropertyType.Collision1);
                PropertyGroup group3 = unit.GetPropertyGroup(PropertyType.AllCollision);
                Random random = new Random();

                for (int j = 0; j < 100; j++)
                {
                    group.CopyNodeRecorded(random.Next(0, group.Count));
                    if (Stop) return;
                    group1.CopyNodeRecorded(random.Next(0, group1.Count));
                    if (Stop) return;
                    group2.CopyNodeRecorded(random.Next(0, group2.Count));
                    if (Stop) return;
                    group3.CopyNodeRecorded(random.Next(0, group3.Count));
                    if (Stop) return;
                    //node.SetValue(NodeSpec.GetKeys(NodeType.AttackDetails)[0], 0xFF - (uint)i);
                    //node.SetValue(NodeSpec.GetKeys(NodeType.AttackDetails)[NodeSpec.KeyedIndexes[NodeType.AttackDetails].Count-1], 0xFF - (uint)i);
                }
            }
        }
    }
}
