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
using NAudio.WaveFormRenderer;
using System.Drawing.Imaging;
using WaveFileManipulator;
using TestWavPlayer;

namespace Audio_Editor
{
    public partial class Form1 : Form
    {
        public MediaPlayer player = new MediaPlayer();
        public MediaFoundationReader reader;
        public string path;
        public int index = 0;

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
                    path = open_dialog.FileName;
                    reader = new MediaFoundationReader(open_dialog.FileName);
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
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (var rdr = reader)
                using (var waveFileWriter = new WaveFileWriter(sfd.FileName, rdr.WaveFormat))
                {
                    MediaFoundationReader[] tracks = new MediaFoundationReader[Convert.ToInt32(LoopCountValue.Text)];
                    for (var i = 0; i < Convert.ToInt32(LoopCountValue.Text); i++)
                        tracks[i] = new MediaFoundationReader(path);
                    byte[] buffer = new byte[rdr.WaveFormat.AverageBytesPerSecond];
                    int read;
                    foreach (var track in tracks)
                    {
                        while ((read = track.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            waveFileWriter.Write(buffer, 0, read);
                        }
                    }
                }
            }
        }

        public void TrimWavFile(TimeSpan cutFromStart, TimeSpan cutFromEnd)
        {
            using (var rdr = reader)
            {
                using (var writer = new WaveFileWriter(
                    Environment.CurrentDirectory + @"\temp" + index + ".wav", rdr.WaveFormat))
                {
                    int bytesPerMillisecond = rdr.WaveFormat.AverageBytesPerSecond / 1000;
                    int startPos = (int)cutFromStart.TotalMilliseconds * bytesPerMillisecond;
                    startPos = startPos - startPos % rdr.WaveFormat.BlockAlign;
                    int endBytes = (int)cutFromEnd.TotalMilliseconds * bytesPerMillisecond;
                    endBytes = endBytes - endBytes % rdr.WaveFormat.BlockAlign;
                    int endPos = (int)rdr.Length - endBytes;
                    TrimWavFile(rdr, writer, startPos, endPos);
                }
            }
            reader = new MediaFoundationReader(Environment.CurrentDirectory + @"\temp" + index + ".wav");
            player.Open(new Uri(Environment.CurrentDirectory + @"\temp" + index + ".wav"));
            index += 1;
        }

        public void TrimWavFile(MediaFoundationReader reader, WaveFileWriter writer,
            int startPos, int endPos)
        {
            reader.Position = startPos;
            byte[] buffer = new byte[1024];
            while (reader.Position < endPos)
            {
                int bytesRequired = (int)(endPos - reader.Position);
                if (bytesRequired > 0)
                {
                    int bytesToRead = Math.Min(bytesRequired, buffer.Length);
                    int bytesRead = reader.Read(buffer, 0, bytesToRead);
                    if (bytesRead > 0)
                    {
                        writer.Write(buffer, 0, bytesRead);
                    }
                }
            }
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            if (CycleCheckBox.Checked)
                player.MediaEnded += new EventHandler(Media_Ended);
            player.Position = TimeSpan.Zero;
            player.Play();
        }

        private void Media_Ended(object sender, EventArgs e)
        {
            player.Position = TimeSpan.Zero;
            player.Play();
        }

        private void PauseButton_Click(object sender, EventArgs e) => player.Pause();

        private void CutAudio_Click(object sender, EventArgs e)
        {
            var time = Convert.ToInt32(textBox1.Text);
            TrimWavFile(new TimeSpan(0, 0, time), new TimeSpan(0, 0, 0));
        }

        private void IncreaseVolumeButton_Click(object sender, EventArgs e) => player.Volume += 0.05;

        private void DecreaseVolumeButton_Click(object sender, EventArgs e) => player.Volume -= 0.05;

        private void SoundWaveButton_Click(object sender, EventArgs e)
        {
            int sampleSize = 1024;
            var bufferSize = 16384 * sampleSize;
            var buffer = new byte[bufferSize];
            int read = 0;
            chart1.Series.Add("wave");
            chart1.Series["wave"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            chart1.Series["wave"].ChartArea = "ChartArea1";
            using (var inputStream = reader)
            {
                using (var wave = new WaveChannel32(inputStream))
                {
                    while (wave.Position < wave.Length)
                    {
                        read = wave.Read(buffer, 0, bufferSize);
                        for (int i = 0; i < read / sampleSize; i++)
                        {
                            var point = BitConverter.ToSingle(buffer, i * sampleSize);
                            chart1.Series["wave"].Points.Add(point);
                        }
                    }
                }
            }
            pictureBox1.Hide();
            chart1.Show();
        }

        private void VolumeLevelDiagramButton_Click(object sender, EventArgs e)
        {
            MaxPeakProvider maxPeakProvider = new MaxPeakProvider();
            RmsPeakProvider rmsPeakProvider = new RmsPeakProvider(200);
            SamplingPeakProvider samplingPeakProvider = new SamplingPeakProvider(200);
            AveragePeakProvider averagePeakProvider = new AveragePeakProvider(4);
            StandardWaveFormRendererSettings myRendererSettings = new StandardWaveFormRendererSettings();
            myRendererSettings.Width = 1080;
            myRendererSettings.TopHeight = 64;
            myRendererSettings.BottomHeight = 64;
            WaveFormRenderer renderer = new WaveFormRenderer();
            var image = renderer.Render(reader, averagePeakProvider, myRendererSettings);
            image.Save(@"C:\Users\artem_000\Desktop\AudioEditorFT204-main\test.png", ImageFormat.Png);
            pictureBox1.Load(@"C:\Users\artem_000\Desktop\AudioEditorFT204-main\test.png");
            pictureBox1.Show();
            chart1.Hide();
        }

        private void ReverseButton_Click(object sender, EventArgs e)
        {
            var reverser = new ReverserProgram();
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                reverser.Start(path, sfd.FileName);
            }
        }
    }
}