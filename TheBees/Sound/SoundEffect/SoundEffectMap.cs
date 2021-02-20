using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TheBees.Sound;

namespace TheBees.Sound
{
    static public class SoundEffectMap
    {
        static private SoundEffectGroup mainGroup;
        static public SoundEffectGroup MainGroup { get { return mainGroup; } }
        static public void LoadSoundEffectGroup()
        {
            mainGroup = SoundEffectGroup.GetRecordable(SampleSpec.SoundEffectRegion);
        }
    }
}
