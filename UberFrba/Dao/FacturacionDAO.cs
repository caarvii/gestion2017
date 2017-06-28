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
    class FacturacionDAO
    {

        internal static System.Data.IDataReader getViajesNoFacturados(DateTime dateTime, ClienteDTO cliente)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("fecha", dateTime);
            parametros.Add("cli_id", cliente.id);

            return SQLManager.executeProcedureList("getViajesNoFacturados", parametros);
        }

        internal static void facturar(DateTime dateTime, ClienteDTO cliente, List<Facturacion.ItemFactura> viajesParaFacturarList)
        {
            try
            {
                DataTable table = new DataTable();
                table.Columns.Add("viaje_id", typeof(int));
                table.Columns.Add("viaje_desc", typeof(string));
                table.Columns.Add("viaje_costo", typeof(double));

                foreach (Facturacion.ItemFactura itemFactura in viajesParaFacturarList)
                {
                    table.Rows.Add(itemFactura.viajeId, itemFactura.viajeDesc, itemFactura.viajeCosto);
                }

                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("fecha", dateTime);
                parametros.Add("cli_id", cliente.id);
                parametros.Add("viajes", table);

                SQLManager.executePorcedure("Facturar", parametros);
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
