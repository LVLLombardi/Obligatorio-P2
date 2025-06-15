namespace Dominio;

public class ClienteOcasional:Cliente
{
    private bool _esElegible;

    public bool Elegible
    {
        get { return _esElegible; }
    }
    public ClienteOcasional(string correo, string contrasenia, string documento, string nombre, string nacionalidad, bool esElegible) : base(correo, contrasenia, documento, nombre, nacionalidad)
    {
        _esElegible = esElegible;
    }

    public override string ToString()
    {
        return $"{base.ToString()} - Es Elegible: {_esElegible}";
    }

    public override string Tipo()
    {
        return "Cliente Ocasional";
    }

    public void CambiarElegibilidad(bool nuevaElegibilidad)
    {
        _esElegible = nuevaElegibilidad;
    } 
    
}