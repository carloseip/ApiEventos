using BE;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class ClienteEmpresaModelBO
    {
        public List<ClienteEmpresaModel> ListarClienteEmpresa()
        {
            return ClienteEmpresaModelDAO.Listar();
        }
    }
}
