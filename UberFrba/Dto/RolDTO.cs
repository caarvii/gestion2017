using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Dto
{
    public class RolDTO
    {
        public int IdRol{ get;set;}
        public string NombreRol{get;set;}
        public List<FuncionalidadDTO> ListaFunc{get;set;}
        public bool Estado{get;set;}

        public RolDTO(){
            this.ListaFunc = new List<FuncionalidadDTO>();
            this.Estado = true;
        }

        public override string ToString()
        {
            return this.NombreRol;
        }

        public override bool Equals(object obj)
        {

            var item = obj as RolDTO;

            if (item == null)
                return false;

            if (this.Estado == item.Estado && this.NombreRol == item.NombreRol)
            {
                return true;
            }
            else{
                return false;
            }

        }
    }
}
