﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Dto
{
    public class UsuarioDTO
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public bool activo { get; set; }
        public int intentos { get; set; }
        public List<RolDTO> rolesList { get; set; }

        public UsuarioDTO(String _username, String _password)
        {
            username = _username;
            password = _password;
        }

        public UsuarioDTO()
        {
            // TODO: Complete member initialization
        }
    }

   
}
