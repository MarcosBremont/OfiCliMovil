using OfiCliMovil.Models;
using OfiCliMovil.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OfiCliMovil.Pantallas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BalancePendiente : ContentPage
    {
        ObservableCollection<UserModel> Usr_List = new ObservableCollection<UserModel>();

        public BalancePendiente()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
            //test data population
            this.Usr_List.Add(new UserModel { documento = "4525", valororiginal = "2,155.00", pendiente = "1,505.00", concepto = "MENSUALIDAD CABLE" });
            this.Usr_List.Add(new UserModel { documento = "4525", valororiginal = "2,155.00", pendiente = "1,505.00", concepto = "MENSUALIDAD CABLE" });
            this.Usr_List.Add(new UserModel { documento = "4525", valororiginal = "2,155.00", pendiente = "1,505.00", concepto = "MENSUALIDAD CABLE" });


            //listx.ItemsSource = this.Usr_List;

        }

        private async void BtnAtras_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();

        }
    }
}