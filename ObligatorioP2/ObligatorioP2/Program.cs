using System;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using Dominio;

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
                    ListarPasajesEntreDosFechas();
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
        Console.WriteLine("2 - Listar vuelos por codigo IATA");
        Console.WriteLine("3 - Alta de cliente ocasional");
        Console.WriteLine("4 - Listar pasajes entre dos fechas");
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

    static void ListarTodosLosClientes()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("**** LISTAR TODOS LOS CLIENTES ****");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine();

        try
        {
            List<Cliente> clientes = miSistema.ListarClientes();
            if (clientes.Count == 0) throw new Exception("No hay clientes registrados en el Sistema");
            foreach (Cliente c in clientes)
            {
                Console.WriteLine(c.ToString());
            }
        }
        catch (Exception e)
        {
            MostrarError(e.Message);
        }
    }

    static string PedirPalabras(string mensaje)
    {
        Console.Write(mensaje);
        string dato = Console.ReadLine();
        return dato;
    }
    
    static DateTime PedirFecha(string mensaje)
    {
        bool exito = false;
        DateTime fecha = new DateTime();
        while (!exito)
        {
            Console.Write(mensaje + " [DD/MM/YYYY]:");
            exito = DateTime.TryParse(Console.ReadLine(), out fecha);

            if (!exito) MostrarError("ERROR: Debe ingresar una fecha en formato DD/MM/YYYY");
        }
        return fecha;
    }
    static void ListarVuelosPorIATA()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("**** LISTAR VUELOS POR CODIGO IATA ****");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine();

        try
        {
            string codigoIATA = PedirPalabras("Ingrese codigo IATA: ");
            List<Vuelo> vuelos = miSistema.ListarVuelos(codigoIATA);
            if (vuelos.Count == 0) throw new Exception("No hay vuelos registrados en el sistema");
            foreach (Vuelo v in vuelos)
            {
                Console.WriteLine(v.ToString());
            }
        }
        catch (Exception e)
        {
            MostrarError("La busqueda no fue exitosa: " + e.Message);
        }
    }

    static void ListarPasajesEntreDosFechas()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("**** LISTAR PASAJES ENTRE DOS FECHAS ****");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine();

        try
        {
            DateTime fechaInicio = PedirFecha("Ingrese la fecha de inicio");
            DateTime fechaFin = PedirFecha("Ingresar la fecha de fin");
            if (fechaInicio == new DateTime()) throw new Exception("Fecha invalida");
            if (fechaFin == new DateTime()) throw new Exception("Fecha invalida");
            List<Pasaje> pasajes = miSistema.ListarPasajesSegunFechas(fechaInicio, fechaFin);
            if (pasajes.Count == 0) throw new Exception("No hay pasajes registrados en el Sistema.");
            foreach (Pasaje p in pasajes)
            {
                Console.WriteLine(p.ToString());
            }
        }
        catch (Exception e)
        {
            MostrarError(e.Message);
        }
    }

    static void AltaClienteOcasional()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("**** ALTA DE CLIENTE OCASIONAL ****");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine();

        try
        {
            string correo = PedirPalabras("Ingrese correo del cliente: ");
            string contrasenia = PedirPalabras("Ingrese contraseña: ");
            string documento = PedirPalabras("Ingrese documento: ");
            string nombre = PedirPalabras("Ingrese nombre: ");
            string nacionalidad = PedirPalabras("Ingrese nacionalidad: ");
            bool esElegible = GenerarElegible();
            
            if(string.IsNullOrEmpty(correo)) throw new Exception("El correo no puede estar vacio");
            if(string.IsNullOrEmpty(contrasenia)) throw new Exception("La contraseña no puede estar vacia");
            if(string.IsNullOrEmpty(documento)) throw new Exception("El documento no puede estar vacio");
            if(string.IsNullOrEmpty(nombre)) throw new Exception("El nombre no puede estar vacio");
            if(string.IsNullOrEmpty(nacionalidad)) throw new Exception("La nacionalidad no puede estar vacia");
            ClienteOcasional nuevo = new ClienteOcasional(correo, contrasenia, documento, nombre, nacionalidad, esElegible);
            miSistema.AgregarUsuario(nuevo);
            MostrarExito("Cliente ocasional agregado con éxito.");
        }
        catch(Exception e)
        {
            MostrarError(e.Message);

        }
    }
    public static bool GenerarElegible()
    {
        Random random = new Random();
        return random.Next(0, 2)==1;
    }
}        

