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
    public class DetEvento_FechaController : ApiController
    {
        DetEvento_FechaBO gestorDetEvento_Fecha = new DetEvento_FechaBO();

        // GET: api/DetEvento_Fecha
        [HttpGet]
        public IEnumerable<DetEvento_Fecha> Get()
        {
            return gestorDetEvento_Fecha.ListarDetEvento_Fecha();
        }
        // GET: api/DetEvento_Fecha/5
        [HttpGet]
        public IEnumerable<DetEvento_Fecha> Get(int id)
        {
            return gestorDetEvento_Fecha.ListarDetEvento_Fecha(id);
        }
        // POST: api/DetEvento_Fecha
        [HttpPost]
        public string Post([FromBody]DetEvento_Fecha value)
        {
            return gestorDetEvento_Fecha.IngresarDetEvento_Fecha(value);
        }
        // PUT: api/DetEvento_Fecha/
        [HttpPut]
        public string Put([FromBody]DetEvento_Fecha value)
        {
            return gestorDetEvento_Fecha.ActualizarDetEvento_Fecha(value);
        }
        // DELETE: api/DetEvento_Fecha/IdEvento/Fecha
        [HttpDelete]
        public string Delete(int IdEvento, DateTime Fecha)
        {
            return gestorDetEvento_Fecha.EiminarDetEvento_Fecha(IdEvento, Fecha);
        }
    }
}
