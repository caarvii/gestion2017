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
                    chofer.mail = Convert.ToString(dataReader["chof_mail"]);
                    chofer.direccion = Convert.ToString(dataReader["chof_direccion"]);
                    chofer.telefono = Convert.ToInt32(dataReader["chof_telefono"]);
                    chofer.fechaNacimiento = Convert.ToDateTime(dataReader["chof_fecha_nacimiento"]);
                    chofer.estado = Convert.ToBoolean(dataReader["chof_activo"]);

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

        public static ChoferDTO getChoferById(int chofer_id)
        {
            SqlDataReader reader = SQLManager.executeProcedureList("getChoferById",
            SQLManager.getSingleParams("chofer_id", chofer_id));
            return ReaderToListChofer(reader).First();
        }


        public static int deleteChofer(int chofer_id)
        {

            return SQLManager.executePorcedure("bajaLogicaChofer", SQLManager.getSingleParams("chof_id", chofer_id));

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
            parameters.Add("chof_fecha_nacimiento", chofer.fechaNacimiento);

            // El estado se habilita por defecto en 1.

            try
            {
                SQLManager.executePorcedure("altaChofer", parameters);
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

        public static void updateChofer(ChoferDTO chofer)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("chof_id", chofer.id);
            parameters.Add("chof_nombre", chofer.nombre);
            parameters.Add("chof_apellido", chofer.apellido);
            parameters.Add("chof_dni", chofer.dni);
            parameters.Add("chof_mail", chofer.mail);
            parameters.Add("chof_telefono", chofer.telefono);
            parameters.Add("chof_direccion", chofer.direccion);
            parameters.Add("chof_fecha_nacimiento", chofer.fechaNacimiento);
            parameters.Add("chof_activo", chofer.estado);
            
            // Usuario no se updetea

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


        internal static List<ChoferDTO> getChoferFilter(Dictionary<string, object> filtrosChoferList)
        {
            StringBuilder stringBuilder = new StringBuilder("select * from GARBAGE.Chofer where ");

            foreach (KeyValuePair<string, object> filtro in filtrosChoferList)
            {
                stringBuilder.Append(filtro.Key);
                stringBuilder.Append(" = '");
                stringBuilder.Append(filtro.Value);
                stringBuilder.Append("'");
            }

            SqlDataReader dataReader = SQLManager.executeQuery(stringBuilder.ToString());
            return ReaderToListChofer(dataReader);
        }




    }
}
