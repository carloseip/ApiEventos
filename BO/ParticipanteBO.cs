using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAO;

namespace BO
{
    public class ParticipanteBO
    {
        public List<ParticipanteModel> ListarParticipantesModel()
        {
            return ParticipanteDAO.ListarParticipantes();
        }
        public List<Participante> ListarParticipantes()
        {
            return ParticipanteDAO.Listar();
        }
        public Participante ListarParticipanteDNI(string DNI)
        {
            return ParticipanteDAO.Listar(DNI);
        }
        public string IngresarParticipante(Participante value)
        {
            return ParticipanteDAO.Ingresar(value);
        }
        public string EiminarParticipante(string DNI)
        {
            return ParticipanteDAO.Eliminar(DNI);
        }
        public string ActualizarParticipante(Participante value)
        {
            return ParticipanteDAO.Actualizar(value);
        }
    }
}
