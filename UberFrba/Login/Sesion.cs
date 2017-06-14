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
        private static UsuarioDTO usuarioActual;
        private static bool logued;

        private static UsuarioDTO defaultUser()
        {
            return new UsuarioDTO()
            {
                rolesList = new List<RolDTO>() { RolDAO.selectRolById(1) }
            };
        }

        public static List<RolDTO> Roles
        {
            get { return Usuario.rolesList; }
        }

        /// <summary>
        /// Rol seleccionado por el usuario.
        /// </summary>
        public static RolDTO Rol
        {
            get { if (rolActual == null) rolActual = Usuario.rolesList[0]; return rolActual; }
            set
            {
                if (Roles.Contains(value))
                    rolActual = value;
                else
                    throw new ApplicationException("Intento de asignacion de rol no autorizado para el usuario.");
            }

        }

        public static UsuarioDTO Usuario
        {
            get
            {
                if (usuarioActual == null) usuarioActual = defaultUser(); return usuarioActual;
            }
        }

        public static bool Logued { get { return logued; } }

        private static byte[] getSHA256(string value)
        {
            SHA256Managed crypt = new SHA256Managed();
            return crypt.ComputeHash(Encoding.UTF8.GetBytes(value), 0, Encoding.UTF8.GetByteCount(value));
        }

        public static void Login(string username, string password)
        {
            try
            {
               
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@username", username);
                parameters.Add("@password", getSHA256(password));

                int id = SQLManager.executePorcedure("Login", parameters);

                UsuarioDTO usuario = new UsuarioDTO() { id = id, username = username };

                usuario.rolesList = RolDAO.getRolListByUserId(id);

                usuarioActual = usuario;

                logued = true;

                

            }
            catch (SqlException ex)
            {
                if (ex.Number == 50000) //Si es una exception que lancé yo.
                    throw new ApplicationException(ex.Message);
                else throw ex;
            }
        }

        public static void Logout()
        {
            logued = false;
            usuarioActual = defaultUser();
        }
        /*
        public static bool FuncionalidadHabilitada(ClaseFuncionalidad funcionalidad)
        {
            return RolActual.tienePermiso(funcionalidad);
        }
        */
        public static void Start(RolDTO rol)
        {
            if (rol == null)
                StartAsClient();
            else
                StartAsUser(rol);
        }

        public static void StartAsClient()
        {
            usuarioActual = defaultUser();
            rolActual = Roles[0];
        }

        public static void StartAsUser(RolDTO rol)
        {
            rolActual = rol;
        }

        public static void Reset_estado()
        {
            using (SqlConnection conn = Conexion.obtenerConexion())
            {
                SqlCommand com = new SqlCommand("[NORMALIZADOS].[SP_Reset_Estado_Users]", conn);
                com.CommandType = CommandType.StoredProcedure;
                com.ExecuteNonQuery();
            }
        }

        public static void End()
        {
            //CERRAR CONEXION
        }

    }
}
