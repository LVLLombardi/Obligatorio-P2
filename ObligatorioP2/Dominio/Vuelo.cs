using System.Security.Cryptography;
using Dominio.Interfaces;

namespace Dominio;

public class Vuelo : IValidable
{
    private string _nroVuelo;
    private Ruta _ruta;
    private Avion _avion;
    private Frecuencia _frecuencia;

    public Vuelo(string nroVuelo, Ruta ruta, Avion avion, Frecuencia frecuencia)
    {
        _nroVuelo = nroVuelo;
        _ruta = ruta;
        _avion = avion;
        _frecuencia = frecuencia;
    }

    public string NumeroVuelo
    {
        get { return _nroVuelo; }
    }

    public void Validar()
    {
        if (!ValidarNroVuelo(_nroVuelo)) throw new Exception("El número de vuelo no puede ser vacío y debe contener 2 letras y entre 1 y 4 números"); 
        if (_ruta == null) throw new Exception("La ruta no puede ser nula");
        if (_avion == null) throw new Exception("El avion no puede ser nulo");
    }

    public bool ValidarNroVuelo(string nroVuelo)
    {
        bool esValido = true;
        if (string.IsNullOrEmpty(nroVuelo) || nroVuelo.Length < 3 || nroVuelo.Length > 6) throw new Exception("El número de vuelo debe tener entre 3 y 6 de largo");
        
        for (int i = 0; i < 2; i++)
        {
            if (!char.IsLetter(nroVuelo[i])) throw new Exception("El número de vuelo es inválido.");
        }
        
        for (int i = 2; i < nroVuelo.Length; i++)
        {
            if (!char.IsDigit(nroVuelo[i])) throw new Exception("El número de vuelo debe tener entre 1 y 4 números.");
        }
        return esValido;
    }

    public override bool Equals(object obj)
    {
        Vuelo v = obj as Vuelo;
        return v != null && this._nroVuelo == v._nroVuelo;
    }

    public override string ToString()
    {
        return $"Número de Vuelo: {_nroVuelo}";
    }
}