using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFrba.Dto;

namespace UberFrba.Dto
{
    public class ClienteDTO{

        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public Int64 dni { get; set; }
        public String mail { get; set; }
        public Int64 telefono { get; set; }
        public String direccion { get; set; }
        public Int64 codigoPostal { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public bool estado { get; set; }

        public ClienteDTO(String _nombre, String _apellido, Int64 _dni, String _mail, Int64 _telefono, String _direccion, Int64 _codigoPostal, DateTime _fechaNacimiento, bool _estado)
        {
            nombre=_nombre;
            apellido = _apellido;
            dni = _dni;
            mail = _mail;
            telefono = _telefono;
            direccion = _direccion;
            codigoPostal = _codigoPostal;
            fechaNacimiento=_fechaNacimiento;
            estado = _estado;
        }


        public ClienteDTO() { }


        public override string ToString()
        {
            return this.nombre + this.apellido;
        }

        public override bool Equals(object obj)
        {

            var item = obj as ClienteDTO;

            if (item == null)
                return false;

            if (this.nombre == item.nombre && this.apellido == item.apellido && this.dni == item.dni )
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

