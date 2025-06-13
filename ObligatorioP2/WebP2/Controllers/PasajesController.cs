using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace WebP2.Controllers;

public class PasajesController : Controller
{
    private Sistema miSistema = Sistema.Instancia;
    
    [HttpGet]
    public IActionResult HacerCompra(string NumeroVuelo)
    {
        ViewBag.Paquete = miSistema.ListarVuelos(NumeroVuelo);
        return View();
    }
    
    [HttpGet]
    public IActionResult ListadoPasajes()
    {
        ViewBag.Listado = miSistema.ListarPasajesPorFechaAsc();
        return View();
    }
}