using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Dao;
using UberFrba.Interface;


namespace UberFrba.Abm_Cliente
{
    public partial class listadoCliente : UberFrba.listadoGenerico , OnCreateUpdateListener
    {
        

         public void onOperationFinish() {

            cargarDGVClientes();
        
        }

        public listadoCliente()
        {
            InitializeComponent();
        }

        private void listadoCliente_Load(object sender, EventArgs e)
        {
            cargarDGVClientes();
        }

        public void cargarDGVClientes()
        {
            tablaListado.DataSource = ClienteDAO.getAllClientes();
        }

        protected void btnActualizarListado_Click(object sender, EventArgs e)
        {
            cargarDGVClientes();
        }


        protected void botonAlta_Click_1(object sender, EventArgs e)
        {
            crearCliente crearClienteForm = new crearCliente();
            crearClienteForm.ShowDialog();
        }

        protected void botonBaja_Click_1(object sender, EventArgs e)
        {
            if (tablaListado.SelectedRows.Count == 1)
            {
                DataGridViewRow row = this.tablaListado.SelectedRows[0];
                ClienteDTO cliente = new ClienteDTO();
                int id = Convert.ToInt32(row.Cells["id"].Value);

                if (ClienteDAO.deleteCliente(id) == 1)
                {
                    MessageBox.Show("Cliente dado de baja correctamente");
                    cargarDGVClientes();
                }

            }
        }

        private void botonLimpiar_Click_1(object sender, EventArgs e)
        {
            tablaListado.DataSource = null;
        }

        private void botonModificacion_Click_1(object sender, EventArgs e)
        {
            if (tablaListado.SelectedRows.Count == 1)
            {
                DataGridViewRow row = this.tablaListado.SelectedRows[0];
                ClienteDTO cliente = new ClienteDTO();
                cliente.id = Convert.ToInt32(row.Cells["id"].Value);

                crearCliente crearClienteForm = new crearCliente(cliente, this);
                crearClienteForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Debe seleccionar el cliente a modificar");
            }
        }



    }
}