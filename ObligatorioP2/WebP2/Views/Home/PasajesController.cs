using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace WebP2.Views.Home
{
    public class PasajesController : Controller
    {
        [HttpGet]
        public IActionResult HacerCompra(string NumeroVuelo)
        {
            ViewBag.Paquete = Sistema.Instancia;
            return View();
        }
    }
}
