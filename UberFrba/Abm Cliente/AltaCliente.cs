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

        public crearCliente()
        {
            InitializeComponent();
        }

        OnCreateUpdateListener listener;

        //este constructor lo voy a usar para modificar un cliente
        public crearCliente(ClienteDTO _clienteAModificar, OnCreateUpdateListener _listener)
        {
            InitializeComponent();
            clienteAModificar = _clienteAModificar;
            CargarDatosDeClienteAModificar();
            btnCrearCliente.Visible = false;
            btnModificar.Visible = true;
            lblUsuario.Visible = false;
            lblPassword.Visible = false;
            txtPassword.Visible = false;
            txtUserName.Visible = false;
            this.Text = "Modificar cliente";
            listener = _listener;
        }

        private void CargarDatosDeClienteAModificar(){
            ClienteDTO cliente = ClienteDAO.getClienteById(clienteAModificar.id);
            txtNombre.Text = cliente.nombre;
            txtApellido.Text = cliente.apellido;
            txtDni.Text = cliente.dni.ToString();
            txtMail.Text = cliente.mail;
            txtTelefono.Text = cliente.telefono.ToString();
            txtDireccion.Text = cliente.direccion;
            txtCodigoPostal.Text = cliente.codigoPostal.ToString();
            txtUserName.Text = cliente.username;
        }






        private ClienteDTO cargarCliente()
        {

            int dni;
            if (!Int32.TryParse(txtDni.Text, out dni)) throw new Exception("El DNI debe ser numerico");
            
            int telefono;
            if (!Int32.TryParse(txtTelefono.Text, out telefono)) throw new Exception("El telefono debe ser numerico");
            
            int codigoPostal;
            if (!Int32.TryParse(txtCodigoPostal.Text, out codigoPostal)) throw new Exception("El codigo postal debe ser numerico");


            ClienteDTO unCliente = new ClienteDTO(
                txtNombre.Text,
                txtApellido.Text,
                dni,
                txtMail.Text,
                telefono,
                txtDireccion.Text,
                codigoPostal,
                dtpFechaNacimiento.Value.Date,
                txtUserName.Text,
                txtPassword.Text);

            return unCliente;

        }

        private void btnCrearCliente_Click(object sender, EventArgs e)
        {
            try
            {
                ClienteDTO nuevoCliente = this.cargarCliente();
                ClienteDAO.addNewCliente(nuevoCliente);
                MessageBox.Show("Se agrego el turno correctamente");

            }
            catch (ApplicationException ex)
            {
                    Utility.ShowError("Error al agregar el cliente", ex);
            }

        }
        
            //vamos a necesitar un trigger que c/vez que inserte un cliente inserte el usuario


        
        private void crearCliente_Load(object sender, EventArgs e)
        {
            
        }

        public void mostrarBotonModificar()
        {
            btnModificar.Visible = true;
        }

        public void ocultarCrear() {
            btnCrearCliente.Visible = false;    
        }


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

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                ClienteDTO cliente = cargarCliente();
                cliente.id = clienteAModificar.id;
                ClienteDAO.updateCliente(cliente);
                MessageBox.Show("Cliente modificado con exito");
                this.Close(); //Cierro formulario
                listener.onOperationFinish();
                
            }
            catch (ApplicationException ex)
            {
                Utility.ShowError("Error al agregar el cliente", ex);
            }
        
        }

        private void txtCodigoPostal_TextChanged(object sender, EventArgs e)
        {

        }



            












     
        




    }
}
