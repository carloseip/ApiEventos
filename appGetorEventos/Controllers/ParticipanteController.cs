using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BO;
using BE;
using System.Web.Http.Cors;

namespace ApiSeguraEventos.Controllers
{
    [EnableCors("*", "*", "*")]
    public class ParticipanteController : ApiController
    {
        ParticipanteBO gestorParticipante = new ParticipanteBO();

        // GET: api/Participante
        [HttpGet]
        public IEnumerable<Participante> Get()
        {
            return gestorParticipante.ListarParticipantes();
        }
        // GET: api/Participante
        [HttpGet]
        [Route("api/participantes")]
        public IEnumerable<ParticipanteModel> GetModel()
        {
            return gestorParticipante.ListarParticipantesModel();
        }
        // GET: api/Participante/5123425
        [HttpGet]
        public Participante Get(string DNI)
        {
            return gestorParticipante.ListarParticipanteDNI(DNI);
        }
        // POST: api/Participante
        [HttpPost]
        public string Post([FromBody]Participante value)
        {
            return gestorParticipante.IngresarParticipante(value);
        }
        // PUT: api/Participante
        [HttpPut]
        public string Put([FromBody]Participante value)
        {
            return gestorParticipante.ActualizarParticipante(value);
        }
        // PUT: api/eliminarParticipante/5
        [HttpPut]
        [Route("api/eliminarParticipante")]
        public string Put(string DNI)
        {
            return gestorParticipante.EiminarParticipante(DNI);
        }
        // DELETE: api/Participante/5242546
        [HttpDelete]
        public string Delete(string DNI)
        {
            return gestorParticipante.EiminarParticipante(DNI);
        }
    }
}
