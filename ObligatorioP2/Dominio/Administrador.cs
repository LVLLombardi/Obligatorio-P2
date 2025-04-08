using Dominio.Interfaces;

namespace Dominio;

public class Administrador : IValidable
{
    private string _apodo;
    private string _correoAdmin;
    private string _contraseniaAdmin;

    public Administrador(string apodo, string correoAdmin, string contraseniaAdmin)
    {
        _apodo = apodo;
        _correoAdmin = correoAdmin;
        _contraseniaAdmin = contraseniaAdmin;
    }

    public void Validar()
    {
        if (string.IsNullOrEmpty(_apodo)) throw new Exception("El apodo no puede ser vacío");
        if (string.IsNullOrEmpty(_correoAdmin)) throw new Exception("El correo del administrador no puede ser vacio");
        if (string.IsNullOrEmpty(_contraseniaAdmin)) throw new Exception("La contraseña no puede ser vacia");
    }
}