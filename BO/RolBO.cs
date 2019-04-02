using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAO;

namespace BO
{
    public class RolBO
    {
        public List<Rol> ListarRol()
        {
            return RolDAO.Listar();
        }
    }
}
