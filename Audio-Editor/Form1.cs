using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Windows.Media;
using NAudio;
using NAudio.Utils;
using NAudio.Wave;

namespace Audio_Editor
{
    public partial class Form1 : Form
    {
        public MediaPlayer player = new MediaPlayer();
        public Mp3FileReader reader;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog open_dialog = new OpenFileDialog();
            if (open_dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    player.Open(new Uri(open_dialog.FileName));
                    reader = new Mp3FileReader(open_dialog.FileName);

                }
                catch
                {
                    DialogResult result = MessageBox.Show("Невозможно открыть выбранный файл",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void SaveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                using (var rdr = reader)
                using (var waveFileWriter = new WaveFileWriter(sfd.FileName, rdr.WaveFormat))
                {
                    byte[] buffer = new byte[rdr.WaveFormat.AverageBytesPerSecond];
                    int read;
                    while ((read = rdr.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        waveFileWriter.Write(buffer, 0, read);
                    }
                }
            }
        }

        //public static class WavFileUtils
        //{
        //    public static void TrimWavFile(string inPath, string outPath, TimeSpan cutFromStart, TimeSpan cutFromEnd)
        //    {
        //        using (NAudio.Wave.WaveFileReader reader = new NAudio.Wave.WaveFileReader(inPath))
        //        {
        //            using (NAudio.Wave.WaveFileWriter writer = new NAudio.Wave.WaveFileWriter(outPath, reader.WaveFormat))
        //            {
        //                int bytesPerMillisecond = reader.WaveFormat.AverageBytesPerSecond / 1000;

        //                int startPos = (int)cutFromStart.TotalMilliseconds * bytesPerMillisecond;
        //                startPos = startPos - startPos % reader.WaveFormat.BlockAlign;

        //                int endBytes = (int)cutFromEnd.TotalMilliseconds * bytesPerMillisecond;
        //                endBytes = endBytes - endBytes % reader.WaveFormat.BlockAlign;
        //                int endPos = (int)reader.Length - endBytes;

        //                TrimWavFile(reader, writer, startPos, endPos);
        //            }
        //        }
        //    }

        //    private static void TrimWavFile(NAudio.Wave.WaveFileReader reader, NAudio.Wave.WaveFileWriter writer, 
        //        int startPos, int endPos)
        //    {
        //        reader.Position = startPos;
        //        byte[] buffer = new byte[1024];
        //        while (reader.Position < endPos)
        //        {
        //            int bytesRequired = (int)(endPos - reader.Position);
        //            if (bytesRequired > 0)
        //            {
        //                int bytesToRead = Math.Min(bytesRequired, buffer.Length);
        //                int bytesRead = reader.Read(buffer, 0, bytesToRead);
        //                if (bytesRead > 0)
        //                {
        //                    writer.WriteData(buffer, 0, bytesRead);
        //                }
        //            }
        //        }
        //    }
        //}

        private void PlayButton_Click(object sender, EventArgs e)
        {
            player.Play();
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            player.Pause();
        }
    }
}
