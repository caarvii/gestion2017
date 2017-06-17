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

        public static List<ModeloDTO> readerToListModelos(SqlDataReader dataReader)
        {
            List<ModeloDTO> modelos = new List<ModeloDTO>();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    ModeloDTO modelo = new ModeloDTO();
                    modelo.id = Convert.ToInt32(dataReader["modelo_id"]);
                    modelo.nombre = Convert.ToString(dataReader["modelo_nombre"]);

                    modelos.Add(modelo);
                }
            }
            dataReader.Close();
            dataReader.Dispose();
            return modelos;
        }

        public static List<ModeloDTO> getModelosListByMarca(int marcaId)
        {

            SqlDataReader reader = SQLManager.executeProcedureList("getModelosListByMarca",
                SQLManager.getSingleParams("marca_id", marcaId));
            List<ModeloDTO> modelos = readerToListModelos(reader);
            return modelos;
        }




    }
}
