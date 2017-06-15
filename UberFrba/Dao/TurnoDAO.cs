using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFrba.Repository;
using UberFrba.Dto;


namespace UberFrba.Dao
{
    class TurnoDAO
    {
        
        public static List<TurnoDTO> ReaderToListTurno(SqlDataReader dataReader)
        {
            List<TurnoDTO> turnos = new List<TurnoDTO>();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    TurnoDTO turno = new TurnoDTO();
                    turno.id = Convert.ToInt32(dataReader["turno_id"]);
                    //turno.horaInicial = Convert.ToInt32(dataReader["turno_hora_inicio"]);
                    //turno.horaFinal = Convert.ToInt32(dataReader["turno_hora_fin"]);
                    turno.descripcion = Convert.ToString(dataReader["turno_descripcion"]);
                    turno.valor = Convert.ToDouble(dataReader["turno_valor_km"]);
                    turno.precio = Convert.ToDouble(dataReader["turno_precio_base"]);
                    turno.estado = Convert.ToBoolean(dataReader["turno_habilitado"]);

                    turnos.Add(turno);
                }
            }
            dataReader.Close();
            dataReader.Dispose();
            return turnos;

        }
        /*

        public static TurnoDTO selectTurnoById(int id)
        {
            SqlConnection con = Conexion.obtenerConexion();
            SqlCommand com = new SqlCommand("SELECT * FROM GARBAGE.Rol WHERE rol_id=" + id, con);
            SqlDataReader reader = com.ExecuteReader();
            List<RolDTO> Roles = ReaderToListClaseRol(reader);
            if (Roles.Count == 0) return null;
            return Roles[0];

        }
        */


        public static List<TurnoDTO> getAllTurnoDescripcion()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            SqlDataReader reader = SQLManager.executeProcedureList("getTurnos",parameters);
            return ReaderToListTurno(reader);
        }


        
    }
}
