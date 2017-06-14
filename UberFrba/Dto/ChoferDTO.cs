using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba
{
    class ChoferDTO
    {
        private int id { get; set; }
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


        public override string ToString()
        {
            return this.nombre + this.apellido;
        }

        public override bool Equals(object obj)
        {

            var item = obj as ChoferDTO;

            if (item == null)
                return false;

            if (this.nombre == item.nombre && this.apellido == item.apellido && this.dni == item.dni)
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
