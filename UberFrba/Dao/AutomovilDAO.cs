using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFrba.Dao;
using UberFrba.Dto;
using UberFrba.Repository;

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
                    automovil.activo = Convert.ToBoolean(dataReader["auto_activo"]);

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
            return readerAutomovilFiltro(reader);
        }

		 public static AutomovilDTO getAutomovilDisponible(int chof_id)
        {
            SqlDataReader reader = SQLManager.executeProcedureList("getAutomovilDisponible",
                SQLManager.getSingleParams("chof_id", chof_id));

            if (!reader.HasRows)
            {
                throw new ApplicationException("Este chofer no tiene automoviles habilitados");
            }

            return readerToListAutomovil(reader).First();
        }

		private static Dictionary<string, object> addNewAutomovilParams(AutomovilDTO automovil, List<TurnoDTO> turnos)
        {
            DataTable table = new DataTable();
            table.Columns.Add("turnoext_id", typeof(int));

            foreach (TurnoDTO turno in turnos)
            {
                table.Rows.Add(turno.id);
            }         

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("auto_marca_id", automovil.marca_id);
            parameters.Add("auto_modelo_id", automovil.modelo_id);
            parameters.Add("auto_patente", automovil.patente);
            parameters.Add("auto_licencia", automovil.licencia);
            parameters.Add("auto_rodado", automovil.rodado);
            parameters.Add("auto_chofer_id", automovil.chofer_id);
            parameters.Add("turnos", table);
            return parameters;

        }

        internal static void addNewAutomovil (AutomovilDTO automovil, List<TurnoDTO> turnos)
        {
            executeAutomovilProcedure("altaAutomovil", addNewAutomovilParams(automovil, turnos));
        }

        internal static void updateAutomovil(AutomovilDTO automovil, List<TurnoDTO> turnos)
        {
            Dictionary<string, object> parametros = addNewAutomovilParams(automovil, turnos);
            parametros.Add("auto_id", automovil.id);
            parametros.Add("auto_activo", automovil.activo);
            executeAutomovilProcedure("updateAutomovil", parametros);
        }


        private static void executeAutomovilProcedure(string procedureName, Dictionary<string, object> parametros)
        {
            try
            {
                SQLManager.executePorcedure(procedureName, parametros);
            }
            catch (SqlException exception)
            {
                if (exception.Number == 50000 || exception.Number == 60000)
                    throw new ApplicationException(exception.Message);
                else
                    throw exception;
            }
        }


            public static int deleteAutomovil(int auto_id)
        {

            return SQLManager.executePorcedure("bajaLogicaAutomovil", SQLManager.getSingleParams("auto_id", auto_id));

        }


          internal static List<AutomovilDTO> getAutomovilesFilter(Dictionary<string, object> filtrosAutomovilList)
        {
            StringBuilder stringBuilder = new StringBuilder("select auto_id,auto_marca_id,marca_nombre,auto_mod_id,mod_nombre,auto_patente,auto_licencia,auto_rodado,auto_activo , chof_nombre FROM GARBAGE.Automovil,GARBAGE.Marca,GARBAGE.Modelo , GARBAGE.Chofer,GARBAGE.ChoferxAutomovil WHERE auto_marca_id=marca_id and auto_mod_id = mod_id and auto_id =  chof_auto_auto_id and chof_auto_chof_id=chof_id and ");

            int a = 0;

            foreach (KeyValuePair<string, object> filtro in filtrosAutomovilList)
            {
                if (a > 0)
                {
                    stringBuilder.Append(" and ");
                }

                stringBuilder.Append(filtro.Key);
                stringBuilder.Append(" = '");
                stringBuilder.Append(filtro.Value);
                stringBuilder.Append("'");
                a = a + 1;
            }

            SqlDataReader dataReader = SQLManager.executeQuery(stringBuilder.ToString());
            return readerAutomovilFiltro(dataReader);


         }


          public static List<AutomovilDTO> readerAutomovilFiltro(SqlDataReader dataReader)
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
                      automovil.activo = Convert.ToBoolean(dataReader["auto_activo"]);

                      automovil.chofer_nombre = Convert.ToString(dataReader["chof_nombre"]);

                      automoviles.Add(automovil);
                  }
              }
              dataReader.Close();
              dataReader.Dispose();
              return automoviles;
          }



    }


}
