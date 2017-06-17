using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Dto;
using UberFrba.Dao;

namespace UberFrba.Abm_Chofer
{
    public partial class AltaChofer : Form
    {
        private ChoferDTO chofer;
        private ChoferDTO choferEdicion;

        private bool edicion = false;


        public AltaChofer()
        {
            InitializeComponent();
            this.Text = "Alta de Choferes";
            this.botonAgregar.Text = "Agregar";
            this.edicion = false;
            this.checkHabilitado.Checked = true;

        }

        public AltaChofer(int choferModificableID)
        {
            InitializeComponent();

            cargarDatosEdicion(choferModificableID);

            this.Text = "Edicion de Choferes";
            this.botonAgregar.Text = "Editar";
            this.edicion = false;
        }

        private void cargarDatosEdicion(int choferModificableID)
        {
            //Cargar todos los datos de los choferes
            choferEdicion = ChoferDAO.getChoferById(choferModificableID);

            this.txtNombre.Text = choferEdicion.nombre;
            this.txtApellido.Text = choferEdicion.apellido;
            this.txtDNI.Text = choferEdicion.dni.ToString();
            this.txtDireccion.Text = choferEdicion.direccion;
            this.txtTelefono.Text = choferEdicion.telefono.ToString();
            this.dateFechaNac.Value = choferEdicion.fechaNacimiento;
            
            //PENDIENTE

            //this.txtUsuario.Text = 
            //this.txtPassword.Text =

            //txtUserName.Text = cliente.username;
                
            // CONSULTAR QUE HACEMOS CON ESTADO.
            
        }


        // VALIDACIONES

         private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.allowAlphaOnlyYEspacio(e);
            if (e.KeyChar != 8) 
                this.allowMaxLenght(txtNombre, 254, e);
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.allowAlphaOnlyYEspacio(e);
            if (e.KeyChar != 8)
                this.allowMaxLenght(txtNombre, 255, e);
        }

         private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.allowNumericOnly(e);
            if (e.KeyChar != 8) this.allowMaxLenght(txtDNI, 18, e);
        }

        private void txtMail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8) this.allowMaxLenght(txtMail, 255, e);
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.allowNumericOnly(e);
            if (e.KeyChar != 8) this.allowMaxLenght(txtTelefono, 18, e);
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.allowAlphanumericYEspacio(e);
            if (e.KeyChar != 8) this.allowMaxLenght(txtTelefono, 18, e);
        }

        // BOTONES

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
            this.txtUsuario.Text = "";
            this.txtPassword.Text = "";

            this.checkHabilitado.Checked = false;
        }


    }
}
