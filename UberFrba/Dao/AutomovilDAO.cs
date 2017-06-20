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
    class AutomovilDAO{

        public static List<AutomovilDTO> readerToListAutomovil(SqlDataReader dataReader)
        {

            List<AutomovilDTO> automoviles = new List<AutomovilDTO>();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    AutomovilDTO automovil = new AutomovilDTO();
                    automovil.auto_id = Convert.ToInt32(dataReader["auto_id"]);
                    automovil.auto_marca_id = Convert.ToInt32(dataReader["auto_marca_id"]);
                    automovil.auto_marca_nombre = Convert.ToString(dataReader["marca_nombre"]);
                    automovil.auto_modelo_id = Convert.ToInt32(dataReader["auto_mod_id"]);
                    automovil.auto_modelo_nombre = Convert.ToString(dataReader["mod_nombre"]);
                    automovil.auto_patente = Convert.ToString(dataReader["auto_patente"]);
                    automovil.auto_licencia = Convert.ToInt32(dataReader["auto_licencia"]);
                    automovil.auto_rodado = Convert.ToString(dataReader["auto_rodado"]);
                    automoviles.Add(automovil);
                }
            }
            dataReader.Close();
            dataReader.Dispose();
            return automoviles;
       }


        public static List<AutomovilDTO> getAllAutomoviles()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            SqlDataReader reader = SQLManager.executeProcedureList("getAutomoviles", parameters);
            return readerToListAutomovil(reader);
        }

         public static void addNewAutomovil(AutomovilDTO automovil){
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("auto_id", automovil.auto_id);
            parameters.Add("marca_id", automovil.auto_marca_id);
            parameters.Add("auto_modelo_id", automovil.auto_modelo_id);
            parameters.Add("auto_patente", automovil.auto_patente);
            parameters.Add("auto_licencia", automovil.auto_licencia);
            parameters.Add("auto_rodado", automovil.auto_rodado);
            parameters.Add("auto_turno_id", automovil.auto_turno_id);
            parameters.Add("auto_chofer_id", automovil.auto_chofer_id);

            try
            {
                SQLManager.executePorcedure("altaAutomovil", parameters);
            }
            catch (SqlException exception)
            {
                if (exception.Number == 50000)
                {
                    throw new ApplicationException(exception.Message);
                }
                else
                {
                    throw exception;
                }
            }


         }





    















    }
}
