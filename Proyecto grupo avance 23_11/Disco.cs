using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_grupo_PRG2
{
    public class Disco
    {
        static int contador = 0;
        public string Codigo { get; set; }
        private string nombre;
        private string artista;
        private string genero;
        private int anio;
        private int pistas;
        private int duracion;
        private double precio;
        private int stock;
        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (value.Length == 0)
                {
                    Console.WriteLine("Error: El nombre no puede ser vacío");
                    return;
                }
                nombre = value;
            }
        }
        public string Artista
        {
            get { return artista; }
            set
            {
                if (value.Length == 0)
                {
                    Console.WriteLine("Error: El artista no puede ser nulo");
                    return;
                }
                artista = value;
            }
        }
        public string Genero
        {
            get { return genero; }
            set
            {
                if (value.Length == 0)
                {
                    Console.WriteLine("Error: Debe ingresar el género");
                    return;
                }
                genero = value;
            }
        }

        public int Anio
        {
            get { return anio; }
            set
            {
                if (value > DateTime.Now.Year)
                {
                    Console.WriteLine("Error: El año no puede ser mayor al actual");
                    return;
                }
                anio = value;

            }
        }
        public int Pistas
        {
            get { return pistas; }
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Error: El disco debe tener al menos una pista");
                    return;
                }
                pistas = value;

            }
        }
        public int Duracion
        {
            get { return duracion; }
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Error: El disco debe tener duracion mayor a cero");
                    return;
                }
                duracion = value;
            }
        }
        public double Precio
        {
            get { return precio; }
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Error: El precio no puede ser menor a cero");
                    return;
                }
                precio = value;
            }
        }
        public int Stock
        {
            get { return stock; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Error: El stock no puede ser menor a cero");
                    return;
                }
                stock = value;
            }
        }

        public Disco(string nom, string art, string gen, int ann, int pist, int dur, double prec, int stk)
        {
            Nombre = nom.ToUpper();
            Artista = art.ToUpper();
            Genero = gen.ToUpper();
            Anio = ann;
            Pistas = pist;
            Duracion = dur;
            Precio = prec;
            Stock = stk;
            contador++;
            GenerarCodigo();
        }

        public void GenerarCodigo()
        {
            Codigo = "D" + nombre.Substring(0, 2) + "-" + artista.Substring(0, 3) + "-" + contador;
        }
    }
}
