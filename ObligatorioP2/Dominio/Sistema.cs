namespace Dominio;

public class Sistema
{
    private List<Aeropuerto> _aeropuertos = new List<Aeropuerto>();
    private List<Ruta> _rutas = new List<Ruta>();
    private List<Avion> _aviones = new List<Avion>();
    private List<Vuelo> _vuelos = new List<Vuelo>();
    private List<Pasaje> _pasajes = new List<Pasaje>();

    public Sistema()
    {
        PrecargarAeropuerto();
    }

    public void CrearAeropuerto(Aeropuerto aeropuerto)
    {
        if (aeropuerto == null) throw new Exception("El Aeropuerto no puede ser nulo");
        aeropuerto.Validar();
        _aeropuertos.Add(aeropuerto);
    }

    public void PrecargarAeropuerto()
    {
        
    }
    
}