using System;
using System.Windows.Forms;

namespace UIForm
{
    public partial class UI : Form
    {
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

        private void IncreaseVolumeButton_Click(object sender, EventArgs e) =>
            player.Volume += 0.05;

        private void DecreaseVolumeButton_Click(object sender, EventArgs e) =>
            player.Volume -= 0.05;
    }
}