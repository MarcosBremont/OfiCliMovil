using Acr.UserDialogs;
using OfiCliMovil.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using OfiCliMovil.Objetos;
using Xamarin.Forms.Xaml;

namespace OfiCliMovil.Pantallas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class LoginPage : ContentPageBase
    {
        Herramientas herramientas = new Herramientas();

        ToastConfigClass toastConfig = new ToastConfigClass();
        Tecnico tec = new Tecnico();
        public event EventHandler OnLogin;
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void BtnIniciarSesion_Clicked(object sender, EventArgs e)
        {
            BtnIniciarSesion.IsEnabled = false;

            using (UserDialogs.Instance.Loading("Cargando..."))
            {

                try
                {
                    if (string.IsNullOrEmpty(TxtUsuario.Text) || string.IsNullOrEmpty(TxtUsuario.Text))
                    {
                        toastConfig.MostrarNotificacion("El usuario y la contraseña son obligatorios");
                        return;
                    }



                    var resultTecnico = await tec.IniciarSesion(TxtUsuario.Text, TxtClave.Text);

                    if (resultTecnico.respuesta == "OK")
                    {
                        toastConfig.MostrarNotificacion($"Bienvenido {resultTecnico.nombre}", ToastPosition.Top, 3, "#51C560");
                        OnLogin(this, EventArgs.Empty);
                        _ = this.Navigation.PopModalAsync();
                    }
                    else
                    {
                        MostrarNotificacion(resultTecnico.mensaje);
                    }
                }
                catch (Exception ex)
                {
                    toastConfig.MostrarNotificacion("No se pudo establecer la conexión, por favor verifique los datos nuevamente.", ToastPosition.Top, 3, "#FC412F");
                }
            }
           
            BtnIniciarSesion.IsEnabled = true;

            await Navigation.PushModalAsync(new HamburgerMenu());
        }

        private async void AjusteAdministracion_Clicked(object sender, EventArgs e)
        {
            if (IsBusy)
                return;
            IsBusy = true;
            Opacity = 0.5;
            await Navigation.PushModalAsync(new Administracion());
            Opacity = 1;
        }
    }
}
