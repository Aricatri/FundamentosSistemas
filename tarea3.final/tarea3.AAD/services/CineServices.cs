using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tarea3.AAD.entities;
using tarea3.AAD.repository;

namespace tarea3.AAD.services
{
    internal class CineServices
    {
        //references
        private CineRepository cineRepository = new CineRepository();
        //metodos
        public bool Registrar(Cine cine)
        {
            if (cineRepository.Verificar(cine.Codigo))
            {
                MessageBox.Show("EL codigo ya existe");
                return false;
            }
            else
            {
                cineRepository.Registrar(cine);
                return true;
            }
        }

        public  List<Cine> ListarTodoo()
        {
            return CineRepository.ListarTodo();
        }
        public void Elimnar (string codigo)
        {
            cineRepository.Eliminar(codigo);
        }
        public void EliminarTodo()
        {
            cineRepository.EliminarTodo();
        }
        public List <Cine> OrdenarXNombre()
        {
            return CineRepository.OrdenarXNombre();
        }
        public List<Cine>  BuscarXNombre(string nombre)
        {
            return CineRepository.BuscarXNombre(nombre);
        }
    }
}
