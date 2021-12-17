using System;
using Domain;
using NAudio.Wave;
using Infrastructure;


namespace ApplicationLayer
{
    public interface IAudioChanger
    {
        Data CutFile(TimeSpan start, TimeSpan end, Data data, CutAudio cutAudio);
    }

    public class AudioChanger : IAudioChanger
    {
        public Data CutFile(TimeSpan start, TimeSpan end, Data data, CutAudio cutAudio)
        {
            var fileWriter = new WaveFileWriter(Environment.CurrentDirectory + @"\temp" + data.index + data.extension, 
                new MediaFoundationReader(data.path).WaveFormat);
            return cutAudio.TrimWavFile(start, end, fileWriter, data);
        }

        public Data ReverseFile(Data data, ReverseAudio reverseAudio)
        {
            return reverseAudio.Start(data);
        }
    }
}
