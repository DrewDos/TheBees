using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using TheBees.GameRom;
using TheBees.Records;
using TheBees.User;
using TheBees.Data;

namespace TheBees.UnitData
{
    public class ActionGroup : Recordable
    {
        static private bool maintainData = false;
        public override bool MaintainData { get { return maintainData; } }

        protected ActionType type;
        public ActionType ActionType { get { return type; } }

        private MappedRecordableList recordableList;
        public MappedRecordableList RecordableList { get { return recordableList; } }
        private Unit parent;

        public ActionGroup(uint address, ActionType newType, Unit newParent)
            : base(address, true)
        {
            parent = newParent;
            type = newType;
            recordableList = new MappedRecordableList(UpdateAddressList);
            LoadActions(RomData.GetAddressList(address).ToArray());
        }

        private uint GetPointerOffset(int index)
        {
            return address + (uint)(4 * index);
        }

        protected void LoadActions(uint [] gameAddresses)
        {
            for (int i = 0; i < gameAddresses.Length; i++)
            {
                uint realAddress = gameAddresses[i] - UnitAction.HeaderSize;

                recordableList.AddMap(UnitAction.GetRecordable(realAddress, new ActionReference(parent.Index, (int)type, i, 0)));
            }
        }

        public UnitAction GetAction(int index)
        {
            return (UnitAction)recordableList.GetMap(index);
        }

        public ActionReference[] GetAllIndexes()
        {
            List<ActionReference> nodeIndexes = new List<ActionReference>();
            
            for (int i = 0; i < recordableList.MapCount; i++)
            {
                UnitAction action = (UnitAction)recordableList.GetMap(i);

                for (int j = 0; j < action.Count; j++)
                {
                    nodeIndexes.Add(new ActionReference(parent.Index, (int)type, i, j));
                }
            }

            return nodeIndexes.ToArray();

        }
        public int AddAction(UnitAction newAction)
        {
            if (record == null)
                throw new Exception("Record is null");

            recordableList.AddMap(newAction);
            UpdateAddressList();

            return Count - 1;
            
        }

        ////////////////////////////////////////
        // recordable actions
        ////////////////////////////////////////

        static public ActionGroup GetRecordable(uint address, ActionType newType, Unit parent)
        {
            if (!MasterList.ContainsKey(address))
            {
                ActionGroup newGroup = new ActionGroup(address, newType, parent);
                if (creatingBaseRecords) newGroup.InitializeRecord();
            }

            return (ActionGroup)MasterList[address];
        }

        public int AppendActionRecorded(int actionIndex)
        {
            return AppendActionRecorded((UnitAction)recordableList.GetMap(actionIndex).GetCopyRecorded());            
        }

        public int AppendActionRecorded(UnitAction newAction)
        {
            if (newAction == null)
                return -1;

            if (!PrepareResize(SizeInBytes + 0x04))
                return -1;

            return AddAction(newAction);
        }
        private void UpdateAddressList()
        {
            int i = 0;
            uint[] addresses = recordableList.GetAddressList();

            for (; i < addresses.Length; i++)
            {
                RomData.Set32(address+(uint)(i*4), addresses[i]+UnitAction.HeaderSize);
            }

            RomData.Set32(address + (uint)(i * 4), 0);
        }

        protected override void BeforeDataMove()
        {
            // do nothing
            return;
        }

        protected override void AfterSetAddress()
        {
            UpdateAddressList();
        }

        protected override RecordSpaceGroup spaceGroup
        {
            get
            {
                return RecordGuide.ProgramSpace;
            }
        }

        //public List<uint> AllAddresses { get { return addresses; } }
        public int Count { get { return recordableList.MapCount; } }
        public override int SizeInBytes { get { return Count * 4 + 4; }}
        //public List<UnitAction> Actions { get { return actions; } }
    }

    public class ActionReference
    {
        private int unitNum;
        private int groupNum;
        private int actionNum;
        private int dataNum;

        public ActionReference(int newUnitNum, int newGroupNum, int newActionNum, int newDataNum)
        {
            unitNum = newUnitNum;
            groupNum = newGroupNum;
            actionNum = newActionNum;
            dataNum = newDataNum;
        }

        public void SetDataNum(int newData)
        {
            dataNum = newData;
        }
        public int UnitNum { get { return unitNum; } }
        public int GroupNum { get { return groupNum; } }
        public int ActionNum { get { return actionNum; } }
        public int DataNum { get { return dataNum; } }
    }
}
