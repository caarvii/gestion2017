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
using UberFrba.Dto;
using UberFrba.Interface;


namespace UberFrba.Abm_Cliente
{
    public partial class ListadoCliente : UberFrba.ListadoGenerico , OnCreateUpdateListener
    {
        
        Dictionary<string, object> filtrosClienteList = new Dictionary<string, object>();

        ListadoSeleccionListener listener;
        bool seleccionDeCliente = false;
        List<ClienteDTO> clientes;
        private bool soloActivos = new bool();

        public void onOperationFinish() {

            cargarDGVClientes();
        
        }

        public ListadoCliente()
        {
            InitializeComponent();
        }

        public ListadoCliente(ListadoSeleccionListener _listener): this(_listener, false)
        {
        }

        public ListadoCliente(ListadoSeleccionListener _listener, Boolean soloActivos)
        {
            InitializeComponent();

            listener = _listener;
            this.soloActivos = soloActivos;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;

            cargarDGVClientes();
            
            botonAlta.Visible = false;
            botonBaja.Visible = false;
            botonModificacion.Text = "Seleccionar";
            seleccionDeCliente = true;

        }

        private void listadoCliente_Load(object sender, EventArgs e)
        {
            cargarDGVClientes();
        }

        public void cargarDGVClientes()
        {

            clientes = soloActivos ?  ClienteDAO.getClientesHabilitados() : ClienteDAO.getAllClientes();
            tablaListado.DataSource = clientes;
            tablaListado.Columns["estado"].Visible = false;

            //VER

            //tablaListado.Columns["username"].Visible=false;
            //tablaListado.Columns["password"].Visible = false;
            //tablaListado.Columns["intentos"].Visible = false;
        
        }

        protected void btnActualizarListado_Click(object sender, EventArgs e)
        {
            cargarDGVClientes();
        }


        protected void botonAlta_Click_1(object sender, EventArgs e)
        {
            crearCliente crearClienteForm = new crearCliente(this);
            crearClienteForm.ShowDialog();
        }

        protected void botonBaja_Click_1(object sender, EventArgs e)
        {
            if (tablaListado.SelectedRows.Count == 1)
            {
                DataGridViewRow row = this.tablaListado.SelectedRows[0];
                
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
            if (seleccionDeCliente == false)
            {
                if (tablaListado.SelectedRows.Count == 1)
                {
                    DataGridViewRow row = this.tablaListado.SelectedRows[0];

                    int id = Convert.ToInt32(row.Cells["id"].Value);

                    ClienteDTO cliente = ClienteDAO.getClienteById(id);

                    crearCliente crearClienteForm = new crearCliente(cliente, this);
                    crearClienteForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Debe seleccionar el cliente a modificar");
                }
            }
            else
            {

                if (tablaListado.RowCount > 0)
                {
                    int index = tablaListado.SelectedRows[0].Index;
                    listener.onOperationFinishCliente(clientes.ElementAt(index));
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una fila");
                }
            }


        }

        protected void botonBuscar_Click(object sender, EventArgs e)
        {
            {
                filtrosClienteList = new Dictionary<string, object>();

                if (!string.IsNullOrWhiteSpace(txtFiltroNombre.Text))
                {
                    filtrosClienteList.Add("cli_nombre", txtFiltroNombre.Text);
                }

                if (!string.IsNullOrWhiteSpace(txtFiltroApellido.Text))
                {
                    filtrosClienteList.Add("cli_apellido", txtFiltroApellido.Text);
                }

                if (!string.IsNullOrWhiteSpace(txtFiltroDni.Text))
                {
                     filtrosClienteList.Add("cli_dni", txtFiltroDni.Text);
                }

                //if check todos los filtros 

                if (filtrosClienteList.Count > 0)
                {
                    //Tiene filtros
                    clientes =  ClienteDAO.getClientesFilter(filtrosClienteList, soloActivos);
                    tablaListado.DataSource = clientes;
                    tablaListado.Columns["estado"].Visible = false;
                }
                else
                {
                    cargarDGVClientes();
                }

            }
        }



    }
}