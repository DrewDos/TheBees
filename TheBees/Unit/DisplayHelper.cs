using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using TheBees.UnitData.Node;
using TheBees.Forms;
using TheBees.GameRom;

namespace TheBees.UnitData
{
    static class DisplayHelper
    {
        public static MotionRequest GetRequestsFromMotion(Unit unit, Motion primary)
        {
            return GetRequests(unit, primary, GetGfxNodesFromMotion(unit, primary));
        }

        public static MotionRequest GetRequestsFromRange(Unit unit, Motion primary, SupportGraphicSpec[] gfxNodes)
        {
            return GetRequests(unit, primary, GetGfxNodesFromRange(gfxNodes));
        }

        private static MotionRequest GetRequests(Unit unit, Motion primary, SupportGraphicSpec[][] gfxNodes)
        {
            List<SpriteRequest> requestList = new List<SpriteRequest>();
            Dictionary<DataNode, int> nodeMap = new Dictionary<DataNode, int>();
            int currIndex = 0;

            for (int layerIndex = 0; layerIndex < 2; layerIndex++)
            {
                if (gfxNodes != null)
                {
                    if (gfxNodes[layerIndex] != null && gfxNodes[layerIndex].Length > 0)
                    {
                        int count = gfxNodes[layerIndex].Length;

                        for (int i = 0; i < count; i++)
                        {
                            requestList.Add(GetSupportRequest(unit, gfxNodes[layerIndex][i]));
                            nodeMap[gfxNodes[layerIndex][i]] = currIndex;
                            currIndex++;
                        }
                    }
                }

                if (layerIndex == 0)
                {
                    if (primary != null && primary.SpriteIndex != 0)
                    {
                        SpriteRequest req = GetUnitRequest(unit, primary);
                        requestList.Add(req);
                        nodeMap[primary] = currIndex;
                        currIndex++;
                    }
                }
            }


            return new MotionRequest(nodeMap, requestList);
        }

        private static SpriteRequest GetSupportRequest(Unit unit, SupportGraphicSpec supportNode)
        {
            return new SpriteRequest(supportNode.SpriteIndex,
                        GetSupportPallet(unit, supportNode),
                        supportNode.XPos,
                        -supportNode.YPos,
                        supportNode.FlipX,
                        supportNode.FlipY);
        }

        private static SpriteRequest GetUnitRequest(Unit unit, Motion motion)
        {
            return new SpriteRequest(
                    motion.SpriteIndex,
                    GetDefaultPallet(unit),
                    0,
                    0,
                    motion.FlipX,
                    motion.FlipY,
                    true
                );
        }

        private static Color[] GetDefaultPallet(Unit unit)
        {
            if (unit is UnitMissile)
            {
                return ((UnitData.UnitCharacter)UnitHandler.UnitSet[0]).PalletSet.GetPallet(UnitPalletType.Normal, UnitPalletSideIndex.Left, 0, 0);
            }
            else if (unit is UnitCharacter)
            {
                return ((UnitData.UnitCharacter)unit).PalletSet.GetPallet(UnitPalletType.Normal, UnitPalletSideIndex.Left, 0, 0);
            }
            else
            {
                throw new ArgumentException("Invalid Unit Type");
            }
        }
        private static Color[] GetSupportPallet(Unit unit, SupportGraphicSpec supportNode)
        {
            if (unit.GetType() == typeof(UnitCharacter))
            {
                uint redirectValue = GameData.GameDataHandler.SpecialGraphicRedirect.GetSuppleValue(supportNode.PalletIndex).Value;
                UnitPalletType palletType = (redirectValue & 0x2000) > 0 ? UnitPalletType.Dim : UnitPalletType.Normal;

                //if (palletType == UnitPalletType.Dim)
                //    redirectValue += 1;
                return ((UnitCharacter)unit).PalletSet.GetPallet(palletType, UnitPalletSideIndex.Left, 0, (int)redirectValue & 0xFF);
            }
            else
            {
                throw new Exception("Pallets for non-characters not yet implemented");
            }
        }

        private static SupportGraphicSpec[][] GetGfxNodesFromMotion(Unit unit, Motion motion)
        {
            List<SupportGraphicSpec> gfxNodesFront = new List<SupportGraphicSpec>();
            List<SupportGraphicSpec> gfxNodesBack = new List<SupportGraphicSpec>();
            PropertyGroup gfxExtGroup = unit.GetPropertyGroup(PropertyType.SupportGraphicsExt);

            if (gfxExtGroup == null)
                return null;
            SupportGraphicSpecExt gfxExtNode = (SupportGraphicSpecExt)gfxExtGroup.GetNode(motion.SupportGfxIndex);
            PropertyGroup allGfxNodes = unit.GetPropertyGroup(PropertyType.SupportGraphics);
            SupportGraphicSpec[][] output = new SupportGraphicSpec[2][];
            HashSet<int> tempHash = new HashSet<int>();

            for (int i = 0; i < 4; i++)
            {
                int index = 0;
                if (gfxExtNode != null)
                {
                    index = (int)gfxExtNode.GetValue(String.Format("gfxIndex{0}", i + 1));
                }

                if (index != 0)
                {
                    SupportGraphicSpec currGfxNode = (SupportGraphicSpec)allGfxNodes.GetNode(index);

                    if (!tempHash.Contains(index))
                    {
                        if (currGfxNode.LayerValue != 1)
                        {
                            gfxNodesFront.Add(currGfxNode);
                        }
                        else
                        {
                            gfxNodesBack.Add(currGfxNode);
                        }

                        tempHash.Add(index);
                    }

                }
            }

            if (gfxNodesFront.Count == 0 && gfxNodesBack.Count == 0)
                return null;

            gfxNodesBack.Reverse();
            output[0] = gfxNodesBack.ToArray();
            output[1] = gfxNodesFront.ToArray();

            return output;
        }


        public static SupportGraphicSpec[][] GetGfxNodesFromRange(SupportGraphicSpec[] nodes)
        {
            List<SupportGraphicSpec> gfxNodesFront = new List<SupportGraphicSpec>();
            List<SupportGraphicSpec> gfxNodesBack = new List<SupportGraphicSpec>();
            SupportGraphicSpec[][] output = new SupportGraphicSpec[2][];

            for (int i = 0; i < nodes.Length; i++)
            {
                if (nodes[i].LayerValue != 1)
                {
                    gfxNodesFront.Add(nodes[i]);
                }
                else
                {
                    gfxNodesBack.Add(nodes[i]);
                }
            }

            gfxNodesBack.Reverse();
            output[0] = gfxNodesBack.ToArray();
            output[1] = gfxNodesFront.ToArray();
            return output;
        }
    }

    public class MotionRequest
    {
        private Dictionary<DataNode, int> map;
        private List<SpriteRequest> requests;

        public Dictionary<DataNode, int> Map { get { return map; } }
        public List<SpriteRequest> Requests { get { return requests;}}

        public MotionRequest(Dictionary<DataNode, int> newMap, List<SpriteRequest> newRequests)
        {
            map = newMap;
            requests = newRequests;
        }
    }
}
