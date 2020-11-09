using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbergueHN.Source.Objetos
{
    class Suministro
    {
        public string Id { get; set; } = null;
        public string Descripcion { get; set; } = null;
        public string Existencia { get; set; } = null;
        public string Tipo { get; set; } = null;
        public string Talla { get; set; } = null;
        public string Genero { get; set; } = null;
        public int CantidadIngresada { get; set; } = 0;

        public int CantidadEntregada { get; set; } = 0;
    }
}
