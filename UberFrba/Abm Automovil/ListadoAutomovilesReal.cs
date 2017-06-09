using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Uso la conexion
using CONN = UberFrba.conexion;

namespace UberFrba.Abm_Automovil
{
    public partial class ListadoAutomovilesReal : UberFrba.listadoGenerico
    {
        public ListadoAutomovilesReal()
        {
            InitializeComponent();

            // Agregar o no los criterios de busqueda.
            llenarTablaSinCriterios(tablaListado);

        }

        private static void llenarTablaSinCriterios(DataGridView tablaListado)
        {
            // Abro consulta
            CONN.connection.Open();

            // Deberia pegarle a la base.
            string consultaSQL = "SELECT * FROM GARBAGE.Automovil";


            tablaListado.DataSource = CONN.devolverDatosConConsulta(consultaSQL);


            CONN.connection.Close();
            // Cierro consulta
        }

    }
}
