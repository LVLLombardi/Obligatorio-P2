using Dominio.Interfaces;

namespace Dominio;

public class Pasaje : IValidable
{
    private int _id;
    private static int s_ultId = 1;  
    private Vuelo _vuelo;
    private DateTime _fecha;
    private Cliente _pasajero;
    private Equipaje _equipaje;
    private double _precio;

    public Pasaje(Vuelo vuelo, DateTime fecha, Cliente pasajero, Equipaje equipaje, double precio)
    {
        _id = s_ultId++;
        _vuelo = vuelo;
        _pasajero = pasajero;
        _equipaje = equipaje;
        _precio = precio;
        _fecha = fecha; 
    }

    public DateTime Fecha
    {
        get { return _fecha; }
    }

    public void Validar()
    {
        if (_vuelo == null) throw new Exception("El vuelo no puede ser nulo");
        if(_pasajero == null) throw new Exception("El pasajero no puede ser nulo");
        if (_precio < 0) throw new Exception("El precio debe ser positivo");
        if(_fecha == new DateTime()) throw new Exception("El fecha no puede ser nula");
    }

    public override string ToString()
    {
        return $"Pasaje-> Id: {_id} - Nombre Pasajero: {_pasajero.Nombre} - Fecha: {_fecha.ToShortDateString()} - Número de vuelo: {_vuelo.NumeroVuelo}";
    }
}