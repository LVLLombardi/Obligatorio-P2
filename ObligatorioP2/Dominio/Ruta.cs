using Dominio.Interfaces;

namespace Dominio;

public class Ruta : IValidable
{
    private int _id;
    private static int s_ultId = 1; //para que pueda ser compartido static
    private Aeropuerto _aeropuertoSalida;
    private Aeropuerto _aeropuertoLlegada;
    private double _distancia;

    public Aeropuerto AeropuertoSalida
    {
        get { return _aeropuertoSalida; }
    }

    public Aeropuerto AeropuertoLlegada
    {
        get { return _aeropuertoLlegada; }
    }

    public int Id
    {
        get { return _id; }
    }
    public Ruta(Aeropuerto aeropuertoSalida, Aeropuerto aeropuertoLlegada, double distancia)
    {
        _id = s_ultId++;
        _aeropuertoSalida = aeropuertoSalida;
        _aeropuertoLlegada = aeropuertoLlegada;
        _distancia = distancia;
    }

    public void Validar()
    {
        //if(_aeropuertoSalida == null) throw new Exception("El aeropuerto de salida no puede ser nulo");
        //if(_aeropuertoLlegada == null) throw new Exception("El aeropuerto de llegada no puede ser nulo");
        if (_distancia < 0) throw new Exception("La distancia no puede ser negativa");
    }
}