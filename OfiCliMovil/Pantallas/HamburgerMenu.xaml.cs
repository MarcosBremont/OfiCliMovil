using HamburgerMenu;
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
    public partial class HamburgerMenu : MasterDetailPage
    {
        public HamburgerMenu()
        {
            InitializeComponent();
            MyMenu();

        }
        public void MyMenu()
        {
            Detail = new NavigationPage(new DashboardPage());
            List<Menu> menu = new List<Menu>
            {
                new Menu{ Page= new DashboardPage(), MenuTitle="Dashboard",  MenuDetail="",icon="DashboardIcon.png"},
                new Menu{ Page= new BalancePendiente(), MenuTitle="Balance Pendiente",  MenuDetail="",icon="dollarIcon.png"},
                new Menu{ Page= new InformacionGeneral(), MenuTitle="Informacion General",  MenuDetail="",icon="information.png"},
                new Menu{ Page= new MisMetodosDePago(), MenuTitle="Mis Metodos de Pago",  MenuDetail="",icon="creditcard.png"},
                new Menu{ Page= new RealizarPago(), MenuTitle="Realizar Pago",  MenuDetail="",icon="dollarIcon2.png"},
                new Menu{ Page= new PagosRealizados(), MenuTitle="Pagos Realizados",  MenuDetail="",icon="creditcard.png"},
                new Menu{ Page= new HistorialdeOrdenes(), MenuTitle="Historial de Ordenes",  MenuDetail="",icon="history.png"},
                new Menu{ Page= new ReporteAveria(), MenuTitle="Reporte de Averia",  MenuDetail="",icon="herramientas.png"},
                new Menu{ Page= new Servicios(), MenuTitle="Servicios",  MenuDetail="",icon="herramientas.png"}
            };
            ListMenu.ItemsSource = menu;
        }
        private void ListMenu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var menu = e.SelectedItem as Menu;
            if (menu != null)
            {
                IsPresented = false;
                Detail = new NavigationPage(menu.Page);
            }
        }
        public class Menu
        {
            public string MenuTitle
            {
                get;
                set;
            }
            public string MenuDetail
            {
                get;
                set;
            }

            public ImageSource icon
            {
                get;
                set;
            }

            public Page Page
            {
                get;
                set;
            }
        }

        private async void BtnCerrarSesion_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Información", "¿Desea cerrar sesión?", "SI", "NO"))
            {
                LoginPage loginPage = new LoginPage();
                await Navigation.PushModalAsync(loginPage);
            }
        }
    }
}