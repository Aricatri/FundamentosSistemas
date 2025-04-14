using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tarea2.final.Entities;

namespace tarea2.final.Controllers
{
    internal class AnimalesController
    {
        //creamos el arreglo 
        //private EntitiesName[] x2 = new EntitiesName[100]
        private Animales[] animales=new Animales[100];
        int contador = 0;
        private int conHerviboro = 0;
        private int conCarnivoro = 0;
        private int conOmnivoro = 0;
        private int conInsectivoro = 0;
        
        public void Registrar(Animales animal)
        {
            switch (animal.Alimentacion)
            {
                case "Herbivoro": conHerviboro++; break;
                case "Carnivoro": conCarnivoro++; break;
                case "Omnivoro": conOmnivoro++; break;
                case "Insectivoro": conInsectivoro++; break;
            }
            animales[contador] = animal;
            contador++;
        }
        public void EliminarAnimal (int indice)
        {
            switch (animales[indice].Alimentacion)
            {
                case "Herbivoro": conHerviboro--; break;
                case "Carnivoro": conCarnivoro--; break;
                case "Omnivoro": conOmnivoro--; break;
                case "Insectivoro": conInsectivoro--; break;
            }
            for (int i= indice; i<contador-1; i++)
            {
                animales[i] = animales[i + 1];
            }

            //liamos la ultima posición 
            animales[contador-1]= null ;
            contador--;

        }
        public void ModificarDato(int indice, Animales animalNuevo )
        {
            string AlimentacionAnterior = animales[indice].Alimentacion;
            switch (AlimentacionAnterior)
            {
                case "Herbivoro": conHerviboro--; break;
                case "Carnivoro": conCarnivoro--; break;
                case "Omnivoro": conOmnivoro--; break;
                case "Insectivoro": conInsectivoro--; break;
            }
            switch (animalNuevo.Alimentacion)
            {
                case "Herbivoro": conHerviboro++; break;
                case "Carnivoro": conCarnivoro++; break;
                case "Omnivoro": conOmnivoro++; break;
                case "Insectivoro": conInsectivoro++; break;
            }
            animales[indice] = animalNuevo;
        }
        //cuando listamos arreglos , vamos con nuetro arreglo primero
        public Animales[] ListarTodo()
        {
            return
               animales;
        }
        public int ObtenerTotalHerviboro()
        {
            return conHerviboro;
        }
        public int ObtenerTotalCarnivoro()
        {
            return conCarnivoro;
        }
        public int ObtenerTotalOmnivoro()
        {
            return conOmnivoro;
        }
        public int ObtenerTotalInsectivoro()
        {
            return conInsectivoro;
        }
    }
}
