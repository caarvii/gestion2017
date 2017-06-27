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
        public int dni { get; set; }
        public String mail { get; set; }
        public int telefono { get; set; }
        public String direccion { get; set; }
        public int codigoPostal { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public bool estado { get; set; }

        public ClienteDTO(String _nombre, String _apellido, int _dni, String _mail, int _telefono, String _direccion, int _codigoPostal, DateTime _fechaNacimiento , bool _estado)
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

