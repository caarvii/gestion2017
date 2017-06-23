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

        }
        List<AutomovilDTO> automoviles;

        public void cargarDGVAutomovil() {
            automoviles=AutomovilDAO.getAllAutomoviles();
            tablaListado.DataSource = automoviles;
        
        }

        public void onOperationFinish()
        {

            

        }


        protected override void botonLimpiar_Click(object sender, EventArgs e)
        {
            tablaListado.DataSource = null;


        }


        protected void botonAlta_Click_1(object sender, EventArgs e)
        {
            AltaAutomovil altaAutomovilForm = new AltaAutomovil();
            altaAutomovilForm.ShowDialog();
        }

        private void ListadoAutomovil_Load_1(object sender, EventArgs e)
        {

        }

        private void botonModificacion_Click_1(object sender, EventArgs e)
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

    }
}
