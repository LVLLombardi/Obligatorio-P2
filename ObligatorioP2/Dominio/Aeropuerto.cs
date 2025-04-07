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
        throw new NotImplementedException();
    }
}