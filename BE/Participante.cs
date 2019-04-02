using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class Participante
    {
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string ApellidoP { get; set; }
        public string ApellidoM { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public DateTime FechaNac { get; set; }
        public string Sexo { get; set; }
        public string Telefono { get; set; }
        public int IdDistrito { get; set; }
        public string RUC { get; set; }
    }
}
