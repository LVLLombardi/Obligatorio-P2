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

    public override double CalcularPrecio(double subtotal, Equipaje equipaje)
    {
        double precioFinal = subtotal * 1.25;

        if (equipaje == Equipaje.CABINA)
        {
            precioFinal *= 1.10;
        } else if (equipaje == Equipaje.BODEGA)
        {
            precioFinal *= 1.20;
        }

        return precioFinal;
    }

    public void CambiarElegibilidad(bool nuevaElegibilidad)
    {
        _esElegible = nuevaElegibilidad;
    } 
    
}