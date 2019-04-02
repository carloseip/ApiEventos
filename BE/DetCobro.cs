using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class DetCobro
    {
        public int IdCobro { get; set; }
        public string DNI { get; set; }
        public int idTipoCobro { get; set; }
        public string TipoDoc { get; set; }
        public string SerieDoc { get; set; }
        public string NumeroDoc { get; set; }
        public string Moneda { get; set; }
        public float MontoCobrado { get; set; }
        public string TipoDocCobro { get; set; }
        public string NumOperacion { get; set; }
        public string Observacion { get; set; }
    }
}
