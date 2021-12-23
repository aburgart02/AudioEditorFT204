using System;
using Domain;
using System.Windows.Forms;
using Infrastructure;
using ApplicationLayer;
using System.Windows.Media;

namespace UIForm
{
    public partial class UI : Form
    {
        private Data data;
        private readonly MediaPlayer player;
        private readonly AudioChanger audioChanger;
        private readonly Opener opener;
        private readonly Saver saver;
        private readonly CutAudio cutAudio;
        private readonly ReverseAudio reverseAudio;
        private readonly Converter converter;
        private readonly Mp3ToWavConverter mp3ToWavConverter;
        private readonly WavToMp3Converter wavToMp3Converter;

        public UI(MediaPlayer player, AudioChanger audioChanger, Mp3ToWavConverter mp3ToWavConverter, 
            WavToMp3Converter wavToMp3Converter, Opener opener, Saver saver, CutAudio cutAudio, 
            ReverseAudio reverseAudio, Converter converter)
        {
            InitializeComponent();
            this.player = player;
            this.audioChanger = audioChanger;
            this.opener = opener;
            this.saver = saver;
            this.reverseAudio = reverseAudio;
            this.cutAudio = cutAudio;
            this.converter = converter;
            this.mp3ToWavConverter = mp3ToWavConverter;
            this.wavToMp3Converter = wavToMp3Converter;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Hide();
            chart1.Hide();
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog open_dialog = new OpenFileDialog();
            if (open_dialog.ShowDialog() == DialogResult.OK)
            {
                player.Open(new Uri(open_dialog.FileName));
                data = opener.Open(open_dialog.FileName);
            }
        }

        public void SaveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            var loopCount = LoopCountValue.Text;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (loopCount == "")
                    saver.SaveTrack(sfd.FileName, 1, data);
                else
                    saver.SaveTrack(sfd.FileName, Convert.ToInt32(loopCount), data);
            }
        }
    }
}