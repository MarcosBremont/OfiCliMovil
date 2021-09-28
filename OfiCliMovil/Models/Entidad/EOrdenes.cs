using System;
using System.Collections.Generic;
using System.Text;

namespace OfiCliMovil.Models.Entidad
{
    public class EOrdenes
    {
        public string numero { get; set; }
        public string fecha { get; set; }
        public string servicio { get; set; }
        public string tipo { get; set; }
        public string estado { get; set; }
        public string fechaCompletada { get; set; }
        public string tecnico { get; set; }

        //agregados manual

        public int codigo_cli { get; set; }
        public int tiposervicio { get; set; }
        public string comentario { get; set; }
    }
}
