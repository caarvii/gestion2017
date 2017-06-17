using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Abm_Automovil
{
    public partial class ListadoAutomovilesReal : UberFrba.ListadoGenerico
    {
        public ListadoAutomovilesReal()
        {
            InitializeComponent();
            this.Text = this.Text + " de Automoviles";

            // Agregar o no los criterios de busqueda.
            llenarTablaSinCriterios(tablaListado);

        }

        private static void llenarTablaSinCriterios(DataGridView tablaListado)
        {
            // Abro consulta
           // CONN.connection.Open();

            // Deberia pegarle a la base.
           // string consultaSQL = "SELECT * FROM GARBAGE.Automovil";


            //tablaListado.DataSource = CONN.devolverDatosConConsulta(consultaSQL);


           // CONN.connection.Close();
            // Cierro consulta
        }

        protected override void botonLimpiar_Click(object sender, EventArgs e)
        {
            // Limpiar generico
            base.botonLimpiar_Click(this, null);

            // Limpiar especifico de los criterios.

            // TODO

        }

    }
}
