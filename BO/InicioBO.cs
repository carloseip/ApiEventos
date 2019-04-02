using System;
using System.Collections.Generic;
using System.Text;
using BE;
using DAO;

namespace BO
{
    public class InicioBO
    {
        public IEnumerable<Inicio> Listar()
        {
            return InicioDAO.Listar();
        }
    }
}
