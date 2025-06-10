using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace WebP2.Controllers
{
    public class VuelosController : Controller
    {
        Sistema miSistema = Sistema.Instancia;
        [HttpGet]
        public IActionResult Listado(string aeropuerto_salida, string aeropuerto_llegada, DateTime? frecuencia_vuelo)
        {
            if (TempData["Error"] != null) ViewBag.Error = TempData["Error"];
            if (TempData["Exito"] != null) ViewBag.Exito = TempData["Exito"];

            //Lista completa de aeropuertos para filtros en vista de vuelos
            ViewBag.Aeropuertos = miSistema.Aeropuerto;

            // Lista vacía para guardar resultados de la busqueda
            List<Vuelo> vuelosFiltrados = new List<Vuelo>();
            List<Vuelo> todosLosVuelos = miSistema.Vuelos;

            foreach (Vuelo v in todosLosVuelos)
            {
                bool cumpleCondiciones = true; 

                //Filtro de aeropuerto de salida.
                if (!string.IsNullOrEmpty(aeropuerto_salida))
                {
                    if (!v.Ruta.AeropuertoSalida.Codigo.Equals(aeropuerto_salida, StringComparison.OrdinalIgnoreCase))
                    {
                        cumpleCondiciones = false;
                    }
                }

                //Filtro de aeropuerto de llegada
                if (cumpleCondiciones && !string.IsNullOrEmpty(aeropuerto_llegada))
                {
                    if (!v.Ruta.AeropuertoLlegada.Codigo.Equals(aeropuerto_llegada, StringComparison.OrdinalIgnoreCase))
                    {
                        cumpleCondiciones = false;
                    }
                }

                //Filtro de frecuencia
                if (cumpleCondiciones && frecuencia_vuelo!=null)
                {
                    DayOfWeek diaSeleccionado = frecuencia_vuelo.Value.DayOfWeek;
                    bool diaEncontrado = false;

                    foreach (DayOfWeek dia in v.Frecuencia)
                    {
                        if (dia == diaSeleccionado)
                        {
                            diaEncontrado = true;
                        }
                    }

                    if (!diaEncontrado)
                    {
                        cumpleCondiciones = false;
                    }
                }

                //Vuelos que cumplen las condiciones para mostrarse
                if (cumpleCondiciones)
                {
                    vuelosFiltrados.Add(v);
                }
            }

            // Paso los valores de búsqueda a la vista y luego la vista filtrada
            ViewBag.AeropuertoSalida = aeropuerto_salida;
            ViewBag.AeropuertoLlegada = aeropuerto_llegada;
            ViewBag.FrecuenciaVuelo = frecuencia_vuelo;

            ViewBag.Listado = vuelosFiltrados;

            return View();
        }
    }
}

