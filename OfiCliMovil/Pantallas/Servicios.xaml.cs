using OfiCliMovil.Models;
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
            LlenarCable();
            LlenarInternet();
        }


        protected override void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                this.IsBusy = false;
                _= LlenarCable();
                _ = LlenarInternet();
            }
            catch (Exception ex)
            {

            }

        }

        public async Task LlenarCable()
        {
            try
            {
                lsv_Servicio_Cable.IsVisible = false;
                ApiOrdenServicio apiOrdenServicio = new OfiCliMovil.Models.ApiOrdenServicio();
                lsv_Servicio_Cable.ItemsSource = null;

                var datos = await apiOrdenServicio.GetListadoDeEquiposCable(App.Id_Cliente);

                lsv_Servicio_Cable.ItemsSource = datos;
                lsv_Servicio_Cable.IsVisible = true;


            }
            catch (Exception ex)
            {

            }
        }

        public async Task LlenarInternet()
        {
            try
            {
                lsv_Servicio_Internet.IsVisible = false;
                ApiOrdenServicio apiOrdenServicio = new OfiCliMovil.Models.ApiOrdenServicio();
                lsv_Servicio_Internet.ItemsSource = null;

                var datos = await apiOrdenServicio.GetListadoDeEquiposInternet(App.Id_Cliente);

                lsv_Servicio_Internet.ItemsSource = datos;
                lsv_Servicio_Internet.IsVisible = true;


            }
            catch (Exception ex)
            {

            }
        }

        private void VerPlanInternet_Clicked(object sender, EventArgs e)
        {
            //if (FramePlanInternet.IsVisible == false)
            //{
            //    FramePlanInternet.IsVisible = true;
            //}
            //else
            //{
            //    FramePlanInternet.IsVisible = false;
            //}
        }

        private void VerPlanCable_Clicked(object sender, EventArgs e)
        {
            //if (FramePlanCable.IsVisible == false)
            //{
            //    FramePlanCable.IsVisible = true;
            //}
            //else
            //{
            //    FramePlanCable.IsVisible = false;
            //}

        }
    }
}