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
    public class DetEvento_LocalController : ApiController
    {
        DetEvento_LocalBO gestorDetEvento_Local = new DetEvento_LocalBO();

        // GET: api/DetEvento_Local
        [HttpGet]
        public IEnumerable<DetEvento_Local> Get()
        {
            return gestorDetEvento_Local.ListarDetEvento_Local();
        }

        // GET: api/DetEvento_Local/5/4
        [HttpGet]
        public DetEvento_Local Get(int IdEvento, int IdLocal)
        {
            return gestorDetEvento_Local.ListarDetEvento_Local(IdEvento, IdLocal);
        }
        [HttpGet]
        public LocalModelView Get(int IdEvento)
        {
            return gestorDetEvento_Local.getLocal(IdEvento);
        }
        // POST: api/DetEvento_Local
        
        // PUT: api/DetEvento_Local
        [HttpPut]
        [Route("api/actualizarLocal")]
        public string Put([FromBody]DetEvento_Local value)
        {
            return gestorDetEvento_Local.ActualizarDetEvento_Local(value);
        }
        [HttpPost]
        [Route("api/asignarLocal")]
        public string Post([FromBody]DetEvento_Local value)
        {
            return gestorDetEvento_Local.IngresarDetEvento_Local(value);
        }
        // DELETE: api/DetEvento_Local/5/4
        [HttpDelete]
        public string Delete(int IdEvento, int IdLocal)
        {
            return gestorDetEvento_Local.EiminarDetEvento_Local(IdEvento, IdLocal);
        }
    }
}
