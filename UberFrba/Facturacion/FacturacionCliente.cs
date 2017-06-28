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
        private List<ItemFactura> viajesParaFacturarList;

        public FacturacionCliente()
        {
            InitializeComponent();
            this.importeTotal = 0;
            this.viajesParaFacturarList = new List<ItemFactura>();
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
            ListadoCliente listadoSeleccionClienteForm = new ListadoCliente(this, true);
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

            DataTable dt = new DataTable();
            dt.Load(FacturacionDAO.getViajesNoFacturados(dateInicio.Value, cliente));

            if (dt.Rows.Count == 0)
            {
                Utility.ShowInfo("Facturacion", "No hay viajes sin facturar para los datos ingresados");
                return;
            }

            viajesParaFacturar.DataSource = dt;

            viajesParaFacturarList.AddRange(dt.AsEnumerable().Select(x =>
               new ItemFactura(Convert.ToInt32(x[x.Table.Columns["viaje_id"].Ordinal]),
                    Convert.ToString(x[x.Table.Columns["viaje_descripcion"].Ordinal]),
                Convert.ToDouble(x[x.Table.Columns["valor_viaje"].Ordinal]))).ToList());

            importeTotal = viajesParaFacturarList.AsEnumerable().Select(x => x.viajeCosto).Sum();

            totalFacturaLabel.Text = "$ " + importeTotal;

        }

        private void botonFacturar_Click(object sender, EventArgs e)
        {

        }

        















    }
}
