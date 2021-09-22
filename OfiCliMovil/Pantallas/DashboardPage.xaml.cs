using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OfiCliMovil.Pantallas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashboardPage : ContentPage
    {
        public DashboardPage()
        {
            InitializeComponent();
        }

        private async void btnPendiente_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new BalancePendiente());
        }

        private async void btnUltimoPago_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new BalancePendiente());

        }
    }
}