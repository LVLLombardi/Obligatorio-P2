using Dominio.Interfaces;

namespace Dominio;

public abstract class Usuario : IValidable
{
    private string _correo;
    private string _contrasenia;

    public Usuario(string correo, string contrasenia)
    {
        _correo = correo;
        _contrasenia = contrasenia;
    }

    public string Correo 
    {
        get { return _correo; }
    }
    public string Contrasenia
    {
        get { return _contrasenia; }
    }
    public virtual void Validar()
    {
        if (string.IsNullOrEmpty(_correo)) throw new Exception("El correo no puede ser vacio");
        if (string.IsNullOrEmpty(_contrasenia)) throw new Exception("La contraseña no puede ser vacia");
    }

    // VERIFICACION FUTURA
    public override bool Equals(object? obj)
    {
        Usuario u = obj as Usuario;
        return u != null && u.Correo == _correo;
    }

    public override string ToString()
    {
        return $"Correo: {_correo}";
    }
}