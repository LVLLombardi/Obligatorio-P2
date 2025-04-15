namespace Dominio;

public class Sistema
{
    private List<Usuario> _usuarios = new List<Usuario>();
    private List<Aeropuerto> _aeropuertos = new List<Aeropuerto>();
    private List<Ruta> _rutas = new List<Ruta>();
    private List<Avion> _aviones = new List<Avion>();
    private List<Vuelo> _vuelos = new List<Vuelo>();
    private List<Pasaje> _pasajes = new List<Pasaje>();

    public Sistema()
    {
        PrecargarUsuarios();
        PrecargarAeropuertos();
        PrecargarRutas();
        PrecargarAviones();
    }

    // CREACION DE USUARIO
    public void AgregarUsuario(Usuario u)
    {
        if(u == null) throw new Exception("El nombre del usuario no puede ser nulo");
        u.Validar();
        _usuarios.Add(u);
    }

    // PRECARGA USUARIOS - CLIENTE PREMIUM - CLIENTE OCASIONAL - ADMINISTRADORES
    private void PrecargarUsuarios()
    {
        AgregarUsuario(new ClientePremium("lewishamilton44@gmail.com", "H4LTONf@", "46288064", "Lewis Hamilton", "Británica", 100));
        AgregarUsuario(new ClientePremium("fernandoalonso14@gmail.com", "4LONSOa!", "45433468", "Fernando Alonso", "Española", 30));
        AgregarUsuario(new ClientePremium("oliverbearman87@gmail.com", "BEAR87h#", "56764347", "Oliver Bearman", "Británica", 10));
        AgregarUsuario(new ClientePremium("charlesleclerc@gmail.com", "LEC16f$", "56288769", "Charles Leclerc", "Monegasca", 20));
        AgregarUsuario(new ClientePremium("kimiantonelli12@gmail.com", "KIMI12m_", "612344345", "Kimi Antonelli", "Italiana", 5));
        
        AgregarUsuario(new ClienteOcasional("carlossainz55@gmail.com", "CARL55w", "45654322", "Carlos Sainz", "Española", true));
        AgregarUsuario(new ClienteOcasional("maria.lopez92@gmail.com", "MariL92!", "33445566", "María López", "Argentina", true));
        AgregarUsuario(new ClienteOcasional("john.doe84@yahoo.com", "JohnD84#", "99887711", "John Doe", "Estadounidense", false));
        AgregarUsuario(new ClienteOcasional("luigi.rossi@outlook.it", "LuigiR99$", "11223344", "Luigi Rossi", "Italiana", true));
        AgregarUsuario(new ClienteOcasional("emily.jones@protonmail.com", "EmJ2023%", "77665544", "Emily Jones", "Canadiense", false));
        
        AgregarUsuario(new Administrador("yukitsunoda22@gmail.com", "YUKIrb!22", "Yuki"));
        AgregarUsuario(new Administrador("landonorris4@gmail.com", "LANDO4@", "Lando"));
    }
    
    // CREACION DE AEROPUERTO
    public void AgregarAeropuerto(Aeropuerto aeropuerto)
    {
        if (aeropuerto == null) throw new Exception("El Aeropuerto no puede ser nulo");
        aeropuerto.Validar();
        _aeropuertos.Add(aeropuerto);
    }

    // PRECARGA DE AEROPUERTOS
    private void PrecargarAeropuertos()
    {
        AgregarAeropuerto(new Aeropuerto("BCN", "Barcelona", 110, 95));
        AgregarAeropuerto(new Aeropuerto("JFK", "Nueva York", 150, 130));
        AgregarAeropuerto(new Aeropuerto("CDG", "París", 140, 120));
        AgregarAeropuerto(new Aeropuerto("LHR", "Londres", 160, 140));
        AgregarAeropuerto(new Aeropuerto("FCO", "Roma", 130, 110));
        AgregarAeropuerto(new Aeropuerto("EZE", "Buenos Aires", 100, 90));
        AgregarAeropuerto(new Aeropuerto("GRU", "São Paulo", 115, 100));
        AgregarAeropuerto(new Aeropuerto("LAX", "Los Ángeles", 155, 135));
        AgregarAeropuerto(new Aeropuerto("NRT", "Tokio", 170, 150));
        AgregarAeropuerto(new Aeropuerto("SYD", "Sídney", 165, 145));
        AgregarAeropuerto(new Aeropuerto("FRA", "Frankfurt", 145, 125));
        AgregarAeropuerto(new Aeropuerto("AMS", "Ámsterdam", 135, 115));
        AgregarAeropuerto(new Aeropuerto("MEX", "Ciudad de México", 105, 95));
        AgregarAeropuerto(new Aeropuerto("YYZ", "Toronto", 120, 100));
        AgregarAeropuerto(new Aeropuerto("SCL", "Santiago", 110, 90));
        AgregarAeropuerto(new Aeropuerto("BOG", "Bogotá", 108, 92));
        AgregarAeropuerto(new Aeropuerto("LIM", "Lima", 107, 89));
        AgregarAeropuerto(new Aeropuerto("DXB", "Dubái", 175, 155));
        AgregarAeropuerto(new Aeropuerto("ICN", "Seúl", 168, 148));
        AgregarAeropuerto(new Aeropuerto("JNB", "Johannesburgo", 125, 105));
    }

    // FUNCION PARA USAR EN RUTAS SE BUSCA AEROPUERTO POR CODIGO IATA
    public Aeropuerto BuscarAeropuertoPorCodigo(string codigo)
    {
        Aeropuerto a = null;
        int i = 0;
        while (a == null && i < _aeropuertos.Count)
        {
            if(_aeropuertos[i].Codigo == codigo) a = _aeropuertos[i];
            i++;
        }

        return a;
    }
    
    // CREACION DE RUTA
    public void AgregarRuta(Ruta r)
    {
        if (r == null) throw new Exception("La Ruta no puede ser nula");
        r.Validar();
        _rutas.Add(r);
    }

    // PRECARGA DE RUTAS
    private void PrecargarRutas()
    {
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("BCN"), BuscarAeropuertoPorCodigo("JFK"), 120));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("MAD"), BuscarAeropuertoPorCodigo("CDG"), 85));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("LHR"), BuscarAeropuertoPorCodigo("FCO"), 110));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("EZE"), BuscarAeropuertoPorCodigo("GRU"), 95));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("LAX"), BuscarAeropuertoPorCodigo("NRT"), 140));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("SYD"), BuscarAeropuertoPorCodigo("ICN"), 135));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("FRA"), BuscarAeropuertoPorCodigo("AMS"), 60));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("MEX"), BuscarAeropuertoPorCodigo("YYZ"), 100));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("SCL"), BuscarAeropuertoPorCodigo("BOG"), 115));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("LIM"), BuscarAeropuertoPorCodigo("JFK"), 125));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("DXB"), BuscarAeropuertoPorCodigo("ICN"), 145));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("CDG"), BuscarAeropuertoPorCodigo("LHR"), 75));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("JNB"), BuscarAeropuertoPorCodigo("DXB"), 160));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("AMS"), BuscarAeropuertoPorCodigo("MAD"), 90));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("GRU"), BuscarAeropuertoPorCodigo("FCO"), 130));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("YYZ"), BuscarAeropuertoPorCodigo("SYD"), 180));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("BOG"), BuscarAeropuertoPorCodigo("MEX"), 105));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("NRT"), BuscarAeropuertoPorCodigo("ICN"), 70));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("LHR"), BuscarAeropuertoPorCodigo("MAD"), 95));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("EZE"), BuscarAeropuertoPorCodigo("SCL"), 85));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("JFK"), BuscarAeropuertoPorCodigo("LAX"), 125));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("SYD"), BuscarAeropuertoPorCodigo("FRA"), 175));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("DXB"), BuscarAeropuertoPorCodigo("CDG"), 150));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("LIM"), BuscarAeropuertoPorCodigo("GRU"), 95));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("MAD"), BuscarAeropuertoPorCodigo("EZE"), 155));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("AMS"), BuscarAeropuertoPorCodigo("JNB"), 165));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("ICN"), BuscarAeropuertoPorCodigo("MEX"), 145));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("NRT"), BuscarAeropuertoPorCodigo("CDG"), 155));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("YYZ"), BuscarAeropuertoPorCodigo("BCN"), 115));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("BOG"), BuscarAeropuertoPorCodigo("LHR"), 130));
    }

    // CREACION DE AVION
    public void AgregarAvion(Avion a)
    {
        if (a == null) throw new Exception("El avion no puede ser nulo");
        a.Validar();
        _aviones.Add(a);
    }

    // PRECARGA DE AVIONES
    private void PrecargarAviones()
    {
        AgregarAvion(new Avion("Boeing", "737", 180, 5600, 15000));
        AgregarAvion(new Avion("Airbus", "A320", 160, 6100, 14000));
        AgregarAvion(new Avion("Embraer", "E190", 100, 4200, 9000));
        AgregarAvion(new Avion("Bombardier", "CRJ900", 90, 3700, 8500));
    }

    // CREACION DE VUELO
    public void AgregarVuelo(Vuelo v)
    {
        if (v == null) throw new Exception("El vuelo no puede ser nulo");
        v.Validar();
        _vuelos.Add(v);
    }
    
    // PRECARGA DE VUELOS
    private void PrecargarVuelos()
    {
        
    }
    
    // CREACION DE PASAJE
    public void AgregarPasaje(Pasaje p)
    {
        
    }
    
    // PRECARGA DE PASAJES

    private void PrecargarPasajes()
    {
        
    }

    public List<Usuario> ListarClientes()
    {
        List<Usuario> clientes = new List<Usuario>();
        foreach (Usuario u in _usuarios)
        {
            if (u is Cliente)
            {
                clientes.Add(u);
            }
        }
        return clientes;
    }
}