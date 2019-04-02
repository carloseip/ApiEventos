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
    public class DetEvento_PonenteController : ApiController
    {
        DetEvento_PonenteBO gestorDetEvento_Ponente = new DetEvento_PonenteBO();

        // GET: api/DetEvento_Ponente
        [HttpGet]
        public IEnumerable<DetEvento_Ponente> Get()
        {
            return gestorDetEvento_Ponente.ListarDetEvento_Ponente();
        }
        [HttpGet]
        public IEnumerable<PonenteModelView> BuscarPonentes(int IdEvento)
        {
            return gestorDetEvento_Ponente.BuscarPonentes(IdEvento);
        }
        // GET: api/DetEvento_Ponente/5/5
        [HttpGet]
        public DetEvento_Ponente Get(string DocIdentidad, int IdEvento)
        {
            return gestorDetEvento_Ponente.ListarDetEvento_Ponente(DocIdentidad, IdEvento);
        }
        // POST: api/DetEvento_Ponente
        [HttpPost]
        public string Post([FromBody]DetEvento_Ponente value)
        {
            return gestorDetEvento_Ponente.IngresarDetEvento_Ponente(value);
        }
        // PUT: api/DetEvento_Ponente/5
        [HttpPut]
        public string Put([FromBody]DetEvento_Ponente value)
        {
            return gestorDetEvento_Ponente.ActualizarDetEvento_Ponente(value);
        }
        // DELETE: api/DetEvento_Ponente/5/5
        [HttpDelete]
        public string Delete(string DocIdentidad, int IdEvento)
        {
            return gestorDetEvento_Ponente.EiminarDetEvento_Ponente(DocIdentidad, IdEvento);
        }
    }
}
