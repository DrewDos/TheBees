using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TheBees.Records;
using TheBees.Data;
using TheBees.User;

namespace TheBees.Sound
{
    public class SoundEffectGroup : Recordable
    {
        static public event Action<int> LoadSoundEffectComplete;
        private List<SoundEffect> soundEffects;

        private ushort count;
        private ushort unknownValue;
        private int size;

        public override bool MaintainData
        {
            get { return true; }
        }
        public SoundEffectGroup(uint address)
            : base(address, true)
        {
            LoadSoundEffects();
        }

        static public SoundEffectGroup GetRecordable(uint address)
        {
            if (!MasterList.ContainsKey(address))
            {
                SoundEffectGroup newGroup = new SoundEffectGroup(address);

                if (creatingBaseRecords) newGroup.InitializeRecord();

                MasterList[address] = newGroup;
            }

            return (SoundEffectGroup)MasterList[address];
        }

        public uint[] GetValidIndexes()
        {
            List<uint> validIndexes = new List<uint>();

            for (int i = 0; i < soundEffects.Count; i++)
            {
                if (soundEffects[i] != null)
                    validIndexes.Add((uint)i);
            }

            return validIndexes.ToArray();
        }

        public void LoadSoundEffects()
        {
            count = RomData.Get16(address);
            unknownValue = RomData.Get16(address, 2);

            soundEffects = new List<SoundEffect>();

            size += (count * 4) + 4; // sound effect count + unknown + count

            for (int i = 0; i < count; i++)
            {
                uint subAddress = RomData.Get32(address + (uint)((i * 4) + 4));
                
                if(subAddress == 0x00)
                {
                    soundEffects.Add(null);
                        
                }
                else
                {
                    SoundEffect newSoundEffect = new SoundEffect(subAddress + address);
                    soundEffects.Add(newSoundEffect);
                    if (LoadSoundEffectComplete != null) LoadSoundEffectComplete(i);
                    size += newSoundEffect.SizeInBytes;
                }
            }

        }

        public SoundEffect GetSoundEffect(int index)
        {
            return soundEffects[index];
        }

        private void UpdateSoundEffectPointers()
        {
            for (int i = 0; i < count; i++)
            {
                SoundEffect currEffect = soundEffects[i];

                uint finalAddress = 0x00;
                if (currEffect != null)
                    finalAddress = currEffect.Address - SampleSpec.SoundEffectRegion;

                RomData.Set32(address+ (uint)((i * 4) + 4), finalAddress);

            }
        }

        protected override RecordSpaceGroup spaceGroup
        {
            get
            {
                return RecordGuide.ProgramSpace;
            }
        }

        public override int SizeInBytes
        {
            get { return size; }
        }
    }
}
