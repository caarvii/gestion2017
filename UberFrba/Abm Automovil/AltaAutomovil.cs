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


namespace UberFrba.Abm_Automovil
{
    public partial class AltaAutomovil : Form, ListadoSeleccionListener
    {
        public AltaAutomovil()
        {
            InitializeComponent();
            cargarComboBox();
        }

        public AltaAutomovil(AutomovilDTO _AutomovilAModificar, OnCreateUpdateListener _listener)
        {
            InitializeComponent();
            cargarComboBox();
            AutomovilAModificar = _AutomovilAModificar;
            CargarDatosDeAutomovilAModificar();
            btnCrearAutomovil.Visible = false;
            btnModificar.Visible = true;
            this.Text = "Modificar automovil";
            listener = _listener;
        }


        TurnoDTO turnoGlobal;
        ChoferDTO choferGlobal;
        OnCreateUpdateListener listener;
        AutomovilDTO AutomovilAModificar;

        public void onOperationFinish(TurnoDTO turno)
        {
            turnoGlobal =turno;
            txtTurnoDescripcion.Text = turno.descripcion;
            txtTurnoHoraInicio.Text = turno.horaInicial.ToString();
            txtTurnoHoraFin.Text = turno.horaFinal.ToString();
        }

        private void CargarDatosDeAutomovilAModificar()
        {
            
            
            
            cmbMarca.SelectedItem= ((AutomovilDTO) AutomovilAModificar).auto_marca_nombre;
            cmbModelo.SelectedItem= ((AutomovilDTO) AutomovilAModificar).auto_modelo_nombre;
            txtPatente.Text = AutomovilAModificar.auto_patente;
            txtLicencia.Text = AutomovilAModificar.auto_licencia.ToString();
            //    



        }


        private void cargarComboBox()
        {
            List<MarcaDTO> marcas = MarcaDAO.getAllMarcas();
            cmbMarca.DataSource = marcas;
            cmbMarca.DisplayMember = "descripcion";
            cmbMarca.ValueMember = "id";

            List<ModeloDTO> modelo = ModeloDAO.getAllModelos();
          //  cmbModelo.DataSource = modelo;
            cmbModelo.ValueMember = "id";
            cmbModelo.DisplayMember = "descripcion";
        }

        private void txtPatente_KeyPress(object sender, EventArgs e) {
            //this.allowAlphanumericOnly(e);
            //if (e.KeyChar != 8) this.allowMaxLenght(txtPatente, 10, e);
            
        }


        private AutomovilDTO cargarAutomovil()
        {

            int licencia;
            if (!Int32.TryParse(txtLicencia.Text, out licencia)) throw new Exception("La licencia debe ser numerica");

            AutomovilDTO unAutomovil = new AutomovilDTO(
            ((MarcaDTO) cmbMarca.SelectedItem).id,
            ((ModeloDTO) cmbModelo.SelectedItem).id,
            txtPatente.Text,
            txtLicencia.Text,
            txtAutoRodado.Text);

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
            /*
            ListadoChofer ListadoSeleccionDeChoferForm = new ListadoChofer(this);
            ListadoSeleccionDeChoferForm.ShowDialog();
             */ 
        }

        private void btnCrearAutomovil_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(cmbMarca.Text) && !string.IsNullOrWhiteSpace(cmbModelo.Text) && !string.IsNullOrWhiteSpace(txtPatente.Text) && !string.IsNullOrWhiteSpace(txtLicencia.Text) && !string.IsNullOrWhiteSpace(txtTurnoDescripcion.Text) && !string.IsNullOrWhiteSpace(txtChoferDni.Text))
            {
                try
                {
                    AutomovilDTO nuevoAutomovil = this.cargarAutomovil();
                    AutomovilDAO.addNewAutomovil(nuevoAutomovil);
                    MessageBox.Show("Se agrego el automovil correctamente");
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
            if (!string.IsNullOrWhiteSpace(cmbMarca.Text) && !string.IsNullOrWhiteSpace(cmbModelo.Text) && !string.IsNullOrWhiteSpace(txtPatente.Text) && !string.IsNullOrWhiteSpace(txtLicencia.Text) && !string.IsNullOrWhiteSpace(txtTurnoDescripcion.Text) && !string.IsNullOrWhiteSpace(txtChoferDni.Text))
            {
                try
                {
                    AutomovilDTO automovil = cargarAutomovil();
                    automovil.auto_id = AutomovilAModificar.auto_id;
                    AutomovilDAO.updateAutomovil(automovil);
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




    }
}
