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
        if(_usuarios.Contains(u)) throw new Exception("El usuario ya existe con el correo dado");
        u.Validar();
        _usuarios.Add(u);
    }
   
    // BUSCAR CLIENTE POR CORREO
    public Cliente BuscarCliente(string correo)
    {
        Cliente u = null;
        int i = 0;

        while (u == null && i < _usuarios.Count)
        {
            if (_usuarios[i] is Cliente c && c.Correo == correo) u = c;
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
        if(_aeropuertos.Contains(aeropuerto)) throw new Exception("El aeropuerto ya está existe en el Sistema");
        aeropuerto.Validar();
        _aeropuertos.Add(aeropuerto);
    }

    // PRECARGA DE AEROPUERTOS
    private void PrecargarAeropuertos()
    {
        AgregarAeropuerto(new Aeropuerto("FCO", "Roma", 130, 110));
        AgregarAeropuerto(new Aeropuerto("JFK", "Nueva York", 200, 180));
        AgregarAeropuerto(new Aeropuerto("CDG", "París", 150, 130));
        AgregarAeropuerto(new Aeropuerto("LHR", "Londres", 160, 140));
        AgregarAeropuerto(new Aeropuerto("EZE", "Buenos Aires", 120, 100));
        AgregarAeropuerto(new Aeropuerto("GRU", "São Paulo", 140, 115));
        AgregarAeropuerto(new Aeropuerto("NRT", "Tokio", 210, 190));
        AgregarAeropuerto(new Aeropuerto("SYD", "Sídney", 220, 195));
        AgregarAeropuerto(new Aeropuerto("MEX", "Ciudad de México", 130, 120));
        AgregarAeropuerto(new Aeropuerto("BCN", "Barcelona", 145, 125));
        AgregarAeropuerto(new Aeropuerto("FRA", "Fráncfort", 155, 135));
        AgregarAeropuerto(new Aeropuerto("AMS", "Ámsterdam", 150, 130));
        AgregarAeropuerto(new Aeropuerto("IST", "Estambul", 135, 120));
        AgregarAeropuerto(new Aeropuerto("SCL", "Santiago", 125, 105));
        AgregarAeropuerto(new Aeropuerto("YYZ", "Toronto", 160, 145));
        AgregarAeropuerto(new Aeropuerto("DXB", "Dubái", 180, 160));
        AgregarAeropuerto(new Aeropuerto("SIN", "Singapur", 200, 185));
        AgregarAeropuerto(new Aeropuerto("JNB", "Johannesburgo", 140, 125));
        AgregarAeropuerto(new Aeropuerto("LAX", "Los Ángeles", 190, 170));
        AgregarAeropuerto(new Aeropuerto("MAD", "Madrid", 150, 135));
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
        if(_rutas.Contains(r)) throw new Exception("La ruta dada ya existe en el Sistema");
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
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("FCO"), BuscarAeropuertoPorCodigo("JFK"), 13000));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("CDG"), BuscarAeropuertoPorCodigo("LHR"), 340));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("EZE"), BuscarAeropuertoPorCodigo("GRU"), 1700));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("NRT"), BuscarAeropuertoPorCodigo("SYD"), 7800));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("MEX"), BuscarAeropuertoPorCodigo("BCN"), 9400));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("FRA"), BuscarAeropuertoPorCodigo("AMS"), 440));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("IST"), BuscarAeropuertoPorCodigo("SCL"), 13300));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("YYZ"), BuscarAeropuertoPorCodigo("DXB"), 11100));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("SIN"), BuscarAeropuertoPorCodigo("JNB"), 8700));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("LAX"), BuscarAeropuertoPorCodigo("MAD"), 9400));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("JFK"), BuscarAeropuertoPorCodigo("CDG"), 5850));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("LHR"), BuscarAeropuertoPorCodigo("FCO"), 1430));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("GRU"), BuscarAeropuertoPorCodigo("NRT"), 18500));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("SYD"), BuscarAeropuertoPorCodigo("EZE"), 11800));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("BCN"), BuscarAeropuertoPorCodigo("FRA"), 1150));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("AMS"), BuscarAeropuertoPorCodigo("IST"), 2200));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("SCL"), BuscarAeropuertoPorCodigo("YYZ"), 8500));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("DXB"), BuscarAeropuertoPorCodigo("SIN"), 5800));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("JNB"), BuscarAeropuertoPorCodigo("LAX"), 16100));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("MAD"), BuscarAeropuertoPorCodigo("MEX"), 9100));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("JFK"), BuscarAeropuertoPorCodigo("EZE"), 8500));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("CDG"), BuscarAeropuertoPorCodigo("DXB"), 5250));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("LHR"), BuscarAeropuertoPorCodigo("SIN"), 10800));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("GRU"), BuscarAeropuertoPorCodigo("JNB"), 7650));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("SYD"), BuscarAeropuertoPorCodigo("BCN"), 17300));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("MEX"), BuscarAeropuertoPorCodigo("IST"), 11150));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("FRA"), BuscarAeropuertoPorCodigo("YYZ"), 6350));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("AMS"), BuscarAeropuertoPorCodigo("MAD"), 1450));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("IST"), BuscarAeropuertoPorCodigo("LAX"), 11100));
        AgregarRuta(new Ruta(BuscarAeropuertoPorCodigo("SCL"), BuscarAeropuertoPorCodigo("JFK"), 8400));

    }

    // CREACION DE AVION
    public void AgregarAvion(Avion a) 
    {
        if (a == null) throw new Exception("El avion no puede ser nulo");
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
        AgregarAvion(new Avion("Airbus", "A320", 170, 6100, 36000));
        AgregarAvion(new Avion("Embraer", "E195", 132, 4200, 28000));
        AgregarAvion(new Avion("Boeing", "787", 242, 13600, 55000));
        AgregarAvion(new Avion("Airbus", "A350", 300, 15000, 60000));
    }

    // CREACION DE VUELO
    public void AgregarVuelo(Vuelo v)
    {
        if (v == null) throw new Exception("El vuelo no puede ser nulo");
        v.Validar();
        if(_vuelos.Contains(v)) throw new Exception("Ya existe un vuelo con el número de vuelo dado");
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
        AgregarVuelo(new Vuelo("AB1234", BuscarRuta(1), BuscarAvion("Boeing", "737"), new List<DayOfWeek> { DayOfWeek.Monday, DayOfWeek.Friday }));
        AgregarVuelo(new Vuelo("CD2345", BuscarRuta(2), BuscarAvion("Airbus", "A320"), new List<DayOfWeek> { DayOfWeek.Tuesday }));
        AgregarVuelo(new Vuelo("EF3456", BuscarRuta(3), BuscarAvion("Embraer", "E195"), new List<DayOfWeek> { DayOfWeek.Wednesday, DayOfWeek.Saturday }));
        AgregarVuelo(new Vuelo("GH4567", BuscarRuta(4), BuscarAvion("Boeing", "787"), new List<DayOfWeek> { DayOfWeek.Thursday }));
        AgregarVuelo(new Vuelo("IJ5678", BuscarRuta(5), BuscarAvion("Airbus", "A350"), new List<DayOfWeek> { DayOfWeek.Sunday, DayOfWeek.Monday }));
        AgregarVuelo(new Vuelo("KL6789", BuscarRuta(6), BuscarAvion("Boeing", "737"), new List<DayOfWeek> { DayOfWeek.Friday }));
        AgregarVuelo(new Vuelo("MN7890", BuscarRuta(7), BuscarAvion("Airbus", "A320"), new List<DayOfWeek> { DayOfWeek.Tuesday, DayOfWeek.Thursday }));
        AgregarVuelo(new Vuelo("OP8901", BuscarRuta(8), BuscarAvion("Embraer", "E195"), new List<DayOfWeek> { DayOfWeek.Saturday }));
        AgregarVuelo(new Vuelo("QR9012", BuscarRuta(9), BuscarAvion("Boeing", "787"), new List<DayOfWeek> { DayOfWeek.Monday }));
        AgregarVuelo(new Vuelo("ST0123", BuscarRuta(10), BuscarAvion("Airbus", "A350"), new List<DayOfWeek> { DayOfWeek.Wednesday }));
        AgregarVuelo(new Vuelo("UV1235", BuscarRuta(11), BuscarAvion("Boeing", "737"), new List<DayOfWeek> { DayOfWeek.Sunday }));
        AgregarVuelo(new Vuelo("WX2346", BuscarRuta(12), BuscarAvion("Airbus", "A320"), new List<DayOfWeek> { DayOfWeek.Friday, DayOfWeek.Saturday }));
        AgregarVuelo(new Vuelo("YZ3457", BuscarRuta(13), BuscarAvion("Embraer", "E195"), new List<DayOfWeek> { DayOfWeek.Monday }));
        AgregarVuelo(new Vuelo("AA4568", BuscarRuta(14), BuscarAvion("Boeing", "787"), new List<DayOfWeek> { DayOfWeek.Tuesday }));
        AgregarVuelo(new Vuelo("BB5679", BuscarRuta(15), BuscarAvion("Airbus", "A350"), new List<DayOfWeek> { DayOfWeek.Thursday }));
        AgregarVuelo(new Vuelo("CC6780", BuscarRuta(16), BuscarAvion("Boeing", "737"), new List<DayOfWeek> { DayOfWeek.Saturday }));
        AgregarVuelo(new Vuelo("DD7891", BuscarRuta(17), BuscarAvion("Airbus", "A320"), new List<DayOfWeek> { DayOfWeek.Sunday, DayOfWeek.Wednesday }));
        AgregarVuelo(new Vuelo("EE8902", BuscarRuta(18), BuscarAvion("Embraer", "E195"), new List<DayOfWeek> { DayOfWeek.Monday }));
        AgregarVuelo(new Vuelo("FF9013", BuscarRuta(19), BuscarAvion("Boeing", "787"), new List<DayOfWeek> { DayOfWeek.Friday }));
        AgregarVuelo(new Vuelo("GG0124", BuscarRuta(20), BuscarAvion("Airbus", "A350"), new List<DayOfWeek> { DayOfWeek.Wednesday }));
        AgregarVuelo(new Vuelo("HH1236", BuscarRuta(21), BuscarAvion("Boeing", "737"), new List<DayOfWeek> { DayOfWeek.Tuesday }));
        AgregarVuelo(new Vuelo("II2347", BuscarRuta(22), BuscarAvion("Airbus", "A320"), new List<DayOfWeek> { DayOfWeek.Monday, DayOfWeek.Thursday }));
        AgregarVuelo(new Vuelo("JJ3458", BuscarRuta(23), BuscarAvion("Embraer", "E195"), new List<DayOfWeek> { DayOfWeek.Sunday }));
        AgregarVuelo(new Vuelo("KK4569", BuscarRuta(24), BuscarAvion("Boeing", "787"), new List<DayOfWeek> { DayOfWeek.Tuesday }));
        AgregarVuelo(new Vuelo("LL5670", BuscarRuta(25), BuscarAvion("Airbus", "A350"), new List<DayOfWeek> { DayOfWeek.Friday }));
        AgregarVuelo(new Vuelo("MM6781", BuscarRuta(26), BuscarAvion("Boeing", "737"), new List<DayOfWeek> { DayOfWeek.Saturday }));
        AgregarVuelo(new Vuelo("NN7892", BuscarRuta(27), BuscarAvion("Airbus", "A320"), new List<DayOfWeek> { DayOfWeek.Monday }));
        AgregarVuelo(new Vuelo("OO8903", BuscarRuta(28), BuscarAvion("Embraer", "E195"), new List<DayOfWeek> { DayOfWeek.Thursday }));
        AgregarVuelo(new Vuelo("PP9014", BuscarRuta(29), BuscarAvion("Boeing", "787"), new List<DayOfWeek> { DayOfWeek.Sunday }));
        AgregarVuelo(new Vuelo("QQ0125", BuscarRuta(30), BuscarAvion("Airbus", "A350"), new List<DayOfWeek> { DayOfWeek.Wednesday, DayOfWeek.Friday }));
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
        AgregarPasaje(new Pasaje(BuscarVuelo("CD2345"), new DateTime(2025, 6, 2), BuscarCliente("carlossainz55@gmail.com"), Equipaje.CABINA, 1500));
        AgregarPasaje(new Pasaje(BuscarVuelo("EF3456"), new DateTime(2025, 6, 3), BuscarCliente("maria.lopez92@gmail.com"), Equipaje.BODEGA, 2000));
        AgregarPasaje(new Pasaje(BuscarVuelo("GH4567"), new DateTime(2025, 6, 4), BuscarCliente("john.doe84@yahoo.com"), Equipaje.LIGHT, 1800));
        AgregarPasaje(new Pasaje(BuscarVuelo("IJ5678"), new DateTime(2025, 6, 5), BuscarCliente("luigi.rossi@outlook.it"), Equipaje.CABINA, 2200));
        AgregarPasaje(new Pasaje(BuscarVuelo("KL6789"), new DateTime(2025, 6, 6), BuscarCliente("emily.jones@protonmail.com"), Equipaje.BODEGA, 2100));
        AgregarPasaje(new Pasaje(BuscarVuelo("MN7890"), new DateTime(2025, 6, 7), BuscarCliente("fernandoalonso14@gmail.com"), Equipaje.LIGHT, 2500));
        AgregarPasaje(new Pasaje(BuscarVuelo("OP8901"), new DateTime(2025, 6, 8), BuscarCliente("oliverbearman87@gmail.com"), Equipaje.CABINA, 2300));
        AgregarPasaje(new Pasaje(BuscarVuelo("QR9012"), new DateTime(2025, 6, 9), BuscarCliente("charlesleclerc@gmail.com"), Equipaje.BODEGA, 1900));
        AgregarPasaje(new Pasaje(BuscarVuelo("ST0123"), new DateTime(2025, 6, 10), BuscarCliente("kimiantonelli12@gmail.com"), Equipaje.LIGHT, 1700));
        AgregarPasaje(new Pasaje(BuscarVuelo("UV1235"), new DateTime(2025, 6, 11), BuscarCliente("lewishamilton44@gmail.com"), Equipaje.CABINA, 2600));
        AgregarPasaje(new Pasaje(BuscarVuelo("WX2346"), new DateTime(2025, 6, 12), BuscarCliente("carlossainz55@gmail.com"), Equipaje.BODEGA, 2400));
        AgregarPasaje(new Pasaje(BuscarVuelo("YZ3457"), new DateTime(2025, 6, 13), BuscarCliente("maria.lopez92@gmail.com"), Equipaje.LIGHT, 2200));
        AgregarPasaje(new Pasaje(BuscarVuelo("AA4568"), new DateTime(2025, 6, 14), BuscarCliente("john.doe84@yahoo.com"), Equipaje.CABINA, 2000));
        AgregarPasaje(new Pasaje(BuscarVuelo("BB5679"), new DateTime(2025, 6, 15), BuscarCliente("luigi.rossi@outlook.it"), Equipaje.BODEGA, 2100));
        AgregarPasaje(new Pasaje(BuscarVuelo("CC6780"), new DateTime(2025, 6, 16), BuscarCliente("emily.jones@protonmail.com"), Equipaje.LIGHT, 1800));
        AgregarPasaje(new Pasaje(BuscarVuelo("DD7891"), new DateTime(2025, 6, 17), BuscarCliente("fernandoalonso14@gmail.com"), Equipaje.CABINA, 2300));
        AgregarPasaje(new Pasaje(BuscarVuelo("EE8902"), new DateTime(2025, 6, 18), BuscarCliente("oliverbearman87@gmail.com"), Equipaje.BODEGA, 2500));
        AgregarPasaje(new Pasaje(BuscarVuelo("FF9013"), new DateTime(2025, 6, 19), BuscarCliente("charlesleclerc@gmail.com"), Equipaje.LIGHT, 2100));
        AgregarPasaje(new Pasaje(BuscarVuelo("GG0124"), new DateTime(2025, 6, 20), BuscarCliente("kimiantonelli12@gmail.com"), Equipaje.CABINA, 2400));
        AgregarPasaje(new Pasaje(BuscarVuelo("HH1236"), new DateTime(2025, 6, 21), BuscarCliente("lewishamilton44@gmail.com"), Equipaje.BODEGA, 2800));
        AgregarPasaje(new Pasaje(BuscarVuelo("II2347"), new DateTime(2025, 6, 22), BuscarCliente("carlossainz55@gmail.com"), Equipaje.LIGHT, 2200));
        AgregarPasaje(new Pasaje(BuscarVuelo("JJ3458"), new DateTime(2025, 6, 23), BuscarCliente("maria.lopez92@gmail.com"), Equipaje.CABINA, 2000));
        AgregarPasaje(new Pasaje(BuscarVuelo("KK4569"), new DateTime(2025, 6, 24), BuscarCliente("john.doe84@yahoo.com"), Equipaje.BODEGA, 2300));
        AgregarPasaje(new Pasaje(BuscarVuelo("LL5670"), new DateTime(2025, 6, 25), BuscarCliente("luigi.rossi@outlook.it"), Equipaje.LIGHT, 1900));
        AgregarPasaje(new Pasaje(BuscarVuelo("MM6781"), new DateTime(2025, 6, 26), BuscarCliente("emily.jones@protonmail.com"), Equipaje.CABINA, 2400));
        AgregarPasaje(new Pasaje(BuscarVuelo("NN7892"), new DateTime(2025, 6, 27), BuscarCliente("fernandoalonso14@gmail.com"), Equipaje.BODEGA, 2600));
        AgregarPasaje(new Pasaje(BuscarVuelo("OO8903"), new DateTime(2025, 6, 28), BuscarCliente("oliverbearman87@gmail.com"), Equipaje.LIGHT, 2300));
        AgregarPasaje(new Pasaje(BuscarVuelo("PP9014"), new DateTime(2025, 6, 29), BuscarCliente("charlesleclerc@gmail.com"), Equipaje.CABINA, 2200));
    }

    //LISTADO DE CLIENTES
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
    
    // LISTADO DE VUELO POR CODIGO IATA
    public List<Vuelo> ListarVuelos(string codigoIATA)
    {
        List<Vuelo> vuelos = new List<Vuelo>();
        Aeropuerto a = BuscarAeropuertoPorCodigo(codigoIATA);

        foreach (Vuelo v in _vuelos)
        { 
            if(v.ContieneAeropuerto(a)) vuelos.Add(v);
        }

        return vuelos;
    }

    // LISTADO DE PASAJE SEGUN DOS FECHAS DADAS
    public List<Pasaje> ListarPasajesSegunFechas(DateTime desde, DateTime hasta)
    {
        List<Pasaje> buscados = new List<Pasaje>();
        
        if (desde > hasta)
        {
            DateTime auxFecha = desde;
            desde = hasta;
            hasta = auxFecha;
        }
        
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