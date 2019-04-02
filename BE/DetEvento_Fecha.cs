using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace BE
{
    public class DetEvento_Fecha
    {
        public int IdEvento { get; set; }
        public DateTime Fecha { get; set; }
        public System.TimeSpan HoraEvento { get; set; }
        public string Comentario { get; set; }
    }
}
