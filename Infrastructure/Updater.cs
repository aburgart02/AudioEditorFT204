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
                new MediaFoundationReader(Environment.CurrentDirectory + @"\temp" + data.index + data.extension);
            data.player.Open(new Uri(Environment.CurrentDirectory + @"\temp" + data.index + data.extension));
            data.path = Environment.CurrentDirectory + @"\temp" + data.index + data.extension;
            data.index += 1;
        }
    }
}
