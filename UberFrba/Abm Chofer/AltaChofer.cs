using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Abm_Chofer
{
    public partial class AltaChofer : Form
    {
        private ChoferDTO chofer;



        public AltaChofer()
        {
            InitializeComponent();
        }

        private void botonAgregar_Click(object sender, EventArgs e)
        {

        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            this.txtNombre.Text = "";
            this.txtApellido.Text = "";
            this.txtDNI.Text = "";
            this.txtDireccion.Text = "";
            this.txtTelefono.Text = "";
            this.txtMail.Text = "";
            this.dateFechaNac.ResetText();
            this.checkHabilitado.Checked = false;
        }


    }
}
