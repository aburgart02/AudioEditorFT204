using System;
using System.Windows.Forms;
using NAudio.Wave;
using NAudio.WaveFormRenderer;

namespace UIForm
{
    public partial class UI : Form
    {
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
    }
}