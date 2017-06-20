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

namespace UberFrba.Abm_Automovil
{
    public partial class ListadoAutomovil : UberFrba.ListadoGenerico
    {
        public ListadoAutomovil()
        {
            InitializeComponent();
            cargarDGVAutomovil();

        }


        public void cargarDGVAutomovil() {
            tablaListado.DataSource = AutomovilDAO.getAllAutomoviles();
        
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

    }
}
