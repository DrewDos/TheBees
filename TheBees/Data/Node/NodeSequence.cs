using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TheBees.Records;
using TheBees.User;

namespace TheBees.GameRom
{
    public abstract class NodeSequence : Recordable
    {

        static public event Action OnRecordableAction;
        protected uint currentAddress;
        protected int size = 0;
        protected List<DataNode> dataNodes = new List<DataNode>();
        public List<DataNode> DataNodes { get { return dataNodes; } }

        static private bool maintainData = false;
        public override bool MaintainData { get { return maintainData; } }

        protected override RecordSpaceGroup spaceGroup
        {
            get
            {
                return RecordGuide.ProgramSpace;
            }
        }

        static public RecordSpaceGroup SpaceGroup { get { return RecordGuide.ProgramSpace; } }

        protected NodeSequence(uint sourceAddress, bool finalize = true)
            : base(sourceAddress, finalize)
        {
            currentAddress = sourceAddress;
        }

        protected override void MakeEmptyBuffer()
        {
            for (int i = 0; i < Count; i++)
            {
                DataNodes[i].MakeEmptyBuffer();
            }
        }

        protected override void BufferData()
        {
            for (int i = 0; i < Count; i++)
            {
                DataNodes[i].BufferValues();
            }
        }

        protected override void ApplyBuffer()
        {
            for (int i = 0; i < Count; i++)
            {
                DataNodes[i].ApplyBuffer();
            }
        }

        protected override void ClearBuffer()
        {
            for (int i = 0; i < Count; i++)
            {
                DataNodes[i].ClearBuffer();
            }
        }

        protected override void SetBuffer(Recordable srcRecordable)
        {
            NodeSequence srcSequence = (NodeSequence)srcRecordable;
            
            if (srcSequence.Count != Count)
                throw new Exception("DataNodes between sequences do not match");

            for (int i = 0; i < Count; i++)
            {
                if(srcSequence.dataNodes[i].GetNodeType() != dataNodes[i].GetNodeType())
                throw new Exception("Data nodes between sequences do not match");
            }

            for (int i = 0; i < Count; i++)
            {
                dataNodes[i].SetBuffer(srcSequence.dataNodes[i]);
            }
        }

        protected override void BeforeDataMove()
        {
            base.BeforeDataMove();

            BufferData();
        }

        protected override void AfterSetAddress()
        {
            base.AfterSetAddress();

            ApplyBuffer();
            ClearBuffer();
        }
        protected virtual int [] InsertNodes(int position, params DataNode [] newNodes)
        {
            if (newNodes == null || newNodes.Length == 0)
                throw new Exception("Nodes cannot be null");

            int totalNodeSize = 0;
            Array.ForEach(newNodes, (x) => totalNodeSize += x.SizeInBytes);

            uint targetAddress;

            if (position == Count)
            {
                targetAddress = currentAddress;
            }
            else
            {
                targetAddress = dataNodes[position].Address;
            }

            for (int i = position; i < Count; i++)
            {
                dataNodes[i].BufferValues();
                dataNodes[i].AdjustAddress(totalNodeSize);
            }
            dataNodes.InsertRange(position, newNodes);

            if (Array.Find(newNodes, (x) => !x.Buffered) != null)
                throw new Exception("Nodes must be buffered before inserting");

            Array.ForEach(newNodes, (x) =>
            {
                //x.BufferValues();
                x.SetAddress(targetAddress);
                x.ApplyBuffer();
                x.ClearBuffer();
                targetAddress += (uint)x.SizeInBytes;
            });

            for (int i = position + newNodes.Length; i < Count; i++)
            {
                dataNodes[i].ApplyBuffer();
                dataNodes[i].ClearBuffer();
            }

            InitSizeCurrent();

            List<int> output = new List<int>();
            for (int i = 0; i < newNodes.Length; i++) output.Add(i+position);

            return output.ToArray();
        }

        protected virtual void Trim(uint nodeAddressStart)
        {
            int startIndex = dataNodes.IndexOf(dataNodes.Find((x) => x.Address == nodeAddressStart));

            if (startIndex == -1) return;
            if (startIndex == 0) throw new Exception("None to remove");

            bool removed = false;
            while (dataNodes.Count != startIndex)
            {
                dataNodes.RemoveAt(startIndex);
                removed = true;
            }

            if (dataNodes.Count == 0)
                throw new Exception("No more nodes");

            if(!removed)
                return;

            size = 0;
            currentAddress = address;
            dataNodes.ForEach((x) => size += x.SizeInBytes);
            currentAddress += (uint)size;
        }

        protected bool ContainsNode(uint nodeAddressStart)
        {
            return dataNodes.Find((x) => x.Address == nodeAddressStart) != null;
        }

        public DataNode[] GetNodeCopiesFromIndexes(int[] indexes = null)
        {
            DataNode[] tmpNodes = GetNodesFromIndexes(indexes);
            List<DataNode> output = new List<DataNode>();
            Array.ForEach(tmpNodes, (x) => {
                bool clearBuffer = false;
                if (!x.Buffered)
                {
                    clearBuffer = true;
                    x.BufferValues();
                }
                DataNode newNode = x.GetCopy(true);
                newNode.BufferValues();
                output.Add(newNode);
                if (clearBuffer) x.ClearBuffer();

            });
            return output.ToArray();
        }

        public DataNode[] GetNodesFromIndexes(int[] indexes = null)
        {
            List<DataNode> output = new List<DataNode>();

            if (indexes != null)
            {
                foreach (int index in indexes) { output.Add(DataNodes[index]); }
                return output.ToArray();
            }
            else
            {
                return DataNodes.ToArray();
            }
        }

        public virtual int RemoveNodesRecorded(int [] indexes)
        {
            DataNode[] nodes = GetNodesFromIndexes(indexes);
            int newSize, subSize = 0;
            
            Array.ForEach(nodes, (x) => { subSize += x.SizeInBytes; });
            newSize = SizeInBytes - subSize;

            BufferData();

            PrepareResize(newSize);

            return RemoveNodes(indexes);

        }

        public virtual int RemoveNodes(int[] indexes)
        {
            currentAddress = address;
            size = 0;


            for (int i = indexes.Length - 1; i >= 0; i--)
            {
                if (dataNodes[indexes[i]].GetNodeType() == NodeType.ActionHeader)
                    throw new ArgumentException("Cannot remove Action Header");
                dataNodes.RemoveAt(indexes[i]);
            }

            for (int i = 0; i < dataNodes.Count; i++)
            {
                dataNodes[i].SetAddress(currentAddress);
                dataNodes[i].ApplyBuffer();
                dataNodes[i].ClearBuffer();
                currentAddress += (uint)dataNodes[i].SizeInBytes;
                size += dataNodes[i].SizeInBytes;
            }

            return indexes.Length;
        }


        public virtual int[] InsertNodesRecorded(int position, params DataNode[] newNodes)
        {
            int newSize = SizeInBytes;
            Array.ForEach(newNodes, (x) => newSize += x.SizeInBytes);

            if (!PrepareResize(newSize))
                return null;

            return InsertNodes(position, newNodes);
        }

        public int AppendNodeRecorded(params DataNode [] newNodes)
        {
            int newSize = SizeInBytes;
            Array.ForEach(newNodes, (x) => newSize += x.SizeInBytes);

            return InsertNodesRecorded(Count, newNodes)[0];
        }

        public int AppendNodeRecorded(int srcIndex)
        {
            DataNode node = dataNodes[srcIndex];
            DataNode newNode;
            bool clearBuffer = false;
            if (!node.Buffered)
            {
                node.BufferValues();
                clearBuffer = true;
            }
            newNode = node.GetCopy(true);

            if (clearBuffer)
                node.ClearBuffer();
                       
            return InsertNodesRecorded(Count, newNode)[0];
        }

        public DataNode GetNode(int index)
        {
            return DataNodes[index];
        }

        public DataNode AddNode(DataNode newNode, bool setNewAddress = true)
        {
            bool pendClear = false;

            if (setNewAddress && newNode.Address != currentAddress)
            {
                //throw new Exception("Nodes not in sequence");
                newNode.BufferValues();
                newNode.SetAddress(currentAddress);
                newNode.ApplyBuffer();
                pendClear = true;
            }

            dataNodes.Add(newNode);
            currentAddress += (uint)newNode.SizeInBytes;
            size += newNode.SizeInBytes;
            if(pendClear)
                newNode.ClearBuffer();
            return newNode;
        }

        public virtual DataNode AddNodeByType(NodeType type)
        {
            return AddNode(new DataNode(currentAddress, type));
        }


        public DataNode CopyNode(int index)
        {
            return AddNode(DataNodes[index].GetCopy(true));
        }

        public List<DataNode> GetNodeListCopy()
        {
            List<DataNode> newList = new List<DataNode>();
            foreach(DataNode node in dataNodes)
            {
                newList.Add(node.GetCopy(true));
            }
            return newList;
        }
        public virtual int SwapNodes(int src, int target)
        {
            DataNode srcNode = dataNodes[src];
            DataNode targetNode = dataNodes[target];
            uint tmpAddr = targetNode.Address;

            srcNode.BufferValues();
            targetNode.BufferValues();

            targetNode.SetAddress(srcNode.Address);
            srcNode.SetAddress(tmpAddr);

            targetNode.ApplyBuffer();
            srcNode.ApplyBuffer();

            dataNodes[src] = targetNode;
            dataNodes[target] = srcNode;

            return target;

        }

        public bool CopyNodeRecorded(int index)
        {

            if (!PrepareResize(SizeInBytes + dataNodes[index].SizeInBytes))
                return false;
            
            CopyNode(index);
            OnRecordedCountChanged();

            if (OnRecordableAction != null)
                OnRecordableAction();

            return true;
        }


        public bool AddNodeRecordable(DataNode newNode)
        {
           
            if (!PrepareResize(SizeInBytes + newNode.SizeInBytes))
                return false;

            AddNode(newNode);
            OnRecordedCountChanged();

            if (OnRecordableAction != null)
                OnRecordableAction();
            return true;

        }

        protected void InitSizeCurrent()
        {
            SetSize();
            SetCurrent();
        }


        protected void SetSize()
        {
            size = (int)dataNodes[dataNodes.Count - 1].Address + dataNodes[dataNodes.Count - 1].SizeInBytes - (int)address;
        }

        protected void SetCurrent()
        {
            currentAddress = (uint)size + address;
        }


        public virtual void SetAddress(uint newAddress)
        {
            uint oldAddr = address;
            address = newAddress;
            currentAddress = newAddress;

            UpdateNodeAddresses();

            //CallOnUpdateAddress(oldAddr ,startAddr);
        }

        public void AdjustAddress(int adjustment)
        {
            SetAddress((uint)((int)address + adjustment));
        }

        protected void UpdateNodeAddresses()
        {
            for (int i = 0; i < dataNodes.Count; i++)
            {
                dataNodes[i].SetAddress(currentAddress);
                currentAddress += (uint)dataNodes[i].SizeInBytes;
            }
        }
        protected override void OnUpdateAddress(uint oldAddress, uint newAddress)
        {
            base.OnUpdateAddress(oldAddress, newAddress);
            SetAddress(newAddress);
        }

        protected virtual void OnRecordedCountChanged()
        {
            throw new NotImplementedException("Must be implemented in a derived class");
        }


        public override int SizeInBytes { get { int output = 0; dataNodes.ForEach( (x) => output += x.SizeInBytes); return output ; } }
        public virtual uint DataAddress { get { return address; } }
        public int Count { get { return dataNodes.Count; } }
    }
}
