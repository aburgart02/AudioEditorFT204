using System;
using Audio_Editor.Infrastructure;
using NAudio.Wave;

namespace Audio_Editor.Domain
{
    class Mp3ToWavConversion
    {
        public static void ConvertMp3ToWav()
        {
            using (var rdr = Globals.reader)
            {
                WaveFileWriter.CreateWaveFile(Environment.CurrentDirectory + @"\temp" + Globals.index + ".wav", rdr);
            }
            var updater = new Updater();
            updater.UpdateAudio();
        }
    }
}
