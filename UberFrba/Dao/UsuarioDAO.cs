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
        public UsuarioDTO getUsuarioById(int userId)
        {
           SqlDataReader dataReader = SQLManager.executeProcedureList("getUsuarioById", SQLManager.getSingleParams("userId", userId));
           return getUsuarios(dataReader).First();
        }

        private List<UsuarioDTO> getUsuarios(SqlDataReader dataReader)
        {
            List<UsuarioDTO> listaUsuarios = new List<UsuarioDTO>();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    UsuarioDTO usuario = new UsuarioDTO();
                    usuario.id = Convert.ToInt32(dataReader["usu_id"]);
                    usuario.username = Convert.ToString(dataReader["usu_username"]);
              //      usuario.password = Convert.To(dataReader["usu_password"]);

                    listaUsuarios.Add(usuario);
                }
            }
            dataReader.Close();
            dataReader.Dispose();
            return listaUsuarios;
        }


    }
}
