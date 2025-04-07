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
                    PressToContinue();
                    break;
                case "2":
                    PressToContinue();
                    break;
                case "3":
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
        Console.WriteLine("1 - Crear nueva marca");
        Console.WriteLine("2 - Listado de marcas");
        Console.WriteLine("3 - Listado de autos");
        Console.WriteLine("4 - Crear nuevo auto");
        Console.WriteLine("5 - Autos por año");
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
}