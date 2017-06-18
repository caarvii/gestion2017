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
        public static List<RolDTO> parseRoles(SqlDataReader dataReader)
        {
            List<RolDTO> listaRoles = new List<RolDTO>();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    RolDTO rol = new RolDTO();
                    rol.id = Convert.ToInt32(dataReader["rol_id"]);
                    rol.nombre = Convert.ToString(dataReader["rol_nombre"]).Trim();
                    rol.activo = Convert.ToBoolean(dataReader["rol_activo"]);
                    rol.funcionalidadesList = FuncionalidadDAO.getFuncionalidadListByRol(rol.id);

                    listaRoles.Add(rol);
                }
            }
            dataReader.Close();
            dataReader.Dispose();
            return listaRoles;

        }

        public static RolDTO getRolById(int id)
        {
            SqlDataReader reader = SQLManager.executeProcedureList("getRolById", 
                SQLManager.getSingleParams("rol_id", id));
            return parseRoles(reader).First();
        }

        public static List<RolDTO> getRolListByUserId(int userId)
        {
            SqlDataReader dataReader = SQLManager.executeProcedureList("getRolListByUserId",
                SQLManager.getSingleParams("user_id", userId));

            return parseRoles(dataReader);
        }

        internal static List<RolDTO> getRoles()
        {
            SqlDataReader reader = SQLManager.executeProcedureList("getRoles");
            return parseRoles(reader);
        }
    }
}
