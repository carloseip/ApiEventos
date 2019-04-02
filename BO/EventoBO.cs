using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAO;

namespace BO
{
    public class EventoBO
    {
        public List<CabEvento> ListarEvento()
        {
            return EventoDAO.Listar();
        }
        public CabEvento ListarEvento(int IdEvento)
        {
            return EventoDAO.Listar(IdEvento);
        }
        public CabEvento ListarEvento(string Nombre)
        {
            return EventoDAO.Listar(Nombre);
        }
        public string EliminarEvento(int Id)
        {
            return EventoDAO.Eliminar(Id);
        }
        public string ActualizarEvento(Eventos value)
        {
            return EventoDAO.Actualizar(value);
        }
        public string IngresarEvento(Eventos value)
        {
            return EventoDAO.Ingresar(value);
        }
    }
}
