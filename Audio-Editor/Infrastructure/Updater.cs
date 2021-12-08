using System;
using NAudio.Wave;

namespace Audio_Editor.Infrastructure
{
    public interface IUpdater
    {
        void UpdateAudio();
    }

    class Updater : IUpdater
    {
        public void UpdateAudio()
        {
            Globals.reader =
                new MediaFoundationReader(Environment.CurrentDirectory + @"\temp" + Globals.index + ".wav");
            Globals.player.Open(new Uri(Environment.CurrentDirectory + @"\temp" + Globals.index + ".wav"));
            Globals.path = Environment.CurrentDirectory + @"\temp" + Globals.index + ".wav";
            Globals.index += 1;
        }
    }
}
