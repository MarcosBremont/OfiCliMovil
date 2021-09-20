using OfiCliMovil.Pantallas;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OfiCliMovil
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Device.SetFlags(new[] { "RadioButton_Experimental" });

            MainPage = new Pantallas.HamburgerMenu();
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
