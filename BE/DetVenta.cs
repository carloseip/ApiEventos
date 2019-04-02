using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class DetVenta
    {
        public int IdCabVenta { get; set; }
        public int IdEvento { get; set; }
        public string Servicio { get; set; }
        public int Cantidad { get; set; }
        public float Precio { get; set; }
        public byte Descuento { get; set; }
        public float ValTotal { get; set; }
        public byte IVA { get; set; }
        public float Total { get; set; }
    }
}
