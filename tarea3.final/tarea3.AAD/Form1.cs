using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tarea3.AAD.entities;
using tarea3.AAD.services;

namespace tarea3.AAD
{
    public partial class Form1 : Form
    {
        //controllers
        private CineServices cineServices = new CineServices();
        public Form1()
        {
            InitializeComponent();
        }
        //creamos el mostrarDataGrid
        private void MostrarEnDataGrid(List<Cine> cines)
        {
            //1,limpiamos 
            dataGridView1.DataSource = null;
            //validamos e mostramos
            if (cines.Count == 0)
            {
                lblRecuentoTotal.Text = "0";
                return;
            }
            else
            {
                dataGridView1.DataSource = cines;

                // Total de recuento
                lblRecuentoTotal.Text=cines.Count.ToString();

            }
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            //validamos
            if (txtArea.Text == ""  || txtCodigo.Text == "" || txtDireccion.Text=="" || txtDistrito.Text=="" || txtGerente.Text==""
                || txtNombreCine.Text=="")
            {
                MessageBox.Show("Ingrese todos los campos para proceder");
            }
            else
            {
                Cine cine = new Cine
                {
                    Codigo = txtCodigo.Text,
                    Nombre = txtNombreCine.Text,
                    Area = double.Parse(txtArea.Text),
                    Gerente = txtGerente.Text,
                    Distrito = txtDistrito.Text,
                    Direccion = txtDireccion.Text,
                };
                bool registrado= cineServices.Registrar(cine);
                if (!registrado)
                {
                    MessageBox.Show("Código ya registrado");
                    return;
                }
            }

        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            MostrarEnDataGrid(cineServices.ListarTodoo());
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Validación
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione registro a eliminar");
                return;
            }

            String codigo = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();

            // Eliminamos
            cineServices.Elimnar(codigo);

            // Mostramos en Datagrid
            MostrarEnDataGrid(cineServices.ListarTodoo());

        }

        private void btnOrdenarxNombre_Click(object sender, EventArgs e)
        {
            MostrarEnDataGrid(cineServices.OrdenarXNombre());
        }

        private void btnBorrarTodo_Click(object sender, EventArgs e)
        {
            cineServices.EliminarTodo();
            MostrarEnDataGrid(cineServices.ListarTodoo());
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            //validamos 
            if (txtBuscarNombre.Text == "")
            {
                MessageBox.Show("Ingrese el nombre a buscar ");
                return;
            }
            string nombre = txtBuscarNombre.Text;
            MostrarEnDataGrid(cineServices.BuscarXNombre(nombre));
        }
    }
}
