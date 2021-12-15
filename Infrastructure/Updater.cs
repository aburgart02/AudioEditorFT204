using System;
using NAudio.Wave;

namespace Infrastructure
{
    public interface IUpdater
    {
        Data UpdateAudio(Data data);
    }

    public class Updater : IUpdater
    {
        public Data UpdateAudio(Data data)
        {
            return new Data(new MediaFoundationReader(Environment.CurrentDirectory + @"\temp" + data.index + data.extension),
                Environment.CurrentDirectory + @"\temp" + data.index + data.extension,
                data.index + 1, data.extension);
        }
    }
}
