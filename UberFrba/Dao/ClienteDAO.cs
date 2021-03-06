﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using UberFrba.Repository;
using UberFrba.Dto;

namespace UberFrba.Dto
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
                    cliente.dni = Convert.ToInt64(dataReader["cli_dni"]);
                    cliente.mail = Convert.ToString(dataReader["cli_mail"]);
                    cliente.telefono = Convert.ToInt64(dataReader["cli_telefono"]);
                    cliente.direccion = Convert.ToString(dataReader["cli_direccion"]);
                    cliente.codigoPostal = Convert.ToInt64(dataReader["cli_cp"]);
                    cliente.fechaNacimiento = Convert.ToDateTime(dataReader["cli_fecha_nacimiento"]);
                    cliente.estado = Convert.ToBoolean(dataReader["cli_activo"]);

                    clientes.Add(cliente);

                }
            }
            dataReader.Close();
            dataReader.Dispose();
            return clientes;

       }

        public static List<ClienteDTO> getAllClientes()
        {
            SqlDataReader reader = SQLManager.executeProcedureList("getClientes");
            return readerToListCliente(reader);
        }

        public static ClienteDTO getClienteById(int clienteId)
        {
            SqlDataReader reader = SQLManager.executeProcedureList("getClienteById",
                SQLManager.getSingleParams("cli_id", clienteId));
            return readerToListCliente(reader).First();
        }

        public static ClienteDTO getClienteByUserId(int usuarioId)
        {
            SqlDataReader reader = SQLManager.executeProcedureList("getClienteByUsuarioId",
            SQLManager.getSingleParams("usuario_id", usuarioId));
            return readerToListCliente(reader).First();
        }

        internal static List<ClienteDTO> getClientesFilter(Dictionary<string, object> filtrosClienteList, Boolean onlyEnabled)
        {
            StringBuilder stringBuilder = new StringBuilder("select * from GARBAGE.Cliente where cli_activo = " + (onlyEnabled ? 1 : 0) + " and ");

            int a = 0;

            foreach (KeyValuePair<string, object> filtro in filtrosClienteList)
            {
                if (a > 0)
                {
                    stringBuilder.Append(" and ");
                }

                if (filtro.Key.Equals("cli_dni"))
                {
                    stringBuilder.Append(filtro.Key);
                    stringBuilder.Append(" = '");
                    stringBuilder.Append(filtro.Value);
                    stringBuilder.Append("' ");
                }

                else {

                    stringBuilder.Append(filtro.Key);
                    stringBuilder.Append(" like '%");
                    stringBuilder.Append(filtro.Value);
                    stringBuilder.Append("%' ");
                }

                a++;
               
            }

            SqlDataReader dataReader = SQLManager.executeQuery(stringBuilder.ToString());
            return readerToListCliente(dataReader);
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
            parameters.Add("cli_fecha_nacimiento", cliente.fechaNacimiento);

            // El estado se habilita por defecto en 1.

            try
            {
                SQLManager.executePorcedure("altaCliente", parameters);
            }
            catch (SqlException exception)
            {
                if (exception.Number == 50000 || exception.Number == 70000)
                {
                    throw new ApplicationException(exception.Message);
                }
                else
                {
                    throw exception;
                }
            }
        
        
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
            parameters.Add("cli_fecha_nacimiento", cliente.fechaNacimiento);
            parameters.Add("cli_activo", cliente.estado);

            // Usuario no se updetea

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

        public static List<ClienteDTO> getClientesHabilitados()
        {
            SqlDataReader reader = SQLManager.executeProcedureList("getClientesHabilitados");
            return readerToListCliente(reader);
        }

    }
}
