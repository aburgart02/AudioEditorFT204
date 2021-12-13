using System;
using Infrastructure;
using NAudio.Wave;

namespace Domain
{
    public class Mp3ToWavConversion
    {
        public static void ConvertMp3ToWav(Data data)
        {
            using (var rdr = data.reader)
            {
                WaveFileWriter.CreateWaveFile(Environment.CurrentDirectory + @"\temp" + data.index + ".wav", rdr);
            }
            data.extension = ".wav";
            var updater = new Updater();
            updater.UpdateAudio(data);
        }
    }
}
