using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba;

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
            //cmbMarca.DataSource = marcaDAO.getMarcas();
            cmbMarca.DisplayMember = "Marca";

            //cmbTurno.DataSource = turnoDAO.getTurnos();
            cmbMarca.DisplayMember = "Turno";

            //cmbMarca.DataSource = choferDAO.getChoferes();
            cmbMarca.DisplayMember = "Chofer";
        }

        private void txtPatente_KeyPress(object sender, EventArgs e) {
            this.allowAlphanumericOnly(e);
            if (e.KeyChar != 8) this.allowMaxLenght(txtPatente, 10, e);
            
        }




    }
}
