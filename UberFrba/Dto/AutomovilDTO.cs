using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Dto
{
    public class AutomovilDTO
    {
        private int p1;
        private int p2;
        private string p3;
        private string p4;
        private string p5;


        public int id { get; set; }
        public int marca_id { get; set; }
        public string marca_nombre { get; set; }
        public int modelo_id { get; set; }
        public string modelo_nombre { get; set; }
        public string patente { get; set; }
        public int licencia { get; set; }
        public string rodado { get; set; }
        public int chofer_id { get; set; }
        public int turno_id { get; set; }


        public AutomovilDTO(int _marca_id, int _modelo_id, string _patente, int _licencia, string _rodado,int _chofer_id,int _turno_id)
        {
        marca_id = _marca_id;
        modelo_id = _modelo_id;
        patente= _patente; 
        licencia= _licencia;
        rodado = _rodado;
        chofer_id = _chofer_id;
        turno_id = _turno_id; 
        
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
