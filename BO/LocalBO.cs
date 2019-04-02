using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAO;

namespace BO
{
    public class LocalBO
    {
        public List<Local> ListarLocal()
        {
            return LocalDAO.Listar();
        }
        public Local ListarLocal(int IdLocal)
        {
            return LocalDAO.Listar(IdLocal);
        }
        public Local ListarLocal(string NombreLocal)
        {
            return LocalDAO.Listar(NombreLocal);
        }
        public string IngresarLocal(Local value)
        {
            return LocalDAO.Ingresar(value);
        }
        public string ActualizarLocal(Local value)
        {
            return LocalDAO.Actualizar(value);
        }
        public string EliminarLocal(int id)
        {
            return LocalDAO.Eliminar(id);
        }
    }
}

