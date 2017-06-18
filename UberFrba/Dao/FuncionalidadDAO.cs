using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFrba.Dto;
using System.Data.SqlClient;
using UberFrba.Repository;

namespace UberFrba.Dao
{
    public static class FuncionalidadDAO
    {
        public static List<FuncionalidadDTO> readerToListFunc(SqlDataReader dataReader)
        {
            List<FuncionalidadDTO> listaFunc = new List<FuncionalidadDTO>();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    FuncionalidadDTO func = new FuncionalidadDTO();
                    func.id = Convert.ToInt32(dataReader["func_id"]);
                    func.descripcion = Convert.ToString(dataReader["func_descripcion"]);

                    listaFunc.Add(func);
                }
            }
            dataReader.Close();
            dataReader.Dispose();
            return listaFunc;
        }

        public static List<FuncionalidadDTO> getFuncionalidadListByRol(int rolId)
        {

            SqlDataReader reader = SQLManager.executeProcedureList("getFuncionalidadListByRolId",
                SQLManager.getSingleParams("rol_id", rolId));
            List<FuncionalidadDTO> funcionalidades = readerToListFunc(reader);
            return funcionalidades; 
        }
    }
}
