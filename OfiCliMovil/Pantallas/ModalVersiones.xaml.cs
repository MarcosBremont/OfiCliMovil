using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using OfiCliMovil.Models;
using Rg.Plugins.Popup.Services;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OfiCliMovil.Pantallas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModalVersiones : Rg.Plugins.Popup.Pages.PopupPage
    {
        public event EventHandler OnLLamarOtraPantalla;

        public ModalVersiones()
        {
            InitializeComponent();
            OnLLamarOtraPantalla += ModalVersiones_OnLLamarOtraPantalla;
        }

        private void ModalVersiones_OnLLamarOtraPantalla(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }


        public void MostrarNotificacion(string mensaje)
        {
            ToastConfig config = new ToastConfig(mensaje);
            config.Duration = new TimeSpan(0, 0, 5);
            config.Position = ToastPosition.Top;
            UserDialogs.Instance.Toast(config);
        }

        private async void BtnCancelar_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.PopAsync();

        }
    }
}