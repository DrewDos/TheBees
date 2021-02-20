using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

using TheBees.GameRom;
using TheBees.Records;

namespace TheBees.UnitData
{
    public delegate void OnLoadUnitDelegate(int unitIndex);
    public delegate void OnUpdateGroupAddressDelegate(int typeNum, uint newAddress);

    public abstract class Unit
    {
        private const int addressCount = 0x18;
        protected Dictionary<PropertyType, PropertyGroup> propertyGroups;
        protected Dictionary<ActionType, ActionGroup> actionGroups;

        protected uint address;
        protected List<uint> addresses;
        protected int index;

        public const int AddressCount = 24;

        // recordable support
        private Dictionary<ActionType, RecordableObserver> actionGroupObservables = new Dictionary<ActionType, RecordableObserver>();
        private Dictionary<PropertyType, RecordableObserver> propertyObservables = new Dictionary<PropertyType, RecordableObserver>();

        // keep these properties here
        public uint Address { get { return address; } }
        public int Index { get { return index; } }

        static public OnLoadUnitDelegate OnUnitLoaded = null;

        protected PropertyLoader propertyLoader;
        public PropertyLoader PropertyLoader { get { return propertyLoader; } }

        public Unit(uint address, int index)
        {
            this.address = address;
            this.index = index;

            propertyGroups = new Dictionary<PropertyType, PropertyGroup>();
            actionGroups = new Dictionary<ActionType, ActionGroup>();


            if (OnUnitLoaded != null) OnUnitLoaded(index);
        }

        protected void LoadUnit()
        {
            LoadAddresses();
            LoadActionGroups();
            LoadPropertyGroups();
        }

        protected virtual void LoadAddresses()
        {
            addresses = new List<uint>();

            for (int i = 0; i < AddressCount; i++)
            {
                addresses.Add(RomData.Get32(address + (uint)(4 * i)));
            }
        }
        
        protected virtual void LoadActionGroups()
        {
            // Load up the basic groups
            AddAction(ActionType.ClientBehavior1);
            AddAction(ActionType.ClientBehavior2);
            AddAction(ActionType.NormalOperation);
            AddAction(ActionType.Mortals);
            AddAction(ActionType.ClientBehavior3);
            AddAction(ActionType.Throws);
            AddAction(ActionType.Tricks);
            AddAction(ActionType.VictoryPose);
            AddAction(ActionType.SubroutineMortal);
            AddAction(ActionType.LandingBehavior);
        }

        protected void OnCallLoadPropertyGroup(PropertyType type, NodeType nodeType)
        {
            AddProperty(type, nodeType, propertyLoader.GetMax(type));
        }

        protected virtual void LoadPropertyGroups()
        {
            // get max values
            if (!Globals.GetGuideDataAsBase)
            {
                propertyLoader.LoadFromGuide();
            }
            else
            {
                propertyLoader.LoadFromData();
            }

            propertyLoader.UpdateGuideData();
        }

        public ActionGroup GetActionGroup(ActionType type)
        {
            if (actionGroups.ContainsKey(type))
            {
                return actionGroups[type];
            }

            return null;
        }

        public bool GroupExists(PropertyType type)
        {
            return propertyGroups.ContainsKey(type);
        }

        public bool GroupExists(ActionType type)
        {
            return actionGroups.ContainsKey(type);
        }


        public PropertyGroup GetPropertyGroup(PropertyType type)
        {
            if (propertyGroups.ContainsKey(type))
            {
                return propertyGroups[type];
            }

            return null;
        }

        protected void AddAction(ActionType type)
        {
            uint loadingAddress = addresses[(int)type];
            if(loadingAddress != 0)
            {
                //ActionGroup newGroup = new ActionGroup(addresses[(int)type], type, this);
                //actionGroups.Add(type, newGroup);
                ActionGroup group = ActionGroup.GetRecordable(loadingAddress, type, this);
                actionGroupObservables[type] = new RecordableObserver(group, OnUpdateGroupAddress);
                actionGroups.Add(type, group);

            }
        }

        protected void AddProperty(PropertyType propertyType, NodeType nodeType, int count)
        {
            if (addresses[(int)propertyType] != 0)
            {
                PropertyGroup newGroup = PropertyGroup.GetRecordable(addresses[(int)propertyType], count, nodeType, propertyType, this);
                propertyObservables[propertyType] = new RecordableObserver(newGroup, OnUpdateGroupAddress);
                propertyGroups.Add(propertyType,  newGroup);

                newGroup.MaxValueChangedEvent += OnMaxPropertyValueChanged;
            }
        }

        private uint GetPointerOffset(int index)
        {
            return address + (uint)(4 * index);
        }

        private void OnUpdateGroupAddress(RecordableMoveParams p)
        {
            UpdateGroupAddresses();
        }

        private void UpdateGroupAddresses()
        {
            int actionGroupStart = 0;
            int actionGroupEnd = (int)ActionType.VictoryPose;
            int propertyGroupStart = (int)PropertyType.TweakMotion;
            int propertyGroupEnd = (int)PropertyType.AttackDetails;

            for (int i = actionGroupStart; i <= actionGroupEnd; i++)
            {
                if(actionGroups.ContainsKey((ActionType)i))
                {
                    RomData.Set32(address + (uint)(i * 4), actionGroups[(ActionType)i].Address);
                }
            }
            for (int i = propertyGroupStart; i <= propertyGroupEnd; i++)
            {
                if (propertyGroups.ContainsKey((PropertyType)i))
                {
                    RomData.Set32(address + (uint)(i * 4), propertyGroups[(PropertyType)i].Address);
                }
            }
        }

        //public void UpdatePropertyAddress(PropertyType type, uint newAddress)
        //{
        //    addresses[(int)type] = newAddress;
        //    propertyGroups[type].SetAddress(newAddress);
        //}

        //public void UpdateGroupAddress(int typeNum, uint newAddress)
        //{
        //    if (addressCount > typeNum)
        //    {
        //        addresses[(int)typeNum] = newAddress;
        //        RomData.Set32(address + (uint)typeNum * 4, newAddress); // fix later
        //    }
        //}

        public DataNode GetPropertyNode(PropertyType type, int index)
        {
            if (propertyGroups[type].DataNodes.Count <= index)
                return null;

            return propertyGroups[type].GetNode(index);
        }


        public uint GetAddress(PropertyType type)
        {
            return addresses[(int)type];
        }

        public uint GetAddress(ActionType type)
        {
            return addresses[(int)type];
        }

        public void OnMaxPropertyValueChanged(PropertyType type, int newMax)
        {
            PropertyLoader.SetMax(type, newMax);
        }

        public Dictionary<ActionType, ActionGroup> ActionGroups { get { return actionGroups; } }
        public Dictionary<PropertyType, PropertyGroup> PropertyGroups { get { return propertyGroups; } }
    }
}
