using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Ejercicio2_4.Modelos;
using System.IO;

namespace Ejercicio2_4
{
    public partial class App : Application
    {
        static bd basedatos;
        public static bd BaseDatos
        {
            get
            {
                if (basedatos == null)
                {
                    basedatos = new bd(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "EmpleDB.db3"));
                }
                return basedatos;
            }
        }


        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
