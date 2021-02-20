using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;

using TheBees.Sprites;

namespace TheBees.UnitData
{
    public delegate void OnUpdateLoadCharacterUnitDelegate(int index);
    public delegate void OnUpdateLoadMissileUnitDelegate(int index);

    static class UnitHandler
    {
        static private List<Unit> unitSet = null;
        static private Unit missileUnit = null;

        static public Action<int> OnLoadCharacterUnit;
        static public Action<int> OnLoadMissileUnit;
        static public event Action OnLoadingComplete;

        static public List<Unit> UnitSet { get { return unitSet; } }

        static public void Clear()
        {
            unitSet = null;
            missileUnit = null;
        }

        static public UnitCharacter[] GetCharacterUnits()
        {
            List<UnitCharacter> unitCharacters = new List<UnitCharacter>();

            foreach (Unit currUnit in unitSet)
            {
                if (currUnit is UnitCharacter)
                {
                    unitCharacters.Add((UnitCharacter)currUnit);
                }
            }

            return unitCharacters.ToArray();
        }

        static public int GetCharacterUnitCount()
        {
            return UnitSpec.CharacterUnitCount;
        }

        static public void InitUnitSet()
        {
            unitSet = new List<Unit>();

            List<int> validIndexes = new List<int>();

            for(int i = 0; i < UnitSpec.CharacterUnitCount; i++)
            {

                if (OnLoadCharacterUnit != null)
                    OnLoadCharacterUnit(i);

                var watch = Stopwatch.StartNew();
                unitSet.Add(new UnitCharacter(UnitSpec.GetCharacterUnitOffset(i), i));
                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;
            }

            if (OnLoadMissileUnit != null)
                OnLoadMissileUnit(0);
            
            unitSet.Add(new UnitMissile(UnitSpec.GetMissileUnitOffset(), UnitSpec.MissileUnitIndex, UnitSpec.AddressOfMissleConfigOffset, UnitSpec.MissileConfigCount));
            missileUnit = unitSet[unitSet.Count - 1];

            if (OnLoadingComplete != null)
                OnLoadingComplete();

        }

        static public Unit GetUnit(int index)
        {
            return unitSet[index];
        }

        static public void SetupBaseInfo(bool isBaseData, bool obtainingBaseData)
        {
            if (obtainingBaseData)
            {
                // unit action
                if (UnitAction.RetrievingActionCounts)
                {
                    OnLoadingComplete += UnitAction.FixIntercepts;
                    OnLoadingComplete += UnitAction.PopulateActionLengths;
                }
                OnLoadingComplete += UnitAction.InitializeRecords;

                OnLoadingComplete += ClearBaseCallback;
            }
        }

        static private void ClearBaseCallback()
        {
            // unit action
            if (UnitAction.RetrievingActionCounts)
            {
                OnLoadingComplete -= UnitAction.FixIntercepts;
                OnLoadingComplete -= UnitAction.PopulateActionLengths;
            }


            OnLoadingComplete -= UnitAction.InitializeRecords;
        }

        //static priv List<Unit> CharacterUnitSet
        //{
        //    get
        //    {
        //        return characterUnitSet;
        //    }
        //}

        static public Unit MissileUnit
        {
            get
            {
                return missileUnit;
            }
        }
        static public Color[] GetCharacterUnitPallet(int selectedIndex)
        {
            uint address;
            try
            {
                address = RomData.Get32(UnitSpec.GetCharacterUnitPalletOffset((uint)UnitSpec.UnitIndexRedirect[UnitSpec.PalletAddressRedirect[selectedIndex] - 1])) - 0x400000;
            }
            catch(IndexOutOfRangeException)
            {
                address = RomData.Get32(UnitSpec.GetCharacterUnitPalletOffset((uint)UnitSpec.UnitIndexRedirect[UnitSpec.PalletAddressRedirect[0] - 1])) - 0x400000;
            }
            return Pallet.GetPallet(address);

        }

        static public Color[] GetMissileUnitPallet(int selectedIndex)
        {
            return null;
        }
    }
}
