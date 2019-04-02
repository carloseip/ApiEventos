using System;
using System.Collections.Generic;
using System.Text;
using BE;
using DAO;


namespace BO
{
    public class ServicioBO
    {

        public List<Servicio> Listar() {

            return DAO.ServicioDAO.Listar();
        }
        public List<Servicio> BuscarServiciosDelEvento(int id)
        {

            return DAO.ServicioDAO.BuscarServicios(id);
        }


        public Servicio BuscarServicio(int id)
        {

            return DAO.ServicioDAO.BuscarServicio(id);
        }

        public string Insertar(Servicio value)
        {
            return DAO.ServicioDAO.Ingresar(value);
        }

        public string Actualizar(Servicio value)
        {
            return DAO.ServicioDAO.Actualizar(value);
        }

        public string Eliminar(int id)
        {
            return DAO.ServicioDAO.Eliminar(id);
        }
    }
}
