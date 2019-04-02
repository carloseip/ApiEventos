using System;
using System.Collections.Generic;
using System.Text;
using DAO;
using BE;

namespace BO
{
    public class DetEvento_ParticipanteBO
    {

        public List<DetEvento_ParticipanteModelView> Listar() {

            return DAO.DetEvento_ParticipanteDAO.Listar();
        }


        public List<DetEvento_ParticipanteModelView> BuscarParticipantes(int IdEvento)
        {

            return DAO.DetEvento_ParticipanteDAO.BuscarParticipantes(IdEvento);
        }


        public string Insertar(DetEvento_Participante value) {

            return DAO.DetEvento_ParticipanteDAO.Ingresar(value);

        }


        public string Actualizar(DetEvento_Participante value)
        {

            return DAO.DetEvento_ParticipanteDAO.Actualizar(value);

        }
    }
}
