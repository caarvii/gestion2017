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

namespace UberFrba.Abm_Automovil
{
    public partial class ListadoAutomovil : UberFrba.ListadoGenerico, OnCreateUpdateListener
    {
        public ListadoAutomovil()
        {
            InitializeComponent();
            cargarDGVAutomovil();
            cargarCombosFiltro();

        }
        List<AutomovilDTO> automoviles;
        Dictionary<string, object> filtrosAutomovilList = new Dictionary<string, object>();


        public void cargarDGVAutomovil() {
            automoviles=AutomovilDAO.getAllAutomoviles();
            tablaListado.DataSource = automoviles;
            tablaListado.Columns["turno_id"].Visible = false;
            tablaListado.Columns["chofer_id"].Visible = false;
            
        }

        public void onOperationFinish()
        {
            cargarDGVAutomovil();
            

        }

        public void cargarCombosFiltro() {
            List<MarcaDTO> marcas = MarcaDAO.getAllMarcas();
            cmbFiltroMarca.DataSource = marcas;
            cmbFiltroMarca.DisplayMember = "descripcion";
            cmbFiltroMarca.ValueMember = "id";
            cmbFiltroMarca.SelectedIndex = -1;

            List<ModeloDTO> modelos = ModeloDAO.getAllModelos();
            cmbFiltroModelo.DataSource = modelos;
            cmbFiltroModelo.DisplayMember = "nombre";
            cmbFiltroModelo.ValueMember = "id";
            cmbFiltroModelo.SelectedIndex = -1;

        }


        protected override void botonLimpiar_Click(object sender, EventArgs e)
        {
            tablaListado.DataSource = null;
            cmbFiltroMarca.SelectedIndex = -1;
            cmbFiltroModelo.SelectedIndex = -1;
            txtFiltroPatente.Text = "";
            txtFiltroChofer.Text = "";
        }


        protected void botonAlta_Click_1(object sender, EventArgs e)
        {
            AltaAutomovil altaAutomovilForm = new AltaAutomovil(this);
            altaAutomovilForm.ShowDialog();
        }

        private void ListadoAutomovil_Load_1(object sender, EventArgs e)
        {

        }

        protected void botonModificacion_Click_1(object sender, EventArgs e)
        {
            if (tablaListado.SelectedRows.Count == 1)
            {

                int index = tablaListado.SelectedRows[0].Index;
                AutomovilDTO automovil = (AutomovilDTO) automoviles.ElementAt(index);
                AltaAutomovil crearAutomovilForm = new AltaAutomovil(automovil, this);
                crearAutomovilForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Debe seleccionar el automovil a modificar");
            }
        }

        protected void botonBaja_Click_1(object sender, EventArgs e)
        {
            if (tablaListado.SelectedRows.Count == 1 && tablaListado.RowCount != 0)
            {
                DataGridViewRow row = this.tablaListado.SelectedRows[0];

                int id = Convert.ToInt32(row.Cells["id"].Value);

                if (Convert.ToBoolean(row.Cells["activo"].Value) == true)
                {
                    if (AutomovilDAO.deleteAutomovil(id) == 1)
                    {
                        MessageBox.Show("Automovil dado de baja correctamente");
                        cargarDGVAutomovil();
                    }
                } else{
                    MessageBox.Show("El automovil ya esta deshabilitado");

               }
           }

         }

        protected void botonBuscar_Click(object sender, EventArgs e)
        {

            filtrosAutomovilList = new Dictionary<string, object>();


            if (cmbFiltroModelo.SelectedIndex != -1 && ((ModeloDTO)cmbFiltroModelo.SelectedItem) != null)
            {
                filtrosAutomovilList.Add("mod_nombre", ((ModeloDTO)cmbFiltroModelo.SelectedItem).nombre.ToString());
            }

            if (cmbFiltroMarca.SelectedIndex != -1 && ((MarcaDTO)cmbFiltroMarca.SelectedItem) != null)
            {
                filtrosAutomovilList.Add("marca_nombre", ((MarcaDTO)cmbFiltroMarca.SelectedItem).descripcion);
            }

            if (!string.IsNullOrWhiteSpace(txtFiltroPatente.Text))
            {
                filtrosAutomovilList.Add("auto_patente", txtFiltroPatente.Text);
            }

            // Correspondera al nombre.

            if (!string.IsNullOrWhiteSpace(txtFiltroChofer.Text))
            {
                filtrosAutomovilList.Add("chof_nombre", txtFiltroChofer.Text);
            }


            if (filtrosAutomovilList.Count > 0)
            {
                //Tiene filtros
                automoviles = AutomovilDAO.getAutomovilesFilter(filtrosAutomovilList);
                tablaListado.DataSource = automoviles;
            }
            else
            {
                cargarDGVAutomovil();
            }


        }
    }
}