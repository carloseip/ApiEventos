using System;
using System.Collections.Generic;
using System.Text;
using BE;
using DAO;

namespace BO
{
    public class TipoEventoBO
    {

        public List<TipoEvento> Listar() {
            return DAO.TipoEventoDAO.Listar();

        }

        public TipoEvento BuscarEvento(int id)
        {
            return DAO.TipoEventoDAO.BuscarEvento(id);

        }

        public string Ingresar(TipoEvento value)
        {
            return DAO.TipoEventoDAO.Ingresar(value);

        }

        public string Actualizar(TipoEvento value)
        {
            return DAO.TipoEventoDAO.Actualizar(value);

        }
        public string Eliminar(int id)
        {
            return DAO.TipoEventoDAO.Eliminar(id);

        }
    }
}
