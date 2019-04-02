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
    public class LocalController : ApiController
    {
        LocalBO gestorLocal = new LocalBO();

        // GET: api/Local
        [HttpGet]
        public IEnumerable<Local> Get()
        {
            return gestorLocal.ListarLocal();
        }

        // GET: api/Local/5
        [HttpGet]
        public Local Get(int id)
        {
            return gestorLocal.ListarLocal(id);
        }
        // GET: api/Local/5
        [HttpGet]
        public Local Get(string nombre)
        {
            return gestorLocal.ListarLocal(nombre);
        }

        // POST: api/Local
        [HttpPost]
        public string Post([FromBody]Local value)
        {
            return gestorLocal.IngresarLocal(value);
        }

        // PUT: api/Local/5
        [HttpPut]
        public string Put([FromBody]Local value)
        {
            return gestorLocal.ActualizarLocal(value);
        }

        // DELETE: api/Local/5
        [HttpDelete]
        public string Delete(int id)
        {
            return gestorLocal.EliminarLocal(id);
        }
    }
}
