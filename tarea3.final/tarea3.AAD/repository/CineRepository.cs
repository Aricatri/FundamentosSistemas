using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tarea3.AAD.entities;

namespace tarea3.AAD.repository
{
    internal class CineRepository
    {
        //arreglo public Cine cine = new Cine();
        //en repository , la referencia es  private , lo demas public
        //referenicamos a nuestras entities con una lista
        private static List<Cine> cine = new List<Cine> ();
        public bool Verificar (string codigo)
        {
            return cine.Exists(ci => ci.Codigo.Equals(codigo));
            
        }
        public static List<Cine> ListarTodo() {
            return cine;        
        }
        public static List<Cine> OrdenarXNombre()
        {
            return cine.OrderBy(ci => ci.Nombre).ToList();
        }
        public void Eliminar(string codigo)
        {
            cine.RemoveAll(ci=>ci.Codigo.Equals(codigo));
        }
        public void Registrar(Cine teather)
        {
            cine.Add(teather);
        }
        public void EliminarTodo()
        {
            cine.Clear();
        }
        public static List<Cine> BuscarXNombre(string nombre)
        {
            return cine.FindAll(ci=>ci.Nombre.Contains(nombre));
        }

    }
}
