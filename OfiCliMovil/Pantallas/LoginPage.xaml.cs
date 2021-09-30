using Acr.UserDialogs;
using OfiCliMovil.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Rg.Plugins.Popup.Services;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using OfiCliMovil.Objetos;
using Xamarin.Forms.Xaml;
using Objetos;
using Rg.Plugins.Popup.Services;

namespace OfiCliMovil.Pantallas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPageBase
    {
        Herramientas herramientas = new Herramientas();
        ApiOrdenServicio apiOrdenServicio = new ApiOrdenServicio();
        ToastConfigClass toastConfig = new ToastConfigClass();

        ModalVersiones modalversion = new ModalVersiones();
        private bool _userTapped;

        public LoginPage()
        {
            InitializeComponent();

            lblolvidastelacontraseña.GestureRecognizers.Add(
                new TapGestureRecognizer()
                {
                    Command = new Command(async () =>
                    {
                        lblolvidastelacontraseña.IsVisible = false;
                        await Navigation.PushModalAsync(new OlvideMiContrasena());
                        lblolvidastelacontraseña.IsVisible = true;
                    }),
                         NumberOfTapsRequired = 1

                }
              );


            lblVersion.GestureRecognizers.Add(
              new TapGestureRecognizer()
              {
                  Command = new Command(async () =>
                  {
                      if (_userTapped)
                          return;

                      _userTapped = true;
                      modalversion = new ModalVersiones();
                      modalversion.OnLLamarOtraPantalla += Modalversion_OnLLamarOtraPantalla;

                      await PopupNavigation.PushAsync(modalversion);
                      await Task.Delay(1000);
                      _userTapped = false;
                      Opacity = 1;
                  }),
                  NumberOfTapsRequired = 1

              }
            );

        }

        private void Modalversion_OnLLamarOtraPantalla(object sender, EventArgs e)
        {
            try
            {
                Acr.UserDialogs.UserDialogs.Instance.ShowLoading("Cargando...");
                //await LlenarListado();
                Acr.UserDialogs.UserDialogs.Instance.HideLoading();
            }

            catch (Exception ex)
            {
                MostrarNotificacion("Error, no se puedne consultar las versiones" + ex);
            }
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


                    string ClaveEnMayuscula = TxtClave.Text.ToUpper(); 
                    var apiResult = await apiOrdenServicio.IniciarSesion(TxtUsuario.Text, ClaveEnMayuscula);

                    if (apiResult.encontrado == true)
                    {
                        App.Cliente = apiResult.nombre_cli;
                        App.Cedula = TxtUsuario.Text;
                        App.Clave = ClaveEnMayuscula;
                        App.Id_Cliente = apiResult.codigo_cli;
                        toastConfig.MostrarNotificacion($"Bienvenido {apiResult.nombre_cli}", ToastPosition.Top, 3, "#51C560");
                        App.HamburgerMenu = new HamburgerMenu();
                        await Navigation.PushModalAsync(App.HamburgerMenu);
                        int codigocli = apiResult.codigo_cli;
                    }
                    else
                    {
                        MostrarNotificacion(apiResult.result);
                    }
                }
                catch (Exception ex)
                {
                    toastConfig.MostrarNotificacion("No se pudo establecer la conexión, por favor verifique los datos nuevamente.", ToastPosition.Top, 3, "#FC412F");
                }
            }

            BtnIniciarSesion.IsEnabled = true;

        }

        //private async void AjusteAdministracion_Clicked(object sender, EventArgs e)
        //{
        //    if (IsBusy)
        //        return;
        //    IsBusy = true;
        //    Opacity = 0.5;
        //    await Navigation.PushModalAsync(new Administracion());
        //    Opacity = 1;
        //}
    }
}
