using System;
using Domain;
using NAudio.Wave;
using Infrastructure;


namespace ApplicationLayer
{
    public interface IAudioChanger
    {
        Data CutFile(TimeSpan start, TimeSpan end);
    }

    public class AudioChanger : IAudioChanger
    {
        private Data data;
        private ReverseAudioFileInteraction fileInteraction;
        private ReverseAudioArrays arraysInteraction;
        private ReverseAudioMetadata reverseMetadata;

        public AudioChanger(Data data)
        {
            this.data = data;
            fileInteraction = new ReverseAudioFileInteraction();
            arraysInteraction = new ReverseAudioArrays();
            reverseMetadata = new ReverseAudioMetadata();
        }

        public Data CutFile(TimeSpan start, TimeSpan end)
        {
            var fileWriter = new WaveFileWriter(Environment.CurrentDirectory + @"\temp" + data.index + data.extension, 
                data.reader.WaveFormat);
            return new CutAudio(data).TrimWavFile(start, end, fileWriter);
        }

        public Data ReverseFile()
        {
            return new ReverseAudio(fileInteraction, arraysInteraction, reverseMetadata, data).Start();
        }
    }
}
