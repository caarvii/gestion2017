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
    class ClienteDAO
    {

        public static List<ClienteDTO> readerToListCliente(SqlDataReader dataReader)
        {

            List<ClienteDTO> clientes = new List<ClienteDTO>();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    ClienteDTO cliente = new ClienteDTO();
                    cliente.id = Convert.ToInt32(dataReader["cli_id"]);
                    cliente.nombre = Convert.ToString(dataReader["cli_nombre"]);
                    cliente.apellido = Convert.ToString(dataReader["cli_apellido"]);
                    cliente.dni = Convert.ToInt32(dataReader["cli_dni"]);
                    cliente.mail = Convert.ToString(dataReader["cli_mail"]);
                    cliente.telefono = Convert.ToInt32(dataReader["cli_telefono"]);
                    cliente.direccion = Convert.ToString(dataReader["cli_direccion"]);
                    cliente.codigoPostal = Convert.ToInt32(dataReader["cli_cp"]);
                    //cliente.fechaNacimiento = Convert.ToDateTime(dataReader["cli_fechanac"]);
                    cliente.activo = Convert.ToBoolean(dataReader["cli_activo"]);
                    clientes.Add(cliente);
                }
            }
            dataReader.Close();
            dataReader.Dispose();
            return clientes;

       }


        public static List<ClienteDTO> getAllClientes()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            SqlDataReader reader = SQLManager.executeProcedureList("getClientes", parameters);
            return readerToListCliente(reader);
        }


        public static void addNewCliente(ClienteDTO cliente){
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("cli_nombre", cliente.nombre);
            parameters.Add("cli_apellido", cliente.apellido);
            parameters.Add("cli_dni", cliente.dni);
            parameters.Add("cli_mail", cliente.mail);
            parameters.Add("cli_telefono", cliente.telefono);
            parameters.Add("cli_direccion", cliente.direccion);
            parameters.Add("cli_cp", cliente.codigoPostal);
            parameters.Add("cli_fechanac", cliente.fechaNacimiento);
            parameters.Add("usu_usuario", cliente.username);
            parameters.Add("usu_password", cliente.password);

            try
            {
                SQLManager.executePorcedure("altaCliente", parameters);
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

        
        public static ClienteDTO getClienteById(int clienteId)
        {
            SqlDataReader reader = SQLManager.executeProcedureList("getClienteById",
            SQLManager.getSingleParams("cli_id", clienteId));
            return readerToListCliente(reader).First();
        }

        public static void updateCliente(ClienteDTO cliente){
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("cli_id",cliente.id);
            parameters.Add("cli_nombre", cliente.nombre);
            parameters.Add("cli_apellido", cliente.apellido);
            parameters.Add("cli_dni", cliente.dni);
            parameters.Add("cli_mail", cliente.mail);
            parameters.Add("cli_telefono", cliente.telefono);
            parameters.Add("cli_direccion", cliente.direccion);
            parameters.Add("cli_cp", cliente.codigoPostal);
            parameters.Add("cli_fechanac", cliente.fechaNacimiento);

            try
            {
                SQLManager.executePorcedure("updateCliente", parameters);
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

        public static int deleteCliente(int cli_id){
             return SQLManager.executePorcedure("bajaLogicaCliente", SQLManager.getSingleParams("cli_id", cli_id));
        }


    }
}
