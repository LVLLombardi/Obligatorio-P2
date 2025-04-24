using Dominio;
using static ObligatorioP2.Program;

namespace ObligatorioP2;

class Program
{
    static Sistema miSistema;
    static void Main(string[] args)
    {
        miSistema = new Sistema();

        string opcion = "";
        while (opcion != "0")
        {
            MostrarMenu();
            Console.Write("Ingrese una opcion -> ");
            opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    ListarTodosLosClientes();
                    PressToContinue();
                    break;
                case "2":
                    ListarVuelosPorIATA();
                    PressToContinue();
                    break;
                case "3":
                    AltaClienteOcasional();
                    PressToContinue();
                    break;
                case "4":
                    ListarPasajesPorFecha();
                    PressToContinue();
                    break;
                case "5":
                    PressToContinue();
                    break;
                case "6":
                    PressToContinue();
                    break;
                case "0":
                    Console.WriteLine("Saliendo del Sistema...");
                    break;
                default:
                    MostrarError("ERROR: La opción NO es válida");
                    PressToContinue();
                    break;
            }
        }
    }

    static void MostrarMenu()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("****** MENU ******");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("1 - Listado de Todos los Clientes");
        Console.WriteLine("2 - Listar vuelos por código IATA");
        Console.WriteLine("3 - Alta de cliente ocasional");
        Console.WriteLine("4 - Listar pasajes entre dos fechas");
        Console.WriteLine("5 - ");
        Console.WriteLine("0 - Salir");
    }

    static void PressToContinue()
    {
        Console.WriteLine("Presione una tecla para continuar");
        Console.ReadKey();
    }

    static void MostrarError(string mensaje)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(mensaje);
        Console.ForegroundColor = ConsoleColor.Gray;
    }

    static void MostrarExito(string mensaje)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(mensaje);
        Console.ForegroundColor = ConsoleColor.Gray;
    }

    static string PedirPalabras(string mensaje)
    {
        Console.Write(mensaje);
        string dato = Console.ReadLine();
        return dato;
    }

    static int PedirNumeros(string mensaje)
    {
        bool exito = false;
        int numero = 0;
        while (!exito)
        {
            Console.Write(mensaje);
            exito = int.TryParse(Console.ReadLine(), out numero);

            if (!exito) MostrarError("ERROR: Debe ingresar solo numeros");
        }

        return numero;
    }

    /*static void CrearAeropuerto()
    {
        Console.Clear();
        Console.WriteLine("****** CREAR AEROPUERTO ******");
        Console.WriteLine();

        string codigo = PedirPalabras("Ingrese el Código IATA para el aeropuerto: ");
        string ciudad = PedirPalabras("Ingrese ciudad para el aeropuerto: ");
        double costoOperacion = PedirNumeros("Ingrese el costo operacion: ");
        double costoTasas = PedirNumeros("Ingrese el Costo de Tasas: ");

        try
        {
            if (string.IsNullOrEmpty(codigo) || codigo.Length != 3) throw new Exception("El código IATA no puede estar vacío y debe tener 3 letras");
            if (string.IsNullOrEmpty(ciudad)) throw new Exception("La ciudad no puede ser vacía");
            if (costoOperacion < 0) throw new Exception("El costo debe ser un número positivo");
            if (costoTasas < 0) throw new Exception("El costo de las tasas no puede ser negativo");
            
            Aeropuerto a = new Aeropuerto(codigo, ciudad, costoOperacion, costoTasas);
            miSistema.CrearAeropuerto(a);
            
            MostrarExito("El aeropuerto se ha creado correctamente");
        }
        catch (Exception ex)
        {
            MostrarError(ex.Message);
        }
    }*/

    static void ListarTodosLosClientes()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("**** LISTAR TODOS LOS CLIENTES ****");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine();

        try
        {
            List<Usuario> clientes = miSistema.ListarClientes();
            if (clientes.Count == 0) throw new Exception("No hay clientes registrados en el Sistema");
            foreach (Usuario c in clientes)
            {
                Console.WriteLine(c.ToString());
            }
        }
        catch (Exception e)
        {
            MostrarError(e.Message);
        }
    }

    static void ListarVuelosPorIATA()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("**** LISTAR VUELOS SEGÚN CODIGO IATA ****");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine();

        string codigoIngresado = PedirIATA("Ingrese código IATA para búsqueda de vuelos: ").ToUpper();
        Aeropuerto aeropuerto = miSistema.BuscarAeropuertoPorCodigo(codigoIngresado);


        if (aeropuerto == null)
        {
            MostrarError("El aeropuerto con el código IATA ingresado no existe.");
            PressToContinue();
            return;
        }
        else
        {
            List<Vuelo> vuelos = miSistema.ListarVuelos();
            bool vuelosEncontrados = false;

            foreach (var vuelo in vuelos)
            {
                if (vuelo.Ruta.AeropuertoSalida.Codigo == codigoIngresado || vuelo.Ruta.AeropuertoLlegada.Codigo == codigoIngresado)
                {
                    vuelosEncontrados = true;
                    Console.WriteLine(vuelo.ToString());
                }
            }
            if (!vuelosEncontrados)
            {
                Console.WriteLine("No se encontraron vuelos para el código IATA ingresado.");
            }

        }
        
        static string PedirIATA(string mensaje)
        {
            string entrada = "";

            while (true)
            {
                Console.Write(mensaje);
                entrada = Console.ReadLine();

                if (Aeropuerto.ValidarCodigoIata(entrada))
                {
                    return entrada.ToUpper();
                }
                else
                {
                    Console.WriteLine("El código IATA debe tener exactamente 3 letras.");
                }
            }
        }
            
        }
    static void AltaClienteOcasional()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("**** ALTA DE CLIENTE OCASIONAL ****");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine();

        //RESTO DE LOGICA
    }

    static void ListarPasajesPorFecha()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("**** LISTAR PASAJES POR FECHA ****");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine();

        //RESTO DE LOGICA
    }
}

 