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
using UberFrba.Menu;

namespace UberFrba.Login
{
    public partial class SelectRolLogin : Form
    {
        private List<RolDTO> rolList;

        public SelectRolLogin(List<RolDTO> list)
        {
            InitializeComponent();
            this.rolList = list; 
        }

        private void onLoadForm(object sender, System.EventArgs e)
        {
            comboBoxRoles.DataSource = rolList;
            comboBoxRoles.DisplayMember = "nombre";
            comboBoxRoles.ValueMember = "id";
        }

        private void comboBoxRoles_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            RolDTO rol = (RolDTO) comboBoxRoles.SelectedItem;
            comboBoxRoles.Text = rol.nombre.Trim();
        }

        private void buttonIngresar_Click(object sender, EventArgs e)
        {
            if (comboBoxRoles.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione algun rol para ingresar");
            }
            else
            {
                Sesion.RolActual = (RolDTO) comboBoxRoles.SelectedItem;
                this.Hide();
                MenuHome menu = new MenuHome();
                menu.ShowDialog();
                Close();

            }
        }

       
    }
}
