using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using UberFrba.Repository;
using UberFrba.Dto;


namespace UberFrba.Dao
{
    class ChoferDAO
    {
        public static List<ChoferDTO> ReaderToListChofer(SqlDataReader dataReader)
        {
            List<ChoferDTO> choferes = new List<ChoferDTO>();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    ChoferDTO chofer = new ChoferDTO();
                    chofer.id = Convert.ToInt32(dataReader["chof_id"]);
                    chofer.dni = Convert.ToInt32(dataReader["chof_dni"]);
                    chofer.nombre = Convert.ToString(dataReader["chof_nombre"]);
                    chofer.apellido = Convert.ToString(dataReader["chof_apellido"]);
                    choferes.Add(chofer);
                }
            }
            dataReader.Close();
            dataReader.Dispose();
            return choferes;

        }

        public static List<ChoferDTO> getAllChoferes()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            SqlDataReader reader = SQLManager.executeProcedureList("getChoferes", parameters);
            return ReaderToListChofer(reader);
        }

        public static ChoferDTO getChoferById(int choferId)
        {
            SqlDataReader reader = SQLManager.executeProcedureList("getChoferById",
            SQLManager.getSingleParams("chof_id", choferId));
            return ReaderToListChofer(reader).First();
        }




        public static void addNewChofer(ChoferDTO chofer)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("chof_nombre", chofer.nombre);
            parameters.Add("chof_apellido", chofer.apellido);
            parameters.Add("chof_dni", chofer.dni);
            parameters.Add("chof_mail", chofer.mail);
            parameters.Add("chof_telefono", chofer.telefono);
            parameters.Add("chof_direccion", chofer.direccion);
            parameters.Add("chof_fechanac", chofer.fechaNacimiento);

            // VER POR AHORA
            //parameters.Add("usu_usuario", chofer.username);
            //parameters.Add("usu_password", chofer.password);


            // Se habilita por defecto en 1
            try
            {
                SQLManager.executePorcedure("altaChofer", parameters);
            }
            catch (SqlException exception)
            {
                if (exception.Number == 50000 || exception.Number == 60000)
                {
                    throw new ApplicationException(exception.Message);
                }
                else
                {
                    throw exception;
                }
            }
        }

        public static void updateChofer(ChoferDTO chofer)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("chof_nombre", chofer.nombre);
            parameters.Add("chof_apellido", chofer.apellido);
            parameters.Add("chof_dni", chofer.dni);
            parameters.Add("chof_mail", chofer.mail);
            parameters.Add("chof_telefono", chofer.telefono);
            parameters.Add("chof_direccion", chofer.direccion);
            parameters.Add("chof_fechanac", chofer.fechaNacimiento);

            
            // Usuario y fecha

            try
            {
                SQLManager.executePorcedure("updateChofer", parameters);
            }
            catch (SqlException exception)
            {
                if (exception.Number == 50000)
                {
                    throw new ApplicationException(exception.Message);
                }
                else
                {
                    throw exception;
                }
            }

        }




    }
}
