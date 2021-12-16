using System;
using Infrastructure;
using NAudio.Wave;

namespace Domain
{
    public class Mp3ToWavConversion
    {
        public Data ConvertMp3ToWav(Data data)
        {
            using (var rdr = new MediaFoundationReader(data.path))
            {
                WaveFileWriter.CreateWaveFile(Environment.CurrentDirectory + @"\temp" + data.index + ".wav", rdr);
            }
            data.extension = ".wav";
            var updater = new Updater();
            return updater.UpdateAudio(data);
        }
    }
}
