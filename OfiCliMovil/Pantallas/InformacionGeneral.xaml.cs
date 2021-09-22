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
    public partial class InformacionGeneral : ContentPage
    {
        EClienteFull eClienteFull = new EClienteFull();
        ApiOrdenServicio apiOrdenServicio = new ApiOrdenServicio();
        public InformacionGeneral()
        {
            InitializeComponent();
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

                txtcodigo.Text = apiResult.codigo_cli.ToString();
                txtnombrecli.Text = apiResult.nombre_cli.ToString();
                txtcedula.Text = apiResult.cedula.ToString();
                //txttelefono.Text = apiResult.telefono.ToString();
                lblEstado.Text = apiResult.estado.ToString();
                TxtFecha.Text = apiResult.fecha.ToString();
                txtApodo.Text = apiResult.apodo.ToString();
                txtemail.Text = apiResult.email.ToString();
                txtdireccion.Text = apiResult.direccion.ToString();
                txtejecutivo.Text = apiResult.ejecutivo.ToString();
                txtemail.Text = apiResult.email.ToString();
                txtemail.Text = apiResult.email.ToString();
                txtemail.Text = apiResult.email.ToString();
            }
            catch (Exception ex)
            {
                await DisplayAlert("No se pudo establecer la conexión", "por favor verifique su conexion a internet", "OK");
            }

        }
    }
} 