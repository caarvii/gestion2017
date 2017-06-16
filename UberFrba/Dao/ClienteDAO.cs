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
        /*
        SqlDataReader reader = SQLManager.executeProcedureList("getFuncionalidadListByRolId",
    SQLManager.getSingleParams("rol_id", rolId));
                    List<FuncionalidadDTO> funcionalidades = readerToListFunc(reader);
            return funcionalidades; 
        */
        
        public static ClienteDTO getClienteById(int clienteId)
        {
            SqlDataReader reader = SQLManager.executeProcedureList("getClienteById",
            SQLManager.getSingleParams("cli_id", clienteId));
            return readerToListCliente(reader).First();
        }

        public static void modificarCliente(ClienteDTO cliente){



        }



    }
}
