using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Repository
{
    class SQLManager
    {

        private static SqlParameter _executeScalar(SqlConnection con, SqlCommand com)
        {
            SqlParameter returnValue = new SqlParameter();
            returnValue.Direction = ParameterDirection.ReturnValue;
            com.Parameters.Add(returnValue);
            con.Open();
            com.ExecuteScalar();
            con.Close();
            return returnValue;
        }

        private static SqlDataReader _executeList(SqlConnection con, SqlCommand com)
        {
            con.Open();
            return com.ExecuteReader();
        }

        private static void addParameters(
           System.Collections.Generic.Dictionary<String, Object> parameters, SqlCommand com)
        {
            foreach (KeyValuePair<string, object> param in parameters)
            {
                com.Parameters.AddWithValue(param.Key, param.Value);
            }
        }

        public static int executePorcedure(String procedureName,
            System.Collections.Generic.Dictionary<String, Object> parameters)
        {
            SqlConnection con = Conexion.obtenerConexion();

            
            SqlCommand com = new SqlCommand("GARBAGE." + procedureName, con);
            com.CommandType = CommandType.StoredProcedure;

            addParameters(parameters, com);

            SqlParameter returnValue = _executeScalar(con, com);

            return Convert.ToInt32(returnValue.Value);
        }

        public static SqlDataReader executeProcedureList(String functionName,
            System.Collections.Generic.Dictionary<String, Object> parameters)
        {
            SqlConnection con = Conexion.obtenerConexion();

            SqlCommand com = new SqlCommand("GARBAGE." + functionName, con);
            com.CommandType = CommandType.StoredProcedure;

            addParameters(parameters, com);

            return _executeList(con, com);
        }

        public static Dictionary<string, object> getSingleParams(string key, object value)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add(key, value);
            return parameters;
        }
    }
}
