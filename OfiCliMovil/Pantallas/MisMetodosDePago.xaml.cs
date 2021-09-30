using EjemploListView.Modelo;
using Newtonsoft.Json;
using OfiCliMovil.Models;
using OfiCliMovil.Models.Entidad;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Drawing;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OfiCliMovil.Pantallas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MisMetodosDePago : ContentPage
    {
        List<string> ListaDeImagenesSeleccionadas;

        public MisMetodosDePago()
        {
            InitializeComponent();
            lsv_tarjetas.ItemSelected += Lsv_tarjetas_ItemSelected;
        }

        private async void Lsv_tarjetas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (IsBusy)
                return;

            IsBusy = true;



            if (e.SelectedItem != null)
            {
                var element = lsv_tarjetas.SelectedItem as ApiOrdenServicio;
                await this.Navigation.PushModalAsync(new EditarMetodoPago());

            }
        }

        protected override async void OnAppearing()
        {
            LlenarMenu();
            await Task.Yield();
        }

      
        public async void LlenarMenu()
        {
            try
            {
                lsv_tarjetas.IsVisible = false;
                ApiOrdenServicio apiOrdenServicio = new OfiCliMovil.Models.ApiOrdenServicio();
                lsv_tarjetas.ItemsSource = null;
                int codig_cli = App.Id_Cliente;
                //var result = await apiOrdenServicio.GetTarjetas(App.Id_Cliente);
                var result = await new Herramientas().EjecutarSentenciaEnApiLibre($"Cliente/ObtenerListadoTarjetas/{App.Id_Cliente}");

                //var result = await new Herramientas().EjecutarSentenciaEnApiLibre($"Cliente/ObtenerListadoTarjetas?codigo_cli={codig_cli}");


                List<ETarjetas> listado_de_fotos = JsonConvert.DeserializeObject<List<ETarjetas>>(result);


                foreach (var item in listado_de_fotos)
                {
                    item.Image = Base64ToImageSource(item.logo);
                    item.cliente = App.Cliente;
                }


                lsv_tarjetas.ItemsSource = listado_de_fotos;
                lsv_tarjetas.IsVisible = true;

                //txtBalance.Text = string.Format("{0:N2}", datos.Sum(n => n.valor));
                //txtcantidad.Text = datos.Count.ToString();

            }
            catch (Exception ex)
            {

            }
        }



        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        private ImageSource Base64ToImageSource(string base64)
        {
            var byteArray = Convert.FromBase64String(base64);
            var stream1 = new MemoryStream(byteArray);

            return ImageSource.FromStream(() => stream1);

        }
    }
}