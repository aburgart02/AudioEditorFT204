using System.Windows.Media;
using NAudio.Wave;

namespace Infrastructure
{
    public class Data
    {
        public MediaPlayer player;
        public MediaFoundationReader reader;
        public string path;
        public int index;
        public string extension;

        public Data()
        {
            player = new MediaPlayer();
        }
    }
}
