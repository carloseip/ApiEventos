using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class DetAsistencia
    {
        public string DNI { get; set; }
        public int IdEvento { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime HoraLlegada { get; set; }
    }
}
