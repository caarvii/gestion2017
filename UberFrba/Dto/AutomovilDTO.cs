using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Dto
{
    class AutomovilDTO
    {

        public int auto_id { get; set; }
        public int auto_marca_id { get; set; }
        public string auto_marca_nombre { get; set; }
        public int auto_modelo_id { get; set; }
        public string auto_modelo_nombre { get; set; }
        public string auto_patente { get; set; }
        public string auto_licencia { get; set; }
        public string auto_rodado { get; set; }



        public AutomovilDTO(int _auto_marca_id, string _auto_marca_nombre, int _auto_modelo_id, string _auto_modelo_nombre, string _auto_patente, string _auto_licencia, string _auto_rodado)
        {
        auto_marca_id = _auto_marca_id;
        auto_marca_nombre = _auto_marca_nombre;
        auto_modelo_id = _auto_modelo_id;
        auto_modelo_nombre = _auto_modelo_nombre;
        auto_patente= _auto_patente; 
        auto_licencia= _auto_licencia;
        auto_rodado = _auto_rodado;
        
        }

        public AutomovilDTO() { }
        









    }
}
