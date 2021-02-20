using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TheBees.GameRom;
using TheBees.UnitData;
using TheBees.Forms.Support.DataControl;

namespace TheBees.Forms
{
    public class PanelMissileConfig : NodePanel
    {

        protected static NodeLayout pageMissileConfig;
        protected static TabAccel pageAccel1;
        protected static TabAccel pageAccel2;
        private bool accelMatching = false;
        private Dictionary<string, NodeLayout> keyedTabs = new Dictionary<string, NodeLayout>();

        public PanelMissileConfig(int xPosition, int yPosition, int width, int height, ActiveDataElement activeDataSource)
            : base(xPosition, yPosition, width, height, activeDataSource)
        {
        }


        protected override void SetVariables()
        {
            pageCount = 3;
        }

        protected override void LoadPanel()
        {
            pageMissileConfig = new TabMissileConfig(activeData);
            pageAccel1 = new TabAccel(activeData);
            pageAccel2 = new TabAccel(activeData);

            pageMissileConfig.ValueChangedEvent += OnChangeValue;
            pageAccel1.ValueChangedEvent += OnChangeValue;
            pageAccel2.ValueChangedEvent += OnChangeValue;

            pageAccel1.PrimaryIndexChanged += (x) => OnAccelIndexChanged("accel1", x);
            pageAccel2.PrimaryIndexChanged += (x) => OnAccelIndexChanged("accel2", x);

            keyedTabs["accel1"] = pageAccel1;
            keyedTabs["accel2"] = pageAccel2;
        }

        public void OnChangeValue(DataControlEventParams p)
        {
            NodeDataStream.SaveData();
        }

        protected override void SetupPages()
        {
            pages = new NodeLayout[pageCount];

            pages[0] = pageMissileConfig;
            pages[1] = pageAccel1;
            pages[2] = pageAccel2;
        }

        protected override void OnLoadTabs()
        {
            //pageMissileConfig.EnableEdit("accel1", false);
            //pageMissileConfig.EnableEdit("accel2", false);
        }

        public override void LoadNode(DataNode source)
        {
            pageMissileConfig.LoadNode(source);
            pageAccel1.LoadNode((int)source.GetValue("accel1"));
            pageAccel2.LoadNode((int)source.GetValue("accel2"));

            UpdateMatchingAccel("accel1");
        }

        private void OnAccelIndexChanged(string tag, int index)
        {

            pageMissileConfig.ControlSet.GetControlByKey(tag).UpdateControl((uint)index);
            UpdateMatchingAccel(tag);
            //pageMissileConfig.Verification.Pending = true;
        }

        private void UpdateMatchingAccel(string keepTag)
        {
            if (pageAccel1.PrimaryIndex == pageAccel2.PrimaryIndex)
            {
                if (keepTag == "accel1")
                {
                    pageAccel2.Enabled = false;
                }


                else if (keepTag == "accel2")
                {
                    pageAccel1.Enabled = false;
                }
                accelMatching = true;
            }
            else
            {
                pageAccel1.Enabled = true;
                pageAccel2.Enabled = true;
                accelMatching = false;
            }

            keyedTabs[keepTag].PreventBufferRelease = accelMatching;
        }
    }


}
