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
using UberFrba.Helpers;
using UberFrba.Interface;


namespace UberFrba.Abm_Chofer
{
    public partial class AltaChofer : Form
    {
        private ChoferDTO chofer;
        private ChoferDTO choferEdicion;

        private bool edicion = false;

        OnCreateUpdateListener listener;

        public AltaChofer(OnCreateUpdateListener listenerExterno)
        {
            InitializeComponent();
            this.dateFechaNac.Value = Config.newInstance.date;
            this.Text = "Alta de Choferes";
            this.botonAgregar.Text = "Agregar";
            this.edicion = false;
            this.checkHabilitado.Checked = true;
            listener = listenerExterno;
        }

        public AltaChofer(int choferModificableID, OnCreateUpdateListener listenerExterno)
        {
            InitializeComponent();

            cargarDatosEdicion(choferModificableID);

            this.Text = "Edicion de Choferes";
            this.botonAgregar.Text = "Editar";
            this.edicion = true;

            listener = listenerExterno;
        }

        private void cargarDatosEdicion(int choferModificableID)
        {
            //Cargar todos los datos de los choferes
            choferEdicion = ChoferDAO.getChoferById(choferModificableID);

            this.choferEdicion.id = choferModificableID;

            this.txtNombre.Text = choferEdicion.nombre;
            this.txtApellido.Text = choferEdicion.apellido;
            this.txtDNI.Text = choferEdicion.dni.ToString();
            this.txtDireccion.Text = choferEdicion.direccion;
            this.txtTelefono.Text = choferEdicion.telefono.ToString();
            this.dateFechaNac.Value = choferEdicion.fechaNacimiento;
            //this.checkHabilitado.Checked = Convert.ToBoolean(choferEdicion.estado);
            this.checkHabilitado.Checked = choferEdicion.estado;
            this.txtMail.Text = choferEdicion.mail;

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
            if (!string.IsNullOrWhiteSpace(txtNombre.Text) 
                && !string.IsNullOrWhiteSpace(txtApellido.Text)
                && !string.IsNullOrWhiteSpace(txtDNI.Text)
                && !string.IsNullOrWhiteSpace(txtDireccion.Text)
                && !string.IsNullOrWhiteSpace(txtTelefono.Text)
                && !string.IsNullOrWhiteSpace(txtMail.Text)
                && !string.IsNullOrWhiteSpace(dateFechaNac.Value.ToString()))
            {
               if (setearVariables())
                 {
                   agregarEditarChofer(chofer);
                 }
            }
            else
            {
                MessageBox.Show("Debe completar todos los campos", "Error");
            }
        }

        private bool setearVariables()
        {
            chofer = new ChoferDTO(txtNombre.Text
                                    ,txtApellido.Text 
                                    , Convert.ToInt32(txtDNI.Text)
                                    , txtDireccion.Text
                                    , Convert.ToInt32(txtTelefono.Text)
                                    , txtMail.Text
                                    , Convert.ToDateTime(dateFechaNac.Value)
                                    , checkHabilitado.Checked);
            return true;
        }


        private void agregarEditarChofer(ChoferDTO choferActivo)
        {

            if (this.edicion)
            {
                // Edicion
                try
                {
                    choferActivo.id = this.choferEdicion.id;

                    ChoferDAO.updateChofer(choferActivo);
                    MessageBox.Show("Se edito el chofer correctamente");
                    this.Close();
                    listener.onOperationFinish();
                }
                catch (ApplicationException ex)
                {
                    Utility.ShowError("Error al editar el chofer", ex);
                }

            }
            else
            {
                // Alta 
                try
                {
                    ChoferDAO.addNewChofer(choferActivo);
                    MessageBox.Show("Se agrego el chofer correctamente");
                    this.Close();
                    listener.onOperationFinish();
                }
                catch (ApplicationException ex)
                {
                    Utility.ShowError("Error al agregar el turno", ex);
                }

            }

        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            this.txtNombre.Text = "";
            this.txtApellido.Text = "";
            this.txtDNI.Text = "";
            this.txtDireccion.Text = "";
            this.txtTelefono.Text = "";
            this.txtMail.Text = "";
            this.dateFechaNac.Value = Config.newInstance.date;
            this.checkHabilitado.Checked = false;
        }


    }
}
