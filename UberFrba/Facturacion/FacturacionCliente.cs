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
using UberFrba.Helpers;
using UberFrba.Interface;
using UberFrba.Abm_Cliente;

namespace UberFrba.Facturacion
{
    public partial class FacturacionCliente : Form, ListadoSeleccionListener
    {
        private ClienteDTO cliente;
        private double importeTotal;
        private List<int> viajesParaFacturarList;

        public FacturacionCliente()
        {
            InitializeComponent();
            this.importeTotal = 0;
            this.viajesParaFacturarList = new List<int>();
        }

        public void onOperationFinishTurno(TurnoDTO turno)
        {
            //Do nothing
        }

        public void onOperationFinishChofer(ChoferDTO chofer)
        {
            //Do nothing
        }

        public void onOperationFinishCliente(ClienteDTO cliente)
        {
            this.cliente = cliente;
            this.txtDNI.Text = cliente.dni.ToString();
            this.txtNombreApellido.Text = cliente.nombre + " " + cliente.apellido;
        }

        private void botonSeleccionarCliente_Click(object sender, EventArgs e)
        {
            ListadoCliente listadoSeleccionClienteForm = new ListadoCliente(this);
            // averiguar por que el constructor del listadoCliente era (this,true)
            listadoSeleccionClienteForm.ShowDialog();

        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            this.dateInicio.Value = Config.newInstance.date;
            this.txtDNI.Text = "";
            this.txtNombreApellido.Text = "";
            this.cliente = null;
            this.viajesParaFacturar.DataSource = null;
            this.viajesParaFacturarList.Clear();
            this.importeTotal = 0;
        }

        private void botonBuscarViajes_Click(object sender, EventArgs e)
        {

            if (cliente == null)
            {
                Utility.ShowInfo("Facturacion", "Debe seleccionar un cliente para buscar los viajes");
                return;
            }

            //DataTable dt = new DataTable();
            //dt.Load(RendicionDAO.getViajesNoRendidos(chofer, turno, fechaRendicionDateTimePicker.Value));











        }

        















    }
}
