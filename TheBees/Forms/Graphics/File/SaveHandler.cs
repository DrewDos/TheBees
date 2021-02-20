using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TheBees.Records;
using TheBees.Description;

namespace TheBees
{
    static class SaveHandler
    {
        static public event Action OnSaveRom;
        static public event Action BeforeSaveEvent;

        static public void SaveRom(string source, RomType type)
        {
            if (BeforeSaveEvent != null)
                BeforeSaveEvent();

            // save the rom
            RomData.SaveRomData(source, type);

            // save the records data
            //RecordFile.SaveRecords(Settings.RecordsSource);

            // save the descriptions
            DescriptionFile.Save(Settings.DescriptionSource);

            if (OnSaveRom != null)
                OnSaveRom();
        }
    }
}
