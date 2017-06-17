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

namespace UberFrba.Abm_Cliente
{
    public partial class listadoCliente : Form
    {
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
            dgvClientes.DataSource = ClienteDAO.getAllClientes();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count == 1)
            {
                DataGridViewRow row = this.dgvClientes.SelectedRows[0];
                ClienteDTO cliente = new ClienteDTO();
                cliente.id = Convert.ToInt32(row.Cells["id"].Value);
                
                crearCliente ventanaCliente = new crearCliente(cliente);
                ventanaCliente.ShowDialog();
            }
            else
            {
                MessageBox.Show("Debe seleccionar el cliente a modificar");
            }

        }

        private void btnActualizarListado_Click(object sender, EventArgs e)
        {
            cargarDGVClientes();
        }

        private void btnDeshabilitar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count == 1)
            {
                DataGridViewRow row = this.dgvClientes.SelectedRows[0];
                ClienteDTO cliente = new ClienteDTO();
                int id = Convert.ToInt32(row.Cells["id"].Value);

                 if (ClienteDAO.deleteCliente(id) == 1)
                 {
                     MessageBox.Show("Cliente dado de baja correctamente");
                 }

            }
        }



    }
}