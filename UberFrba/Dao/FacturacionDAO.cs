using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFrba.Dto;
using UberFrba.Repository;

namespace UberFrba.Dao
{
    class FacturacionDAO
    {

        internal static System.Data.IDataReader getViajesNoFacturados(DateTime dateTime, ClienteDTO cliente)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("fecha", dateTime);
            parametros.Add("cli_id", cliente.id);

            return SQLManager.executeProcedureList("getViajesNoFacturados", parametros);
        }
    }
}
