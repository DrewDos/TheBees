using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TheBees.GameRom;
using TheBees.UnitData;

namespace TheBees.Forms
{
    public static class ActiveData
    {
        static private ActiveDataElement [] elements = new ActiveDataElement[8];
        static private bool initialized = false;

        static public ActiveDataElement GetDataElement(int index)
        {
            if (!initialized)
            {
                Array.Clear(elements, 0, 8);

                initialized = true;
            }

            if (elements[index] == null)
            {
                elements[index] = new ActiveDataElement();
            }

            return elements[index];
            
        }

    }
    public class ActiveDataElement
    {
        private Unit unit = null;
        private ActionGroup group = null;
        private UnitAction action = null;
        private DataNode data = null;

        
        public Unit Unit { get { return unit; }}
        public ActionGroup Group { get { return group; }}
        public UnitAction Action { get { return action; } }
        public DataNode Data { get { return data; } }

        public void SetUnit(Unit source)
        {
            unit = source;
        }
        public void SetGroup(ActionGroup source)
        {
            group = source;
        }
        public void SetAction(UnitAction source)
        {
            action = source;
        }
        public void SetDataNode(DataNode source)
        {
            data = source;
        }
    }
}
