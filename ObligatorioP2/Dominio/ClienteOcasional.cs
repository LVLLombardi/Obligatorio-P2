namespace Dominio;

public class ClienteOcasional:Cliente
{
    private bool _esElegible;

    public ClienteOcasional(string correo, string contrasenia, string documento, string nombre, string nacionalidad, bool esElegible) : base(correo, contrasenia, documento, nombre, nacionalidad)
    {
        _esElegible = esElegible;
    }

    public override string ToString()
    {
        return $"Cliente Ocasional -> {base.ToString()} - Es Elegible: {_esElegible}";
    }
}