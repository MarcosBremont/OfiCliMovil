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
    public partial class Servicios : ContentPage
    {
        public Servicios()
        {
            InitializeComponent();
            FramePlanCable.IsVisible = false;
            FramePlanInternet.IsVisible = false;
        }

        private void VerPlanInternet_Clicked(object sender, EventArgs e)
        {
            if (FramePlanInternet.IsVisible == false)
            {
                FramePlanInternet.IsVisible = true;
            }
            else
            {
                FramePlanInternet.IsVisible = false;
            }
        }

        private void VerPlanCable_Clicked(object sender, EventArgs e)
        {
            if (FramePlanCable.IsVisible == false)
            {
                FramePlanCable.IsVisible = true;
            }
            else
            {
                FramePlanCable.IsVisible = false;
            }

        }
    }
}