using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAO;

namespace BO
{
    public class RolAccionCasoBO
    {
        public string IngresarRolAccionCaso(RolAccionCaso value)
        {
            return RolAccionCasoDAO.Ingresar(value);
        }
    }
}
