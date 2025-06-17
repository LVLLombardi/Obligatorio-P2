
using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace WebP2.Controllers

{
    public class PasajesController : Controller
    {
        Sistema miSistema = Sistema.Instancia;

        [HttpGet]
        public IActionResult HacerCompra(string numeroVuelo, DateTime fechaVuelo)
        {
            if (HttpContext.Session.GetString("rol") == null || HttpContext.Session.GetString("rol") != "Cliente")
            {
                return View("NoAuth");
            }
            if (TempData["Error"] != null) ViewBag.Error = TempData["Error"];
            if (TempData["Exito"] != null) ViewBag.Exito = TempData["Exito"];

            try
            {
                ViewBag.VueloSeleccionado = miSistema.BuscarVuelo(numeroVuelo);
                ViewBag.FechaSeleccionada = fechaVuelo;
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Listado", "Vuelos");
            }

            return View();
        }

        [HttpPost]
        public IActionResult HacerCompra(string numeroVuelo, DateTime fechaVuelo, Equipaje tipoEquipaje,
            double precioPasaje)
        {
            if (HttpContext.Session.GetString("rol") == null || HttpContext.Session.GetString("rol") != "Cliente")
            {
                return View("NoAuth");
            }
            
            try
            {
                Pasaje pasajeComprado = miSistema.ComprarPasaje(numeroVuelo, fechaVuelo,
                    HttpContext.Session.GetString("email"), tipoEquipaje, precioPasaje);
                TempData["Exito"] = "Usted ha comprado el pasaje de manera exitosa.";
                return RedirectToAction("Listado", "Vuelos");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("HacerCompra", "Pasajes");
            }
        }

        public IActionResult ListadoPasajesCliente()
        {
            if (HttpContext.Session.GetString("rol") == null || HttpContext.Session.GetString("rol") != "Cliente")
            {
                return View("NoAuth");
            }
            
            ViewBag.Pasajes = miSistema.ListarPasajesPorPrecioDesc(HttpContext.Session.GetString("email"));
            return View();
        }
    }
}