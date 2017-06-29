using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using UberFrba.Dto;
using UberFrba.Repository;

namespace UberFrba.Dao
{
    class ViajeDAO
    {
        private static List<ViajeDTO> getViajesReader(SqlDataReader dataReader)
        {
            List<ViajeDTO> listaViajes = new List<ViajeDTO>();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    ViajeDTO viaje = new ViajeDTO();

                    viaje.id = Convert.ToInt32(dataReader["viaje_id"]);
                    viaje.auto_id = Convert.ToInt32(dataReader["viaje_auto_id"]);
                    viaje.turno_id = Convert.ToInt32(dataReader["viaje_turno_id"]);
                    viaje.chof_id = Convert.ToInt32(dataReader["viaje_chof_id"]);
                    viaje.cant_km = Convert.ToInt32(dataReader["viaje_cant_km"]);
                    viaje.fechaInicio = Convert.ToDateTime(dataReader["fecha_hora_ini"]);
                    viaje.fechaFinal = Convert.ToDateTime(dataReader["fecha_hora_fin"]);
                    viaje.cli_id = Convert.ToInt32(dataReader["viaje_cli_id"]);
                    viaje.rendido = Convert.ToInt32(dataReader["viaje_rendido"]);
                    viaje.duplicado = Convert.ToInt32(dataReader["viaje_duplicado"]);

                    listaViajes.Add(viaje);
                }
            }
            dataReader.Close();
            dataReader.Dispose();
            return listaViajes;
        }

        public static void addNewViaje(ViajeDTO viaje)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("viaje_auto_id", viaje.auto_id);
            parameters.Add("viaje_turno_id", viaje.turno_id);
            parameters.Add("viaje_chof_id", viaje.chof_id);
            parameters.Add("viaje_cant_km", viaje.cant_km);
            parameters.Add("fecha_hora_ini", viaje.fechaInicio);
            parameters.Add("fecha_hora_fin", viaje.fechaFinal);
            parameters.Add("viaje_cli_id", viaje.cli_id);
            
             // Se evalua en el procedimiento

            //parameters.Add("viaje_rendido", 0);
            //parameters.Add("viaje_duplicado", 0);

            // Se habilita por defecto en 1

            try
            {
                SQLManager.executePorcedure("altaViaje", parameters);
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
