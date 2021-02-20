using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheBees.Sprites
{
    static class SpriteMap
    {
        static public void UpdateSpriteDefPointer(NormalSpriteDef def, uint newAddress)
        {
            List<int> indexes = NormalSpriteDef.PointerIndexes[def.Address];

            foreach (int index in indexes)
            {
                RomData.Set32((uint)index * SpriteSpec.SpriteIndexSize + SpriteSpec.SpriteDefOffset + 4, newAddress);
            }
        }

        static public void UpdateSpriteDefPointer(int index, uint newAddress)
        {
            RomData.Set32((uint)index * SpriteSpec.SpriteIndexSize + SpriteSpec.SpriteDefOffset + 4, newAddress);
        }

        static public uint GetSpriteAddress(int index)
        {
            return RomData.Get32((uint)index * SpriteSpec.SpriteIndexSize + SpriteSpec.SpriteDefOffset + 4);
        }

        static public void UpdateSpriteAxis(int index, short xPos, short yPos)
        {
            RomData.Set16((uint)index * SpriteSpec.SpriteIndexSize + SpriteSpec.SpriteDefOffset, (ushort)xPos);
            RomData.Set16((uint)index * SpriteSpec.SpriteIndexSize + SpriteSpec.SpriteDefOffset + 2, (ushort)yPos);
        }

        static public void UpdateSpriteAxis(NormalSpriteDef def, short xPos, short yPos)
        {
            foreach (int index in NormalSpriteDef.PointerIndexes[def.Address])
            {
                UpdateSpriteAxis(index, xPos, yPos);
            }
        }
    }
}
