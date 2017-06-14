using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFrba.Dto;

namespace UberFrba.Dao
{
    class ClienteDTO:UsuarioDTO{

        private int id { get; set; }
        private string nombre { get; set; }
        private string apellido { get; set; }
        private int dni { get; set; }
        private String mail { get; set; }
        private int telefono { get; set; }
        private String direccion { get; set; }
        private int codigoPostal { get; set; }
        private DateTime fechaNacimiento { get; set; }

        public ClienteDTO(String _nombre, String _apellido, int _dni, String _mail, int _telefono, String _direccion, int _codigoPostal, DateTime _fechaNacimiento,string username,string password):base(username,password){
            nombre=_nombre;
            apellido = _apellido;
            dni = _dni;
            mail = _mail;
            telefono = _telefono;
            direccion = _direccion;
            codigoPostal = _codigoPostal;
            fechaNacimiento=_fechaNacimiento;
        }

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

