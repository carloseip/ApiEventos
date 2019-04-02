using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Eventos
    {
        public int IdEvento { get; set; }
        public int IdTipoEvento { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public List<DetEvento_Fecha> DetalleEvento{get;set;} 

    }
}
