using System;
using System.Windows.Forms;
using ApplicationLayer;

namespace UIForm
{
    public partial class UI : Form
    {
        private void CutAudio_Click(object sender, EventArgs e)
        {
            var time = Convert.ToInt32(textBox1.Text);
            data = audioChanger.CutFile(new TimeSpan(0, 0, time), new TimeSpan(0, 0, 0), data);
            player.Open(new Uri(Environment.CurrentDirectory + @"\temp" + (data.index - 1) + data.extension));
        }

        private void ReverseButton_Click(object sender, EventArgs e)
        {
            data = audioChanger.ReverseFile(data);
            player.Open(new Uri(Environment.CurrentDirectory + @"\temp" + (data.index - 1) + data.extension));
        }

        private void Mp3ToWavButton_Click(object sender, EventArgs e)
        {
            data = mp3ToWavConverter.Convert(data);
            player.Open(new Uri(Environment.CurrentDirectory + @"\temp" + (data.index - 1) + data.extension));
        }

        private void WavToMp3Button_Click(object sender, EventArgs e)
        {
            data = wavToMp3Converter.Convert(data);
            player.Open(new Uri(Environment.CurrentDirectory + @"\temp" + (data.index - 1) + data.extension));
        }
    }
}