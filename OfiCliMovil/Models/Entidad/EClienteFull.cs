using System;
using System.Collections.Generic;
using System.Text;

namespace OfiCliMovil.Models.Entidad
{
    public class EClienteFull
    {
        Herramientas herramientas = new Herramientas();
        #region Entidades

        public bool encontrado { get; set; }
        public string result { get; set; }
        public int codigo_cli { get; set; }
        public string nombre_cli { get; set; } = "";
        public string direccion { get; set; } = "";
        public string cedula { get; set; } = "";
        public string estado_civ { get; set; } = "";
        public string profesion { get; set; } = "";
        public string formapago { get; set; } = "";
        public string estado { get; set; } = "";
        public string estadocable { get; set; }
        public int tarifa { get; set; }
        public int plandatos { get; set; }
        public double cuotacable { get; set; }
        public double cuotadatos { get; set; }
        public double cuota { get; set; }
        public DateTime fechact { get; set; }
        public DateTime fechsusp { get; set; }
        public string comentario { get; set; } = "";
        public string credito { get; set; } = "";
        public DateTime fecha { get; set; }
        public string sexo { get; set; } = "";
        public string acuerdo { get; set; } = "";
        public string tipo_ncf { get; set; } = "";
        public string tipo_senal { get; set; } = "";
        public string tecnico { get; set; } = "";
        public int televisore { get; set; }
        public string alcancia { get; set; } = "";
        public string email { get; set; } = "";
        public string tipocuota { get; set; } = "";
        public int codtecnico { get; set; }
        public string nodo { get; set; } = "";
        public string poste { get; set; } = "";
        public string tap { get; set; } = "";
        public string cintillo { get; set; } = "";
        public DateTime fincontrato { get; set; }
        public int canal { get; set; }
        public int emisora { get; set; }
        public int programa { get; set; }
        public DateTime fechacanal { get; set; }
        public int vendedor { get; set; }
        public string cablemodem { get; set; } = "";
        public string internet { get; set; } = "";
        public string confisico { get; set; } = "";
        public string legal { get; set; } = "";
        public int usumodi { get; set; }
        public DateTime fechamodi { get; set; }
        public DateTime fecha_nac { get; set; }
        public string palmid { get; set; } = "";
        public int codmodem { get; set; }
        public DateTime fechaemail { get; set; }
        public string tarjeta { get; set; } = "";
        public string tipofactu { get; set; } = "";
        public int ejecutivo { get; set; }
        public int codtipocli { get; set; }
        public int codmanual { get; set; }
        public string carnet { get; set; } = "";
        public string exequatur { get; set; } = "";
        public string provincia { get; set; } = "";
        public DateTime fechaexeq { get; set; }
        public string apodo { get; set; } = "";
        public string chance { get; set; } = "";
        public DateTime fec_chance { get; set; }
        public string detachance { get; set; } = "";
        public double balance { get; set; }
        public string telefono { get; set; }
        public string numero_telefono { get; set; }
        public string ener_alterna { get; set; }
        public string facturaacaja { get; set; }
        public string facturaacorreo { get; set; }
        public int id_tipoconexion { get; set; }
        public DateTime fechafinservicio { get; set; }
        public DateTime fechafacturacion { get; set; }
        //Propiedades adicionales
        public string transferir { get; set; }
        public string lat { get; set; }
        public string lng { get; set; }
        public int id_nodo { get; set; }
        public string tipo_documento { get; set; }
        public string pasaporte { get; set; }
        public DateTime fechamesgratis { get; set; }
        public DateTime fechafelicitado { get; set; }
        public List<EServicio> Servicios { get; set; }
        #endregion

        public EClienteFull()
        {
            this.Servicios = new List<EServicio>();
        }
    }
}
