using ApplicationLayer;
using Ninject;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Media;
using UIForm;
using Domain;
using Infrastructure;

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
            ninjectKernel.Bind<Opener>().To<Opener>();
            ninjectKernel.Bind<Saver>().To<Saver>();
            ninjectKernel.Bind<CutAudio>().To<CutAudio>();
            ninjectKernel.Bind<ReverseAudio>().To<ReverseAudio>();
            ninjectKernel.Bind<Converter>().To<Converter>();
            var form = ninjectKernel.Get<UI>();
            Application.Run(form);
        }
    }
}
