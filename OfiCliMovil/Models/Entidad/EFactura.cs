using System;
using System.Collections.Generic;
using System.Text;

namespace OfiCliMovil.Models.Entidad
{
    public class EFactura
    {
      
            public int numero_fac { get; set; }
            public DateTime fecha { get; set; }
            public double valor { get; set; }
            public double balance { get; set; }
            public string referencia { get; set; }
            public List<EDetalle_Factura> detalle { get; set; }
       
    }

}
