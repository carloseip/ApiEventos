using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAO;

namespace BO
{
    public class DetAsistenciaBO
    {
        public List<DetAsistencia> ListarDetAsistencia()
        {
            return DetAsistenciaDAO.Listar();
        }
        public DetAsistencia ListarDetAsistencia(string DNI, int IdEvento)
        {
            return DetAsistenciaDAO.Listar(DNI, IdEvento);
        }
        public string IngresarDetAsistencia(DetAsistencia value)
        {
            return DetAsistenciaDAO.Ingresar(value);
        }
        public string EiminarDetAsistencia(string DNI, int IdEvento)
        {
            return DetAsistenciaDAO.Eliminar(DNI, IdEvento);
        }
        public string ActualizarDetAsistencia(DetAsistencia value)
        {
            return DetAsistenciaDAO.Actualizar(value);
        }
    }
}
