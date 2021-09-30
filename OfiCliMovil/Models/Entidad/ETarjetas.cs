using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace OfiCliMovil.Models.Entidad
{
    public partial class ETarjetas
    {
        public string cliente { get; set; }
        public string token { get; set; }
        public string terminal { get; set; }
        public string logo { get; set; }
        public string marca { get; set; }

        public ImageSource Image { get; set; }

    }
}
