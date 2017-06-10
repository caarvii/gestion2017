using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace UberFrba
{
    public partial class conexion : Form
    {
        public conexion()
        {
            InitializeComponent();
        }

        // Prueba de variables heredables.

        public String a = "VALOR DE VARIABLE A";


        // CONEXION

        public static string connectionString = "Server=SA-PC\\SQLSERVER2012;Database=GD1C2017;User Id=gd;Password=gd2017";
        public static SqlConnection connection = new SqlConnection(connectionString);

        // Metodos 

        public static DataTable devolverDatosConConsulta(String consulta)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(consulta, connection);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);

            DataTable table = new DataTable();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            adapter.Fill(table);

            return table;
        }

    }
}
