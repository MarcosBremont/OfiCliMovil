using System;
using System.Collections.Generic;
using System.Text;

namespace OfiCliMovil.Models.Entidad
{
   public  class EDetalle_Factura
    {
            public int cod_Prod { get; set; }
            public string producto { get; set; }
            public double precio { get; set; }
            public double cantidad { get; set; }
            public double total { get; set; }

    }

}
