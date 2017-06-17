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
    class ChoferDAO
    {
        public static List<ChoferDTO> ReaderToListChofer(SqlDataReader dataReader)
        {
            List<ChoferDTO> choferes = new List<ChoferDTO>();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    ChoferDTO chofer = new ChoferDTO();
                    chofer.id = Convert.ToInt32(dataReader["chof_id"]);
                    chofer.dni = Convert.ToInt32(dataReader["chof_dni"]);
                    chofer.nombre = Convert.ToString(dataReader["chof_nombre"]);
                    chofer.apellido = Convert.ToString(dataReader["chof_apellido"]);
                    choferes.Add(chofer);
                }
            }
            dataReader.Close();
            dataReader.Dispose();
            return choferes;

        }

        public static List<ChoferDTO> getAllChoferes()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            SqlDataReader reader = SQLManager.executeProcedureList("getChoferes", parameters);
            return ReaderToListChofer(reader);
        }







    }
}
