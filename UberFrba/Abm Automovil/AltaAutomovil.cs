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
using UberFrba.Abm_Turno;
using UberFrba.Interface;
using UberFrba.Helpers;
using UberFrba.Abm_Automovil;
using UberFrba.Abm_Chofer;


namespace UberFrba.Abm_Automovil
{
    public partial class AltaAutomovil : Form, ListadoSeleccionListener
    {
        public AltaAutomovil(OnCreateUpdateListener _listener)
        {
            InitializeComponent();
            cargarDatosIniciales();
            listener = _listener;
            turnos = new List<TurnoDTO>();
        }

        TurnoDTO turnoGlobal;
        ChoferDTO choferGlobal;
        OnCreateUpdateListener listener;
        AutomovilDTO AutomovilAModificar;
        List<TurnoDTO> turnos;
        
        public AltaAutomovil(AutomovilDTO _AutomovilAModificar, OnCreateUpdateListener _listener)
        {


            InitializeComponent();
            turnos = new List<TurnoDTO>();
            cargarDatosIniciales();
            AutomovilAModificar = _AutomovilAModificar;
            CargarDatosDeAutomovilAModificar();
            btnCrearAutomovil.Visible = false;
            btnModificar.Visible = true;
            this.Text = "Modificar automovil";
            chkAutoActivo.Visible = true;
            lblAutoActivo.Visible = true;
            listener = _listener;
        }

        public void onOperationFinishChofer(ChoferDTO chofer)
        {
            choferGlobal = chofer;
            txtChoferDni.Text = chofer.dni.ToString();
            txtChoferNombreCompleto.Text = chofer.nombre + " " + chofer.apellido;
        }

        public void onOperationFinishCliente (ClienteDTO cliente)
        {
            // TODO
        }


        public void onOperationFinishTurno(TurnoDTO turno)
        {
            turnoGlobal =turno;
            //txtTurnoDescripcion.Text = turno.descripcion;
            //txtTurnoHoraInicio.Text = turno.horaInicial.ToString();
//            txtTurnoHoraFin.Text = turno.horaFinal.ToString();



        }

        private void CargarDatosDeAutomovilAModificar()
        {
            
            
            
            cmbMarca.Text= AutomovilAModificar.marca_nombre; 
            cmbModelo.Text = AutomovilAModificar.modelo_nombre;
            txtPatente.Text = AutomovilAModificar.patente;

            choferGlobal = ChoferDAO.getChoferByAutomovilId(AutomovilAModificar.id);


            txtChoferDni.Text = choferGlobal.dni.ToString();
            txtChoferNombreCompleto.Text = choferGlobal.nombre + " " + choferGlobal.apellido;

            turnos = TurnoDAO.getTurnosByAutomovilId(AutomovilAModificar.id);

            foreach (TurnoDTO turno in turnos) {
                dgvTurnos.Rows.Add(turno.descripcion, turno.horaInicial, turno.horaFinal);
            }
            chkAutoActivo.Checked = AutomovilAModificar.activo;

            txtLicencia.Text = AutomovilAModificar.licencia;
            txtAutoRodado.Text = AutomovilAModificar.rodado;

        }


        private void cargarDatosIniciales()
        {
            List<MarcaDTO> marcas = MarcaDAO.getAllMarcas();
            cmbMarca.DataSource = marcas;
            cmbMarca.DisplayMember = "descripcion";
            cmbMarca.ValueMember = "id";
            cmbMarca.SelectedIndex = -1;

            List<ModeloDTO> modelos = ModeloDAO.getAllModelos();
            cmbModelo.DataSource = modelos;
            cmbModelo.DisplayMember = "nombre";
            cmbModelo.ValueMember = "id";
            cmbModelo.SelectedIndex = -1;

            List<TurnoDTO> turnos = TurnoDAO.getAllTurnos();
            cmbTurno.DataSource = turnos;
            cmbTurno.DisplayMember = "descripcion";
            cmbTurno.ValueMember = "id";
            cmbTurno.SelectedIndex = -1;


        }

        private void txtPatente_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.allowAlphanumericOnly(e);
            if (e.KeyChar != 8) this.allowMaxLenght(txtPatente, 10, e);
            
        }

        private void txtLicencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.allowAlphanumericOnly(e);
            if (e.KeyChar != 8) this.allowMaxLenght(txtLicencia, 26, e);

        }

        private void txtAutoRodado_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.allowAlphanumericOnly(e);
            if (e.KeyChar != 8) this.allowMaxLenght(txtAutoRodado, 10, e);

        }



        private AutomovilDTO cargarAutomovil()
        {


            AutomovilDTO unAutomovil = new AutomovilDTO(
            ((MarcaDTO) cmbMarca.SelectedItem).id,
            ((ModeloDTO) cmbModelo.SelectedItem).id,
            txtPatente.Text,
            txtLicencia.Text,
            txtAutoRodado.Text,
            choferGlobal.id);

           return unAutomovil;

        }


        private void cmbModelo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AltaAutomovil_Load(object sender, EventArgs e)
        {

        }

        private void cmdSeleccionarTurno_Click(object sender, EventArgs e)
        {
            ListadoTurno ListadoSeleccionDeTurnoForm = new ListadoTurno(this);
            ListadoSeleccionDeTurnoForm.ShowDialog();
        }

        private void cmdSeleccionarChofer_Click(object sender, EventArgs e)
        {
            
            ListadoChofer ListadoSeleccionDeChoferForm = new ListadoChofer(this);
            ListadoSeleccionDeChoferForm.ShowDialog();
              
        }

        private void btnCrearAutomovil_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(cmbMarca.Text) && !string.IsNullOrWhiteSpace(cmbModelo.Text) && !string.IsNullOrWhiteSpace(txtPatente.Text) && !string.IsNullOrWhiteSpace(txtLicencia.Text) && !string.IsNullOrWhiteSpace(txtChoferDni.Text) && turnos.Count!=0)
            {
                try
                {
                    AutomovilDTO nuevoAutomovil = this.cargarAutomovil();
                    AutomovilDAO.addNewAutomovil(nuevoAutomovil,turnos);
                    MessageBox.Show("Se agrego el automovil correctamente");
                    listener.onOperationFinish();
                    this.Close();
                }
                catch (ApplicationException ex)
                {
                    Utility.ShowError("Error al agregar el automovil", ex);
                }
            }
            else
            {
                MessageBox.Show("Debe completar todos los campos", "Error");
            }
       }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(cmbMarca.Text) && !string.IsNullOrWhiteSpace(cmbModelo.Text) && !string.IsNullOrWhiteSpace(txtPatente.Text) && !string.IsNullOrWhiteSpace(txtLicencia.Text) && !string.IsNullOrWhiteSpace(txtChoferDni.Text))
            {
                try
                {
                    AutomovilDTO automovil = cargarAutomovil();
                    automovil.id = AutomovilAModificar.id;
                    automovil.activo = chkAutoActivo.Checked;
                    AutomovilDAO.updateAutomovil(automovil,turnos);
                    MessageBox.Show("Automovil modificado con exito");
                    this.Close(); //Cierro formulario
                    listener.onOperationFinish();

                }
                catch (ApplicationException ex)
                {
                    Utility.ShowError("Error al agregar el automovil", ex);
                }
            }
            else
            {
                MessageBox.Show("Debe completar todos los campos", "Error");
            }

        }

        private void btnAgregarTurno_Click(object sender, EventArgs e)
        {
            if (cmbTurno.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione algun turno para agregar");
                return;
            }

            TurnoDTO turno = (TurnoDTO)cmbTurno.SelectedItem;

            if (turnos.Contains(turno))
            {
                MessageBox.Show("Ya ha agregado este turno");
                return;
            }


            turnos.Add(turno);
            dgvTurnos.Rows.Add(turno.descripcion, turno.horaInicial, turno.horaFinal);
            cmbTurno.SelectedIndex = -1;
        }

        private void btnRemoverTurno_Click(object sender, EventArgs e)
        
        {
            if (dgvTurnos.SelectedRows.Count == 1 && dgvTurnos.RowCount != 0)
            {
                int index = dgvTurnos.SelectedRows[0].Index;
                turnos.RemoveAt(index);
                dgvTurnos.Rows.RemoveAt(index);
            }
            else
            {
                MessageBox.Show("Debe seleccionar el turno a remover");
            }
            
        }
        







    }
}
