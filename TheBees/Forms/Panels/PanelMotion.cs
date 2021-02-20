//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Windows.Forms;

//using TheBees.GameRom;
//using TheBees.UnitData;

//namespace TheBees.Forms
//{
//    public class PanelMotion : NodePanel
//    {


//        private static NodeLayout pageAttack;
//        private static NodeLayout pageCollision;
//        private static NodeLayout pageMotion;

//        public PanelMotion(int xPosition, int yPosition, int width, int height, ActiveDataElement activeDataSource)
//            : base(xPosition, yPosition, width, height, activeDataSource)
//        {
//        }


//        protected override void SetVariables()
//        {
//            pageCount = 3;
//        }

//        protected override void LoadPanel()
//        {
//            pageMotion = new TabMotion(activeData);
//            pageAttack = new TabAttackDetails(activeData);
//            pageCollision = new TabCollision(activeData);
//        }

//        protected override void SetupPages()
//        {
//            pages = new NodeLayout[pageCount];

//            pages[0] = pageMotion;
//            pages[1] = pageAttack;
//            pages[2] = pageCollision;

//            //pageMotion.OnEditChanged = OnEditChanged;
//            pageAttack.OnIndexChanged = OnIndexChange;
//            pageCollision.OnIndexChanged = OnIndexChange;
//        }

//        public override void LoadNode(DataNode source)
//        {
//            pageMotion.LoadNode(source);

//            if (source.GetNodeType() != NodeType.Motion8)
//            {
//                pageAttack.LoadNode(activeData.Unit.GetPropertyGroup(PropertyType.AttackDetails).GetNode((int)((Motion)source).AttackIndex));
//                pageCollision.LoadNode(activeData.Unit.GetPropertyGroup(PropertyType.AllCollision).GetNode((int)((Motion)source).AllCollisionIndex));

//                EnableTab(1);
//                EnableTab(2);
//            }
//            else
//            {
//                EnableTab(1, false);
//                EnableTab(2, false);
//            }
//        }

//        private void OnIndexChange(NodeLayout control, string tag, int value)
//        {
//            if (tag == "allCollision")
//            {
//                pageMotion.QueueValue(tag, (uint)value);
//                pageMotion.SetVerificationFlag();
//            }
//            if(tag == "attackIndex")
//            {
//                pageMotion.QueueValue(tag, (uint)value);
//                pageMotion.SetVerificationFlag();
//            }
//        }


//    }

//}
