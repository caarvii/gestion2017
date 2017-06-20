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
using UberFrba.Abm_Rol;
using UberFrba.Abm_Turno;
using UberFrba.Dto;
using UberFrba.Listado_Estadistico;
using UberFrba.Login;

namespace UberFrba.Menu
{
    public partial class MenuHome : Form
    {

        public Form currentForm { get; set; }

        public MenuHome()
        {
            InitializeComponent();
            loadFuncionalidades();
        }

        private void loadFuncionalidades()
        {
            RolDTO rol = Sesion.RolActual;
            List<FuncionalidadDTO> funcionalidades = rol.funcionalidadesList;

            this.abmTitleLabel.Visible = false;
            this.operacionesTitleLabel.Visible = false;
            this.reportesTitleLabel.Visible = false;

            this.rolesMenuItem.Available = false;
            this.clientesMenuItem.Available = false;
            this.autoMenuItem.Available = false;
            this.choferesMenuItem.Available = false;
            this.turnosMenuItem.Available = false;
            this.registrarViajeMenuItem.Available = false;
            this.rendicionViajesMenuItem.Available = false;
            this.facturarClienteMenuItem.Available = false;
            this.listadoEstadisticoMenuItem.Available = false;

            foreach (FuncionalidadDTO funcionalidad in funcionalidades)
            {
                switch (funcionalidad.toFuncionalidad())
                {
                    case FuncionalidadDTO.Funcionalidad.ABM_ROL:
                        this.rolesMenuItem.Available = true;
                        break;
                    case FuncionalidadDTO.Funcionalidad.ABM_CLIENTE:
                        this.clientesMenuItem.Available = true;
                        break;
                    case FuncionalidadDTO.Funcionalidad.ABM_AUTOMOVIL:
                        this.autoMenuItem.Available = true;
                        break;
                    case FuncionalidadDTO.Funcionalidad.AMB_CHOFER:
                        this.choferesMenuItem.Available = true;
                        break;
                    case FuncionalidadDTO.Funcionalidad.AMB_TURNO:
                        this.turnosMenuItem.Available = true;
                        break;
                    case FuncionalidadDTO.Funcionalidad.REGISTRAR_VIAJE:
                        this.registrarViajeMenuItem.Available = true;
                        break;
                    case FuncionalidadDTO.Funcionalidad.RENDICION_DE_VIAJES:
                        this.rendicionViajesMenuItem.Available = true;
                        break;
                    case FuncionalidadDTO.Funcionalidad.FACTURACION_CLIENTES:
                        this.facturarClienteMenuItem.Available = true;
                        break;
                    case FuncionalidadDTO.Funcionalidad.LISTADO_ESTADISTICO:
                        this.listadoEstadisticoMenuItem.Available = true;
                        break;
                }
            }

            if (this.rolesMenuItem.Available || this.clientesMenuItem.Available ||
                this.autoMenuItem.Available || this.choferesMenuItem.Available ||
                this.turnosMenuItem.Available)
            {
                this.abmTitleLabel.Visible = true;
            }

            if (this.registrarViajeMenuItem.Available || this.rendicionViajesMenuItem.Available ||
                this.facturarClienteMenuItem.Available)
            {
                this.operacionesTitleLabel.Visible = true;
            }

            if (this.listadoEstadisticoMenuItem.Available)
            {
                this.reportesTitleLabel.Visible = true;
            }
        }

        private void onMenuLoad(object sender, System.EventArgs e)
        {
            usernameLabel.Text = Sesion.UsuarioActual.username;
        }

        private void rolesMenuItem_Click(object sender, EventArgs e)
        {
            if (canShowForm("ListadoRol"))
            {
                showMenuForm(new ListadoRol());
            }
        }

        private void turnosMenuItem_Click(object sender, EventArgs e)
        {
            if (canShowForm("ListadoTurno"))
            {
                showMenuForm(new ListadoTurno());
            }
        }

        private void clientesMenuItem_Click(object sender, System.EventArgs e)
        {
            if (canShowForm("ListadoCliente"))
            {
                showMenuForm(new ListadoCliente());
            }
        }

        private bool canShowForm(string formName)
        {
            return this.currentForm == null ||
                (this.currentForm != null && !this.currentForm.Name.Equals(formName));
        }

        private void showMenuForm(Form newForm)
        {
            newForm.MdiParent = this;
            newForm.Dock = DockStyle.Fill;

            if (currentForm != null)
            {
                var oldForm = currentForm;
                this.currentForm = newForm;
                oldForm.Hide();
                currentForm.Show();
                oldForm.Close();
            }
            else
            {
                this.currentForm = newForm;
                currentForm.Show();
            }
        }

        private void cerrarSesionMenuItem_Click(object sender, EventArgs e)
        {
            Sesion.logout();
            FormLogin formLogin = new FormLogin();
            this.Hide();
            formLogin.ShowDialog();
            this.Close();
        }

        private void listadoEstadisticoMenuItem_Click(object sender, EventArgs e)
        {
            if (canShowForm("Listado"))
            {
                showMenuForm(new Listado());
            }

        }
    }
}
