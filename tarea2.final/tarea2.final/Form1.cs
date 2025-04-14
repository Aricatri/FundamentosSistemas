using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tarea2.final.Controllers;
using tarea2.final.Entities;

namespace tarea2.final
{
    public partial class Form1 : Form
    {
        private AnimalesController animalesController = new AnimalesController();
        public Form1()
        {
            InitializeComponent();
        }

        private void MostrarEnDataGrid(Animales[] animales)
        {
            //limpiadoo
            dgvAnimales.DataSource = null;
            dgvAnimales.DataSource = animales;
            lblCarnivoro.Text =animalesController.ObtenerTotalCarnivoro().ToString();
            lblHerbivoro.Text=animalesController.ObtenerTotalHerviboro().ToString();
            lblInsectivoro.Text=animalesController.ObtenerTotalInsectivoro().ToString();
            lblOmnivoro.Text=animalesController.ObtenerTotalOmnivoro().ToString();
        }
        private void btnRegistar_Click(object sender, EventArgs e)
        {
            //validacion de campos 
            if (txtPeso.Text == "" || txtCuidador.Text == "" || txtEdad.Text == "" || txtEspecie.Text == "" || txtNombre.Text == "" || cbxAlimentacion.Text == "")
            {
                MessageBox.Show("Ingrese todo los campos");
                return;
            }
            //creamos el objeto para poder usar los datos de nuestra clase y comparamos con el entities
            //EntitieName x2 =new EntitieName(){ .....};
            Animales animales = new Animales()
            {
                Nombre = txtNombre.Text,
                Peso = double.Parse(txtPeso.Text),
                Especie = txtEspecie.Text,
                Edad = int.Parse(txtEdad.Text),
                Alimentacion = cbxAlimentacion.Text,
                Cuidador = txtCuidador.Text,
            };

            //registro 
            animalesController.Registrar(animales);
            // Mostramos
            MostrarEnDataGrid(animalesController.ListarTodo());

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //validación
            if (dgvAnimales.CurrentCell == null)
            {
                MessageBox.Show("Selecciona una fila para eliminar");
                return ;
            }
            int index = dgvAnimales.CurrentCell.RowIndex;
            animalesController.EliminarAnimal(index);
            MostrarEnDataGrid(animalesController.ListarTodo());

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //validación
            if (dgvAnimales.CurrentCell == null)
            {
                MessageBox.Show("Selecciona una fila para modificar");
                return;
            }
            int indice = dgvAnimales.CurrentCell.RowIndex;
            Animales modificado = new Animales()
            {
                Nombre = txtNombre.Text,
                Peso = double.Parse(txtPeso.Text),
                Edad = int.Parse(txtEdad.Text),
                Especie = txtEspecie.Text,
                Cuidador = txtCuidador.Text,
                Alimentacion = cbxAlimentacion.Text
            };
            animalesController.ModificarDato(indice, modificado);
            MostrarEnDataGrid(animalesController.ListarTodo());
        }
    }
}
