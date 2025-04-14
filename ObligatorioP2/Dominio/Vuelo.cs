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
        if (string.IsNullOrEmpty(_nroVuelo)) throw new Exception("El número de vuelo no puede ser vacío"); // VALIDAR ALFANUMERICO
        if (_ruta == null) throw new Exception("La ruta no puede ser nula");
        if (_avion == null) throw new Exception("El avion no puede ser nulo");
        if (_frecuencia < 0) throw new Exception("La frecuencia no puede ser negativa");
    }
}