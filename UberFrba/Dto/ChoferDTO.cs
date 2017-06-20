using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba
{
    class ChoferDTO
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public Int32 dni { get; set; }
        public string direccion { get; set; }
        public Int32 telefono { get; set; }
        public string mail { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public bool estado { get; set; }

        // Podria faltar la herencia de Usuario

        public ChoferDTO(string nombre_var , string apellido_var , Int32 dni_var , string direccion_var , Int32 telefono_var , string mail_var , DateTime fechaNac_var , bool estado)
        {
            this.nombre = nombre_var;
            this.apellido = apellido_var;
            this.dni = dni_var;
            this.direccion = direccion_var;
            this.telefono = telefono_var;
            this.mail = mail_var;
            this.fechaNacimiento = fechaNac_var;
            this.estado = estado;
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
