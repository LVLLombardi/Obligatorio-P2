using System.Security.Cryptography;
using Dominio.Interfaces;

namespace Dominio;

public class Vuelo : IValidable
{
    private string _nroVuelo;
    private Ruta _ruta;
    private Avion _avion;
    private List <DayOfWeek> _frecuencia;

    public Vuelo(string nroVuelo, Ruta ruta, Avion avion, List<DayOfWeek> frecuencia)
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
    public Ruta Ruta
    {
        get { return _ruta; }
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
        if (string.IsNullOrEmpty(nroVuelo) || nroVuelo.Length < 3 || nroVuelo.Length > 6) esValido = false;
        
        
        for (int i = 0; i < 2; i++)
        {
            if (!char.IsLetter(nroVuelo[i]))
                esValido = false;
        }
        
        for (int i = 2; i < nroVuelo.Length; i++)
        {
            if (!char.IsDigit(nroVuelo[i]))
                esValido = false;
        }
        return esValido;
    }

    public override string ToString()
    {
        List<string> dias = new List<string>();

        foreach (DayOfWeek dia in Enum.GetValues(typeof(DayOfWeek)))
        {
            if (_frecuencia.Contains(dia))
            {
                dias.Add(dia.ToString());
            }
        }
        return $"Vuelo -> Número de Vuelo: {_nroVuelo} - Modelo Avión: {_avion.Modelo} - Ruta: {_ruta.AeropuertoSalida.Codigo} - {_ruta.AeropuertoLlegada.Codigo} - Frecuencia: {string.Join(", ", dias)}";
    }
}