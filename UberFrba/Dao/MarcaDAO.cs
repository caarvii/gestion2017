using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using UberFrba.Repository;
using UberFrba.Dto;

namespace UberFrba.Dao
{
    class MarcaDAO
    {


        public static List<MarcaDTO> getAllMarcas()
        {
            SqlDataReader reader = SQLManager.executeProcedureList("getMarcas");
            return readerToListMarcas(reader);
        }



        private static List<MarcaDTO> readerToListMarcas(SqlDataReader dataReader)
        {
            List<MarcaDTO> marcas = new List<MarcaDTO>();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    MarcaDTO marca = new MarcaDTO();
                    marca.id = Convert.ToInt32(dataReader["marca_id"]);
                    marca.descripcion = Convert.ToString(dataReader["marca_nombre"]);
                    marcas.Add(marca);
                }
            }
            dataReader.Close();
            dataReader.Dispose();
            return marcas;
        }







    }
}
