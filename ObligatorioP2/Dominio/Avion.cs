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
        if(string.IsNullOrEmpty(_fabricante)) throw new Exception("El fabricante no puede ser vacío");
        if (string.IsNullOrEmpty(_modelo)) throw new Exception("El modelo no puede ser vacío");
        if (_cantAsientos <= 0) throw new Exception("La cantidad de asientos debe ser mayor a cero");
        if (_alcanceKm < 0) throw new Exception("La cantidad máxima de Kilometros que puede volar no puede ser negativa");
        if (_costoOperacion < 0) throw new Exception("El costo de operación por km no puede ser menor a cero");
    }
}