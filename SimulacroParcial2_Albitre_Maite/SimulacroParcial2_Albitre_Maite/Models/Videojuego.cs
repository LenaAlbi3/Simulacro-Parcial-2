using SimulacroParcial2_Albitre_Maite.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulacroParcial2_Albitre_Maite.Models
{
    public class Videojuego
    {
        public string Nombre { get; set; } 
        public TipoPlataforma Plataforma { get; set; }
        public double Precio { get; set; }
        public int Stock {  get; set; }
        public Videojuego(string nombre, TipoPlataforma plataforma, double precio, int stock) 
        {
            Nombre = nombre;
            Plataforma = plataforma;
            Precio = precio;
            Stock = stock;
        }
        public override string ToString()
        {
            return $"{Nombre}, {Plataforma}, {Precio}, {Stock}"; 
        }
    }
}
