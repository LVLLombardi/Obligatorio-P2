namespace Dominio;

public class ClientePremium:Cliente
{
    private double _puntos;

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
}