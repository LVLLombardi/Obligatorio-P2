using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace WebP2.Controllers
{
    public class VuelosController : Controller
    {
        Sistema miSistema = Sistema.Instancia;
        [HttpGet]
        public IActionResult Listado(string aeropuerto_salida, string aeropuerto_llegada, DateTime fecha_vuelo)
        {
            if (HttpContext.Session.GetString("rol") == null || HttpContext.Session.GetString("rol") != "Cliente")
            {
                return View("NoAuth");
            }
            
            if (TempData["Error"] != null) ViewBag.Error = TempData["Error"];
            if (TempData["Exito"] != null) ViewBag.Exito = TempData["Exito"];

            
            // Lista completa de aeropuertos para los filtros en la vista
            ViewBag.Aeropuertos = miSistema.Aeropuerto;
            List<Vuelo> vuelosFiltrados = miSistema.FiltrarVuelos(aeropuerto_salida, aeropuerto_llegada, fecha_vuelo);

            if (fecha_vuelo == DateTime.MinValue)
            {
                vuelosFiltrados = miSistema.FiltrarVuelos(aeropuerto_salida, aeropuerto_llegada, null);
            }
            else
            {
                vuelosFiltrados = miSistema.FiltrarVuelos(aeropuerto_salida, aeropuerto_llegada, fecha_vuelo);
            }
            //Lista filtrada para pasar a la vista
            ViewBag.AeropuertoSalida = aeropuerto_salida;
            ViewBag.AeropuertoLlegada = aeropuerto_llegada;
            ViewBag.FechaVuelo = fecha_vuelo;
            ViewBag.Listado = vuelosFiltrados;

            return View();
        }
    }
}

