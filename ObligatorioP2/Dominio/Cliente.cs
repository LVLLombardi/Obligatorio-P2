using Dominio.Interfaces;

namespace Dominio;

public abstract class Cliente : Usuario
{
    private string _documento;
    private string _nombre;
    private string _nacionalidad;

    public Cliente(string correo, string contrasenia, string documento, string nombre, string nacionalidad):base(correo, contrasenia)
    {
        _documento = documento;
        _nombre = nombre;
        _nacionalidad = nacionalidad;
    }

    public override void Validar()
    {
        base.Validar();
        if (string.IsNullOrEmpty(_documento)) throw new Exception("El documento no puede ser vacio");
        if (string.IsNullOrEmpty(_nombre)) throw new Exception("El nombre del cliente no puede ser vacio");
        if(string.IsNullOrEmpty(_nacionalidad)) throw new Exception("El nacionalidad no puede ser vacia");
    }

    public override string ToString()
    {
        return $"Nombre Cliente: {_nombre} - {base.ToString()} - Nacionalidad: {_nacionalidad}";
    }
}