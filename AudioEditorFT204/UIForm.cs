using System;
using System.Windows.Forms;
using Infrastructure;
using ApplicationLayer;
using System.Windows.Media;

namespace UIForm
{
    public partial class UI : Form
    {
        private Data data;
        private MediaPlayer player;

        public UI()
        {
            InitializeComponent();
            player = new MediaPlayer();
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
            {
                player.Open(new Uri(open_dialog.FileName));
                data = opener.Open(open_dialog.FileName);
            }
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
    }
}