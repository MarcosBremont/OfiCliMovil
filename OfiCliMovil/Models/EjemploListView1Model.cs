using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using EjemploListView.Modelo;

namespace EjemploListView.Modelo
{
    public class EjemploListView1Model
    {

        public EjemploListView1Model()
        {
           // constructor
        }
        public ObservableCollection<MenuEjemplo1> ObtenerMenuEjemplo1()
        {
            ObservableCollection<MenuEjemplo1> oMenuPrincipal = new ObservableCollection<MenuEjemplo1>();

            oMenuPrincipal.Add(new MenuEjemplo1
            {
                Opcion = "•••• 9818",
                Habilitado = true,
                idOpcion = 1,
                icon = "logoamericanexpress.png",
                IconoBasura = "garbagecan.png"

            });
            oMenuPrincipal.Add(new MenuEjemplo1
            {
                Opcion = "•••• 9818",
                Habilitado = true,
                idOpcion = 2,
                icon = "logodiscover.png",
                IconoBasura = "garbagecan.png"


            });
            oMenuPrincipal.Add(new MenuEjemplo1
            {
                Opcion = "•••• 9818",
                Habilitado = true,
                idOpcion = 3,
                icon = "logomastercard.png",
                IconoBasura = "garbagecan.png"

            });
            oMenuPrincipal.Add(new MenuEjemplo1
            {
                Opcion = "•••• 9818",
                Habilitado = true,
                idOpcion = 4,
                icon = "logovisa.png",
                IconoBasura = "garbagecan.png"

            });



            return oMenuPrincipal;


        } // Fin del método ObtenerMenu

    } // fin clase
}
