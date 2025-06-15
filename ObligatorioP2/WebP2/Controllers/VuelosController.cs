using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace WebP2.Controllers
{
    public class VuelosController : Controller
    {
        Sistema miSistema = Sistema.Instancia;
        [HttpGet]
        public IActionResult Listado(string aeropuerto_salida, string aeropuerto_llegada, DateTime frecuencia_vuelo)
        {
            if (TempData["Error"] != null) ViewBag.Error = TempData["Error"];
            if (TempData["Exito"] != null) ViewBag.Exito = TempData["Exito"];

            // Lista completa de aeropuertos para los filtros en la vista
            ViewBag.Aeropuertos = miSistema.Aeropuerto;
            List<Vuelo> vuelosFiltrados = miSistema.FiltrarVuelos(aeropuerto_salida, aeropuerto_llegada, frecuencia_vuelo);

            //Lista filtrada para pasar a la vista
            ViewBag.AeropuertoSalida = aeropuerto_salida;
            ViewBag.AeropuertoLlegada = aeropuerto_llegada;
            ViewBag.FrecuenciaVuelo = frecuencia_vuelo;
            ViewBag.Listado = vuelosFiltrados;

            return View();
        }
    }
}

