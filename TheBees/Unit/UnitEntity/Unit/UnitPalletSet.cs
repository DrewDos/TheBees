using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TheBees.GameRom;
using System.Drawing;
using TheBees.Sprites;

namespace TheBees.UnitData
{
    class UnitPalletSet
    {
        private PalletIndexSet[] palletIndexSets;
        private int palletsPerSection;
        private int dimStart;
        private int exStart;

        public UnitPalletSet(PalletIndexSet[] srcIndexSets)
        {
            palletIndexSets = srcIndexSets;

            // each pallet set consists of two groups of pallets per side
            // each group per side refers to a set of normal pallets, and a set of dim pallets
            // there are 4 ex pallets. two refer to normal luminosity, two refer to dim luminosity
            // left side normal, right side normal, left side dim, right side dim, 4 ex pallets
            palletsPerSection = (srcIndexSets[0].Count - 4) / 4;
            dimStart = palletsPerSection * 2;
            exStart = palletsPerSection * 4;
        }

        public PalletIndexSet GetIndexSet(int groupNum)
        {
            return palletIndexSets[groupNum];
        }

        private int GetBaseIndex(UnitPalletType palletType, UnitPalletSideIndex sideIndex)
        {
            int indexOffset = 0;

            switch (palletType)
            {
                case UnitPalletType.Normal:
                    indexOffset = 0;
                    break;

                case UnitPalletType.Dim:
                    indexOffset = dimStart;
                    break;
                case UnitPalletType.EX:
                    indexOffset = exStart;
                    break;
            }

            switch (sideIndex)
            {  
                case UnitPalletSideIndex.Left:
                    break;
                case UnitPalletSideIndex.Right:
                    indexOffset += palletsPerSection;
                    break;
            }

            return indexOffset;
        }
        public uint GetPalletAddress(UnitPalletType palletType, UnitPalletSideIndex sideIndex, int groupNum, int palletIndex)
        {
            return GetIndexSet(groupNum).GetAddressFromIndex(GetBaseIndex(palletType, sideIndex) + palletIndex) - 0x400000;
        }
        public Color[] GetPallet(UnitPalletType palletType, UnitPalletSideIndex sideIndex, int groupNum, int palletIndex)
        {
            return Sprites.Pallet.GetPallet(GetIndexSet(groupNum).GetAddressFromIndex(GetBaseIndex(palletType, sideIndex) + palletIndex) - 0x400000);
        }

        public void SetPallet(UnitPalletType palletType, UnitPalletSideIndex sideIndex, int groupNum, int palletIndex, Color [] pallet)
        {
            Sprites.Pallet.SetPallet(GetIndexSet(groupNum).GetAddressFromIndex(GetBaseIndex(palletType, sideIndex) + palletIndex) - 0x400000, pallet);
        }

        public int GetIndexCount(UnitPalletType palletType)
        {
            if (palletType == UnitPalletType.EX)
                return 4;

            return palletsPerSection;
        }
    }

    public enum UnitPalletSideIndex
    {
        Left,
        Right
    }
    public enum UnitPalletType
    {
        Normal,
        Dim,
        EX,
        None
    }
}
