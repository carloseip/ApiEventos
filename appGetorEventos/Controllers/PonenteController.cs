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
    public class PonenteController : ApiController
    {
        PonenteBO gestorPonente = new PonenteBO();

        // GET: api/Ponente
        [HttpGet]
        public IEnumerable<Ponente> Get()
        {
            return gestorPonente.ListarPonente();
        }
        // GET: api/Ponente/51243536478
        [HttpGet]
        public Ponente Get(string DocIdentidad)
        {
            return gestorPonente.ListarPonenteDocIdentidad(DocIdentidad);
        }
        // POST: api/Ponente
        [HttpPost]
        public string Post([FromBody]Ponente value)
        {
            return gestorPonente.IngresarPonente(value);
        }
        // PUT: api/Ponente
        [HttpPut]
        public string Put([FromBody]Ponente value)
        {
            return gestorPonente.ActualizarPonente(value);
        }
        // DELETE: api/Ponente/2345623476
        [HttpDelete]
        public string Delete(string DocIdentidad)
        {
            return gestorPonente.EiminarPonente(DocIdentidad);
        }
    }
}
