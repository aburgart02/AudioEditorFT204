using System;
using System.Windows.Forms;
using NAudio.Wave;
using NAudio.WaveFormRenderer;
using System.Drawing.Imaging;
using Audio_Editor.Infrastructure;
using Audio_Editor.ApplicationLayer;

namespace Audio_Editor
{
    public partial class UI : Form
    {
        public UI()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog open_dialog = new OpenFileDialog();
            var opener = new Opener();
            opener.Open(open_dialog);
        }

        public void SaveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            var saver = new Saver();
            var loopCount = LoopCountValue.Text;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (loopCount == "")
                    saver.SaveTrack(sfd, 1);
                else
                    saver.SaveTrack(sfd, Convert.ToInt32(loopCount));
            }
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            if (CycleCheckBox.Checked)
                Globals.player.MediaEnded += new EventHandler(Media_Ended);
            Globals.player.Position = TimeSpan.Zero;
            Globals.player.Play();
        }

        private void Media_Ended(object sender, EventArgs e)
        {
            Globals.player.Position = TimeSpan.Zero;
            Globals.player.Play();
        }

        private void PauseButton_Click(object sender, EventArgs e) => Globals.player.Pause();

        private void CutAudio_Click(object sender, EventArgs e)
        {
            var time = Convert.ToInt32(textBox1.Text);
            var audioChanger = new AudioChanger();
            audioChanger.CutFile(new TimeSpan(0, 0, time), new TimeSpan(0, 0, 0));
        }

        private void IncreaseVolumeButton_Click(object sender, EventArgs e) => 
            Globals.player.Volume += 0.05;

        private void DecreaseVolumeButton_Click(object sender, EventArgs e) => 
            Globals.player.Volume -= 0.05;

        private void SoundWaveButton_Click(object sender, EventArgs e)
        {
            int sampleSize = 1024;
            var bufferSize = 16384 * sampleSize;
            var buffer = new byte[bufferSize];
            int read = 0;
            chart1.Series.Add("wave");
            chart1.Series["wave"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            chart1.Series["wave"].ChartArea = "ChartArea1";
            using (var inputStream = Globals.reader)
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
            AveragePeakProvider averagePeakProvider = new AveragePeakProvider(4);
            StandardWaveFormRendererSettings myRendererSettings = new StandardWaveFormRendererSettings();
            myRendererSettings.Width = 1080;
            myRendererSettings.TopHeight = 64;
            myRendererSettings.BottomHeight = 64;
            WaveFormRenderer renderer = new WaveFormRenderer();
            var image = renderer.Render(Globals.reader, averagePeakProvider, myRendererSettings);
            image.Save(@"B:\CreatingGames\AudioEditorFT204\test.png", ImageFormat.Png);
            pictureBox1.Load(@"B:\CreatingGames\AudioEditorFT204\test.png");
            pictureBox1.Show();
            chart1.Hide();
        }

        private void ReverseButton_Click(object sender, EventArgs e)
        {
            var audioChanger = new AudioChanger();
            audioChanger.ReverseFile();
        }

        private void Mp3ToWavButton_Click(object sender, EventArgs e)
        {
            var formatConverter = new FormatConverter();
            formatConverter.ConvertMp3ToWav();
        }
    }
}