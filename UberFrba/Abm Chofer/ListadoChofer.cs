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

namespace UberFrba.Abm_Chofer
{
    public partial class ListadoChofer : UberFrba.ListadoGenerico, OnCreateUpdateListener
    {

        Dictionary<string, object> filtrosChoferList = new Dictionary<string, object>();

        public ListadoChofer()
        {
            InitializeComponent();
        }

        public void onOperationFinish()
        {

            cargarListadoChofer();
            tablaListado.Columns["estado"].Visible = false;

        }

        private void cargarListadoChofer()
        {

            tablaListado.DataSource = ChoferDAO.getAllChoferes();
            tablaListado.Columns["estado"].Visible = false;

        }

        private void botonLimpiar_Click_1(object sender, EventArgs e)
        {
            tablaListado.DataSource = null;
            filtroNombre.Text = null;
            filtroApellido = null;
            filtroDNI.Text = null;
        
        }

        private void botonBuscar_Click(object sender, EventArgs e)
        {

            filtrosChoferList = new Dictionary<string, object>();

            if (!string.IsNullOrWhiteSpace(filtroNombre.Text))
            {
                filtrosChoferList.Add("chof_nombre", filtroNombre.Text);
            }

            if (!string.IsNullOrWhiteSpace(filtroApellido.Text))
            {
                filtrosChoferList.Add("chof_apellido", filtroApellido.Text);
            }

            if (!string.IsNullOrWhiteSpace(filtroDNI.Text))
            {
                filtrosChoferList.Add("chof_dni", filtroDNI.Text);
            }

            //if check todos los filtros 

            if (filtrosChoferList.Count > 0)
            {
                //Tiene filtros
                tablaListado.DataSource = ChoferDAO.getChoferFilter(filtrosChoferList);
                tablaListado.Columns["estado"].Visible = false;

            }
            else
            {
                cargarListadoChofer();
            }

        }

        private void botonBaja_Click_1(object sender, EventArgs e)
        {

            if (tablaListado.SelectedRows.Count == 1 && tablaListado.RowCount != 0)
            {
                DataGridViewRow row = this.tablaListado.SelectedRows[0];

                int id = Convert.ToInt32(row.Cells["id"].Value);

                if (TurnoDAO.deleteTurno(id) == 1)
                {
                    MessageBox.Show("Chofer dado de baja correctamente");
                    cargarListadoChofer();
                }

            }

        }

        private void botonAlta_Click_1(object sender, EventArgs e)
        {
            AltaChofer altaChoferForm = new AltaChofer(this);
            altaChoferForm.ShowDialog();
        }

        private void botonModificacion_Click_1(object sender, EventArgs e)
        {
            if (tablaListado.SelectedRows.Count == 1 && tablaListado.RowCount != 0)
            {
                DataGridViewRow row = this.tablaListado.SelectedRows[0];

                int id = Convert.ToInt32(row.Cells["id"].Value);

                AltaChofer altaTurno = new AltaChofer(id, this);
                altaTurno.ShowDialog();

            }
            else
            {
                MessageBox.Show("Debe seleccionar el chofer a modificar");

            }

        }






    }
}
