using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFrba.Dto;
using UberFrba.Repository;

namespace UberFrba.Dao
{
    class RendicionDAO
    {
        public static List<TurnoDTO> getTurnosViajesByChofer(ChoferDTO chofer)
        {
            SqlDataReader reader = SQLManager.executeProcedureList("getTurnosViajesByChofer", 
                SQLManager.getSingleParams("chof_id", chofer.id));
            return TurnoDAO.getTurnos(reader);
        }

        public static SqlDataReader getViajesNoRendidos(ChoferDTO chofer, TurnoDTO turno, DateTime dateTime)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("chof_id", chofer.id);
            parametros.Add("turno_id", turno.id);
            parametros.Add("fecha", dateTime);
            parametros.Add("porcentaje_rendicion", Config.newInstance.porcentajeRendicion);

            return SQLManager.executeProcedureList("getViajesNoRendidos", parametros);
        }

        internal static void generarRendicion(ChoferDTO chofer, TurnoDTO turno, DateTime dateTime, 
            double importeTotal, List<int> viajesParaRendirList)
        {
            try
            {

                DataTable table = new DataTable();
                table.Columns.Add("viaje_id", typeof(int));
                foreach (int viajeId in viajesParaRendirList)
                {
                    table.Rows.Add(viajeId);
                }

                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("chof_id", chofer.id);
                parametros.Add("turno_id", turno.id);
                parametros.Add("fecha", dateTime);
                parametros.Add("importe_total", importeTotal);
                parametros.Add("viajes", table);

                SQLManager.executePorcedure("generarRendicion", parametros);
            }
            catch (SqlException exception)
            {
                if (exception.Number == 50000)
                    throw new ApplicationException(exception.Message);
                else
                    throw exception;
            }
        }
    }
}
