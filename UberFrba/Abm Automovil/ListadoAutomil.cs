using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

// Agrego form de conexion
using CONN = UberFrba.conexion;

namespace UberFrba.Abm_Automovil
{
    public partial class ListadoAutomil : UberFrba.conexion 
    {
        public ListadoAutomil()
        {
            InitializeComponent();
            label2.Text = a;
            consulta(tabla);

            // Cierro conexcion
            connection.Close();
        }

        private static void consulta(DataGridView tabla){

            // Prueba llenado

            string consultaSQL = "SELECT TOP 10 * FROM GARBAGE.Automovil";
            SqlDataAdapter adapter = new SqlDataAdapter(consultaSQL, connection);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);

            DataTable table = new DataTable();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            adapter.Fill(table);

            tabla.DataSource = table;

            tabla.AutoResizeColumns(
                DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
  
        }

    }
}
