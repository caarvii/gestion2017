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
using UberFrba.Dto;
using UberFrba.Interface;

namespace UberFrba.Abm_Rol
{
    public partial class ListadoRol : UberFrba.ListadoGenerico, OnCreateUpdateListener
    {
        private List<RolDTO> rolList = new List<RolDTO>();
        public ListadoRol()
        {
            InitializeComponent();
            loadRoles();
        }

        private void loadRoles()
        {
            rolList = RolDAO.getRoles(); 
            tablaListado.DataSource = rolList;
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

        private void botonModificacion_Click_1(object sender, EventArgs e)
        {

            if (tablaListado.RowCount == 0)
            {
                MessageBox.Show("Debe buscar y seleccionar un rol para modificarlo");
                return;
            }

            if (tablaListado.RowCount > 0)
            {
                int index = tablaListado.SelectedRows[0].Index;
                RolDTO rol = rolList.ElementAt(index);

                AltaRol altaRol = new AltaRol(rol, this);
                altaRol.ShowDialog();
            }

           
        }

        private void botonBaja_Click_1(object sender, EventArgs e)
        {
            if (tablaListado.RowCount == 0)
            {
                MessageBox.Show("Debe buscar y seleccionar un rol para modificarlo");
                return;
            }

            if (tablaListado.RowCount > 0)
            {
                int index = tablaListado.SelectedRows[0].Index;
                RolDTO rol = rolList.ElementAt(index);
                RolDAO.deleteRol(rol.id);
                loadRoles();
            }
        }
    }
}
