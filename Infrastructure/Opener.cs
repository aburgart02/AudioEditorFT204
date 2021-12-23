using System;
using System.IO;
using NAudio.Wave;


namespace Infrastructure
{
    public interface IOpener
    {
        Data Open(string path);
    }

    public class Opener : IOpener
    {
        public Data Open(string path)
        {
            return new Data(path, 0, Path.GetExtension(path));
        }
    }
}
