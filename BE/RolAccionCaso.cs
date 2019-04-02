using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class RolAccionCaso
    {
        public String Nombre { get; set; }
        public String Siglas { get; set; }
        public List<AccionCaso> listaCasoAccion { get; set; }
    }
}
