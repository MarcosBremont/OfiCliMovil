using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OfiCliMovil.Objetos
{
    public class ContentPageBase: ContentPage
    {
        public void MostrarNotificacion(string mensaje)
        {
            ToastConfig config = new ToastConfig(mensaje);
            config.Duration = new TimeSpan(0, 0, 5);
            config.Position = ToastPosition.Top;
            UserDialogs.Instance.Toast(config);
        }

    }
}
