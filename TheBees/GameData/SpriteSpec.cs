using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheBees.Sprites
{
    static class SpriteSpec
    {
        public const uint MaxSpriteIndex = (0x80000 / 8);
        public const uint SpriteDefOffset = 0x6800000;
        public const uint SpriteIndexSize = 0x08;
    }
        
}
