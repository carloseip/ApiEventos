using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAO;

namespace BO
{
    public class DetEvento_FechaBO
    {
        public List<DetEvento_Fecha> ListarDetEvento_Fecha()
        {
           return DetEvento_FechaDAO.Listar();
        }
        public List<DetEvento_Fecha> ListarDetEvento_Fecha(int IdEvento)
        {
            return DetEvento_FechaDAO.Listar(IdEvento);
        }
        public string IngresarDetEvento_Fecha(DetEvento_Fecha value)
        {
            return DetEvento_FechaDAO.Ingresar(value);
        }
        public string EiminarDetEvento_Fecha(int IdEvento,DateTime Fecha)
        {
            return DetEvento_FechaDAO.Eliminar(IdEvento, Fecha);
        }
        public string ActualizarDetEvento_Fecha(DetEvento_Fecha value)
        {
            return DetEvento_FechaDAO.Actualizar(value);
        }
    }
}
