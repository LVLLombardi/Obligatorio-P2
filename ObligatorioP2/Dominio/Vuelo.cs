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
        if (!ValidarNroVuelo(_nroVuelo)) throw new Exception("El número de vuelo no puede ser vacío y debe contener 2 letras y entre 1 y 4 números"); // VALIDAR ALFANUMERICO
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
            
            /*int cantDigitos = nroVuelo.Length - 2;

            if (cantDigitos < 1 || cantDigitos > 4)
            {
                esValido = false;
            }
            else
            {
                for (int i = 2; i < nroVuelo.Length; i++)
                {
                    char c = nroVuelo[i];
                    if (c < '0' || c > '9')
                    {
                        esValido = false;
                    }
                }
            }*/
        
        return esValido;
    }

    public override string ToString()
    {
        return $"Vuelo -> Número de Vuelo: {_nroVuelo} - Modelo Avión: {_avion.Modelo} - {_ruta.ToString()} - Frecuencia: {_frecuencia}";
    }
}