using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TheBees.GameRom;
using TheBees.Records;

namespace TheBees.UnitData
{
    public class PropertyGroup : NodeSequence
    {
        private NodeType nodeType;
        private PropertyType propertyType;
        public event Action<PropertyType, int> MaxValueChangedEvent;

        public PropertyGroup(uint sourceAddress, int count, NodeType type, PropertyType newPropertyType)
            : base(sourceAddress)
        {
            this.nodeType = type;
            propertyType = newPropertyType;

            int nodeSize = (int)NodeSpec.SpecSizes[type];
            currentAddress = sourceAddress;
            for (int i = 0; i < count; i++)
            {
                dataNodes.Add(NodeUtil.GetProperNode(type, currentAddress));
                size += nodeSize;
                currentAddress = sourceAddress + (uint)size;
            }
        }

        public NodeType Type { get { return nodeType; } }

        ////////////////////////////////////////
        // recordable actions
        ////////////////////////////////////////

        static public PropertyGroup GetRecordable(uint address, int count, NodeType type, PropertyType newPropertyType, Unit parent)
        {
            if (!MasterList.ContainsKey(address))
            {
                MasterList[address] = new PropertyGroup(address, count, type, newPropertyType);
                if(!(parent is UnitMissile))
                {
                    //if (creatingBaseRecords) MasterList[address].InitializeRecord();
                }
            }

            return (PropertyGroup)MasterList[address];
        }

        protected override void OnRecordedCountChanged()
        {
            if(MaxValueChangedEvent!=null)
                MaxValueChangedEvent(propertyType, dataNodes.Count);
        }
    }
}
