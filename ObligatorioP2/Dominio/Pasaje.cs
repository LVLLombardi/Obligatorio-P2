using Dominio.Interfaces;

namespace Dominio;

public class Pasaje : IValidable, IComparable<Pasaje>, IEquatable<Pasaje>
{
    private int _id;
    private static int s_ultId = 1;  
    private Vuelo _vuelo;
    private DateTime _fecha;
    private Cliente _pasajero;
    private Equipaje _equipaje;

    public Pasaje(Vuelo vuelo, DateTime fecha, Cliente pasajero, Equipaje equipaje)
    {
        _id = s_ultId++;
        _vuelo = vuelo;
        _pasajero = pasajero;
        _equipaje = equipaje;
        _fecha = fecha; 
    }

    public DateTime Fecha
    {
        get { return _fecha; }
    }

    public Equipaje Equipaje
    {
        get { return _equipaje; }
    }

    public Cliente Pasajero
    {
        get { return _pasajero; }
    }
    

    public Vuelo Vuelo
    {
        get { return _vuelo; }
    }
    
    public void Validar()
    {
        if (_vuelo == null) throw new Exception("El vuelo no puede ser nulo");
        if(_pasajero == null) throw new Exception("El pasajero no puede ser nulo");
        if(_fecha == new DateTime()) throw new Exception("El fecha no puede ser nula");
        if (!ValidarFecha()) throw new Exception("La fecha no corresponde a la frecuencia del vuelo");
    }

    private bool ValidarFecha()
    {
        return _vuelo.Frecuencia != null && _vuelo.Frecuencia.Contains(_fecha.DayOfWeek);
    }

    public int CompareTo(Pasaje? other)
    {
        return this._fecha.CompareTo(other._fecha);
    }

    public bool Equals(Pasaje? other)
    {
        return this._pasajero.Correo.Equals(other.Pasajero.Correo);
    }

    public override string ToString()
    {
        return $"Pasaje-> Id: {_id} - Nombre Pasajero: {_pasajero.Nombre} - Fecha: {_fecha.ToShortDateString()} - Número de vuelo: {_vuelo.NumeroVuelo}";
    }

    public double CostoFinalPasaje()
    {
        double costoBase = _vuelo.CalcularCostoPorAsiento();
        double tasas = _vuelo.Ruta.AeropuertoSalida.CostoTasas + _vuelo.Ruta.AeropuertoLlegada.CostoTasas;

        double subtotal = costoBase + tasas;
       return  _pasajero.CalcularPrecio(subtotal, _equipaje);
    }
}