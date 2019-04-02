using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAO;

namespace BO
{
    public class Det_Evento_ServicioBO
    {

        public List<Servicio> BuscarServiciosDelEvento(int idevento)
        {


            return DAO.Det_Evento_ServicioDAO.BuscarDetEvento_Servicio(idevento);
        }

        public string Insertar(Det_Evento_Servicio value)
        {


            return DAO.Det_Evento_ServicioDAO.Ingresar(value);
        }
        public string EiminarDetEvento_Servicio(int IdEvento, int idservicio)
        {
            return Det_Evento_ServicioDAO.Eliminar(IdEvento, idservicio);
        }
    }
}
