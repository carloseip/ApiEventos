using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BO;
using BE;
using System.Web.Http.Cors;

namespace appGetorEventos.Controllers
{
    [EnableCors("*", "*", "*")]
    public class DetEvento_ServiciosController : ApiController
    {
        private Det_Evento_ServicioBO gestorDetEvento_Servicio = new Det_Evento_ServicioBO();

        // GET: api/DetEvento_Servicios
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/DetEvento_Servicios/5
        public IEnumerable<Servicio> Get(int IdEvento)
        {
            return gestorDetEvento_Servicio.BuscarServiciosDelEvento(IdEvento);
        }

        // POST: api/DetEvento_Servicios
        public string Post([FromBody]Det_Evento_Servicio value)
        {
            return gestorDetEvento_Servicio.Insertar(value);
        }

        // PUT: api/DetEvento_Servicios/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/DetEvento_Servicios/5
        public string Delete(int IdEvento,int IdServicio)
        {
            return gestorDetEvento_Servicio.EiminarDetEvento_Servicio(IdEvento, IdServicio);
        }
    }
}
