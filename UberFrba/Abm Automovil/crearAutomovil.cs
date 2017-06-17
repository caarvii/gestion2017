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

namespace UberFrba.Abm_Automovil
{
    public partial class frmCrearAutomovil : Form
    {
        public frmCrearAutomovil()
        {
            InitializeComponent();
            cargarComboBox();
        }

        private void frmCrearAutomovil_Load(object sender, EventArgs e)
        {

        }

        private void cargarComboBox()
        {
            List<MarcaDTO> marcas = MarcaDAO.getAllMarcas();
            cmbMarca.DataSource = marcas;
            cmbMarca.DisplayMember = "descripcion";
            cmbMarca.ValueMember = "id";

            List<TurnoDTO> turnos = TurnoDAO.getAllTurnoDescripcion();
            cmbTurno.DataSource = turnos;
            cmbTurno.DisplayMember = "descripcion";
            cmbTurno.ValueMember = "id";

            List<ChoferDTO> choferes = ChoferDAO.getAllChoferes();
            cmbChofer.DataSource = choferes;
            cmbChofer.DisplayMember = "dni";
            cmbChofer.ValueMember = "id";
        }

        private void txtPatente_KeyPress(object sender, EventArgs e) {
          /*  this.allowAlphanumericOnly(e);
            if (e.KeyChar != 8) this.allowMaxLenght(txtPatente, 10, e);
            */
        }

        private void btnCrearAutomovil_Click(object sender, EventArgs e)
        {
            MarcaDTO marca = (MarcaDTO)cmbMarca.SelectedItem;
            int id_marca = marca.id;
            string Modelo = txtModelo.Text;
            string Patente = txtPatente.Text;
            string Licencia = txtLicencia.Text;
            TurnoDTO turno = (TurnoDTO)cmbTurno.SelectedItem;
            ChoferDTO chofer = (ChoferDTO)cmbChofer.SelectedItem;




        }

        private void cmbMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            MarcaDTO marca = (MarcaDTO)cmbMarca.SelectedItem;
            List<ModeloDTO> modelos = ModeloDAO.getModelosListByMarca(marca.id);
            cmbModelo.DataSource = modelos;
            cmbModelo.DisplayMember = "nombre";
            cmbModelo.ValueMember = "id";
        }

        private void cmbModelo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }




    }
}
