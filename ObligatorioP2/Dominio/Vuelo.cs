using Dominio.Interfaces;

namespace Dominio;

public class Vuelo : IValidable
{
    private string _nroVuelo;
    private Ruta _ruta;
    private Avion _avion;
    private int _frecuencia;

    public Vuelo(string nroVuelo, Ruta ruta, Avion avion, int frecuencia)
    {
        _nroVuelo = nroVuelo;
        _ruta = ruta;
        _avion = avion;
        _frecuencia = frecuencia;
    }


    public void Validar()
    {
        throw new NotImplementedException();
    }
}