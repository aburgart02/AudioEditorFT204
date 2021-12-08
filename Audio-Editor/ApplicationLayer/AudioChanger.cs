using System;
using Audio_Editor.Infrastructure;


namespace Audio_Editor.ApplicationLayer
{
    public interface IAudioChanger
    {
        void CutFile(TimeSpan start, TimeSpan end);
    }

    public class AudioChanger : IAudioChanger
    {
        public void CutFile(TimeSpan start, TimeSpan end)
        {
            Domain.CutAudio.TrimWavFile(start, end);
        }

        public void ReverseFile()
        {
            Domain.ReverseAudio.Start(Globals.path);
        }
    }
}
