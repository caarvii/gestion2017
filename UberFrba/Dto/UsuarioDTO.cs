using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Dto
{
    public class UsuarioDTO
    {
        public int userId { get; set; }
        public string Username { get; set; }
        public bool Habilitado { get; set; }
        public int Intentos { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public List<RolDTO> Roles { get; set; }
    }
}
