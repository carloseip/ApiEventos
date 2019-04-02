using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
   public class ClienteEmpresa
    {
        public string RUC { get; set; }
        public string RazonSocial { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Contacto { get; set; }
        public int IdDistrito { get; set; }
    }
}
