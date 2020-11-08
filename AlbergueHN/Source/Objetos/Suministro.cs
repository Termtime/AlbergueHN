using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbergueHN.Source.Objetos
{
    class Suministro
    {
        public int articuloID;
        public String descripcion;
        public int existencia;
        public string tipo;
        public string talla;
        public string genero;

        public Suministro(int articuloID, string descripcion, int existencia, string tipo, string talla, string genero)
        {
            this.articuloID = articuloID;
            this.descripcion = descripcion;
            this.existencia = existencia;
            this.tipo = tipo;
            this.talla = talla;
            this.genero = genero;
        }
    }

   
}
