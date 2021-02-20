using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TheBees.GameRom;
using TheBees.UnitData;
using TheBees.General;

namespace TheBees.Forms
{
    public partial class TabSAEffect : NodeLayout
    {
        SuperArtSettings settingsNode;

        public TabSAEffect(ActiveDataElement source)
            : base(source)
        {
            //InitializeComponent();
        }


        public TabSAEffect()
            : base(null)
        {
            //InitializeComponent();
        }
        public override void LoadNode(DataNode newNode)
        {
            settingsNode = (SuperArtSettings)newNode;

            base.LoadNode(newNode);
        }


        protected override void RegisterControls()
        {
            tbSuperArtNum.MaxValue = 0x0003; 
            tbMaxSA1.MaxValue = 0xFFFF; 
            tbMaxSA2.MaxValue = 0xFFFF;
            tbAirSA.MaxValue = 0xFFFF;
            tbVolume.MaxValue = 0xFFFF; 
            tbGaugeCount.MaxValue = 0xFFFF; 
            tbDecreaseSpeed.MaxValue = 0xFFFF;

            rbNormal.Tag = 0x00;
            rbUsesGuage.Tag = 0x01;
            rbActivateOnDeath.Tag = 0x03;

            ControlSet.RegisterControl(tbSuperArtNum, "saNumber");
            ControlSet.RegisterControl(tbMaxSA1, "maxSA1");
            ControlSet.RegisterControl(tbMaxSA2, "maxSA2");
            ControlSet.RegisterControl(tbAirSA, "airSA");
            ControlSet.RegisterControlRange(
                NodeLayoutControlSet.ControlsToArray(rbNormal, rbActivateOnDeath, rbUsesGuage),
                new Ref<uint>(() => (uint)settingsNode.Flag, (x) => { settingsNode.Flag = (SuperArtFlag)x;  })
            );
            ControlSet.RegisterControl(tbVolume, "volume");
            ControlSet.RegisterControl(tbGaugeCount, "numberOfGauge");
            ControlSet.RegisterControl(tbDecreaseSpeed, "decreaseSpeed");
        }
    }
}
