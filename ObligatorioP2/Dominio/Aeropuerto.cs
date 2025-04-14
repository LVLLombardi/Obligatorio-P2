using Dominio.Interfaces;

namespace Dominio;

public class Aeropuerto : IValidable
{
    private string _codigoIATA;
    private string _ciudad;
    private double _costoOp;
    private double _costoTasas;

    public Aeropuerto(string codigoIATA, string ciudad, double costoOp, double costoTasas)
    {
        _codigoIATA = codigoIATA;
        _ciudad = ciudad;
        _costoOp = costoOp;
        _costoTasas = costoTasas;
    }

    public void Validar()
    {
        if (string.IsNullOrEmpty(_codigoIATA) || _codigoIATA.Length != 3) throw new Exception("El código IATA es un identificador único de 3 letras");
        if (string.IsNullOrEmpty(_ciudad)) throw new Exception("La ciudad no puede ser vacía");
        if (_costoOp < 0) throw new Exception("El costo de Operación debe ser positivo.");
        if(_costoTasas < 0) throw new Exception("El costo de Tasas es obligatorio y debe ser positivo");
    }
}