using EjemploListView.Modelo;
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
    public partial class MisMetodosDePago : ContentPage
    {
        public MisMetodosDePago()
        {
            InitializeComponent();
            banderaClick = true;
        }


        private static bool banderaClick;

        protected override async void OnAppearing()
        {
            LlenarMenu();
            await Task.Yield();
        }

        public async void LlenarMenu()
        {
            EjemploListView1Model oEjemploListView1Model = new EjemploListView1Model();
            listViewEjemplo1.ItemsSource = null;
            listViewEjemplo1.ItemsSource = oEjemploListView1Model.ObtenerMenuEjemplo1();
            listViewEjemplo1.ItemSelected += OnClickOpcionSeleccionada;
        }

        private async void OnClickOpcionSeleccionada(object sender, SelectedItemChangedEventArgs e)
        {
            if (banderaClick)
            {
                var item = e.SelectedItem as MenuEjemplo1;
                if ((item != null) && (item.Habilitado))
                {
                    var oSeleccionado = item.idOpcion;
                    banderaClick = false;
                    switch (oSeleccionado)
                    {
                        case 1:
                            Navigation.PushAsync(new MisMetodosDePago());
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                    }
                    await Task.Run(async () =>
                    {
                        await Task.Delay(500);
                        banderaClick = true;
                    });

                }
            } // fin banderaCLick
        }// fin metodo OnClickOpcionSeleccionada
    }
}