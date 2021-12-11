using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UIForm;

namespace MainProgram
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var container = new Container();
            container.Register<UI, UI>();
            var uiForm = container.Resolve<UI>();
            Application.Run(uiForm);
        }

        public class Container
        {
            private readonly Dictionary<Type, Type> dict = new Dictionary<Type, Type>();

            public void Register(Type service, Type implementation)
            {
                dict.Add(service, implementation);
            }

            public void Register<T1, T2>() where T2 : T1
            {
                Register(typeof(T1), typeof(T2));
            }

            public object Resolve(Type service)
            {
                var x = dict[service];
                var constructor = x.GetConstructors();
                var parameters = constructor[0].GetParameters();
                var list = new List<object>();
                foreach (var parameter in parameters)
                    list.Add(Resolve(parameter.ParameterType));
                return constructor[0].Invoke(list.ToArray());
            }

            public T Resolve<T>()
            {
                var x = Resolve(typeof(T));
                return (T)x;
            }
        }
    }
}
