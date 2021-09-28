using EjemploListView.Modelo;
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
    public partial class HistorialdeOrdenes : ContentPage
    {
        public HistorialdeOrdenes()
        {
            InitializeComponent();
            LlenarBalancePendiente();

        }

        protected override void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                this.IsBusy = false;
                LlenarBalancePendiente();
                lsv_historial_ordenes_pendientes.Refreshing += Lsv_historial_ordenes_pendientes_Refreshing; ;
            }
            catch (Exception ex)
            {

            }

        }

        private void Lsv_historial_ordenes_pendientes_Refreshing(object sender, EventArgs e)
        {
            try
            {
                LlenarBalancePendiente();
                lsv_historial_ordenes_pendientes.IsRefreshing = false;
            }
            catch (Exception ex)
            {

            }
        }


        public async Task LlenarBalancePendiente()
        {
            try
            {
                lsv_historial_ordenes_pendientes.IsVisible = false;
                ApiOrdenServicio apiOrdenServicio = new OfiCliMovil.Models.ApiOrdenServicio();
                lsv_historial_ordenes_pendientes.ItemsSource = null;

                var datos = await apiOrdenServicio.GetHistorialOrdenes(App.Id_Cliente);

                lsv_historial_ordenes_pendientes.ItemsSource = datos;
                lsv_historial_ordenes_pendientes.IsVisible = true;


            }
            catch (Exception ex)
            {

            }
        }



    }
}