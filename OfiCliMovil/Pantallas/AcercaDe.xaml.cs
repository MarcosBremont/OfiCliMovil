using Acr.UserDialogs;
using OfiCliMovil.Models;
using Rg.Plugins.Popup.Services;
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
    public partial class AcercaDe : ContentPage
    {
        Herramientas herramientas = new Herramientas();
        ApiOrdenServicio apiOrdenServicio = new ApiOrdenServicio();
        ToastConfigClass toastConfig = new ToastConfigClass();

        ModalVersiones modalversion = new ModalVersiones();
        private bool _userTapped;
        public AcercaDe()
        {
            InitializeComponent();



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


            txtConectionType.GestureRecognizers.Add(
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

        public void MostrarNotificacion(string mensaje)
        {
            ToastConfig config = new ToastConfig(mensaje);
            config.Duration = new TimeSpan(0, 0, 5);
            config.Position = ToastPosition.Top;
            UserDialogs.Instance.Toast(config);
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
    }
}