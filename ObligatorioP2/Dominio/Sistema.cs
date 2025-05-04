using System.Reflection;
using System.Text;

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
        PrecargarVuelos();
        PrecargarPasajes();
    }

    // CREACION DE USUARIO
    public void AgregarUsuario(Usuario u)
    {
        if(u == null) throw new Exception("El nombre del usuario no puede ser nulo");
        if(ExisteUsuarioConCorreo(u.Correo)) throw new Exception("El correo del usuario ya existe");
        u.Validar();
        _usuarios.Add(u);
    }
    
    //VALIDACION QUE NO SE ENCUENTREN DOS CORREOS IGUALES
    private bool ExisteUsuarioConCorreo(string correo)
    {
        bool encontrado = false;
        foreach (Usuario usuario in _usuarios)
        {
            if (usuario.Correo == correo) encontrado = true;
        }
        return encontrado;
    }
    
    //BUSCAR CLIENTE POR CORREO
    public Cliente BuscarCliente(string correo)
    {
        Cliente u = null;
        int i = 0;

        while (u == null && i < _usuarios.Count)
        {
            if (_usuarios[i] is Cliente c && c.Correo == correo) u = c; // no hay que usar un equals?
            i++;
        }

        return u; 
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
        if (BuscarAeropuertoPorCodigo(aeropuerto.Codigo) != null) throw new Exception("El aeropuerto ya está existe en el Sistema");//validacion de que aeropuerto ya no esté creado
        aeropuerto.Validar();
        _aeropuertos.Add(aeropuerto);
    }

    // PRECARGA DE AEROPUERTOS
    private void PrecargarAeropuertos()
    {
        AgregarAeropuerto(new Aeropuerto("JFK", "Nueva York", 150, 120));
        AgregarAeropuerto(new Aeropuerto("LAX", "Los Angeles", 170, 130));
        AgregarAeropuerto(new Aeropuerto("CDG", "Paris", 140, 110));
        AgregarAeropuerto(new Aeropuerto("NRT", "Tokio", 180, 150));
        AgregarAeropuerto(new Aeropuerto("SYD", "Sídney", 160, 140));
        AgregarAeropuerto(new Aeropuerto("FRA", "Fráncfort", 130, 100));
        AgregarAeropuerto(new Aeropuerto("GRU", "São Paulo", 125, 95));
        AgregarAeropuerto(new Aeropuerto("dxB", "Dubái", 155, 135));
        AgregarAeropuerto(new Aeropuerto("AMS", "Ámsterdam", 145, 115));
        AgregarAeropuerto(new Aeropuerto("YYZ", "Toronto", 135, 105));
        AgregarAeropuerto(new Aeropuerto("SFO", "San Francisco", 165, 125));
        AgregarAeropuerto(new Aeropuerto("ICN", "Seúl", 150, 120));
        AgregarAeropuerto(new Aeropuerto("BCN", "Barcelona", 120, 100));
        AgregarAeropuerto(new Aeropuerto("LHR", "Londres", 175, 145));
        AgregarAeropuerto(new Aeropuerto("mEX", "Ciudad de México", 110, 90));
        AgregarAeropuerto(new Aeropuerto("IST", "Estambul", 130, 110));
        AgregarAeropuerto(new Aeropuerto("JNB", "Johannesburgo", 140, 120));
        AgregarAeropuerto(new Aeropuerto("HND", "Haneda", 160, 130));
        AgregarAeropuerto(new Aeropuerto("PEK", "Pekín", 155, 125));
        AgregarAeropuerto(new Aeropuerto("EZE", "Buenos Aires", 115, 95));

        /*AgregarAeropuerto(new Aeropuerto("BCN", "Barcelona", 110, 95));
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
        AgregarAeropuerto(new Aeropuerto("JNB", "Johannesburgo", 125, 105)); */
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

    //BUSCAR RUTA POR ID
    public Ruta BuscarRuta(int idRuta)
    {
        foreach (Ruta r in _rutas)
        {
            if (r.Id == idRuta) return r;
        }
        return null;
    }

    // PRECARGA DE RUTAS
    private void PrecargarRutas()
    {
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("bcn"), BuscarAeropuertoPorCodigo("JFK"), 6174));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("JFK"), BuscarAeropuertoPorCodigo("lhr"), 5540));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("lax"), BuscarAeropuertoPorCodigo("NRT"), 8780));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("CDG"), BuscarAeropuertoPorCodigo("fco"), 1100));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("gru"), BuscarAeropuertoPorCodigo("EZE"), 1670));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("syd"), BuscarAeropuertoPorCodigo("AKL"), 2150));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("JFK"), BuscarAeropuertoPorCodigo("mia"), 1750));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("sfo"), BuscarAeropuertoPorCodigo("ORD"), 2970));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("YYZ"), BuscarAeropuertoPorCodigo("yvr"), 3350));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("fra"), BuscarAeropuertoPorCodigo("DXB"), 4840));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("bom"), BuscarAeropuertoPorCodigo("DEL"), 1140));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("jnb"), BuscarAeropuertoPorCodigo("CPT"), 1270));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("MEX"), BuscarAeropuertoPorCodigo("cun"), 1290));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("lim"), BuscarAeropuertoPorCodigo("BOG"), 1880));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("MAD"), BuscarAeropuertoPorCodigo("bcn"), 500));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("ams"), BuscarAeropuertoPorCodigo("OSL"), 960));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("HND"), BuscarAeropuertoPorCodigo("icn"), 1250));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("sin"), BuscarAeropuertoPorCodigo("KUL"), 300));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("SVO"), BuscarAeropuertoPorCodigo("led"), 635));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("doh"), BuscarAeropuertoPorCodigo("AUH"), 320));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("muc"), BuscarAeropuertoPorCodigo("ZRH"), 320));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("VIE"), BuscarAeropuertoPorCodigo("prg"), 300));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("ath"), BuscarAeropuertoPorCodigo("IST"), 560));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("ICN"), BuscarAeropuertoPorCodigo("bkk"), 3660));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("lhr"), BuscarAeropuertoPorCodigo("DXB"), 5500));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("jfk"), BuscarAeropuertoPorCodigo("LAX"), 3970));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("ord"), BuscarAeropuertoPorCodigo("ATL"), 960));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("SEA"), BuscarAeropuertoPorCodigo("den"), 1700));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("dca"), BuscarAeropuertoPorCodigo("BOS"), 650));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("CPT"), BuscarAeropuertoPorCodigo("dxb"), 7610));

        /*AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("BCN"), BuscarAeropuertoPorCodigo("JFK"), 120));
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
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("BOG"), BuscarAeropuertoPorCodigo("LHR"), 130));*/
    }

    // CREACION DE AVION
    public void AgregarAvion(Avion a) // validacion extra de que no haya un fabricante y modelo iguales
    {
        if (a == null) throw new Exception("El avion no puede ser nulo");
        if (BuscarAvion(a.ModeloAvion,a.FabricanteAvion) != null) throw new Exception("Ya existe un avion con el mismo modelo y fabricante");
        a.Validar();
        _aviones.Add(a);
    }
    //BUSCAR AVIÓN POR MODELO Y FABRICANTE:
    public Avion BuscarAvion(string fabricante, string modelo)
    {
        Avion a = null;
        int i = 0;
        while (a == null && i < _aviones.Count)
        {
            if ((_aviones[i].FabricanteAvion == fabricante)&&(_aviones[i].ModeloAvion == modelo)) a = _aviones[i];
            i++;
        }

        return a;
    }

    // PRECARGA DE AVIONES
    private void PrecargarAviones()
    {
        AgregarAvion(new Avion("Boeing", "737", 180, 5000, 35000));
        AgregarAvion(new Avion("Airbus", "A320", 160, 4800, 33000));
        AgregarAvion(new Avion("Embraer", "E190", 100, 3000, 22000));
        AgregarAvion(new Avion("Boeing", "787", 250, 13000, 60000));
        AgregarAvion(new Avion("Airbus", "A350", 300, 15000, 75000));
        AgregarAvion(new Avion("Boeing", "767", 210, 11000, 55000));
        AgregarAvion(new Avion("Bombardier", "CRJ900", 90, 2800, 20000));
        AgregarAvion(new Avion("Airbus", "A330", 270, 13450, 72000));
        AgregarAvion(new Avion("Embraer", "E175", 88, 2900, 19000));
        AgregarAvion(new Avion("Boeing", "777", 280, 14400, 68000));
        AgregarAvion(new Avion("Airbus", "A319", 140, 4600, 31000));
        AgregarAvion(new Avion("Boeing", "757", 200, 7800, 47000));
        AgregarAvion(new Avion("Boeing", "747", 400, 13850, 85000));
        AgregarAvion(new Avion("Embraer", "E195", 110, 3200, 25000));
        AgregarAvion(new Avion("Bombardier", "CRJ1000", 100, 3000, 23000));
        AgregarAvion(new Avion("Airbus", "A321", 185, 5950, 36000));
        /*AgregarAvion(new Avion("Boeing", "737", 180, 5600, 15000));
        AgregarAvion(new Avion("Airbus", "A320", 160, 6100, 14000));
        AgregarAvion(new Avion("Embraer", "E190", 100, 4200, 9000));
        AgregarAvion(new Avion("Bombardier", "CRJ900", 90, 3700, 8500));*/
    }

    // CREACION DE VUELO
    public void AgregarVuelo(Vuelo v)
    {
        if (v == null) throw new Exception("El vuelo no puede ser nulo");
        v.Validar();
        _vuelos.Add(v);
    }
    //BUSCAR VUELO POR NUMERO DE VUELO
    public Vuelo BuscarVuelo(string numeroVuelo)
    {
        Vuelo v = null;
        int i = 0;
        while (v == null && i < _vuelos.Count)
        {
            if ((_vuelos[i].NumeroVuelo == numeroVuelo)) v = _vuelos[i];
            i++;
        }

        return v;
    }
    // PRECARGA DE VUELOS
    private void PrecargarVuelos()
    {
        AgregarVuelo(new Vuelo("AB1234", BuscarRuta(1), BuscarAvion("Boeing", "737"), Frecuencia.Lunes));
        AgregarVuelo(new Vuelo("CD5678", BuscarRuta(2), BuscarAvion("Airbus", "A320"), Frecuencia.Martes));
        AgregarVuelo(new Vuelo("EF9101", BuscarRuta(3), BuscarAvion("Embraer", "E190"), Frecuencia.Miercoles));
        AgregarVuelo(new Vuelo("GH2345", BuscarRuta(4), BuscarAvion("Boeing", "787"), Frecuencia.Jueves));
        AgregarVuelo(new Vuelo("IJ6789", BuscarRuta(5), BuscarAvion("Airbus", "A350"), Frecuencia.Viernes));
        AgregarVuelo(new Vuelo("KL3456", BuscarRuta(6), BuscarAvion("Boeing", "767"), Frecuencia.Sabado));
        AgregarVuelo(new Vuelo("MN7890", BuscarRuta(7), BuscarAvion("Bombardier", "CRJ900"), Frecuencia.Domingo));
        AgregarVuelo(new Vuelo("OP1234", BuscarRuta(8), BuscarAvion("Airbus", "A330"), Frecuencia.Lunes));
        AgregarVuelo(new Vuelo("QR5678", BuscarRuta(9), BuscarAvion("Boeing", "737"), Frecuencia.Martes));
        AgregarVuelo(new Vuelo("ST9101", BuscarRuta(10), BuscarAvion("Embraer", "E175"), Frecuencia.Miercoles));
        AgregarVuelo(new Vuelo("UV2345", BuscarRuta(11), BuscarAvion("Boeing", "777"), Frecuencia.Jueves));
        AgregarVuelo(new Vuelo("WX6789", BuscarRuta(12), BuscarAvion("Airbus", "A319"), Frecuencia.Viernes));
        AgregarVuelo(new Vuelo("YZ3456", BuscarRuta(13), BuscarAvion("Boeing", "757"), Frecuencia.Sabado));
        AgregarVuelo(new Vuelo("AB5678", BuscarRuta(14), BuscarAvion("Airbus", "A320"), Frecuencia.Domingo));
        AgregarVuelo(new Vuelo("CD9101", BuscarRuta(15), BuscarAvion("Boeing", "787"), Frecuencia.Lunes));
        AgregarVuelo(new Vuelo("EF2345", BuscarRuta(16), BuscarAvion("Airbus", "A350"), Frecuencia.Martes));
        AgregarVuelo(new Vuelo("GH6789", BuscarRuta(17), BuscarAvion("Boeing", "747"), Frecuencia.Miercoles));
        AgregarVuelo(new Vuelo("IJ3456", BuscarRuta(18), BuscarAvion("Embraer", "E195"), Frecuencia.Jueves));
        AgregarVuelo(new Vuelo("KL7890", BuscarRuta(19), BuscarAvion("Bombardier", "CRJ1000"), Frecuencia.Viernes));
        AgregarVuelo(new Vuelo("MN1234", BuscarRuta(20), BuscarAvion("Airbus", "A321"), Frecuencia.Sabado));
        AgregarVuelo(new Vuelo("OP5678", BuscarRuta(21), BuscarAvion("Boeing", "767"), Frecuencia.Domingo));
        AgregarVuelo(new Vuelo("QR9101", BuscarRuta(22), BuscarAvion("Airbus", "A330"), Frecuencia.Lunes));
        AgregarVuelo(new Vuelo("ST2345", BuscarRuta(23), BuscarAvion("Boeing", "737"), Frecuencia.Martes));
        AgregarVuelo(new Vuelo("UV6789", BuscarRuta(24), BuscarAvion("Embraer", "E190"), Frecuencia.Miercoles));
        AgregarVuelo(new Vuelo("WX3456", BuscarRuta(25), BuscarAvion("Boeing", "787"), Frecuencia.Jueves));

        /*AgregarVuelo(new Vuelo("AB1234", BuscarRuta(1), BuscarAvion("Boeing", "737"), Frecuencia.Lunes));
        AgregarVuelo(new Vuelo("CD5678", BuscarRuta(2), BuscarAvion("Airbus", "A320"), Frecuencia.Martes));
        AgregarVuelo(new Vuelo("EF9101", BuscarRuta(3), BuscarAvion("Embraer", "E190"), Frecuencia.Miercoles));
        AgregarVuelo(new Vuelo("GH1122", BuscarRuta(4), BuscarAvion("Bombardier", "CRJ900"), Frecuencia.Jueves));
        AgregarVuelo(new Vuelo("IJ3344", BuscarRuta(5), BuscarAvion("Boeing", "737"), Frecuencia.Viernes));
        AgregarVuelo(new Vuelo("KL5566", BuscarRuta(6), BuscarAvion("Airbus", "A320"), Frecuencia.Sabado));
        AgregarVuelo(new Vuelo("MN7788", BuscarRuta(7), BuscarAvion("Embraer", "E190"), Frecuencia.Domingo));
        AgregarVuelo(new Vuelo("OP9900", BuscarRuta(8), BuscarAvion("Bombardier", "CRJ900"), Frecuencia.Lunes));
        AgregarVuelo(new Vuelo("QR1234", BuscarRuta(9), BuscarAvion("Boeing", "737"), Frecuencia.Martes));
        AgregarVuelo(new Vuelo("ST5678", BuscarRuta(10), BuscarAvion("Airbus", "A320"), Frecuencia.Miercoles));
        
        AgregarVuelo(new Vuelo("UV9101", BuscarRuta(11), BuscarAvion("Embraer", "E190"), Frecuencia.Jueves));
        AgregarVuelo(new Vuelo("WX1122", BuscarRuta(12), BuscarAvion("Bombardier", "CRJ900"), Frecuencia.Viernes));
        AgregarVuelo(new Vuelo("YZ3344", BuscarRuta(13), BuscarAvion("Boeing", "737"), Frecuencia.Sabado));
        AgregarVuelo(new Vuelo("AB5566", BuscarRuta(14), BuscarAvion("Airbus", "A320"), Frecuencia.Domingo));
        AgregarVuelo(new Vuelo("CD7788", BuscarRuta(15), BuscarAvion("Embraer", "E190"), Frecuencia.Lunes));
        AgregarVuelo(new Vuelo("EF9900", BuscarRuta(16), BuscarAvion("Bombardier", "CRJ900"), Frecuencia.Martes));
        AgregarVuelo(new Vuelo("GH1234", BuscarRuta(17), BuscarAvion("Boeing", "737"), Frecuencia.Miercoles));
        AgregarVuelo(new Vuelo("IJ5678", BuscarRuta(18), BuscarAvion("Airbus", "A320"), Frecuencia.Jueves));
        AgregarVuelo(new Vuelo("KL9101", BuscarRuta(19), BuscarAvion("Embraer", "E190"), Frecuencia.Viernes));
        AgregarVuelo(new Vuelo("MN1122", BuscarRuta(20), BuscarAvion("Bombardier", "CRJ900"), Frecuencia.Sabado));

        AgregarVuelo(new Vuelo("OP3344", BuscarRuta(21), BuscarAvion("Boeing", "737"), Frecuencia.Domingo));
        AgregarVuelo(new Vuelo("QR5566", BuscarRuta(22), BuscarAvion("Airbus", "A320"), Frecuencia.Lunes));
        AgregarVuelo(new Vuelo("ST7788", BuscarRuta(23), BuscarAvion("Embraer", "E190"), Frecuencia.Martes));
        AgregarVuelo(new Vuelo("UV9900", BuscarRuta(24), BuscarAvion("Bombardier", "CRJ900"), Frecuencia.Miercoles));
        AgregarVuelo(new Vuelo("WX1234", BuscarRuta(25), BuscarAvion("Boeing", "737"), Frecuencia.Jueves));
        AgregarVuelo(new Vuelo("YZ5678", BuscarRuta(26), BuscarAvion("Airbus", "A320"), Frecuencia.Viernes));
        AgregarVuelo(new Vuelo("AB9101", BuscarRuta(27), BuscarAvion("Embraer", "E190"), Frecuencia.Sabado));
        AgregarVuelo(new Vuelo("CD1122", BuscarRuta(28), BuscarAvion("Bombardier", "CRJ900"), Frecuencia.Domingo));
        AgregarVuelo(new Vuelo("EF3344", BuscarRuta(29), BuscarAvion("Boeing", "737"), Frecuencia.Lunes));
        AgregarVuelo(new Vuelo("GH5566", BuscarRuta(30), BuscarAvion("Airbus", "A320"), Frecuencia.Martes));*/

    }

    // CREACION DE PASAJE 
    public void AgregarPasaje(Pasaje p)
    {
        if (p == null) throw new Exception("El pasaje no puede ser nulo");    
        p.Validar();
        _pasajes.Add(p);
    }
    
    // PRECARGA DE PASAJES

    private void PrecargarPasajes()
    {
        AgregarPasaje(new Pasaje(BuscarVuelo("AB1234"), new DateTime(2025, 6, 1), BuscarCliente("lewishamilton44@gmail.com"), Equipaje.LIGHT, 1200));
        AgregarPasaje(new Pasaje(BuscarVuelo("CD5678"), new DateTime(2025, 6, 3), BuscarCliente("fernandoalonso14@gmail.com"), Equipaje.CABINA, 2350));
        AgregarPasaje(new Pasaje(BuscarVuelo("EF9101"), new DateTime(2025, 6, 5), BuscarCliente("oliverbearman87@gmail.com"), Equipaje.BODEGA, 3120));
        AgregarPasaje(new Pasaje(BuscarVuelo("GH2345"), new DateTime(2025, 6, 7), BuscarCliente("charlesleclerc@gmail.com"), Equipaje.LIGHT, 4100));
        AgregarPasaje(new Pasaje(BuscarVuelo("IJ6789"), new DateTime(2025, 6, 9), BuscarCliente("kimiantonelli12@gmail.com"), Equipaje.CABINA, 1650));
        AgregarPasaje(new Pasaje(BuscarVuelo("KL3456"), new DateTime(2025, 6, 10), BuscarCliente("carlossainz55@gmail.com"), Equipaje.BODEGA, 4980));
        AgregarPasaje(new Pasaje(BuscarVuelo("MN7890"), new DateTime(2025, 6, 12), BuscarCliente("maria.lopez92@gmail.com"), Equipaje.CABINA, 1420));
        AgregarPasaje(new Pasaje(BuscarVuelo("OP1234"), new DateTime(2025, 6, 13), BuscarCliente("john.doe84@yahoo.com"), Equipaje.LIGHT, 1980));
        AgregarPasaje(new Pasaje(BuscarVuelo("QR5678"), new DateTime(2025, 6, 15), BuscarCliente("luigi.rossi@outlook.it"), Equipaje.BODEGA, 2590));
        AgregarPasaje(new Pasaje(BuscarVuelo("ST9101"), new DateTime(2025, 6, 17), BuscarCliente("emily.jones@protonmail.com"), Equipaje.LIGHT, 3300));
        AgregarPasaje(new Pasaje(BuscarVuelo("UV2345"), new DateTime(2025, 6, 18), BuscarCliente("lewishamilton44@gmail.com"), Equipaje.CABINA, 4700));
        AgregarPasaje(new Pasaje(BuscarVuelo("WX6789"), new DateTime(2025, 6, 19), BuscarCliente("fernandoalonso14@gmail.com"), Equipaje.BODEGA, 1240));
        AgregarPasaje(new Pasaje(BuscarVuelo("YZ3456"), new DateTime(2025, 6, 20), BuscarCliente("oliverbearman87@gmail.com"), Equipaje.LIGHT, 1390));
        AgregarPasaje(new Pasaje(BuscarVuelo("AB5678"), new DateTime(2025, 6, 22), BuscarCliente("charlesleclerc@gmail.com"), Equipaje.CABINA, 2230));
        AgregarPasaje(new Pasaje(BuscarVuelo("CD9101"), new DateTime(2025, 6, 23), BuscarCliente("kimiantonelli12@gmail.com"), Equipaje.BODEGA, 4990));
        AgregarPasaje(new Pasaje(BuscarVuelo("EF2345"), new DateTime(2025, 6, 25), BuscarCliente("carlossainz55@gmail.com"), Equipaje.LIGHT, 2600));
        AgregarPasaje(new Pasaje(BuscarVuelo("GH6789"), new DateTime(2025, 6, 27), BuscarCliente("maria.lopez92@gmail.com"), Equipaje.CABINA, 1790));
        AgregarPasaje(new Pasaje(BuscarVuelo("IJ3456"), new DateTime(2025, 6, 28), BuscarCliente("john.doe84@yahoo.com"), Equipaje.BODEGA, 4600));
        AgregarPasaje(new Pasaje(BuscarVuelo("KL7890"), new DateTime(2025, 6, 29), BuscarCliente("luigi.rossi@outlook.it"), Equipaje.LIGHT, 2070));
        AgregarPasaje(new Pasaje(BuscarVuelo("MN1234"), new DateTime(2025, 7, 1), BuscarCliente("emily.jones@protonmail.com"), Equipaje.CABINA, 3490));
        AgregarPasaje(new Pasaje(BuscarVuelo("OP5678"), new DateTime(2025, 7, 2), BuscarCliente("lewishamilton44@gmail.com"), Equipaje.BODEGA, 3150));
        AgregarPasaje(new Pasaje(BuscarVuelo("QR9101"), new DateTime(2025, 7, 3), BuscarCliente("fernandoalonso14@gmail.com"), Equipaje.LIGHT, 1800));
        AgregarPasaje(new Pasaje(BuscarVuelo("ST2345"), new DateTime(2025, 7, 4), BuscarCliente("oliverbearman87@gmail.com"), Equipaje.CABINA, 2670));
        AgregarPasaje(new Pasaje(BuscarVuelo("UV6789"), new DateTime(2025, 7, 5), BuscarCliente("charlesleclerc@gmail.com"), Equipaje.BODEGA, 4870));
        AgregarPasaje(new Pasaje(BuscarVuelo("WX3456"), new DateTime(2025, 7, 6), BuscarCliente("kimiantonelli12@gmail.com"), Equipaje.LIGHT, 1320));


        /*AgregarPasaje(new Pasaje(BuscarVuelo("AB1234"), BuscarCliente("lewishamilton44@gmail.com"), Equipaje.LIGHT, 1200));
        AgregarPasaje(new Pasaje(BuscarVuelo("CD5678"), BuscarCliente("fernandoalonso14@gmail.com"), Equipaje.CABINA, 3450));
        AgregarPasaje(new Pasaje(BuscarVuelo("EF9101"), BuscarCliente("oliverbearman87@gmail.com"), Equipaje.BODEGA, 2870));
        AgregarPasaje(new Pasaje(BuscarVuelo("GH1122"), BuscarCliente("charlesleclerc@gmail.com"), Equipaje.LIGHT, 1340));
        AgregarPasaje(new Pasaje(BuscarVuelo("IJ3344"), BuscarCliente("kimiantonelli12@gmail.com"), Equipaje.CABINA, 4260));
        AgregarPasaje(new Pasaje(BuscarVuelo("KL5566"), BuscarCliente("carlossainz55@gmail.com"), Equipaje.BODEGA, 2180));
        AgregarPasaje(new Pasaje(BuscarVuelo("MN7788"), BuscarCliente("maria.lopez92@gmail.com"), Equipaje.LIGHT, 1930));
        AgregarPasaje(new Pasaje(BuscarVuelo("OP9900"), BuscarCliente("john.doe84@yahoo.com"), Equipaje.CABINA, 3050));
        AgregarPasaje(new Pasaje(BuscarVuelo("QR1234"), BuscarCliente("luigi.rossi@outlook.it"), Equipaje.BODEGA, 4590));
        AgregarPasaje(new Pasaje(BuscarVuelo("ST5678"), BuscarCliente("emily.jones@protonmail.com"), Equipaje.LIGHT, 1510));
        AgregarPasaje(new Pasaje(BuscarVuelo("UV9101"), BuscarCliente("lewishamilton44@gmail.com"), Equipaje.CABINA, 2110));
        AgregarPasaje(new Pasaje(BuscarVuelo("WX1122"), BuscarCliente("fernandoalonso14@gmail.com"), Equipaje.BODEGA, 3750));
        AgregarPasaje(new Pasaje(BuscarVuelo("YZ3344"), BuscarCliente("oliverbearman87@gmail.com"), Equipaje.LIGHT, 1680));
        AgregarPasaje(new Pasaje(BuscarVuelo("AB5566"), BuscarCliente("charlesleclerc@gmail.com"), Equipaje.CABINA, 4920));
        AgregarPasaje(new Pasaje(BuscarVuelo("CD7788"), BuscarCliente("kimiantonelli12@gmail.com"), Equipaje.BODEGA, 1210));
        AgregarPasaje(new Pasaje(BuscarVuelo("EF9900"), BuscarCliente("carlossainz55@gmail.com"), Equipaje.LIGHT, 2260));
        AgregarPasaje(new Pasaje(BuscarVuelo("GH1234"), BuscarCliente("maria.lopez92@gmail.com"), Equipaje.CABINA, 1990));
        AgregarPasaje(new Pasaje(BuscarVuelo("IJ5678"), BuscarCliente("john.doe84@yahoo.com"), Equipaje.BODEGA, 3550));
        AgregarPasaje(new Pasaje(BuscarVuelo("KL9101"), BuscarCliente("luigi.rossi@outlook.it"), Equipaje.LIGHT, 2850));
        AgregarPasaje(new Pasaje(BuscarVuelo("MN1122"), BuscarCliente("emily.jones@protonmail.com"), Equipaje.CABINA, 1580));
        AgregarPasaje(new Pasaje(BuscarVuelo("OP3344"), BuscarCliente("lewishamilton44@gmail.com"), Equipaje.BODEGA, 4330));
        AgregarPasaje(new Pasaje(BuscarVuelo("QR5566"), BuscarCliente("fernandoalonso14@gmail.com"), Equipaje.LIGHT, 3190));
        AgregarPasaje(new Pasaje(BuscarVuelo("ST7788"), BuscarCliente("oliverbearman87@gmail.com"), Equipaje.CABINA, 2440));
        AgregarPasaje(new Pasaje(BuscarVuelo("UV9900"), BuscarCliente("charlesleclerc@gmail.com"), Equipaje.BODEGA, 1630));
        AgregarPasaje(new Pasaje(BuscarVuelo("WX1234"), BuscarCliente("kimiantonelli12@gmail.com"), Equipaje.LIGHT, 3870));*/

    }

    public List<Cliente> ListarClientes()
    {
        List<Cliente> clientes = new List<Cliente>();
        foreach (Usuario u in _usuarios)
        {
            if (u is Cliente cli)
            {
                clientes.Add(cli);
            }
        }
        return clientes;
    }

    public List<Pasaje> ListarPasajesSegunFechas(DateTime desde, DateTime hasta)
    {
        List<Pasaje> buscados = new List<Pasaje>();
        foreach (Pasaje p in _pasajes)
        {
            if (p.Fecha.Date >= desde.Date && p.Fecha.Date <= hasta.Date)
            {
                buscados.Add(p);
            }
        }
        return buscados;
    }
    
}