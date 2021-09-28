using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Net.Http;
using System.Reflection;
using ImageCircle.Forms.Plugin.Abstractions;
using Acr.UserDialogs;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Text;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using OfiCliMovil.Models;

namespace OfiCliMovil
{
    public class Herramientas
    {
        //    ToastConfigClass toastConfig = new ToastConfigClass();
        //    //Public Objects, clases and Variables...
        //    public string fileSelectedPath = null;
        //    public Page defaultParentPage = null;
        //    public Color errColor = Color.Red;
        //    public bool busy = false;
        //    public bool BuenaConexionAInternet = false;
        //    public string msgConexionAInternet = "";

        //    //Server
        //    HttpClient usuarioFoto = new HttpClient();

        //    internal List<Productos> EstablecimientosFiltradosPorNombre(string texto)
        //    {
        //        try
        //        {
        //            List<Productos> filtrados = new List<Productos>();
        //            foreach (Productos productos in Configuracion.establecimientos)
        //            {
        //                if (productos.nombre.ToLower().Contains(texto.ToLower()))
        //                    filtrados.Add(productos);
        //            }

        //            return filtrados;
        //        }
        //        catch (Exception ex)
        //        {
        //            _ = ex.Message;
        //            return null;
        //        }
        //    }

        //    public bool ComprobarConexionURL(string URL)
        //    {
        //        try
        //        {
        //            URL = URL.ToLower().Replace("http://", "").Replace("https://", "");
        //            var ip_regularizado = URL.Split('/');
        //            URL = ip_regularizado[0];


        //            Ping p1 = new Ping();
        //            PingReply PR = p1.Send(URL);
        //            // check when the ping is not success
        //            while (!PR.Status.ToString().Equals("Success"))
        //            {
        //                return false;
        //            }
        //            // check after the ping is n success
        //            while (PR.Status.ToString().Equals("Success"))
        //            {
        //                return true;
        //            }

        //            return false;
        //        }
        //        catch (Exception ex)
        //        {
        //            toastConfig.MostrarNotificacion("¡Error al conectar!");

        //            Console.WriteLine(ex.Message);
        //            return false;
        //        }
        //    }

        //    internal movimiento GetMovimientoPorId(int idMovimientoExt)
        //    {
        //        //Obtener la Tarjeta por el token
        //        foreach (movimiento mov in Configuracion.movimientos)
        //            if (mov.idmovimiento == idMovimientoExt)
        //                return mov;

        //        return null;
        //    }

        //    internal string FormatoMontoPreAzul(double monto)
        //    {
        //        try
        //        {
        //            string montoFormateado = monto >= 1 ? monto.ToString("###.00") : "0" + monto.ToString("###.00");
        //            return montoFormateado.Replace(",", ".");
        //        }
        //        catch
        //        {
        //            return "Error";
        //        }
        //    }

        //    internal Tarjetas GetTarjetaPorToken(string token)
        //    {
        //        //Obtener la Tarjeta por el token
        //        foreach (Tarjetas tarjeta in Configuracion.MisMetodosDePago)
        //            if (tarjeta.token == token)
        //                return tarjeta;

        //        return null;
        //    }

        //    internal Tarjetas GetTarjetaPorTerminal(string numeroTerminalTarjeta)
        //    {
        //        if (numeroTerminalTarjeta.Length > 4)
        //            numeroTerminalTarjeta = numeroTerminalTarjeta.Substring(numeroTerminalTarjeta.Length - 4, 4);

        //        //Obtener la Tarjeta por el token
        //        foreach (Tarjetas tarjeta in Configuracion.MisMetodosDePago)
        //            if (tarjeta.terminal == numeroTerminalTarjeta)
        //                return tarjeta;

        //        return null;
        //    }

        //    internal void Toast(string texto)
        //    {
        //        UserDialogs.Instance.Toast(texto);
        //    }

        //    internal TipoTarjeta GetTipoTarjetaPorId(int id_tipo_tarjeta)
        //    {
        //        //Obtener el logo que coincide con el id del tipo de tarjeta...
        //        foreach (TipoTarjeta tipo_tarjeta in Configuracion.TiposTarjeta)
        //            if (tipo_tarjeta.id_tipo_tarjeta == id_tipo_tarjeta)
        //                return tipo_tarjeta;

        //        return null;
        //    }

        //    internal string GetLogoTarjetaPorIdTipoTarjeta(int id_tipo_tarjeta)
        //    {
        //        //Obtener el logo que coincide con el id del tipo de tarjeta...
        //        TipoTarjeta tipoCard = GetTipoTarjetaPorId(id_tipo_tarjeta);

        //        if (tipoCard != null)
        //            return tipoCard.logo;
        //        else
        //            return "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";
        //    }

        //    internal Comprobante GetComprobantePorCodigo(string codigo_comprobante)
        //    {
        //        //Obtener el logo que coincide con el id del tipo de tarjeta...
        //        foreach (Comprobante comprobante_item in Configuracion.Comprobantes)
        //            if (comprobante_item.codigo == codigo_comprobante)
        //                return comprobante_item;

        //        return null;
        //    }

        //    internal string FromURLTOBase64(string fileName)
        //    {
        //        try
        //        {
        //            System.Net.WebClient wc = new System.Net.WebClient();
        //            byte[] response = wc.DownloadData(fileName);
        //            return ByteArrayToBase64(response);
        //        }
        //        catch (Exception)
        //        {
        //            return "Error";
        //        }
        //    }

        //    internal object GetColorPorId(string idColor)
        //    {
        //        //Obtener la marca que coincide con el id de marca recibido...
        //        foreach (CarColor color in Configuracion.colores)
        //            if (color.id_color.ToString() == idColor)
        //                return color;

        //        return null;
        //    }

        //    public object GetInstance(string strFullyQualifiedName)
        //    {
        //        try
        //        {
        //            Type t = Type.GetType(strFullyQualifiedName);
        //            return Activator.CreateInstance(t);
        //        }
        //        catch (Exception e)
        //        {
        //            //Hubo un error al tratar de crear la isntancia de la clase strFullyQualifiedName
        //            return null;
        //        }
        //    }

        //    public string NewTrimingForMask(string Mask, string TextFor)
        //    {

        //        //999-9999999-9
        //        //___-_______-_
        //        //_59-___2__1-_

        //        List<string> AllDiferentChars = SacarCadaCaracter(Mask);
        //        bool finishFromleft = false;
        //        bool finishFromright = false;

        //        for (int i = 0; i < AllDiferentChars.Count; i++)
        //        {
        //            //Remove from left
        //            for (int j = 0; finishFromleft; j++)
        //            {
        //                if (TextFor.Substring(j, 1) == AllDiferentChars[i])
        //                {
        //                    TextFor = TextFor.Remove(j, 1);
        //                }
        //                else
        //                {
        //                    finishFromleft = true;
        //                }
        //            }

        //            //Remove from right
        //            for (int j = 0; finishFromright; j++)
        //            {
        //                if (TextFor.Substring(j, 1) == AllDiferentChars[i])
        //                {
        //                    TextFor = TextFor.Remove(j, 1);
        //                }
        //                else
        //                {
        //                    finishFromright = true;
        //                }
        //            }

        //        }


        //        return TextFor;
        //    }

        //    public List<string> SacarCadaCaracter(string TextoATrabajar)
        //    {
        //        List<string> MyCaracters = new List<string>();

        //        for (int i = 0; i < TextoATrabajar.Length; i++)
        //        {
        //            if (!MyCaracters.Contains(TextoATrabajar.Substring(i, 1)) && TextoATrabajar.Substring(i, 1) != "_")
        //            {
        //                MyCaracters.Add(TextoATrabajar.Substring(i, 1));
        //            }
        //        }
        //        return MyCaracters;
        //    }

        //    public string FormatoDinero(string valor)
        //    {
        //        try
        //        {
        //            try
        //            {
        //                string s = valor.Replace("$", "").Replace(Configuracion.moneda, "");
        //                s = Convert.ToDouble(valor).ToString("###,###.00");
        //                if (s.Contains("-"))
        //                {
        //                    s = s.Replace("-", "");
        //                    if (s == ".00")
        //                    {
        //                        s = "0.00";
        //                    }
        //                    s = $"-{Configuracion.moneda} " + s;
        //                }
        //                else
        //                {
        //                    if (s == ".00")
        //                    {
        //                        s = "0.00";
        //                    }
        //                    s = Configuracion.moneda + " " + s;
        //                }

        //                return s;
        //            }
        //            catch
        //            {
        //                string s = "-" + Convert.ToDouble(valor.Replace("-", "")).ToString("###,###.00");
        //                if (s == ".00")
        //                {
        //                    s = "0.00";
        //                }
        //                s = Configuracion.moneda + " " + s;

        //                return s;
        //            }
        //        }
        //        catch
        //        {
        //            return valor;
        //        }
        //    }

        //    public string FormatoDinero(double valor)
        //    {
        //        try
        //        {
        //            try
        //            {
        //                string s = "";
        //                s = Convert.ToDouble(valor).ToString("###,###.00");
        //                if (s.Contains("-"))
        //                {
        //                    s = s.Replace("-", "");
        //                    if (s == ".00")
        //                    {
        //                        s = "0.00";
        //                    }
        //                    s = $"-{Configuracion.moneda} " + s;
        //                }
        //                else
        //                {
        //                    if (s == ".00")
        //                    {
        //                        s = "0.00";
        //                    }
        //                    s = Configuracion.moneda + " " + s;
        //                }

        //                return s;
        //            }
        //            catch
        //            {
        //                string s = "-" + Convert.ToDouble(valor.ToString().Replace("-", "")).ToString("###,###.00");
        //                if (s == ".00")
        //                {
        //                    s = "0.00";
        //                }
        //                s = Configuracion.moneda + " " + s;

        //                return s;
        //            }
        //        }
        //        catch
        //        {
        //            return valor.ToString();
        //        }
        //    }

        //    public string FormatoDecimalFix(string valor)
        //    {
        //        try
        //        {
        //            try
        //            {
        //                string s = valor.Replace("$", "");
        //                s = Convert.ToDouble(valor).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);

        //                if (s.Contains("-"))
        //                {
        //                    s = s.Replace("-", "");
        //                    if (s == ".00")
        //                    {
        //                        s = "0.00";
        //                    }
        //                    s = "-" + s;
        //                }
        //                else
        //                {
        //                    if (s == ".00")
        //                    {
        //                        s = "0.00";
        //                    }
        //                }

        //                return s;
        //            }
        //            catch
        //            {
        //                return "Error";
        //            }
        //        }
        //        catch
        //        {
        //            return valor;
        //        }
        //    }

        //    public string FormatoDecimal(string valor)
        //    {
        //        try
        //        {
        //            string SignoDeMenos = valor.Substring(0, 1) == "-" ? "-" : "";
        //            try
        //            {
        //                valor = valor.Replace(",", "");
        //                string s = Convert.ToDouble(valor).ToString("###,###.00");
        //                if (s == ".00")
        //                {
        //                    s = "0.00";
        //                }

        //                if (s.Substring(0, 1) == ".")
        //                    s = "0" + s;

        //                return Convert.ToDouble(s) == 0 ? SignoDeMenos + s : s;
        //            }
        //            catch
        //            {
        //                string s = Convert.ToDouble(valor.Replace("-", "")).ToString("###,###.00");
        //                if (s == ".00")
        //                {
        //                    s = "0.00";
        //                }

        //                if (s.Substring(0, 1) == ".")
        //                    s = "0" + s;

        //                return Convert.ToDouble(s) == 0 ? SignoDeMenos + s : s;
        //            }
        //        }
        //        catch
        //        {
        //            return valor;
        //        }
        //    }

        //    public bool IsDecimalValido(string valor)
        //    {
        //        try
        //        {
        //            valor = valor.Replace("$", "");

        //            double s = Convert.ToDouble(valor);

        //            return true;
        //        }
        //        catch
        //        {
        //            if (string.IsNullOrEmpty(valor))
        //                return true;
        //            else
        //                return false;
        //        }
        //    }

        //    public string BorrarConBackSpaceEnMascara(string Mask, string texto, int caretposition)
        //    {
        //        List<string> AllDiferentChars = SacarCadaCaracter(Mask);
        //        texto = texto.Remove(caretposition, 1) + Mask.Substring(Mask.Length - 1, 1);
        //        //texto = FixMovedCharacters(Mask, texto);
        //        string SubTexto = texto.Substring(caretposition, texto.Length - caretposition);
        //        string SubTextoW = SubTexto;
        //        string SubMask = Mask.Substring(caretposition, texto.Length - caretposition);
        //        bool Pertenece = false;
        //        int fullCaret = 0;
        //        string CharacterSame = "";
        //        if (caretposition < texto.Length - 1)
        //        {
        //            for (int i = 0; i < SubTexto.Length - 1; i++)
        //            {

        //                Pertenece = false;
        //                if (AllDiferentChars.Contains(SubTexto.Substring(i, 1)))
        //                    Pertenece = true;

        //                if (Pertenece)
        //                {
        //                    Pertenece = false;
        //                    for (int NewCaret = 0; !Pertenece; NewCaret++)
        //                    {
        //                        if ((i + NewCaret + 1) >= (SubTexto.Length - 1))
        //                        {
        //                            SubTexto = FixMovedCharacters(SubMask, SubTexto);
        //                            Pertenece = false;
        //                            break;
        //                        }
        //                        else
        //                        {
        //                            CharacterSame = SubTexto.Substring(i + NewCaret + 1, 1);
        //                            fullCaret = NewCaret + i + 1;
        //                            if (!AllDiferentChars.Contains(CharacterSame))
        //                            {
        //                                Pertenece = true;
        //                            }
        //                        }
        //                    }
        //                    if (!Pertenece) { break; } else { }//End of the line...

        //                    if (i == 0)
        //                    {
        //                        try
        //                        {
        //                            SubTexto = SubTextoW.Substring(fullCaret, 1);
        //                            SubTexto += SubTextoW.Substring(i, fullCaret - i);
        //                            SubTexto += SubTextoW.Substring(fullCaret + 1, SubTextoW.Length - (fullCaret + 1));
        //                        }
        //                        catch
        //                        {
        //                        }
        //                    }
        //                    else if (i > 0)
        //                    {
        //                        try
        //                        {
        //                            SubTexto = SubTextoW.Substring(0, i);
        //                            SubTexto += SubTextoW.Substring(fullCaret, 1);
        //                            SubTexto += SubTextoW.Substring(i, fullCaret - i);
        //                            SubTexto += SubTextoW.Substring(fullCaret + 1, SubTextoW.Length - (fullCaret + 1));
        //                        }
        //                        catch
        //                        {
        //                        }
        //                    }
        //                    i = fullCaret;
        //                }
        //                SubTextoW = SubTexto;

        //            }
        //        }

        //        texto = texto.Substring(0, caretposition) + SubTexto;

        //        return texto;
        //    }

        //    public bool Validate(string textoActual, string mask)
        //    {
        //        bool Validado = true;

        //        if (textoActual.Length > mask.Length + 1 || textoActual.Length < mask.Length - 1)
        //        {
        //            Validado = false;
        //        }

        //        textoActual = RepararMascara(mask, textoActual);

        //        return Validado;
        //    }

        //    public string RepararMascara(string mask, string texto)
        //    {
        //        List<string> AllMyChars = SacarCadaCaracter(mask);

        //        for (int i = 0; i < texto.Length; i++)
        //        {
        //            if (!AllMyChars.Contains(texto.Substring(i, 1)) || texto.Substring(i, 1) == "_")
        //            {
        //                //Mask sigue normal...
        //            }
        //            else
        //            {
        //                if (texto.Substring(i, 1) != " ")
        //                {
        //                    //Es un dígito o valor, significa que no está vacío...
        //                    return texto;
        //                }
        //            }
        //        }

        //        return mask;
        //    }

        //    //public void TextChangeTextBoxCustom(EventArgs e, Control EsteTextBox)
        //    //{

        //    //    int SelectionPosition = (EsteTextBox as TextBoxCustom).SelectionStart;
        //    //    if ((EsteTextBox as TextBoxCustom).TipoValidacion == Validacion.Cedula)
        //    //    {
        //    //        if (Validate((EsteTextBox as TextBoxCustom).Text, EsteTextBox))
        //    //        {
        //    //            lastValidValue = (EsteTextBox as TextBoxCustom).Text;
        //    //        }
        //    //        else
        //    //        {
        //    //            (EsteTextBox as TextBoxCustom).Text = lastValidValue;
        //    //        }

        //    //        string Formato = (EsteTextBox as TextBoxCustom).DefaultValue.Replace("9", "_").Replace("0", "_");
        //    //        if ((EsteTextBox as TextBoxCustom).SelectionStart > 0 && (EsteTextBox as TextBoxCustom).Text.Length > Formato.Length)
        //    //        {

        //    //            if (((EsteTextBox as TextBoxCustom).Text.Substring((EsteTextBox as TextBoxCustom).SelectionStart, 1) == "_" || char.IsDigit(Convert.ToChar((EsteTextBox as TextBoxCustom).Text.Substring((EsteTextBox as TextBoxCustom).SelectionStart, 1)))) && (EsteTextBox as TextBoxCustom).SelectionStart != (EsteTextBox as TextBoxCustom).Text.Length)
        //    //            {
        //    //                if (!ChanguingText)
        //    //                {
        //    //                    ChanguingText = true;

        //    //                    (EsteTextBox as TextBoxCustom).Text = (EsteTextBox as TextBoxCustom).Text.Remove((EsteTextBox as TextBoxCustom).SelectionStart, 1);

        //    //                }
        //    //                ChanguingText = false;
        //    //            }
        //    //            else if ((EsteTextBox as TextBoxCustom).Text.Substring((EsteTextBox as TextBoxCustom).SelectionStart, 1) != "_")
        //    //            {
        //    //                List<string> MyCharacters = SacarCadaCaracter(Formato);
        //    //                bool EsCaracterDeLaMascara = false;
        //    //                int PositionToErase = 0;
        //    //                for (int i = 0; !EsCaracterDeLaMascara; i++)
        //    //                {
        //    //                    EsCaracterDeLaMascara = true;
        //    //                    for (int j = 0; j < MyCharacters.Count; j++)
        //    //                    {
        //    //                        if ((EsteTextBox as TextBoxCustom).Text.Substring((EsteTextBox as TextBoxCustom).SelectionStart + PositionToErase, 1) == MyCharacters[j])
        //    //                        {
        //    //                            PositionToErase++;
        //    //                            EsCaracterDeLaMascara = false;
        //    //                        }
        //    //                    }
        //    //                }
        //    //                (EsteTextBox as TextBoxCustom).Text = (EsteTextBox as TextBoxCustom).Text.Substring(0, (EsteTextBox as TextBoxCustom).SelectionStart - 1) + (EsteTextBox as TextBoxCustom).Text.Substring((EsteTextBox as TextBoxCustom).SelectionStart, PositionToErase) + (EsteTextBox as TextBoxCustom).Text.Substring((EsteTextBox as TextBoxCustom).SelectionStart - 1, 1) + (EsteTextBox as TextBoxCustom).Text.Substring((EsteTextBox as TextBoxCustom).SelectionStart + (PositionToErase + 1), ((EsteTextBox as TextBoxCustom).Text.Length - ((EsteTextBox as TextBoxCustom).SelectionStart + (PositionToErase + 1))));
        //    //                SelectionPosition = SelectionPosition + PositionToErase;

        //    //            }

        //    //            (EsteTextBox as TextBoxCustom).SelectionStart = SelectionPosition;
        //    //        }
        //    //        else
        //    //        {
        //    //            if ((EsteTextBox as TextBoxCustom).Text.Length < Formato.Length)//addd a "_" because it erased...
        //    //            {
        //    //                if (!ChanguingText)
        //    //                {
        //    //                    ChanguingText = true;

        //    //                    if (Formato.Substring((EsteTextBox as TextBoxCustom).SelectionStart, 1) != "_")
        //    //                    {
        //    //                        (EsteTextBox as TextBoxCustom).Text = (EsteTextBox as TextBoxCustom).Text.Remove((EsteTextBox as TextBoxCustom).SelectionStart, 1).Insert((EsteTextBox as TextBoxCustom).SelectionStart, Formato.Substring((EsteTextBox as TextBoxCustom).SelectionStart, 1) + Formato.Substring((EsteTextBox as TextBoxCustom).SelectionStart + 1, 1));
        //    //                    }
        //    //                    else
        //    //                    {
        //    //                        (EsteTextBox as TextBoxCustom).Text = (EsteTextBox as TextBoxCustom).Text.Insert((EsteTextBox as TextBoxCustom).SelectionStart, "_");
        //    //                    }
        //    //                    (EsteTextBox as TextBoxCustom).SelectionStart = SelectionPosition;
        //    //                }
        //    //                ChanguingText = false;
        //    //            }
        //    //        }
        //    //    }

        //    //}

        //    public string FixMovedCharacters(string mask, string texto)
        //    {
        //        List<string> AllMyChars = SacarCadaCaracter(mask);
        //        for (int i = 0; i < mask.Length; i++)
        //        {
        //            if (texto.Substring(i, 1) != "_")
        //            {
        //                if (AllMyChars.Contains(texto.Substring(i, 1)))
        //                {
        //                    texto = texto.Remove(i, 1);
        //                    texto = texto.Insert(i, mask.Substring(i, 1));
        //                }
        //            }
        //        }
        //        return texto;
        //    }

        //    public string ColocarPrimerCaracterEnMayuscula(string OldString)
        //    {
        //        OldString = OldString.Substring(0, 1).ToUpper() + OldString.Substring(1, OldString.Length - 1);
        //        return OldString;
        //    }

        //    public bool ElDatasourceContieneElItemTal(DataTable myDataSource, string nombreColumna, string ItemTal)
        //    {
        //        bool SeEncuentraElItem = false;

        //        for (int i = 0; i < myDataSource.Rows.Count; i++)
        //        {
        //            if (myDataSource.Rows[i][nombreColumna].ToString() == ItemTal)
        //                SeEncuentraElItem = true;
        //        }

        //        return SeEncuentraElItem;
        //    }

        //    public bool IsValorNumerico(string texto)
        //    {
        //        try
        //        {
        //            texto = texto.Replace("$", "");
        //            double isNumeric = Convert.ToDouble(texto);
        //            return true;
        //        }
        //        catch
        //        {
        //            return false;
        //        }
        //    }

        //    public bool IsValorEntero(string texto)
        //    {
        //        try
        //        {
        //            texto = texto.Replace("$", "");
        //            long isNumeric = Convert.ToInt64(texto);
        //            return true;
        //        }
        //        catch
        //        {
        //            return false;
        //        }
        //    }

        //    public bool IsValorNumericoNegativo(string texto)
        //    {
        //        try
        //        {
        //            texto = texto.Replace("$", "");
        //            double isNumeric = Convert.ToDouble(texto);
        //            if (isNumeric < 0)
        //            {
        //                return true;
        //            }
        //            else
        //            {
        //                return false;
        //            }
        //        }
        //        catch
        //        {
        //            return false;
        //        }
        //    }

        //    public int StrToInt(string numero)
        //    {
        //        int numero_int;
        //        int.TryParse(numero, out numero_int);
        //        return numero_int;
        //    }

        //    public double StrToDouble(string numero)
        //    {
        //        double numero_double;
        //        double.TryParse(numero, out numero_double);
        //        return numero_double;
        //    }

        //    public double FixStrToDouble(string numero)
        //    {
        //        if (numero is null)
        //            return 0;

        //        string numeroReparado = "";
        //        for (int caracter = 0; caracter < numero.Length; caracter++)
        //        {
        //            if (Char.IsDigit(Convert.ToChar(numero.Substring(caracter, 1))) || Convert.ToChar(numero.Substring(caracter, 1)) == '.')
        //            {
        //                numeroReparado += numero.Substring(caracter, 1);
        //            }
        //            else if (caracter == 0 & Convert.ToChar(numero.Substring(caracter, 1)) == '-')
        //            {
        //                numeroReparado += numero.Substring(caracter, 1);
        //            }
        //        }

        //        numero = numeroReparado;
        //        double numero_double;
        //        double.TryParse(numero, out numero_double);
        //        return numero_double;
        //    }

        //    public string StrToNumbers(string cadena)
        //    {
        //        if (cadena is null)
        //            return "";

        //        string numeroReparado = "";
        //        for (int caracter = 0; caracter < cadena.Length; caracter++)
        //        {
        //            if (Char.IsDigit(Convert.ToChar(cadena.Substring(caracter, 1))))
        //            {
        //                numeroReparado += cadena.Substring(caracter, 1);
        //            }
        //        }
        //        return numeroReparado;
        //    }

        //    public decimal StrToDecimal(string numero)
        //    {
        //        decimal numero_double;
        //        decimal.TryParse(numero, out numero_double);
        //        return numero_double;
        //    }

        //    public Int64 StrToInt64(string numero)
        //    {
        //        Int64 numero_int;
        //        Int64.TryParse(numero, out numero_int);
        //        return numero_int;
        //    }

        //    public DateTime StrToDateTime(string fecha)
        //    {
        //        DateTime fechaParsed;
        //        DateTime.TryParse(fecha, out fechaParsed);
        //        return fechaParsed;
        //    }

        //    public DateTime FechaHora()
        //    {
        //        TimeZoneInfo zona = TimeZoneInfo.FindSystemTimeZoneById("Venezuela Standard Time");
        //        return TimeZoneInfo.ConvertTime(DateTime.Now, zona);
        //    }

        //    public ImageSource Base64ToImageSource(string base64)
        //    {
        //        try
        //        {
        //            byte[] Base64Stream = Convert.FromBase64String(base64);
        //            return ImageSource.FromStream(() => new MemoryStream(Base64Stream));
        //        }
        //        catch (Exception)
        //        {
        //            byte[] Base64Stream = Convert.FromBase64String(Configuracion.NoImageFound);
        //            return ImageSource.FromStream(() => new MemoryStream(Base64Stream));
        //        }
        //    }

        //    public async Task<bool> RevisarConexionAInternet(bool mostrarMensajes = false)
        //    {
        //        try
        //        {
        //            var cnx = CrossConnectivity.Current;
        //            msgConexionAInternet = "";

        //            if (cnx.IsConnected)
        //            {

        //                if (Device.RuntimePlatform == Device.iOS)
        //                {
        //                    BuenaConexionAInternet = true;
        //                    return BuenaConexionAInternet;
        //                }

        //                var tipoConexion = Plugin.Connectivity.Abstractions.ConnectionType.Cellular;
        //                string movilOWifi = cnx.ConnectionTypes.Contains(tipoConexion) ? "Móvil" : "Wifi";

        //                var capacidadMinima = 500000;
        //                var anchoDeBanda = cnx.Bandwidths;

        //                if (anchoDeBanda.Count() == 0)
        //                {
        //                    BuenaConexionAInternet = false;
        //                    msgConexionAInternet = $"No hay acceso a internet en su red {movilOWifi}...";
        //                }
        //                else
        //                {
        //                    if (anchoDeBanda.Max() >= (ulong)capacidadMinima)
        //                    {
        //                        BuenaConexionAInternet = true;
        //                    }
        //                    else
        //                    {
        //                        BuenaConexionAInternet = false;
        //                        msgConexionAInternet = $"Su conexión a Internet es deficiente, compruebe su conexión a internet e inténtelo de nuevo...";
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                BuenaConexionAInternet = false;
        //                msgConexionAInternet = $"Usted no está conectado a Internet...";
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            BuenaConexionAInternet = false;
        //            msgConexionAInternet = $"Error al comprobar su conexión a internet...";
        //        }

        //        if (!BuenaConexionAInternet && mostrarMensajes)
        //            MsgNormal(msgConexionAInternet);

        //        return BuenaConexionAInternet;
        //    }

        //    public ImageSource Base64ToCarImageSource(string base64)
        //    {
        //        try
        //        {
        //            byte[] Base64Stream = Convert.FromBase64String(base64);
        //            return ImageSource.FromStream(() => new MemoryStream(Base64Stream));
        //        }
        //        catch (Exception)
        //        {
        //            byte[] Base64Stream = Convert.FromBase64String(Configuracion.CarDefaultImage);
        //            return ImageSource.FromStream(() => new MemoryStream(Base64Stream));
        //        }
        //    }

        //    public Tuple<ImageSource, bool> Base64ToImageSourceIsCorrecta(string base64)
        //    {
        //        try
        //        {
        //            //Si el base64 recibido es muy pequeño descartarlo y usar la imagen por defecto...
        //            if (string.IsNullOrEmpty(base64) || base64.Length < 100)
        //            {
        //                byte[] Base64Stream = Convert.FromBase64String(Configuracion.NoImageFound);
        //                return Tuple.Create<ImageSource, bool>(ImageSource.FromStream(() => new MemoryStream(Base64Stream)), false);
        //            }
        //            else
        //            {
        //                byte[] Base64Stream = Convert.FromBase64String(base64);
        //                return Tuple.Create<ImageSource, bool>(ImageSource.FromStream(() => new MemoryStream(Base64Stream)), true);
        //            }
        //        }
        //        catch (Exception)
        //        {
        //            //Si hay un error en la converción usar la imagen por defecto...
        //            byte[] Base64Stream = Convert.FromBase64String(Configuracion.NoImageFound);
        //            return Tuple.Create<ImageSource, bool>(ImageSource.FromStream(() => new MemoryStream(Base64Stream)), false);
        //        }

        //    }

        //    public ImageSource Base64ToString(string base64)
        //    {
        //        try
        //        {
        //            byte[] Base64Stream = Convert.FromBase64String(base64);
        //            return ImageSource.FromStream(() => new MemoryStream(Base64Stream));
        //        }
        //        catch (Exception)
        //        {
        //            byte[] Base64Stream = Convert.FromBase64String(Configuracion.NoImageFound);
        //            return ImageSource.FromStream(() => new MemoryStream(Base64Stream));
        //        }

        //    }

        //    public byte[] ImageToByteArray(string imgSourcePath)
        //    {
        //        //file to base64 string
        //        return System.IO.File.ReadAllBytes(imgSourcePath);
        //    }

        //    public string ByteArrayToBase64(byte[] ByteArray)
        //    {
        //        return Convert.ToBase64String(ByteArray);
        //    }

        //    public string PathToBase64(string PathFileFrom)
        //    {
        //        if (PathFileFrom is null)
        //            return "Image not found...";
        //        return ByteArrayToBase64(ImageToByteArray(PathFileFrom));
        //    }

        //    #region Mensajes y Alertas

        //    public async void MsgNormal(Page pageSender, string msg, string buttonOkName = "OK", string title = "")
        //    {

        //        if (!Configuracion.LoggedIn && msg.ToLower().Contains("tiempo de espera agotado"))
        //            return;

        //        await pageSender.DisplayAlert(title, msg, buttonOkName);
        //    }

        //    public async void MsgNormal(string msg, string buttonOkName = "OK", string title = "")
        //    {
        //        if (!Configuracion.LoggedIn && msg.ToLower().Contains("tiempo de espera agotado"))
        //            return;

        //        await defaultParentPage.DisplayAlert(title, msg, buttonOkName);
        //    }

        //    public async Task<bool> MsgNormalAsync(string msg, string buttonOkName = "OK", string title = "")
        //    {
        //        if (!Configuracion.LoggedIn && msg.ToLower().Contains("tiempo de espera agotado"))
        //            return false;

        //        await defaultParentPage.DisplayAlert(title, msg, buttonOkName);
        //        return true;
        //    }

        //    public async Task<bool> MsgPregunta(Page pageSender, string msg, string buttonOkName = "ACEPTAR", string buttonCancelName = "CANCELAR", string title = "")
        //    {
        //        bool myResult = false;

        //        //Make the question...
        //        var result = await pageSender.DisplayAlert(title, msg, buttonOkName, buttonCancelName);
        //        if (result)
        //            myResult = true;
        //        else
        //            myResult = false;

        //        //Retrieve the answer...
        //        return myResult;
        //    }

        //    public async void MsgError(Page pageSender, string msg = "Error inesperado...", string buttonOkName = "OK", string title = "")
        //    {
        //        if (!msg.ToLower().Contains("tiempo de espera agotado"))
        //            await pageSender.DisplayAlert(title, msg, buttonOkName);
        //    }

        //    #endregion

        //    public async Task<bool> RevisarTiempoDeSesion(string msg)
        //    {
        //        if (!Configuracion.LoggedIn)
        //            return true;

        //        if (msg.ToLower().Contains("tiempo de espera agotado"))
        //        {
        //            Configuracion.LoggingOut = true;
        //            Configuracion.ReiniciarDatosDeUsuario();
        //            await Task.Delay(500);

        //            return false;
        //        }
        //        else return true;
        //    }

        //    #region ValidarControles

        //    public bool IsValidarControles(StackLayout containerLayout)
        //    {
        //        bool isValid = true;
        //        cEntry.firstInvalidxEntry = null;
        //        cPicker.firstInvalidxPicker = null;
        //        isValid = IsValidarControlesStackLayout(containerLayout);
        //        return isValid;
        //    }

        //    private bool IsValidarControlesStackLayout(StackLayout containerLayout)
        //    {
        //        //Variable global de validación (será falsa si por lo menos alguno de los controles no está validado correctamente)
        //        bool isValid = true;

        //        //Validar controles primarios...
        //        bool isValidated = true;
        //        foreach (var control in containerLayout.Children)
        //        {
        //            isValidated = true;

        //            if (control is cEntry)
        //                (control as cEntry).Validar(ref isValidated);
        //            else if (control is CleanEntry)
        //                (control as CleanEntry).Validar(ref isValidated);
        //            else if (control is cPicker)
        //                (control as cPicker).Validar(ref isValidated);
        //            else if (control is CleanPicker)
        //                (control as CleanPicker).Validar(ref isValidated);

        //            //De lo contrario significa que hay que usar recursividad para acceder a los layouts y a los grids...
        //            else
        //            {
        //                if (control is Grid)
        //                    isValidated = IsValidarControles(control as Grid);
        //                else if (control is Frame)
        //                    isValidated = IsValidarControles(control as Frame);
        //                else if (control is StackLayout)
        //                    isValidated = IsValidarControlesStackLayout(control as StackLayout);

        //            }

        //            isValid = !isValidated ? false : isValid;
        //        }

        //        return isValid;
        //    }

        //    private bool IsValidarControles(Grid ContainerGrid)
        //    {
        //        //Variable global de validación (será falsa si por lo menos alguno de los controles no está validado correctamente)
        //        bool isValid = true;

        //        //Validar controles primarios...
        //        bool isValidated = true;
        //        foreach (var control in ContainerGrid.Children)
        //        {
        //            isValidated = true;

        //            if (control is cEntry)
        //                (control as cEntry).Validar(ref isValidated);
        //            else if (control is cPicker)
        //                (control as cPicker).Validar(ref isValidated);

        //            //De lo contrario significa que hay que usar recursividad para acceder a los layouts y a los grids...
        //            else
        //            {
        //                if (control is Grid)
        //                    isValidated = IsValidarControles(control as Grid);
        //                else if (control is Frame)
        //                    isValidated = IsValidarControles(control as Frame);
        //                else if (control is StackLayout)
        //                    isValidated = IsValidarControlesStackLayout(control as StackLayout);
        //            }

        //            isValid = !isValidated ? false : isValid;
        //        }

        //        return isValid;
        //    }

        //    private bool IsValidarControles(Frame ContainerFrame)
        //    {
        //        //Variable global de validación (será falsa si por lo menos alguno de los controles no está validado correctamente)
        //        bool isValid = true;

        //        //Validar controles primarios...
        //        bool isValidated = true;
        //        foreach (var control in ContainerFrame.Children)
        //        {
        //            isValidated = true;

        //            if (control is cEntry)
        //                (control as cEntry).Validar(ref isValidated);
        //            else if (control is cPicker)
        //                (control as cPicker).Validar(ref isValidated);

        //            //De lo contrario significa que hay que usar recursividad para acceder a los layouts y a los grids...
        //            else
        //            {
        //                if (control is Grid)
        //                    isValidated = IsValidarControles(control as Grid);
        //                else if (control is Frame)
        //                    isValidated = IsValidarControles(control as Frame);
        //                else if (control is StackLayout)
        //                    isValidated = IsValidarControlesStackLayout(control as StackLayout);

        //            }

        //            isValid = !isValidated ? false : isValid;
        //        }

        //        return isValid;
        //    }

        //    #endregion

        public async Task<string> EjecutarSentenciaEnApiLibre(string urlPart, bool check = false)
        {
            string request = "";
            try
            {
                string url = Configuracion.ServerApi + urlPart;

                HttpClient clientHTTP = new HttpClient();
                var response = await clientHTTP.GetAsync(url);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    request = jsonString.ToString();
                }

            }
            catch (Exception ex)
            {
                UserDialogs.Instance.Toast("¡No se pudo establecer conexión con el servidor!. ");
            }
            return request;
        }

        public async Task<string> EjecutarMetodoPost(string parametros, string body_data)
        {
            try
            {
                string url = Configuracion.ServerApi + parametros;
/*                string bvody_data_formated = "\"" + body_data.Replace("\"", "\\" + "\"") + "\""*/;

                HttpClient client = new HttpClient();
                var content = new StringContent(body_data, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(url, content);
                var jsonString = await response.Content.ReadAsStringAsync();
                return jsonString.ToString();
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.Toast("¡No se pudo establecer conexión con el servidor!. ");
                throw ex;
            }
        }

        //    public async Task<string> EjecutarSentenciaEnApiParaSubirFoto(string Method)
        //    {
        //        string request = "Nothing from sever...";

        //        string sentencia = Configuracion.ServerApi + Method;

        //        var response = await usuarioFoto.GetAsync(sentencia);
        //        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        //        {
        //            var jsonString = await response.Content.ReadAsStringAsync();
        //            request = jsonString.ToString();
        //        }

        //        return request;
        //    }

        //    public Vehiculo GetVehiculoPorId(int idVehiculo)
        //    {
        //        //Obtener el vehiculo por el id recibido...
        //        foreach (Vehiculo car in Configuracion.vehiculos)
        //            if (car.id_vehiculo == idVehiculo)
        //                return car;

        //        return null;
        //    }

        //    public object GetPaisPorId(int id)
        //    {
        //        //Obtener el Municipio por el id recibido...
        //        foreach (Pais item in Configuracion.paises)
        //            if (item.id_pais == id)
        //                return item;

        //        return null;
        //    }

        //    public object GetProvinciaPorId(int id)
        //    {
        //        //Obtener el Provincia por el id recibido...
        //        foreach (Provincia item in Configuracion.provincias)
        //            if (item.id_provincia == id)
        //                return item;

        //        return null;
        //    }

        //    public object GetMunicipioPorId(int id)
        //    {
        //        //Obtener el Municipio por el id recibido...
        //        foreach (Municipio item in Configuracion.municipios)
        //            if (item.id_municipio == id)
        //                return item;

        //        return null;
        //    }

        //    public List<Provincia> GetProvinciasPorPais(int id_pais)
        //    {
        //        List<Provincia> provinciasQueCoinciden = new List<Provincia>();

        //        //LLenar una lista con los modelos que coinciden con la marca recibida...
        //        foreach (Provincia item in Configuracion.provincias)
        //            if (item.id_pais == id_pais)
        //                provinciasQueCoinciden.Add(item);

        //        return provinciasQueCoinciden;
        //    }

        //    public List<Municipio> GetMunicipiosPorProvincia(int id_provincia)
        //    {
        //        List<Municipio> MunicipiosQueCoinciden = new List<Municipio>();

        //        //LLenar una lista con los modelos que coinciden con la marca recibida...
        //        foreach (Municipio item in Configuracion.municipios)
        //            if (item.id_provincia == id_provincia)
        //                MunicipiosQueCoinciden.Add(item);

        //        return MunicipiosQueCoinciden;
        //    }

        //    public List<object> GetObjectListPorFiltro(List<object> completeList, List<object> emptyList, string parameterName, string parameterFilter)
        //    {
        //        //Obtener el vehiculo por el id recibido...
        //        foreach (object item in completeList)
        //        {
        //            var propertiesOfList = item.GetType().GetProperties();
        //            foreach (var prop in propertiesOfList)
        //            {
        //                if (prop.Name == parameterName)
        //                {
        //                    if (prop.GetValue(item).ToString() == parameterFilter)
        //                    {
        //                        emptyList.Add(item);
        //                        break;
        //                    }
        //                }
        //            }
        //        }

        //        return emptyList;
        //    }

        //    public async Task<Vehiculo> ModificarVehiculoPorId(int idVehiculo, Vehiculo vehiculoModificado)
        //    {
        //        //Obtener el vehiculo por el id recibido...
        //        PropertyInfo[] PropertiesActualCar;
        //        PropertyInfo[] PropertiesNewCar = vehiculoModificado.GetType().GetProperties();
        //        foreach (Vehiculo car in Configuracion.vehiculos)
        //            if (car.id_vehiculo == idVehiculo)
        //            {
        //                PropertiesActualCar = car.GetType().GetProperties();
        //                foreach (var propActual in PropertiesActualCar)
        //                {
        //                    foreach (var propNuevo in PropertiesNewCar)
        //                    {
        //                        if (propActual.Name == propNuevo.Name)
        //                            propActual.SetValue(car, propNuevo.GetValue(vehiculoModificado));
        //                    }
        //                }

        //            }

        //        return null;
        //    }

        //    public Marca GetMarcaPorId(int idMarca)
        //    {
        //        //Obtener la marca que coincide con el id de marca recibido...
        //        foreach (Marca marca in Configuracion.marcas)
        //            if (marca.id_marca == idMarca)
        //                return marca;

        //        return null;
        //    }

        //    public Sexo GetSexoPorId(int idSexo)
        //    {
        //        //Obtener la marca que coincide con el id de marca recibido...
        //        foreach (Sexo sexo in Configuracion.sexos)
        //            if (sexo.id_sexo == idSexo)
        //                return sexo;

        //        return null;
        //    }

        //    public Modelo1 GetModeloPorID(int idModelo)
        //    {
        //        //Obtener la marca que coincide con el id de marca recibido...
        //        foreach (Modelo1 modelo in Configuracion.modelos)
        //            if (modelo.id_modelo == idModelo)
        //                return modelo;

        //        return null;
        //    }

        //    public List<Modelo1> GetModelosPorIdMarca(int idMarca)
        //    {
        //        List<Modelo1> modelosQueCoinciden = new List<Modelo1>();

        //        //LLenar una lista con los modelos que coinciden con la marca recibida...
        //        foreach (Modelo1 modelo in Configuracion.modelos)
        //            if (modelo.id_marca == idMarca)
        //                modelosQueCoinciden.Add(modelo);

        //        return modelosQueCoinciden;
        //    }

        //    public async Task ParpadeoImagen(CircleImage image, int delay, int times, Color errColor)
        //    {
        //        //Efecto de parpadeo y vibración...
        //        Color savedColor = image.BorderColor;
        //        Thickness savedTickness = image.Margin;
        //        for (int i = 0; i < times; i++)
        //        {
        //            image.BorderColor = errColor;
        //            image.Margin = new Thickness(image.Margin.Left + 5, image.Margin.Top, image.Margin.Right, image.Margin.Bottom);
        //            await Task.Delay(delay);

        //            image.BorderColor = savedColor;
        //            image.Margin = new Thickness(image.Margin.Left - 10, image.Margin.Top, image.Margin.Right, image.Margin.Bottom);
        //            await Task.Delay(delay);
        //        }
        //        image.Margin = savedTickness;
        //    }

        //    public List<object> LlenarLista(DataTable dt, object clase)
        //    {
        //        List<object> usuarios = new List<object>();
        //        Type thisType = clase.GetType();
        //        MethodInfo theMethod = thisType.GetMethod("Clone");
        //        var newReset = new object();
        //        var properties = clase.GetType().GetProperties();

        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            newReset = theMethod.Invoke(clase, null);
        //            foreach (var Prop in properties)
        //            {
        //                for (int x = 0; x < dt.Columns.Count; x++)
        //                {
        //                    if (Prop.Name == dt.Columns[x].ColumnName)
        //                    {
        //                        Prop.SetValue(newReset, dt.Rows[i][x].ToString());
        //                    }
        //                }
        //            }
        //            usuarios.Add(newReset);

        //        }
        //        return usuarios;
        //    }

        //    public string[] SplitByMaximunPortionSize(string texto, int portionMaximunSize, bool replaceDiagonal = false)
        //    {
        //        int parts = DivideRoundingUp(texto.Length, portionMaximunSize);
        //        if (replaceDiagonal)
        //            texto = texto.Replace("/", "*");

        //        string[] result = new string[parts];
        //        int position = 0;

        //        while (texto.Length > 0)
        //        {
        //            while (texto.Length >= portionMaximunSize)
        //            {
        //                result[position] = texto.Substring(0, portionMaximunSize);
        //                texto = texto.Remove(0, portionMaximunSize);
        //                position++;
        //            }

        //            //Last Portion
        //            result[position] = texto.Substring(0, texto.Length);
        //            texto = "";

        //        }

        //        return result;
        //    }

        //    public static int DivideRoundingUp(int x, int y)
        //    {
        //        // TODO: Define behaviour for negative numbers
        //        int remainder;
        //        int quotient = Math.DivRem(x, y, out remainder);
        //        return remainder == 0 ? quotient : quotient + 1;
        //    }

        //    public string GenerarClave(int longitudPassword)
        //    {

        //        Random rnd = new Random();
        //        string Password = "";

        //        for (int i = 0; i < longitudPassword; i++)
        //        {
        //            Password = Password + (rnd.Next(1, 10).ToString());
        //        }

        //        return Password;

        //    }

        //    public string GetFileNameFromImageControl(Image imgWorking)
        //    {
        //        var source = imgWorking.Source as FileImageSource;

        //        if (source != null)
        //            return source.File;
        //        else
        //            return null;
        //    }

        //    public string GetFileNameFromImageControl(CircleImage imgWorking)
        //    {
        //        var source = imgWorking.Source as FileImageSource;

        //        if (source != null)
        //            return source.File;
        //        else
        //            return null;
        //    }

        //    public bool IsNumeroMayorQueCero(string textoToWork)
        //    {
        //        try
        //        {
        //            return Convert.ToInt64(textoToWork) > 0 ? true : false;
        //        }
        //        catch
        //        {
        //            return false;
        //        }
        //    }

        //    #region Seleccionar Imagen

        //    public async void SeleccionarOTomarFoto(Page senderPage, string titulo, string cancelButton, CircleImage imgToWork)
        //    {

        //        switch (Device.RuntimePlatform)
        //        {
        //            case Device.iOS:
        //                UserDialogs.Instance.ActionSheet(new ActionSheetConfig()
        //                                                 .SetTitle(titulo)
        //                                                 .Add("Tomar Foto", () => TakePhotoAsync(senderPage, imgToWork))
        //                                                 .Add("Seleccionar foto", () => PickPhotoAsync(senderPage, imgToWork)).SetCancel(cancelButton)
        //                                                 );
        //                break;

        //            case Device.Android:
        //                UserDialogs.Instance.ActionSheet(new ActionSheetConfig()
        //                                                 .SetTitle(titulo)
        //                                                 .Add("Tomar Foto", () => TakePhotoAsync(senderPage, imgToWork), "camera.png")
        //                                                 .Add("Seleccionar foto", () => PickPhotoAsync(senderPage, imgToWork), "gallery.png").SetCancel(cancelButton)
        //                                                 );
        //                break;
        //        }

        //    }

        //    private async void PickPhotoAsync(Page senderPage, CircleImage imgToWork)
        //    {
        //        try
        //        {

        //            fileSelectedPath = null;

        //            if (Device.RuntimePlatform == Device.Android)
        //            {
        //                await RequestThisPermision(Permiso.Galeria);
        //            }
        //            else
        //            {
        //                if (!await RequestThisPermision(Permiso.Galeria))
        //                {
        //                    MsgNormal(senderPage, "Permiso denegado, no se puede acceder a la galería");
        //                    return;
        //                }
        //            }

        //            if (Device.RuntimePlatform == Device.Android)
        //            {


        //                if (!CrossMedia.Current.IsPickPhotoSupported)
        //                {
        //                    MsgNormal(senderPage, "Este dispositivo no puede seleccionar imágenes", "OK");
        //                    return;
        //                }
        //                else
        //                {
        //                    try
        //                    {

        //                        //Check for Media Library Permisions
        //                        var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Plugin.Permissions.Abstractions.Permission.MediaLibrary);

        //                    PickPicture:
        //                        if (status == Plugin.Permissions.Abstractions.PermissionStatus.Granted)
        //                        {

        //                            var file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
        //                            {
        //                                CompressionQuality = 75,
        //                                CustomPhotoSize = 100,
        //                                PhotoSize = PhotoSize.MaxWidthHeight,
        //                                MaxWidthHeight = 300
        //                            });

        //                            if (file == null)
        //                                return;
        //                            else
        //                            {
        //                                while (fileSelectedPath == null)
        //                                    fileSelectedPath = file.Path;

        //                                imgToWork.Source = ImageSource.FromStream(() => file.GetStream());
        //                            }
        //                        }
        //                        else
        //                        {
        //                            await CrossPermissions.Current.RequestPermissionsAsync(Plugin.Permissions.Abstractions.Permission.MediaLibrary);
        //                            var statusTwo = await CrossPermissions.Current.CheckPermissionStatusAsync(Plugin.Permissions.Abstractions.Permission.MediaLibrary);

        //                            if (status == Plugin.Permissions.Abstractions.PermissionStatus.Granted)
        //                                goto PickPicture;
        //                            else
        //                                return;
        //                        }
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        MsgNormal(senderPage, "Permiso denegado, no se puede acceder a la galería");
        //                        return;
        //                    }
        //                }

        //            }
        //            else
        //            {
        //                await CrossMedia.Current.Initialize();

        //                var cameraStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);
        //                var storageStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);
        //                var photoLibraryStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.MediaLibrary);

        //                while (cameraStatus != PermissionStatus.Granted && storageStatus != PermissionStatus.Granted && photoLibraryStatus != PermissionStatus.Granted)
        //                {
        //                    var cameraStatus1 = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Camera);
        //                    var storageStatus1 = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Storage);
        //                    var photoLibrary = await CrossPermissions.Current.RequestPermissionsAsync(Permission.MediaLibrary);

        //                    cameraStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);
        //                    storageStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);
        //                    photoLibraryStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.MediaLibrary);
        //                }

        //                if (!CrossMedia.Current.IsPickPhotoSupported)
        //                {
        //                    MsgNormal("Photos Not Supported", ":( Permission not granted to photos.", "OK");
        //                    return;
        //                }
        //                var file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
        //                {
        //                    CompressionQuality = 75,
        //                    CustomPhotoSize = 100,
        //                    PhotoSize = PhotoSize.MaxWidthHeight,
        //                    MaxWidthHeight = 300
        //                });

        //                if (file == null)
        //                    return;

        //                imgToWork.Source = ImageSource.FromStream(() =>
        //                {

        //                    while (fileSelectedPath == null)
        //                        fileSelectedPath = file.Path;

        //                    var stream = file.GetStream();
        //                    return stream;
        //                });

        //            }
        //        }
        //        catch (Exception)
        //        {
        //            return;
        //        }
        //    }

        //    private async void TakePhotoAsync(Page senderPage, CircleImage imgToWork)
        //    {

        //        try
        //        {
        //            fileSelectedPath = null;

        //            if (Device.RuntimePlatform == Device.Android)
        //            {
        //                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
        //                {
        //                    MsgNormal(senderPage, "No hay cámara disponible", "OK", "Cámara");
        //                    return;
        //                }

        //                //Check for Camera Permisions
        //                await CrossPermissions.Current.RequestPermissionsAsync(Plugin.Permissions.Abstractions.Permission.Camera);

        //                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
        //                {
        //                    CompressionQuality = 75,
        //                    CustomPhotoSize = 100,
        //                    DefaultCamera = CameraDevice.Front,
        //                    PhotoSize = PhotoSize.MaxWidthHeight,
        //                    MaxWidthHeight = 300
        //                });

        //                if (file == null)
        //                    return;
        //                else
        //                {
        //                    while (fileSelectedPath == null)
        //                        fileSelectedPath = file.Path;

        //                    imgToWork.Source = ImageSource.FromStream(() => file.GetStream());

        //                }

        //            }
        //            else
        //            {
        //                await CrossMedia.Current.Initialize();

        //                var cameraStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);
        //                var storageStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);
        //                var photoLibraryStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.MediaLibrary);

        //                while (cameraStatus != PermissionStatus.Granted && storageStatus != PermissionStatus.Granted && photoLibraryStatus != PermissionStatus.Granted)
        //                {
        //                    var cameraStatus1 = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Camera);
        //                    var storageStatus1 = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Storage);
        //                    var photoLibrary = await CrossPermissions.Current.RequestPermissionsAsync(Permission.MediaLibrary);

        //                    cameraStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);
        //                    storageStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);
        //                    photoLibraryStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.MediaLibrary);
        //                }

        //                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
        //                {
        //                    MsgNormal("No Camera", ":( No camera available.", "OK");
        //                    return;
        //                }

        //                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
        //                {
        //                    DefaultCamera = Plugin.Media.Abstractions.CameraDevice.Front,
        //                    CompressionQuality = 75,
        //                    CustomPhotoSize = 100,
        //                    PhotoSize = PhotoSize.MaxWidthHeight,
        //                    MaxWidthHeight = 300
        //                });

        //                if (file == null)
        //                    return;

        //                imgToWork.Source = ImageSource.FromStream(() =>
        //                {

        //                    while (fileSelectedPath == null)
        //                        fileSelectedPath = file.Path;

        //                    var stream = file.GetStream();
        //                    return stream;
        //                });
        //            }

        //        }
        //        catch (Exception ex)
        //        {
        //        }

        //    }

        //    public async Task<bool> RequestThisPermision(Permiso permiso)
        //    {
        //        if (busy)
        //            return false;

        //        busy = true;

        //        var status = PermissionStatus.Unknown;
        //        switch (permiso)
        //        {
        //            case Permiso.Camara:
        //                status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);
        //                break;
        //            case Permiso.Galeria:
        //                status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Photos);
        //                break;
        //        }

        //        if (status != PermissionStatus.Granted)
        //        {
        //            switch (permiso)
        //            {
        //                case Permiso.Camara:
        //                    status = await Utils.CheckPermissions(Permission.Camera);
        //                    break;
        //                case Permiso.Galeria:
        //                    status = await Utils.CheckPermissions(Permission.Photos);
        //                    break;
        //            }
        //        }

        //        busy = false;
        //        return status == PermissionStatus.Granted ? true : false;
        //    }

        //    #endregion

        //    #region METODOS PARA ENCRIPTAR
        //    /// Encripta una cadena
        //    public string Encriptar(string _cadenaAencriptar)
        //    {
        //        string result = string.Empty;
        //        byte[] encryted = System.Text.Encoding.Unicode.GetBytes(_cadenaAencriptar);
        //        result = Convert.ToBase64String(encryted);
        //        return result;
        //    }

        //    /// Esta función desencripta la cadena que le envíamos en el parámentro de entrada.
        //    public string DesEncriptar(string _cadenaAdesencriptar)
        //    {
        //        string result = string.Empty;
        //        byte[] decryted = Convert.FromBase64String(_cadenaAdesencriptar);
        //        //result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
        //        result = System.Text.Encoding.Unicode.GetString(decryted);
        //        return result;
        //    }
        //    #endregion

        //    public async Task<bool> SubirImagen(int idDeLaEntidad, string fotoEnBase64, ContextoDeFoto contexto)
        //    {
        //        try
        //        {

        //            //New Method / Ermes Jeff
        //            //Stuff for Upload the vehicles images...
        //            if (fotoEnBase64.Length > 75)
        //            {
        //                using (var dlg = UserDialogs.Instance.Progress("Subiendo Imagen...", null, null, true, MaskType.Black))
        //                {
        //                    //Preparar la imagen para ser subida
        //                    string[] paquete = SplitByMaximunPortionSize(fotoEnBase64.Substring(1, fotoEnBase64.Length - 2).Replace("+", "MASPLUS"), 226, true);
        //                    decimal porcientoCadaPaquete = 100m / Convert.ToDecimal(paquete.Length);
        //                    decimal porcierntoEntero = 0m;

        //                    //Primer Carcater
        //                    string primerCaracter = fotoEnBase64.Substring(0, 1).Replace("+", "MASPLUS");
        //                    primerCaracter = primerCaracter.Replace("/", "*");

        //                    //Ultimo Caracter
        //                    string ultimoCaracter = fotoEnBase64.Substring(fotoEnBase64.Length - 1, 1).Replace("+", "MASPLUS");
        //                    ultimoCaracter = ultimoCaracter.Replace("/", "*");

        //                    //Variables to control the Package submition...
        //                    int timeout = 0;
        //                    int timeoutLimit = 50;
        //                    bool resendPackage = true;
        //                    var result = "";

        //                    //Subir primera parte de la foto...
        //                    timeout = 0;
        //                    while (resendPackage)
        //                    {
        //                        result = await EjecutarSentenciaEnApiLibre($"{(contexto == ContextoDeFoto.vehiculo ? "FotoVehiculo" : "FotoCliente")}/{idDeLaEntidad},{primerCaracter},S,{Configuracion.key}", false);
        //                        if (result == "1")
        //                            resendPackage = false;

        //                        //Break on Timeout reach Limit times...
        //                        if (timeout >= timeoutLimit)
        //                            return false;
        //                        else
        //                            timeout++;

        //                    }

        //                    //Aumentar porcentage completado en el Progress Dialog
        //                    porcierntoEntero += porcientoCadaPaquete;
        //                    dlg.PercentComplete = Convert.ToInt32(porcierntoEntero);

        //                    //Subir segunda parte...
        //                    resendPackage = true;
        //                    for (int i = 0; i < (paquete.Length); i++)
        //                    {

        //                        timeout = 0;
        //                        while (resendPackage)
        //                        {
        //                            result = await EjecutarSentenciaEnApiParaSubirFoto($"{(contexto == ContextoDeFoto.vehiculo ? "FotoVehiculo" : "FotoCliente")}/{idDeLaEntidad},{paquete[i]},N,a");
        //                            if (result == "1")
        //                                resendPackage = false;

        //                            //Break on Timeout reach Limit times...
        //                            if (timeout >= timeoutLimit)
        //                                return false;
        //                            else
        //                                timeout++;

        //                        }
        //                        resendPackage = true;

        //                        //Aumentar porcentage completado en el Progress Dialog
        //                        porcierntoEntero += porcientoCadaPaquete;
        //                        dlg.PercentComplete = Convert.ToInt32(porcierntoEntero);
        //                    }

        //                    //Enviar la última parte con la {F} de finalizado...
        //                    timeout = 0;
        //                    while (resendPackage)
        //                    {
        //                        result = await EjecutarSentenciaEnApiLibre($"{(contexto == ContextoDeFoto.vehiculo ? "FotoVehiculo" : "FotoCliente")}/{idDeLaEntidad},{ultimoCaracter},F,{Configuracion.key}", false);
        //                        if (result == "1")
        //                            resendPackage = false;

        //                        //Break on Timeout reach Limit times...
        //                        if (timeout >= timeoutLimit)
        //                            return false;
        //                        else
        //                            timeout++;

        //                    }

        //                    //Completar el Progress Dialog                    
        //                    dlg.PercentComplete = 100;
        //                }
        //            }

        //            return true;
        //        }
        //        catch (Exception)
        //        {
        //            return false;
        //        }

        //    }

        //    public async void Appear(CircleImage control, int speed = 50, double increaseAmmount = 0.25)
        //    {
        //        //regulate Speed...
        //        if (speed > 100)
        //            speed = 100;
        //        if (speed < 0)
        //            speed = 0;

        //        //Delay calculation
        //        int delay = 110 - speed;

        //        while (control.Opacity < 1)
        //        {
        //            control.Opacity += increaseAmmount;
        //            await Task.Delay(delay);
        //        }
        //    }

        //    public async void Appear(Layout control, int speed = 100, double increaseAmmount = 0.05)
        //    {
        //        //regulate Speed...
        //        if (speed > 100)
        //            speed = 100;
        //        if (speed < 0)
        //            speed = 0;

        //        //Delay calculation
        //        int delay = 106 - speed;

        //        while (control.Opacity < 1)
        //        {
        //            control.Opacity += increaseAmmount;
        //            await Task.Delay(delay);
        //        }
        //    }

        //    public static string EncriptarConContraseña(string key, string texto_plano)
        //    {
        //        byte[] iv = new byte[16];
        //        byte[] array;
        //        using (Aes aes = Aes.Create())
        //        {
        //            aes.Key = Encoding.UTF8.GetBytes(key);
        //            aes.IV = iv;
        //            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
        //            using (MemoryStream memoryStream = new MemoryStream())
        //            {
        //                using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
        //                {
        //                    using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
        //                    {
        //                        streamWriter.Write(texto_plano);
        //                    }

        //                    array = memoryStream.ToArray();
        //                }
        //            }
        //        }

        //        return Convert.ToBase64String(array);
        //    }

        //    public static string DesencriptarConContraseña(string key, string texto_plano)
        //    {
        //        byte[] iv = new byte[16];
        //        byte[] buffer = Convert.FromBase64String(texto_plano);
        //        using (Aes aes = Aes.Create())
        //        {
        //            aes.Key = Encoding.UTF8.GetBytes(key);
        //            aes.IV = iv;
        //            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
        //            using (MemoryStream memoryStream = new MemoryStream(buffer))
        //            {
        //                using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
        //                {
        //                    using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
        //                    {
        //                        return streamReader.ReadToEnd();
        //                    }
        //                }
        //            }
        //        }
        //    }

    }

    public enum Permiso
    {
        Camara,
        Galeria,
        Telefono
    }

    public enum ContextoDeFoto
    {
        cliente,
        vehiculo
    }

    public class RequestResult
    {
        public bool ResultStatus { get; set; }
        public string String_Result { get; set; }
    }


}

