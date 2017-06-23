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
                    automovil.id = Convert.ToInt32(dataReader["auto_id"]);
                    automovil.marca_id = Convert.ToInt32(dataReader["auto_marca_id"]);
                    automovil.marca_nombre = Convert.ToString(dataReader["marca_nombre"]);
                    automovil.modelo_id = Convert.ToInt32(dataReader["auto_mod_id"]);
                    automovil.modelo_nombre = Convert.ToString(dataReader["mod_nombre"]);
                    automovil.patente = Convert.ToString(dataReader["auto_patente"]);
                    automovil.licencia = Convert.ToString(dataReader["auto_licencia"]);
                    automovil.rodado = Convert.ToString(dataReader["auto_rodado"]);
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
            parameters.Add("auto_marca_id", automovil.marca_id);
            parameters.Add("auto_modelo_id", automovil.modelo_id);
            parameters.Add("auto_patente", automovil.patente);
            parameters.Add("auto_licencia", automovil.licencia);
            parameters.Add("auto_rodado", automovil.rodado);
            parameters.Add("auto_turno_id", automovil.turno_id);
            parameters.Add("auto_chofer_id", automovil.chofer_id);

            try
            {
                SQLManager.executePorcedure("altaAutomovil", parameters);
            }
            catch (SqlException exception)
            {
                if (exception.Number == 50000 || exception.Number == 60000)
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
