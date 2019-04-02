using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAO;

namespace BO
{
    public class DetEvento_LocalBO
    {
        public List<DetEvento_Local> ListarDetEvento_Local()
        {
            return DetEvento_LocalDAO.Listar();
        }
        public DetEvento_Local ListarDetEvento_Local(int IdEvento, int IdLocal)
        {
            return DetEvento_LocalDAO.Listar(IdEvento,IdLocal);
        }
        public string IngresarDetEvento_Local(DetEvento_Local value)
        {
            return DetEvento_LocalDAO.Ingresar(value);
        }
        public string EiminarDetEvento_Local(int IdEvento, int IdLocal)
        {
            return DetEvento_LocalDAO.Eliminar(IdEvento,IdLocal);
        }
        public string ActualizarDetEvento_Local(DetEvento_Local value)
        {
            return DetEvento_LocalDAO.Actualizar(value);
        }
        public LocalModelView getLocal(int IdEvento)
        {
            return DetEvento_LocalDAO.GetLocal(IdEvento);
        }
    }
}
