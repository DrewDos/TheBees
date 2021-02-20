using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace TheBees.User
{
    interface IUserMap
    {
        int GuideIndex { get; }
        void SaveData(BinaryWriter w);
        void LoadData(BinaryReader r);
        void LoadBaseData();
        void Clear();
    }
}
