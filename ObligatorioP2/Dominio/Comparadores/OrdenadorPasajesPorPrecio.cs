namespace Dominio.Comparadores;

public class OrdenadorPasajesPorPrecio: IComparer<Pasaje>
{
    public int Compare(Pasaje? x, Pasaje? y)
    {
        return x.CostoFinalPasaje().CompareTo(y.CostoFinalPasaje()) * -1;
    }
}