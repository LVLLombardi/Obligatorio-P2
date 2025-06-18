
using System.Runtime.InteropServices.JavaScript;
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
                if (string.IsNullOrEmpty(numeroVuelo)) throw new Exception("Número vuelo no especificado");
                if (fechaVuelo == new DateTime()) throw new Exception("Fecha del vuelo no especificada");
                ViewBag.VueloSeleccionado = miSistema.BuscarVuelo(numeroVuelo);
                ViewBag.FechaSeleccionada = fechaVuelo;
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.VueloSeleccionado = null;
                ViewBag.FechaSeleccionada = fechaVuelo;
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
                ViewBag.PrecioFinal = precioPasaje;
                miSistema.ComprarPasaje(numeroVuelo, fechaVuelo,
                    HttpContext.Session.GetString("email"), tipoEquipaje);
                TempData["Exito"] = "Usted ha comprado el pasaje de manera exitosa.";
                return RedirectToAction("Listado", "Vuelos");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.VueloSeleccionado = miSistema.BuscarVuelo(numeroVuelo);
                ViewBag.FechaSeleccionada = fechaVuelo;
                ViewBag.PrecioFinal = precioPasaje;
                return View();
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

        public IActionResult ListadoPasajesAdministrador()
        {
            if (HttpContext.Session.GetString("rol") == null || HttpContext.Session.GetString("rol") != "Administrador")
            {
                return View("NoAuth");
            }

            ViewBag.Pasajes = miSistema.ListarPasajesPorFechaAsc();
            return View();
        }
    }
}