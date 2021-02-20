using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;

using TheBees.Forms;
using TheBees.GameRom;
using TheBees.UnitData;
using TheBees.Records;
using TheBees.Description;

namespace TheBees
{
    static class LoadHandler
    {
        public delegate void OnLoadSuccessDelegate();

        static private int numValues;
        static private int currProgress;
        static private LoadingForm form = new LoadingForm();
        static public OnLoadSuccessDelegate OnLoadSuccess = null;
        static private Thread loadingThread = null;

        static public void Initialize()
        {
            // initialize callbacks
            RomData.OnLoadFileUpdate = OnUpdateLoadRom;
            UnitHandler.OnLoadCharacterUnit = OnUpdateLoadCharacterUnit;
            UnitHandler.OnLoadMissileUnit = OnUpdateLoadMisisleUnit;
        }

        static public bool LoadData(string sourceDirectory, RomType sourceLoadMethod)
        {
            Globals.RomLocation = sourceDirectory;

            currProgress = 0;
            numValues = 0;

            if (sourceLoadMethod == RomType.COMBINED)
            {
                numValues += RomData.RomFileCountCombined;
            }
            else if (sourceLoadMethod == RomType.SEPARATED)
            {
                numValues += RomData.RomFileCountSeparated;
            }
            
            numValues += UnitHandler.GetCharacterUnitCount();
            numValues += 1;//missile unit;

            form.SetProgressMax(numValues);
            form.SetProgress(0);
            form.SetMessage("Loading...");

            loadingThread = new Thread(
                new ThreadStart(() =>
                {
                    RomData.LoadRomData(sourceDirectory, sourceLoadMethod);

                    Globals.RomLoaded = true;
                    if (OnLoadSuccess != null)
                    {
                        OnLoadSuccess();
                    }
                    form.DialogResult = DialogResult.OK;
                }

            ));

            form.HandleCreated += OnFormHandleCreated;

            if(form.ShowDialog() == DialogResult.OK)
            {
                return true;
            }
            
            return false;

        }

        static public void OnFormHandleCreated(object o, EventArgs e)
        {
            loadingThread.Start();
        }
        static public bool CheckDirValid(string directory, RomType type)
        {
            int foundCount = 0;
            string[] files = null;
            int targetCount = 0;

            switch (type)
            {
                case RomType.COMBINED:
                    files = RomData.RomNamesCombined;
                    targetCount = RomData.RomFileCountCombined;
                    break;

                case RomType.SEPARATED:
                    files = RomData.RomNamesSeparated;
                    targetCount = RomData.RomFileCountSeparated;
                    break;

            }

            for (int i = 0; i < targetCount; i++)
            {
                if (File.Exists(directory + files[i]))
                {
                    foundCount += 1;
                }
            }

            if (foundCount == targetCount)
            {
                Globals.LoadedType = type;
                return true;
            }

            return false;
        }




        static private void CloseLoadingForm()
        {
            form.BeginInvoke(
                new Action(() =>
                {
                    form.Close();
                }
            ));
        }

        static private void UpdateLoadingForm(string message)
        {
            currProgress += 1;
            form.BeginInvoke(
                new Action(() =>
                {
                    form.SetMessage(message);
                    form.SetProgress(currProgress);
                }
            ));
        }

        static void OnUpdateLoadRom(int index, string romName)
        {
            UpdateLoadingForm(String.Format("Loading Rom {0}", romName));
        }

        static void OnUpdateLoadCharacterUnit(int index)
        {
            UpdateLoadingForm(String.Format("Loading Character Unit #{0}", index+1));
        }

        static void OnUpdateLoadMisisleUnit(int index)
        {
            UpdateLoadingForm(String.Format("Loading Missile Unit #{0}", index+1));
        }

        static void LoadRom(RomType loadMethod)
        {
            RomData.LoadRomData(@"C:\SF3\Roms\sfiii3\", loadMethod);
        }

    }
}
