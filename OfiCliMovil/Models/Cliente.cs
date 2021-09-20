using OfiCliMovil;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OfiCliMovil.Models
{
    public class Cliente
    {
        Herramientas herramientas = new Herramientas();

        #region Entidades
        public int codigo { get; set; } = 0;
        public string nombre { get; set; }
        public string estado { get; set; }
        public int cod_alm { get; set; }
        public string usuario { get; set; }
        public string clave { get; set; }
        public string imei { get; set; }
        public string token_firebase { get; set; }
        public string ofitec { get; set; }
        public object accion { get; set; }
        public string token { get; set; }
        public string respuesta { get; set; }
        public string mensaje { get; set; }

        public string respuesta_code { get; set; }

        public static bool IsLoginTecnico { get; set; } = false;
        public static string NombreTecnico { get; set; }
        public static string TokenTecnico { get; set; }
        public static int CodigoTecnico { get; set; }
        public static string ImeiTecnico { get; set; }
        #endregion

    }
}
