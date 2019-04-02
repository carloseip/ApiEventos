using System;
using System.Collections.Generic;
using System.Text;
using BE;
using DAO;

namespace BO
{
    public class TipoCobroBO
    {

        public List<TipoCobro> Listar() {


            return DAO.TipoCobroDAO.Listar();
        }

        public TipoCobro BuscarTipoCobro(int id)
        {


            return DAO.TipoCobroDAO.BuscarTipoCobro(id);
        }

        public string Insertar(TipoCobro value)
        {


            return DAO.TipoCobroDAO.Ingresar(value);
        }

        public string Actualizar(TipoCobro value)
        {


            return DAO.TipoCobroDAO.Actualizar(value);
        }


        public string Eliminar(int id)
        {


            return DAO.TipoCobroDAO.Eliminar(id);
        }
    }
}
