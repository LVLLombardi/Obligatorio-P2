using System.Reflection.Metadata;

namespace Dominio;

public class ClientePremium:Cliente
{
    private double _puntos;

    public double Puntos
    {
        get { return _puntos; }
    }
    
    public ClientePremium(string correo, string contrasenia, string documento, string nombre, string nacionalidad, double puntos) : base(correo, contrasenia, documento, nombre, nacionalidad)
    {
        _puntos = puntos;
    }

    
    public override void Validar()
    {
        base.Validar();
        if (_puntos < 0) throw new Exception("Los puntos deben ser positivos");
    }

    public override string ToString()
    {
        return $"{base.ToString()} - Puntos: {_puntos}";
    }
    
    public override string Tipo()
    {
        return "Cliente Premium";
    }

    public override string Rol()
    {
        return "Cliente";
    }

    public override double CalcularPrecio(double subtotal, Equipaje equipaje)
    {
        double precioFinal = subtotal * 1.25;

        if (equipaje == Equipaje.BODEGA)
        {
            precioFinal *= 1.05;
        }

        return precioFinal;
    }

    public void cambiarPuntos(double nuevosPuntos)
    {
       _puntos = nuevosPuntos; 
    }
}