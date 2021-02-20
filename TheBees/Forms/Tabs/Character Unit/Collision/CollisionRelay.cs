using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;

using TheBees.GameRom;
using TheBees.UnitData;

namespace TheBees.Forms
{
    public static class CollisionRelay
    {
        static private SpriteViewer viewer;

        static private string[] keys = new string[]
        {
            "decision1",
            "decision2",
            "decision3",
            "atkRoll",
            "throwJgmt",
            "jgmtThrown"
        };

        public static void SetSpriteViewer(SpriteViewer source)
        {
            viewer = source;
        }

        // get current rects for sprite view
        public static Rectangle[] GetCollisionRects(DataNode node, string type)
        {
            int typeCount = 0;

            switch (node.GetNodeType())
            {
                case NodeType.Collision16:
                    typeCount = 16;
                    break;
                case NodeType.Collision4:
                    typeCount = 4;
                    break;
            }

            Rectangle[] output = new Rectangle[typeCount / 4];

            for (int i = 0; i < typeCount / 4; i++)
            {
                string[] keys = NodeSpec.GetCollisionKeysFromIndex(i);
                short[] values = new short[4];

                for (int j = 0; j < 4; j++)
                {
                    values[j] = (short)node.GetValue(keys[j]);
                }

                output[i] = GetCollisionRect(values);

            }

            return output;
        }

        // update the collision view
        public static void UpdateViewAll(DataNode [] nodes)
        {
            Color [] colors = new Color []
            {
                Color.FromArgb(0, 255, 0),
                Color.FromArgb(128, 128, 255),
                Color.FromArgb(0, 255, 255),
                Color.FromArgb(255, 0, 0),
                Color.FromArgb(255, 128, 0),
                Color.FromArgb(255, 255, 0)
            };

            viewer.InitializeCollision();

            for (int i = 0; i < nodes.Length; i++)
            {
                if (nodes[i] != null)
                {
                    viewer.SetCollision(keys[i], GetCollisionRects(nodes[i], keys[i]), colors[i]);
                }
            }

            viewer.CollisionSetComplete();
        }

        public static void UpdateViewType(DataNode node, string type)
        {
            viewer.UpdateCollision(type, GetCollisionRects(node, type));

            viewer.CollisionSetComplete();
        }

        public static void UpdateViewSingle(DataNode node, string type, int index)
        {
            viewer.UpdateCollision(type, new Rectangle[] { GetCollisionRectFromIndex(node, type, index) }, index);

            viewer.CollisionSetComplete();
        }

        // get rect based off of collision indexes
        public static Rectangle GetCollisionRectFromIndex(DataNode node, string type, int index)
        {

            return GetCollisionRect(
                (short)node.GetValue(String.Format("x{0}_start", index + 1)),
                (short)node.GetValue(String.Format("x{0}_width", index + 1)),
                (short)node.GetValue(String.Format("y{0}_start", index + 1)),
                (short)node.GetValue(String.Format("y{0}_width", index + 1))
            );
        }

        // get rect based off of values
        public static Rectangle GetCollisionRect(params short[] values)
        {
            return new Rectangle((int)values[0], -((int)values[2]) + -((int)values[3]), (int)values[1], (int)values[3]);
        }

        // helper to get values from rectangle
       

        public static short[] GetValuesFromRect(Rectangle source)
        {
            short[] output = new short[4];

            output[0] = (short)(source.X);
            output[1] = (short)source.Width;
            output[2] = (short)(-(source.Y + source.Height));
            output[3] = (short)source.Height;

            return output;
        }

        public static short [] GetValuesFromViewerRect(string type, int index)
        {
            return GetValuesFromRect(viewer.GetCollisionBox(type, index).RawRect);
        }




    }
}
