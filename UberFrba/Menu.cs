using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Login;

namespace UberFrba
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }


        private void onMenuLoad(object sender, System.EventArgs e)
        {
            usernameLabel.Text = Sesion.UsuarioActual.username;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox5_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox6_Click(object sender, EventArgs e)
        {

        }

        private void menuFuncionalidades_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

       
    }
}
