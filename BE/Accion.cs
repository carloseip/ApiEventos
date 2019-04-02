using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Accion
    {
        public int IdAccion { get; set; }
        public String Nombre { get; set; }
        public String Siglas { get; set; }
        public int IdAccionPrevia { get; set; }
        public String Descripcion { get; set; }
    }
}
