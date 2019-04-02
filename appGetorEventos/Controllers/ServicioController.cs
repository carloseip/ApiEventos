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
    public class ServicioController : ApiController
    {
        private ServicioBO gestorServicio = new ServicioBO();

        // GET: api/Servicio
        [HttpGet]
        public IEnumerable<Servicio> Get()
        {
            return gestorServicio.Listar();
        }
        // GET: api/Servicio/5
        [HttpGet]
        public Servicio Get(int id)
        {
            return gestorServicio.BuscarServicio(id);
        }
        // POST: api/Servicio
        [HttpPost]
        public string Post([FromBody]Servicio value)
        {
            return gestorServicio.Insertar(value);
        }
        // PUT: api/Servicio
        [HttpPut]
        public string Put( [FromBody]Servicio value)
        {

            return gestorServicio.Actualizar(value);
        }
        // DELETE: api/Servicio/5
        [HttpDelete]
        public string Delete(int id)
        {
            return gestorServicio.Eliminar(id);
        }
    }
}
