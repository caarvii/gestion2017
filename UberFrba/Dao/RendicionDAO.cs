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
    class RendicionDAO
    {
        public static List<TurnoDTO> getTurnosViajesByChofer(ChoferDTO chofer)
        {
            SqlDataReader reader = SQLManager.executeProcedureList("getTurnosViajesByChofer", 
                SQLManager.getSingleParams("chof_id", chofer.id));
            return TurnoDAO.getTurnos(reader);
        }
    }
}
