﻿using System;
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

        ListadoSeleccionListener listener;
        bool seleccionDeChofer = false;
        List<ChoferDTO> choferes;
        Dictionary<string, object> filtrosChoferList = new Dictionary<string, object>();
        private bool soloActivos = new bool();

        public ListadoChofer()
        {
            InitializeComponent();
            loadChoferes();
        }

        private void loadChoferes()
        {
            tablaListado.DataSource = ChoferDAO.getAllChoferes();

        }

        public ListadoChofer(ListadoSeleccionListener _listener) : this(_listener, false)
        {
        }

        public ListadoChofer(ListadoSeleccionListener _listener, Boolean soloActivos)
        {
            InitializeComponent();
            listener = _listener;
            this.soloActivos = soloActivos;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            cargarListadoChofer();
            botonAlta.Visible = false;
            botonBaja.Visible = false;
            botonModificacion.Text = "Seleccionar";
            seleccionDeChofer = true;
        }


        public void onOperationFinish()
        {
            cargarListadoChofer();
            tablaListado.Columns["estado"].Visible = false;
        }

        private void cargarListadoChofer()
        {
            choferes = soloActivos ? ChoferDAO.getChoferesHabilitados() : ChoferDAO.getAllChoferes();
            tablaListado.DataSource = choferes;
            tablaListado.Columns["estado"].Visible = false;
        }

        private void botonLimpiar_Click_1(object sender, EventArgs e)
        {
            tablaListado.DataSource = null;
            filtroNombre.Text = null;
            filtroApellido.Text = null;
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
                choferes = ChoferDAO.getChoferFilter(filtrosChoferList, soloActivos);
                tablaListado.DataSource = choferes;
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

                if (ChoferDAO.deleteChofer(id) == 1)
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

            if (!seleccionDeChofer)
            {


                if (tablaListado.SelectedRows.Count == 1 && tablaListado.RowCount != 0)
                {
                    DataGridViewRow row = this.tablaListado.SelectedRows[0];

                    int id = Convert.ToInt32(row.Cells["id"].Value);

                    AltaChofer altaChofer = new AltaChofer(id, this);
                    altaChofer.ShowDialog();

                }
                else
                {
                    MessageBox.Show("Debe seleccionar el chofer a modificar");

                }

            }else{

                if (tablaListado.RowCount > 0)
                {
                    int index = tablaListado.SelectedRows[0].Index;
                    listener.onOperationFinishChofer(choferes.ElementAt(index));
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una fila");
                }




           }
        }  

        private void ListadoChofer_Load(object sender, EventArgs e)
        {

        }







    }
}
