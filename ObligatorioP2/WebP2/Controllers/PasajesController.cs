
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
            try
            {
                if (HttpContext.Session.GetString("rol") == null || HttpContext.Session.GetString("rol") != "Cliente")
                {
                    throw new Exception("Solo los clientes registrados pueden comprar pasajes.");
                }

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
            ViewBag.Pasajes = miSistema.Pasajes;
            return View();
        }
    }
}