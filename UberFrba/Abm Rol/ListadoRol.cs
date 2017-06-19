using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Dao;
using UberFrba.Interface;

namespace UberFrba.Abm_Rol
{
    public partial class ListadoRol : UberFrba.ListadoGenerico, OnCreateUpdateListener
    {
        public ListadoRol()
        {
            InitializeComponent();
            loadRoles();
        }

        private void loadRoles()
        {
            tablaListado.DataSource = RolDAO.getRoles();
        }

        private void botonBuscar_Click(object sender, EventArgs e)
        {
            loadRoles();
        }

        private void botonAlta_Click_1(object sender, EventArgs e)
        {
            AltaRol altaRol = new AltaRol(this);
            altaRol.ShowDialog();
        }

        public void onOperationFinish()
        {
            loadRoles();
        }
    }
}
