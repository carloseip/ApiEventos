using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class CarteraCobro
    {
        public int IdCarteraCobro { get; set; }
        public string TipoDoc { get; set; }
        public string SerieDoc { get; set; }
        public string NumeroDoc { get; set; }
        public string Moneda { get; set; }
        public float MontoOriginal { get; set; }
        public float MontoPagado { get; set; }
        public string TipoCartera { get; set; }
        public int IdCabVenta { get; set; }
        public int IdEvento { get; set; }
    }
}
