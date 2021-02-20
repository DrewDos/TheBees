using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace TheBees.Sound
{
    class Wav
    {
        private WavHeader header;
        private byte[] data;

        public Wav(byte[] sourceData)
        {
            data = sourceData;
            header = new WavHeader(sourceData);
        }
        public void SaveRaw(string target)
        {
            BinaryWriter w = new BinaryWriter(File.Open(target, FileMode.Create));
            //header.WriteHeader(w);
            w.Write(data);
            w.Close();
        }
        public void SaveWav(string target)
        {
            BinaryWriter w = new BinaryWriter(File.Open(target, FileMode.Create));
            header.WriteHeader(w);
            w.Write(data);
            w.Close();
        }
    }

    class WavHeader
    {
        private const uint chunkID = 0x46464952; // RIFF in ascii

        private uint chunkSize;
        private const uint format = 0x45564157; // WAVE
        private uint subChunk1ID = 0x20746D66; // "fmt "
        private uint subChunk1Size;
        private ushort audioFormat;
        private ushort numChannels;
        private uint sampleRate;
        private uint byteRate;
        private ushort blockAlign;
        private ushort bitsPerSample;
        // private ushort extraParamSize;
        private const uint subChunk2ID = 0x61746164;
        private uint subChunk2Size;

        public WavHeader(byte[] sourceData)
        {
            PrepHeader(sourceData);
        }

        private void PrepHeader(byte[] sourceData)
        {
            // creates a basic header
            // just for 3rd strike samples for now

            // 1 = pcm
            audioFormat = 1;
            // mono for this game
            numChannels = 1;
            // 12000 test for now
            sampleRate = 12000;

            bitsPerSample = 8;

            byteRate = sampleRate * numChannels * bitsPerSample / 8;
            blockAlign = (ushort)(numChannels * bitsPerSample / 8);

            uint dataLength = (uint)sourceData.Length;
            int numSamples = (int)(dataLength * 8 * numChannels / bitsPerSample);

            // 16 is for pcm
            subChunk1Size = 16;
            subChunk2Size = (uint)numSamples * numChannels * bitsPerSample / 8;
            chunkSize = 36 + subChunk2Size;
        }

        public void WriteHeader(BinaryWriter w)
        {
            w.Write(chunkID);
            w.Write(chunkSize);
            w.Write(format);
            w.Write(subChunk1ID);
            w.Write(subChunk1Size);
            w.Write(audioFormat);
            w.Write(numChannels);
            w.Write(sampleRate);
            w.Write(byteRate);
            w.Write(blockAlign);
            w.Write(bitsPerSample);
            w.Write(subChunk2ID);
            w.Write(subChunk2Size);
        }
    }
}