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

        //Probar si funciona
        public static int  addNewTurno(TurnoDTO turno)
        {
            return SQLManager.executePorcedure("altaTurno", null);
            // modificar para darle los parametros.

        }

        //Probar si funciona
        public static int deleteTurno(int turno_id)
        {
            return SQLManager.executePorcedure("bajaLogicaTurno", null);

        }
        

        // Probar si funciona
        public static List<TurnoDTO> getAllTurnos()
        {
            SqlDataReader dataReader = SQLManager.executeProcedureList("getAllTurnos",null);

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
                    turno.horaInicial = Convert.ToDateTime(dataReader["turno_hora_inicio"]);
                    turno.horaFinal = Convert.ToDateTime(dataReader["turno_hora_final"]);
                    turno.descripcion =  Convert.ToString(dataReader["turno_descripcion"]);
                    turno.valor = Convert.ToDouble(dataReader["turno_valor_km"]);
                    turno.precio = Convert.ToDouble(dataReader["turno_precio_base"]);

                    listaTurnos.Add(turno);
                }
            }
            dataReader.Close();
            dataReader.Dispose();
            return listaTurnos;
        }


        
    }
}
