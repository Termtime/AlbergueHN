using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbergueHN.Source.Objetos
{
    class Suministro
    {
        public string Id { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; } = 1;
        public string Tipo { get; set; } 
        public string Talla { get; set; }
        public string Genero { get; set; }
    }
}
