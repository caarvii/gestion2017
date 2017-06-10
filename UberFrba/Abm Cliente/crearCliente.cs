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

namespace UberFrba.Abm_Cliente
{
    public partial class crearCliente : Form
    {
        public crearCliente()
        {
            InitializeComponent();
        }

        private ClienteDTO cargarCliente()
        {

            int dni;
            if (!Int32.TryParse(txtDni.Text, out dni)) throw new Exception("El DNI debe ser numerico");
            
            int telefono;
            if (!Int32.TryParse(txtTelefono.Text, out telefono)) throw new Exception("El telefono debe ser numerico");
            
            int codigoPostal;
            if (!Int32.TryParse(txtCodigoPostal.Text, out codigoPostal)) throw new Exception("El telefono debe ser numerico");


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
            ClienteDTO nuevoCliente = this.cargarCliente();
            //Aca le tengo que pegar a la base de datos e insertar el cliente
            //vamos a necesitar un trigger que c/vez que inserte un cliente inserte el usuario


        }

        private void crearCliente_Load(object sender, EventArgs e)
        {

        }
/*
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.allowAlphaOnlyYEspacio(e);
            if (e.KeyChar != 8) 
                this.allowMaxLenght(txtNombre, 254, e);
        }
     
        */




    }
}
