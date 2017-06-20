using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFrba.Dto;
using System.Data.SqlClient;
using UberFrba.Repository;

namespace UberFrba.Dao
{
    class ModeloDAO
    {

        private static List<ModeloDTO> readerToListModelos(SqlDataReader dataReader)
        {
            List<ModeloDTO> modelos = new List<ModeloDTO>();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    ModeloDTO modelo = new ModeloDTO();
                    modelo.id = Convert.ToInt32(dataReader["mod_id"]);
                    modelo.nombre = Convert.ToString(dataReader["mod_nombre"]);

                    modelos.Add(modelo);
                }
            }
            dataReader.Close();
            dataReader.Dispose();
            return modelos;
        }

        public static List<ModeloDTO> getAllModelos()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            SqlDataReader reader = SQLManager.executeProcedureList("getModelos", parameters);
            return readerToListModelos(reader);
        }


    }
}
