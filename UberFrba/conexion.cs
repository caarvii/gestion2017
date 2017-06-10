using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UberFrba
{
    class Conexion
    {

        // CONEXION

        //public static string connectionString = "Server=SA-PC\\SQLSERVER2012;Database=GD1C2017;User Id=gd;Password=gd2017";
        //public static SqlConnection connection = new SqlConnection(connectionString);

        // Metodos 

        public static DataTable devolverDatosConConsulta(String consulta)
        {
            Config config = Config.newInstance;

            SqlConnection conn = new SqlConnection(config.connectionDB);

            SqlDataAdapter adapter = new SqlDataAdapter(consulta, conn);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);

            DataTable table = new DataTable();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            adapter.Fill(table);

            return table;
        }

        public static SqlConnection obtenerConexion()
        {
            Config config = Config.newInstance;

            SqlConnection conn = new SqlConnection(config.connectionDB);
            conn.Open();
            System.Console.WriteLine("Conexion exitosa");
            return conn;

        }
    }
}
