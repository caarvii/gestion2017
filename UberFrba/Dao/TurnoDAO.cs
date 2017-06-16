using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFrba.Dto;
using UberFrba.Repository;

namespace UberFrba.Dao
{
    public class TurnoDAO
    {

        public static void updateTurno(TurnoDTO turno) 
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("turno_id", turno.id);
            parameters.Add("turno_hora_inicio", turno.horaInicial);
            parameters.Add("turno_hora_fin", turno.horaFinal);
            parameters.Add("turno_descripcion", turno.descripcion);
            parameters.Add("turno_valor_km", turno.valor);
            parameters.Add("turno_precio_base", turno.precio);
            parameters.Add("turno_habilitado", turno.estado);

            try
            {
                SQLManager.executePorcedure("updateTurno", parameters);
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


        //Probar si funciona
        public static void addNewTurno(TurnoDTO turno)
        {
            // VER EL TEMA DE LA FECHA

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("turno_hora_inicio", turno.horaInicial);
            parameters.Add("turno_hora_fin", turno.horaFinal);
            parameters.Add("turno_descripcion", turno.descripcion);
            parameters.Add("turno_valor_km", turno.valor);
            parameters.Add("turno_precio_base", turno.precio);
 
            // Se habilita por defecto en 1
            try
            {
                SQLManager.executePorcedure("altaTurno", parameters);
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

        //Probar si funciona
        public static int deleteTurno(int turno_id)
        {
            
            return SQLManager.executePorcedure("bajaLogicaTurno", SQLManager.getSingleParams("turno_id", turno_id));

        }
        

        // Probar si funciona
        public static List<TurnoDTO> getAllTurnos()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            SqlDataReader dataReader = SQLManager.executeProcedureList("getAllTurnos", parameters);

            return getTurnos(dataReader);
        }
       


        public static TurnoDTO selectTurnoById(int turno_id)
        {
            SqlDataReader dataReader = SQLManager.executeProcedureList("getTurnoById",
               SQLManager.getSingleParams("turno_id", turno_id));
            return getTurnos(dataReader).First();

        }

        private static List<TurnoDTO> getTurnos(SqlDataReader dataReader)
        {
            List<TurnoDTO> listaTurnos = new List<TurnoDTO>();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    TurnoDTO turno = new TurnoDTO();
                    turno.id = Convert.ToInt32(dataReader["turno_id"]);
                    turno.horaInicial = Convert.ToInt32(dataReader["turno_hora_inicio"]);
                    turno.horaFinal = Convert.ToInt32(dataReader["turno_hora_fin"]);
                    turno.descripcion =  Convert.ToString(dataReader["turno_descripcion"]);
                    turno.valor = Convert.ToDouble(dataReader["turno_valor_km"]);
                    turno.precio = Convert.ToDouble(dataReader["turno_precio_base"]);
                    turno.estado = Convert.ToBoolean(dataReader["turno_habilitado"]);

                    listaTurnos.Add(turno);
                }
            }
            dataReader.Close();
            dataReader.Dispose();
            return listaTurnos;
        }

        internal static List<TurnoDTO> getTurnosFilter(Dictionary<string, object> filtrosTurnoList)
        {   
            StringBuilder stringBuilder = new StringBuilder("select * from GARBAGE.Turno where ");

            foreach (KeyValuePair<string, object> filtro in filtrosTurnoList)
            {
                stringBuilder.Append(filtro.Key);
                stringBuilder.Append(" = '");
                stringBuilder.Append(filtro.Value);
                stringBuilder.Append("'");
            }

            SqlDataReader dataReader = SQLManager.executeQuery(stringBuilder.ToString());
            return getTurnos(dataReader);
        }
    }
}
