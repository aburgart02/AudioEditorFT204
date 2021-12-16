using System;
using Domain;
using NAudio.Wave;
using Infrastructure;


namespace ApplicationLayer
{
    public interface IAudioChanger
    {
        Data CutFile(TimeSpan start, TimeSpan end, Data data);
    }

    public class AudioChanger : IAudioChanger
    {
        private ReverseAudioFileInteraction fileInteraction;
        private ReverseAudioArrays arraysInteraction;
        private ReverseAudioMetadata reverseMetadata;

        public AudioChanger()
        {
            fileInteraction = new ReverseAudioFileInteraction();
            arraysInteraction = new ReverseAudioArrays();
            reverseMetadata = new ReverseAudioMetadata();
        }

        public Data CutFile(TimeSpan start, TimeSpan end, Data data)
        {
            var fileWriter = new WaveFileWriter(Environment.CurrentDirectory + @"\temp" + data.index + data.extension, 
                new MediaFoundationReader(data.path).WaveFormat);
            return new CutAudio().TrimWavFile(start, end, fileWriter, data);
        }

        public Data ReverseFile(Data data)
        {
            return new ReverseAudio(fileInteraction, arraysInteraction, reverseMetadata).Start(data);
        }
    }
}
