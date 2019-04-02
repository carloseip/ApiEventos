using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class UsuarioModelActualizar
    {
        public int IdUsuario { get; set; }
        public String DNI { get; set; }
        public String Nombre { get; set; }
        public String ApellidoP { get; set; }
        public String ApellidoM { get; set; }
        public String Telefono { get; set; }
        public String Usuario { get; set; }
        public String Pass { get; set; }
        public String Rol { get; set; }
    }
}
