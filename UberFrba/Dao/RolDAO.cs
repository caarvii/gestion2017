using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFrba.Dao;
using UberFrba.Dto;
using UberFrba.Repository;

namespace UberFrba.Dao
{
    public static class RolDAO
    {
        public static List<RolDTO> ReaderToListClaseRol(SqlDataReader dataReader)
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

        public static RolDTO selectRolById(int id)
        {
                SqlConnection con = Conexion.obtenerConexion();
                SqlCommand com = new SqlCommand("SELECT * FROM GARBAGE.Rol WHERE rol_id=" + id, con);
                SqlDataReader reader = com.ExecuteReader();
                List<RolDTO> Roles = ReaderToListClaseRol(reader);
                if (Roles.Count == 0) return null;
                return Roles[0];
           
        }

        public static List<RolDTO> getRolListByUserId(int userId)
        {
            SqlDataReader dataReader = SQLManager.executeProcedureList("getRolListByUserId",
                SQLManager.getSingleParams("user_id", userId));
              
            return ReaderToListClaseRol(dataReader); 
        }
    }
}
