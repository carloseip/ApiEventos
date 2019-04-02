using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAO;

namespace BO
{
    public class DistritoBO
    {
        public List<Distrito> ListarDistritos()
        {
            return DistritoDAO.Listar();
        }
        public List<Distrito> ListarDistritos(string NombreDistrito)
        {
            return DistritoDAO.Listar(NombreDistrito);
        }

    }
}
