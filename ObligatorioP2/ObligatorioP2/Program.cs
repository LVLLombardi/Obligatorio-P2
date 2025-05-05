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
                    PressToContinue();
                    break;
                case "4":
                    ListarPasajesEntreDosFechas();
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
        Console.WriteLine("2 - ");
        Console.WriteLine("3 - ");
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

    static void ListarPasajesEntreDosFechas()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("**** LISTAR PASAJES ENTRE DOS FECHAS ****");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine();

        try
        {
            List<Pasaje> pasajes = miSistema.ListarPasajesSegunFechas(new DateTime(2025, 6, 1), new DateTime(2025, 6, 10));
            if (pasajes.Count == 0) throw new Exception("No hay pasajes registrados en el Sistema");
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
}