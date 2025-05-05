using System;
using System.Data;
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
                    PressToContinue();
                    break;
                case "3":
                    AltaClienteOcasional();
                    PressToContinue();
                    break;
                case "4":
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
        Console.WriteLine("2 - Listar Todos los Vuelos según código de Aeropuerto");
        Console.WriteLine("3 - Alta de cliente ocasional");
        Console.WriteLine("4 - ");
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
            
            Cliente existente = miSistema.BuscarCliente(correo);

            if (existente != null) throw new Exception("Ya existe un cliente con ese correo.");
            string contrasenia = PedirPalabras("Ingrese contraseña: ");
            string documento = PedirPalabras("Ingrese documento: ");
            string nombre = PedirPalabras("Ingrese nombre: ");
            string nacionalidad = PedirPalabras("Ingrese nacionalidad: ");
            bool esElegible = GenerarElegible();

            ClienteOcasional nuevo = new ClienteOcasional(correo, contrasenia, documento, nombre, nacionalidad, esElegible);
            miSistema.AgregarUsuario(nuevo);
            MostrarExito("Cliente ocasional agregado con éxito.");
        }
        catch(Exception e)
        {
            MostrarError("Error al crear cliente ocasional"+e.Message);

        }
    }
    public static bool GenerarElegible()
    {
        bool esElegible= false;
        Random random = new Random();
        int n = random.Next(0, 2);
        if (n == 0)
        {
            esElegible = false;
        }
        else
        {
            esElegible = true;
        }
        return esElegible;
    }


}        


