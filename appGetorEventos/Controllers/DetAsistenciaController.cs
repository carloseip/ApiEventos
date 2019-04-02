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
    [Authorize]
    public class DetAsistenciaController : ApiController
    {
        DetAsistenciaBO gestorDetAsistencia = new DetAsistenciaBO();
        
        // GET: api/DetAsistencia
        [HttpGet]
        public IEnumerable<DetAsistencia> Get()
        {
            return gestorDetAsistencia.ListarDetAsistencia();
        }
        // GET: api/DetAsistencia/47702484/4
        [HttpGet]
        public DetAsistencia Get(string DNI, int IdEvento)
        {
            return gestorDetAsistencia.ListarDetAsistencia(DNI, IdEvento);
        }
        // POST: api/DetAsistencia
        [HttpPost]
        public string Post([FromBody]DetAsistencia value)
        {
            return gestorDetAsistencia.IngresarDetAsistencia(value);
        }
        // PUT: api/DetAsistencia
        [HttpPut]
        public string Put([FromBody]DetAsistencia value)
        {
            return gestorDetAsistencia.ActualizarDetAsistencia(value);
        }
        // DELETE: api/DetAsistencia/43432423/4
        [HttpDelete]
        public string Delete(string DNI, int IdEvento)
        {
            return gestorDetAsistencia.EiminarDetAsistencia(DNI, IdEvento);
        }
    }
}
