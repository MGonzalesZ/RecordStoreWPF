using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_grupo_PRG2
{
    public class CestaDisco
    {
        public string Codigo { get; private set; }
        public string Nombre { get; private set; }
        public string Artista { get; private set; }

        public double Precio { get; private set; }

        public int Cantidad { get; set; }

        public double Subtotal { get; private set; }
        
        public CestaDisco(string cod, string nom, string art, double prec)
        {
            Codigo = cod;
            Nombre = nom;
            Artista = art;
            Precio = prec;  
        }

        public void CalcularSubt()
        {
            Subtotal = Math.Round(this.Precio * this.Cantidad,2);
        }
        
       
    }
}
