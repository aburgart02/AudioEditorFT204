using System;
using System.Windows.Forms;
using NAudio.Wave;
using NAudio.WaveFormRenderer;
using System.Drawing.Imaging;
using Infrastructure;
using ApplicationLayer;
using System.IO;

namespace UIForm
{
    public partial class UI : Form
    {
        public Data data;

        public UI()
        {
            InitializeComponent();
            data = new Data();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Hide();
            chart1.Hide();
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog open_dialog = new OpenFileDialog();
            var opener = new Opener();
            if (open_dialog.ShowDialog() == DialogResult.OK)
                opener.Open(open_dialog, data);
        }

        public void SaveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            var saver = new Saver();
            var loopCount = LoopCountValue.Text;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (loopCount == "")
                    saver.SaveTrack(sfd.FileName, 1, data);
                else
                    saver.SaveTrack(sfd.FileName, Convert.ToInt32(loopCount), data);
            }
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            if (CycleCheckBox.Checked)
                data.player.MediaEnded += new EventHandler(Media_Ended);
            data.player.Position = TimeSpan.Zero;
            data.player.Play();
        }

        private void Media_Ended(object sender, EventArgs e)
        {
            data.player.Position = TimeSpan.Zero;
            data.player.Play();
        }

        private void PauseButton_Click(object sender, EventArgs e) => data.player.Pause();

        private void IncreaseVolumeButton_Click(object sender, EventArgs e) =>
            data.player.Volume += 0.05;

        private void DecreaseVolumeButton_Click(object sender, EventArgs e) =>
            data.player.Volume -= 0.05;

        private void CutAudio_Click(object sender, EventArgs e)
        {
            var time = Convert.ToInt32(textBox1.Text);
            var audioChanger = new AudioChanger();
            audioChanger.CutFile(new TimeSpan(0, 0, time), new TimeSpan(0, 0, 0), data);
        }

        private void SoundWaveButton_Click(object sender, EventArgs e)
        {
            int sampleSize = 1024;
            var bufferSize = 16384 * sampleSize;
            var buffer = new byte[bufferSize];
            int read = 0;
            chart1.Series.Clear();
            chart1.Series.Add("Audio Wave");
            chart1.Series["Audio Wave"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            chart1.Series["Audio Wave"].ChartArea = "ChartArea1";
            using (var inputStream = data.reader)
            {
                using (var wave = new WaveChannel32(inputStream))
                {
                    while (wave.Position < wave.Length)
                    {
                        read = wave.Read(buffer, 0, bufferSize);
                        for (int i = 0; i < read / sampleSize; i++)
                        {
                            var point = BitConverter.ToSingle(buffer, i * sampleSize);
                            chart1.Series["Audio Wave"].Points.Add(point);
                        }
                    }
                }
            }
            pictureBox1.Hide();
            chart1.Show();
        }

        private void VolumeLevelDiagramButton_Click(object sender, EventArgs e)
        {
            AveragePeakProvider averagePeakProvider = new AveragePeakProvider(4);
            StandardWaveFormRendererSettings myRendererSettings = new StandardWaveFormRendererSettings();
            myRendererSettings.Width = 1080;
            myRendererSettings.TopHeight = 64;
            myRendererSettings.BottomHeight = 64;
            WaveFormRenderer renderer = new WaveFormRenderer();
            using (var inputStream = data.reader)
            {
                if (!pictureBox1.Visible)
                {
                    var image = renderer.Render(inputStream, averagePeakProvider, myRendererSettings);
                    pictureBox1.Image = image;
                    chart1.Hide();
                    pictureBox1.Show();
                }
            }
        }

        private void ReverseButton_Click(object sender, EventArgs e)
        {
            var audioChanger = new AudioChanger();
            audioChanger.ReverseFile(data);
        }

        private void Mp3ToWavButton_Click(object sender, EventArgs e)
        {
            var formatConverter = new FormatConverter();
            formatConverter.ConvertMp3ToWav(data);
        }

        private void WavToMp3Button_Click(object sender, EventArgs e)
        {
            var formatConverter = new FormatConverter();
            formatConverter.ConvertWavToMp3(data);
        }
    }
}