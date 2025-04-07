using Dominio.Interfaces;

namespace Dominio;

public class Ruta : IValidable
{
    private int _id;
    private int s_ultId = 1;
    private Aeropuerto _aeropuertoSalida;
    private Aeropuerto _aeropuertoLlegada;
    private double _distancia;

    public Ruta(Aeropuerto aeropuertoSalida, Aeropuerto aeropuertoLlegada, double distancia)
    {
        _id = s_ultId++;
        _aeropuertoSalida = aeropuertoSalida;
        _aeropuertoLlegada = aeropuertoLlegada;
        _distancia = distancia;
    }


    public void Validar()
    {
        throw new NotImplementedException();
    }
}