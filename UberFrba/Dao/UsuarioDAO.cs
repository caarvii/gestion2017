using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFrba.Dto;
using UberFrba.Repository;

namespace UberFrba.Dao
{
    class UsuarioDAO
    {
        public static UsuarioDTO getUsuarioById(int userId)
        {
           SqlDataReader dataReader = SQLManager.executeProcedureList("getUsuarioById", 
               SQLManager.getSingleParams("user_id", userId));
           return getUsuarios(dataReader).First();
        }

        private static List<UsuarioDTO> getUsuarios(SqlDataReader dataReader)
        {
            List<UsuarioDTO> listaUsuarios = new List<UsuarioDTO>();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    UsuarioDTO usuario = new UsuarioDTO();
                    usuario.id = Convert.ToInt32(dataReader["usu_id"]);
                    usuario.username = Convert.ToString(dataReader["usu_username"]);
                    byte[] binaryPassword = (byte[]) dataReader["usu_password"];
                    usuario.password = Encoding.UTF8.GetString(binaryPassword);
                    usuario.intentos = Convert.ToInt32(dataReader["usu_intentos"]);
                    usuario.activo = Convert.ToBoolean(dataReader["usu_activo"]);

                    listaUsuarios.Add(usuario);
                }
            }
            dataReader.Close();
            dataReader.Dispose();
            return listaUsuarios;
        }


    }
}
