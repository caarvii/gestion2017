using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Abm_Turno;
using UberFrba.Abm_Chofer;
using UberFrba.Abm_Cliente;
using UberFrba.Interface;
using UberFrba.Helpers;
using UberFrba.Dao;
using UberFrba.Dto;

namespace UberFrba.Registro_Viajes
{
    public partial class RegistroViaje : Form, ListadoSeleccionListener
    {
        TurnoDTO turnoGlobal;
        ChoferDTO choferGlobal;
        ClienteDTO clienteGlobal;
        OnCreateUpdateListener listener;
        AutomovilDTO AutomovilAModificar;

        public RegistroViaje()
        {
            InitializeComponent();
        }

        public void onOperationFinishCliente(ClienteDTO cliente)
        {
            clienteGlobal = cliente;
            txtNombreCliente.Text = cliente.nombre + " " + cliente.apellido;
            txtDNICliente.Text = cliente.dni.ToString();
        }

        public void onOperationFinishChofer(ChoferDTO chofer)
        {
            choferGlobal = chofer;
            txtNombreChofer.Text = chofer.nombre + " " + chofer.apellido;
            txtDNIChofer.Text = chofer.dni.ToString();
        }

        public void onOperationFinishTurno(TurnoDTO turno)
        {
            // NO SE IMPLEMENTA
        }



        // VALIDACIONES






        // BOTONES

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            txtDNIChofer.Text = "";
            txtNombreChofer.Text = "";
            txtAutomovil.Text = "";
            comboTurno.DataSource = null;
            txtHoraInicio.Text = "";
            txtHoraFin.Text = "";
            txtCantKM.Text = "";
            dataFechaInicio.ResetText();
            dataFechaFin.ResetText();
            txtDNICliente.Text = "";
            txtNombreCliente.Text = "";

        }

        private void botonSelecionChofer_Click(object sender, EventArgs e)
        {
            ListadoChofer ListadoSeleccionDeChoferForm = new ListadoChofer(this);
            ListadoSeleccionDeChoferForm.ShowDialog();
        }

        private void botonSelecionCliente_Click(object sender, EventArgs e)
        {
            ListadoCliente ListadoSeleccionCliente = new ListadoCliente(this);
            ListadoSeleccionCliente.ShowDialog();
        }

        private void botonRegistrar_Click(object sender, EventArgs e)
        {
            // TODO






        }
    }
}
