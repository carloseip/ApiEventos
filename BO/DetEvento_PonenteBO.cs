using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAO;

namespace BO
{
    public class DetEvento_PonenteBO
    {
        public List<DetEvento_Ponente> ListarDetEvento_Ponente()
        {
            return DetEvento_PonenteDAO.Listar();
        }
        public DetEvento_Ponente ListarDetEvento_Ponente(string DocIdentidad, int IdEvento)
        {
            return DetEvento_PonenteDAO.Listar(DocIdentidad,IdEvento);
        }
        public string IngresarDetEvento_Ponente(DetEvento_Ponente value)
        {
            return DetEvento_PonenteDAO.Ingresar(value);
        }
        public string EiminarDetEvento_Ponente(string DocIdentidad, int IdEvento)
        {
            return DetEvento_PonenteDAO.Eliminar(DocIdentidad, IdEvento);
        }
        public string ActualizarDetEvento_Ponente(DetEvento_Ponente value)
        {
            return DetEvento_PonenteDAO.Actualizar(value);
        }
        public List<PonenteModelView> BuscarPonentes(int id)
        {
            return DetEvento_PonenteDAO.BuscarPonentes(id);
        }

    }
}
