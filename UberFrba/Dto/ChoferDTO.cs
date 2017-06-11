using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba
{
    class ChoferDTO
    {
        private string nombre { get; set; }
        private string apellido { get; set; }
        private Int32 dni { get; set; }
        private string direccion { get; set; }
        private Int32 telefono { get; set; }
        private string mail { get; set; }
        private DateTime fechaNacimiento { get; set; }

        // Podria faltar la herencia de Usuario

        public ChoferDTO(string nombre_var , string apellido_var , Int32 dni_var , string direccion_var , Int32 telefono_var , string mail_var , DateTime fechaNac_var)
        {
            this.nombre = nombre_var;
            this.apellido = apellido_var;
            this.dni = dni_var;
            this.direccion = direccion_var;
            this.telefono = telefono_var;
            this.mail = mail_var;
            this.fechaNacimiento = fechaNac_var;
        }

        public ChoferDTO()
        {
        }
    }
}
