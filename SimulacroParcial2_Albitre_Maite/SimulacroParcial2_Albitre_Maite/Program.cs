
using SimulacroParcial2_Albitre_Maite.Models;

class Program
{
    static void Main(string[] args)
    {
        Tienda.CargarDatos();
        int opc;

        do
        {
            Console.Clear();
            Console.WriteLine($"Menu\n" +
            $"1. Agregar Juego\n" +
            $"2. Ver Catalogo\n" +
            $"3. Actualizar Juego Existente\n" +
            $"4. Eliminar Juego\n" +
            $"5. Guardar y Salir");
            opc = int.Parse(Console.ReadLine());
            switch (opc)
            {
                case 1:
                    Videojuego j = Tienda.CrearVideojuego();
                    Tienda.AgregarVideojuego(j);
                    break;
                case 2:
                    Tienda.MostrarCatalogo();
                    break;
                case 3:
                    Console.WriteLine("Ingrese el nombre del juego: ");
                    string nom = Console.ReadLine();
                    Console.WriteLine("Ingrese el nuevo precio: ");
                    double prec = double.Parse(Console.ReadLine());
                    Console.WriteLine("Ingrese el nombre del juego: ");
                    int stk = int.Parse(Console.ReadLine());
                    Tienda.ActualizarVidejuego(nom, prec, stk);
                    break;
                case 4:
                    Console.WriteLine("Ingrese el nombre del juego: ");
                    nom = Console.ReadLine();
                    Tienda.EliminarVideojuego(nom);
                    break;
                case 5:
                    Console.WriteLine("Saliendo...");
                    break;

                default:
                    Console.WriteLine("Opcion invalida");
                    break;
            }

        } while (opc != 5);

    }

}