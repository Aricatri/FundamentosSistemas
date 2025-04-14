using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tarea2.final.Entities
{
    internal class Animales
    {
        //controlador
        public Animales () { }

        public string Nombre { get; set; }
        public double Peso { get; set; }
        public string Cuidador { get; set; }
        public string Especie { get; set; }
        public int Edad { get; set; }
        public string Alimentacion { get; set; }
    }
}
