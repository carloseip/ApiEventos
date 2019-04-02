using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class DetEvento_Local
    {
        public int IdLocal { get; set; }
        public int IdEvento { get; set; }
        public DateTime FechaIni { get; set; }
        public DateTime FechaFin { get; set; }
        public float Costo { get; set; }
        public string Comentario { get; set; }
    }
}
