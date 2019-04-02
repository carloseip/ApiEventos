using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BE
{
    public class Encargado
    {
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string ApellidoP { get; set; }
        public string ApellidoM { get; set; }
        public string Direccion { get; set; }
        public string NomDistrito { get; set; }
        public string Email { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaNac { get; set; }
        public char Sexo { get; set; }
        public string Telefono { get; set; }
        public int? IdDistrito { get; set; }
        public int? Estado { get; set; }
    }
}
