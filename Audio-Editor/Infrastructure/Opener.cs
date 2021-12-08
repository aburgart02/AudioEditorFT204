using System;
using System.Windows.Forms;
using System.Windows.Media;
using NAudio.Wave;


namespace Audio_Editor.Infrastructure
{
    public interface IOpener
    {
        void Open(OpenFileDialog open_dialog);
    }

    class Opener : IOpener
    {
        public void Open(OpenFileDialog open_dialog)
        {
            if (open_dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Globals.player = new MediaPlayer();
                    Globals.player.Open(new Uri(open_dialog.FileName));
                    Globals.path = open_dialog.FileName;
                    Globals.reader = new MediaFoundationReader(open_dialog.FileName);
                }
                catch
                {
                    DialogResult result = MessageBox.Show("Невозможно открыть выбранный файл",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
