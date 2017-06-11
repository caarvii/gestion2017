using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Abm_Cliente
{
    class UsuarioDTO
    {
        private String username;
        private String password;

        public UsuarioDTO(String _username,String _password) {
            username = _username;
            password = _password;
        }


    }
}
