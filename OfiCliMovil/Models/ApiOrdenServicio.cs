using Newtonsoft.Json;
using OfiCliMovil.Models.Entidad;
using OfiCliMovil.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using OfiCliMovil.Models;

namespace OfiCliMovil.Models
{
    public class ApiOrdenServicio
    {
        Herramientas herramientas = new Herramientas();
        public ApiOrdenServicio()
        {
            // constructor
        }


        public async Task<EClienteFull> IniciarSesion(string cedula, string clave)
        {
            var result = await herramientas.EjecutarSentenciaEnApiLibre($"Cliente/IniciarSesion/{cedula}/{clave}");
            var apiResult = Newtonsoft.Json.JsonConvert.DeserializeObject<EClienteFull>(result);
            return apiResult;
        }

        //public async Task<List<EFactura>> GetListadoDeBalancePendienteAsync(int idCliente)
        //{
        //    List<EFactura> facturas = new List<EFactura>();


        //    var result = await herramientas.EjecutarSentenciaEnApiLibre($"Cliente/ObtenerFacturasPendiente/{idCliente}");
        //    facturas = Newtonsoft.Json.JsonConvert.DeserializeObject<List<EFactura>>(result);


        //    return facturas;
        //} // Fin del método ObtenerMenu


        public async Task<List<EFactura>> GetListadoDeBalancePendiente(int idCliente)
        {

            var result = await herramientas.EjecutarSentenciaEnApiLibre($"Cliente/ObtenerFacturasPendiente/{idCliente}");
            var listado_de_ordenes_servicio = Newtonsoft.Json.JsonConvert.DeserializeObject<List<EFactura>>(result);

            return listado_de_ordenes_servicio;
        } // Fin del método ObtenerMenu

        public async Task<List<ETarjetas>> GetTarjetas(int idCliente)
        {

            var result = await herramientas.EjecutarSentenciaEnApiLibre($"Cliente/ObtenerListadoTarjetas/{idCliente}");
            var listado_de_tarjetas = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ETarjetas>>(result);

            return listado_de_tarjetas;
        } // Fin del método ObtenerMenu


        public async Task<List<ERecibo>> GetListadoDePagosRealizados(int idCliente)
        {

            var result = await herramientas.EjecutarSentenciaEnApiLibre($"Cliente/ObtenerPagosRealizados/{idCliente}");
            var listado_de_ordenes_servicio = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ERecibo>>(result);

            return listado_de_ordenes_servicio;
        } // Fin del método ObtenerMenu


        public async Task<List<EOrdenes>> GetHistorialOrdenes(int idCliente)
        {

            var result = await herramientas.EjecutarSentenciaEnApiLibre($"Cliente/ObtenerHistorialOrdenes/{idCliente}");
            var listado_de_ordenes_servicio = Newtonsoft.Json.JsonConvert.DeserializeObject<List<EOrdenes>>(result);

            return listado_de_ordenes_servicio;
        } // Fin del método ObtenerMenu


        public async Task<List<EOrdenes>> GetListadoDeEquiposCable(int idCliente)
        {

            var result = await herramientas.EjecutarSentenciaEnApiLibre($"Cliente/ObtenerEquiposCable/{idCliente}");
            var listado_de_equipos_cable = Newtonsoft.Json.JsonConvert.DeserializeObject<List<EOrdenes>>(result);

            return listado_de_equipos_cable;
        } // Fin del método ObtenerMenu


        public async Task<List<EOrdenes>> GetListadoDeEquiposInternet(int idCliente)
        {

            var result = await herramientas.EjecutarSentenciaEnApiLibre($"Cliente/ObtenerEquiposInternet/{idCliente}");
            var listado_de_equipos_internet = Newtonsoft.Json.JsonConvert.DeserializeObject<List<EOrdenes>>(result);

            return listado_de_equipos_internet;
        } // Fin del




        public async Task<EClienteFull> RecuperarClave(string cedula)
        {
            var respuesta = await herramientas.EjecutarSentenciaEnApiLibre($"/Cliente/RecuperarClave/{cedula}");
            var cliente = Newtonsoft.Json.JsonConvert.DeserializeObject<EClienteFull>(respuesta);
            return cliente;
        }


        public async Task<Result> CrearAveria(EOrdenes ordenes)
        {
            var body_data = JsonConvert.SerializeObject(ordenes);
            var result = await herramientas.EjecutarMetodoPost($"Cliente/crearaveria", body_data);
            var apiResult = Newtonsoft.Json.JsonConvert.DeserializeObject<Result>(result);
            return apiResult;
        }

  



        //public async Task<List<OrdenServi>> GetListadoDeOrdenes(int tiposervicio, int tecnico, string progresoorden, string sector)
        //{

        //    var result = await herramientas.EjecutarSentenciaEnApiLibre($"ofitec/ConsultarListadoDeOrdenes/{tiposervicio}/{tecnico}/{progresoorden}/{sector}");
        //    var listado_de_ordenes_servicio = Newtonsoft.Json.JsonConvert.DeserializeObject<List<OrdenServi>>(result);

        //    return listado_de_ordenes_servicio;
        //} // Fin del método ObtenerMenu

        //public async Task<Result> ActualizarOrden(int tiposervicio, int numero, string progreso_orden, string reportetecnico, string servicio)
        //{

        //    reportetecnico = reportetecnico.Replace("/", " ");
        //    string url = $"ofitec/ActualizarOrden?" +
        //     $"tiposervicio={tiposervicio}" +
        //     $"&numero={numero}" +
        //     $"&progreso_orden={progreso_orden}" +
        //     $"&reportetecnico={reportetecnico}" +
        //     $"&servicio={servicio}";
        //    var result = await herramientas.EjecutarSentenciaEnApiLibre(url);

        //    var response = Newtonsoft.Json.JsonConvert.DeserializeObject<Result>(result);
        //    return response;
        //}
        //public async Task<Result> SetHistorialProgresoOrden(int numero, int numero_ordencable, int numero_ordeninternet, string progreso_orden, string fecha, string lat, string lng)
        //{

        //    string url = $"ofitec/SetHistorialProgresoOrden?" +
        //     $"numero={numero}" +
        //     $"&numero_ordencable={numero_ordencable}" +
        //     $"&numero_ordeninternet={numero_ordeninternet}" +
        //     $"&progreso_orden={progreso_orden}" +
        //     $"&fecha={fecha}" +
        //     $"&lat={lat}" +
        //     $"&lng={lng}";
        //    var result = await herramientas.EjecutarSentenciaEnApiLibre(url);

        //    var response = Newtonsoft.Json.JsonConvert.DeserializeObject<Result>(result);
        //    return response;
        //}

        //public async Task<List<CantidadOrdenProgreso>> ConsultarCantidadOrdenesProgreso(int id_tecnico)
        //{
        //    var result = await herramientas.EjecutarSentenciaEnApiLibre($"ofitec/ConsultarCantidadOrdenesProgreso/{id_tecnico}");

        //    var response = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CantidadOrdenProgreso>>(result);
        //    return response;
        //}

        //public async Task<List<OrdenServi>> GetListadoDeOrdenes(int tiposervicio, int id_tecnico, string progreso_orden, DateTime desde, DateTime hasta)
        //{
        //    string fechas = desde.ToString("yyyy-MM-dd") + "/" + hasta.ToString("yyyy-MM-dd");
        //    var result = await herramientas.EjecutarSentenciaEnApiLibre($"ofitec/ConsultarListadoDeOrdenesPorFechas/{tiposervicio}/{id_tecnico}/{progreso_orden}/{fechas}");

        //    var listado_de_ordenes_servicio = Newtonsoft.Json.JsonConvert.DeserializeObject<List<OrdenServi>>(result);

        //    return listado_de_ordenes_servicio;
        //}

        //public async Task<Tecnico> CambiarContrasena(int id_tecnico, string clave)
        //{
        //    var result = await herramientas.EjecutarSentenciaEnApiLibre($"/ofitec/cambiarclave/{id_tecnico}/{clave}");
        //    var tecnico = Newtonsoft.Json.JsonConvert.DeserializeObject<Tecnico>(result);

        //    return tecnico;
        //}

        //public async Task<Result> SetFacturaTemporal(List<Producto> listadodeproductosinventario, int IDFacturaTemporal)
        //{
        //    var body_data = JsonConvert.SerializeObject(listadodeproductosinventario);
        //    var result = await new Herramientas().EjecutarMetodoPost(
        //       $"ofitec/GuardarDetalleFacturaTemporal?id_factura_temporal={IDFacturaTemporal}", body_data);
        //    return new Result { Respuesta = "OK", Mensaje = result };
        //}



        //public async Task<Tuple<string, List<Producto>>> GetListadoDeProductosPorOrden(int numero_orden_general)
        //{
        //    try
        //    {
        //        var result = await herramientas.EjecutarSentenciaEnApiLibre($"ofitec/ListadoDeProductosPorOrdenes/{numero_orden_general}");
        //        var listado_de_productos = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Producto>>(result);

        //        List<Producto> lista = new List<Producto>();
        //        return new Tuple<string, List<Producto>>("True", listado_de_productos);
        //    }
        //    catch (Exception ex)
        //    {
        //        List<Producto> lista = new List<Producto>();
        //        return new Tuple<string, List<Producto>>("Error. " + ex.Message, lista);
        //    }
        //} // Fin del método 

        //public async Task<Tuple<string, List<Producto>>> ConsultarListadoDeProductosPorSector(int id_sector, string estado, string serviciotecnico)
        //{
        //    try
        //    {
        //        var result = await herramientas.EjecutarSentenciaEnApiLibre($"ofitec/ConsultarListadoDeProductosPorSector/{id_sector}/{"A"}{"S"}");
        //        var listado_de_productos = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Producto>>(result);

        //        List<Producto> lista = new List<Producto>();
        //        return new Tuple<string, List<Producto>>("True", listado_de_productos);
        //    }
        //    catch (Exception ex)
        //    {
        //        List<Producto> lista = new List<Producto>();
        //        return new Tuple<string, List<Producto>>("Error. " + ex.Message, lista);
        //    }
        //} // Fin del método 

        //public async Task<Tuple<string, List<Sectores>>> GetListadoDeSectores()
        //{
        //    try
        //    {
        //        var result = await herramientas.EjecutarSentenciaEnApiLibre($"ofitec/ConsultarSectores");
        //        var listado_de_sectores = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Sectores>>(result);

        //        return new Tuple<string, List<Sectores>>("True", listado_de_sectores);
        //    }
        //    catch (Exception ex)
        //    {
        //        List<Sectores> lista = new List<Sectores>();

        //        return new Tuple<string, List<Sectores>>("Error. " + ex.Message, lista);
        //    }
        //} // Fin del método 

        //public async Task<Result> ActualizarLocalizacion(int codigo_cli, string lat, string lng)
        //{

        //    string url = $"ofitec/ActualizarLocalizacion/{codigo_cli}/{lat}/{lng}";
        //    var result = await herramientas.EjecutarSentenciaEnApiLibre(url);

        //    var response = Newtonsoft.Json.JsonConvert.DeserializeObject<Result>(result);
        //    return response;
        //}

        //public async Task<ResultValidarImei> IimeiOfitec(string imei, DateTime fecha_hora, string aplicacion)
        //{

        //    ResultValidarImei resultValidarImei = new ResultValidarImei();
        //    try
        //    {
        //        string fechaactual = DateTime.Now.ToString("yyyy-MM-dd");
        //        var result = await herramientas.EjecutarSentenciaEnApiLibre($"ofitec/IimeiOfitec/{imei}/{fechaactual}/{aplicacion}");
        //        resultValidarImei = Newtonsoft.Json.JsonConvert.DeserializeObject<ResultValidarImei>(result);
        //        resultValidarImei.HayError = false;
        //    }
        //    catch (Exception ex)
        //    {
        //        if (resultValidarImei is null)
        //            resultValidarImei = new ResultValidarImei();

        //        resultValidarImei.HayError = true;
        //        resultValidarImei.Mensaje = ex.Message;
        //    }
        //    return resultValidarImei;
        //} // Fin del método 

        //public async Task<Result> ActualizarIdentificadorTecnico(int cod_tecnico, string imei)
        //{
        //    var result = await herramientas.EjecutarSentenciaEnApiLibre($"ofitec/ActualizarIdentificadorTecnico/{cod_tecnico}/{imei}");
        //    var response = Newtonsoft.Json.JsonConvert.DeserializeObject<Result>(result);
        //    return response;
        //}


        //public async Task<Result> IsLicenciaValida(DateTime fecha_hora)
        //{
        //    Result result1 = new Result();
        //    try
        //    {
        //        string fechaactual = DateTime.Now.ToString("yyyy-MM-dd");

        //        var response = await herramientas.EjecutarSentenciaEnApiLibre($"ofitec/IsLicenciaValida/{fechaactual}");
        //        result1 = Newtonsoft.Json.JsonConvert.DeserializeObject<Result>(response);
        //        if (result1 is null)
        //        {
        //            result1 = new Result();
        //            result1.Respuesta = "ERROR";
        //            result1.Mensaje = "Por favor configure la conexión de la api en los ajustes";

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        if (result1 is null)
        //            result1 = new Result();

        //        result1.Respuesta = "ERROR";
        //        result1.Mensaje = "No hay conexión con el servidor";
        //    }
        //    return result1;
        //}

        //public async Task<Tuple<string, List<Empresa>>> GetListadoEmpresa(int codigo)
        //{
        //    try
        //    {
        //        var result = await herramientas.EjecutarSentenciaEnApiLibre($"ofitec/SEmpresaConfiguracion/{codigo}");
        //        var listado_empresa = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Empresa>>(result);

        //        return new Tuple<string, List<Empresa>>("True", listado_empresa);
        //    }
        //    catch (Exception ex)
        //    {
        //        List<Empresa> lista_empresa = new List<Empresa>();

        //        return new Tuple<string, List<Empresa>>("Error. " + ex.Message, lista_empresa);
        //    }
        //} // Fin del método 


    }

} // Fin clase

