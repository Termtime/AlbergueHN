using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbergueHN.Source.Objetos
{
    class Persona
    {
        public string identidad { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string nombreCompleto { get; set; }

        public Persona(string identidad, string nombres, string apellidos)
        {
            this.identidad = identidad;
            this.nombres = nombres;
            this.apellidos = apellidos;
            this.nombreCompleto = nombres + " " + apellidos;
        }

        public override string ToString()
        {
            return nombreCompleto + " - " + identidad;
        }
    }
}
