using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Dto
{
    public class RolDTO
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public List<FuncionalidadDTO> funcionalidadesList { get; set; }
        public bool activo { get; set; }

        public RolDTO(){
            this.funcionalidadesList = new List<FuncionalidadDTO>();
            this.activo = true;
        }

        public override string ToString()
        {
            return this.nombre;
        }

        public override bool Equals(object obj)
        {

            var item = obj as RolDTO;

            if (item == null)
                return false;

            if (this.activo == item.activo && this.nombre == item.nombre)
            {
                return true;
            }
            else{
                return false;
            }

        }
    }
}
