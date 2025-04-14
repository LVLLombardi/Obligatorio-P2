using Dominio.Interfaces;

namespace Dominio;

public class Administrador : Usuario
{
    private string _apodo;

    public Administrador(string correo, string contrasenia, string apodo):base(correo, contrasenia)
    {
        _apodo = apodo;
    }

    public override void Validar()
    {
        base.Validar();
        if (string.IsNullOrEmpty(_apodo)) throw new Exception("El apodo no puede ser vacío");
    }
}