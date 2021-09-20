using System;
using System.Collections.Generic;
using System.Linq;



namespace OfiCliMovil.Objetos
{
    public class Convertidor
    {
        public int IntParse(object valor)
        {
            string numeroString = valor != null ? valor.ToString() : "";
            int numero_int;
            int.TryParse(numeroString, out numero_int);
            return numero_int;
        }

        public double DoubleParse(object valor)
        {
            string numeroString = valor != null ? valor.ToString() : "";
            double numero_double;
            double.TryParse(numeroString, out numero_double);
            return numero_double;
        }

        public decimal DecimalParse(object valor)
        {
            string numeroString = valor != null ? valor.ToString() : "";
            decimal numero_double;
            decimal.TryParse(numeroString, out numero_double);
            return numero_double;
        }

        public Int64 IntParse64(object valor)
        {
            string numeroString = valor != null ? valor.ToString() : "";
            Int64 numero_int;
            Int64.TryParse(numeroString, out numero_int);
            return numero_int;
        }

        public DateTime DateTimeParse(object valor)
        {
            string fechaString = valor != null ? valor.ToString() : "";
            DateTime fechaParsed;
            DateTime.TryParse(fechaString, out fechaParsed);
            return fechaParsed;
        }

        public DateTime FechaHora()
        {
            TimeZoneInfo zona = TimeZoneInfo.FindSystemTimeZoneById("Venezuela Standard Time");
            return TimeZoneInfo.ConvertTime(DateTime.Now, zona);
        }

        public bool BoolParse(string valor)
        {
            bool valorBool;
            bool.TryParse(valor, out valorBool);
            return valorBool;
        }

        public string StringParse(object valor)
        {
            return valor != null ? valor.ToString() : "";
        }

        public DateTime ProbarYRepararFecha(string fecha)
        {
            DateTime fechaActual = FechaHora();
            TimeSpan horaActual = TimeSpan.Parse(fechaActual.ToString("HH:mm:ss"));
            DateTime fechaReparada = DateTime.TryParse(fecha, out fechaReparada) ? fechaReparada : fechaActual;
            fechaReparada = DateTimeParse(fecha).Date.Add(horaActual);
            return fechaReparada;
        }

        public string QuitarCerosIp(string ip)
        {
            string[] ipSeparada = new string[] { };
            IEnumerable<int> ipInt;
            string ipFinal = "";

            ipSeparada = ip.Split('.');
            ipInt = ipSeparada.Select(val => IntParse(val)).ToArray<int>();
            ipFinal = string.Join(".", ipInt);

            return ipFinal;
        }

        public string GenerarClaveOficli(int longitudClave = 6)
        {
            Random rnd = new Random();
            string clave = "";

            for (int i = 0; i < longitudClave; i++)
            {
                clave = clave + (rnd.Next(1, 10).ToString());
            }

            return clave;
        }

        public string ConvertirTipoCuotaEnPalabra(string tipoCuota)
        {
            if (tipoCuota == "A")
            {
                return "Asignada";
            }
            else if (tipoCuota == "S")
            {
                return "Por Servicio";
            }

            return "Sin Definir";
        }
    }
}
