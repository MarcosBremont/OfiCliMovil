using OfiCliMovil.Models;
using OfiCliMovil.Models.Entidad;
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
        EClienteFull eClienteFull = new EClienteFull();
        ApiOrdenServicio apiOrdenServicio = new ApiOrdenServicio();

        public DashboardPage()
        {
            InitializeComponent();
        }

        private async void btnPendiente_Clicked(object sender, EventArgs e)
        {
            App.HamburgerMenu.Detail = new NavigationPage(new BalancePendiente());
        }

        private async void btnUltimoPago_Clicked(object sender, EventArgs e)
        {
            App.HamburgerMenu.Detail = new NavigationPage(new BalancePendiente());

        }


        protected async override void OnAppearing()
        {
            await CargarCantidades();
            base.OnAppearing();
        }

        public async Task CargarCantidades()
        {
            try
            {
                var apiResult = await apiOrdenServicio.IniciarSesion(App.Cedula, App.Clave);
                lblNombreUsuario.Text = apiResult.codigo_cli +" - "+  apiResult.nombre_cli;
                btnCuotaMensual.Text = "$" + apiResult.cuota.ToString() + "\n Cuota Mensual";
                btnPendiente.Text = "$" + apiResult.balance.ToString() + "\n Balance Pendiente";
                btnUltimoPago.Text = $"{apiResult.fechaultimopago.ToString("dd/MM/yyyy")}\n${apiResult.montoultimopago.ToString()}\nUltimo Pago";
                btnEstado.Text = "Estado \n" +  apiResult.estado.ToString();
                btnFinServicio.Text = "Fin de servicio \n" + apiResult.fechafinservicio.ToString("dd/MM/yyyy");
                btnPendiente.Text = "$" + apiResult.balance.ToString() + "\n Balance Pendiente";

            }
            catch (Exception ex)
            {
                await DisplayAlert("No se pudo establecer la conexión", "por favor verifique su conexion a internet", "OK");
            }

        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}