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
using UberFrba.Abm_Cliente;
using UberFrba.Helpers;
using UberFrba.Interface;

namespace UberFrba.Dao
{
    public partial class crearCliente : Form
    {
        ClienteDTO clienteAModificar;

        OnCreateUpdateListener listener;

        public crearCliente(OnCreateUpdateListener listenerExterno)
        {
            InitializeComponent();
            this.Text = "Alta de Clientes";

            btnCrearCliente.Visible = true
                ;
            btnModificar.Visible = false;

            this.checkHabilitado.Checked = true;
            
            listener = listenerExterno;

        }

        public crearCliente(ClienteDTO _clienteAModificar, OnCreateUpdateListener _listener)
        {
            InitializeComponent();
            clienteAModificar = _clienteAModificar;

            CargarDatosDeClienteAModificar(clienteAModificar);

            btnCrearCliente.Visible = false;
            btnModificar.Visible = true;
            
            this.Text = "Modificar cliente";
            listener = _listener;
        }

        private void CargarDatosDeClienteAModificar(ClienteDTO clienteAModificar)
        {
            //ClienteDTO cliente = ClienteDAO.getClienteById(clienteAModificar.id);

            ClienteDTO cliente = clienteAModificar;

            txtNombre.Text = cliente.nombre;
            txtApellido.Text = cliente.apellido;
            txtDni.Text = cliente.dni.ToString();
            txtMail.Text = cliente.mail;
            txtTelefono.Text = cliente.telefono.ToString();
            txtDireccion.Text = cliente.direccion;
            txtCodigoPostal.Text = cliente.codigoPostal.ToString();
            this.checkHabilitado.Checked = Convert.ToBoolean(cliente.estado);
            
        }

        private ClienteDTO cargarCliente()
        {
            /*
            int dni;
            if (!Int32.TryParse(txtDni.Text, out dni)) throw new Exception("El DNI debe ser numerico");
            
            int telefono;
            if (!Int32.TryParse(txtTelefono.Text, out telefono)) throw new Exception("El telefono debe ser numerico");
            
            int codigoPostal;
            if (!Int32.TryParse(txtCodigoPostal.Text, out codigoPostal)) throw new Exception("El codigo postal debe ser numerico");
            */

            ClienteDTO unCliente = new ClienteDTO(
                                                    txtNombre.Text
                                                    ,txtApellido.Text
                                                    , Convert.ToInt32(txtDni.Text)
                                                    ,txtMail.Text
                                                    , Convert.ToInt32(txtTelefono.Text)
                                                    ,txtDireccion.Text
                                                    , Convert.ToInt32(txtCodigoPostal.Text)
                                                    ,Convert.ToDateTime(dtpFechaNacimiento.Value)
                                                    ,checkHabilitado.Checked);

            return unCliente;
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

        private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.allowNumericOnly(e);
            if (e.KeyChar != 8) this.allowMaxLenght(txtDni, 18, e);
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

        private void txtCodigoPostal_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.allowNumericOnly(e);
            if (e.KeyChar != 8) this.allowMaxLenght(txtCodigoPostal, 18, e);
        }


        // BOTONES

        private void btnCrearCliente_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNombre.Text)
                && !string.IsNullOrWhiteSpace(txtApellido.Text)
                && !string.IsNullOrWhiteSpace(txtDni.Text)
                && !string.IsNullOrWhiteSpace(txtDireccion.Text)
                && !string.IsNullOrWhiteSpace(txtTelefono.Text)
                && !string.IsNullOrWhiteSpace(txtCodigoPostal.Text)
                && !string.IsNullOrWhiteSpace(txtMail.Text)
                && !string.IsNullOrWhiteSpace(dtpFechaNacimiento.Value.ToString()))
            {
                try
                {
                    ClienteDTO nuevoCliente = this.cargarCliente();

                    ClienteDAO.addNewCliente(nuevoCliente);
                    MessageBox.Show("Se agrego el cliente correctamente");

                    this.Close();
                    listener.onOperationFinish();

                }
                catch (ApplicationException ex)
                {
                    Utility.ShowError("Error al agregar el cliente", ex);
                }

            }
            else
            {
                MessageBox.Show("Debe completar todos los campos", "Error");

            }

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNombre.Text)
                && !string.IsNullOrWhiteSpace(txtApellido.Text)
                && !string.IsNullOrWhiteSpace(txtDni.Text)
                && !string.IsNullOrWhiteSpace(txtDireccion.Text)
                && !string.IsNullOrWhiteSpace(txtTelefono.Text)
                && !string.IsNullOrWhiteSpace(dtpFechaNacimiento.Value.ToString()))
            {
                try
                {
                    ClienteDTO cliente = cargarCliente();

                    cliente.id = clienteAModificar.id;

                    ClienteDAO.updateCliente(cliente);
                    MessageBox.Show("Cliente modificado con exito");

                    this.Close();
                    listener.onOperationFinish();

                }
                catch (ApplicationException ex)
                {
                    Utility.ShowError("Error al agregar el cliente", ex);
                } 

            }
            else
            {
                MessageBox.Show("Debe completar todos los campos", "Error");
            }
        
        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            this.txtNombre.Text = "";
            this.txtApellido.Text = "";
            this.txtDni.Text = "";
            this.txtDireccion.Text = "";
            this.txtTelefono.Text = "";
            this.txtMail.Text = "";
            this.txtCodigoPostal.Text = "";
            this.dtpFechaNacimiento.ResetText();
            this.checkHabilitado.Checked = false;
        }

        public void mostrarBotonModificar()
        {
            btnModificar.Visible = true;
        }

        public void ocultarCrear()
        {
            btnCrearCliente.Visible = false;
        }

        // FIN LINEA


    }
}
