using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Ventas
    {
        public string NumeroDoc { get; set; }
        public string Evento { get; set; }
        public string Local { get; set; }
        public DateTime Fecha { get; set; }
        public float PrecioTotal { get; set; }
    }
}
