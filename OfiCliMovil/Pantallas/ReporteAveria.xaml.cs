using Acr.UserDialogs;
using Objetos;
using OfiCliMovil.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Objetos;

namespace OfiCliMovil.Pantallas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReporteAveria : ContentPageBase
    {
        ApiOrdenServicio apiOrdenServicio = new ApiOrdenServicio();
        int ServicioOrden = 0;
        string comentario = "";
        public ReporteAveria()
        {
            InitializeComponent();
        }

        private void radioCable_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
                ServicioOrden = 1;
        }

        private void radioInternet_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            ServicioOrden = 2;
        }

        private async void BtnReportarAveria_Clicked(object sender, EventArgs e)
        {
            comentario = txtcomentario.Text;

            var apiResult = await apiOrdenServicio.CrearAveria(new Models.Entidad.EOrdenes() { codigo_cli = App.Id_Cliente, tiposervicio = this.ServicioOrden, comentario = comentario });
          
            if (apiResult.Respuesta == "OK")
            {
                MostrarNotificacion(apiResult.Mensaje);
            }
            else
            {
                MostrarNotificacion(apiResult.Mensaje);
            }

            txtcomentario.Text = "";
            radioCable.IsChecked = false;
            radioInternet.IsChecked = false;


        }
    }
}