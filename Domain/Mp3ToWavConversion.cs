using System;
using Infrastructure;
using NAudio.Wave;

namespace Domain
{
    public class Mp3ToWavConversion
    {
        private Data data;

        public Mp3ToWavConversion(Data data)
        {
            this.data = data;
        }

        public Data ConvertMp3ToWav()
        {
            using (var rdr = data.reader)
            {
                WaveFileWriter.CreateWaveFile(Environment.CurrentDirectory + @"\temp" + data.index + ".wav", rdr);
            }
            data.extension = ".wav";
            var updater = new Updater();
            return updater.UpdateAudio(data);
        }
    }
}
