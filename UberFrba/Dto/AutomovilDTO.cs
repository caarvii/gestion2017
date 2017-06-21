using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Dto
{
    class AutomovilDTO
    {
        private int p1;
        private int p2;
        private string p3;
        private string p4;
        private string p5;


        public int auto_id { get; set; }
        public int auto_marca_id { get; set; }
        public string auto_marca_nombre { get; set; }
        public int auto_modelo_id { get; set; }
        public string auto_modelo_nombre { get; set; }
        public string auto_patente { get; set; }
        public string auto_licencia { get; set; }
        public string auto_rodado { get; set; }
        public int auto_chofer_id { get; set; }
        public int auto_turno_id { get; set; }


        public AutomovilDTO(int _auto_marca_id, int _auto_modelo_id, string _auto_patente, string _auto_licencia, string _auto_rodado,int _auto_chofer_id,int _auto_turno_id)
        {
        auto_marca_id = _auto_marca_id;
        auto_modelo_id = _auto_modelo_id;
        auto_patente= _auto_patente; 
        auto_licencia= _auto_licencia;
        auto_rodado = _auto_rodado;
        auto_chofer_id = _auto_chofer_id;
        auto_turno_id = _auto_turno_id; 
        
        }

        public AutomovilDTO() { }

        public AutomovilDTO(int p1, int p2, string p3, string p4, string p5)
        {
            // TODO: Complete member initialization
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
            this.p4 = p4;
            this.p5 = p5;
        }
        









    }
}
