using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class DetEvento_Material
    {
        public int IdEvento { get; set; }
        public int IdMaterial { get; set; }
        public float CostoUnitario { get; set; }
        public int Cantidad { get; set; }
    }
}
