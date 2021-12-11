using System;
using NAudio.Wave;

namespace Infrastructure
{
    public interface IUpdater
    {
        void UpdateAudio(Data data);
    }

    public class Updater : IUpdater
    {
        public void UpdateAudio(Data data)
        {
            data.reader =
                new MediaFoundationReader(Environment.CurrentDirectory + @"\temp" + data.index + ".wav");
            data.player.Open(new Uri(Environment.CurrentDirectory + @"\temp" + data.index + ".wav"));
            data.path = Environment.CurrentDirectory + @"\temp" + data.index + ".wav";
            data.index += 1;
        }
    }
}
