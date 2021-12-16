using ApplicationLayer;
using Ninject;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Media;
using UIForm;

namespace MainProgram
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            IKernel ninjectKernel = new StandardKernel();
            ninjectKernel.Bind<UI>().To<UI>();
            ninjectKernel.Bind<MediaPlayer>().To<MediaPlayer>();
            ninjectKernel.Bind<AudioChanger>().To<AudioChanger>();
            ninjectKernel.Bind<Mp3ToWavConverter>().To<Mp3ToWavConverter>();
            ninjectKernel.Bind<WavToMp3Converter>().To<WavToMp3Converter>();
            var form = ninjectKernel.Get<UI>();
            Application.Run(form);
        }
    }
}
