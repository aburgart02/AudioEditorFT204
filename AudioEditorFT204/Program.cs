using Ninject;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
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
            var form = ninjectKernel.Get<UI>();
            Application.Run(form);
        }
    }
}
