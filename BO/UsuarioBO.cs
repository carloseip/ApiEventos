using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAO;

namespace BO
{
    public class UsuarioBO
    {
        public string IngresarUsuario(Usuario usuario)
        {
            return UsuarioDAO.Ingresar(usuario);
        }
        public List<UsuarioModel> Listar()
        {
            return UsuarioDAO.Listar();
        }
        public string EliminarUsuario(int IdUsuario)
        {
            return  UsuarioDAO.Eliminar(IdUsuario);
        }
        public UsuarioModelActualizar ListarUsuario(int IdUsuario)
        {
            return UsuarioDAO.Listar(IdUsuario);
        }
        public string ActualizarUsuario(UsuarioModelActualizar value)
        {
            return UsuarioDAO.Actualizar(value);
        }
    }
}
