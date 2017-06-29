using System;
using System.Collections.Generic;
using System.Data;
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

        private static Dictionary<string, object> createRolParams(string rolNombre, List<FuncionalidadDTO> funcionalidadesXRol)
        {
            DataTable table = new DataTable();
            table.Columns.Add("funcionalidad_id", typeof(int));
            foreach (FuncionalidadDTO funcionalidad in funcionalidadesXRol)
            {
                table.Rows.Add(funcionalidad.id);
            }

            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("rol_nombre", rolNombre);
            parametros.Add("funcionalidades", table);
            return parametros;
        }

        internal static void createRol(string rolNombre, List<FuncionalidadDTO> funcionalidadesXRol)
        {
            executeRolProcedure("createRol", createRolParams(rolNombre, funcionalidadesXRol));
        }

        internal static void updateRol(int rolId, string rolNombre, bool rolActivo, List<FuncionalidadDTO> funcionalidadesXRol)
        {
            Dictionary<string, object> parametros = createRolParams(rolNombre, funcionalidadesXRol);
            parametros.Add("rol_id", rolId);
            parametros.Add("rol_activo", rolActivo);

            executeRolProcedure("updateRol", parametros);
        }

        private static void executeRolProcedure(string procedureName, Dictionary<string, object> parametros)
        {
            try
            {
                SQLManager.executePorcedure(procedureName, parametros);
            }
            catch (SqlException exception)
            {
                if (exception.Number == 50000)
                    throw new ApplicationException(exception.Message);
                else
                    throw exception;
            }
        }

        internal static void deleteRol(int rolId)
        {
            executeRolProcedure("bajaLogica", SQLManager.getSingleParams("rol_id", rolId));
        }
    }
}
