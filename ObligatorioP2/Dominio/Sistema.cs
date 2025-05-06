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
   
    // BUSCAR CLIENTE POR CORREO
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


    // BUSCAR CLIENTE POR DOCUMENTO
    public Cliente BuscarDocumento(string documento)
    {
        Cliente u = null;
        int i = 0;

        while (u == null && i < _usuarios.Count)
        {
            if (_usuarios[i] is Cliente c && c.Documento == documento) u = c;
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
        AgregarAeropuerto(new Aeropuerto("FCO", "Roma", 130, 110));
        AgregarAeropuerto(new Aeropuerto("AKL", "Auckland", 140, 120));
        AgregarAeropuerto(new Aeropuerto("MIA", "Miami", 150, 130));
        AgregarAeropuerto(new Aeropuerto("ORD", "Chicago", 145, 125));
        AgregarAeropuerto(new Aeropuerto("YVR", "Vancouver", 135, 115));
        AgregarAeropuerto(new Aeropuerto("BOM", "Bombay", 140, 120));
        AgregarAeropuerto(new Aeropuerto("DEL", "Delhi", 150, 130));
        AgregarAeropuerto(new Aeropuerto("CUN", "Cancún", 120, 100));
        AgregarAeropuerto(new Aeropuerto("LIM", "Lima", 125, 105));
        AgregarAeropuerto(new Aeropuerto("BOG", "Bogotá", 130, 110));
        AgregarAeropuerto(new Aeropuerto("MAD", "Madrid", 140, 120));
        AgregarAeropuerto(new Aeropuerto("OSL", "Oslo", 130, 110));
        AgregarAeropuerto(new Aeropuerto("SIN", "Singapur", 145, 125));
        AgregarAeropuerto(new Aeropuerto("KUL", "Kuala Lumpur", 140, 120));
        AgregarAeropuerto(new Aeropuerto("SVO", "Moscú", 135, 115));
        AgregarAeropuerto(new Aeropuerto("LED", "San Petersburgo", 130, 110));
        AgregarAeropuerto(new Aeropuerto("DOH", "Doha", 150, 130));
        AgregarAeropuerto(new Aeropuerto("AUH", "Abu Dhabi", 140, 120));
        AgregarAeropuerto(new Aeropuerto("MUC", "Múnich", 135, 115));
        AgregarAeropuerto(new Aeropuerto("ZRH", "Zúrich", 130, 110));
        AgregarAeropuerto(new Aeropuerto("VIE", "Viena", 125, 105));
        AgregarAeropuerto(new Aeropuerto("PRG", "Praga", 120, 100));
        AgregarAeropuerto(new Aeropuerto("ATH", "Atenas", 130, 110));
        AgregarAeropuerto(new Aeropuerto("BKK", "Bangkok", 145, 125));
        AgregarAeropuerto(new Aeropuerto("ATL", "Atlanta", 140, 120));
        AgregarAeropuerto(new Aeropuerto("SEA", "Seattle", 135, 115));
        AgregarAeropuerto(new Aeropuerto("DEN", "Denver", 130, 110));
        AgregarAeropuerto(new Aeropuerto("DCA", "Washington DC", 125, 105));
        AgregarAeropuerto(new Aeropuerto("BOS", "Boston", 120, 100));
    }

    // FUNCION PARA USAR EN RUTAS SE BUSCA AEROPUERTO POR CODIGO IATA
    public Aeropuerto BuscarAeropuertoPorCodigo(string codigo)
    {
        Aeropuerto a = null;
        int i = 0;
        while (a == null && i < _aeropuertos.Count)
        {
            if(_aeropuertos[i].Codigo.ToUpper() == codigo.ToUpper()) a = _aeropuertos[i];
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
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("FCO"), BuscarAeropuertoPorCodigo("AKL"), 13000));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("AKL"), BuscarAeropuertoPorCodigo("MIA"), 16000));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("MIA"), BuscarAeropuertoPorCodigo("ORD"), 2500));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("ORD"), BuscarAeropuertoPorCodigo("YVR"), 3300));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("YVR"), BuscarAeropuertoPorCodigo("BOM"), 12000));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("BOM"), BuscarAeropuertoPorCodigo("DEL"), 1140));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("DEL"), BuscarAeropuertoPorCodigo("CUN"), 5000));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("CUN"), BuscarAeropuertoPorCodigo("LIM"), 2000));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("LIM"), BuscarAeropuertoPorCodigo("BOG"), 1800));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("BOG"), BuscarAeropuertoPorCodigo("MAD"), 9000));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("MAD"), BuscarAeropuertoPorCodigo("OSL"), 2500));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("OSL"), BuscarAeropuertoPorCodigo("SIN"), 11500));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("SIN"), BuscarAeropuertoPorCodigo("KUL"), 300));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("KUL"), BuscarAeropuertoPorCodigo("SVO"), 2500));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("SVO"), BuscarAeropuertoPorCodigo("LED"), 800));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("LED"), BuscarAeropuertoPorCodigo("DOH"), 3500));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("DOH"), BuscarAeropuertoPorCodigo("AUH"), 320));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("AUH"), BuscarAeropuertoPorCodigo("MUC"), 5000));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("MUC"), BuscarAeropuertoPorCodigo("ZRH"), 320));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("ZRH"), BuscarAeropuertoPorCodigo("VIE"), 500));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("VIE"), BuscarAeropuertoPorCodigo("PRG"), 200));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("PRG"), BuscarAeropuertoPorCodigo("ATH"), 1500));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("ATH"), BuscarAeropuertoPorCodigo("BKK"), 8000));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("BKK"), BuscarAeropuertoPorCodigo("ATL"), 14000));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("ATL"), BuscarAeropuertoPorCodigo("SEA"), 1000));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("SEA"), BuscarAeropuertoPorCodigo("DEN"), 1700));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("DEN"), BuscarAeropuertoPorCodigo("DCA"), 1500));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("DCA"), BuscarAeropuertoPorCodigo("BOS"), 650));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("BOS"), BuscarAeropuertoPorCodigo("MIA"), 1750));
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