using System;
using Domain;
using NAudio.Wave;
using Infrastructure;


namespace ApplicationLayer
{
    public interface IAudioChanger
    {
        void CutFile(TimeSpan start, TimeSpan end, Data data);
    }

    public class AudioChanger : IAudioChanger
    {
        public void CutFile(TimeSpan start, TimeSpan end, Data data)
        {
            var fileWriter = new WaveFileWriter(Environment.CurrentDirectory + @"\temp" + data.index + data.extension, data.reader.WaveFormat);
            CutAudio.TrimWavFile(start, end, data, fileWriter);
        }

        public void ReverseFile(Data data)
        {
            ReverseAudio.Start(data);
        }
    }
}
