using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Abm_Cliente;
using UberFrba.Abm_Turno;
using UberFrba.Dto;
using UberFrba.Login;

namespace UberFrba
{
    public partial class Menu : Form
    {

        public Form currentFrom { get; set; }


        public Menu()
        {
            InitializeComponent();
            loadFuncionalidades();
            
        }

        private void loadFuncionalidades()
        {
            RolDTO rol = Sesion.RolActual;
            List<FuncionalidadDTO> funcionalidades = rol.funcionalidadesList;

        }


        private void onMenuLoad(object sender, System.EventArgs e)
        {
            usernameLabel.Text = Sesion.UsuarioActual.username;
        }

        private void rolesMenuItem_Click(object sender, EventArgs e)
        {
            //TODO
        }

        private void turnosMenuItem_Click(object sender, EventArgs e)
        {
            if (canShowForm("ListadoTurno"))
            {   
                ListadoTurno listadoTurno = new ListadoTurno();
                listadoTurno.MdiParent = this;
                listadoTurno.Dock = DockStyle.Fill;
                listadoTurno.Show();

                this.currentFrom = listadoTurno;
            }
            
        }

        private bool canShowForm(string formName)
        {
            return this.currentFrom == null || 
                (this.currentFrom != null && !this.currentFrom.Name.Equals(formName));
        }

        private void clientesMenuItem_Click(object sender, System.EventArgs e)
        {
            listadoCliente listado = new listadoCliente();
            listado.Show();
        }



    }
}
