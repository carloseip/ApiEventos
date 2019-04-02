using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAO;

namespace BO
{
    public class ClienteEmpresaBO
    {
        public List<ClienteEmpresa> ListarClienteEmpresa()
        {
            return ClienteEmpresaDAO.Listar();
        }
        public ClienteEmpresa ListarClienteEmpresaRUC(string RUC)
        {
            return ClienteEmpresaDAO.Listar(RUC);
        }
        public string IngresarClienteEmpresa(ClienteEmpresa value)
        {
            return ClienteEmpresaDAO.Ingresar(value);
        }
        public string EiminarClienteEmpresa(string RUC)
        {
            return ClienteEmpresaDAO.Eliminar(RUC);
        }
        public string ActualizarClienteEmpresa(ClienteEmpresa value)
        {
            return ClienteEmpresaDAO.Actualizar(value);
        }
    }
}
