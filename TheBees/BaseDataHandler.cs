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
using TheBees.GameData;
using TheBees.Sprites;
using TheBees.Sound;
using TheBees.User;

namespace TheBees
{
    static class BaseDataHandler
    {
        static public event Action<bool, bool> OnObtainBaseInfoEvent;

        static public void Initialize()
        {
            Globals.RomLoaded = false;
            Globals.LoadedType = RomType.NONE;

            // configure base callbacks
            RecordGuide.LoadCompleteEvent += Recordable.AllLoadComplete;

            if (Settings.Debug)
            {
                RecordGuide.LoadCompleteEvent += Debugging.CheckNestedActions;
                RecordGuide.LoadCompleteEvent += Debugging.GetZeroFooters;
            }

            SpriteHandler.SetOperationCompleteCallback();

            OnObtainBaseInfoEvent += UnitHandler.SetupBaseInfo;
            OnObtainBaseInfoEvent += Recordable.SetupBaseInfo;

            // initialize support classes
            RomData.Initialize();
            RomGuide.Initialize();
            RecordGuide.Initialize();
            LoadHandler.Initialize();

            if (Settings.SetStreamingData)
            {
                DataNode.OnSetDataValue = NodeDataStream.OnNodeUpdate;
                //ModifyAction.UpdateAll = NodeDataStream.SaveData;
                ModifyCommand.OnUpdateComplete = NodeDataStream.SaveData;
                ModifySAEffect.OnUpdateNode = NodeDataStream.SaveData;
                NodeDataStream.DestinationDir = Settings.StreamDataTarget;
                SupportGraphics.UpdateComplete = NodeDataStream.SaveData;

            }

            LoadHandler.OnLoadSuccess = OnLoad;
        }

        static public bool Close()
        {
            if (Globals.RomLoaded)
            {
                RomData.Clear();
                DescriptionBody.Clear();
                RomGuide.Clear();
                CommandSet.Clear();
                UnitHandler.Clear();
                Globals.RomLoaded = false;

                return true;
            }

            return false;
        }

        static private void OnLoad()
        {
            //SoundTest.TestGetSampleSet();
            
            bool isBaseRom = RomSpec.BaseChecksum.SequenceEqual(RomData.Checksum);
            Globals.IsBaseRom = isBaseRom;

            // get the game data
            GameData.GameDataHandler.Initialize();

            // load action debug values
            ActionDebug.LoadWithReferences();

            // get the guide data first
            RomGuide.Load(isBaseRom, Settings.GuideSource);

            bool obtainingBaseData = isBaseRom && !RecordGuide.HasBaseData;
            if (OnObtainBaseInfoEvent != null)
                OnObtainBaseInfoEvent(isBaseRom, obtainingBaseData);

            //NormalSpriteDef.PreventPending = isBaseRom && !RecordGuide.HasBaseData;
            SpriteHandler.LoadAllSpriteDefs();

            // load sound data
            SoundEffectMap.LoadSoundEffectGroup();
            SampleDataMap.LoadSampleDataGroup();
            RawSampleHeaderMap.LoadAllHeaderGroups();

            // load all of the units
            UnitHandler.InitUnitSet();
            
            RecordGuide.LoadComplete(isBaseRom && !RecordGuide.HasBaseData, Settings.Debug);
            //NormalSpriteDef.PreventPending = !(isBaseRom && !RecordGuide.HasBaseData);

            // get static data
            if (!File.Exists(Settings.StaticDescriptorSource) && isBaseRom)
            {
                // load all static data
                OrbitalBasisHandler.LoadDescriptors();
                StaticDescriptor.SaveDescriptors(Settings.StaticDescriptorSource);
                Globals.HasStaticData = true;
            }
            else
            {
                StaticDescriptor.LoadDescriptors(Settings.StaticDescriptorSource);
                Globals.HasStaticData = false;
            }
        }

        static private void OnLoadUnits()
        {

        }
        static private void SaveBaseRomData()
        {
        }
    }
}
