using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace OfiCliMovil.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        public DashboardViewModel()
        {
            Title = "Dashboard";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
        }

        public ICommand OpenWebCommand { get; }
    }
}