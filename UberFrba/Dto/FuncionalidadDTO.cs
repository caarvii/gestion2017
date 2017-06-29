using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Dto
{
    public class FuncionalidadDTO
    {
        public enum Funcionalidad
        {
            ABM_ROL,
	        ABM_CLIENTE,
	        ABM_AUTOMOVIL,
            AMB_TURNO,
            AMB_CHOFER,
            REGISTRAR_VIAJE,
            RENDICION_DE_VIAJES,
            FACTURACION_CLIENTES,
	        LISTADO_ESTADISTICO
        }

        public Funcionalidad toFuncionalidad() { 
            return (Funcionalidad) Enum.Parse(typeof(Funcionalidad), (this.id - 1).ToString());
        }

        public int id { get; set;}
        public string descripcion { get; set;}

        public FuncionalidadDTO(){
        }

        public FuncionalidadDTO(int id, string desc)
        {
            this.id = id;
            descripcion = desc;
        }

        public override string ToString()
        {
            return descripcion;
        }

        public override bool Equals(object obj)
        {
            var item = obj as FuncionalidadDTO;

            if (item == null)
            {
                return false;
            }

            return item.descripcion == this.descripcion;
        }

        public override int GetHashCode()
        {
            return 1;
        }
    }
}
