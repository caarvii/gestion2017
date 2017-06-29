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
using UberFrba.Helpers;
using UberFrba.Menu;

namespace UberFrba.Login
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            txtPassword.KeyDown += new KeyEventHandler(txtPass_KeyDown);
        }

        void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter) btnIngresar.PerformClick();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
                {
                    Utility.ShowInfo("Advertencia", "No puede estar vacio el username o el password");
                    return;
                }

                UsuarioDTO usuario = Sesion.login(txtUsername.Text, txtPassword.Text);

                if (usuario.rolesList.Count > 1)
                {
                    this.Hide();
                    SelectRolLogin selectRolLogin = new SelectRolLogin(usuario.rolesList);
                    selectRolLogin.ShowDialog();
                    Close();
                }
                else
                {
                    Sesion.RolActual = usuario.rolesList.First();
                    this.Hide();
                    MenuHome menu = new MenuHome();
                    menu.ShowDialog();
                    Close();
                }

            }
            catch (ApplicationException ex)
            {
                Utility.ShowError("Error", ex);
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
