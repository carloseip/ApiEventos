using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class CabVenta
    {
        public int IdCabVenta { get; set; }
        public string TipoDoc { get; set; }
        public string SerieDoc { get; set; }
        public string NumeroDoc { get; set; }
        public string Moneda { get; set; }
        public float PrecioTotal { get; set; }
        public int Descuento { get; set; }
        public float ValVenta { get; set; }
        public string IVA { get; set; }
        public float Total { get; set; }
        public string DNI { get; set; }
        public string RUC { get; set; }
        public List<DetVenta> DetVenta { get; set; }
    }
}
