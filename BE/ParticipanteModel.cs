using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class ParticipanteModel
    {
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string ApellidoP { get; set; }
        public string ApellidoM { get; set; }
        public string Direcion { get; set; }
        public string Email { get; set; }
        public DateTime FechaNac { get; set; }
        public string Sexo { get; set; }
        public string Telefono { get; set; }
        public string Distrito { get; set; }
        public string Empresa { get; set; }
    }
}
