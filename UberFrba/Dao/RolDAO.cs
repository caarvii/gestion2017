using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFrba.Dao;
using UberFrba.Dto;

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
                    rol.IdRol = Convert.ToInt32(dataReader["Id"]);
                    rol.NombreRol = Convert.ToString(dataReader["Nombre"]);
                    rol.Estado = Convert.ToBoolean(dataReader["Activo"]);
                    rol.ListaFunc = FuncionalidadDAO.selectByRol(rol);

                    listaRoles.Add(rol);
                }
            }
            dataReader.Close();
            dataReader.Dispose();
            return listaRoles;

        }

        public static RolDTO SelectById(int Id)
        {
                SqlConnection con = Conexion.obtenerConexion();
                SqlCommand com = new SqlCommand("SELECT * FROM GARBAGE.Rol WHERE Id=" + Id, con);
                SqlDataReader reader = com.ExecuteReader();
                List<RolDTO> Roles = ReaderToListClaseRol(reader);
                if (Roles.Count == 0) return null;
                return Roles[0];
           
        }

        public static List<RolDTO> SelectByUser(UsuarioDTO usuario)
        {
            using (SqlConnection conn = Conexion.obtenerConexion())
            {
                SqlCommand com = new SqlCommand("SELECT R.rol_id, R.rol_nombre, R.rol_activo FROM GARBAGE.Usuario U JOIN GARBAGE.Rol R ON U.Rol = R.Id WHERE U.Id=" + usuario.userId, conn);
                SqlDataReader dataReader = com.ExecuteReader();
                return ReaderToListClaseRol(dataReader);
            }
        }
    }
}
