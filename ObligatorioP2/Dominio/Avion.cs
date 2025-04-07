using Dominio.Interfaces;

namespace Dominio;

public class Avion : IValidable
{
    private string _fabricante;
    private string _modelo;
    private int _cantAsientos;
    private double _alcanceKm;
    private double _costoOperacion;

    public Avion(string fabricante, string modelo, int cantAsientos, double alcanceKm, double costoOperacion)
    {
        _fabricante = fabricante;
        _modelo = modelo;
        _cantAsientos = cantAsientos;
        _alcanceKm = alcanceKm;
        _costoOperacion = costoOperacion;
    }


    public void Validar()
    {
        throw new NotImplementedException();
    }
}