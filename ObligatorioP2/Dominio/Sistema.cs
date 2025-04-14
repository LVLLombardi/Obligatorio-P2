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
    }

    // CREACION DE USUARIO
    public void CrearUsuario(Usuario u)
    {
        if(u == null) throw new Exception("El nombre del usuario no puede ser nulo");
        u.Validar();
        _usuarios.Add(u);
    }

    // PRECARGA USUARIOS - CLIENTE PREMIUM - CLIENTE OCASIONAL - ADMINISTRADORES
    private void PrecargarUsuarios()
    {
        CrearUsuario(new ClientePremium("lewishamilton44@gmail.com", "H4LTONf@", "46288064", "Lewis Hamilton", "Británica", 100));
        CrearUsuario(new ClientePremium("fernandoalonso14@gmail.com", "4LONSOa!", "45433468", "Fernando Alonso", "Española", 30));
        CrearUsuario(new ClientePremium("oliverbearman87@gmail.com", "BEAR87h#", "56764347", "Oliver Bearman", "Británica", 10));
        CrearUsuario(new ClientePremium("charlesleclerc@gmail.com", "LEC16f$", "56288769", "Charles Leclerc", "Monegasca", 20));
        CrearUsuario(new ClientePremium("kimiantonelli12@gmail.com", "KIMI12m_", "612344345", "Kimi Antonelli", "Italiana", 5));
        
        CrearUsuario(new ClienteOcasional("carlossainz55@gmail.com", "CARL55w", "45654322", "Carlos Sainz", "Española", true));
        CrearUsuario(new ClienteOcasional("maria.lopez92@gmail.com", "MariL92!", "33445566", "María López", "Argentina", true));
        CrearUsuario(new ClienteOcasional("john.doe84@yahoo.com", "JohnD84#", "99887711", "John Doe", "Estadounidense", false));
        CrearUsuario(new ClienteOcasional("luigi.rossi@outlook.it", "LuigiR99$", "11223344", "Luigi Rossi", "Italiana", true));
        CrearUsuario(new ClienteOcasional("emily.jones@protonmail.com", "EmJ2023%", "77665544", "Emily Jones", "Canadiense", false));
        
        CrearUsuario(new Administrador("yukitsunoda22@gmail.com", "YUKIrb!22", "Yuki"));
        CrearUsuario(new Administrador("landonorris4@gmail.com", "LANDO4@", "Lando"));
    }
    
    // CREACION DE AEROPUERTO
    public void CrearAeropuerto(Aeropuerto aeropuerto)
    {
        if (aeropuerto == null) throw new Exception("El Aeropuerto no puede ser nulo");
        aeropuerto.Validar();
        _aeropuertos.Add(aeropuerto);
    }

    // PRECARGA DE AEROPUERTOS
    private void PrecargarAeropuertos()
    {
        CrearAeropuerto(new Aeropuerto("BCN", "Barcelona", 110, 95));
        CrearAeropuerto(new Aeropuerto("JFK", "Nueva York", 150, 130));
        CrearAeropuerto(new Aeropuerto("CDG", "París", 140, 120));
        CrearAeropuerto(new Aeropuerto("LHR", "Londres", 160, 140));
        CrearAeropuerto(new Aeropuerto("FCO", "Roma", 130, 110));
        CrearAeropuerto(new Aeropuerto("EZE", "Buenos Aires", 100, 90));
        CrearAeropuerto(new Aeropuerto("GRU", "São Paulo", 115, 100));
        CrearAeropuerto(new Aeropuerto("LAX", "Los Ángeles", 155, 135));
        CrearAeropuerto(new Aeropuerto("NRT", "Tokio", 170, 150));
        CrearAeropuerto(new Aeropuerto("SYD", "Sídney", 165, 145));
        CrearAeropuerto(new Aeropuerto("FRA", "Frankfurt", 145, 125));
        CrearAeropuerto(new Aeropuerto("AMS", "Ámsterdam", 135, 115));
        CrearAeropuerto(new Aeropuerto("MEX", "Ciudad de México", 105, 95));
        CrearAeropuerto(new Aeropuerto("YYZ", "Toronto", 120, 100));
        CrearAeropuerto(new Aeropuerto("SCL", "Santiago", 110, 90));
        CrearAeropuerto(new Aeropuerto("BOG", "Bogotá", 108, 92));
        CrearAeropuerto(new Aeropuerto("LIM", "Lima", 107, 89));
        CrearAeropuerto(new Aeropuerto("DXB", "Dubái", 175, 155));
        CrearAeropuerto(new Aeropuerto("ICN", "Seúl", 168, 148));
        CrearAeropuerto(new Aeropuerto("JNB", "Johannesburgo", 125, 105));
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
    public void CrearRuta(Ruta r)
    {
        if (r == null) throw new Exception("La Ruta no puede ser nula");
        r.Validar();
        _rutas.Add(r);
    }

    // PRECARGA DE RUTAS
    private void PrecargarRutas()
    {
        CrearRuta(new Ruta(BuscarAeropuertoPorCodigo("BCN"), BuscarAeropuertoPorCodigo("JFK"), 120));
        CrearRuta(new Ruta(BuscarAeropuertoPorCodigo("MAD"), BuscarAeropuertoPorCodigo("CDG"), 85));
        CrearRuta(new Ruta(BuscarAeropuertoPorCodigo("LHR"), BuscarAeropuertoPorCodigo("FCO"), 110));
        CrearRuta(new Ruta(BuscarAeropuertoPorCodigo("EZE"), BuscarAeropuertoPorCodigo("GRU"), 95));
        CrearRuta(new Ruta(BuscarAeropuertoPorCodigo("LAX"), BuscarAeropuertoPorCodigo("NRT"), 140));
        CrearRuta(new Ruta(BuscarAeropuertoPorCodigo("SYD"), BuscarAeropuertoPorCodigo("ICN"), 135));
        CrearRuta(new Ruta(BuscarAeropuertoPorCodigo("FRA"), BuscarAeropuertoPorCodigo("AMS"), 60));
        CrearRuta(new Ruta(BuscarAeropuertoPorCodigo("MEX"), BuscarAeropuertoPorCodigo("YYZ"), 100));
        CrearRuta(new Ruta(BuscarAeropuertoPorCodigo("SCL"), BuscarAeropuertoPorCodigo("BOG"), 115));
        CrearRuta(new Ruta(BuscarAeropuertoPorCodigo("LIM"), BuscarAeropuertoPorCodigo("JFK"), 125));
        CrearRuta(new Ruta(BuscarAeropuertoPorCodigo("DXB"), BuscarAeropuertoPorCodigo("ICN"), 145));
        CrearRuta(new Ruta(BuscarAeropuertoPorCodigo("CDG"), BuscarAeropuertoPorCodigo("LHR"), 75));
        CrearRuta(new Ruta(BuscarAeropuertoPorCodigo("JNB"), BuscarAeropuertoPorCodigo("DXB"), 160));
        CrearRuta(new Ruta(BuscarAeropuertoPorCodigo("AMS"), BuscarAeropuertoPorCodigo("MAD"), 90));
        CrearRuta(new Ruta(BuscarAeropuertoPorCodigo("GRU"), BuscarAeropuertoPorCodigo("FCO"), 130));
        CrearRuta(new Ruta(BuscarAeropuertoPorCodigo("YYZ"), BuscarAeropuertoPorCodigo("SYD"), 180));
        CrearRuta(new Ruta(BuscarAeropuertoPorCodigo("BOG"), BuscarAeropuertoPorCodigo("MEX"), 105));
        CrearRuta(new Ruta(BuscarAeropuertoPorCodigo("NRT"), BuscarAeropuertoPorCodigo("ICN"), 70));
        CrearRuta(new Ruta(BuscarAeropuertoPorCodigo("LHR"), BuscarAeropuertoPorCodigo("MAD"), 95));
        CrearRuta(new Ruta(BuscarAeropuertoPorCodigo("EZE"), BuscarAeropuertoPorCodigo("SCL"), 85));
        CrearRuta(new Ruta(BuscarAeropuertoPorCodigo("JFK"), BuscarAeropuertoPorCodigo("LAX"), 125));
        CrearRuta(new Ruta(BuscarAeropuertoPorCodigo("SYD"), BuscarAeropuertoPorCodigo("FRA"), 175));
        CrearRuta(new Ruta(BuscarAeropuertoPorCodigo("DXB"), BuscarAeropuertoPorCodigo("CDG"), 150));
        CrearRuta(new Ruta(BuscarAeropuertoPorCodigo("LIM"), BuscarAeropuertoPorCodigo("GRU"), 95));
        CrearRuta(new Ruta(BuscarAeropuertoPorCodigo("MAD"), BuscarAeropuertoPorCodigo("EZE"), 155));
        CrearRuta(new Ruta(BuscarAeropuertoPorCodigo("AMS"), BuscarAeropuertoPorCodigo("JNB"), 165));
        CrearRuta(new Ruta(BuscarAeropuertoPorCodigo("ICN"), BuscarAeropuertoPorCodigo("MEX"), 145));
        CrearRuta(new Ruta(BuscarAeropuertoPorCodigo("NRT"), BuscarAeropuertoPorCodigo("CDG"), 155));
        CrearRuta(new Ruta(BuscarAeropuertoPorCodigo("YYZ"), BuscarAeropuertoPorCodigo("BCN"), 115));
        CrearRuta(new Ruta(BuscarAeropuertoPorCodigo("BOG"), BuscarAeropuertoPorCodigo("LHR"), 130));
    }
    
    
    
    
}