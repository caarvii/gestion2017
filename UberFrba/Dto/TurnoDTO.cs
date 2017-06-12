using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba
{
    class TurnoDTO
    {
        private int id { get; set; }
        private DateTime horaInicial { get; set; }
        private DateTime horaFinal { get; set; }
        private string descripcion { get; set; }
        private double valor { get; set; }
        private double precio { get; set; }
        private bool estado { get; set; }


        public TurnoDTO(DateTime horaIni , DateTime horaFin , string desc, double valorKM , double precioBase , bool estado_hab )
        {
            this.horaInicial = horaIni;
            this.horaFinal = horaFin;
            this.descripcion = desc;
            this.valor = valorKM;
            this.precio = precioBase;
            this.estado = estado_hab;

        }

        public TurnoDTO()
        {
            this.estado = true;
        }

        public override string ToString()
        {
            return this.descripcion + this.horaInicial;
        }

        public override bool Equals(object obj)
        {

            var item = obj as TurnoDTO;

            if (item == null)
                return false;

            if (this.estado == item.estado && this.descripcion == item.descripcion && this.horaInicial == item.horaInicial && this.horaFinal == item.horaFinal)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


    }
}
