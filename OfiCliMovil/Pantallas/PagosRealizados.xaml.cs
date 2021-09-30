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
    public partial class PagosRealizados : ContentPage
    {
        public PagosRealizados()
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
                //lsv_balancependiente.Refreshing += Lsv_balancependiente_Refreshing;
            }
            catch (Exception ex)
            {

            }

        }

        //private void Lsv_balancependiente_Refreshing(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        LlenarBalancePendiente();
        //        lsv_pagos_realizados.IsRefreshing = false;
        //    }
        //    catch (Exception ex)
        //    {

        //    }

        //}


        public async Task LlenarBalancePendiente()
        {
            try
            {
                lsv_pagos_realizados.IsVisible = false;
                ApiOrdenServicio apiOrdenServicio = new OfiCliMovil.Models.ApiOrdenServicio();
                lsv_pagos_realizados.ItemsSource = null;

                var datos = await apiOrdenServicio.GetListadoDePagosRealizados(App.Id_Cliente);

                lsv_pagos_realizados.ItemsSource = datos;
                lsv_pagos_realizados.IsVisible = true;

                txtBalance.Text = string.Format("{0:N2}", datos.Sum(n => n.valor));
                txtcantidad.Text = datos.Count.ToString();

            }
            catch (Exception ex)
            {

            }
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}
