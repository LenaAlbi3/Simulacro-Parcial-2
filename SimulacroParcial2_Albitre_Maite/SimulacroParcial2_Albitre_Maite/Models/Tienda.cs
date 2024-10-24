using SimulacroParcial2_Albitre_Maite.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulacroParcial2_Albitre_Maite.Models
{
    public static class Tienda
    {
         static readonly string ArchivoCatalogo = "Juegos.txt";
         static List<Videojuego> catalogo = new();

        public static Videojuego CrearVideojuego()
        {
            Console.WriteLine("Ingrese el nombre del juego: ");
            string nom = Console.ReadLine();
            Console.Write("Seleccione la plataforma del videojuego: ");
            foreach (var plataforma in Enum.GetValues(typeof(TipoPlataforma)))
            {
                Console.WriteLine($"{(int)plataforma}. {plataforma}");
            }
            int tipoPlat = int.Parse(Console.ReadLine());
            TipoPlataforma plat = (TipoPlataforma)tipoPlat;
            Console.WriteLine("Ingrese el precio del juego: ");
            double prec = double.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese la cantidad en stock: ");
            int stock = int.Parse(Console.ReadLine());
            Videojuego j = new Videojuego(nom, plat, prec, stock);
            return j;
        }

        public static void AgregarVideojuego(Videojuego videojuego)
        {
            catalogo.Add(videojuego);
            GuardarDato(videojuego);

        }
        public static void MostrarCatalogo()
        {
            Console.WriteLine("\nCatalogo de videojuegos: ");
            Console.WriteLine("\nNombre | Plataforma | Precio | Stock ");
            
            if (catalogo.Count > 0)
            {
                foreach (var juego in catalogo)
                {
                    Console.WriteLine(juego);
                }
            }
            else
            {
                Console.WriteLine("No hay videojuegos para mostrar. ");
            }

        }
        public static void ActualizarVidejuego(string nombre, double precioNuevo, int stock)
        {
            Console.WriteLine("Ingrese el nombre del videojuego: ");
            string name = Console.ReadLine();
            var juego = catalogo.Find(j => j.Nombre == nombre);
            if (juego != null)
            {
                juego.Precio = precioNuevo;
                juego.Stock = stock;
            }
            else
            {
                Console.WriteLine("Juego no encontrado.");

            }
            GuardarDatos();
        }
        public static void EliminarVideojuego(string nombre)
        {
            var juego = catalogo.Find(j => j.Nombre == nombre);
            if (juego != null)
            {
                catalogo.Remove(juego);
                Console.WriteLine("El juego se elimino correctamente. ");
            }
            else
            {
                Console.WriteLine("Juego no encontrado.");

            }
            GuardarDatos();
        }

        public static void CargarDatos()
        {
            if (File.Exists(ArchivoCatalogo))
            {
                var lineas = File.ReadAllLines(ArchivoCatalogo);
                foreach (var linea in lineas)
                {
                    
                    var datos = linea.Split(";");
                    string nombre = datos[0];
                    TipoPlataforma plat = (TipoPlataforma)Enum.Parse(typeof(TipoPlataforma), datos[1]);
                    double precio = double.Parse(datos[2]);
                    int stock = int.Parse(datos[3]);
                    Videojuego juego = new(nombre, plat, precio, stock);
                    catalogo.Add(juego);
                }
            }

        }

        public static void GuardarDato(Videojuego juego)
        {
            using StreamWriter streamWriter = new StreamWriter(ArchivoCatalogo);
            streamWriter.WriteLine(juego);
        }

        public static void GuardarDatos()
        {
            using StreamWriter streamWriter = new StreamWriter(ArchivoCatalogo);
            foreach (Videojuego juego in catalogo)
            {
            streamWriter.WriteLine(juego);
            }

            //List<string> lineas = new();
            //foreach(var juego in catalogo)
            //{
            //    lineas.Add(juego.ToString());
            //}
            //File.WriteAllLines(ArchivoCatalogo, lineas);

        }


    }
}
