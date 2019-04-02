using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BE;
using DAO;

namespace BO
{
    public class DetEvento_EncargadoBO
    {

        public List<DetEvento_EncargadoModelView> Listar() {

            return DAO.DetEvento_EncargadoDAO.Listar();

        }

        public DetEvento_EncargadoModelView BuscarEncargadoDelEvento(int idevento) {


            return DAO.DetEvento_EncargadoDAO.BuscarEncargado(idevento);
        }

        public string Insertar(DetEvento_Encargado value) {


            return DAO.DetEvento_EncargadoDAO.Ingresar(value);
        }

        public string Actualizar(DetEvento_Encargado value)
        {


            return DAO.DetEvento_EncargadoDAO.Actualizar(value);
        }
        public EncargadoModelView Encargado(int idevento)
        {


            return DAO.DetEvento_EncargadoDAO.Encargado(idevento);
        }
        public string EiminarDetEvento_Encargado(int IdEvento, string dni)
        {
            return DetEvento_EncargadoDAO.Eliminar(IdEvento, dni);
        }
    }
}
