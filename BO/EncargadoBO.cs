using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAO;

namespace BO
{
    public class EncargadoBO
    {
        public List<Encargado> ListarEncargados()
        {
            return EncargadoDAO.Listar();
        }
        public Encargado ListarEncargadosDNI(string DNI)
        {
            return EncargadoDAO.Listar(DNI);
        }
        public string IngresarEncargado(Encargado value, string nombreDistrito)
        {
            return EncargadoDAO.Ingresar(value, nombreDistrito);
        }
        public string EiminarEncargado(string DNI)
        {
            return EncargadoDAO.Eliminar(DNI);
        }
        public string ActualizarEncargado(Encargado value,string nombre)
        {
            return EncargadoDAO.Actualizar(value, nombre);
        }
    }
}
