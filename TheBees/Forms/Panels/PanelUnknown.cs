//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Windows.Forms;

//using TheBees.GameRom;
//using TheBees.UnitData;

//namespace TheBees.Forms
//{
//    public class PanelUnknown : NodePanel
//    {

//        protected static NodeLayout pageUnknown;

//        public PanelUnknown(int xPosition, int yPosition, int width, int height, ActiveDataElement activeDataSource)
//            : base(xPosition, yPosition, width, height, activeDataSource)
//        {
//        }


//        protected override void SetVariables()
//        {
//            pageCount = 1;
//        }

//        protected override void LoadPanel()
//        {
//            pageUnknown = new TabFunctionCall(activeData);
//        }

//        protected override void SetupPages()
//        {
//            pages = new NodeLayout[pageCount];

//            pages[0] = pageUnknown;
//        }

//        public override void LoadNode(DataNode source)
//        {
//            pageUnknown.LoadNode(source);
//        }
//    }
    

//}
