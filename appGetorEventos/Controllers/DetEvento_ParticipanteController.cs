using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BE;
using BO;

namespace ApiSeguraEventos.Controllers
{
    [EnableCors("*", "*", "*")]
    public class DetEvento_ParticipanteController : ApiController
    {
        private DetEvento_ParticipanteBO gestorDetEvento_Participante = new DetEvento_ParticipanteBO();

        // GET: api/DetEvento_Participante
        [Route("api/ListaEventosConParticipantes")]
        public IEnumerable<DetEvento_ParticipanteModelView> Get()
        {
            return gestorDetEvento_Participante.Listar();
        }

        // GET: api/DetEvento_Participante/5
        [Route("api/ListadeParticipantesporEvento")]
        public IEnumerable<DetEvento_ParticipanteModelView> Get(int id)
        {
            return gestorDetEvento_Participante.BuscarParticipantes(id);
        }

        // POST: api/DetEvento_Participante
        [Route("api/IngresarConfirmaciondeAsistencia")]
        public string Post([FromBody]DetEvento_Participante value)
        {

            return gestorDetEvento_Participante.Insertar(value);
        }

        // PUT: api/DetEvento_Participante/5
        [Route("api/ActualizarConfirmaciondeAsistencia")]
        public string Put( [FromBody]DetEvento_Participante value)
        {

            return gestorDetEvento_Participante.Actualizar(value);
        }

        // DELETE: api/DetEvento_Participante/5
        public void Delete(int id)
        {
        }
    }
}
