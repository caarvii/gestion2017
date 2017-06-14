using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Dao
{
    class ClienteDTO:UsuarioDTO{
    
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

 

        
        




        }



    }

