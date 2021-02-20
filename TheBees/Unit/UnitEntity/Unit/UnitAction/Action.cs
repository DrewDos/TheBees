using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TheBees.Records;
using TheBees.GameRom;

using TheBees.User;

namespace TheBees.UnitData
{
    public class UnitAction : NodeSequence
    {
        public const bool RetrievingActionCounts = false;
        public const int HeaderSize = 0x08;
        private List<int> motionIndexes;
        private List<ActionReference> references = new List<ActionReference>();
        private int forceNodeCount = -1;
        private List<int> loadAsMotionIndexes = null;
        private List<int> realIndexes = new List<int>();

        // debugging
        public bool ZeroFooter = false;

        static public bool GetBaseActionLengths = false;
        static public List<UnitAction> AllActions = new List<UnitAction>();
        private Action initializeAction = null;

        public UnitAction(uint newAddress, ActionReference reference, bool finalize = true)
            : base(newAddress, finalize)
        {
            references.Add(reference);
            forceNodeCount = ActionGuide.GetActionLength(newAddress);
            loadAsMotionIndexes = ActionGuide.GetTreatAsMotionIndex(newAddress);

            if (forceNodeCount > 0)
            {
                initializeAction = InitDataForcedCount;
            }
            else
            {
                initializeAction = InitDataFindFooter;
            }

            initializeAction();
            UpdateRealIndexes();
        }

        private UnitAction()
            : base(0, false)
        {
        }

        ////////////////////////////////////////
        // node loading
        ////////////////////////////////////////
        
        private bool CheckLoadFooterBefore()
        {
            FunctionCall tempCall = new FunctionCall(currentAddress, NodeType.FunctionCall8);
            if (tempCall.Value1 + tempCall.Value2 + tempCall.Value3 == 0)
            {
                if (tempCall.FunctionCode == 0x02)
                {
                    return false;
                }
            }

            return true;
        }

        private bool CheckLoadFooterAfter(DataNode newNode)
        {

            if (!(newNode is FunctionCall))
                return true;

            FunctionCall call = ((FunctionCall)newNode);

            if (call.FunctionCode == 0x06 && call.Value1 + call.Value2 + call.Value3 == 0)
            {
                return false;
            }
            
            // check if code 45 follows 0x10
            //if (call.FunctionCode == 0x45 && funcSum == 0)
            //{
            //    FunctionCall nextCall = new FunctionCall(currentAddress, NodeType.FunctionCall8);
            //    if (nextCall.FunctionCode != 0x10)
            //        return false;
            //}

            return true;
        }

        private void InitDataForcedCount()
        {
            uint checkFooter;
            motionIndexes = new List<int>();

            // load the header first
            AddNodeByType(NodeType.ActionHeader);
            checkFooter = RomData.Get32(currentAddress);

            // keep loading nodes until we get to the footer
            int counter = 1;

            while (checkFooter != 0x10000 && counter < forceNodeCount)
            {
                bool forceMotion = false;
                if (loadAsMotionIndexes != null)
                {
                    if (loadAsMotionIndexes.IndexOf(dataNodes.Count) != -1)
                    {
                        forceMotion = true;
                    }
                }

                DataNode newNode = AddActionNode(RomData.Get8(currentAddress), forceMotion);

                counter += 1;
                checkFooter = RomData.Get32(currentAddress);
            }

            // now, load the footer if we can
            if (counter < forceNodeCount)
            {
                if (checkFooter == 0x10000)
                {
                    AddNodeByType(NodeType.ActionFooter);
                }
                else
                {
                    throw new Exception("should not be less than forceNodeCount");
                }


                
            }
        }

        private void InitDataFindFooter()
        {
            uint checkFooter;
            motionIndexes = new List<int>();

            // load the header first
            AddNodeByType(NodeType.ActionHeader);
            checkFooter = RomData.Get32(currentAddress);
            
            // keep loading nodes until we get to the footer
            bool loadFooter = true;

            while (checkFooter != 0x10000)
            {
                // general checks
                // check if function code is 4 with empty values

                //if (!CheckLoadFooterBefore())
                //{
                //    loadFooter = false;
                //    break;
                //}

                bool forceMotion = false;
                if (loadAsMotionIndexes != null)
                {
                    if (loadAsMotionIndexes.IndexOf(dataNodes.Count) != 0)
                    {
                        forceMotion = true;
                    }
                }


                DataNode newNode = AddActionNode(RomData.Get8(currentAddress), forceMotion);

                // final checks
                if (!CheckLoadFooterAfter(newNode))
                {
                    loadFooter = false;
                    break;
                }

                checkFooter = RomData.Get32(currentAddress);
            }
            
            // now, load the footer if we can
            if(loadFooter)
                AddNodeByType(NodeType.ActionFooter);
        }

        public override int[] InsertNodesRecorded(int position, params DataNode[] newNodes)
        {
            if (newNodes == null || newNodes.Length == 0)
                throw new ArgumentException("Nodes cannot be null and nodes cannot be empty");

            for (int i = 0; i < newNodes.Length; i++)
            {
                if (!(newNodes[i].GetType().IsSubclassOf(typeof(ActionNode))))
                    throw new Exception("Nodes are not action nodes");

                if (Header.DataLengthInBytes != ((ActionNode)newNodes[i]).SizeInBytes && !(newNodes[i] is FunctionCall))
                {
                    newNodes[i] = ConvertSize(newNodes[i], Header.DataLengthInBytes);
                }
            }

            return base.InsertNodesRecorded(position, newNodes);
        }
        protected override int [] InsertNodes(int position, params DataNode [] newNodes)
        {
           
            int [] res = base.InsertNodes(position, newNodes);

            if (res.Length == 0)
                return res;

            // update motion indexes
            AssignForceMotions();
            UpdateRealIndexes();

            // update node count
            ActionGuide.SetActionLength(address, Count);

            return res;
        }

        public override int RemoveNodes(int[] indexes)
        {

            int removeCount = base.RemoveNodes(indexes);

            if (removeCount == 0)
                return 0;


            // update motion indexes
            AssignForceMotions();
            UpdateRealIndexes();

            // update node count
            ActionGuide.SetActionLength(address, Count);

            return removeCount;
        }

        private void AssignForceMotions()
        {
            List<int> forceMotionTemp = new List<int>();

            for (int i = 0; i < dataNodes.Count; i++)
            {
                if (dataNodes[i] is Motion)
                {
                    forceMotionTemp.Add(i);
                }
            }

            if (forceMotionTemp.Count > 0)
            {
                ActionGuide.SetForceMotionRange(address, forceMotionTemp);
                loadAsMotionIndexes = ActionGuide.GetTreatAsMotionIndex(address);
            }
            else if (ActionGuide.GetTreatAsMotionIndex(address) != null)
            {
                ActionGuide.ClearForceMotion(address);
            }
        }

        public override DataNode AddNodeByType(NodeType type)
        {
            RawNodeType rawType = NodeUtil.GetRawFromNodeType(type);
            DataNode newNode;

            switch (rawType)
            {
                case RawNodeType.Motion:
                    newNode = new Motion(currentAddress, NodeUtil.GetNodeTypeFromRaw(RawNodeType.Motion, Header.DataLengthInBytes));
                    break;
                case RawNodeType.FunctionCall:
                    newNode = new FunctionCall(currentAddress, NodeUtil.GetNodeTypeFromRaw(RawNodeType.FunctionCall, 0x08));// Header.DataLengthInBytes));
                    break;
                default:
                    switch (type)
                    {
                        case NodeType.ActionHeader:
                            newNode = new ActionHeader(currentAddress);
                            break;
                        default:
                            newNode = new DataNode(currentAddress, type);
                            break;
                    }
                    break;
            }


            dataNodes.Add(newNode);
            int currSize = NodeSpec.SpecSizes[type];
            size += currSize;
            currentAddress += (uint)currSize;

            return newNode;
        }

        private DataNode AddActionNode(byte nodeType, bool forceMotion)
        {
            // is motion?
            if (nodeType != 0 || forceMotion)
            {
                motionIndexes.Add(dataNodes.Count);
                NodeType someType = NodeUtil.GetNodeTypeFromRaw(RawNodeType.Motion, Header.DataLengthInBytes);
                return AddNodeByType(someType);
            }
            else
            {
                return AddNodeByType(NodeUtil.GetNodeTypeFromRaw(RawNodeType.FunctionCall, 0x08));
            }
        }
        

        public DataNode CreateNodeFromType(NodeType type, uint offset)
        {
            switch (NodeUtil.GetRawFromNodeType(type))
            {
                case RawNodeType.Motion:
                    return new Motion(offset, type);
                default:
                    return new DataNode(offset, type);
            }
        }
        private int GetNewSize(int newSizeOfData)
        {
            int newSize = 0;

            for (int i = 0; i < dataNodes.Count; i++)
            {
                newSize += NodeSpec.SpecSizes[SelectNewType(dataNodes[i], newSizeOfData)];
            }

            return newSize;
        }

        private NodeType SelectNewType(DataNode node, int newSizeOfData)
        {
            NodeType addType = node.GetNodeType();

            return SelectNewType(addType, newSizeOfData);
        }

        private NodeType SelectNewType(NodeType newType, int newSizeOfData)
        {
            RawNodeType type = NodeUtil.GetRawFromNodeType(newType);

            if (type != RawNodeType.None)
            {
                newType = NodeUtil.GetNodeTypeFromRaw(type, newSizeOfData);
            }

            return newType;
        }


        public Motion GetMotion(int index)
        {
            return (Motion)dataNodes[(int)motionIndexes[index]];
        }

        ////////////////////////////////////////
        // recordable methods
        ////////////////////////////////////////

        public void AddReference(ActionReference reference)
        {
            references.Add(reference);
        }

        public ActionReference GetReference(int index)
        {
            return references[index];
        }

        ////////////////////////////////////////
        // recordable actions
        ////////////////////////////////////////

        static public void InitializeRecords()
        {
            AllActions.ForEach((x) => x.InitializeRecord());
        }


        public override int SwapNodes(int src, int target)
        {
            int res = base.SwapNodes(src, target);
            AssignForceMotions();
            return res;
        }

        protected override Recordable GetCopy()
        {
            UnitAction newAction = new UnitAction();
            newAction.dataNodes.AddRange(GetNodeListCopy());
            newAction.motionIndexes = new List<int>();
            newAction.motionIndexes.AddRange(motionIndexes);
            newAction.forceNodeCount = forceNodeCount;
            if(loadAsMotionIndexes != null)
            {
                newAction.loadAsMotionIndexes = new List<int>();
                newAction.loadAsMotionIndexes.AddRange(loadAsMotionIndexes);
            }
            newAction.InitSizeCurrent();
            return newAction;
        }

        public override Recordable GetCopyRecorded()
        {
            Recordable newRecordable = base.GetCopyRecorded();
            ActionGuide.SetActionLength(newRecordable.Address, ((UnitAction)newRecordable).Count);
            ((UnitAction)newRecordable).AssignForceMotions();
            return newRecordable;
        }

        ////////////////////////////////////////
        // base data support
        ////////////////////////////////////////

        static public void FixIntercepts()
        {
            UnitAction srcAction;
            UnitAction dstAction;

            List<UnitAction> finalSrcActions = new List<UnitAction>();
            List<UnitAction> finalDstActions = new List<UnitAction>();

            for (int i = 0; i < AllActions.Count; i++)
            {
                srcAction = AllActions[i];

                for (int j = 0; j < AllActions.Count; j++)
                {
                    dstAction = AllActions[j];
                    if (srcAction == dstAction) continue;

                    if (srcAction.Address >= dstAction.Address && srcAction.Address < (dstAction.Address+(uint)dstAction.SizeInBytes))
                    {
                        //if (!finalSrcActions.Contains(srcAction))
                            finalSrcActions.Add(srcAction);
                        //if (!finalDstActions.Contains(dstAction))
                            finalDstActions.Add(dstAction);
                    }
                }
            }

            for (int i = 0; i < finalSrcActions.Count; i++)
            {
                finalDstActions[i].Trim(finalSrcActions[i].Address);
            }
        }

        protected override void Trim(uint nodeAddressStart)
        {
            base.Trim(nodeAddressStart);

            motionIndexes.Clear();

            for (int i = 0; i < dataNodes.Count; i++)
            {
                if (dataNodes[i] is Motion)
                    motionIndexes.Add(i);
            }
        }

        static public void PopulateActionLengths()
        {
            AllActions.ForEach((x) => ActionGuide.SetActionLength(x.address, x.Count));
        }

        static public UnitAction GetRecordable(uint realAddress, ActionReference reference)
        {
            bool setReference = true;
            if (!MasterList.ContainsKey(realAddress))
            {
                if (reference == null)
                    throw new Exception("When creating an action, reference must be set");

                MasterList[realAddress] = new UnitAction(realAddress, reference);
                setReference = false;
            }

            if (reference != null && setReference)
                ((UnitAction)MasterList[realAddress]).AddReference(reference);

            return (UnitAction)MasterList[realAddress];
        }

        static public UnitAction CreateRecordable(ActionReference reference, int sizeInBytes, bool addFooter)
        {
            UnitAction newAction = new UnitAction();

            ActionHeader header = new ActionHeader(0);
            header.MakeEmptyBuffer();
            header.DataLengthInBytes = sizeInBytes;
            newAction.AddNode(header);
            newAction.motionIndexes = new List<int>();
            
            DataNode footer = null;
            if (addFooter)
            {
                footer = new DataNode(NodeType.ActionFooter);
                footer.MakeEmptyBuffer();
                footer.SetValue("undef1", 0x10000);
                newAction.AddNode(footer, false);
            }

            newAction.references.Add(reference);

            RecordSpace space = NodeSequence.SpaceGroup.GetSpaceFromFreeSize(newAction.SizeInBytes);
            uint newAddress = space.GetNewRecordStart();
            newAction.RecordEntity = new Record(newAddress, newAction.SizeInBytes);
            space.AddRawRecord(newAction.RecordEntity);
            newAction.SetAddress(newAddress);
            newAction.FinalizeAddress(newAddress);

            header.ApplyBuffer();
            if (footer != null) footer.ApplyBuffer();
            ActionGuide.SetActionLength(newAddress, newAction.Count);
            return newAction;
        }

        public override void FinalizeAddress(uint newAddress)
        {
            base.FinalizeAddress(newAddress);

            AllActions.Add(this);
        }

        protected override void OnRecordedCountChanged()
        {
            // do nothing
            return;
        }

        ////////////////////////////////////////
        // general methods
        ////////////////////////////////////////

        private void UpdateRealIndexes()
        {
            realIndexes.Clear();
            int functionLimit = Header.DataLengthInBytes / 0x08;
            int functionCtr = 0;

            for (int i = 0; i < dataNodes.Count; i++)
            {
                functionCtr = 0;
                realIndexes.Add(i);
                while(dataNodes.Count > i && dataNodes[i] is FunctionCall)
                {
                    functionCtr += 1;
                    if (functionCtr == functionLimit)
                        break;
                    i += 1;
                }
            }
        }

        public int GetRealFromListIndex(int listIndex)
        {
            if (listIndex == 0) return 0;

            int index = realIndexes.Find((x) => x == listIndex);

            if (index == 0)
            {
                // is function call
                int leniency = Header.DataLengthInBytes / 8 - 1;
                index = realIndexes.Find((x) => listIndex >= x && dataNodes[x] is FunctionCall && (listIndex - x <= leniency));
            }

            return index;
        }

        public int GetFromRealIndex(int realIndex)
        {
            return realIndexes[realIndex];
        }

        private DataNode ConvertSize(DataNode srcNode, int newSizeOfData)
        {

            NodeType currType = srcNode.GetNodeType();
            NodeType newType = SelectNewType(currType, newSizeOfData);

            DataNode newNode = CreateNodeFromType(newType, currentAddress);

            newNode.MakeEmptyBuffer();

            List<string> newKeys = new List<string>(NodeSpec.KeyedIndexes[newType].Keys);
            List<string> currKeys = new List<string>(NodeSpec.KeyedIndexes[currType].Keys);

            int valueCount = srcNode.Values.Length;

            for (int valueIndex = 0; valueIndex < valueCount; valueIndex++)
            {
                string key = currKeys[valueIndex];

                if (newNode.ContainsKey(key))
                {
                    newNode.SetValue(key, srcNode.GetValue(key));
                }
            }

            // fix tweak motions between sizes
            if (srcNode is Motion)
            {
                if(currType == NodeType.Motion16 && newType == NodeType.Motion24)
                {
                    ((Motion)newNode).TweakMotion *= 2;
                }
                else if (currType == NodeType.Motion24 && newType == NodeType.Motion16)
                {
                    ((Motion)newNode).TweakMotion /= 2;
                }
            }

            newNode.SetNodeType(newType);

            return newNode;
        }

        public bool ChangeLengthOfData(int newSizeOfData)
        {

            if (newSizeOfData == LengthOfDataInBytes)
                throw new ArgumentException("newSizeOfData must be a different size");

            int newSize = GetNewSize(newSizeOfData);

            if (SizeInBytes > newSize)
            {
                if (!spaceGroup.FreeSizeAvailable(record, newSize))
                    return false;
            }


            PrepareResize(newSize);
            currentAddress = address;

            BufferData();

            int currSize = 0;
            size = 0;

            Header.SetAddress(currentAddress);
            currentAddress += HeaderSize;

            int nodeCount = Count;
            if(dataNodes.Last().GetNodeType() == NodeType.ActionFooter)
                nodeCount = Count-1;

            for (int i = 1; i < nodeCount; i++)
            {
                if (dataNodes[i] is FunctionCall)
                    continue;

                DataNode srcNode = dataNodes[i];
                DataNode newNode = ConvertSize(srcNode, newSizeOfData);

                dataNodes[i].ClearBuffer();

                // this is kind of dangerous
                // we might be inflicting upon a reference to this node
                dataNodes[i] = null;
                dataNodes[i] = newNode;

                currSize = NodeSpec.SpecSizes[newNode.GetNodeType()];

                currentAddress += (uint)currSize;
                size += currSize;

            }

            if(dataNodes.Last().GetNodeType() == NodeType.ActionFooter)
                dataNodes.Last().SetAddress(currentAddress);

            ApplyBuffer();

            Header.DataLengthInBytes = newSizeOfData;

            UpdateRealIndexes();
            return true;

        }

        protected override void BeforeDataMove()
        {
            base.BeforeDataMove();

            ActionGuide.ClearActionLength(address);
            ActionGuide.ClearForceMotion(address);
        }
        protected override void AfterSetAddress()
        {
            base.AfterSetAddress();

            ActionGuide.SetActionLength(address, dataNodes.Count);
            if (loadAsMotionIndexes != null)
            {
                ActionGuide.SetForceMotion(address, 1);
            }
        }

        public bool HasBaseFooter
        {
            get
            {
                return dataNodes.Last().GetNodeType() == NodeType.ActionFooter;
            }
        }

        public ActionHeader Header { get { return (ActionHeader)dataNodes.First(); } }
        //public DataNode Footer { get { return dataNodes.Last(); } }

        public int ReferenceCount { get { return references.Count; } }
        public int MotionCount { get { return motionIndexes.Count; } }
        public int[] MotionIndexes { get { return motionIndexes.ToArray(); } }
        public int LengthOfDataInBytes { get { return Header.DataLengthInBytes; } }
    }
}
