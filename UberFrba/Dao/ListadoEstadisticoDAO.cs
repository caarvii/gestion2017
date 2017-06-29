using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFrba.Repository;

namespace UberFrba.Dao
{
    class ListadoEstadisticoDAO
    {
        public static SqlDataReader consultarListado(String procedure, int trimestre, int anio)
        {

            Dictionary<String, object> parameters = new Dictionary<String, object>();
            parameters.Add("trimestre", trimestre);
            parameters.Add("anio", anio);

            switch (procedure) {

                case ("Choferes con mayor recaudacion"):
                    SqlDataReader reader = SQLManager.executeProcedureList("choferes_mayor_recaudacion", parameters);
                    return reader;

                case ("Choferes con el viaje mas largo realizado"):
                    SqlDataReader reader2 = SQLManager.executeProcedureList("choferes_viaje_mas_largo", parameters);
                    return reader2;

                case ("Clientes con mayor consumo"):
                    SqlDataReader reader3 = SQLManager.executeProcedureList("clientes_mayor_consumo", parameters);
                    return reader3;
                
                case ("Cliente que utilizo mas veces mismo automovil"):
                    SqlDataReader reader4 = SQLManager.executeProcedureList("clientes_mismo_auto", parameters);
                    return reader4;

                default: throw new ApplicationException("Debe elegir una funcionalidad disponible");
            }
        }
    }
}
