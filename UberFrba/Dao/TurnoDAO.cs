using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFrba.Dto;

namespace UberFrba.Dao
{
    class TurnoDAO
    {
        /*
        public static List<TurnoDTO> ReaderToListClaseRol(SqlDataReader dataReader)
        {
            List<RolDTO> listaRoles = new List<RolDTO>();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    RolDTO rol = new RolDTO();
                    rol.id = Convert.ToInt32(dataReader["rol_id"]);
                    rol.nombre = Convert.ToString(dataReader["rol_nombre"]);
                    rol.activo = Convert.ToBoolean(dataReader["rol_activo"]);
                    rol.funcionalidadesList = FuncionalidadDAO.getFuncionalidadListByRol(rol.id);

                    listaRoles.Add(rol);
                }
            }
            dataReader.Close();
            dataReader.Dispose();
            return listaRoles;

        }



        public static TurnoDTO selectTurnoById(int id)
        {
            SqlConnection con = Conexion.obtenerConexion();
            SqlCommand com = new SqlCommand("SELECT * FROM GARBAGE.Rol WHERE rol_id=" + id, con);
            SqlDataReader reader = com.ExecuteReader();
            List<RolDTO> Roles = ReaderToListClaseRol(reader);
            if (Roles.Count == 0) return null;
            return Roles[0];

        }

        public static List<String> getAllTurnoDescripcion()
        {
            SqlDataReader dataReader = SQLManager.executeProcedureList("getRolListByUserId",
                SQLManager.getSingleParams("user_id", userId));

            return ReaderToListClaseRol(dataReader);
        }


        */
    }
}
