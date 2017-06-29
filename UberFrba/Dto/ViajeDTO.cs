using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Dto
{
    public class ViajeDTO
    {
        public int id { get; set; }
        public int auto_id { get; set; }
        public int turno_id { get; set; }
        public int chof_id { get; set; }
        public double cant_km { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFinal { get; set; }
        public int cli_id { get; set; }
        public int rendido { get; set; }
        public int duplicado { get; set; }


        public ViajeDTO(
                         int auto_id,
                         int turno_id,
                         int chof_id,
                         double cant_km,
                         DateTime fechaInicio,
                         DateTime fechaFinal,
                         int cli_id
                        )
        {
            this.auto_id = auto_id;
            this.turno_id = turno_id;
            this.chof_id = chof_id;
            this.cant_km = cant_km;
            this.fechaInicio = fechaInicio;
            this.fechaFinal = fechaFinal;
            this.cli_id = cli_id;
        }


        public ViajeDTO(){}


    }
}
