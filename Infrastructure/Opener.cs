using System;
using System.Windows.Forms;
using System.Windows.Media;
using NAudio.Wave;


namespace Infrastructure
{
    public interface IOpener
    {
        void Open(OpenFileDialog open_dialog, Data data);
    }

    public class Opener : IOpener
    {
        public void Open(OpenFileDialog open_dialog, Data data)
        {
            data.player.Open(new Uri(open_dialog.FileName));
            data.path = open_dialog.FileName;
            data.reader = new MediaFoundationReader(open_dialog.FileName);
        }
    }
}
