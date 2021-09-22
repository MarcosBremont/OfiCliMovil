using Acr.UserDialogs;
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


    public partial class OlvideMiContrasena : ContentPage
    {
        ToastConfigClass toastConfig = new ToastConfigClass();
        public OlvideMiContrasena()
        {
            InitializeComponent();
        }

        private async void BtnAtras_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private async void btnEnviarClave_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtcedula.Text))
                {
                    toastConfig.MostrarNotificacion("¡Los campos son obligatorios!");
                    return;
                }
                
                Acr.UserDialogs.UserDialogs.Instance.ShowLoading("Cargando...");
                ApiOrdenServicio Api = new ApiOrdenServicio();
                var respuesta = await Api.RecuperarClave(txtcedula.Text);
                if (respuesta.result == "OK")
                {
                    toastConfig.MostrarNotificacion("¡Contraseña enviada a su correo con exito!");
                    await Navigation.PopModalAsync();
                }
                Acr.UserDialogs.UserDialogs.Instance.HideLoading();
            }

            catch (Exception ex)
            {
                toastConfig.MostrarNotificacion("No se pudo establecer conexion con el servidor. ");
            }
        }
    }
}