using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Data;
using UberFrba.Dto;
using UberFrba.Dao;
using UberFrba.Repository;

namespace UberFrba.Login
{
    public class Sesion
    {
        private static RolDTO rolActual { get; set; }
        private static UsuarioDTO usuarioActual { get; set; }
        private static bool logued { get; set; }

        public static RolDTO RolActual{
            get{ return rolActual; }
            set{ rolActual = value; }
        }

        public static UsuarioDTO UsuarioActual
        {
            get { return usuarioActual; }
            set { usuarioActual = value; }
        }

        private static byte[] getSHA256(string value)
        {
            SHA256Managed crypt = new SHA256Managed();
            return crypt.ComputeHash(Encoding.UTF8.GetBytes(value), 0, Encoding.UTF8.GetByteCount(value));
        }

        public static UsuarioDTO login(string username, string password)
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@username", username);
                parameters.Add("@password", getSHA256(password));

                int userId = SQLManager.executePorcedure("Login", parameters);

                UsuarioDTO usuario = UsuarioDAO.getUsuarioById(userId);
                usuario.rolesList = RolDAO.getRolListByUserId(userId);

                if (usuario.rolesList.Count == 0) throw new ApplicationException("El usuario " + username +
                    " no tiene ningun rol asignado");

                usuarioActual = usuario;

                logued = true;

                return usuarioActual;
            }
            catch (SqlException ex)
            {
                if (ex.Number == 50000) //Si es una exception que ejecutamos nosotros.
                    throw new ApplicationException(ex.Message);
                else 
                    throw ex;
            }
        }

        public static void logout()
        {
            logued = false;
            usuarioActual = null;
            rolActual = null;
        }
        

    }
}
