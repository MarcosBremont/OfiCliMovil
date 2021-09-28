using System;
using System.Collections.Generic;
using System.Text;

namespace OfiCliMovil.Models.Entidad
{
   public class ERecibo
    {
        public int numero_rec { get; set; }
        public string fecha { get; set; }
        public string cliente { get; set; }
        public double valor { get; set; }
        public string estado { get; set; }
        public string codigo_cli { get; set; }
        public double balance { get; set; }
        public string boleto { get; set; }
        public string pinPaquetico { get; set; }
        public string tipo { get; set; }
        public string referencia { get; set; }
        public string cobrador { get; set; }
        public string concepto { get; set; }
    }
}
