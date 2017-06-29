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
        AutomovilDTO autoGlobal;

        OnCreateUpdateListener listener;
       
        public RegistroViaje()
        {
            InitializeComponent();
            this.dataFechaInicio.Value = Config.newInstance.date;
            this.dataFechaFin.Value = Config.newInstance.date;
            this.comboTurno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
           
            cargarAutomovilDisponible();

            

        }

        public void onOperationFinishTurno(TurnoDTO turno)
        {
            // NO SE IMPLEMENTA
        }

        // METODOS GENERALES

        private void cargarAutomovilDisponible()
        {

            try
            {
                AutomovilDTO auto = AutomovilDAO.getAutomovilDisponible(choferGlobal.id);
                autoGlobal = auto;

                txtAutomovil.Text = auto.patente;

                cargarTurnosDeAuto(auto.id);
            }
            catch(ApplicationException e)
            {
                txtNombreChofer.Text = "";
                txtDNIChofer.Text = "";
                Utility.ShowError("Registro de viaje",e);

            }
         

        }

        private void cargarTurnosDeAuto(int auto_id)
        {
            List<TurnoDTO> turnos = TurnoDAO.getTurnosByAutoId(auto_id);

            comboTurno.DataSource = turnos;
            comboTurno.DisplayMember = "descripcion";
            comboTurno.ValueMember = "id";

            comboTurno.Enabled = true; 

        }

        private void comboTurno_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboTurno.SelectedIndex != -1)
            {
                txtHoraInicio.Text = ((TurnoDTO)comboTurno.SelectedItem).horaInicial.ToString();

                txtHoraFin.Text = ((TurnoDTO)comboTurno.SelectedItem).horaFinal.ToString();
            }

        }

        // VALIDACIONES

        private void txtCantKM_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.allowNumericOnlyForDouble(e);

        }

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
            dataFechaInicio.Value = Config.newInstance.date;
            dataFechaFin.Value = Config.newInstance.date;
            txtDNICliente.Text = "";
            txtNombreCliente.Text = "";

        }

        private void botonSelecionChofer_Click(object sender, EventArgs e)
        {
            ListadoChofer ListadoSeleccionDeChoferForm = new ListadoChofer(this, true);
            ListadoSeleccionDeChoferForm.ShowDialog();
        }

        private void botonSelecionCliente_Click(object sender, EventArgs e)
        {
            ListadoCliente ListadoSeleccionCliente = new ListadoCliente(this, true);
            ListadoSeleccionCliente.ShowDialog();
        }

        private bool validacionFecha()
        {
            return (dataFechaInicio.Value < dataFechaFin.Value) && (dataFechaInicio.Value.Day == dataFechaFin.Value.Day);

        }

        private bool validacionTurno()
        {

            return (Convert.ToInt32(txtHoraInicio.Text)  <= dataFechaInicio.Value.Hour &&
                    Convert.ToInt32(txtHoraFin.Text) >= dataFechaFin.Value.Hour                    
                    );

        }

        private void registrarViaje()
        {
            // SETEO 
            ViajeDTO nuevoViaje = new ViajeDTO( 
                                               autoGlobal.id,
                                               ((TurnoDTO)comboTurno.SelectedItem).id,
                                               choferGlobal.id,
                                               Convert.ToInt32(txtCantKM.Text),
                                               dataFechaInicio.Value,
                                               dataFechaFin.Value,
                                               clienteGlobal.id
                                                );
            // REGISTRO

            try
            {
                ViajeDAO.addNewViaje(nuevoViaje);
                MessageBox.Show("Se agrego el viaje correctamente");

                // LIMPIAR

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
            catch (ApplicationException ex)
            {
                Utility.ShowError("Error al agregar un viaje", ex);
            }   
            

        }

        private void botonRegistrar_Click(object sender, EventArgs e)
        {
            // TODO

            if (!string.IsNullOrWhiteSpace(txtDNIChofer.Text) 
                && !string.IsNullOrWhiteSpace(txtAutomovil.Text) 
                && !string.IsNullOrWhiteSpace(comboTurno.Text)
                && !string.IsNullOrWhiteSpace(txtCantKM.Text)
                && !string.IsNullOrWhiteSpace(dataFechaFin.Value.ToString())
                && !string.IsNullOrWhiteSpace(dataFechaInicio.Value.ToString())
                && !string.IsNullOrWhiteSpace(txtDNICliente.Text)
                )
            {
                if (validacionFecha())
                {
                    if (validacionTurno())
                    {
                        registrarViaje();
                    }
                    else 
                    {
                        MessageBox.Show("La hora inicial y final debe estar contenida dentro del turno correspondiente.", "Error");
                    }

                }
                else 
                {
                    MessageBox.Show("La fecha inicial y final debe ser del mismo dia y la final mayor.", "Error");
                }

            }
            else
            {
                MessageBox.Show("Debe completar todos los campos", "Error");

            }


        }
    }
}
