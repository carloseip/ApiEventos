using System;
using System.Collections.Generic;
using System.Text;
using BE;
using DAO;

namespace BO
{
    public class CobroBO
    {

        public List<CobroModelView> Listar()
        {

            return DAO.CobroDAO.Listar();
        }

        public CobroModelView BuscarCobro(int id)
        {

            return DAO.CobroDAO.BuscarCobro(id);
        }

        public string IngresarCobro(CobroModelView cobro)
        {
            return CobroDAO.IngresarCobro(cobro);
        }


        public string ActualizarCobro(CobroModelView cobro)
        {
            return CobroDAO.ActualizarCobro(cobro);
        }

        public string DeleteCobro(int id)
        {
            return CobroDAO.DeleteCobro(id);
        }

    }
}
