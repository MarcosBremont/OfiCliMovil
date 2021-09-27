using OfiCliMovil.Pantallas;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OfiCliMovil
{
    public partial class App : Application
    {
        public static int Id_Cliente { get; set; }
        public static String Cedula { get; set; }
        public static String Clave { get; set; }
        public App()
        {
            InitializeComponent();
            Device.SetFlags(new[] { "RadioButton_Experimental" });

            MainPage = new Pantallas.LoginPage();
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
