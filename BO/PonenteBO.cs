using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAO;


namespace BO
{
    public class PonenteBO
    {
        public List<Ponente> ListarPonente()
        {
            return PonenteDAO.Listar();
        }
        public Ponente ListarPonenteDocIdentidad(string DocIdentidad)
        {
            return PonenteDAO.Listar(DocIdentidad);
        }
        public string IngresarPonente(Ponente value)
        {
            return PonenteDAO.Ingresar(value);
        }
        public string EiminarPonente(string DocIdentidad)
        {
            return PonenteDAO.Eliminar(DocIdentidad);
        }
        public string ActualizarPonente(Ponente value)
        {
            return PonenteDAO.Actualizar(value);
        }
    }
}
