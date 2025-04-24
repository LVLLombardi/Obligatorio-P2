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
        u.Validar();
        _usuarios.Add(u);
    }
    //BUSCAR CLIENTE POR CORREO Y CONTRASEÑA
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
        if (BuscarAeropuertoPorCodigo(aeropuerto.Codigo)!= null) throw new Exception("El aeropuerto ya está cargado");//validacion de que aeropuerto ya no esté creado
        aeropuerto.Validar();
        _aeropuertos.Add(aeropuerto);
    }

    // PRECARGA DE AEROPUERTOS
    private void PrecargarAeropuertos()
    {
        AgregarAeropuerto(new Aeropuerto("MAD", "Madrid", 130, 110));
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

    //BUSCAR RUTA POR ID
    public Ruta BuscarRuta(int IdRuta)
    {
        foreach (Ruta r in _rutas)
        {
            if (r.Id == IdRuta) return r;
        }
        return null;
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
        AgregarVuelo(new Vuelo("GH5566", BuscarRuta(30), BuscarAvion("Airbus", "A320"), Frecuencia.Martes));

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
        AgregarPasaje(new Pasaje(BuscarVuelo("AB1234"), BuscarCliente("lewishamilton44@gmail.com"), Equipaje.LIGHT, 1200));
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
        AgregarPasaje(new Pasaje(BuscarVuelo("WX1234"), BuscarCliente("kimiantonelli12@gmail.com"), Equipaje.LIGHT, 3870));

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
    public List<Vuelo> ListarVuelos()
    {
        List<Vuelo> vuelos = new List<Vuelo>();
        foreach (Vuelo v in _vuelos)
        {
            if (v is Vuelo)
            {
                vuelos.Add(v);
            }
        }
        return vuelos;
    }
    
}