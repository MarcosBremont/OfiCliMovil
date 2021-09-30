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


                if (apiResult.legal == "N")
                {
                    lblenlegal.Text = "NO";
                }
                else
                {
                    lblenlegal.Text = "SI";

                }


                if (apiResult.acuerdo == "N")
                {
                    lblsinacuerdos.Text = "SIN ACUERDOS";
                }
                else
                {
                    lblsinacuerdos.Text = "CON ACUERDOS";
                }


                if (apiResult.estadocable == "S")
                {
                    lblestadoserviciocable.Text = "SUSPENDIDO";
                }
                else if (apiResult.estadocable == "A")
                {
                    lblestadoserviciocable.Text = "ACTIVO";
                }


                if (apiResult.internet == "S")
                {
                    lblestadoserviciointernet.Text = "SUSPENDIDO";
                }
                else if (apiResult.internet == "A")
                {
                    lblestadoserviciointernet.Text = "ACTIVO";
                }

                if (apiResult.telefono == null)
                {
                    txttelefono.Text = "0";
                }
                else
                {
                    txttelefono.Text = apiResult.telefono.ToString();
                }


                txtcodigo.Text = apiResult.codigo_cli.ToString();
                txtnombrecli.Text = apiResult.nombre_cli.ToString();
                txtcedula.Text = apiResult.cedula.ToString();
                lblEstado.Text = apiResult.estado.ToString();
                TxtFecha.Text = apiResult.fecha.ToString();
                txtApodo.Text = apiResult.apodo.ToString();
                txtemail.Text = apiResult.email.ToString();
                txtdireccion.Text = apiResult.direccion.ToString();
                txtejecutivo.Text = apiResult.ejecutivo.ToString();
                txtcuotamensual.Text = apiResult.cuota.ToString();
                //txtContratoFisico.Text = apiResult.confisico.ToString();
                TxtFecha.Text = apiResult.fecha.ToString("dd/MM/yyyy");
                lblfincontrato.Text = apiResult.fincontrato.ToString("dd/MM/yyyy");
                //TxtFecha.Text = apiResult.fecha.ToString();
                lblfinservicio.Text = apiResult.fechafinservicio.ToString("dd/MM/yyyy");

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