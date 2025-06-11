using Microsoft.AspNetCore.Mvc;
using Dominio;
namespace WebP2.Controllers;

public class UsuariosController : Controller
{
    private Sistema miSistema = Sistema.Instancia;
    
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string email, string contrasenia)
    {
        try
        {
            if (string.IsNullOrEmpty(email)) throw new Exception("El Email no puede ser vacio");
            if (string.IsNullOrEmpty(contrasenia)) throw new Exception("La contraseña no puede ser vacia");
            Usuario u = miSistema.Login(email, contrasenia);
            if(u == null) throw new Exception("Email o contraseña incorrectos");
            
            HttpContext.Session.SetString("email", u.Correo);
            HttpContext.Session.SetString("rol", u.Rol());
            
            return RedirectToAction("Index", "Home");
        }
        catch (Exception e)
        {
           ViewBag.Error = e.Message;
           return View();
        }
    }
    
    [HttpGet]
    public IActionResult Registro()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Registro(string nombre, string nacionalidad, string email, string contrasenia, string documento)
    {
        
        try
        {
            if(string.IsNullOrEmpty(nombre)) throw new Exception("El nombre no puede ser vacio");
            if(string.IsNullOrEmpty(nacionalidad))  throw new Exception("La nacionalidad no puede ser vacia");
            if(string.IsNullOrEmpty(email)) throw new Exception("El Email no puede ser vacio");
            if (string.IsNullOrEmpty(contrasenia)) throw new Exception("La contraseña no puede ser vacia");
            if(string.IsNullOrEmpty(documento)) throw new Exception("El documento no puede ser vacio");
            
            bool esElegible = miSistema.GenerarElegibilidadCliente();
        
            Cliente cliente = new ClienteOcasional(email, contrasenia, documento, nombre, nacionalidad, esElegible);
            
            miSistema.RegistrarCliente(cliente);
            
            HttpContext.Session.SetString("email", cliente.Correo);
            HttpContext.Session.SetString("rol", cliente.Rol());
            
            return RedirectToAction("Index", "Home");
        }
        catch (Exception e)
        {
            ViewBag.Error = e.Message;
            ViewBag.Nombre = nombre;
            ViewBag.Email = email;
            ViewBag.Contrasenia = contrasenia;
            ViewBag.Documento = documento;
            ViewBag.Nacionalidad = nacionalidad;
            return View();
        }
    }
    
    [HttpGet]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index", "Home");
    }
}