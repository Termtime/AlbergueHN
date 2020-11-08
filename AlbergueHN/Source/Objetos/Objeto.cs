using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbergueHN.Source.Objetos
{
    class Objeto
    {
        public int ArticuloID;
        public String Descripcion;
        public int CantidadExistencia;

        public Objeto(int articuloID, String descripcion, int cantidadExistencia)
        {
            ArticuloID = articuloID;
            Descripcion = descripcion;
            CantidadExistencia = cantidadExistencia;
        }
        public Objeto()
        {
            ArticuloID = 0;
            Descripcion = "";
            CantidadExistencia = 0;
        }
        public int getArticuloID()
        {
            return ArticuloID;
        }
        public String getDescripcion()
        {
            return Descripcion;
        }
        public int getCantidadExistencia()
        {
            return CantidadExistencia;
        }

        public void setArticuloID(int articuloID)
        {
            ArticuloID = articuloID;
        }
        public void setDescripcion(String descripcion)
        {
            Descripcion = descripcion;
        }
        public void setCantidadExistencia(int cantidad)
        {
            CantidadExistencia = cantidad;
        }
    }

   
}
